using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Application.Prøvegrupper;

public interface IPrøvegruppeRepository
{
    Task<IEnumerable<Prøvegruppe>> GetAllAsync();
    Task<Prøvegruppe> GetByIdAsync(PrøvegruppeId prøvegruppeId);
    Task<Prøvegruppe> CreateAsync(Prøvegruppe prøvegruppe);
    Task UpdateAsync(Prøvegruppe prøvegruppe);
}