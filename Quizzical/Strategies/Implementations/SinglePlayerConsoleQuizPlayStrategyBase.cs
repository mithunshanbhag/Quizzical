namespace Quizzical.Strategies.Implementations;

/// <summary>
///     Base strategy class for console-based, single-player quizzes.
/// </summary>
internal abstract class SinglePlayerConsoleQuizPlayStrategyBase : IQuizPlayStrategy
{
    /// <remarks>
    ///     This uses the template design pattern. It defines a skeleton (template) method that calls into
    ///     other virtual/abstract (hook) methods overridden by derived classes.
    /// </remarks>
    public async Task<QuizEvaluation> ExecuteAsync(Quiz quiz, CancellationToken cancellationToken = default)
    {
        var quizResponse = new QuizEvaluation();

        var toContinue = true;

        for (var index = 0; index < quiz.Questions.Length && toContinue; index++)
        {
            var currentQuestion = quiz.Questions[index];

            DisplayQuestion(currentQuestion, index, quiz.Questions.Length);

            var selectedAnswer = CaptureUserResponse(currentQuestion);

            var evaluation = currentQuestion.Evaluate(selectedAnswer);

            quizResponse.QuestionResponses.Add(currentQuestion, evaluation);

            toContinue = ShowEvaluation(currentQuestion, evaluation, index, quiz.Questions.Length);
        }

        return await Task.FromResult(quizResponse);
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

    protected abstract dynamic? CaptureUserResponse(Question question);

    protected virtual bool ShowEvaluation(Question question, bool? evaluation, int index, int totalQuestions)
    {
        if (question.ExplanationText is not null)
        {
            AnsiConsole.Markup(evaluation.HasValue
                ? evaluation.Value
                    ? "[green]Correct: [/]"
                    : "[red]Incorrect: [/]"
                : "[yellow]Skipped: [/]");
            AnsiConsole.MarkupLine(question.ExplanationText);
        }

        AnsiConsole.WriteLine();
        var toContinue = AnsiConsole.Prompt(
            new ConfirmationPrompt("Continue?")
                .HideDefaultValue());

        return toContinue;
    }
}