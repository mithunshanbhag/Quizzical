namespace Quizzical.Misc.ExtensionMethods;

internal static class HostApplicationBuilderExtension
{
    public static HostApplicationBuilder ConfigureApp(this HostApplicationBuilder builder)
    {
        builder.Configuration.AddUserSecrets(Assembly.GetExecutingAssembly());

        return builder;
    }

    public static HostApplicationBuilder ConfigureServices(this HostApplicationBuilder builder)
    {
        //// auto-mapper
        //builder.Services.AddAutoMapper(typeof(MapperProfile));

        // mediatr
        builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); });

        // openai client
        var quizzicalOpenAiApiKey = builder.Configuration["OpenAi:ApiKey"];
        var quizzicalOpenAiModel = builder.Configuration["OpenAi:Model"];
        var openAiChatClient = new ChatClient(quizzicalOpenAiModel, quizzicalOpenAiApiKey);
        builder.Services.AddSingleton(openAiChatClient);

        // strategies
        builder.Services
            .AddTransient<IQuizPlayStrategy, TrueFalseQuizPlayStrategy>()
            .AddTransient<IQuizPlayStrategy, MultipleChoiceQuizPlayStrategy>();

        // services
        builder.Services
            .AddTransient<IQuizFactory, QuizFactory>()
            .AddTransient<IQuestionFactory, QuestionFactory>();

        // repositories

        // misc
        builder.Services
            .AddTransient<QuizEngine>();

        return builder;
    }
}