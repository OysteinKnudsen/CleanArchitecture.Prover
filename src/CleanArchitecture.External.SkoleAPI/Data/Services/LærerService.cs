using CleanArchitecture.External.SkoleAPI.Data.Models;

namespace CleanArchitecture.External.SkoleAPI.Data.Services;
/*
 * ################################################################################
 * # Dette er en ekstern tjeneste som du ikke skal bry deg om implementasjonen av.#
 * ################################################################################
 */
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