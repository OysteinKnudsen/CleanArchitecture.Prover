using CleanArchitecture.Prover.Domain.Entities;

namespace CleanArchitecture.Prover.Web.Models;

public record PrøvegjennomføringViewModel(string PrøveId, int ElevId, string Gjennomføringsstatus) 
{
    public static PrøvegjennomføringViewModel From(Prøvegjennomføring prøvegjennomføring)
    {
        return new PrøvegjennomføringViewModel(prøvegjennomføring.PrøveId, prøvegjennomføring.ElevId, prøvegjennomføring.Gjennomføringsstatus.ToString());
    }
}