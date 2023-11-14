using CleanArchitecture.Prover.Domain.Entities;

namespace CleanArchitecture.Prover.Web.Models;

public record ElevViewModel(int ElevId, string Navn, int KlasseId)
{
    public static ElevViewModel From(Elev elev)
    {
        return new ElevViewModel(elev.Id, elev.Navn.ToString(), elev.Klasse);
    }
}