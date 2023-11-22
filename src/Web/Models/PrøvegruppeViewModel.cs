using CleanArchitecture.Prover.Domain.Entities;

namespace CleanArchitecture.Prover.Web.Models;
// Gir det mening å bruke IEnumerable? Man vil jo egentlig ikke enumerere over disse verdiene.
public record PrøvegruppeViewModel(int PrøvegruppeId, int PrøvegruppeansvarligId,
    IEnumerable<PrøvegjennomføringViewModel> Prøvegjennomføringer, string PrøvegruppeStatus)
{
    public static PrøvegruppeViewModel From(Prøvegruppe prøvegruppe)
    {
        var gjennomføringerViewModels = prøvegruppe.Prøvegjennomføringer.Select(PrøvegjennomføringViewModel.From);
        return new PrøvegruppeViewModel(prøvegruppe.PrøvegruppeId, prøvegruppe.Prøvegruppeansvarlig,
            gjennomføringerViewModels, prøvegruppe.Status.ToString());
    }
}