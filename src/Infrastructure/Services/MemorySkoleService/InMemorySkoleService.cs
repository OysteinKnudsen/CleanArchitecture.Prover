using CleanArchitecture.Prover.Application.Skole;
using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Infrastructure.Services.MemorySkoleService;

public class InMemorySkoleService : ISkoleService
{
    private readonly IEnumerable<Lærer> _lærere = new List<Lærer>()
    {
        new(new LærerId(101), new LærerNavn("Olav", "Folkestad"), new KlasseId(1)),
        new(new LærerId(102), new LærerNavn("Unni", "Hinkel"), new KlasseId(2)),
    };

    private readonly IEnumerable<Klasse> _klasser = new List<Klasse>()
    {
        new(new KlasseId(1), new LærerId(101), new Trinn(7), new List<ElevId> { new(1), new(2) }),
        new(new KlasseId(2), new LærerId(102), new Trinn(5), new List<ElevId> { new(3), new(4) })
    };

    private readonly IEnumerable<Elev> _elever = new List<Elev>
    {
        new(new ElevId(1), new ElevNavn("Ola", "Normann"), new KlasseId(1),
            Enumerable.Empty<Prøvegjennomføring>()),
        new(new ElevId(2), new ElevNavn("Kari", "Normann"), new KlasseId(1),
            Enumerable.Empty<Prøvegjennomføring>()),
        new(new ElevId(3), new ElevNavn("Per", "Hansen"), new KlasseId(2), Enumerable.Empty<Prøvegjennomføring>()),
        new(new ElevId(4), new ElevNavn("Lise", "Olsen"), new KlasseId(2), Enumerable.Empty<Prøvegjennomføring>())
    };
    
    public Task<IEnumerable<Lærer>> GetLærereAsync()
    {
        return Task.FromResult(_lærere);
    }

    public Task<Lærer?> GetLærerByIdAsync(LærerId id)
    {
        var lærer = _lærere.ToList().FirstOrDefault(l => l.Id == id);
        return Task.FromResult(lærer);
    }

    public Task<IEnumerable<Elev>> GetEleverAsync()
    {
        return Task.FromResult(_elever);
    }

    public Task<Elev?> GetElevByIdAsync(ElevId id)
    {
        var elev = _elever.ToList().FirstOrDefault(e => e.Id == id);
        return Task.FromResult(elev);
    }

    public Task<IEnumerable<Klasse>> GetKlasserAsync()
    {
        return Task.FromResult(_klasser);
    }

    public Task<Klasse?> GetKlasseByIdAsync(KlasseId id)
    {
        var klasse = _klasser.ToList().FirstOrDefault(k => k.Id == id);
        return Task.FromResult(klasse);
    }
}