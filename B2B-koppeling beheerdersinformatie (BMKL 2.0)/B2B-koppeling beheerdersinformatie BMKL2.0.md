# B2B-koppeling BMKL 2.0

Dit document biedt een handleiding voor het als decentrale netbeheerder aanleveren van beheerdersinformatie via de B2B-koppeling volgens BMKL 2.0. \
Ook worden de services beschreven waarvan een centrale netbeheerder gebruik kan maken.

**Inhoudsopgave**

  - [Context](#context)
  - [Scope](#scope)
  - [Leeswijzer](#leeswijzer)
  - [Procesmodellen afhandelen beheerdersinformatie-aanvragen](#procesmodellen-afhandelen-beheerdersinformatie-aanvragen)
    - [Procesmodel BMKL 2.0 (decentrale netbeheerder)](#procesmodel-bmkl-20-decentrale-netbeheerder)
    - [Procesmodel BMKL 2.0 (centrale netbeheerder)](#procesmodel-bmkl-20-centrale-netbeheerder)
    - [Use casemodel BMKL 2.0](#puse-casemodel-bmkl-20)
  - [Afhandelen beheerdersinformatie-aanvragen (enkel decentraal)](#afhandelen-beheerdersinformatie-aanvragen-enkel-decentraal)
      - [Samenstellen zipbestand](#samenstellen-zipbestand)
      - [Beheerdersinformatie en documenten aanleveren (enkel decentraal)](#beheerdersinformatie-en-documenten-aanleveren-enkel-decentraal)
      - [Opvragen gegevens over aanleveringen (enkel decentraal)](#opvragen-gegevens-over-aanleveringen-enkel-decentraal)
  - [Gebruik BMKL API's](#gebruik-bmkl-apis)
      - [REST interfaces](#rest-interfaces)
      - [Endpoints](#endpoints)
      - [Authenticatie](#authenticatie)
      - [CURL](#curl)
      - [KLIC API Documentatie](#klic-api-documentatie)
  - [Overzicht BMKL API's voor afhandelen beheerdersinformatie-aanvragen](#overzicht-bmkl-apis-voor-afhandelen-beheerdersinformatie-aanvragen)
      - [Zoeken beheerdersinformatie-aanvragen](#zoeken-beheerdersinformatie-aanvragen)
      - [Opvragen beheerdersinformatie-aanvraag](#opvragen-beheerdersinformatie-aanvraag)
      - [Opvragen gebiedsinformatie-aanvraag](#opvragen-gebiedsinformatie-aanvraag)
      - [Bevestigen beheerdersinformatie-aanvraag](#bevestigen-beheerdersinformatie-aanvraag)
      - [Aanleveren beheerdersinformatie (enkel decentraal)](#aanleveren-beheerdersinformatie-enkel-decentraal)
      - [Opvragen aanleveringen beheerdersinformatie (enkel decentraal)](#opvragen-aanleveringen-beheerdersinformatie-enkel-decentraal)
      - [Opvragen uitgeleverde beheerdersinformatie](#opvragen-uitgeleverde-beheerdersinformatie)

---------------------------------------------------------
## Context
Voor het oriënteren, plannen en uitvoeren van graafwerkzaamheden in een bepaald gebied hebben
grondroerders informatie nodig over de locatie en aard van de in de grond aanwezige kabels en leidingen.
Deze informatie bevindt zich bij decentrale netbeheerders of in de centrale voorziening Kabels en Leidingen. \
Het systeem KLIC wordt opgezet als de centrale voorziening voor het ontsluiten van deze informatie. \
Grondroerders doen bij KLIC een aanvraag door het intekenen van een gebied waar men informatie over
nodig heeft. KLIC verzoekt en verkrijgt van de decentrale netbeheerders de informatie, die niet centraal
beschikbaar is, en combineert deze met de informatie van de centrale netbeheerders die in de centrale
voorziening Kabels en Leidingen aanwezig is.

Voor de integratie van informatie van verschillende partijen is het noodzakelijk dat er een gemeenschappelijk
begrippenkader bestaat. Het IMKL (Informatiemodel Kabels en Leidingen) beschrijft de wijze waarop de
gegevens over kabels en leidingen eenduidig kan worden vastgelegd.

De Web API die in dit document wordt gepresenteerd, beschrijft de wijze van communicatie tussen
netbeheerders en KLIC met uitzondering van het aanleveren van gegevens voor de centrale voorziening.
Het doel van deze Web API is om een uitbreidbare, betrouwbare en makkelijk te gebruiken interface te bieden
voor alle betrokkenen.

---------------------------------------------------------
## Scope
Dit document beschrijft de Web API voor centrale en decentrale netbeheerders van het systeem KLIC.
De API betreft de uitwisseling van informatie over de gebiedsinformatie-aanvragen en de uitwisseling van
beheerdersinformatie. \
Het document beschrijft niet de levering van kabel- en leidinginformatie aan de centrale voorziening door
centrale netbeheerders en ook niet de uitwisseling van informatie met gebruikers van de uitgewisselde
informatie in de context van KLIC of INSPIRE. \
Dit document geeft een technische beschrijving van de Web API, maar bevat geen procedurele afspraken
zoals wettelijke termijnen waarbinnen gereageerd moet worden.

Voor de beschrijving van functionaliteit die in het portaal van de Netbeheerder Testdienst (NTD) worden aangeboden, wordt verwezen naar [Netbeheerder Testdienst (NTD](Netbeheerder Testdienst (NTD).md). \
Hierin wordt ook beschreven hoe een testmelding kan worden opgevoerd. \
Ook wordt daar in algemene termen beschreven hoe technische documentatie over de API's kan worden ingezien en de werking van API's kan worden getest.

---------------------------------------------------------

## Leeswijzer

In de sectie [Procesmodellen afhandelen beheerdersinformatie-aanvragen](#procesmodellen-afhandelen-beheerdersinformatie-aanvragen) wordt een schematisch overzicht gegeven van het procesverloop bij het afhandelen van een beheerdersinformatie-aanvraag. \
Hierbij wordt onderscheid gemaakt tussen een decentrale en centrale netbeheerder. Een decentrale netbeheerder zal zelf zijn beheerdersinformatie moeten samenstellen en aanleveren aan KLIC.

De sectie [Afhandelen beheerdersinformatie-aanvragen (enkel decentraal)](#afhandelen-beheerdersinformatie-aanvragen-enkel-decentraal) beschrijft het proces
van het aanleveren van beheerdersinformatie en bijbehorende documenten door de decentrale netbeheerder. Alle bestanden worden verpakt in één zipbestand.

Om dit zipbestand aan te kunnen leveren, moet er eerst een testmelding worden opgevoerd met _"Opvoeren testmelding - BMKL 2.0 decentraal"_ (zie [Netbeheerder Testdienst (NTD](Netbeheerder Testdienst (NTD).md)). Daarmee wordt er een gebiedsinformatie-aanvraag aangemaakt
waarvoor beheerdersinformatie en de bijbehorende documenten aangeleverd kunnen worden.

De sectie [Overzicht BMKL API's voor afhandelen beheerdersinformatie-aanvragen](#overzicht-bmkl-apis-voor-afhandelen-beheerdersinformatie-aanvragen) beschrijft de verschillende componenten van de API. \
Voor een decentrale kunnen achtereenvolgens de volgende secties doorlopen worden:

- [Zoeken beheerdersinformatie-aanvragen](#zoeken-beheerdersinformatie-aanvragen)
- [Opvragen gebiedsinformatie-aanvraag](#opvragen-gebiedsinformatie-aanvraag)
- [Bevestigen beheerdersinformatie-aanvraag](#bevestigen-beheerdersinformatie-aanvraag)
- [Aanleveren beheerdersinformatie (enkel decentraal)](#aanleveren-beheerdersinformatie-enkel-decentraal)

- [Opvragen aanleveringen beheerdersinformatie (enkel decentraal)](#opvragen-aanleveringen-beheerdersinformatie-enkel-decentraal)
- [Opvragen uitgeleverde beheerdersinformatie](#opvragen-uitgeleverde-beheerdersinformatie)

De centrale netbeheerder actualiseert in de NTD-omgeving eerst (indien van toepassing) documenten, via de link "NTD Actualiseren documenten (b&egrave;ta-versie)"
en vervolgens netinformatie, via de link "NTD Actualiseren netinformatie (b&egrave;ta-versie)". \
Daarna kan ook de centrale netbeheerder een testmelding opvoeren met _"Opvoeren testmelding - BMKL 2.0 centraal"_.
De beheerdersinformatie en de bijbehorende documenten worden naar aanleiding van de gedane testmelding samengesteld door het Kadaster.

In de sectie [Gebruik BMKL API's](#gebruik-bmkl-apis) worden meer (technische) details aangereikt over het gebruik van API's en de beschikbare technische documentatie.

---------------------------------------------------------
## Procesmodellen afhandelen beheerdersinformatie-aanvragen

### Procesmodel BMKL 2.0 (decentrale netbeheerder)

![procesmodel](images/8.3.3.2-Produceren-volgens-BMKL2.0-decentraal.png "Procesmodel BMKL 2.0 (decentrale netbeheerder)")
_Figuur 1 Procesmodel BMKL 2.0 (decentrale netbeheerder)_

### Processtappen (decentrale netbeheerder)
Hieronder wordt een overzicht gegeven van typerende processtappen die in het BMKL2.0-koppelvlak (kunnen) worden gedaan bij het afhandelen van een beheerdersinformatie-aanvraag door een decentrale netbeheerder.

- Notificeren netbeheerder \
Een belanghebbende netbeheerder wordt door KLIC genotificeerd dat er een beheerdersinformatie-aanvraag voor hem klaar staat.
- Zoeken beheerderdersinformatie-aanvragen \
Haal als belanghebbende netbeheerder een lijst met beheerdersinformatie-aanvragen op die voldoen aan opgegeven criteria (bijv. `biNotificatieStatus`=biOpen). In een beheerdersinformatie-aanvraag wordt ook de identificatie van de bijbehorende gebiedsinformatie-aanvraag genoemd (`giAanvraagId`).
- Opvragen gebiedsinformatie-aanvraag \
Haal als netbeheerder de details van één gebiedsinformatie-aanvraag op, behorend bij een beheerdersinformatie-aanvraag die in behandeling wordt genomen.
- Bevestigen beheerdersinformatie-aanvraag \
Bevestig de beheerdersinformatie-aanvraag door deze te markeren als 'biBevestigingOntvangen'.
- Aanleveren beheerdersinformatie (alleen decentraal)\
Lever als belanghebbende netbeheerder het zipbestand met beheerdersinformatie aan voor de in behandeling genomen beheerdersinformatie-aanvraag.
- Opvragen aanlevering(en) beheerdersinformatie (alleen decentraal)\
Haal (ter controle) (meta)informatie op over eerdere aanleveringen van beheerdersinformatie voor een specifieke beheerdersinformatie-aanvraag.
- Opvragen beheerdersinformatie-aanvraag \
Haal de status van de beheerdersinformatie-aanvraag op; hiermee is inzichtelijk of de aanlevering al is verwerkt t.b.v. de uitlevering.
- Opvragen uitgeleverde beheerdersinformatie \
Haal als netbeheerder voor een specifieke beheerdersinformatie-aanvraag de beheerdersinformatie op, zoals deze wordt uitgeleverd naar de aanvrager (grondroerder).

### Procesmodel BMKL 2.0 (centrale netbeheerder)

![procesmodel](images/8.3.3.3-Produceren-volgens-BMKL2.0-centraal.png "Procesmodel BMKL 2.0 (centrale netbeheerder)")
_Figuur 2 Procesmodel BMKL 2.0 (centrale netbeheerder)_

### Processtappen (centrale netbeheerder)
Hieronder wordt een overzicht gegeven van typerende processtappen die in het BMKL2.0-koppelvlak (kunnen) worden gedaan bij het afhandelen van een beheerdersinformatie-aanvraag door een centrale netbeheerder. \
Het belangrijkste onderscheid ligt in het feit dat de beheerdersinformatie niet door de netbeheerder zelf, maar door de centrale voorziening van KLIC wordt opgesteld.

- Notificeren netbeheerder \
Een belanghebbende netbeheerder wordt door KLIC genotificeerd dat er een beheerdersinformatie-aanvraag voor hem klaar staat.
- Zoeken beheerderdersinformatie-aanvragen \
Haal als belanghebbende netbeheerder een lijst met beheerdersinformatie-aanvragen op die voldoen aan opgegeven criteria (bijv. `biNotificatieStatus`=biOpen). In een beheerdersinformatie-aanvraag wordt ook de identificatie van de bijbehorende gebiedsinformatie-aanvraag genoemd (`giAanvraagId`).
- Opvragen gebiedsinformatie-aanvraag \
Haal als netbeheerder de details van één gebiedsinformatie-aanvraag op, behorend bij een beheerdersinformatie-aanvraag die in behandeling wordt genomen.
- Bevestigen beheerdersinformatie-aanvraag \
Bevestig de beheerdersinformatie-aanvraag door deze te markeren als 'biBevestigingOntvangen'.
- Opvragen beheerdersinformatie-aanvraag \
Haal de status van de beheerdersinformatie-aanvraag op; hiermee is inzichtelijk of de aanlevering al is verwerkt t.b.v. de uitlevering.
- Opvragen uitgeleverde beheerdersinformatie \
Haal als netbeheerder voor een specifieke beheerdersinformatie-aanvraag de beheerdersinformatie op, zoals deze wordt uitgeleverd naar de aanvrager (grondroerder).

### Use casemodel BMKL 2.0
De verschillende processtappen zijn gemodelleerd in een use casemodel. Hiermee wordt een schematisch overzicht gegeven van de use cases die voor het BMKL 2.0 zijn geimplementeerd.

![usecasemodel](images/UC230-Uitwisselen-beheerdersinformatie-BMKL2.0.jpg "UC230 Uitwisselen beheerdersinformatie (BMKL2.0)")
_Figuur 3 UCM B2B-koppeling beheerdersinformatie (BMKL2.0)_

---------------------------------------------------------
## Afhandelen beheerdersinformatie-aanvragen (enkel decentraal)

### Samenstellen zipbestand
Zodra een belanghebbende netbeheerder de details kent van een gebiedsinformatie-aanvraag, kan de beheerdersinformatie worden samengesteld. \
Beheerdersinformatie en de bijbehorende documenten worden aangeleverd in een zipbestand door de decentrale netbeheerder. Dit bestand moet voldoen aan de volgende voorwaarden:

- Het zipbestand bevat exact één bestand met de extentie `.xml`. Dit bestand bevat de beheerdersinformatie in [IMKL 1.2 formaat](https://register.geostandaarden.nl/imkl2015/index.html).
- Het zipbestand mag één of meerdere PDF bestanden bevatten. Elk van deze bestanden moet gerefereerd worden vanuit het XML-bestand.
- Het zipbestand mag geen mappenstructuur bevatten; alle bestanden in het zipbestand moeten op het hoogste niveau in het zipbestand opgeslagen worden.

### Beheerdersinformatie en documenten aanleveren (enkel decentraal)
Het aanleveren van beheerdersinformatie gaat volgens de stappen, zoals genoemd in het procesmodel:

1. Het opvragen van openstaande beheerdersinformatie-aanvragen.
2. Het ophalen van de gebiedsinformatie-aanvraag bij een beheerdersinformatie-aanvraag waarvoor nog beheerdersinformatie moet worden aangeleverd.
3. Het bevestigen van deze beheerdersinformatie-aanvraag, door deze te markeren als 'biBevestigingOntvangen'
4. Het aanleveren van het zipbestand met beheerdersinformatie voor de bevestigde gebiedsinformatie-aanvraag

### Controleren of de aanlevering met beheerdersinformatie valide is (enkel decentraal)
Een aangeleverd zipbestand met beheerdersinformatie zal door KLIC in een aantal stappen worden gevalideerd. \
De netbeheerder kan de voortgang hiervan en de status opvragen. Als er fouten zijn geconstateerd, worden de betreffende foutmeldingen ook teruggegeven. \
Bij fouten in de aangeleverde beheerdersinformatie, zullen deze fouten door de netbeheerder moeten worden opgelost. Daarna kan een nieuwe aanlevering voor de betreffende beheerdersinformatie-aanvraag worden gedaan.

---------------------------------------------------------
## Gebruik BMKL API's

### REST interfaces
Voor het geautomatiseerd afhandelen van beheerdersinformatie-aanvragen heeft het Kadaster REST interfaces beschikbaar gesteld. \
De documentatie over de werking van deze interfaces is beschikbaar in de vorm van [Swagger](http://swagger.io) specificatie. Deze documentatie is te vinden bij de “KLIC API documentatie”-applicatie die in de Netbeheerder Testdienst beschikbaar wordt gesteld.

De applicatie biedt een overzicht van de endpoints van de verschillende API’s en hoe deze endpoints gebruikt kunnen worden. Voor de “Beheerdersinformatie” API zijn
de meeste endpoints meteen uit te proberen via de aangeboden interface. Uitzondering vormt het downloaden van de aangeleverde beheerdersinformatie. Deze zal via
een browser of via CURL moeten worden uitgevoerd, aangezien Swagger ZIP responses niet ondersteunt.

### Endpoints

De endpoints die gebruikt worden in dit document zijn relatief ten opzichte van de betreffende API’s. \
De service "/gebiedsinformatieAanvragen" wordt bijvoorbeeld voluit \
voor de productieomgeving KLIC:
        "https://service10.kadaster.nl/klic/api/v2/gebiedsinformatieAanvragen" \
voor de Netbeheerder Testdienst (NTD):
        "<https://service10.kadaster.nl/klic/ntd/leveren/api/v2/web/gebiedsinformatieAanvragen>". \
In de voorbeelden in deze documentatie wordt uitgegaan van de API's op de NTD-omgeving.

### Authenticatie
De KLIC REST API's zijn beveiligd middels de OAuth 2.0 specificatie. Zie daarvoor
 [Authenticatie via OAuth](../API%20management/Authenticatie_via_oauth.md).

### CURL

De “KLIC API Documentatie”-applicatie maakt het mogelijk om de meeste endpoints aan te roepen vanuit de browser.
In het voorbeeld in dit document wordt echter gebruik gemaakt van de command-line tool CURL (https://curl.haxx.se/). Dit heeft meer analogie met de werkwijze als een netbeheerder of serviceprovider een eigen applicatie wil ontwikkelen voor het decentraal aanleveren van beheerdersinformatie via de B2B-koppeling. \
De CURL commando's worden in dit document voor de leesbaarheid weergegeven op meerdere regels. Deze commando's dienen of als één enkele regel ingevoerd te worden, of de regels dienen afgesloten te worden met een '^' (Windows) of een '\\' (Unix).

### KLIC API Documentatie

De API Documentatie is beschikbaar via een Swagger-implementatie. Deze functionaliteit is opgenomen in het portaal van de [Netbeheerder Testdienst (NTD](Netbeheerder Testdienst (NTD).md).
Op onderstaande Swagger pagina worden de services voor het afhandelen van beheerdersinformatie-aanvargen weergegeven.

![mijnKadaster](images/KLIC-API-documentatie-BMKL20-detail.png "NTD Portaal - API Documentatie detail")

_Figuur 4 API Documentatie Beheerdersinformatie / BMKL 2.0 detail_

---------------------------------------------------------
## Overzicht BMKL API's voor afhandelen beheerdersinformatie-aanvragen ##

_De voorbeelden die hieronder zijn beschreven, gaan er vanuit dat er	&eacute;&eacute;n testmelding is gedaan. Er zal voor deze testmelding beheerdersinformatie worden aangeleverd._

### Use casemodel BMKL 2.0 (WebAPI)
De use cases voor het koppelvlak BMKL 2.0 zijn geimplementeerd als API's. Onderstaand overzicht geeft van de use cases de API-structuur.

![usecasemodel](images/UC230-Uitwisselen-beheerdersinformatie-BMKL2.0-WebAPI.jpg "UC230 Uitwisselen beheerdersinformatie (BMKL2.0) (WebAPI)")
_Figuur 5 UCM B2B-koppeling beheerdersinformatie (BMKL2.0, API-structuur)_

### Zoeken beheerdersinformatie-aanvragen

Het endpoint voor het opvragen van de lijst met beheerdersinformatie-aanvragen van de netbeheerder,
kan aangeroepen worden met of zonder `biAanvraagId`. De aanroep zonder `biAanvraagId` levert een lijst op en kan worden aangeroepen
met verschillende parameters om zo naar één specifieke, of een bepaalde set beheerdersinformatie-aanvragen te kunnen zoeken.
Het systeem haalt alle beheerdersinformatie-aanvragen op die voldoen aan de criteria en waarvoor de ingelogde gebruiker geautoriseerd is.

De pad-parameter `giAanvraagId` is verplicht maar mag `-` zijn. In dat geval wordt beheerdersinformatie gezocht over alle
beheerdersinformatie-aanvragen waar de netbeheerder belanghebbend bij is.

**_pad:_**
```sh
GET /gebiedsinformatieAanvragen/{giAanvraagId}/beheerdersinformatieAanvragen
```

**_benodigde scope:_**
```
klic.beheerdersinformatie
of
klic.beheerdersinformatie.readonly
```

**_voorbeeld: Zoeken openstaande beheerdersinformatie-aanvragen_**

In dit voorbeeld wordt gezocht naar alle beheerdersinformatie-aanvragen voor de ingelogde netbeheerder met de status "open". Hiervoor wordt de parameter `biNotificatieStatus` met de waarde `biOpen` toegevoegd aan het request.
```sh
curl
 -X GET --header "Authorization: Bearer 1d021976-91c8-4b46-ab9b-529088d0f3de"
 https://service10.kadaster.nl/klic/ntd/leveren/api/v2/web/gebiedsinformatieAanvragen/-/beheerdersinformatieAanvragen?biNotificatieStatus=biOpen
```

**_response_**
```json
[ {
    "biAanvraagId" : "330d0526-0586-4843-ad86-04d8969fc768",
    "giAanvraagId" : "4c8353bd-3907-40ee-84b0-5f54ac38d4d1",
    "bronhoudercode" : "nbact2",
    "biNotificatieStatus" : "https://api.kadaster.nl/klic/v2/waarde/biNotificatieStatussen/biOpen",
    "biProductieStatus" : "https://api.kadaster.nl/klic/v2/waarde/biProductieStatussen/biWachtOpAntwoord",
    "datumGenotificeerd" : "2017-11-03T10:38:44+01:00",
    "mutatieDatum":"2017-11-03T10:38:44+01:00"
  },{
    "biAanvraagId" : "130k5426-0586-4843-ad86-04d89623fd28",
    "giAanvraagId" : "8dc933bd-3907-40ee-84b0-5f54ah37a4d1",
    "bronhoudercode" : "nbact2",
    "biNotificatieStatus" : "https://api.kadaster.nl/klic/v2/waarde/biNotificatieStatussen/biBevestigingOntvangen",
    "biProductieStatus" : "https://api.kadaster.nl/klic/v2/waarde/biProductieStatussen/biWachtOpAntwoord",
    "datumGenotificeerd" : "2017-11-03T10:43:25+01:00",
    "datumBevestigingOntvangen" : "2017-11-03T10:55:36+01:00",
    "mutatieDatum":"2017-11-03T10:55:36+01:00"
} ]
```

### Opvragen beheerdersinformatie-aanvraag
Het endpoint voor het opvragen van één specifieke beheerdersinformatie-aanvraag.
De status van de beheerdersinformatie-aanvraag maakt o.a. inzichtelijk of de aangeleverde beheerdersinformatie al is verwerkt t.b.v. de uitlevering.

De aanroep met `biAanvraagId` levert slechts 1 resultaat op, of een status `404` indien niet gevonden.
De pad-parameter `giAanvraagId` is verplicht en behoort bij de identificatie van de beheerdersinformatie-aanvraag.

**_pad:_**
```sh
GET /gebiedsinformatieAanvragen/{giAanvraagId}/beheerdersinformatieAanvragen/{biAanvraagId}
```

**_benodigde scope:_**
```
klic.beheerdersinformatie
of
klic.beheerdersinformatie.readonly
```

**_voorbeeld: Opvragen één specifieke beheerdersinformatie-aanvraag_**
```sh
curl
 -X GET --header "Authorization: Bearer 1d021976-91c8-4b46-ab9b-529088d0f3de"
 https://service10.kadaster.nl/klic/ntd/leveren/api/v2/web/gebiedsinformatieAanvragen/4c8353bd-3907-40ee-84b0-5f54ac38d4d1/beheerdersinformatieAanvragen/330d0526-0586-4843-ad86-04d8969fc768
```

**_response_**
```json
{
    "biAanvraagId" : "330d0526-0586-4843-ad86-04d8969fc768",
    "giAanvraagId" : "4c8353bd-3907-40ee-84b0-5f54ac38d4d1",
    "bronhoudercode" : "nbact2",
    "biNotificatieStatus" : "https://api.kadaster.nl/klic/v2/waarde/biNotificatieStatussen/biBevestigingOntvangen",
    "biProductieStatus" : "https://api.kadaster.nl/klic/v2/waarde/biProductieStatussen/biGereedVoorSamenstellenProduct",
    "datumGenotificeerd" : "2017-11-03T10:38:44+01:00",
    "datumBevestigingOntvangen" : "2017-11-03T11:05:31+01:00",
    "mutatieDatum":"2017-11-03T11:05:31+01:00"
}
```

### Opvragen gebiedsinformatie-aanvraag

Het endpoint voor het opvragen van gebiedsinformatie-aanvraag waar de betreffende netbeheerder belanghebbend bij is,
kan worden aangeroepen door een `giAanvraagId` mee te geven.

De aanroep met `giAanvraagId` levert slechts 1 resultaat op, of een status `404` indien niet gevonden.

Het zoeken van gebiedsinformatie-aanvragen op basis van selectiecriteria is voor de netbeheerder niet beschikbaar gesteld.

**_pad:_**
```
GET /gebiedsinformatieAanvragen/{giAanvraagId}
```

**_benodigde scope:_**
```
klic.gebiedsinformatieaanvraag.readonly
```

**_voorbeeld: Ophalen één specifieke gebiedsinformatie-aanvraag_**
```sh
curl
 -X GET --header "Authorization: Bearer 1d021976-91c8-4b46-ab9b-529088d0f3de"
  https://service10.kadaster.nl/klic/ntd/leveren/api/v2/web/gebiedsinformatieAanvragen/4c8353bd-3907-40ee-84b0-5f54ac38d4d1
```

**Voorbeeld van response**
```json
{
    "giAanvraagId" : "4c8353bd-3907-40ee-84b0-5f54ac38d4d1",
    "ordernummer" : "2015000924",
    "klicMeldnummer" : "17G000649",
    "aanvrager":{
        "contact":{
            "naam":"Aanvrager01",
            "telefoon":"0881235648",
            "email":"klicwin@kadaster.nl"
        },
        "organisatie":{
            "naam":"Netbeheerder Actualiseren02",
            "bezoekAdres":{
                "openbareRuimteNaam":"Laan van Westenenk",
                "huisnummer":"701",
                "postcode":"7334DP",
                "woonplaatsNaam":"Apeldoorn"
            },
        },
    },
    "opdrachtgever":{
        "contact":{
            "naam":"Kadaster",
            "telefoon":"(088) 183 20 00",
            "email":"noreply@kadaster.nl"
        },
        "organisatie":{
            "naam":"Kadaster",
            "bezoekAdres":{
                "openbareRuimteNaam":"Hofstraat",
                "huisnummer":"110",
                "postcode":"7311KZ",
                "woonplaatsNaam":"Apeldoorn"
            },
        },
    },
    "aanvraagSoort":"http://definities.geostandaarden.nl/imkl2015/id/waarde/AanvraagSoortValue/graafmelding",
    "aanvraagDatum":"2017-11-03T10:38:14+01",
    "mutatieDatum":"2017-11-03T10:38:14+01",
    "giAanvraagStatus" : "https://api.kadaster.nl/klic/v2/waarde/giAanvraagStatussen/giOpen",
    "soortWerkzaamheden":[
        "http://definities.geostandaarden.nl/imkl2015/id/waarde/SoortWerkzaamhedenValue/leggenLaagspanning",
        "http://definities.geostandaarden.nl/imkl2015/id/waarde/SoortWerkzaamhedenValue/woningbouw"
    ],
    "locatieWerkzaamheden":{
        "openbareRuimteNaam":"Laan van Westenenk",
        "huisnummer":"701",
        "postcode":"7334DP",
        "woonplaatsNaam":"Apeldoorn",
        "BAGidAdresseerbaarObject": "0200010000130331"
    },
    "startDatum" : "2017-11-13",
    "eindDatum" : "2017-11-22",
    "graafpolygoon":{
        "type":"Polygon",
        "crs":{
            "type":"name",
            "properties":{
                "name":"EPSG:28992"
            }
        },
        "coordinates":[ [ [ 153606.0, 391101.0 ], [ 153594.0, 391095.0 ], [ 153602.0, 391080.0 ], [ 153622.0, 391094.0 ], [ 153606.0, 391101.0 ] ] ]
    },
    "huisaansluitingAdressen":[{
       "openbareRuimteNaam":"Laan van Westenenk",
       "postcode":"7334DP",
       "huisnummer":"701",
       "woonplaatsNaam":"Apeldoorn",
       "BAGidAdresseerbaarObject": "0200010000130331"
    }, {
       "openbareRuimteNaam":"Evert van 't Landstraat",
       "postcode":"7334DR",
       "huisnummer":"15",
       "woonplaatsNaam":"Apeldoorn",
       "BAGidAdresseerbaarObject": "0200010003923183"
    }]
}
```

### Bevestigen beheerdersinformatie-aanvraag

Voordat een (decentrale) netbeheerder beheerdersinformatie kan aanleveren voor een beheerdersinformatie-aanvraag, moet de netbeheerder eerst bevestigen dat hij de beheerdersinformatie-aanvraag ontvangen heeft. \
Dat wordt gedaan door de `biNotificatieStatus` de waarde `biBevestigingOntvangen` te geven.

Ook voor de centrale netbeheerder wordt aanbevolen om de beheerdersinformatieaanvraag te bevestigen. \
Als een centrale netbeheerder geen ontvangstbevestiging stuurt op een aanvraag, dan blijft deze de status 'open' houden. Het Kadaster zal - ongeacht de notificatiestatus - beheerdersinformatie namens de centrale netbeheerder produceren en uitleveren.

**_pad:_**
```
PATCH /gebiedsinformatieAanvragen/{giAanvraagId}/beheerdersinformatieAanvragen/{biAanvraagId}
```

**_benodigde scope:_**
```
klic.beheerdersinformatie
of
klic.beheerdersinformatie.readonly
```

**_voorbeeld:_**
```sh
curl
 -X PATCH --header 'Authorization: Bearer 1d021976-91c8-4b46-ab9b-529088d0f3de'
 -d "{  \"biNotificatieStatus\": \"biBevestigingOntvangen\" }"
 https://service10.kadaster.nl/klic/ntd/leveren/api/v2/web/gebiedsinformatieAanvragen/4c8353bd-3907-40ee-84b0-5f54ac38d4d1/beheerdersinformatieAanvragen/330d0526-0586-4843-ad86-04d8969fc768
```

**_response:_**
```json
HTTP/1.1 200 OK
```

### Aanleveren beheerdersinformatie (enkel decentraal)

Als de decentrale netbeheerder heeft bevestigd dat de beheerdersinformatie-aanvraag ontvangen is, kan de beheerdersinformatie worden aangeleverd. In onderstaand voorbeeld wordt een POST request gedaan,
waarbij de beheerdersinformatie in de vorm van een zipbestand wordt aangeleverd.

**_pad:_**
```
POST /gebiedsinformatieAanvragen/{giAanvraagId}/beheerdersinformatieAanvragen/{biAanvraagId}/aanleveringen
```

**_benodigde scope:_**
```
klic.beheerdersinformatie
```


**_voorbeeld:_**
```sh
curl
 -X POST --header 'Authorization: Bearer 1d021976-91c8-4b46-ab9b-529088d0f3de'
 -F "netinformatie=@C:/Aanleveringen/Decentraal/nbact1/BMKL20_DECENTRAAL.zip"
 https://service10.kadaster.nl/klic/ntd/leveren/api/v2/web/gebiedsinformatieAanvragen/4c8353bd-3907-40ee-84b0-5f54ac38d4d1/beheerdersinformatieAanvragen/330d0526-0586-4843-ad86-04d8969fc768/aanleveringen
```

**_response:_**
```JSON
HTTP/1.1 200 OK
```
Wanneer de ontvangst van de beheerdersinformatie-aanvraag nog niet is bevestigd, wordt onderstaande melding teruggegeven. De beheerdersinformatie-aanvraag moet dus eerst
bevestigd ('biBevestigingOntvangen') zijn, alvorens er beheerdersinformatie kan worden aangeleverd.

**_response:_**
```JSON
{
  "status" : 405,
  "meldingCode" : 1000405,
  "gebruikerMelding" : "methode niet toegestaan",
  "ontwikkelaarMelding" : "de gebiedsinformatie-aanvraag is nog niet bevestigd",
  "meerInformatie" : "http://developer.klic.nl/foutCode/1000405"
}
```

### Opvragen aanleveringen beheerdersinformatie (enkel decentraal)
Wanneer een decentrale netbeheerder beheerdersinformatie heeft aangeleverd, kan deze de gegevens opvragen over de betreffende aanlevering.
Deze informatie bevat de status van de aanlevering en gegevens over de verwerking en validatie ervan. Dit gaat met een GET request naar hetzelfde
endpoint als waar de beheerdersinformatie met een POST naar toe is gestuurd.

**_pad:_**
```
GET /gebiedsinformatieAanvragen/{giAanvraagId}/beheerdersinformatieAanvragen/{biAanvraagId}/aanleveringen
```

**_benodigde scope:_**
```
klic.beheerdersinformatie
```

**_voorbeeld:_**
```sh
curl
 -X GET --header 'Authorization: Bearer 1d021976-91c8-4b46-ab9b-529088d0f3de'
 https://service10.kadaster.nl/klic/ntd/leveren/api/v2/web/gebiedsinformatieAanvragen/4c8353bd-3907-40ee-84b0-5f54ac38d4d1/beheerdersinformatieAanvragen/330d0526-0586-4843-ad86-04d8969fc768/aanleveringen
```

**_voorbeeld van response:_**
```json
[{
  "aanleveringId" : "3950e2eb-8942-4e6b-99ff-f4f06c5824db",
  "bronhoudercode" : "nbact2",
  "bronhouderNaam" : "Netbeheerder Actualiseren02",
  "informatieSoort" : "beheerdersinformatie",
  "bestandsnaam" : "nbact2_met documenten.zip",
  "bestandsgrootte" : 40955,
  "aanleverNummer" : 15,
  "aanleverDatum" : "2017-11-03T16:23:53.459+01",
  "aanleverStatus" : "https://api.kadaster.nl/klic/v2/waarde/aanleverStatussen/biGevalideerdZonderFouten",
  "aanleverStatusMutatieDatum" : "2017-11-03T16:23:56.829+01",
  "aanleverStatusHistorie" : [ {
    "mutatieDatum" : "2017-11-03T16:23:56.829+01",
    "aanleverStatus" : "https://api.kadaster.nl/klic/v2/waarde/aanleverStatussen/biGevalideerdZonderFouten"
  }, {
    "mutatieDatum" : "2017-11-03T16:23:55.744+01",
    "aanleverStatus" : "https://api.kadaster.nl/klic/v2/waarde/aanleverStatussen/biWordtGevalideerd"
  }, {
    "mutatieDatum" : "2017-11-03T16:23:54.231+01",
    "aanleverStatus" : "https://api.kadaster.nl/klic/v2/waarde/aanleverStatussen/biAangeleverd"
  }, {
    "mutatieDatum" : "2017-11-03T16:23:53.470+01",
    "aanleverStatus" : "https://api.kadaster.nl/klic/v2/waarde/aanleverStatussen/biGestart"
  }],
  "aanleverStappen" : [{
    "aanleverStapAanduiding" : "https://api.kadaster.nl/klic/v2/waarde/aanleverStapAanduidingen/biAanleveren",
    "startDatum" : "2017-11-03T16:23:53.465+01",
    "eindDatum" : "2017-11-03T16:23:54.236+01",
    "stapStatus" : "succes",
    "gebruiker" : "jvanklaveren"
  }, {
    "aanleverStapAanduiding" : "https://api.kadaster.nl/klic/v2/waarde/aanleverStapAanduidingen/biValideren",
    "startDatum" : "2017-11-03T16:23:55.734",
    "eindDatum" : "2017-11-03T16:23:56.832",
    "stapStatus" : "succes",
    "gebruiker" : "system"
  }]
}]
```

### Opvragen uitgeleverde beheerdersinformatie

Nadat de beheerdersinformatie is samengesteld ten behoeve van een uitlevering, kan de netbeheerder opvragen welke informatie door KLIC namens de netbeheerder wordt uitgeleverd.
De beheerdersinformatie-uitlevering wordt als zipbestand teruggegeven.

**_pad:_**
```
GET /gebiedsinformatieAanvragen/{giAanvraagId}/beheerdersinformatieAanvragen/{biAanvraagId}/beheerdersinformatieLevering/zip
```

**_benodigde scope:_**
```
klic.beheerdersinformatie
of
klic.beheerdersinformatie.readonly
```

**_voorbeeld:_**
```sh
curl
 -X GET --header 'Authorization: Bearer 1d021976-91c8-4b46-ab9b-529088d0f3de'
 https://service10.kadaster.nl/klic/ntd/leveren/api/v2/web/gebiedsinformatieAanvragen/4c8353bd-3907-40ee-84b0-5f54ac38d4d1/beheerdersinformatieAanvragen/330d0526-0586-4843-ad86-04d8969fc768/beheerdersinformatieLevering/zip
 > download.zip
```

**_response:_**

Deze aanroep levert een zipbestand op met daarin de beheerdersinformatie zoals die naar de aanvrager wordt uitgeleverd. Dit zijn alleen gegevens van de netbeheerder die bij de meegegeven `biAanvraagId` horen. Het is dus een uitsnede van de volledige uitlevering zoals die naar de aanvrager gaat.
