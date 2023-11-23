using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Application.Prøver;

public interface IPrøveService
{
    Task<IEnumerable<Prøve>> GetAllAsync();
    Task<Prøve> GetByIdAsync(PrøveId prøveId);
    Task<Prøve> CreateAsync(PrøveNavn navn,Trinn trinn, Fag fag, DateTimeOffset start, DateTimeOffset slutt);
}