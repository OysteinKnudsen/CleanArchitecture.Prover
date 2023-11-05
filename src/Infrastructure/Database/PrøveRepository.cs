using System.Text.Json;
using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.Repositories;

namespace CleanArchitecture.Prover.Infrastructure.Database;

public class PrøveRepository : IPrøveRepository
{
    public Task<IEnumerable<Prøve>> GetAllPrøverAsync()
    {
        var json = File.ReadAllText("../prøver.json");
        var prøve = JsonSerializer.Deserialize<Prøve>(json);
        return Task.FromResult(new List<Prøve> { prøve }.AsEnumerable());
    }

    public Task SavePrøveAsync(Prøve prøve)
    {
        throw new NotImplementedException();
    }
}