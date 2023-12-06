using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Application.Prøvegrupper;

public interface IPrøvegruppeRepository
{
    Task<IEnumerable<Prøvegruppe>> GetAllAsync(CancellationToken cancellationToken);
    Task<Prøvegruppe> GetByIdAsync(PrøvegruppeId prøvegruppeId, CancellationToken cancellationToken);
    Task<Prøvegruppe> CreateAsync(PrøveId prøveId, LærerId lærerId, IEnumerable<ElevId> elever, CancellationToken cancellationToken);
    Task UpdateAsync(Prøvegruppe prøvegruppe, CancellationToken cancellationToken);
}