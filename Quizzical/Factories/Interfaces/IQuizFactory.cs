namespace Quizzical.Factories.Interfaces;

internal interface IQuizFactory
{
    Task<Quiz> GenerateAsync(QuizMetadata request, CancellationToken cancellationToken = default);
}