using CleanArchitecture.Prover.Domain.Entities;

namespace CleanArchitecture.Prover.Web.Models;

public record KlasseViewModel(int KlasseId, int LærerId,int Trinn, IEnumerable<int> ElevIder)
{
    public static KlasseViewModel From(Klasse klasse)
    {
        return new KlasseViewModel(klasse.Id, klasse.Lærer, klasse.Trinn, klasse.Elever.Select(elev => elev.Value));
    }
}