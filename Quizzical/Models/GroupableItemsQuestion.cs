namespace Quizzical.Models;

/// <summary>
///     Represents a groupable-items question.
/// </summary>
internal class GroupableItemsQuestion : Question
{
    /// <summary>
    ///     The answer choices for the question.
    /// </summary>
    public required string[] AnswerChoices { get; set; }

    /// <summary>
    ///     The indices of the groupable items in the AnswerChoices array.
    /// </summary>
    public required int[] Groupable { get; set; }

    /// <inheritdoc />
    public override bool? Evaluate(QuestionResponse questionResponse)
    {
        if (questionResponse.Response.IsT3) return null;

        var selectedGroup = questionResponse.Response.AsT0;

        return selectedGroup.OrderBy(i => i).SequenceEqual(Groupable.OrderBy(i => i));
    }
}