using CleanArchitecture.Prover.Application.Prøvegrupper;
using CleanArchitecture.Prover.Application.Prøvegrupper.Exceptions;
using CleanArchitecture.Prover.Application.Prøvegrupper.Services;
using CleanArchitecture.Prover.Application.Prøver;
using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;
using Moq;

namespace Application.UnitTests.Prøvegrupper;

public class PrøvegruppeServiceTests
{
    /*
     * Dette er bare starten på en testklasse med ett eksempel på hva som kan bli testet.
     * Poenget er å få demonstrert effekten av å ha tydelig definerte grensesnitt og at det er enkelt å teste.
     */
    private readonly Mock<IPrøvegruppeRepository> _prøvegruppeRepositoryMock;
    private readonly Mock<IPrøveRepository> _prøveRepositoryMock;
    private readonly PrøvegruppeService _target;
    
    public PrøvegruppeServiceTests()
    {
        _prøvegruppeRepositoryMock = new Mock<IPrøvegruppeRepository>();
        _prøveRepositoryMock = new Mock<IPrøveRepository>();
        _target = new PrøvegruppeService(_prøvegruppeRepositoryMock.Object, _prøveRepositoryMock.Object);
    }
    
    [Fact]
    public async Task UpdateStatusAsync_WhenOutsidePrøveperiode_ThrowsOutsidePrøveperiodeException()
    {
        // Arrange
        var prøvegruppeId = new PrøvegruppeId(1);
        _prøveRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<PrøveId>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(UtgåttPrøve);
        _prøvegruppeRepositoryMock.Setup(x => x.GetByIdAsync(prøvegruppeId, new CancellationToken()))
            .ReturnsAsync(MinimalPrøvegruppe);
        
        // Assert + act
        await Assert.ThrowsAsync<InactivePrøveperiodeException>(() => _target.UpdateStatusAsync(prøvegruppeId, PrøvegruppeStatus.ÅpnetForGjennomføring, new CancellationToken()));
    }

    [Fact]
    public async Task UpdateStatusAsync_WhenActivePrøveperiode_UpdatesStatus()
    {
        // Arrange
        var prøvegruppeId = new PrøvegruppeId(1);
        _prøveRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<PrøveId>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(AktivPrøve);
        _prøvegruppeRepositoryMock.Setup(x => x.GetByIdAsync(prøvegruppeId, new CancellationToken()))
            .ReturnsAsync(MinimalPrøvegruppe);
        
        // Act
        await _target.UpdateStatusAsync(prøvegruppeId, PrøvegruppeStatus.ÅpnetForGjennomføring, new CancellationToken());

        // Assert
        _prøvegruppeRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<Prøvegruppe>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    private static Prøve UtgåttPrøve => new (
        PrøveId.From(1), 
        PrøveNavn.From("Utgått prøve"), 
        new PrøvePeriode(DateTime.Now.Subtract(TimeSpan.FromDays(3)),
            DateTime.Now.Subtract(TimeSpan.FromDays(1))),
        new Trinn(5), Fag.Norsk);

    private static Prøve AktivPrøve => new(
        PrøveId.From(1),
        PrøveNavn.From("Aktiv prøve"),
        new PrøvePeriode(DateTime.Now.Subtract(TimeSpan.FromDays(3)),
            DateTime.Now.Add(TimeSpan.FromDays(3))),
        new Trinn(5), Fag.Norsk);

    private static Prøvegruppe MinimalPrøvegruppe => new(
        new PrøvegruppeId(1),
        PrøveId.From(1),
        new LærerId(1),
        new List<Prøvegjennomføring>(),
        PrøvegruppeStatus.StengtForGjennomføring
    );
}