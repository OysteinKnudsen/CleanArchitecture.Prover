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

    public Task<IEnumerable<Elev>> GetEleverAsync()
    {
        var elever = skoleApiClient.GetEleverAsync();
        
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Klasse>> GetKlasserAsync()
    {
        throw new NotImplementedException();
    }

    private static Lærer ToDomainModel(LærerResponse apiResponse)
    {
        // TODO: Fragile implementation and will likely not work in all cases.
        var fornavn = apiResponse.Navn.Split(' ')[0];
        var etternavn = apiResponse.Navn.Split(' ')[1];

        return new Lærer((LærerId)apiResponse.LærerId, new LærerNavn(fornavn, etternavn), (KlasseId)apiResponse.KlasseId);
    }
}