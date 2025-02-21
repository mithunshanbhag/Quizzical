namespace Quizzical.Models;

/// <summary>
///     Represents a quiz.
/// </summary>
internal class Quiz
{
    /// <inheritdoc cref="QuizConfig" />
    /// >
    public required QuizConfig Config { get; set; }

    /// <summary>
    ///     The questions in the quiz.
    /// </summary>
    public required Question[] Questions { get; set; }
}