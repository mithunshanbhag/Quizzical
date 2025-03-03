namespace Quizzical.Core.Constants;

public class QuizConstants
{
    public const int DefaultNumberOfQuestions = 10;

    public const int DefaultNumberOfAnswerChoices = 4;

    public const string SkipOptionText = "{SKIP}";

    public const int DefaultQuestionTimeLimitInSecs = 0;

    public const bool DefaultShowAnswerHints = false;

    public static IReadOnlyDictionary<string, string[]> PreSelectedTopics = new Dictionary<string, string[]>
    {
        { "Advertising", [] },
        { "Animals", [] },
        { "Anime", [] },
        { "Art", [] },
        { "Board Games", [] },
        { "Books & Literature", [] },
        { "Capitals", [] },
        { "Cartoons", [] },
        { "Celebrities", [] },
        { "Comics", [] },
        { "Cricket", [] },
        { "CSS", [] },
        { "DIY", [] },
        { "Entrepreneurship", [] },
        { "Fashion", [] },
        { "Finance", [] },
        { "Fitness", [] },
        { "Food", [] },
        { "Gardening", [] },
        { "General Knowledge", [] },
        { "Geography", [] },
        { "Health & Fitness", [] },
        { "History", [] },
        { "Hobbies", [] },
        { "Investing", [] },
        { "Math", [] },
        { "Movies", [] },
        { "Music", [] },
        { "Mythology", [] },
        { "Nature", [] },
        { "Parenting", [] },
        { "Pets", [] },
        { "Photography", [] },
        { "Politics", [] },
        { "Relationships", [] },
        { "Science", [] },
        { "SEO", [] },
        { "Soccer", [] },
        { "Space", [] },
        { "Sports", [] },
        { "Technology", [] },
        { "Television", [] },
        { "Travel", [] },
        { "Vehicles", [] },
        { "Video Games", [] }
    };
}