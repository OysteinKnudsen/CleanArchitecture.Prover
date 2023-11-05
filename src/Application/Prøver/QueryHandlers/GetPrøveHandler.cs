using CleanArchitecture.Prover.Application.Abstractions;
using CleanArchitecture.Prover.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Prover.Application.Prøver.QueryHandlers;

internal class GetPrøveHandler(IPrøveRepository prøveRepository) : IRequestHandler<Queries.GetPrøve, Prøve>
{
    public Task<Prøve> Handle(Queries.GetPrøve query, CancellationToken cancellationToken)
    {
        return prøveRepository.GetPrøveAsync(query.PrøveId, cancellationToken);
    }
}