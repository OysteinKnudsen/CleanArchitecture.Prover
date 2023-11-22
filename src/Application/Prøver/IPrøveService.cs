using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Application.Prøver;

// Burde denne filen ligge inne i "Services" mappen? Dersom man skal ha interfaces
// samlet kunne man kanskje hatt en "Interfaces/Abstractions" mappe?
public interface IPrøveService
{
    Task<IEnumerable<Prøve>> GetAllAsync(CancellationToken cancellationToken);
    Task<Prøve> GetByIdAsync(PrøveId prøveId, CancellationToken cancellationToken);
    Task<Prøve> CreateAsync(PrøveNavn navn,Trinn trinn, Fag fag, DateTimeOffset start, DateTimeOffset slutt, CancellationToken cancellationToken);
}