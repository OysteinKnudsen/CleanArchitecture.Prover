using System.Text.Json;
using CleanArchitecture.External.SkoleAPI.Data.Models;

namespace CleanArchitecture.External.SkoleAPI.Data.Services;

public class KlasseService : DataService
{
    public IEnumerable<Klasse> GetKlasser()
    {
        const string relativePath = "data/JSON/klasser.json";
        return LoadJsonDataAsync<List<Klasse>>(relativePath).Result;
    }

    public IEnumerable<Klasse> GetKlasseById(int klasseId)
    {
        return GetKlasser().Where(klasse => klasse.KlasseId == klasseId);
    }
}