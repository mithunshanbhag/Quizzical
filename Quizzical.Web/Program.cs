var app = WebApplication
    .CreateBuilder(args)
    .ConfigureApp()
    .ConfigureServices()
    .Build();

app.Configure()
    .Run();