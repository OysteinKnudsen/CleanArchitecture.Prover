using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Application.Prøvegrupper;

public interface IPrøvegruppeRepository
{
    public Task<IEnumerable<Prøvegruppe>> GetAllAsync(CancellationToken cancellationToken);
    public Task<Prøvegruppe> GetByIdAsync(PrøvegruppeId prøvegruppeId, CancellationToken cancellationToken);
    public Task CreateAsync(Prøvegruppe prøvegruppe, CancellationToken cancellationToken);
    public Task UpdateAsync(Prøvegruppe prøvegruppe, CancellationToken cancellationToken);
    public Task DeleteAsync(PrøvegruppeId prøvegruppeId, CancellationToken cancellationToken);
}