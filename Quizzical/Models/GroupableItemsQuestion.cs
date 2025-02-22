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

    /// <summary>
    ///     Evaluates the user's selected answer against the correct answer.
    /// </summary>
    /// <param name="answer">
    ///     The indices of the selected groupable items in the AnswerChoices array.
    /// </param>
    /// <returns>
    ///     True if the selected answer is correct; otherwise, false.
    /// </returns>
    public override bool? Evaluate(dynamic? answer)
    {
        if (answer == null) return null;

        int[] selectedGroup = answer;

        return selectedGroup.OrderBy(i => i).SequenceEqual(Groupable.OrderBy(i => i));
    }
}