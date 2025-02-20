namespace Quizzical.Models;

internal class Quiz
{
    public required QuizConfig Config { get; set; }

    public required Question[] Questions { get; set; }
}