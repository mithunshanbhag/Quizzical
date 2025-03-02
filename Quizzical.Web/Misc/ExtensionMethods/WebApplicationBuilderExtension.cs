namespace Quizzical.Web.Misc.ExtensionMethods;

public static class WebApplicationBuilderExtension
{
    public static WebApplicationBuilder ConfigureApp(this WebApplicationBuilder builder)
    {
        return builder;
    }

    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        // Add MudBlazor services
        builder.Services.AddMudServices();

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        //// auto-mapper
        //builder.Services.AddAutoMapper(typeof(MapperProfile));

        // mediatr
        builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); });

        // openai client
        var quizzicalOpenAiApiKey = builder.Configuration[ConfigKeys.OpenAiApiKey];
        var quizzicalOpenAiModel = builder.Configuration[ConfigKeys.OpenAiModel];
        var openAiChatClient = new ChatClient(quizzicalOpenAiModel, quizzicalOpenAiApiKey);
        builder.Services.AddSingleton(openAiChatClient);

        // strategies

        // services

        // repositories

        // misc

        return builder;
    }
}