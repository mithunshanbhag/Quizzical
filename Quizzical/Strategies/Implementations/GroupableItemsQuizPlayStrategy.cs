namespace Quizzical.Strategies.Implementations;

internal class GroupableItemsQuizPlayStrategy : SinglePlayerConsolePlayStrategyBase
{
    protected override dynamic CaptureUserResponse(Question question)
    {
        var groupableItemsQuestion = (GroupableItemsQuestion)question;

        var multiSelection = AnsiConsole.Prompt(
            new MultiSelectionPrompt<string>()
                //.Title("Select an answer:")
                //.Required(false)
                .HighlightStyle(Color.Cyan1.ToString())
                .PageSize(10)
                .AddChoices(groupableItemsQuestion.AnswerChoices));

        var selectedIndices = multiSelection
            .Select(answer => Array.IndexOf(groupableItemsQuestion.AnswerChoices, answer))
            .ToArray();

        return selectedIndices;
    }
}