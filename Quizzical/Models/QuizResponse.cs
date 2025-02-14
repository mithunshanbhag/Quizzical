namespace Quizzical.Models;

internal class QuizResponse
{
    public (Question question, bool evaluation) Result { get; set; }
}