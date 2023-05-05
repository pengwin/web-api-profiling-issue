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

var serializer = new ModelDtoStreamSerializer(2000);

app.MapGet("/data", async ([FromServices] InnerApiClient client, HttpResponse response,  CancellationToken cancellationToken) =>
{
    var data = await client.GetDataAsync(options, cancellationToken);
    foreach (var dto in data)
    {
        dto.Amount /= 1000;
    }
    response.ContentType = "application/json";
    response.StatusCode = 200;
    await serializer.SerializeAsync(response.Body, data, cancellationToken);
});

app.MapGet("/data-proxy", async ([FromServices] InnerApiClient client, HttpResponse response,  CancellationToken cancellationToken) =>
{
    var result = await client.GetDataStreamAsync(cancellationToken);
    response.ContentType = "application/json";
    response.StatusCode = 200;

    await result.CopyToAsync(response.Body, cancellationToken);
});

app.Run();
