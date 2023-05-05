using Models;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
var app = builder.Build();

int totalCount = 90000;
var serializer = new ModelDtoStreamSerializer(2000);

app.MapGet("/data", async (HttpResponse response, CancellationToken cancellationToken) =>
{
    var data = ModelDto.CreateData(totalCount);
    response.ContentType = "application/json";
    response.StatusCode = 200;
    await serializer.SerializeAsync(response.Body, data, cancellationToken);
});

app.Run();