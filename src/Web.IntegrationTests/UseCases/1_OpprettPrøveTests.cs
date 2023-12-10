using System.Net;
using System.Text.Json;
using CleanArchitecture.Prover.Application;
using CleanArchitecture.Prover.Web.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Web.IntegrationTests.UseCases;

public class OpprettPrøveTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly JsonSerializerOptions _jsonSerializerOptions = new()
        { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, PropertyNameCaseInsensitive = true };

    private readonly HttpClient _httpClient;
    private readonly DateTimeOffset _today = new(new DateTime(2023, 12, 05));

    public OpprettPrøveTests(WebApplicationFactory<Program> factory)
    {
        var dateTimeProvider = Mock.Of<IDateTimeProvider>(provider => provider.Now() == _today);
        _httpClient = factory.WithWebHostBuilder(builder => builder.ConfigureTestServices(services =>
            {
                services.AddTransient<IDateTimeProvider>(_ => dateTimeProvider);
            }))
            .CreateDefaultClient();
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    [InlineData(8)]
    [InlineData(9)]
    [InlineData(10)]
    public async Task Prøver_PrøveHasNavnAndValidTrinnAndValidPeriod_CreatedPrøveReturned(int trinn)
    {
        //arrange
        var createPrøveModel = new CreatePrøveModel(
            $"Vårprøve i norsk for {trinn}.trinn", 
            trinn, 
            _today.AddDays(1),
            _today.AddDays(10),
            "Norsk");
        var createPrøveModelJson = JsonSerializer.Serialize(createPrøveModel, _jsonSerializerOptions);
        var createPrøveModelContent =
            new StringContent(createPrøveModelJson, System.Text.Encoding.UTF8, "application/json-patch+json");
        
        //act
        var response = await _httpClient.PostAsync(new Uri("/api/prøver", UriKind.Relative), createPrøveModelContent);
        
        //assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        var createdPrøveUri = response.Headers.Location;
        var createdPrøveResponse = await _httpClient.GetAsync(createdPrøveUri);

        //assert created prøve is returned
        createdPrøveResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        var content = await createdPrøveResponse.Content.ReadAsStringAsync();
        var createdPrøve = JsonSerializer.Deserialize<PrøveViewModel>(content, _jsonSerializerOptions);

        createdPrøve!.Fag.Should().Be(createPrøveModel.Fag);
        createdPrøve.Navn.Should().Be(createPrøveModel.Navn);
        createdPrøve.Start.Should().Be(createPrøveModel.Fra);
        createdPrøve.Slutt.Should().Be(createPrøveModel.Til);
    }
    
    [Fact]
    public async Task Prøver_PrøveMissingNavn_BadRequestReturned()
    {
        //arrange
        var createPrøveModel = new CreatePrøveModel(
            string.Empty, 
            8,
            _today.AddDays(1),
            _today.AddDays(10),
            "Norsk");
        var createPrøveModelJson = JsonSerializer.Serialize(createPrøveModel, _jsonSerializerOptions);
        var createPrøveModelContent =
            new StringContent(createPrøveModelJson, System.Text.Encoding.UTF8, "application/json-patch+json");
        
        //act
        var response = await _httpClient.PostAsync(new Uri("/api/prøver", UriKind.Relative), createPrøveModelContent);
        
        //assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(11)]
    public async Task Prøver_PrøveHasNavnButInvalidTrinn_BadRequestReturned(int trinn)
    {
        //arrange
        var createPrøveModel = new CreatePrøveModel(
            $"Vårprøve i norsk for {trinn}.trinn", 
            trinn,
            _today.AddDays(1),
            _today.AddDays(10),
            "Norsk");
        var createPrøveModelJson = JsonSerializer.Serialize(createPrøveModel, _jsonSerializerOptions);
        var createPrøveModelContent =
            new StringContent(createPrøveModelJson, System.Text.Encoding.UTF8, "application/json-patch+json");
        
        //act
        var response = await _httpClient.PostAsync(new Uri("/api/prøver", UriKind.Relative), createPrøveModelContent);
        
        //assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
    
    [Fact]
    public async Task Prøver_PrøveHasFraNotInTheFuture_BadRequestReturned()
    {
        //arrange
        var createPrøveModel = new CreatePrøveModel(
            $"Vårprøve i norsk for 8.trinn", 
            8,
            _today,
            _today.AddDays(10),
            "Norsk");
        var createPrøveModelJson = JsonSerializer.Serialize(createPrøveModel, _jsonSerializerOptions);
        var createPrøveModelContent =
            new StringContent(createPrøveModelJson, System.Text.Encoding.UTF8, "application/json-patch+json");
        
        //act
        var response = await _httpClient.PostAsync(new Uri("/api/prøver", UriKind.Relative), createPrøveModelContent);
        
        //assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
    
    [Fact]
    public async Task Prøver_PrøveHasTilBeforeFra_BadRequestReturned()
    {
        //arrange
        var createPrøveModel = new CreatePrøveModel(
            $"Vårprøve i norsk for 8.trinn", 
            8,
            _today.AddDays(1),
            _today,
            "Norsk");
        var createPrøveModelJson = JsonSerializer.Serialize(createPrøveModel, _jsonSerializerOptions);
        var createPrøveModelContent =
            new StringContent(createPrøveModelJson, System.Text.Encoding.UTF8, "application/json-patch+json");
        
        //act
        var response = await _httpClient.PostAsync(new Uri("/api/prøver", UriKind.Relative), createPrøveModelContent);
        
        //assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}