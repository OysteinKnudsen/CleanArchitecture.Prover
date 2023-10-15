using CleanArchitecture.Prover.Domain.Entities;

namespace CleanArchitecture.Prover.Domain.Repositories;

public interface IPrøveRepository
{
    public Task<IEnumerable<Prøve>> GetAllPrøverAsync();
    public Task SavePrøveAsync(Prøve prøve);
}