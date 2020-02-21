# B2B-koppeling gebiedsinformatie-aanvraag (KLIC B2B-aanvraag)

**Inhoudsopgave**

- [Inleiding](#inleiding)
- [Wijzigingen versie 1.1](#wijzigingen-versie-11)
- [Implementatie](#implementatie)

---------------------------------------------------------
## Inleiding

Dit document beschrijft de wijzigingen die doorgevoerd worden in de B2B-koppeling voor het aanvragen van gebiedsinformatie.  \
Deze B2B-koppeling is momenteel geimplementeerd op basis van het SOAP-protocol en kent onderstaande interfaces:
- _KlicB2BAanvraag_  \
voor het aanvragen van gebiedsinformatie.
- _KlicB2BOrderbevestiging_  \
voor het terugkoppelen door het Kadaster van order-informatie van een succesvolle aanvraag.  \
Als er fouten worden geconstateerd, worden deze hiermee ook teruggekoppeld.
- _KlicB2BBetrokkenBeheerders_  \
voor een overzicht van beheerders met een belang bij een calamiteitenmelding.

De (technische) toelichting op het huidige gebruik van deze interfaces is gepubliceerd op de Klic-pagina's van de Kadaster-website.  \
Zie: https://www.kadaster.nl/klic-technische-documentatie.


## Wijzigingen versie 1.1

In de nieuwe versie van het interface _KlicB2BAanvraag_ zijn de volgende optionele attributen van een gebiedsinformatie-aanvraag toegevoegd:

- `KvkNummer` van aanvrager;  \
het KvK-nummer (Kamer van Koophandel) van de aanvrager (klant) van de aanvraag.  \
Het KvK-Nummer van de klant kan geregistreerd worden in het relatiebeheer-systeem van het Kadaster (CRM). Zolang deze niet is geverifieerd en eventueel is geactualiseerd, moet er een mogelijkheid komen om deze per aanvraag op te geven.

- `KvkNummer` van opdrachtgever;  \
het KvK-nummer (Kamer van Koophandel) van de opdrachtgever voor de aanvraag.  \
Dit KvK-nummer van organisaties is niet bekend bij het Kadaster. Er moet een mogelijkheid komen om deze bij een graafmelding op te geven.

- `VoorbereidingMedegebruikFysiekeInfrastructuur`;  \
een specifiek orientatieverzoek ter voorbereiding op een verzoek tot medegebruik van fysieke infrastructuur. Deze mogelijkheid moet worden geboden in het kader van EU-stimulering breedband (nieuwe WIBON-regelgeving).

- `VoorbereidingCoordinatieCivieleWerken`;  \
een specifiek orientatieverzoek ter voorbereiding op een verzoek tot coördinatie van civiele werken. Deze mogelijkheid moet worden geboden in het kader van EU-stimulering breedband (nieuwe WIBON-regelgeving).

- `IdentificatieBAG` van een dichtstbijzijnd adres (DAS);  \
de identificatie van het adresseerbare object van een dichtstbijzijnd adres.  \
Deze `IdentificatieBAG` is in BAG vastgelegd als identificatie van een adresseerbaar object (_Verblijfsobject_, _Ligplaats_ of _Standplaats_).  \
De identificatie is leidend voor de verwerking van een Klic-aanvraag.  \
Als er van een dichtstbijzijnd adres een `IdentificatieBAG` wordt meegegeven, hoeven geen overige adresgegevens te worden meegegeven. Het eventueel meegegeven adres moet het hoofdadres zijn van het adresseerbare object en overeenstemmen met de adresgegevens zoals deze in BAG zijn vastgelegd.
Is er geen `IdentificatieBAG` meegegeven, dan moeten minimaal een `huisnummer` en `postcode` worden meegegeven voor de bepaling van een geldig dichtsbijzijnd adres.

- `IdentificatieBAG` van een huisaansluitschets-adres (HAS);  \
de identificatie van het adresseerbare object van een adres waarvoor een huisaansluitschets wordt gevraagd.  \
Ook deze `IdentificatieBAG` is in BAG vastgelegd als identificatie van een adresseerbaar object (_Verblijfsobject_, _Ligplaats_ of _Standplaats_).  \
De identificatie is leidend voor de verwerking van een Klic-aanvraag.  \
Als er van een huisaansluitschets-adres een `IdentificatieBAG` wordt meegegeven, hoeven geen overige adresgegevens te worden meegegeven. Het eventueel meegegeven adres moet het hoofdadres zijn van het adresseerbare object en overeenstemmen met de adresgegevens zoals deze in BAG zijn vastgelegd.
Is er geen `IdentificatieBAG` meegegeven, dan moeten minimaal een `huisnummer` en `postcode` worden meegegeven voor de bepaling van een geldig dichtsbijzijnd adres.

- `Informatiepolygoon`;  \
de geometrie van het gebied (een polygoon) waarover informatie gevraagd wordt.  \
Voor een graafmelding en een calamiteitenmelding moet er een mogelijkheid worden geboden om rond het graafgebied een ruimer gebied aan te geven waarover informatie wordt gewenst.  \
Een opgegeven informatiegebied moet een graafgebied volledig omvatten: niets van de graafpolygoon mag buiten de informatiepolygoon liggen.

## Implementatie

Er is voor gekozen om één wijziging alle attributen die in de nabije toekomst gebruikt moeten kunnen worden, op te nemen in een nieuwe versie van het interface (versie 1.1).  \
Alle nieuwe attributen zijn (nu nog) optioneel, zodat een gebruikersapplicatie nog niet hoeft te worden aangepast als de nieuwe versie wordt uitgerold. Deze versie is daarmee backwards compatible.

In eerste instantie controleren we alleen of het gebruik van de nieuwe attributen valide is, en geen verstoring geeft op de verwerking in KLIC.

Vervolgens zal de functionaliteit voor het gebruik van de nieuwe attributen gefaseerd worden uitgerold.  \
Deze fasering ziet er voorlopig als volgt uit:

1. Het gebruik van `IdentificatieBAG` voor een dichtstbijzijnd adres (DAS) en een huisaansluitschets-adres (HAS).
2. Het gebruik van opties voor het aanvragen van een orientatieverzoek in het kader van de EU-stimulering breedband (`VoorbereidingMedegebruikFysiekeInfrastructuur` en `VoorbereidingCoordinatieCivieleWerken`).
3. Het vastleggen en gebruiken van een `KvkNummer` bij een aanvrager en opdrachtgever.
4. Het vastleggen en gebruiken van `Informatiepolygoon` bij een graafmelding of calamiteitenmelding.

Voor een overzicht van de geplande en gerealiseerde implementaties van deze functionaliteit, zie:
* [KLIC - Geplande werkzaamheden](../KLIC%20-%20Geplande%20werkzaamheden.md) 
* [KLIC - Release notes](../KLIC%20-%20Release%20notes.md) 


