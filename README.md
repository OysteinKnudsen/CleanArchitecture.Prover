# CleanArchitecture.Prover

Repo for clean architecture workshop.
Implementasjonen er inspirert av Clean Architecture fra https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html

Strukturen i repoet i "src"-mappen er som følger:

1. **Domain**  
   Entiteter, valuetypes
2. **Application**  
   Applikasjonslogikk, grensesnitt mot avhengigheter
3. **Infrastructure**  
   Database, eksterne tjenester, repositorier
4. **Web**  
   Controllere, dependency injection setup ++
5. **Tests**
   Ulike enhetstester for Domain og Application, samt integrasjonstester for Web (APIet)
6. External
   Inneholder et "eksternt" SkoleAPI hvor man kan hente ut skoler, lærere og elever.

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
Oppgaven din blir å implementere disse.I “Regler”-kolonnen vil det være noen forretningsregler som vi ønsker at systemet skal implementere. 
Du må ikke nødvendigvis implementere alle reglene, men vi har på forhånd implementert en del ende-til-ende tester som tester en del av disse forretningsreglene og som verifiserer at selve use-caset fungerer korrekt ved å teste APIet.

Den første oppgaven i listen er allerede implementert, slik at du kan se hvordan vi har tenkt at oppgavene skal løses.

Noen tips og tanker om hvordan du kan gå frem:

Generelt er oppgavene ganske løst beskrevet og har nødvendigvis ingen eksakt fasit. Men i starten kan det være lurt å se på første use case, og så prøve å basere
de andre use casene/oppgavene på dette. Men prøv også gjerne ut andre måter å løse ting på. Målet er å bli kjent med strukturen og kanskje kunne hente noe inspirasjon fra den, og ikke nødvendigvis klare å løse alle oppgavene 😊.

Vi har også implementert litt ulike tester som det kan anbefales å ta en titt på, og gjerne utvide hvis du ønsker som en del av workshopen.

🙋‍♀️ **PS**: Dersom det er noe som er uklart i oppgavene, eller har du spørsmål til hvordan man burde implementere en oppgave, bare spør oss som holder workshopen!

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
      <td>Opprett prøve (allerede implementert)</td>
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
      <td>
         <ul>
            <li>En prøve kan bare åpnes i prøveperioden</li>
         </ul>
      </td>
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
         <ul>
            <li>Eleven kan bare starte en prøve som er åpnet for gjennomføring av prøvegruppeansvarlig.</li>
        </ul>
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
   <tr>
      <td>
         Ta i bruk "SkoleAPI"
      </td>
      <td>Du har nettopp fått beskjed om at "SkoleAPI" er ferdig utviklet og at tjenesten endelig er klar til bruk.
         Ta i bruk en ny implementasjon av `ISkoleService` som går mot dette APIet i stedet for vår "In-memory" tjeneste/mock</td>
      <td>
      </td>
    </tr>
  </tbody>
</table>

## Ekstraoppgaver ⭐️ 
Har du kommet gjennom alle oppgavene over, fått skrevet noen enhetstester og byttet ut en ekstern tjeneste? Imponerende! Her er noen ekstraoppgaver du kan bryne deg på. Disse har ikke like tydelige rammer som de andre oppgavene, så her er det opp til deg å finne ut hvordan du vil løse dem.


<table>
    <caption>Ekstraoppgaver</caption>
  <thead>
    <tr>
      <th>Oppgave</th>
      <th>Beskrivelse</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>Legg til oppgaver på en prøve</td>
      <td>
        En prøve uten oppgaver gir ikke mye mening. Utvid prøven til å inneholde
        oppgaver. En oppgave består av oppgavetekst, svaralternativer og riktig
        svar.
      </td>
    </tr>
    <tr>
        <td>Legg til oppgavesvar for en elev sin prøvegjennomføring</td>
        <td>
            Vi må vite hva en elev har svart på prøven. Utvid prøvegjennomføringen til å inneholde oppgavesvar.
        </td>
    </tr>
    <tr>
        <td>Automatisk vurdering av eleven sin besvarelse</td>
        <td>
            Det er veldig mye arbeid for lærerne å rette hver prøve manuelt. Legg til automatisk vurdering av eleven sin besvarelse.
        </td>
    </tr>
  </tbody>
</table>

## Bonusmateriale og ressurser

Hvis du er helt ferdig, eller ønsker å bruke tid enten nå eller senere til å se på noen anbefalte ressurser for å lære mer om Clean Architecture, kan vi anbefale følgende:

- Rykende fersk presentasjon av Microsoft om Clean Architecture i .NET 8.0: https://youtu.be/yF9SwL0p0Y0
- Unlce Bob sin bloggpost om Clean Architecture; https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html
- 10 minutters video om Onion Architecture: https://www.youtube.com/watch?v=oC2Ty8H9jck
- Introduksjon til Clean Architecture, DDD og CQRS: https://blog.jacobsdata.com/2020/02/19/a-brief-intro-to-clean-architecture-clean-ddd-and-cqrs
- Simon Brown som prater om "Modular Monoliths": https://www.youtube.com/watch?v=5OjqD-ow8GE
- Clean Architecture av Robert Martin: https://www.amazon.com/Clean-Architecture-Craftsmans-Software-Structure/dp/0134494164

