# CleanArchitecture.Prover

Repo for clean architecture workshop.
Implementasjonen er inspirert av Clean Architecture fra https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html

Strukturen i repoet i "src"-mappen er som følger:

1. **Domain**  
   Entiteter, valuetypes
2. **Application**  
   Applikasjonslogikk, grensesnitt mot avhengigheter
3. **Infrastructure**  
   Database, eksterne tjenester, repsitorier
4. **Web**  
   Controllere, dependency injection setup ++

**Domain** er den innerste delen av arkitekturen og skal derfor ikke referere til noe annet lag.
**Application** kan bare referere til **Domain**.  
**Infrastructure** kan referere til **Application** og **Domain**.  
**Web** er ytterst og kan dermed kjenne til alle lag.

## Forutsetninger

- .NET 8.0 https://dotnet.microsoft.com/en-us/download
- Editor (Visual studio code, Visual Studio, Rider)
- dotnet dev-sertifikat; for å installere et slikt sertifikat: `dotnet dev-certs https --trust`

## Kjøre applikasjonen

- Åpne en terminal der .NET CLI er tilgjengelig
- Navigèr til `src\Web` og skriv `dotnet run` etterfulgt av enter:

```
~\CleanArchitecture.Prover\src\Web> dotnet run
```

- Noe som dette bør vises i konsollet:

```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:7209
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5136
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\projects\faggruppe\CleanArchitecture.Prover\src\Web
```

- OpenAPI-spec https: `https://localhost:7209/swagger/index.html` 
- OpenAPI-spec http: `https://localhost:5136/swagger/index.html` 

# Oppgaver i workshopen
Nedenfor er en oversikt over oppgavene som skal løses i workshopen.
Oppgaven din blir å implementere disse. I “Regler”-kolonnen vil det være noen forretningsregler som vi ønsker at systemet skal implementere. Disse reglene er veiledende, ikke bruk veldig mye tid på å implementere alle disse. Men gjerne gjør et forsøk på å implementere minst en forretningsregel som du kan teste ved å mocke andre avhengigheter. 
<table>
  <caption>
    Oppgaver
  </caption>
  <thead>
    <tr>
      <th>Oppgave</th>
      <th>Beskrivelse</th>
      <th>Regler (veiledende)</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>Opprett prøve</td>
      <td>
        Skoleadministrator kan opprette en prøve. En prøve er satt opp for ett
        trinn, for ett fag i en gitt periode. Prøven skal også ha et navn,
        f.eks. “Vårprøve i naturfag for 8.trinn”.
      </td>
      <td>
        <ul>
          <li>Trinn skal være mellom 1 og 10</li>
          <li>Fra-dato skal være i fremtiden</li>
          <li>Til-dato skal være før fra-dato</li>
        </ul>
      </td>
    </tr>
    <tr>
      <td>Opprett en prøvegruppe</td>
      <td>
        En skoleadministrator kan melde på en gruppe elever til en prøve. Denne
        påmeldte gruppen til en prøve danner en prøvegruppe. Prøvegruppen
        gjennomfører prøven sammen og vil typisk være en klasse på en skole.
      </td>
      <td>
        <ul>
          <li>
            En prøvegruppe kan bare opprettes for en prøve innenfor prøvens
            prøveperiode.
          </li>
          <li>En elev kan bare være meldt på en gang til samme prøve.</li>
        </ul>
      </td>
    </tr>
    <tr>
      <td>Åpne prøve for gjennomføring for en gitt prøvegruppe</td>
      <td>
        En prøvegruppeansvarlig kan åpne en prøve for sin prøvegruppe. Når
        prøvegruppen er åpnet for gjennomføring kan elevene starte prøven.
      </td>
      <td>En prøve kan bare åpnes i prøveperioden.</td>
    </tr>
    <tr>
      <td>Lukk prøve for gjennomføring for en gitt prøvegruppe</td>
      <td>
        En prøvegruppeansvarlig kan lukke prøven for sin prøvegruppe. Da vil det
        ikke lenger være mulig for elevene å starte prøven.
      </td>
      <td></td>
    </tr>
    <tr>
      <td>Start prøve for elev</td>
      <td>En elev kan starte en prøve som eleven er påmeldt.</td>
      <td>
        Eleven kan bare starte en prøve som er åpnet for gjennomføring av
        prøvegruppeansvarlig.
      </td>
    </tr>
    <tr>
      <td>Lever prøve for elev</td>
      <td>En elev kan levere prøven som eleven har påbegynt.</td>
      <td>
        <ul>
          <li>En elev kan bare levere en prøve som allerede er åpnet.</li>
          <li>
            En elev kan bare levere en prøve som er åpen for gjennomføring.
          </li>
        </ul>
      </td>
    </tr>
  </tbody>
</table>
