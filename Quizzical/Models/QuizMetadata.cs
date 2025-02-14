namespace Quizzical.Models;

/// <summary>
///     The metadata required to create a quiz.
/// </summary>
internal class QuizMetadata
{
    /// <summary>
    ///     The type of question.
    /// </summary>
    public QuestionType QuestionType { get; set; }

    /// <summary>
    ///     The difficulty level of the question.
    /// </summary>
    public QuestionDifficultyLevel DifficultyLevel { get; set; }

    /// <summary>
    ///     The number of questions to return.
    /// </summary>
    public int NumberOfQuestions { get; set; }

    /// <summary>
    ///     The topic of the question.
    /// </summary>
    public required string Topic { get; set; }

    /// <summary>
    ///     The keywords associated with the question.
    /// </summary>
    public required List<string> Keywords { get; set; }
}