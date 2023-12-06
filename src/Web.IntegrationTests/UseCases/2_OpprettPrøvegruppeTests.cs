using System.Net;
using System.Text.Json;
using CleanArchitecture.Prover.Application;
using CleanArchitecture.Prover.Application.Prøver;
using CleanArchitecture.Prover.Web.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Web.IntegrationTests.Data;

namespace Web.IntegrationTests.UseCases;

public class OpprettPrøvegruppeTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly JsonSerializerOptions _jsonSerializerOptions = new()
        { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, PropertyNameCaseInsensitive = true };
    private readonly HttpClient _httpClient;

    public OpprettPrøvegruppeTests(WebApplicationFactory<Program> factory)
    {
        var dateTimeProvider = Mock.Of<IDateTimeProvider>(provider => provider.Now() == FakePrøveRepository.Today);
        _httpClient = factory.WithWebHostBuilder(builder => builder.ConfigureTestServices(services =>
            {
                services.AddTransient<IPrøveRepository>(_ => new FakePrøveRepository());
                services.AddTransient<IDateTimeProvider>(_ => dateTimeProvider);
            }))
            .CreateDefaultClient();
    }

    [Fact]
    public async Task Prøvegruppe_PrøveExists_ReturnsCreatedResult()
    {
        //arrange
        var creatPrøvegruppeModel = new CreatePrøvegruppeModel(FakePrøveRepository.ActiveExistingPrøveId);
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