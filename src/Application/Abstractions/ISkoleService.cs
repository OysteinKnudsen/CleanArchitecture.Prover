using CleanArchitecture.Prover.Domain.Entities;

namespace CleanArchitecture.Prover.Application.Abstractions;

public interface ISkoleService
{
    public Task<IEnumerable<Lærer>> GetLærereAsync();
    public Task<IEnumerable<Elev>> GetEleverAsync();
    public Task<IEnumerable<Klasse>> GetKlasserAsync();
}