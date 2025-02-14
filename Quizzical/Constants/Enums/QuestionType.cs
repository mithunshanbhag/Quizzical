namespace Quizzical.Constants.Enums;

internal enum QuestionType
{
    /// <summary>
    ///     A question with multiple answer choices, and one correct answer.
    /// </summary>
    MultipleChoice = 1,

    /// <summary>
    ///     A question with a true or false answer.
    /// </summary>
    TrueFalse,

    /// <summary>
    ///     A question with multiple answer choices, and multiple correct answers.
    /// </summary>
    /// <remarks>@TODO: Refine this property's name.</remarks>
    [Obsolete("Reserved for future use.")] [EditorBrowsable(EditorBrowsableState.Never)]
    MultipleSelect,

    /// <summary>
    ///     A question with a single answer choice.
    /// </summary>
    [Obsolete("Reserved for future use.")] [EditorBrowsable(EditorBrowsableState.Never)]
    FillInTheBlank,

    /// <summary>
    ///     Answer involves matching items, events, or steps to one another.
    /// </summary>
    [Obsolete("Reserved for future use.")] [EditorBrowsable(EditorBrowsableState.Never)]
    PairMatch,

    /// <summary>
    ///     Answer involves arranging items, events, or steps in the correct sequence (e.g., chronological order, process
    ///     steps).
    /// </summary>
    [Obsolete("Reserved for future use.")] [EditorBrowsable(EditorBrowsableState.Never)]
    Sequence
}