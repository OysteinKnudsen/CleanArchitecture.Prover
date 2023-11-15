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

- OpenAPI-spec: `https://localhost:7209/swagger/index.html` 

# Oppgaver i workshopen
- (Hent prøver: En liste med alle tilgjengelige prøver)
- (Hent prøver: En prøve basert på en id på selve prøven)
- Opprett prøve: En skoleadministrator (bruker) kan opprette en prøve 
- Opprett prøvegruppe: En skoleadministrator kan melde på en gruppe elever til en prøve 
- Tildel prøvegruppeansvar: En skoleadministrator kan tildele en lærer ansvar for en prøvegruppe
- Åpne prøve: En prøvegruppeansvarlig lærer kan åpne en prøve for gjennomføring 
- Start prøve: En elev i en prøvegruppe kan starte prøve
- Lever prøve: En elev i en prøvegruppe kan levere prøve 
- Lukk prøve: En prøvegruppeansvarlig kan lukke prøven
