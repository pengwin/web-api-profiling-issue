using System.Net;
using System.Text.Json;
using Models;

namespace OuterApi;

public class InnerApiClient
{
    private readonly HttpClient _client;

    public InnerApiClient(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient();
        _client.BaseAddress = new Uri("http://localhost:5001");
    }

    public async Task<ModelDto[]> GetDataAsync(JsonSerializerOptions options, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync("/data", cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException("Bad request", null, HttpStatusCode.BadRequest);
        }

        var result = await response.Content.ReadFromJsonAsync<ModelDto[]>(options, cancellationToken);
        return result!;
    }
    
    public async Task<Stream> GetDataStreamAsync(CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync("/data", cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException("Bad request", null, HttpStatusCode.BadRequest);
        }

        var result = await response.Content.ReadAsStreamAsync(cancellationToken);
        return result;
    }
}