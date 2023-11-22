using CleanArchitecture.Prover.Domain.Entities;

namespace CleanArchitecture.Prover.Web.Models;

public record PrøvegjennomføringViewModel(int ElevId, string Gjennomføringsstatus) 
{
    public static PrøvegjennomføringViewModel From(Prøvegjennomføring prøvegjennomføring)
    {
        return new PrøvegjennomføringViewModel(prøvegjennomføring.Elev, prøvegjennomføring.Gjennomføringsstatus.ToString());
    }
}