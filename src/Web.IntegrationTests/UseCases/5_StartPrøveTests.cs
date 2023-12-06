using System.Net;
using System.Text.Json;
using CleanArchitecture.Prover.Application;
using CleanArchitecture.Prover.Application.Prøvegrupper;
using CleanArchitecture.Prover.Application.Prøver;
using CleanArchitecture.Prover.Domain.ValueTypes;
using CleanArchitecture.Prover.Web.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Web.IntegrationTests.Data;

namespace Web.IntegrationTests.UseCases;

public class StartPrøveTests  : IClassFixture<WebApplicationFactory<Program>> 
{
    private readonly JsonSerializerOptions _jsonSerializerOptions = new()
        { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, PropertyNameCaseInsensitive = true };
    private readonly HttpClient _httpClient;

    public StartPrøveTests(WebApplicationFactory<Program> factory)
    {
        //arrange
        var dateTimeProvider = Mock.Of<IDateTimeProvider>(provider => provider.Now() == FakePrøveRepository.Today);
        _httpClient = factory.WithWebHostBuilder(builder => builder.ConfigureTestServices(services =>
            {
                services.AddTransient<IPrøveRepository>(_ => new FakePrøveRepository());
                services.AddTransient<IPrøvegruppeRepository>(_ => new FakePrøvegruppeRepository());
                services.AddTransient<IDateTimeProvider>(_ => dateTimeProvider);
            }))
            .CreateDefaultClient();
    }
    
    [Fact]
    public async Task Elev_ElevErPåmeldt_ReturnsNoContent()
    {
        //arrange
        var updateElevModel = new UpdateElevModel((int)Gjennomføringsstatus.Startet); 
        var updateElevModelJson = JsonSerializer.Serialize(updateElevModel, _jsonSerializerOptions);
        var updateElevModelContent =
            new StringContent(updateElevModelJson, System.Text.Encoding.UTF8, "application/json-patch+json");
        
        //act
        var response =
            await _httpClient.PatchAsync(
                new Uri(
                    $"/api/prøver/{FakePrøveRepository.ActiveExistingPrøveId}/elever/{FakePrøvegruppeRepository.PåmeldtElevId}",
                    UriKind.Relative), updateElevModelContent);
        
        //assert
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
    
    [Fact]
    public async Task Elev_ElevIkkePåmeldt_ReturnsBadRequest()
    {
        //arrange
        var updateElevModel = new UpdateElevModel((int)Gjennomføringsstatus.Startet); 
        var updateElevModelJson = JsonSerializer.Serialize(updateElevModel, _jsonSerializerOptions);
        var updateElevModelContent =
            new StringContent(updateElevModelJson, System.Text.Encoding.UTF8, "application/json-patch+json");
        
        //act
        var response =
            await _httpClient.PatchAsync(
                new Uri(
                    $"/api/prøver/{FakePrøveRepository.ActiveExistingPrøveId}/elever/{FakePrøvegruppeRepository.IkkePåmeldtElevId}",
                    UriKind.Relative), updateElevModelContent);
        
        //assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}