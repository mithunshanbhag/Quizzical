namespace Quizzical.Strategies.Implementations;

/// <summary>
///     Base strategy class for console-based, single-player quizzes.
/// </summary>
internal abstract class SinglePlayerConsolePlayStrategyBase : IQuizPlayStrategy
{
    /// <remarks>
    ///     This uses the template design pattern. It defines a skeleton (template) method that calls into
    ///     other virtual/abstract (hook) methods overridden by derived classes.
    /// </remarks>
    public async Task<QuizResponse> ExecuteAsync(Quiz quiz, CancellationToken cancellationToken = default)
    {
        for (var index = 0; index < quiz.Questions.Length; index++)
        {
            var currentQuestion = quiz.Questions[index];

            DisplayQuestion(currentQuestion, index, quiz.Questions.Length);

            var selectedAnswer = CaptureUserResponse(currentQuestion);

            var isCorrect = currentQuestion.Evaluate(selectedAnswer);

            ShowEvaluation(currentQuestion, isCorrect, index, quiz.Questions.Length);
        }

        // @TODO: Implement scoring
        return await Task.FromResult(new QuizResponse());
    }

    protected virtual void DisplayQuestion(Question question, int index, int totalQuestions)
    {
        AnsiConsole.Clear();
        AnsiConsole.Progress()
            .Columns(new TaskDescriptionColumn(), new ProgressBarColumn())
            .Start(ctx =>
            {
                var progressTask = ctx.AddTask($"Question {index + 1} of {totalQuestions}", new ProgressTaskSettings {MaxValue = totalQuestions});
                progressTask.Increment(index);
            });

        AnsiConsole.MarkupLineInterpolated($"[yellow]{question.Text}[/]");
        AnsiConsole.WriteLine();
    }

    protected abstract dynamic CaptureUserResponse(Question question);

    protected virtual void ShowEvaluation(Question question, bool isCorrect, int index, int totalQuestions)
    {
        if (question.ExplanationText is not null)
        {
            AnsiConsole.Markup(isCorrect ? "[green]Correct: [/]" : "[red]Incorrect: [/]");
            AnsiConsole.MarkupLine(question.ExplanationText);
        }

        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine("Press any key to continue.");
        Console.ReadKey(true);
    }
}