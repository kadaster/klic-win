# API-documentatie en versiebeheer

De uitwisseling van informatie tussen KLIC en andere partijen in de graafketen verloopt steeds meer met behulp van API's.

Dit document beschrijft hoe het Kadaster-KLIC met het documenteren en beheren van API-versies om gaat.


## Inhoudsopgave

- [API-documentatie en versiebeheer](#api-documentatie-en-versiebeheer)
    - [Inhoudsopgave](#inhoudsopgave)
    - [Documentatie](#documentatie)
    - [Versiebeheer](#versiebeheer)
        - [Versionering](#versionering)
        - [Uitfaseren van een major API-versie](#uitfaseren-van-een-major-api-versie)

## Documentatie

De documentatie moet gemakkelijk te vinden, te doorzoeken en publiekelijk toegankelijk zijn. De ontwikkelaars moeten eerst de documenten doornemen voordat ze starten met de implementatie. 

- _**Documentatie is gebaseerd op OAS 2.0 of hoger**_  \
Specificaties (documentatie) is beschikbaar als Open API Specification (OAS) V2.0 of hoger.

- _**Documentatie is in het Nederlands**_  \
De voertaal voor de API’s is Nederlands.  \
De documentatie dient voorzien te zijn van voorbeelden inclusief complete request en response-cycli.

- _**Documentatie wordt getest en geaccepteerd**_  \
De dienst KLIC biedt de mogelijkheid om direct vanuit de documentatie de API te testen (API-requests uit te voeren). Dit wordt eerst getest.


## Versiebeheer

### Versionering
API’s zijn altijd geversioneerd. Versioneren zorgt voor een soepele overgang bij wijzigingen.

De oude (backwards compatible) en nieuwe versies worden voor een beperkte overgangsperiode aangeboden.  \
Het wijzigen van een API zal conform het “Wijzigingsproces KLIC standaarden” verlopen.  \
Er worden bovendien maximaal 2 versies van een API ondersteund.

Afnemers kiezen zelf het moment dat ze overschakelen van de oude naar de nieuwe versie van een API, als ze het maar voor het einde van de overgangsperiode is. 

- _**De overgangsperiode bij een nieuwe API versie is bij voorkeur 6 maanden**_  \
Oude en nieuwe versies (max. 2) van een API worden voor een beperkte overgangsperiode naast elkaar aangeboden.

Alleen het major versienummer wordt in de URI opgenomen. Hierdoor is het mogelijk om verschillende versies van een API via de browser te verkennen. 

_Voorbeeld:_
```
https://.../klic/api/v2/gebiedsinformatieAanvragen/4c8353bd-3907-40ee-5f54ac38d4d1
```
_vraagt via API v2 gebiedsinformatieAanvraag #4c8353bd-3907-40ee-5f54ac38d4d1 op._

Het versienummer begint voor KLIC bij 2 (v2) en wordt met 1 opgehoogd voor elke major release waarbij het koppelvlak niet backward compatible wijzigt.

De minor en patch versienummers staan in de header van het bericht zelf in het formaat “major.minor.patch”.  \
Het toevoegen van een end-point of een niet verplichte attribuut aan de payload zijn voorbeelden van wijzigingen die backward compatible zijn.

- _**Alleen het major versienummer is onderdeel van de URI**_  \
In de URI wordt alleen het major versienummer opgenomen. 

Een API is aan veranderingen onderhevig. Het is belangrijk hoe met deze verandering wordt omgegaan. Goed gedocumenteerde en tijdig gecommuniceerde uitfaseringsplanningen zijn in het algemeen voor veel API-gebruikers werkbaar.

### Uitfaseren van een major API-versie

Major releases van API's zijn altijd backward incompatible.
Immers, als een nieuwe release van de API niet tot backward incompatibiliteit leidt, is er geen reden om een hele versie omhoog te gaan en spreken we van een minor release. 

Op het moment dat er een major release plaatsvindt, is het de bedoeling dat alle (potentiële) clients deze nieuwe versie implementeren.
Omdat we geen clients willen breken, kunnen we niet op één moment overschakelen van de oude naar de nieuwe versie, zoals dat bijvoorbeeld bij een update van een website wel vaak gebeurt.  \
Daarom is het noodzakelijk om na de livegang van de nieuwe versie óók de oude versie in de lucht te houden.

Omdat we de oude versie niet tot in de eeuwigheid willen blijven onderhouden en juist iedereen
willen stimuleren om de nieuwe versie te gaan gebruiken, communiceren we een periode waarin
clients de gelegenheid krijgen om hun code aan te passen aan de nieuwe versie.  \
Deze periode noemen we de deprecation periode. De lengte van deze periode kan verschillen per API, vaak is dit
zes maanden, maar niet meer dan één jaar. 

De volgende zaken moeten gecommuniceerd worden:

- Een link naar de (documentatie van de) nieuwe versie van de API;
- Deprecation periode met exacte datum waarop de deprecated versie offline wordt gehaald;
- Migratieplan om eenvoudig over te stappen naar de nieuwe versie;
- Welke features er toegevoegd, gewijzigd of verwijderd worden;
- Welke wijzigingen de huidige implementaties kunnen breken;

Deze zaken dienen gecommuniceerd te worden via de volgende kanalen:

- Per e-mail van de clients;
- Duidelijk leesbaar in de API documentatie van de oude versie;
