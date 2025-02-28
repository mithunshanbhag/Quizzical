namespace Quizzical.Core.Models;

public class QuizEvaluation
{
    public Dictionary<Question, QuestionEvaluation> Evaluations { get; set; } = [];
}