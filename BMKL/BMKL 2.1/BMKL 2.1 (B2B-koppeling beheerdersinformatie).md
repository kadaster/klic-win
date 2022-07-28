# B2B-koppeling BMKL 2.1

Dit document biedt een handleiding voor het als decentrale netbeheerder aanleveren van beheerdersinformatie via de B2B-koppeling volgens BMKL 2.0. \
Ook worden de services beschreven waarvan een centrale netbeheerder gebruik kan maken.

**Inhoudsopgave**

  - [Context](#context)
  - [Scope](#scope)
  - [Leeswijzer](#leeswijzer)
  - [Procesmodellen afhandelen beheerdersinformatie-aanvragen](#procesmodellen-afhandelen-beheerdersinformatie-aanvragen)
    - [Procesmodel BMKL (decentrale netbeheerder)](#procesmodel-bmkl-decentrale-netbeheerder)
    - [Procesmodel BMKL (centrale netbeheerder)](#procesmodel-bmkl-centrale-netbeheerder)
  - [Afhandelen beheerdersinformatie-aanvragen (enkel decentraal)](#afhandelen-beheerdersinformatie-aanvragen-enkel-decentraal)
      - [Samenstellen zipbestand](#samenstellen-zipbestand)
      - [Beheerdersinformatie en documenten aanleveren (enkel decentraal)](#beheerdersinformatie-en-documenten-aanleveren-enkel-decentraal)
      - [Controleren of de aanlevering met beheerdersinformatie valide is (enkel decentraal)](#controleren-of-de-aanlevering-met-beheerdersinformatie-valide-is-enkel-decentraal)
  - [Gebruik BMKL API's](#gebruik-bmkl-apis)
      - [REST interfaces](#rest-interfaces)
      - [Endpoints](#endpoints)
      - [Authenticatie](#authenticatie)
      - [_Accept_ header](#accept-header)
      - [Pagineren](#pagineren)
      - [CURL](#curl)
      - [KLIC API Documentatie](#klic-api-documentatie)
      - [Gebruik van URL-parameters bij de API's](#gebruik-van-url-parameters-bij-de-apis)
  - [Overzicht BMKL API's voor afhandelen beheerdersinformatie-aanvragen](#overzicht-bmkl-apis-voor-afhandelen-beheerdersinformatie-aanvragen)
      - [Zoeken beheerdersinformatie-aanvragen](#zoeken-beheerdersinformatie-aanvragen)
      - [Opvragen beheerdersinformatie-aanvraag](#opvragen-beheerdersinformatie-aanvraag)
      - [Opvragen gebiedsinformatie-aanvraag](#opvragen-gebiedsinformatie-aanvraag)
      - [Bevestigen beheerdersinformatie-aanvraag](#bevestigen-beheerdersinformatie-aanvraag)
      - [Aanleveren beheerdersinformatie (enkel decentraal)](#aanleveren-beheerdersinformatie-enkel-decentraal)
      - [Opvragen aanleveringen beheerdersinformatie (enkel decentraal)](#opvragen-aanleveringen-beheerdersinformatie-enkel-decentraal)
      - [Opvragen uitgeleverde beheerdersinformatie](#opvragen-uitgeleverde-beheerdersinformatie)
  - [Overzicht BMKL API's voor afhandelen afwijkende situatie](#overzicht-bmkl-apis-voor-afhandelen-afwijkende-situatie)
      - [Zoeken terugmeldingen](#zoeken-terugmeldingen)
      - [Bevestigen terugmelding](#bevestigen-terugmelding)
      - [Afwijzen terugmelding](#afwijzen-terugmelding)
      - [Claimen terugmeling](#claimen-terugmelding)

---------------------------------------------------------
## Context
Voor het oriënteren, plannen en uitvoeren van graafwerkzaamheden in een bepaald gebied hebben
grondroerders informatie nodig over de locatie en aard van de in de grond aanwezige kabels en leidingen.
Deze informatie bevindt zich bij decentrale netbeheerders of in de centrale voorziening Kabels en Leidingen. \
Het systeem KLIC is opgezet als centraal systeem voor het ontsluiten van deze informatie. \
Grondroerders doen bij KLIC een aanvraag door het intekenen van een gebied waar men informatie over nodig heeft. KLIC verzoekt en verkrijgt van de decentrale netbeheerders de informatie, die niet centraal beschikbaar is, en combineert deze met de informatie van de centrale netbeheerders die in de centrale voorziening Kabels en Leidingen aanwezig is.

Voor de integratie van informatie van verschillende partijen is het noodzakelijk dat er een gemeenschappelijk begrippenkader bestaat. Het IMKL (Informatiemodel Kabels en Leidingen) beschrijft de wijze waarop de gegevens over kabels en leidingen eenduidig kan worden vastgelegd.

De Web API die in dit document wordt gepresenteerd, beschrijft de wijze van communicatie tussen netbeheerders en KLIC met uitzondering van het aanleveren van gegevens voor de centrale voorziening.
Het doel van deze Web API is om een uitbreidbare, betrouwbare en makkelijk te gebruiken interface te bieden voor alle betrokkenen.

---------------------------------------------------------
## Scope
Dit document beschrijft de Web API voor centrale en decentrale netbeheerders van het systeem KLIC.  \
De API betreft de uitwisseling van informatie over de gebiedsinformatie-aanvragen en de uitwisseling van beheerdersinformatie. \
Het document beschrijft niet de levering van kabel- en leidinginformatie aan de centrale voorziening door centrale netbeheerders en ook niet de uitwisseling van informatie met gebruikers van de uitgewisselde informatie in de context van KLIC of INSPIRE. \
Dit document geeft een technische beschrijving van de Web API, maar bevat geen procedurele afspraken zoals wettelijke termijnen waarbinnen gereageerd moet worden.

Voor de beschrijving van functionaliteit die in het portaal van de Netbeheerder Testdienst (NTD) worden aangeboden, wordt verwezen naar [Netbeheerder Testdienst (NTD](Netbeheerder%20Testdienst%20(NTD).md). \
Hierin wordt ook beschreven hoe een testmelding kan worden opgevoerd. \
Ook wordt daar in algemene termen beschreven hoe technische documentatie over de API's kan worden ingezien en de werking van API's kan worden getest.

---------------------------------------------------------
## Leeswijzer

In de sectie [Procesmodellen afhandelen beheerdersinformatie-aanvragen](#procesmodellen-afhandelen-beheerdersinformatie-aanvragen) wordt een schematisch overzicht gegeven van het procesverloop bij het afhandelen van een beheerdersinformatie-aanvraag. \
Hierbij wordt onderscheid gemaakt tussen een decentrale en centrale netbeheerder. Een decentrale netbeheerder zal zelf zijn beheerdersinformatie moeten samenstellen en aanleveren aan KLIC.  


De sectie [Afhandelen beheerdersinformatie-aanvragen (enkel decentraal)](#afhandelen-beheerdersinformatie-aanvragen-enkel-decentraal) beschrijft het proces van het aanleveren van beheerdersinformatie en bijbehorende documenten door de decentrale netbeheerder. Alle bestanden worden verpakt in één zipbestand.

Om dit zipbestand aan te kunnen leveren, moet er eerst een testmelding worden opgevoerd met _"Opvoeren testmelding - decentraal"_ (zie [Netbeheerder Testdienst (NTD](Netbeheerder%20Testdienst%20(NTD).md)). Daarmee wordt er een gebiedsinformatie-aanvraag aangemaakt waarvoor beheerdersinformatie en de bijbehorende documenten aangeleverd kunnen worden.

De sectie [Overzicht BMKL API's voor afhandelen beheerdersinformatie-aanvragen](#overzicht-bmkl-apis-voor-afhandelen-beheerdersinformatie-aanvragen) beschrijft de verschillende componenten van de API. \
Voor een aanvraag kunnen achtereenvolgens de volgende secties doorlopen worden:

- [Zoeken beheerdersinformatie-aanvragen](#zoeken-beheerdersinformatie-aanvragen)
- [Opvragen gebiedsinformatie-aanvraag](#opvragen-gebiedsinformatie-aanvraag)
- [Bevestigen beheerdersinformatie-aanvraag](#bevestigen-beheerdersinformatie-aanvraag)
- [Aanleveren beheerdersinformatie (enkel decentraal)](#aanleveren-beheerdersinformatie-enkel-decentraal)

- [Opvragen aanleveringen beheerdersinformatie (enkel decentraal)](#opvragen-aanleveringen-beheerdersinformatie-enkel-decentraal)
- [Opvragen uitgeleverde beheerdersinformatie](#opvragen-uitgeleverde-beheerdersinformatie)

De centrale netbeheerder actualiseert in de NTD-omgeving eerst (indien van toepassing) documenten, via de link "NTD Actualiseren documenten"
en vervolgens netinformatie, via de link "NTD Actualiseren netinformatie". \
Daarna kan ook de centrale netbeheerder een testmelding opvoeren met _"Opvoeren testmelding - centraal"_.
De beheerdersinformatie en de bijbehorende documenten worden naar aanleiding van de gedane testmelding samengesteld door het Kadaster.

In de sectie [Gebruik BMKL API's](#gebruik-bmkl-apis) worden meer (technische) details aangereikt over het gebruik van API's en de beschikbare technische documentatie.

---------------------------------------------------------
## Procesmodellen afhandelen beheerdersinformatie-aanvragen

### Procesmodel BMKL (decentrale netbeheerder)

![procesmodel](bijlagen/8.3.3.2-Produceren-volgens-BMKL-decentraal.png "Procesmodel BMKL 2.0 (decentrale netbeheerder)")
_Figuur 1 Procesmodel BMKL (decentrale netbeheerder)_

### Processtappen (decentrale netbeheerder)
Hieronder wordt een overzicht gegeven van typerende processtappen die in het BMKL-koppelvlak (kunnen) worden gedaan bij het afhandelen van een beheerdersinformatie-aanvraag door een decentrale netbeheerder.

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

![procesmodel](bijlagen/8.3.3.3-Produceren-volgens-BMKL-centraal.png "Procesmodel BMKL 2.0 (centrale netbeheerder)")
_Figuur 2 Procesmodel BMKL 2.0 (centrale netbeheerder)_

### Processtappen (centrale netbeheerder)
Hieronder wordt een overzicht gegeven van typerende processtappen die in het BMKL-koppelvlak (kunnen) worden gedaan bij het afhandelen van een beheerdersinformatie-aanvraag door een centrale netbeheerder. \
Het belangrijkste onderscheid met een decentrale netbeheerder; ligt in het feit dat de beheerdersinformatie niet door de netbeheerder zelf, maar door de centrale voorziening van KLIC wordt opgesteld.

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

---------------------------------------------------------
## Afhandelen beheerdersinformatie-aanvragen (enkel decentraal)

### Samenstellen zipbestand
Zodra een belanghebbende netbeheerder de details kent van een gebiedsinformatie-aanvraag, kan de beheerdersinformatie worden samengesteld. \
Beheerdersinformatie en de bijbehorende documenten worden aangeleverd in een zipbestand door de decentrale netbeheerder. Dit bestand moet voldoen aan de volgende voorwaarden:

- Het zipbestand bevat exact één bestand met de extentie `.xml`. Dit bestand bevat de beheerdersinformatie in [IMKL 2.0 formaat](https://www.geonovum.nl/geo-standaarden/informatiemodel-kabels-en-leidingen#standaard).
- Het zipbestand mag één of meerdere PDF bestanden bevatten. Elk van deze bestanden moet gerefereerd worden vanuit het XML-bestand.
- Het zipbestand mag geen mappenstructuur bevatten; alle bestanden in het zipbestand moeten op het hoogste niveau in het zipbestand opgeslagen worden.
- De naam van het zipbestand moet eindigen op '_V2.zip'.

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

De applicatie biedt een overzicht van de endpoints van de verschillende API’s en hoe deze endpoints gebruikt kunnen worden. Voor de “Beheerdersinformatie” API zijn de meeste endpoints meteen uit te proberen via de aangeboden interface. Uitzondering vormt het downloaden van de aangeleverde beheerdersinformatie. Deze zal via
een browser of via CURL moeten worden uitgevoerd, aangezien Swagger ZIP responses niet ondersteunt.

### Endpoints
In het [overzicht met endpoints KLIC API's](../../API%20management/Overzicht%20endpoints%20KLIC%20APIs.md) wordt een overzicht gegeven van de basispaden voor de endpoints die door KLIC API's worden gebruikt.

De endpoints die in onderstaande voorbeelden worden gebruikt, zijn relatief ten opzichte van deze basispaden.  \
In de voorbeelden wordt uitgegaan van de API's op de NTD-omgeving.

### Authenticatie
De KLIC REST API's zijn beveiligd middels de OAuth 2.0 specificatie. Zie daarvoor [Authenticatie via OAuth](../../API%20management/Authenticatie_via_oauth.md).

### _Accept_ header

Wanneer je een KLIC API met een verlopen/ongeldige token gebruikt, dan is het response met foutmelding erin per default in HTML-formaat.  \
Vanuit een client-applicatie is het veelal gewenst om het response-bericht in JSON-formaat terug te krijgen. Om zeker te stellen dat dit formaat wordt teruggegeven, moet een _Accept_-header worden meegegeven in het request.  \
Voorbeeld:

**Request**  
```sh
curl https://service10.kadaster.nl/klic/ntd/bmkl/v2/gebiedsinformatieAanvragen/-/beheerdersinformatieAanvragen?biNotificatieStatus=biOpen
-X GET
-H 'Authorization: Bearer 1d021976-91c8-4b46-ab9b-529088d0f3de'
-H 'Accept: application/json'
```
**Response:**  (indien toegang geweigerd)
```json
{
    "error": "Kadaster - Niet geauthenticeerd.",
    "error_description": "Toegang tot de dienst Klic Online is alleen voor geauthenticeerde gebruikers. "
}
```  
Bij een HTTP 200 response, wordt de response wél in JSON-formaat teruggegeven.

### Pagineren
Voor de endpoints die een lijst van objecten opleveren, pagineren we de output. Waar we een collectie geven, pagineren we door in de response een link naar volgende pagina te geven.  \
Zie ook de toepassing van [standaarden en richtlijnen](../../API%20management/Standaardisering%20bij%20KLIC%20APIs.md) in KLIC API's.

Voorbeeld van een resultaatlijst: 
``` json
{
    "_links": {
        "next": {
            "href": "https://service10.kadaster.nl/klic/ntd/bmkl/v2/gebiedsinformatieAanvragen/-/beheerdersinformatieAanvragen?limiet=5&offset=5"
        },
        "self": {
            "href": "https://service10.kadaster.nl/klic/ntd/bmkl/v2/gebiedsinformatieAanvragen/-/beheerdersinformatieAanvragen?limiet=5"
        }
    },
    "beheerdersinformatieAanvragen": [
        {
           //lijst met eerste 5 beheerdersinformatie-aanvragen...
        }
    ]
}
```

### CURL

De “KLIC API Documentatie”-applicatie maakt het mogelijk om de meeste endpoints aan te roepen vanuit de browser.
In het voorbeeld in dit document wordt echter gebruik gemaakt van de [command-line tool CURL](https://curl.haxx.se/). Dit heeft meer analogie met de werkwijze als een netbeheerder of serviceprovider een eigen applicatie wil ontwikkelen voor het decentraal aanleveren van beheerdersinformatie via de B2B-koppeling. \
De CURL-commando's worden in dit document voor de leesbaarheid weergegeven op meerdere regels. Deze commando's dienen of als één enkele regel ingevoerd te worden, of de regels dienen afgesloten te worden met een '^' (Windows) of een '\\' (Unix).

### KLIC API Documentatie

De API Documentatie is beschikbaar via een Swagger-implementatie. Deze functionaliteit is opgenomen in het portaal van de [Netbeheerder Testdienst (NTD](Netbeheerder Testdienst (NTD).md).
Op onderstaande Swagger-pagina worden de services voor het afhandelen van beheerdersinformatie-aanvragen weergegeven.  \
Let wel, niet alle services zijn geautoriseerd om door netbeheerders gebruikt te worden.

![mijnKadaster](bijlagen/KLIC-API-documentatie-BMKL21-swagger.png "NTD Portaal - API Documentatie detail")

_Figuur 3 API Documentatie Beheerdersinformatie / BMKL 2.1 (detail)_

### Gebruik van URL-parameters bij de API's

In de verschillende API's is het mogelijk om filter-criteria toe te passen met behulp van URL-parameters.  \
In de Swagger-implementatie zoals [hierboven beschreven](#klic-api-documentatie), worden de verschillende parameters per API weergegeven.  \
Bij het gebruik van de `datumVanaf` en/of `datumTot` filters is de parameter `datumType` verplicht, omdat er in sommige API's meerdere datumvelden ontsloten worden. 

![Swagger](bijlagen/Swagger-SelectieParameters-fragment.png "Swagger - Selectie Parameters (fragment gebiedsinformatieAanvragen)")

_Figuur 4 Swagger - Selectie Parameters (fragment gebiedsinformatieAanvragen)_


---------------------------------------------------------
## Overzicht BMKL API's voor afhandelen beheerdersinformatie-aanvragen ##

_De voorbeelden die hieronder zijn beschreven, gaan er vanuit dat er	&eacute;&eacute;n testmelding is gedaan. Er zal voor deze testmelding beheerdersinformatie worden aangeleverd._


### Zoeken beheerdersinformatie-aanvragen

Het endpoint voor het opvragen van de lijst met beheerdersinformatie-aanvragen van de netbeheerder,
kan aangeroepen worden met of zonder `biAanvraagId`. De aanroep zonder `biAanvraagId` levert een lijst op en kan worden aangeroepen met verschillende parameters om zo naar één specifieke, of een bepaalde set beheerdersinformatie-aanvragen te kunnen zoeken.  \
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
curl https://service10.kadaster.nl/klic/ntd/bmkl/v2/gebiedsinformatieAanvragen/-/beheerdersinformatieAanvragen?biNotificatieStatus=biOpen&limiet=5
 -X GET
 -H "Authorization: Bearer 1d021976-91c8-4b46-ab9b-529088d0f3de"
 -H 'Accept: application/json'
```

**_response_**
```json
{
    "_links": {
        "next": {
            "href": "https://service10.kadaster.nl/klic/ntd/bmkl/v2/gebiedsinformatieAanvragen/-/beheerdersinformatieAanvragen?biNotificatieStatus=biOpen&limiet=5&offset=5"
        },
        "self": {
            "href": "https://service10.kadaster.nl/klic/ntd//bmkl/v2/gebiedsinformatieAanvragen/-/beheerdersinformatieAanvragen?biNotificatieStatus=biOpen&limiet=5"
        }
    },
    "beheerdersinformatieAanvragen": [
        {
	        "biAanvraagId": "330d0526-0586-4843-ad86-04d8969fc768",
            "giAanvraagId": "4c8353bd-3907-40ee-84b0-5f54ac38d4d1",
            "bronhoudercode": "KL0002",
            "biNotificatieStatus": "https://api.klic.kadaster.nl/waardelijsten/v2/biNotificatieStatussen/biOpen",
            "biProductieStatus": "https://api.klic.kadaster.nl/waardelijsten/v2/biProductieStatussen/biWachtOpAntwoord",
            "datumGenotificeerd": "2017-11-03T10:38:44+01:00",
            "mutatieDatum":"2017-11-03T10:38:44.653+01:00"
        },{
            "biAanvraagId": "130k5426-0586-4843-ad86-04d89623fd28",
            "giAanvraagId": "8dc933bd-3907-40ee-84b0-5f54ah37a4d1",
            "bronhoudercode": "KL0002",
            "biNotificatieStatus": "https://api.klic.kadaster.nl/waardelijsten/v2/biNotificatieStatussen/biBevestigingOntvangen",
            "biProductieStatus": "https://api.klic.kadaster.nl/waardelijsten/v2/biProductieStatussen/biWachtOpAntwoord",
            "datumGenotificeerd": "2017-11-03T10:43:25+01:00",
            "datumBevestigingOntvangen": "2017-11-03T10:55:36+01:00",
            "mutatieDatum":"2017-11-03T10:55:36.399+01:00"
        },{
            //overige 3 beheerdersinformatie-aanvragen uit resultaatlijst...
        }
    ]
}
```

### Opvragen beheerdersinformatie-aanvraag
Het endpoint voor het opvragen van één specifieke beheerdersinformatie-aanvraag.  \
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
curl https://service10.kadaster.nl/klic/ntd/bmkl/v2/gebiedsinformatieAanvragen/4c8353bd-3907-40ee-84b0-5f54ac38d4d1/beheerdersinformatieAanvragen/330d0526-0586-4843-ad86-04d8969fc768
 -X GET
 -H "Authorization: Bearer 1d021976-91c8-4b46-ab9b-529088d0f3de"
 -H 'Accept: application/json'
```

**_response_**
```json
{
    "biAanvraagId": "330d0526-0586-4843-ad86-04d8969fc768",
    "giAanvraagId": "4c8353bd-3907-40ee-84b0-5f54ac38d4d1",
    "bronhoudercode": "KL0002",
    "biNotificatieStatus": "https://api.klic.kadaster.nl/waardelijsten/v2/biNotificatieStatussen/biBevestigingOntvangen",
    "biProductieStatus": "https://api.klic.kadaster.nl/waardelijsten/v2/biProductieStatussen/biGereedVoorSamenstellenProduct",
    "datumGenotificeerd": "2017-11-03T10:38:44+01:00",
    "datumBevestigingOntvangen": "2017-11-03T11:05:31+01:00",
    "mutatieDatum":"2017-11-03T11:05:31.932+01:00"
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
curl https://service10.kadaster.nl/klic/ntd/bmkl/v2/gebiedsinformatieAanvragen/4c8353bd-3907-40ee-84b0-5f54ac38d4d1
 -X GET
 -H "Authorization: Bearer 1d021976-91c8-4b46-ab9b-529088d0f3de"
 -H 'Accept: application/json'
```

**Voorbeeld van response**
```json
{
    "giAanvraagId": "4c8353bd-3907-40ee-84b0-5f54ac38d4d1",
    "ordernummer": "2015000924",
    "positienummer": "00010",
    "klicMeldnummer": "17G000649",
    "aanvrager":{
        "contactpersoon": {
            "naam":"Aanvrager01",
            "telefoon":"0881235648",
            "email":"klicwin@kadaster.nl"
        },
        "organisatie":{
            "naam":[
                "Grondroerder Apeldoorn B.V."
            ],
            "kvkNummer": "12345678",
            "bezoekAdres":{
                "BAGid": "0200010000130331",
                "openbareRuimteNaam":"Laan van Westenenk",
                "huisnummer":"701",
                "woonplaatsNaam":"Apeldoorn",
                "postcode":"7334DP",
                "landcode": "http://publications.europa.eu/resource/authority/country/NLD"
            }
        },
        "extraContact": {
            "naam":"Tester",
            "telefoon":"0612345678",
            "email":"ordervoorbereiding@operator.net"
        }
    },
    "opdrachtgever":{
        "contactpersoon":{
            "naam":"Kadaster",
            "telefoon":"(088) 183 20 00",
            "email":"noreply@kadaster.nl"
        },
        "organisatie":{
            "naam":[
                "Kadaster"
            ],
            "kvkNummer": "87654321",
            "bezoekAdres":{
                "BAGid": "0200010000090244",
                "openbareRuimteNaam":"Hofstraat",
                "huisnummer":"110",
                "woonplaatsNaam":"Apeldoorn",
                "postcode":"7311KZ",
                "landcode": "http://publications.europa.eu/resource/authority/country/NLD"
            }
        }
    },
    "aanvraagSoort":"http://definities.geostandaarden.nl/imkl2015/id/waarde/AanvraagSoortValue/graafmelding",
    "aanvraagDatum":"2017-11-03T10:38:14+01:00",
    "mutatieDatum":"2017-11-03T10:38:14.451+01:00",
    "giAanvraagStatus": "https://api.klic.kadaster.nl/waardelijsten/v2/giAanvraagStatussen/giOpen",
    "soortWerkzaamheden":[
        "http://definities.geostandaarden.nl/imkl2015/id/waarde/SoortWerkzaamhedenValue/leggenLaagspanning",
        "http://definities.geostandaarden.nl/imkl2015/id/waarde/SoortWerkzaamhedenValue/huisaansluitingenMaken"
    ],
    "locatieWerkzaamheden":{
        "BAGid": "0200010000130331",
        "openbareRuimteNaam":"Laan van Westenenk",
        "huisnummer":"701",
        "woonplaatsNaam":"Apeldoorn",
        "postcode":"7334DP",
    },
    "locatieOmschrijving": "bij fonteinaansluiting",
    "startDatum": "2017-11-13",
    "eindDatum": "2017-11-22",
    "huisaansluitingAdressen":[{
       "BAGid": "0200010000130331",
       "openbareRuimteNaam":"Laan van Westenenk",
       "huisnummer":"701",
       "woonplaatsNaam":"Apeldoorn",
       "postcode":"7334DP",

	}, {
       "BAGid": "0200010003923183",
       "openbareRuimteNaam":"Evert van 't Landstraat",
       "huisnummer":"15",
       "woonplaatsNaam":"Apeldoorn",
       "postcode":"7334DR",
           }],
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
    "informatiepolygoon":{
        "type":"Polygon",
        "crs":{
            "type":"name",
            "properties":{
                "name":"EPSG:28992"
            }
        },
        "coordinates":[ [ [ 153606.0, 391101.0 ], [ 153594.0, 391095.0 ], [ 153602.0, 391080.0 ], [ 153622.0, 391094.0 ], [ 153606.0, 391101.0 ] ] ]
    }
}
```

### Bevestigen beheerdersinformatie-aanvraag

Voordat een (decentrale) netbeheerder beheerdersinformatie kan aanleveren voor een beheerdersinformatie-aanvraag, moet de netbeheerder eerst bevestigen dat hij de beheerdersinformatie-aanvraag ontvangen heeft. \
Dat wordt gedaan door de `biNotificatieStatus` de waarde `biBevestigingOntvangen` te geven.

Ook voor de centrale netbeheerder wordt aanbevolen om de beheerdersinformatieaanvraag te bevestigen. \
Als een centrale netbeheerder geen ontvangstbevestiging stuurt op een aanvraag, dan blijft deze de status "open" houden. Het Kadaster zal - ongeacht de notificatiestatus - beheerdersinformatie namens de centrale netbeheerder produceren en uitleveren.

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
curl https://service10.kadaster.nl/klic/ntd/bmkl/v2/gebiedsinformatieAanvragen/4c8353bd-3907-40ee-84b0-5f54ac38d4d1/beheerdersinformatieAanvragen/330d0526-0586-4843-ad86-04d8969fc768
 -X PATCH
 -H 'Authorization: Bearer 1d021976-91c8-4b46-ab9b-529088d0f3de'
 -H 'Accept: application/json'
 -d "{  \"biNotificatieStatus\": \"biBevestigingOntvangen\" }"
```

**_response:_**
```
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
curl https://service10.kadaster.nl/klic/ntd/bmkl/v2/gebiedsinformatieAanvragen/4c8353bd-3907-40ee-84b0-5f54ac38d4d1/beheerdersinformatieAanvragen/330d0526-0586-4843-ad86-04d8969fc768/aanleveringen
 -X POST
 -H 'Authorization: Bearer 1d021976-91c8-4b46-ab9b-529088d0f3de'
 -H 'Accept: application/json'
 -F "netinformatie=@C:/Aanleveringen/Decentraal/nbact1/BMKL_DECENTRAAL.zip"
```

**_response:_**
```
HTTP/1.1 200 OK
```
Wanneer de ontvangst van de beheerdersinformatie-aanvraag nog niet is bevestigd, wordt onderstaande melding teruggegeven. De beheerdersinformatie-aanvraag moet dus eerst
bevestigd ('bevestigingOntvangen') zijn, alvorens er beheerdersinformatie kan worden aangeleverd.

**_response:_**
```JSON
{
  "status": 405,
  "meldingCode": 1000405,
  "gebruikerMelding": "methode niet toegestaan",
  "ontwikkelaarMelding": "de gebiedsinformatie-aanvraag is nog niet bevestigd",
  "meerInformatie": "http://developer.klic.nl/foutCode/1000405"
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
curl https://service10.kadaster.nl/klic/ntd/bmkl/v2/gebiedsinformatieAanvragen/4c8353bd-3907-40ee-84b0-5f54ac38d4d1/beheerdersinformatieAanvragen/330d0526-0586-4843-ad86-04d8969fc768/aanleveringen
 -X GET 
 -H 'Authorization: Bearer 1d021976-91c8-4b46-ab9b-529088d0f3de'
 -H 'Accept: application/json'
```

**_voorbeeld van response:_**
```json
[{
  "aanleveringId": "3950e2eb-8942-4e6b-99ff-f4f06c5824db",
  "bronhoudercode": "KL0002",
  "bronhouderNaam": "Netbeheerder Decentraal02",
  "informatieSoort": "https://api.klic.kadaster.nl/waardelijsten/v2/informatieSoorten/beheerdersinformatie",
  "bestandsnaam": "KL0002_met_documenten.zip",
  "bestandsgrootte": 40955,
  "aanleverNummer": 15,
  "aanleverDatum": "2017-11-03T16:23:53+01:00",
  "aanleverStatus": "https://api.klic.kadaster.nl/waardelijsten/v2/aanleverStatussen/biGevalideerdZonderFouten",
  "aanleverStatusMutatieDatum": "2017-11-03T16:23:56.829+01:00",
  "aanleverStatusHistorie": [ {
    "mutatieDatum": "2017-11-03T16:23:56.829+01:00",
    "aanleverStatus": "https://api.klic.kadaster.nl/waardelijsten/v2/aanleverStatussen/biGevalideerdZonderFouten"
  }, {
    "mutatieDatum": "2017-11-03T16:23:55.744+01:00",
    "aanleverStatus": "https://api.klic.kadaster.nl/waardelijsten/v2/aanleverStatussen/biWordtGevalideerd"
  }, {
    "mutatieDatum": "2017-11-03T16:23:54.231+01:00",
    "aanleverStatus": "https://api.klic.kadaster.nl/waardelijsten/v2/aanleverStatussen/biAangeleverd"
  }, {
    "mutatieDatum": "2017-11-03T16:23:53.470+01:00",
    "aanleverStatus": "https://api.klic.kadaster.nl/waardelijsten/v2/aanleverStatussen/biGestart"
  }],
  "aanleverStappen": [{
    "aanleverStapAanduiding": "https://api.klic.kadaster.nl/waardelijsten/v2/aanleverStapAanduidingen/biAanleveren",
    "startDatum": "2017-11-03T16:23:53+01:00",
    "eindDatum": "2017-11-03T16:23:54+01:00",
    "stapStatus": "https://api.klic.kadaster.nl/waardelijsten/v2/aanleverStapStatussen/succes",
    "gebruiker": "jvanklaveren"
  }, {
    "aanleverStapAanduiding": "https://api.klic.kadaster.nl/waardelijsten/v2/aanleverStapAanduidingen/biValideren",
    "startDatum": "2017-11-03T16:23:55+01:00",
    "eindDatum": "2017-11-03T16:23:56+01:00",
    "stapStatus": "https://api.klic.kadaster.nl/waardelijsten/v2/aanleverStapStatussen/succes",
    "gebruiker": "system"
  }]
}]
```

### Opvragen uitgeleverde beheerdersinformatie

Nadat de beheerdersinformatie is samengesteld ten behoeve van een uitlevering, kan de netbeheerder opvragen welke informatie door KLIC namens de netbeheerder wordt uitgeleverd.
De beheerdersinformatie-uitlevering wordt als zipbestand teruggegeven.

**Let wel**: De uitgeleverde beheerdersinformatie wordt na 20 werkdagen opgeschoond en is dan niet meer op te vragen!

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
curl https://service10.kadaster.nl/klic/ntd/bmkl/v2/gebiedsinformatieAanvragen/4c8353bd-3907-40ee-84b0-5f54ac38d4d1/beheerdersinformatieAanvragen/330d0526-0586-4843-ad86-04d8969fc768/beheerdersinformatieLevering/zip
 -X GET
 -H 'Authorization: Bearer 1d021976-91c8-4b46-ab9b-529088d0f3de'
 -H 'Accept: application/json'
 > download.zip
```

**_response:_**

Deze aanroep levert een zipbestand op met daarin de beheerdersinformatie zoals die naar de aanvrager wordt uitgeleverd. Dit zijn alleen gegevens van de netbeheerder die bij de meegegeven `giAanvraagId` horen. Het is dus een uitsnede van de volledige uitlevering zoals die naar de aanvrager gaat.

## Overzicht BMKL APIs voor afhandelen afwijkende situatie

### Zoeken terugmeldingen

NB: Dit is een concept ontwerp
Het endpoint voor het opvragen van de lijst met terugmeldingen van de netbeheerder,
kan aangeroepen worden met of zonder `giAanvraagId`. De aanroep zonder `giAanvraagId` kan worden aangeroepen met verschillende parameters om zo naar één specifieke, of een bepaalde set terugmeldingen te kunnen zoeken.
Het systeem haalt alle terugmeldingen op die voldoen aan de criteria en waarvoor de ingelogde gebruiker geautoriseerd is.

De pad-parameter `giAanvraagId` is verplicht maar mag `-` zijn. In dat geval worden terugmeldingen gezocht over alle
gebiedsinformatie aanvragen waar de netbeheerder belanghebbend bij is.

**_pad:_**
```sh
GET /gebiedsinformatieAanvragen/{giAanvraagId}/terugmeldingen/
```

**_benodigde scope:_**
```
klic.beheerdersinformatie
of
klic.beheerdersinformatie.readonly
```

**_voorbeeld: Zoeken openstaande terugmeldingen_**

In dit voorbeeld wordt gezocht naar alle terugmeldingen voor de ingelogde netbeheerder of service provider met de status "open". Hiervoor wordt de parameter `tmNotificatieStatus` met de waarde `tnsOpen` toegevoegd aan het request.
```sh
curl https://service10.kadaster.nl/klic/ntd/bmkl/v2/gebiedsinformatieAanvragen/-/terugmeldingen/-/beheerdersTerugmeldingen?tmNotificatieStatus=tnsOpen&limiet=3
 -X GET
 -H "Authorization: Bearer 1d021976-91c8-4b46-ab9b-529088d0f3de"
 -H 'Accept: application/json'
```

**_response_**
```json
{
	"_links": {
		"next": {
			"href": "https://service10.kadaster.nl/klic/ntd/bmkl/v2/gebiedsinformatieAanvragen/-/terugmeldingen?tmNotificatieStatus=tnsOpen&limiet=3&offset=3"
		},
		"self": {
			"href": "https://service10.kadaster.nl/klic/ntd/bmkl/v2/gebiedsinformatieAanvragen/-/terugmeldingen?tmNotificatieStatus=tnsOpen&limiet=3"
		}
	},
	"beheerdersTerugmeldingen": [
		{
			"terugmeldingId": "138",
	        "beheerdersTerugmeldingId": "546",
			"bronhoudercode": "GM1641",
			"tmNotificatieStatus": "https://api.klic.kadaster.nl/waardelijsten/v2/NotificatieStatussen/tnsOpen",
			"datumGenotificeerd": "2020-11-26T10:20:49+01:00",
			"tmClaimStatus": "https://api.klic.kadaster.nl/waardelijsten/v2/ClaimStatussen/tcsOpen",
			"mutatieDatum": "2020-11-26T10:20:49.123+01:00"
		},
		{
			"terugmeldingId": "126
			"beheerdersTerugmeldingId": "504",
			"bronhoudercode": "KL1001",
			"tmNotificatieStatus": "https://api.klic.kadaster.nl/waardelijsten/v2/NotificatieStatussen/tnsOpen",
			"datumGenotificeerd": "2020-11-26T10:20:49+01:00",
			"tmClaimStatus": "https://api.klic.kadaster.nl/waardelijsten/v2/ClaimStatussen/tcsOpen",
						"mutatieDatum": "2020-11-26T10:20:49.123+01:00"
		},
		{
	        "terugmeldingId": "106",
	        "beheerdersTerugmeldingId": "431",
			"bronhoudercode": "KL1001",
			"tmNotificatieStatus": "https://api.klic.kadaster.nl/waardelijsten/v2/NotificatieStatussen/tnsOpen",
			"datumGenotificeerd": "2020-11-26T10:20:49+01:00",
					"terugmeldingId": "f4eb214a-017b-454c-a678-0a90c58d6666",
			"tmClaimStatus": "https://api.klic.kadaster.nl/waardelijsten/v2/ClaimStatussen/tcsOpen",
			"mutatieDatum": "2020-11-26T10:20:49.123+01:00"
		}
	]
}
```

**_voorbeeld: Ophalen melding data_**

Nadat is gezocht naar alle terugmeldingen voor de ingelogde netbeheerder met de status "open". Kan de bijbehorende terugmelding van de grondroerder opgevraagd worden.
```sh
curl https://service10.kadaster.nl/klic/ntd/bmkl/v2/gebiedsinformatieAanvragen/-/terugmeldingen/123
 -X GET
 -H "Authorization: Bearer 1d021976-91c8-4b46-ab9b-529088d0f3de"
 -H 'Accept: application/json'
```

**_response_**
```json
{
	"terugmeldingId": "123",
	"giAanvraagId": "4c8353bd-3907-40ee-84b0-5f54ac38d4d1",
	"datumAangemaakt": "2020-11-26T10:20:49+01:00",
	"mutatieDatum": "2020-11-26T10:20:49.123+01:00",
	"klicmeldnummer": "19G002541",
	"tmKlicTerugmeldStatus": "https://api.klic.kadaster.nl/waardelijsten/v2/KlicTerugmeldStatussen/ktsInOnderzoek",
	"tmsmelding": {
		"type": "Feature",
		"geometry": {
			"type": "Point",
			"coordinates": [
				190050.02750000009,
				351343.92312499976
			]
		},
		"properties": {
			"meldingsNummerVolledig": "KLIC0071906",
			"meldingsNummer": 71906,
			"tijdstipWijziging": "2020-11-26T14:15:02.659406+02:00",
			"bron": "Kadaster KLIC-viewer",
			"registratie": "KLIC",
			"locatieLink": "https://bagviewer.kadaster.nl/#?geometry.x=190050.03&geometry.y=351343.92&zoomlevel=7",
			"tijdstipRegistratie": "2020-11-26T10:25:58.070+01:00",
			"bronhoudernaam": "Kadaster",
			"bronhoudercode": "K0001",
			"objectType": "",
			"omschrijving": "er ligt hier een groene kabel in mijn graafgebied, lijkt mij een data-kabel. ongeveer 30 cm diep, met een dikte van een halve cm",
			"tijdstipStatusWijziging": "2020-11-26T14:15:02.659406+02:00",
            "objectId": "",
            "status": "Nieuw",
			"statusCode": "NIEUW"
			"doorgestuurdNaar": null,
            "gewijzigdDoor":"0000302114@pmkKLICbeheer",
			"secundair": {
				"situatie": "onbekend net",
				"netbeheerder": "KPN",
			    "klicmeldnummer": "19G002541",
			    "referentie": "Industrieweg Maasbracht meld2",
			    "terugmelder": "G. Raver",
                "telefoonnummer": "0123456789",
				"thema": "http://definities.geostandaarden.nl/imkl2015/id/waarde/Thema/datatransport",
				"bedrijfsnaam": "Kadaster",
				"getekendeGeometrie": {
				    "type": "LineString",
				    "coordinates": [
    					[
    						190050.72312500009,
    						351342.03968749978
    					],
    					[
    						190050.89375000009,
    						351343.47031249976
    					],
    					[
    						190049.16125000007,
    						351345.8065624997
    					]
			    	]
			    },
			"bijlagen": [
				{
					"url": "https://service10.kadaster.nl/gds2/download/public/00c912bf-8232-4078-b06a-b0c040e52172",
					"naam": "screenshot markering.jpg"
				},
				{
					"url": "https://service10.kadaster.nl/gds2/download/public/0e4a1d63-9815-49de-ab3a-b88f09ace0df",
					"naam": "foto1.jpg"
				}
			],
			"email": "noreply@kadaster.nl
		}
	}
}
```

### Bevestigen terugmelding

Een netbeheerder moet bij het kadaster bevestigen dat hij de terugmelding ontvangen heeft. \
Dat wordt gedaan door de `tmNotificatieStatus` de waarde `tnsBevestigingOntvangen` te geven. Voor {giAanvraagId} en {terugmeldingId} mag een wildcard teken '-' gegeven worden

**_pad:_**
```
PATCH /gebiedsinformatieAanvragen/{giAanvraagId}/terugmeldingen/{terugmeldingId}/beheerdersTerugmeldingen/{beheerdersTerugmeldingId}
```

**_benodigde scope:_**
```
klic.beheerdersinformatie
```

**_voorbeeld:_**
```sh
curl https://service10.kadaster.nl/klic/ntd/bmkl/v2/gebiedsinformatieAanvragen/-/terugmeldingen/-/beheerdersTerugmeldingen/146
 -X PATCH
 -H 'Authorization: Bearer 1d021976-91c8-4b46-ab9b-529088d0f3de'
 -H 'Accept: application/json'
 -d "{  \"tmNotificatieStatus\": \"tnsBevestigingOntvangen\" }"
```

**_response:_**
```
HTTP/1.1 200 OK
```

### Afwijzen terugmelding

Een netbeheerder kan aangeven dat een terugmelding geen betrekking heeft op zijn netwerk door `tmClaimStatus` de waarde `tcsAfgewezen` te geven.

**_pad:_**
```
PATCH /gebiedsinformatieAanvragen/{giAanvraagId}/terugmeldingen/{terugmeldingId}/beheerdersTerugmeldingen/{beheerdersTerugmeldingId}
```

**_benodigde scope:_**
```
klic.beheerdersinformatie
```

**_voorbeeld:_**
```sh
curl https://service10.kadaster.nl/klic/ntd/bmkl/v2/gebiedsinformatieAanvragen/-/terugmeldingen/-/beheerdersTerugmeldingen/146
 -X PATCH
 -H 'Authorization: Bearer 1d021976-91c8-4b46-ab9b-529088d0f3de'
 -H 'Accept: application/json'
 -d "{  \"tmClaimStatus\": \"tcsAfgewezen\" }"
```

**_response:_**
```
HTTP/1.1 200 OK
```

### Claimen terugmelding

Een netbeheerder kan aangeven dat een terugmelding geen betrekking heeft op zijn netwerk door `tmClaimStatus` de waarde `tcsGeclaimd` te geven.

**_pad:_**
```
PATCH /gebiedsinformatieAanvragen/{giAanvraagId}/terugmeldingen/{terugmeldingId}/beheerdersTerugmeldingen/{beheerdersTerugmeldingId}
```

**_benodigde scope:_**
```
klic.beheerdersinformatie
```

**_voorbeeld:_**
```sh
curl https://service10.kadaster.nl/klic/ntd/bmkl/v2/gebiedsinformatieAanvragen/-/terugmeldingen/-/beheerdersTerugmeldingen/146
 -X PATCH
 -H 'Authorization: Bearer 1d021976-91c8-4b46-ab9b-529088d0f3de'
 -H 'Accept: application/json'
 -d "{  \"tmClaimStatus\": \"tcsGeclaimd\" }"
```

**_response:_**
```
HTTP/1.1 200 OK
```
