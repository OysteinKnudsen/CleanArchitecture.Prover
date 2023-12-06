using CleanArchitecture.Prover.Application.Prøvegrupper;
using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;

namespace Web.IntegrationTests.Data;

internal class FakePrøvegruppeRepository : IPrøvegruppeRepository
{
    public Task<IEnumerable<Prøvegruppe>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Prøvegruppe> GetByIdAsync(PrøvegruppeId prøvegruppeId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Prøvegruppe> CreateAsync(PrøveId prøveId, LærerId lærerId, IEnumerable<ElevId> elever, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Prøvegruppe prøvegruppe, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}