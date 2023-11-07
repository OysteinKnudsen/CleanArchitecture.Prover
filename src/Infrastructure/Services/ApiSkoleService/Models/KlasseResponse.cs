namespace CleanArchitecture.Prover.Infrastructure.Services.Models;

public record KlasseResponse(int KlasseId, int Trinn, string Gruppe, int LærerId, IEnumerable<int> Elever);