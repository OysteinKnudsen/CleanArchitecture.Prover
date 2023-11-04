using CleanArchitecture.External.SkoleAPI.Data.Models;

namespace CleanArchitecture.External.SkoleAPI.Data.Services;

public class ElevService: DataService
{
    public IEnumerable<Elev> GetElever()
    {
        const string relativePath = "data/JSON/elever.json";
        return LoadJsonDataAsync<List<Elev>>(relativePath).Result;
    }
    
    public IEnumerable<Elev> GetEleverByKlasseId(int klasseId)
    {
        return GetElever().Where(elev => elev.KlasseId == klasseId);
    }
}