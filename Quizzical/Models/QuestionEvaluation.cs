namespace Quizzical.Models;

internal class QuestionEvaluation
{
    public OneOf<bool, None> Evaluation { get; set; }

    public TimeSpan TimeTaken { get; set; }
}