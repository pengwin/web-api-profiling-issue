using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Models;
using OuterApi;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<InnerApiClient>();

var app = builder.Build();

JsonSerializerOptions options = new();

app.MapGet("/data", async ([FromServices] InnerApiClient client, HttpResponse response,  CancellationToken cancellationToken) =>
{
    var data = await client.GetDataAsync(options, cancellationToken);
    response.ContentType = "application/json";
    response.StatusCode = 200;
    await JsonSerializer.SerializeAsync(response.Body, data, options, cancellationToken);
});

app.MapGet("/data-self", async (HttpResponse response, CancellationToken cancellationToken) =>
{
    var data = ModelDto.CreateData();
    response.ContentType = "application/json";
    response.StatusCode = 200;
    await JsonSerializer.SerializeAsync(response.Body, data, options, cancellationToken);
});

app.Run();
