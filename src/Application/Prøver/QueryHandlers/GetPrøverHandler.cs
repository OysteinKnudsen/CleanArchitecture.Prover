using CleanArchitecture.Prover.Application.Abstractions;
using CleanArchitecture.Prover.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Prover.Application.Prøver.QueryHandlers;

internal class GetPrøverHandler(IPrøveRepository prøveRepository) : IRequestHandler<Queries.GetPrøver,IEnumerable<Prøve>>
{
    public Task<IEnumerable<Prøve>> Handle(Queries.GetPrøver query, CancellationToken cancellationToken)
    {
        return prøveRepository.GetAllAsync(cancellationToken);
    }
}