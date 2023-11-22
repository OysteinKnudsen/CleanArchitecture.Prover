using CleanArchitecture.Prover.Application.Prøvegrupper.Exceptions;
using CleanArchitecture.Prover.Application.Prøver;
using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Application.Prøvegrupper.Services;

public class PrøvegruppeService(IPrøvegruppeRepository prøvegruppeRepository, IPrøveRepository prøveRepository)
    : IPrøvegruppeService
{
    public async Task<IEnumerable<Prøvegruppe>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await prøvegruppeRepository.GetAllAsync(cancellationToken);
    }

    public async Task<Prøvegruppe> GetByIdAsync(PrøvegruppeId prøvegruppeId, CancellationToken cancellationToken)
    {
        return await prøvegruppeRepository.GetByIdAsync(prøvegruppeId, cancellationToken);
    }

    public async Task<Prøvegruppe> UpdateStatusAsync(PrøvegruppeId prøveGruppeId, PrøvegruppeStatus status, CancellationToken cancellationToken)
    {
        /*
         Regel: en prøvegruppe kan bare åpnes for gjennomføring i prøveperioden.
         */
        var prøvegruppe = await prøvegruppeRepository.GetByIdAsync(prøveGruppeId, cancellationToken);
        var prøve = await prøveRepository.GetByIdAsync(prøvegruppe.Prøve, cancellationToken);

        if (!prøve.ErAktiv) throw new InactivePrøveperiodeException("Prøvegruppe kan ikke åpnes utenfor prøveperioden.");
        
        var modifiedProvegruppe = prøvegruppe with { Status = status };
        await prøvegruppeRepository.UpdateAsync(modifiedProvegruppe, cancellationToken);
        return modifiedProvegruppe;
    }

    public async Task<Prøvegruppe> CreateAsync(PrøveId prøveId, LærerId lærerId, IEnumerable<ElevId> elever, CancellationToken cancellationToken)
    {
        /*
         TODO: Implementer opprettelse av en prøvegruppe.
         Regel: en prøvegruppe kan bare opprettes for en prøve innenfor prøvens prøveperiode.
         Regel: En elev kan bare være meldt på en gang til samme prøve. 
        */
        var prøve = await prøveRepository.GetByIdAsync(prøveId, cancellationToken);
        
        if (prøve.ErAktiv)
            throw new InactivePrøveperiodeException("Prøvegruppe kan ikke opprettes utenfor prøveperioden.");
        
        // TODO: implementer sjekk for elevene er meldt på prøven fra før.
        return await prøvegruppeRepository.CreateAsync(prøveId, lærerId, elever, cancellationToken);
    }
    public Task UpdateElevStatusAsync(PrøvegruppeId prøveGruppeId, ElevId elevId, Gjennomføringsstatus status,
        CancellationToken cancellationToken)
    {
        /*
         * TODO: Implementer oppdatering av status på en elev i en prøvegruppe.
         * Regel: En elev kan bare endre status til "Startet" eller "Levert" i prøveperioden.
         * Regel: En elev kan bare endre status til "Startet" eller "Levert" dersom prøvegruppen er åpen for gjennomføring.
         */
        throw new NotImplementedException();
    }
}