using System.Net;
using System.Text.Json;
using CleanArchitecture.Prover.Web.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

namespace Web.IntegrationTests.Endpoints;

public class SkoleEndpointTests(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    [Fact]
    public async Task Lærere_2LærereReturned()
    {
        var httpClient = factory.WithWebHostBuilder(builder => builder.ConfigureTestServices(services =>
            {
            }))

            .CreateDefaultClient();
        
        //act
        var response = await httpClient.GetAsync(new Uri("/api/skole/lærere", UriKind.Relative));
        
        //assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        
        var content = await response.Content.ReadAsStringAsync();
        var lærere = JsonSerializer.Deserialize<IEnumerable<LærerViewModel>>(content,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        lærere.Should().HaveCountGreaterThan(0);
    }
    
    [Fact]
    public async Task Lærere_IdIs101_LærerWithId01Returned()
    {
        var httpClient = factory.WithWebHostBuilder(builder => builder.ConfigureTestServices(services =>
            {
            }))

            .CreateDefaultClient();
        
        //act
        var response = await httpClient.GetAsync(new Uri("/api/skole/lærere/101", UriKind.Relative));
        
        //assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        
        var content = await response.Content.ReadAsStringAsync();
        var lærer = JsonSerializer.Deserialize<LærerViewModel>(content,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        lærer!.LærerId.Should().Be(101);
        lærer.Navn.Should().Be("Olav Folkestad");
        lærer.KlasseId.Should().Be(1);
    }
    
    [Fact]
    public async Task Elever_4EleverReturned()
    {
        var httpClient = factory.WithWebHostBuilder(builder => builder.ConfigureTestServices(services =>
            {
            }))

            .CreateDefaultClient();
        
        //act
        var response = await httpClient.GetAsync(new Uri("/api/skole/elever", UriKind.Relative));
        
        //assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        
        var content = await response.Content.ReadAsStringAsync();
        var elever = JsonSerializer.Deserialize<IEnumerable<ElevViewModel>>(content,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        elever.Should().HaveCountGreaterThan(0);
    }
    
    [Fact]
    public async Task Elever_ElevIdIs2_ElevWithId2Returned()
    {
        var httpClient = factory.WithWebHostBuilder(builder => builder.ConfigureTestServices(services =>
            {
            }))

            .CreateDefaultClient();
        
        //act
        var response = await httpClient.GetAsync(new Uri("/api/skole/elever/2", UriKind.Relative));
        
        //assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        
        var content = await response.Content.ReadAsStringAsync();
        var elev = JsonSerializer.Deserialize<ElevViewModel>(content,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        elev!.ElevId.Should().Be(2);
        elev.Navn.Should().Be("Kari Normann");
        elev.KlasseId.Should().Be(1);
    }
    
    [Fact]
    public async Task Klasser_2KlasserReturned()
    {
        var httpClient = factory.WithWebHostBuilder(builder => builder.ConfigureTestServices(services =>
            {
            }))

            .CreateDefaultClient();
        
        //act
        var response = await httpClient.GetAsync(new Uri("/api/skole/klasser", UriKind.Relative));
        
        //assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        
        var content = await response.Content.ReadAsStringAsync();
        var klasser = JsonSerializer.Deserialize<IEnumerable<KlasseViewModel>>(content,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        klasser.Should().HaveCountGreaterThan(0);
    }
    
    [Fact]
    public async Task Klasser_KLasseIdIs2_KlasserWithId2Returned()
    {
        var httpClient = factory.WithWebHostBuilder(builder => builder.ConfigureTestServices(services =>
            {
            }))

            .CreateDefaultClient();
        
        //act
        var response = await httpClient.GetAsync(new Uri("/api/skole/klasser/2", UriKind.Relative));
        
        //assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        
        var content = await response.Content.ReadAsStringAsync();
        var klasse = JsonSerializer.Deserialize<KlasseViewModel>(content,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        klasse!.KlasseId.Should().Be(2);
        klasse.Trinn.Should().Be(5);
        klasse.LærerId.Should().Be(102);
    }
}
