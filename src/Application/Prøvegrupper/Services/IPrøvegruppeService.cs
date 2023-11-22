using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Application.Prøvegrupper.Services;

public interface IPrøvegruppeService
{ 
    public Task<IEnumerable<Prøvegruppe>> GetAllAsync(CancellationToken cancellationToken);
    public Task<Prøvegruppe> GetByIdAsync(PrøvegruppeId prøvegruppeId, CancellationToken cancellationToken);
    public Task<Prøvegruppe> CreateAsync(PrøveId prøveId, LærerId lærerId, IEnumerable<ElevId> elever,
        CancellationToken cancellationToken);
    public Task<Prøvegruppe> UpdateStatusAsync(PrøvegruppeId prøveGruppeId, PrøvegruppeStatus status, CancellationToken cancellationToken);
    public Task UpdateElevStatusAsync(PrøvegruppeId prøveGruppeId, ElevId elevId, Gjennomføringsstatus status, CancellationToken cancellationToken);
}