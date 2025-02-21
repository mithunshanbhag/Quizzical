namespace Quizzical.Models;

internal class QuizEvaluation
{
    public Dictionary<Question, bool> QuestionResponses { get; set; } = new();
}