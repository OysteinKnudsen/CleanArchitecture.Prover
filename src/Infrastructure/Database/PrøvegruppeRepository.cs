using CleanArchitecture.Prover.Application.Prøvegrupper;
using CleanArchitecture.Prover.Application.Skole;
using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Infrastructure.Database;

public class PrøvegruppeRepository(ISkoleService skoleService): IPrøvegruppeRepository
{
    public Task<IEnumerable<Prøvegruppe>> GetAllAsync(CancellationToken cancellationToken)
    {
        // fetch provegrupper from JSON
        var 
    }

    public Task<Prøvegruppe> GetByIdAsync(PrøvegruppeId prøvegruppeId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(Prøvegruppe prøvegruppe, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Prøvegruppe prøvegruppe, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(PrøvegruppeId prøvegruppeId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}