var host = Host
    .CreateApplicationBuilder(args)
    .ConfigureApp()
    .ConfigureServices()
    .Build();

var engine = host.Services.GetRequiredService<QuizEngine>();
await engine.RunAsync(CancellationToken.None);