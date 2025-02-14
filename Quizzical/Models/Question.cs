namespace Quizzical.Models;

/// <summary>
///     Represents a question in a quiz.
/// </summary>
internal abstract class Question : IFlaggable
{
    /// <summary>
    ///     The text of the question.
    /// </summary>
    public required string Text { get; set; }

    /// <summary>
    ///     An optional explanation of the answer.
    /// </summary>
    public string? ExplanationText { get; set; }

    /// <inheritdoc />
    public bool IsFlagged { get; set; }

    /// <inheritdoc />
    public string? FlagReason { get; set; }

    /// <summary>
    ///     Evaluates the user's selected answer against the correct answer.
    /// </summary>
    /// <remarks>
    ///     The type of the answer parameter will depend on the type of question.
    /// </remarks>
    /// <param name="answer">
    ///     The user's answer.
    /// </param>
    /// <returns>
    ///     True if the user's answer is correct; otherwise, false.
    /// </returns>
    public abstract bool Evaluate(dynamic answer);
}