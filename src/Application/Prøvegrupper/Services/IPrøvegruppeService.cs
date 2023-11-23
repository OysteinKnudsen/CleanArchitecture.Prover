using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Application.Prøvegrupper.Services;

public interface IPrøvegruppeService
{ 
    public Task<IEnumerable<Prøvegruppe>> GetAllAsync();
    public Task<Prøvegruppe> GetByIdAsync(PrøvegruppeId prøvegruppeId);
    public Task<Prøvegruppe> CreateAsync(PrøveId prøveId, LærerId lærerId, IEnumerable<ElevId> elever);
    public Task<Prøvegruppe> UpdateStatusAsync(PrøvegruppeId prøveGruppeId, PrøvegruppeStatus status);
    public Task UpdateElevStatusAsync(PrøvegruppeId prøveGruppeId, ElevId elevId, Gjennomføringsstatus status);
}