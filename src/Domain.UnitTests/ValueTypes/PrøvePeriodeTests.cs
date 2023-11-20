using System.Diagnostics.CodeAnalysis;
using CleanArchitecture.Prover.Domain.ValueTypes;
// ReSharper disable ObjectCreationAsStatement

namespace Domain.UnitTests.ValueTypes;

[SuppressMessage("Performance", "CA1806:Do not ignore method results")]
public class PrøvePeriodeTests
{
    [Fact]
    public void Constructor_ValidStartAndSlutt_ShouldCreateObject()
    {
        var start = new DateTimeOffset(2021, 1, 1, 0, 0, 0, TimeSpan.Zero);
        var slutt = start.AddDays(30);

        var prøvePeriode = new PrøvePeriode(start, slutt);
        
        prøvePeriode.Slutt.Should().Be(slutt);
        prøvePeriode.Start.Should().Be(start);
    }

    [Fact]
    public void Constructor_StartAfterSlutt_ShouldThrowArgumentException()
    {
        var start = new DateTimeOffset(2021, 1, 31, 0, 0, 0, TimeSpan.Zero);
        var slutt = new DateTimeOffset(2021, 1, 1, 0, 0, 0, TimeSpan.Zero);

        Action act = () => new PrøvePeriode(start, slutt);

        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Constructor_StartEqualsSlutt_ShouldThrowArgumentException()
    {
        var startAndSlutt = new DateTimeOffset(2021, 1, 1, 0, 0, 0, TimeSpan.Zero);

        Action act = () => new PrøvePeriode(startAndSlutt, startAndSlutt);
        act.Should().Throw<ArgumentException>();
    }
}