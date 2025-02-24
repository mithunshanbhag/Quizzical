namespace Quizzical.Models;

/// <summary>
///     Represents a multiple choice question.
/// </summary>
internal class MultipleChoiceQuestion : Question
{
    /// <summary>
    ///     The answer choices for the question.
    /// </summary>
    public required string[] AnswerChoices { get; set; }

    /// <summary>
    ///     The index of the correct answer in the AnswerChoices array.
    /// </summary>
    public required int CorrectAnswerIndex { get; set; }

    /// <inheritdoc />
    public override bool? Evaluate(QuestionResponse questionResponse)
    {
        if (questionResponse.Response.IsT3) return null;

        var selectedAnswerIndex = questionResponse.Response.AsT1;

        return selectedAnswerIndex == CorrectAnswerIndex;
    }
}