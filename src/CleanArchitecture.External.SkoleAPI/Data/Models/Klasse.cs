namespace CleanArchitecture.External.SkoleAPI.Data.Models;

public record Klasse(int KlasseId,int Trinn, char Gruppe, int LærerId, IEnumerable<int> Elever);