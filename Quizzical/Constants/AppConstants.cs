namespace Quizzical.Constants;

internal class AppConstants
{
    public const string AppName = "Quizzical";

    public const string AppVersion = "1.0.0";

    public const string AppDescription = "@TODO";

    public const string ConsolePrompt = ">";

    public static IReadOnlyDictionary<string, string[]> PreSelectedTopics = new Dictionary<string, string[]>
    {
        {"Soccer", []},
        {"Cricket", []},
        {"Capitals", []},
        {"Animals", []},
        {"General Knowledge", []},
        {"Music", []},
        {"Movies", []},
        {"Geography", []}
    };
}