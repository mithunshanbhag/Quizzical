namespace Quizzical.Factories.Interfaces;

internal interface IQuestionFactory
{
    Task<Question[]> GenerateAsync(QuizMetadata request, CancellationToken cancellationToken = default);
}