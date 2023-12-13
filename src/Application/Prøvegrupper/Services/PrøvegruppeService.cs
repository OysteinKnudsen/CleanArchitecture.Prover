using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Application.Prøvegrupper.Services;

public class PrøvegruppeService : IPrøvegruppeService
{
    public Task<IEnumerable<Prøvegruppe>> GetAllAsync()
    {
        // TODO: Implementer henting av alle prøvegrupper.
        throw new NotImplementedException();
    }

    public Task<Prøvegruppe> GetByIdAsync(PrøvegruppeId prøvegruppeId)
    {
        // TODO: Implementer henting av en enkelt prøvegruppe basert på prøvegruppeId.
        throw new NotImplementedException();
    }

    public Task<Prøvegruppe> CreateAsync(PrøveId prøveId, LærerId lærerId, IEnumerable<ElevId> elever)
    {
        /*
         TODO: Implementer opprettelse av en prøvegruppe.
         Regel: en prøvegruppe kan bare opprettes for en prøve innenfor prøvens prøveperiode.
         Regel: En elev kan bare være meldt på en gang til samme prøve.
        */

        throw new NotImplementedException();
    }

    public Task<Prøvegruppe> UpdateStatusAsync(PrøvegruppeId prøveGruppeId, PrøvegruppeStatus status)
    {
        /*
         TODO: Implementer oppdatering av status på en prøvegruppe.
         Regel: en prøvegruppe kan bare åpnes for gjennomføring i prøveperioden.
         */

        throw new NotImplementedException();
    }

    public Task UpdateElevStatusAsync(PrøvegruppeId prøveGruppeId, ElevId elevId, Gjennomføringsstatus status)
    {
        /*
         * TODO: Implementer oppdatering av status på en elev i en prøvegruppe.
         * Regel: En elev kan bare endre status til "Startet" eller "Levert" i prøveperioden.
         * Regel: En elev kan bare endre status til "Startet" eller "Levert" dersom prøvegruppen er åpen for gjennomføring.
         */
        throw new NotImplementedException();
    }
}