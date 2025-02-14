namespace Quizzical.Strategies.Interfaces;

internal interface IQuizPlayStrategy
{
    Task<QuizResponse> ExecuteAsync(Quiz quiz, CancellationToken cancellationToken = default);
}