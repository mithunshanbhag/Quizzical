namespace Quizzical.Strategies.Implementations;

internal class TrueFalseQuizPlayStrategy : SinglePlayerConsoleQuizPlayStrategyBase
{
    protected override dynamic CaptureUserResponse(Question question)
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<bool>()
                //.Title("Select an answer:")
                .HighlightStyle(Color.Cyan1.ToString())
                .PageSize(10)
                .AddChoices(true, false)
        );
    }
}