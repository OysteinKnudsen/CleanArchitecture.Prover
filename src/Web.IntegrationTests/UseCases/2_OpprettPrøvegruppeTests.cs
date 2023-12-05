using System.Net;
using System.Text.Json;
using CleanArchitecture.Prover.Application.Prøver;
using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;
using CleanArchitecture.Prover.Web.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Web.IntegrationTests.UseCases;

public class OpprettPrøvegruppeTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly JsonSerializerOptions _jsonSerializerOptions = new()
        { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, PropertyNameCaseInsensitive = true };
    private readonly HttpClient _httpClient;
    
    private readonly DateTimeOffset _today = new(new DateTime(2023, 12, 05));
    private const int ExistingPrøveId = 42;

    public OpprettPrøvegruppeTests(WebApplicationFactory<Program> factory)
    {
        var existingPrøve = new Prøve(
            new PrøveId(ExistingPrøveId), 
            new PrøveNavn("En eksisterende prøve"),
            new PrøvePeriode(_today.AddDays(1), _today.AddDays(10)), 
            new Trinn(5), 
            Fag.Matematikk);

        var prøveRepository = Mock.Of<IPrøveRepository>(repository =>
            repository.GetByIdAsync(new PrøveId(ExistingPrøveId)) == new Task<Prøve>(() => existingPrøve));
        _httpClient = factory.WithWebHostBuilder(builder => builder.ConfigureTestServices(services =>
            {
                services.AddTransient<IPrøveRepository>(_ => prøveRepository);
            }))
            .CreateDefaultClient();
    }

    [Fact]
    public async Task Prøvegruppe_PrøveExists_ReturnsCreatedResult()
    {
        //arrange
        var creatPrøvegruppeModel = new CreatePrøvegruppeModel(ExistingPrøveId);
        var createPrøvegruppeModelJson = JsonSerializer.Serialize(creatPrøvegruppeModel, _jsonSerializerOptions);
        var createPrøvegruppeModelContent =
            new StringContent(createPrøvegruppeModelJson, System.Text.Encoding.UTF8, "application/json-patch+json");
        
        //act
        var response =
            await _httpClient.PostAsync(new Uri("/api/prøvegrupper", UriKind.Relative), createPrøvegruppeModelContent);
        
        //assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}