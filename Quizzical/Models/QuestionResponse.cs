using OneOf;
using OneOf.Types;

namespace Quizzical.Models;

internal class QuestionResponse
{
    public QuestionType QuestionType { get; set; }

    public OneOf<int[], int, bool, None> Response { get; set; }
}