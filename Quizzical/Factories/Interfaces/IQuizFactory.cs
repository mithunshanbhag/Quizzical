namespace Quizzical.Factories.Interfaces;

internal interface IQuizFactory
{
    Task<Quiz> GenerateAsync(QuizConfig request, CancellationToken cancellationToken = default);
}