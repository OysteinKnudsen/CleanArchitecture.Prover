using CleanArchitecture.Prover.Application.Prøver;
using CleanArchitecture.Prover.Application.Skole;
using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Application.Prøvegrupper.Services;

public class PrøvegruppeService(IPrøvegruppeRepository prøvegruppeRepository, ISkoleService skoleService, IPrøveService prøveService) : IPrøvegruppeService
{
    public Task<IEnumerable<Prøvegruppe>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Prøvegruppe> GetByIdAsync(PrøvegruppeId prøvegruppeId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Prøvegruppe> CreateAsync(PrøveId prøveId, LærerId lærerId, IEnumerable<ElevId> elever, CancellationToken cancellationToken)
    {
        return await prøvegruppeRepository.CreateAsync(prøveId, lærerId, elever, cancellationToken);
    }

    public Task UpdateStatusAsync(PrøvegruppeId prøveGruppeId, PrøvegruppeStatus status, CancellationToken cancellationToken)
    {
        // TODO: implementer mulighet for å oppdatere en prøvegruppe sin status. 
        throw new NotImplementedException();
    }
}