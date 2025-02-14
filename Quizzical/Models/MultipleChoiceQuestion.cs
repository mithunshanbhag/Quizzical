namespace Quizzical.Models;

/// <summary>
///     Represents a multiple choice question.
/// </summary>
internal class MultipleChoiceQuestion : Question
{
    /// <summary>
    ///     The answer choices for the question.
    /// </summary>
    public required string[] AnswerChoices { get; set; }

    /// <summary>
    ///     The index of the correct answer in the AnswerChoices array.
    /// </summary>
    public required int CorrectAnswerIndex { get; set; }

    /// <summary>
    ///     Evaluates the user's selected answer against the correct answer.
    /// </summary>
    /// <param name="answer">
    ///     The index of the selected answer in the AnswerChoices array.
    /// </param>
    /// <returns>
    ///     True if the selected answer is correct; otherwise, false.
    /// </returns>
    public override bool Evaluate(dynamic answer)
    {
        int selectedAnswerIndex = answer;

        return selectedAnswerIndex == CorrectAnswerIndex;
    }
}