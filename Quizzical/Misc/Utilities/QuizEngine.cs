namespace Quizzical.Misc.Utilities;

/*
 * Rough algorithm:
 *
 * 1. Show the user a choice of pre-selected topics, and capture their choice.
 * 2. Generate a list of questions for that chosen topic.
 * 3. For each question:
 *    - Show the question to the user.
 *    - Capture the user's answer.
 *    - Check if the user's answer is correct.
 *    - Show the user the correct answer if they were wrong.
 *    - Show the user an explanation of the answer.
 *    - Update the user's score.
 *    - Move on to the next question.
 * 4. When all questions complete, show the user their score.
 * 5. Ask the user if they want to play again.
 *    - If yes, go back to step 1.
 * 6. At any point, if the user wants to quit, they can do so by pressing Ctrl+C.
 */

internal class QuizEngine(IConfiguration config, IQuizFactory quizFactory, IEnumerable<IQuizPlayStrategy> quizPlayStrategies)
{
    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        await ShowBanner(TimeSpan.FromSeconds(1));

        var play = true;

        while (play && !cancellationToken.IsCancellationRequested)
        {
            var quizConfig = GetUserSelections();

            var quiz = await quizFactory.GenerateAsync(quizConfig, cancellationToken);

            IQuizPlayStrategy quizPlayStrategy = quizConfig.QuestionType switch
            {
                QuestionType.MultipleChoice => quizPlayStrategies.OfType<MultipleChoiceQuizPlayStrategy>().Single(),
                QuestionType.TrueFalse => quizPlayStrategies.OfType<TrueFalseQuizPlayStrategy>().Single(),
                _ => throw new NotSupportedException($"Question type {quizConfig.QuestionType} is not supported yet.")
            };

            var quizResponse = await quizPlayStrategy.ExecuteAsync(quiz, cancellationToken);

            DisplayFinalScore(quizResponse);

            play = AskUserToPlayAgain();
        }
    }

    private static async Task ShowBanner(TimeSpan duration)
    {
        AnsiConsole.Write(new FigletText(AppConstants.AppName));
        await Task.Delay(duration);
    }

    private QuizConfig GetUserSelections()
    {
        var quizConfig = config.GetSection(ConfigKeys.QuizConfig).Get<QuizConfig>();

        var selectedTopic = quizConfig?.Topic ?? GetUserSelectedTopic();

        var selectedQuizType = quizConfig?.QuestionType ?? GetUserSelectedQuizType();

        var selectedNumberOfQuestions = quizConfig?.NumberOfQuestions ?? GetUserSelectedNumberOfQuestions();

        var selectedDifficultyLevel = quizConfig?.DifficultyLevel ?? GetUserSelectedDifficultyLevel();

        return new QuizConfig
        {
            QuestionType = selectedQuizType,
            Topic = selectedTopic,
            Keywords = [],
            NumberOfQuestions = selectedNumberOfQuestions,
            DifficultyLevel = selectedDifficultyLevel
        };
    }

    private static QuestionDifficultyLevel GetUserSelectedDifficultyLevel()
    {
        AnsiConsole.Clear();

        return AnsiConsole.Prompt(
            new SelectionPrompt<QuestionDifficultyLevel>()
                .Title("What difficulty level would you like to play?")
                .PageSize(8)
                .HighlightStyle(Color.Cyan1.ToString())
                .AddChoices(QuestionDifficultyLevel.Easy, QuestionDifficultyLevel.Medium, QuestionDifficultyLevel.Hard));
    }

    private static int GetUserSelectedNumberOfQuestions()
    {
        AnsiConsole.Clear();

        return AnsiConsole.Prompt(
            new TextPrompt<int>("How many questions would you like to answer?")
                .DefaultValue(QuizConstants.DefaultNumberOfQuestions)
                .Validate(answer => answer is < 1 or > 20
                    ? ValidationResult.Error("Please enter a number between 1 and 20.")
                    : ValidationResult.Success()));
    }

    private static QuestionType GetUserSelectedQuizType()
    {
        AnsiConsole.Clear();

        return AnsiConsole.Prompt(
            new SelectionPrompt<QuestionType>()
                .Title("What type of quiz would you like to play?")
                .PageSize(8)
                .HighlightStyle(Color.Cyan1.ToString())
                .MoreChoicesText("[cyan](Move up and down to reveal more topics)[/]")
                .AddChoices(QuestionType.MultipleChoice, QuestionType.TrueFalse));
    }

    private static bool AskUserToPlayAgain()
    {
        AnsiConsole.Clear();

        return AnsiConsole.Prompt(
            new ConfirmationPrompt("Would you like to play again?"));
    }

    private static void DisplayFinalScore(QuizResponse _)
    {
        AnsiConsole.Clear();
        //throw new NotImplementedException();
    }

    private static string GetUserSelectedTopic()
    {
        AnsiConsole.Clear();

        return AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Would you like to play a quiz?")
                .PageSize(8)
                .HighlightStyle(Color.Cyan1.ToString())
                .MoreChoicesText("[cyan](Move up and down to reveal more topics)[/]")
                .AddChoices(AppConstants.PreSelectedTopics.Keys));
    }
}