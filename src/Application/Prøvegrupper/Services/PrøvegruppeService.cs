using CleanArchitecture.Prover.Application.Prøvegrupper;
using CleanArchitecture.Prover.Application.Skole;
using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Application.Prøver;

public class PrøvegruppeService(IPrøvegruppeRepository prøvegruppeRepository, ISkoleService skoleService) : IPrøvegruppeService
{
    public Task<IEnumerable<Prøvegruppe>> GetAllAsync(CancellationToken cancellationToken)
    {
        //TODO: Er det riktig at man henter data fra SkoleService og prøvegruppeRepo i denne servicen?
        throw new NotImplementedException();
    }

    public Task<Prøvegruppe> GetByIdAsync(PrøvegruppeId prøvegruppeId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(PrøveId prøveId, LærerId lærerId, IEnumerable<ElevId> elever, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task UpdateStatusAsync(PrøvegruppeId prøveGruppeId, PrøvegruppeStatus status, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}