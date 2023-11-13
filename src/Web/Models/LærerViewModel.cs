using CleanArchitecture.Prover.Domain.Entities;

namespace CleanArchitecture.Prover.Web.Models;

public record LærerViewModel(int LærerId, string Navn, int? KlasseId)
{
    public static LærerViewModel From(Lærer lærer)
    {
        return new LærerViewModel(lærer.Id, lærer.Navn.ToString(), lærer.Klasseansvar?.Value);
    }
}