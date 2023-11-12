using CleanArchitecture.Prover.Application.Skole;
using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Infrastructure.Services.JsonSkoleService;

public class JsonSkoleService : ISkoleService
{
    public Task<IEnumerable<Lærer>> GetLærereAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Lærer?> GetLærerByIdAsync(LærerId id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Elev>> GetEleverAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Elev?> GetElevByIdAsync(ElevId id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Klasse>> GetKlasserAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Klasse?> GetKlasseByIdAsync(KlasseId id)
    {
        throw new NotImplementedException();
    }
}