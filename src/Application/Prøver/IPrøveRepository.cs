using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Application.Prøver;

public interface IPrøveRepository
{
    public Task<IEnumerable<Prøve>> GetAllAsync(CancellationToken cancellationToken);
    public Task<Prøve> GetByIdAsync(PrøveId prøveId, CancellationToken cancellationToken);
}