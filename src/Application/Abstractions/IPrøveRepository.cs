using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Application.Abstractions;

public interface IPrøveRepository
{
    public Task<IEnumerable<Prøve>> GetAllAsync(CancellationToken cancellationToken);
    public Task<Prøve> GetPrøveAsync(PrøveId prøveId, CancellationToken cancellationToken);
}