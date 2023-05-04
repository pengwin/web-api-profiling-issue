using System.Net;
using System.Text.Json;
using Models;

namespace OuterApi;

public class InnerApiClient
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _options;
    
    public InnerApiClient(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient();
        _client.BaseAddress = new Uri("http://localhost:5001");
        _options = new JsonSerializerOptions();
    }

    public async Task<ModelDto[]> GetDataAsync(CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync("/data", cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException("Bad request", null, HttpStatusCode.BadRequest);
        }

        var result = await response.Content.ReadFromJsonAsync<ModelDto[]>(_options, cancellationToken);
        return result!;
    }
}