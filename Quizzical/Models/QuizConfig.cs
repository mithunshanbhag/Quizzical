namespace Quizzical.Models;

/// <summary>
///     The configuration required to create a quiz.
/// </summary>
internal class QuizConfig
{
    /// <summary>
    ///     The type of question. See <see cref="Quizzical.Constants.Enums.QuestionType" />
    /// </summary>
    public QuestionType QuestionType { get; set; }

    /// <summary>
    ///     The difficulty level of the question. See <see cref="Quizzical.Constants.Enums.QuestionDifficultyLevel" />
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