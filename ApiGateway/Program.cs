using Yarp.ReverseProxy;

var builder = WebApplication.CreateBuilder(args);

// Load YARP configuration from appsettings
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

app.MapReverseProxy();

app.Run();
