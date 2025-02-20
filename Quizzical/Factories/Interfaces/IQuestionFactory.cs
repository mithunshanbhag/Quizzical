namespace Quizzical.Factories.Interfaces;

internal interface IQuestionFactory
{
    Task<Question[]> GenerateAsync(QuizConfig request, CancellationToken cancellationToken = default);
}