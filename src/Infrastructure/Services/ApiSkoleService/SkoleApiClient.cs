using CleanArchitecture.Prover.Infrastructure.Services.Models;
namespace CleanArchitecture.Prover.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Linq;

public interface ISkoleApiClient
{
    public Task<IEnumerable<LærerResponse>> GetLærereAsync();
    public Task<IEnumerable<ElevResponse>> GetEleverAsync();
    public Task<IEnumerable<KlasseResponse>> GetKlasserAsync();
}
public class SkoleApiClient: ISkoleApiClient
{
    private readonly HttpClient _httpClient;
    private const string SkoleApiBaseAddress = "https://localhost:7165";
    private readonly JsonSerializerOptions _jsonSerializerOptions = new() {PropertyNameCaseInsensitive = true};

    public SkoleApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(SkoleApiBaseAddress);
    }

    public async Task<IEnumerable<LærerResponse>> GetLærereAsync()
    {
        var response = await _httpClient.GetAsync("/lærere");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        // TODO: burde man ha noe validering her for å sjekke at responsen er gyldig før man deserialiserer?
        var lærere = JsonSerializer.Deserialize<IEnumerable<LærerResponse>>(content, _jsonSerializerOptions);
        return lærere ?? Enumerable.Empty<LærerResponse>();
    }

    public async Task<IEnumerable<ElevResponse>> GetEleverAsync()
    {
        var response = await _httpClient.GetAsync("/elever");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        var elever = JsonSerializer.Deserialize<IEnumerable<ElevResponse>>(content, _jsonSerializerOptions);
        return elever ?? Enumerable.Empty<ElevResponse>();
    }

    public async Task<IEnumerable<KlasseResponse>> GetKlasserAsync()
    {
        var response = await _httpClient.GetAsync("/klasser");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        var klasser = JsonSerializer.Deserialize<IEnumerable<KlasseResponse>>(content, _jsonSerializerOptions);
        return klasser ?? Enumerable.Empty<KlasseResponse>();
    }
}
