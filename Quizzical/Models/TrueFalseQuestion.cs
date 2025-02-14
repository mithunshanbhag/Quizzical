namespace Quizzical.Models;

/// <summary>
///     Represents a true/false question.
/// </summary>
internal class TrueFalseQuestion : Question
{
    /// <summary>
    ///     The correct answer to the true/false question.
    /// </summary>
    public required bool CorrectAnswer { get; set; }

    /// <summary>
    ///     Evaluates the user's selected answer against the correct answer.
    /// </summary>
    /// <param name="answer">
    ///     The selected answer.
    /// </param>
    /// <returns>
    ///     True if the selected answer is correct; otherwise, false.
    /// </returns>
    public override bool Evaluate(dynamic answer)
    {
        bool selectedAnswer = answer;

        return selectedAnswer == CorrectAnswer;
    }
}