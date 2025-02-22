namespace Quizzical.Strategies.Implementations;

internal class TrueFalseQuizPlayStrategy : SinglePlayerConsoleQuizPlayStrategyBase
{
    protected override dynamic? CaptureUserResponse(Question question)
    {
        var selectedAnswer = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                //.Title("Select an answer:")
                .HighlightStyle(Color.Cyan1.ToString())
                .PageSize(10)
                .AddChoices(bool.TrueString, bool.FalseString, QuizConstants.SkipOptionText));

        if (selectedAnswer == QuizConstants.SkipOptionText) return null;

        return selectedAnswer == bool.TrueString;
    }
}