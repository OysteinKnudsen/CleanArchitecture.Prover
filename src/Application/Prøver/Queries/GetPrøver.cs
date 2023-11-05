using CleanArchitecture.Prover.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Prover.Application.Prøver.Queries;

public class GetPrøver : IRequest<IEnumerable<Prøve>>;