using System.Collections;
using CleanArchitecture.Prover.Application.Prøvegrupper;
using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Infrastructure.Database;

public class PrøvegruppeRepository : IPrøvegruppeRepository
{
    private readonly IList _prøvegrupper = new List<Prøvegruppe>();
    public Task<Prøvegruppe> CreateAsync(PrøveId prøveId, LærerId lærerId, IEnumerable<ElevId> elever, CancellationToken cancellationToken)
    {
        var prøvegruppeId = new PrøvegruppeId(_prøvegrupper.Count + 1);
        var prøvegjennomføringer =
            elever.Select(e => new Prøvegjennomføring(e, Gjennomføringsstatus.IkkeStartet)).ToList();
        var prøvegruppe = new Prøvegruppe(prøvegruppeId, prøveId, lærerId, prøvegjennomføringer, PrøvegruppeStatus.StengtForGjennomføring);
        _prøvegrupper.Add(prøvegruppe);
        return Task.FromResult(prøvegruppe);
    }
}