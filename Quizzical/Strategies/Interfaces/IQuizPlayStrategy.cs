namespace Quizzical.Strategies.Interfaces;

internal interface IQuizPlayStrategy
{
    Task<QuizEvaluation> ExecuteAsync(Quiz quiz, CancellationToken cancellationToken = default);
}