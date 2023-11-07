using CleanArchitecture.Prover.Application.Abstractions;
using CleanArchitecture.Prover.Domain.Entities;

namespace CleanArchitecture.Prover.Infrastructure.Services.JsonSkoleService;

public class JsonSkoleService : ISkoleService
{
    public Task<IEnumerable<Lærer>> GetLærereAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Elev>> GetEleverAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Klasse>> GetKlasserAsync()
    {
        throw new NotImplementedException();
    }
}