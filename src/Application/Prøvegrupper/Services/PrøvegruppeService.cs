using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Application.Prøvegrupper.Services;

public class PrøvegruppeService(IPrøvegruppeRepository prøvegruppeRepository) : IPrøvegruppeService
{
    public async Task<IEnumerable<Prøvegruppe>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await prøvegruppeRepository.GetAllAsync(cancellationToken);
    }

    public async Task<Prøvegruppe> GetByIdAsync(PrøvegruppeId prøvegruppeId, CancellationToken cancellationToken)
    {
        return await prøvegruppeRepository.GetByIdAsync(prøvegruppeId, cancellationToken);
    }

    public async Task<Prøvegruppe> CreateAsync(PrøveId prøveId, LærerId lærerId, IEnumerable<ElevId> elever, CancellationToken cancellationToken)
    {
        return await prøvegruppeRepository.CreateAsync(prøveId, lærerId, elever, cancellationToken);
    }

    public async Task<Prøvegruppe> UpdateStatusAsync(PrøvegruppeId prøveGruppeId, PrøvegruppeStatus status, CancellationToken cancellationToken)
    {
        var prøvegruppe = await prøvegruppeRepository.GetByIdAsync(prøveGruppeId, cancellationToken);
        var modifiedProvegruppe = prøvegruppe with { Status = status };
        await prøvegruppeRepository.UpdateAsync(modifiedProvegruppe, cancellationToken);
        return modifiedProvegruppe;
    }
}