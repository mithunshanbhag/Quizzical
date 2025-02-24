using OneOf.Types;

namespace Quizzical.Strategies.Implementations;

internal class TrueFalseQuizPlayStrategy : SinglePlayerConsoleQuizPlayStrategyBase
{
    protected override QuestionResponse CaptureUserResponse(Question question)
    {
        var selectedAnswer = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                //.Title("Select an answer:")
                .HighlightStyle(Color.Cyan1.ToString())
                .PageSize(10)
                .AddChoices(bool.TrueString, bool.FalseString, QuizConstants.SkipOptionText));

        return selectedAnswer == QuizConstants.SkipOptionText
            ? new QuestionResponse { QuestionType = QuestionType.TrueFalse, Response = new None() }
            : new QuestionResponse { QuestionType = QuestionType.TrueFalse, Response = selectedAnswer == bool.TrueString };
    }
}