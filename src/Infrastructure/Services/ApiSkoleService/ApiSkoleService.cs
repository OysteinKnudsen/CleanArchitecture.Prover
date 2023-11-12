using CleanArchitecture.Prover.Application.Skole;
using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;
using CleanArchitecture.Prover.Infrastructure.Services.Models;

namespace CleanArchitecture.Prover.Infrastructure.Services;

public class ApiSkoleService(ISkoleApiClient skoleApiClient) : ISkoleService 
{
    public async Task<IEnumerable<Lærer>> GetLærereAsync()
    {
        var lærere = await skoleApiClient.GetLærereAsync();
        return lærere.Select(ToDomainModel);
    }

    public async Task<Lærer?> GetLærerByIdAsync(LærerId id)
    {
        var lærere = await skoleApiClient.GetLærereAsync();
        var lærer = lærere.FirstOrDefault(lærer => lærer.LærerId == id);
        
        if(lærer is null) return null;
        
        return ToDomainModel(lærer);
    }

    public async Task<IEnumerable<Elev>> GetEleverAsync()
    {
        var elever = await skoleApiClient.GetEleverAsync();
        return elever.Select(ToDomainModel);
    }

    public async Task<Elev?> GetElevByIdAsync(ElevId id)
    {
        var elever = await skoleApiClient.GetEleverAsync();
        var elev = elever.FirstOrDefault(elev => elev.ElevId == id);
        if (elev is null) return null;
        return ToDomainModel(elev);
    }

    public async Task<IEnumerable<Klasse>> GetKlasserAsync()
    {
        var klasser = await skoleApiClient.GetKlasserAsync();
        return klasser.Select(ToDomainModel);
    }

    public async Task<Klasse?> GetKlasseByIdAsync(KlasseId id)
    {
        var klasser = await skoleApiClient.GetKlasserAsync();
        var klasse = klasser.FirstOrDefault(klasse => klasse.KlasseId == id);
        if (klasse is null) return null;
        return ToDomainModel(klasse);
    }

    private static Lærer ToDomainModel(LærerResponse apiResponse)
    {
        var (fornavn, etternavn) = SplitNavn(apiResponse.Navn);
        return new Lærer((LærerId)apiResponse.LærerId, new LærerNavn(fornavn, etternavn), (KlasseId)apiResponse.KlasseId);
    }

    private static Elev ToDomainModel(ElevResponse apiResponse)
    {
        var (fornavn, etternavn) = SplitNavn(apiResponse.Navn);
        // TODO: er det riktig å konstruere en Elev med tom liste av Prøvegjennomføringer?
        return new Elev((ElevId)apiResponse.ElevId, new ElevNavn(fornavn, etternavn), (KlasseId)apiResponse.KlasseId, Enumerable.Empty<Prøvegjennomføring>());
    }

    private static Klasse ToDomainModel(KlasseResponse apiResponse)
    {
        return new Klasse((KlasseId) apiResponse.KlasseId, (LærerId) apiResponse.LærerId, (Trinn) apiResponse.Trinn,
            apiResponse.Elever.Select(elevId => (ElevId) elevId));
    }
    
    private static (string, string) SplitNavn(string navn)
    {
        // TODO: Fragile implementation and will likely not work in all cases.
        var fornavn = navn.Split(' ')[0];
        var etternavn = navn.Split(' ')[1];
        return (fornavn, etternavn);
    }
}