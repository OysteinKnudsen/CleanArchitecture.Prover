using CleanArchitecture.Prover.Domain.ValueTypes;

namespace Domain.UnitTests.ValueTypes;

public class PrøvePeriodeTests
{
    [Test]
    public void Constructor_ValidStartAndSlutt_ShouldCreateObject()
    {
        var start = new DateTimeOffset(2021, 1, 1, 0, 0, 0, TimeSpan.Zero);
        var slutt = start.AddDays(30);

        var prøvePeriode = new PrøvePeriode(start, slutt);

        Assert.That(prøvePeriode.Slutt, Is.EqualTo(slutt));
        prøvePeriode.Slutt.Should().Be(slutt);
        prøvePeriode.Start.Should().Be(start);
    }

    [Test]
    public void Constructor_StartAfterSlutt_ShouldThrowArgumentException()
    {
        var start = new DateTimeOffset(2021, 1, 31, 0, 0, 0, TimeSpan.Zero);
        var slutt = new DateTimeOffset(2021, 1, 1, 0, 0, 0, TimeSpan.Zero);

        Assert.Throws<ArgumentException>(() => new PrøvePeriode(start, slutt));
    }

    [Test]
    public void Constructor_StartEqualsSlutt_ShouldThrowArgumentException()
    {
        var startAndSlutt = new DateTimeOffset(2021, 1, 1, 0, 0, 0, TimeSpan.Zero);

        Assert.Throws<ArgumentException>(() => new PrøvePeriode(startAndSlutt, startAndSlutt));
    }
}