namespace Quizzical.Models;

internal class QuizEvaluation
{
    public Dictionary<Question, QuestionEvaluation> Evaluations { get; set; } = [];
}