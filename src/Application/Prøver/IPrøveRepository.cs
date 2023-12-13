using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Application.Prøver;

public interface IPrøveRepository
{
    public Task<IEnumerable<Prøve>> GetAllAsync();
    public Task<Prøve> GetByIdAsync(PrøveId prøveId);
    public Task<Prøve> SaveAsync(Prøve prøve);
}