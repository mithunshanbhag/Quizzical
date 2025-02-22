namespace Quizzical.Strategies.Implementations;

internal class MultipleChoiceQuizPlayStrategy : SinglePlayerConsoleQuizPlayStrategyBase
{
    protected override dynamic? CaptureUserResponse(Question question)
    {
        var multipleChoiceQuestion = (MultipleChoiceQuestion) question;

        var selectedAnswer = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                //.Title("Select an answer:")
                .HighlightStyle(Color.Cyan1.ToString())
                .PageSize(10)
                .AddChoices(
                    multipleChoiceQuestion.AnswerChoices.Append(
                        QuizConstants.SkipOptionText)));

        if (selectedAnswer == QuizConstants.SkipOptionText) return null;

        var selectedAnswerIndex = Array.IndexOf(multipleChoiceQuestion.AnswerChoices, selectedAnswer);

        return selectedAnswerIndex;
    }
}