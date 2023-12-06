using CleanArchitecture.Prover.Application.Prøvegrupper;
using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;

namespace Web.IntegrationTests.Data;

internal class FakePrøvegruppeRepository : IPrøvegruppeRepository
{
    public static PrøvegruppeId StengtPrøveGruppeMedActivePrøveId = new(12);
    public static PrøvegruppeId ÅpnetPrøveGruppeMedActivePrøveId = new(12);
    private readonly List<Prøvegruppe> _prøvegrupper = new()
    {
        new(
            StengtPrøveGruppeMedActivePrøveId,
            new PrøveId(FakePrøveRepository.ActiveExistingPrøveId),
            new LærerId(1),
            new List<Prøvegjennomføring>(),
            PrøvegruppeStatus.StengtForGjennomføring
            ),
        new(
            ÅpnetPrøveGruppeMedActivePrøveId,
            new PrøveId(FakePrøveRepository.ActiveExistingPrøveId),
            new LærerId(1),
            new List<Prøvegjennomføring>(),
            PrøvegruppeStatus.ÅpnetForGjennomføring
        )
    };
        
    public Task<IEnumerable<Prøvegruppe>> GetAllAsync(CancellationToken cancellationToken)
    {
        return Task.FromResult(_prøvegrupper.AsEnumerable());
    }

    public Task<Prøvegruppe> GetByIdAsync(PrøvegruppeId prøvegruppeId, CancellationToken cancellationToken)
    {
        return Task.FromResult(_prøvegrupper.First(p => p.PrøvegruppeId == prøvegruppeId));
    }

    public Task<Prøvegruppe> CreateAsync(PrøveId prøveId, LærerId lærerId, IEnumerable<ElevId> elever, CancellationToken cancellationToken)
    {
        var prøvegruppe = new Prøvegruppe(
            new PrøvegruppeId(new Random().Next()),
            prøveId,
            lærerId,
            new List<Prøvegjennomføring>(),
            PrøvegruppeStatus.StengtForGjennomføring
        );
        _prøvegrupper.Add(prøvegruppe);

        return Task.FromResult(prøvegruppe);
    }

    public Task UpdateAsync(Prøvegruppe prøvegruppe, CancellationToken cancellationToken)
    {
        _prøvegrupper.RemoveAll(pg => pg.PrøvegruppeId == prøvegruppe.PrøvegruppeId);
        _prøvegrupper.Add(prøvegruppe);
        return Task.CompletedTask;
    }
}