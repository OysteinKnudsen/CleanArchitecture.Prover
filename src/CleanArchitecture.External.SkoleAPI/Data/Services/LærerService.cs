using CleanArchitecture.External.SkoleAPI.Data.Models;

namespace CleanArchitecture.External.SkoleAPI.Data.Services;

public class LærerService: DataService
{
    public IEnumerable<Lærer> GetLærere()
    {
        const string relativePath = "data/JSON/lærere.json";
        return LoadJsonDataAsync<List<Lærer>>(relativePath).Result;
    }

    public IEnumerable<Lærer> GetLærerByKlasseId(int klasseId)
    {
        return GetLærere().Where(lærer => lærer.KlasseId == klasseId);
    }
}