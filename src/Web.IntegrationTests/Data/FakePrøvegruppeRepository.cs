using CleanArchitecture.Prover.Application.Prøvegrupper;
using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;

namespace Web.IntegrationTests.Data;

internal class FakePrøvegruppeRepository : IPrøvegruppeRepository
{
    public static PrøvegruppeId StengtPrøveGruppeMedActivePrøveId = new(12);
    public static PrøvegruppeId ÅpnetPrøveGruppeMedActivePrøveId = new(14);
    public static int PåmeldtElevId = 20;
    public static int IkkePåmeldtElevId = 100;

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
            new List<Prøvegjennomføring>
            {
                new(
                    new PrøveId(FakePrøveRepository.ActiveExistingPrøveId),
                    new ElevId(PåmeldtElevId),
                    Gjennomføringsstatus.IkkeStartet)
            },
            PrøvegruppeStatus.ÅpnetForGjennomføring
        )
    };

    public Task<IEnumerable<Prøvegruppe>> GetAllAsync()
    {
        return Task.FromResult(_prøvegrupper.AsEnumerable());
    }

    public Task<Prøvegruppe> GetByIdAsync(PrøvegruppeId prøvegruppeId)
    {
        return Task.FromResult(_prøvegrupper.First(p => p.PrøvegruppeId == prøvegruppeId));
    }

    public Task<Prøvegruppe> SaveAsync(Prøvegruppe prøvegruppe)
    {
        _prøvegrupper.Add(prøvegruppe);

        return Task.FromResult(prøvegruppe);
    }

    public Task UpdateAsync(Prøvegruppe prøvegruppe)
    {
        _prøvegrupper.RemoveAll(pg => pg.PrøvegruppeId == prøvegruppe.PrøvegruppeId);
        _prøvegrupper.Add(prøvegruppe);
        return Task.CompletedTask;
    }
}