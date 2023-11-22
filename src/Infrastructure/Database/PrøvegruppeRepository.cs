using CleanArchitecture.Prover.Application.Prøvegrupper;
using CleanArchitecture.Prover.Application.Prøvegrupper.Exceptions;
using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Infrastructure.Database;

public class PrøvegruppeRepository : IPrøvegruppeRepository
{
    private readonly List<Prøvegruppe> _prøvegrupper = new List<Prøvegruppe>();
    public Task<Prøvegruppe> CreateAsync(PrøveId prøveId, LærerId lærerId, IEnumerable<ElevId> elever, CancellationToken cancellationToken)
    {
        var prøvegruppeId = new PrøvegruppeId(_prøvegrupper.Count + 1);
        var prøvegjennomføringer =
            elever.Select(e => new Prøvegjennomføring(e, Gjennomføringsstatus.IkkeStartet)).ToList();
        var prøvegruppe = new Prøvegruppe(prøvegruppeId, prøveId, lærerId, prøvegjennomføringer, PrøvegruppeStatus.StengtForGjennomføring);
        _prøvegrupper.Add(prøvegruppe);
        return Task.FromResult(prøvegruppe);
    }

    public Task<IEnumerable<Prøvegruppe>> GetAllAsync(CancellationToken cancellationToken)
    {
        return Task.FromResult((IEnumerable<Prøvegruppe>)_prøvegrupper);
    }

    public Task<Prøvegruppe> GetByIdAsync(PrøvegruppeId prøvegruppeId, CancellationToken cancellationToken)
    {
        var provegruppe = _prøvegrupper.Find(pg => pg.PrøvegruppeId == prøvegruppeId);
        if (provegruppe is null) throw new PrøvegruppeNotFoundException("Fant ikke prøvegruppe med id " + prøvegruppeId);
        return Task.FromResult(provegruppe);
    }

    public Task UpdateAsync(Prøvegruppe prøvegruppe, CancellationToken cancellationToken)
    {
        var index = _prøvegrupper.FindIndex(pg => pg.PrøvegruppeId == prøvegruppe.PrøvegruppeId);
        _prøvegrupper[index] = prøvegruppe;
        return Task.CompletedTask;
    }
}