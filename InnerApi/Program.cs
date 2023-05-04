using System.Text.Json;
using Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const int count = 90000;
ModelDto[] data = Enumerable
    .Range(0, count)
    .Select(_ => new ModelDto
    {
        Name = "ABC",
        Amount = 1000
    })
    .ToArray();

JsonSerializerOptions options = new();

app.MapGet("/data", () => Task.FromResult(Results.Json(data, options, "application/json", 200)));

app.Run();