using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Application.Prøver.Services;

internal class PrøveService(IPrøveRepository prøveRepository) : IPrøveService
{
    public Task<IEnumerable<Prøve>> GetAllAsync(CancellationToken cancellationToken)
    {
        return prøveRepository.GetAllAsync(cancellationToken);
    }

    public Task<Prøve> GetByIdAsync(PrøveId prøveId, CancellationToken cancellationToken)
    {
        return prøveRepository.GetByIdAsync(prøveId, cancellationToken);
    }
}