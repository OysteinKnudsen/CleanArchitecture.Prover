using CleanArchitecture.Prover.Application.Abstractions;
using CleanArchitecture.Prover.Domain.Entities;

namespace CleanArchitecture.Prover.Infrastructure.Services;

public class ApiSkoleService(ISkoleApiClient skoleApiClient) : ISkoleService 
{
    public Task<IEnumerable<Lærer>> GetLærereAsync()
    {
        var lærere = skoleApiClient.GetLærereAsync();
        throw new NotImplementedException();
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
}