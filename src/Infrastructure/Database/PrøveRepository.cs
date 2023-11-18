using CleanArchitecture.Prover.Application.Prøver;
using CleanArchitecture.Prover.Application.Prøver.Exceptions;
using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;
using CleanArchitecture.Prover.Infrastructure.Database.Models;

namespace CleanArchitecture.Prover.Infrastructure.Database;

internal class PrøveRepository : IPrøveRepository
{
    private readonly IEnumerable<InMemoryPrøve>? _prøver = new List<InMemoryPrøve>
    {
        new()
        {
            Id = 1,
            Navn = "Prøve i matte 10. trinn 2023",
            PrøvePeriode = new InMemoryPrøvePeriode
            {
                Start = new DateTimeOffset(new DateTime(2023, 10, 01)),
                Slutt = new DateTimeOffset(new DateTime(2023, 10, 15))
            },
            Trinn = 10,
            Fag = "Matematikk"
        },
        new()
        {
            Id = 2,
            Navn = "Prøve i norsk 10. trinn 2023",
            PrøvePeriode = new InMemoryPrøvePeriode
            {
                Start = new DateTimeOffset(new DateTime(2023, 10, 01)),
                Slutt = new DateTimeOffset(new DateTime(2023, 10, 15))
            },
            Trinn = 10,
            Fag = "Norsk"
        },
        new()
        {
            Id = 3,
            Navn = "Prøve i engelsk 10. trinn 2023",
            PrøvePeriode = new InMemoryPrøvePeriode
            {
                Start = new DateTimeOffset(new DateTime(2023, 10, 01)),
                Slutt = new DateTimeOffset(new DateTime(2023, 10, 15))
            },
            Trinn = 10,
            Fag = "Engelsk"
        }
    };

    public Task<IEnumerable<Prøve>> GetAllAsync(CancellationToken cancellationToken)
    {
        var prøver = _prøver is null
            ? Enumerable.Empty<Prøve>()
            : _prøver.Select(GetPrøve);

        return Task.FromResult(prøver);
    }

    public Task<Prøve> GetByIdAsync(PrøveId prøveId, CancellationToken cancellationToken)
    {
        if (_prøver is null)
        {
            throw new PrøveNotFoundException(prøveId);
        }
        var foundPrøve = _prøver.FirstOrDefault(jsonPrøve => jsonPrøve.Id == prøveId.Id);
        return foundPrøve is null
            ? throw new PrøveNotFoundException(prøveId)
            : Task.FromResult(GetPrøve(foundPrøve));

    }

    private static Prøve GetPrøve(InMemoryPrøve inMemoryPrøve)
    {
        return new Prøve(
            (PrøveId)inMemoryPrøve.Id,
            (PrøveNavn)inMemoryPrøve.Navn,
            new PrøvePeriode(inMemoryPrøve.PrøvePeriode.Start, inMemoryPrøve.PrøvePeriode.Slutt),
            (Trinn)inMemoryPrøve.Trinn,
            FagFactory.GetFag(inMemoryPrøve.Fag));
    }
}