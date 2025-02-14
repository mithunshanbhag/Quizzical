namespace Quizzical.Models;

internal class Quiz
{
    public required QuizMetadata Metadata { get; set; }

    public required Question[] Questions { get; set; }
}