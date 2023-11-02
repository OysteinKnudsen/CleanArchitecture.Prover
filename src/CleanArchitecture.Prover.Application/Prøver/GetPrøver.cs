using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.Repositories;

namespace CleanArchitecture.Prover.Application.Prøver;

public interface IGetPrøver
{
    // Burde denne returnere en annen type enn Prøve fra Domain?
    Task<IEnumerable<Prøve>> GetAllPrøver();
}

public class GetPrøver(IPrøveRepository prøverRepository) : IGetPrøver
{
    public Task<IEnumerable<Prøve>> GetAllPrøver()
    {
        return prøverRepository.GetAllPrøverAsync();
    }
}