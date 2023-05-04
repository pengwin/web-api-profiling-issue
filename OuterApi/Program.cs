using Microsoft.AspNetCore.Mvc;
using OuterApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddScoped<InnerApiClient>();

var app = builder.Build();

app.MapGet("/data", async ([FromServices]InnerApiClient client, CancellationToken cancellationToken) =>
{
    var result = await client.GetDataAsync(cancellationToken);
    return result;
});

app.Run();