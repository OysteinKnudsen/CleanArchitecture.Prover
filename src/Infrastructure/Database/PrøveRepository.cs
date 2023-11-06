using System.Reflection;
using System.Text.Json;
using CleanArchitecture.Prover.Application.Abstractions;
using CleanArchitecture.Prover.Application.Prøver.Exceptions;
using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;
using CleanArchitecture.Prover.Infrastructure.Database.Models;

namespace CleanArchitecture.Prover.Infrastructure.Database;

internal sealed class PrøveRepository : IPrøveRepository
{
    private readonly IEnumerable<JsonPrøve>? _prøver;

    private static readonly JsonSerializerOptions
        JsonSerializerOptions = new() { PropertyNameCaseInsensitive = false };

    public PrøveRepository()
    {
        var stream =
            Assembly.GetAssembly(typeof(PrøveRepository))!.GetManifestResourceStream(
                "CleanArchitecture.Prover.Infrastructure.Data.prøver.json");
        using var streamReader = new StreamReader(stream!);
        var json = streamReader.ReadToEnd();
        _prøver = JsonSerializer.Deserialize<IEnumerable<JsonPrøve>>(json, JsonSerializerOptions);
    }

    public Task<IEnumerable<Prøve>> GetAllAsync(CancellationToken cancellationToken)
    {
        var prøver = _prøver is null
            ? Enumerable.Empty<Prøve>()
            : _prøver.Select(GetPrøve);

        return Task.FromResult(prøver);
    }

    public Task<Prøve> GetPrøveAsync(PrøveId prøveId, CancellationToken cancellationToken)
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

    private static Prøve GetPrøve(JsonPrøve jsonPrøve)
    {
        return new Prøve(
            (PrøveId)jsonPrøve.Id,
            (PrøveNavn)jsonPrøve.Navn,
            new PrøvePeriode(jsonPrøve.PrøvePeriode.Start, jsonPrøve.PrøvePeriode.Slutt),
            (Trinn)jsonPrøve.Trinn,
            FagFactory.GetFag(jsonPrøve.Fag));
    }
}