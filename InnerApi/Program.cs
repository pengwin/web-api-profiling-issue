using System.Text.Json;
using Models;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
var app = builder.Build();

JsonSerializerOptions options = new();

app.MapGet("/data", async (HttpResponse response, CancellationToken cancellationToken) =>
{
    var data = ModelDto.CreateData();
    response.ContentType = "application/json";
    response.StatusCode = 200;
    await JsonSerializer.SerializeAsync(response.Body, data, options, cancellationToken);
});

app.Run();