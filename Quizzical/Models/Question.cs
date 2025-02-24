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
    ///     Evaluates the user's selected questionResponse against the correct answer.
    /// </summary>
    /// <remarks>
    ///     The type of the questionResponse parameter will depend on the type of question.
    /// </remarks>
    /// <param name="questionResponse">
    ///     The user's response to the question.
    /// </param>
    /// <returns>
    ///     True if the user's response is correct; False if incorrect; Null if the user has skipped answering.
    /// </returns>
    public abstract bool? Evaluate(QuestionResponse questionResponse);
}