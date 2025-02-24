namespace Quizzical.Models;

/// <summary>
///     Represents a true/false question.
/// </summary>
internal class TrueFalseQuestion : Question
{
    /// <summary>
    ///     The correct answer to the true/false question.
    /// </summary>
    public required bool CorrectAnswer { get; set; }

    /// <inheritdoc />
    public override bool? Evaluate(QuestionResponse questionResponse)
    {
        if (questionResponse.Response.IsT3) return null;

        var selectedAnswer = questionResponse.Response.AsT2;

        return selectedAnswer == CorrectAnswer;
    }
}