using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Application.Prøver;

public interface IPrøveService
{
    Task<IEnumerable<Prøve>> GetAllAsync(CancellationToken cancellationToken);
    Task<Prøve> GetByIdAsync(PrøveId prøveId, CancellationToken cancellationToken);
}