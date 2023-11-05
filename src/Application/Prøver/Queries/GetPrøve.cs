using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;
using MediatR;

namespace CleanArchitecture.Prover.Application.Prøver.Queries;

public class GetPrøve : IRequest<Prøve>
{
    public PrøveId PrøveId { get; set; }
    
    public GetPrøve(PrøveId prøveId)
    {
        PrøveId = prøveId;
    }
}