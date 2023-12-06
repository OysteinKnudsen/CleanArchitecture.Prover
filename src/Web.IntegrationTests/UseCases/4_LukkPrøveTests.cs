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

public class LukkPrøveTests : IClassFixture<WebApplicationFactory<Program>> 
{
    private readonly JsonSerializerOptions _jsonSerializerOptions = new()
        { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, PropertyNameCaseInsensitive = true };
    
    private readonly HttpClient _httpClient;
    
    public LukkPrøveTests(WebApplicationFactory<Program> factory)
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
    public async Task Prøvegruppe_PrøveIsAktivAndÅpen_ReturnsOkAndPrøveIsStengt()
    {
        //arrange
        const int expectedStatus = (int)PrøvegruppeStatus.StengtForGjennomføring;
        var updatePrøvegruppeModel = new UpdatePrøvegruppeModel(expectedStatus); 
        var updatePrøvegruppeModelJson = JsonSerializer.Serialize(updatePrøvegruppeModel, _jsonSerializerOptions);
        var updatePrøvegruppeModelContent =
            new StringContent(updatePrøvegruppeModelJson, System.Text.Encoding.UTF8, "application/json-patch+json");
        
        //act
        var response =
            await _httpClient.PatchAsync(new Uri($"/api/prøvegrupper/{FakePrøvegruppeRepository.ÅpnetPrøveGruppeMedActivePrøveId}", UriKind.Relative), updatePrøvegruppeModelContent);
        
        //assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var content = await response.Content.ReadAsStringAsync();
        var viewModel = JsonSerializer.Deserialize<PrøvegruppeViewModel>(content, _jsonSerializerOptions);
        viewModel!.PrøvegruppeStatus.Should().Be(expectedStatus);
    }
}