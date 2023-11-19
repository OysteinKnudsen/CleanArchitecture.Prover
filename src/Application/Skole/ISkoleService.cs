using System.Collections;
using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Application.Skole;

public interface ISkoleService
{
    public Task<IEnumerable<Lærer>> GetLærereAsync();
    public Task<Lærer?> GetLærerByIdAsync(LærerId id);
    public Task<IEnumerable<Elev>> GetEleverAsync();
    public Task<Elev?> GetElevByIdAsync(ElevId id);
    public Task<IEnumerable<Klasse>> GetKlasserAsync();
    public Task<Klasse?> GetKlasseByIdAsync(KlasseId id);
}