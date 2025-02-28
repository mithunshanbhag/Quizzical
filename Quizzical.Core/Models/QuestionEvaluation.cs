namespace Quizzical.Core.Models;

public class QuestionEvaluation
{
    public OneOf<bool, None> Evaluation { get; set; }

    public TimeSpan TimeTaken { get; set; }
}