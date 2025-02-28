namespace Quizzical.Core.Strategies.Interfaces;

public interface IQuizPlayStrategy
{
    Task<QuizEvaluation> ExecuteAsync(Quiz quiz, CancellationToken cancellationToken = default);
}