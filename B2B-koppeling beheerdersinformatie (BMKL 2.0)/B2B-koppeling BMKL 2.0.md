# B2B-koppeling BMKL 2.0

Dit document biedt een handleiding voor het aanleveren van beheerdersinformatie
via de B2B-koppeling volgens het BMKL 2.0. als decentrale netbeheerder.

Ook worden de services beschreven waarvan een centrale netbeheerder gebruik van kan maken.


**Inhoudsopgave**

  - [Context](#context)
  - [Scope](#scope)
  - [Leeswijzer](#leeswijzer)
      - [Authenticatie](#authenticatie)
      - [Endpoints](#endpoints)
      - [Opvoeren testmelding](#opvoeren-testmelding)
          - [Mijn Kadaster](#mijn-kadaster)
          - [KLIC Netbeheerder Testdienst portaal](#klic-netbeheerder-testdienst-portaal)
          - [Opvoeren testmelding - 1 van 5](#opvoeren-testmelding---1-van-5)
          - [Opvoeren testmelding - 2 van 5](#opvoeren-testmelding---2-van-5)
          - [Opvoeren testmelding - 3 van 5](#opvoeren-testmelding---3-van-5)
          - [Opvoeren testmelding - 4 van 5](#opvoeren-testmelding---4-van-5)
          - [Opvoeren testmelding - 5 van 5](#opvoeren-testmelding---5-van-5)
  - [Beheerdersinformatie en documenten aanleveren (enkel decentraal)](#beheerdersinformatie-en-documenten-aanleveren-enkel-decentraal)
      - [Beheerdersinformatie aanleveren mbv REST interface (enkel decentraal)](#beheerdersinformatie-aanleveren-mbv-rest-interface-enkel-decentraal)
          - [De REST API voor BMKL 2.0 ondersteunt de volgende functionaliteit:](#de-rest-api-voor-bmkl-20-ondersteunt-de-volgende-functionaliteit)
          - [CURL](#curl)
          - [Swagger API Documentatie](#swagger-api-documentatie)
          - [Gebiedsinformatie-aanvragen opvragen](#gebiedsinformatie-aanvragen-opvragen)
          - [Beheerdersinformatie-aanvragen opvragen](#beheerdersinformatie-aanvragen-opvragen)
          - [Beheerdersinformatie-aanvraag bevestigen](#beheerdersinformatie-aanvraag-bevestigen)
          - [Beheerdersinformatie aanleveren (enkel decentraal)](#beheerdersinformatie-aanleveren-enkel-decentraal)
          - [Opvragen gegevens aangeboden beheerdersinformatie (enkel decentraal)](#opvragen-gegevens-aangeboden-beheerdersinformatie-enkel-decentraal)
          - [Uitgeleverde beheerdersinformatie opvragen](#uitgeleverde-beheerdersinformatie-opvragen)
  - [Swagger UI](#swagger-ui)
      - [OAuth token meegeven](#oauth-token-meegeven)

## Context
Voor het oriënteren, plannen en uitvoeren van graafwerkzaamheden in een bepaald gebied hebben
grondroerders informatie nodig over de locatie en aard van de in de grond aanwezige kabels en leidingen.
Deze informatie bevindt zich bij decentrale netbeheerders of in de centrale voorziening Kabels en Leidingen.
Het systeem KLIC wordt opgezet als de centrale voorziening voor het ontsluiten van deze informatie.
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

## Scope
Dit document beschrijft de Web API voor centrale en decentrale netbeheerders van het systeem KLIC. De API
betreft de uitwisseling van informatie over de gebiedsinformatie-aanvragen en de uitwisseling van
beheerdersinformatie.
Het document beschrijft niet de levering van kabel- en leidinginformatie aan de centrale voorziening door
centrale netbeheerders en ook niet de uitwisseling van informatie met gebruikers van de uitgewisselde
informatie in de context van KLIC of INSPIRE.
Dit document geeft een technische beschrijving van de Web API, maar bevat geen procedurele afspraken
zoals wettelijke termijnen waarbinnen gereageerd moet worden.

## Leeswijzer

De sectie [Beheerdersinformatie en documenten aanleveren](#beheerdersinformatie-en-documenten-aanleveren-enkel-decentraal) beschrijft het proces
van het aanleveren van beheerdersinformatie en de bijbehorende documenten door de centrale netbeheerder. Alle bestanden worden verpakt in één zipbestand.

Om dit zipbestand aan te kunnen leveren moet er eerst een testmelding opgevoerd worden, zodat er een gebiedsinformatie-aanvraag aangemaakt
wordt waarvoor beheerdersinformatie en de bijbehorende documenten aangeleverd kunnen worden. Dit wordt beschreven in de
sectie [Opvoeren testmelding](#opvoeren-testmelding) De decentrale netbeheerder doet een testmelding via de link
"Opvoeren testmelding - BMKL 2.0 decentraal (b&egrave;ta-versie)"

De sectie [Beheerdersinformatie aanleveren mbv REST interface](#beheerdersinformatie-aanleveren-mbv-rest-interface-enkel-decentraal) beschrijft de verschillende componenten van de API. Voor het aanleveren van een zipbestand kunnen achtereenvolgens de volgende secties doorlopen worden:

- [Gebiedsinformatie-aanvragen opvragen](#gebiedsinformatie-aanvragen-opvragen)
- [Beheerdersinformatie-aanvragen opvragen](#beheerdersinformatie-aanvragen-opvragen)
- [Beheerdersinformatie-aanvraag bevestigen](#beheerdersinformatie-aanvraag-bevestigen)
- [Beheerdersinformatie aanleveren](#beheerdersinformatie-aanleveren-enkel-decentraal)
- [Opvragen gegevens aangeboden beheerdersinformatie](#opvragen-gegevens-aangeboden-beheerdersinformatie-enkel-decentraal)
- [Uitgeleverde beheerdersinformatie opvragen](#uitgeleverde-beheerdersinformatie-opvragen)

Sectie [Opvragen gegevens aangeboden beheerdersinformatie](#opvragen-gegevens-aangeboden-beheerdersinformatie) beschrijft hoe vervolgens
de status van een aanlevering gecontroleerd kan worden van een decentrale netbeheerder.

Sectie [Uitgeleverde beheerdersinformatie opvragen](#uitgeleverde-beheerdersinformatie-opvragen) beschrijft hoe een aangeleverd zipbestand gedownload kan worden.

De centrale netbeheerder actualiseert in de NTD-omgeving eerst (indien van toepassing) documenten, via de link "NTD Actualiseren documenten (b&egrave;ta-versie)"
en vervolgens netinformatie, via de link "NTD Actualiseren netinformatie (b&egrave;ta-versie)". Daarna doet de centrale netbeheerder een testmelding via de
link "Opvoeren testmelding - BMKL 2.0 centraal (b&egrave;ta-versie)". De beheerdersinformatie en de bijbehorende documenten wordt naar aanleiding van de
gedane testmelding smanegesteld door het Kadaster.

### Authenticatie

De KLIC REST API's zijn beveiligd middels de OAuth 2.0 specificatie. Zie daarvoor 
 [Authenticatie via oauth](./../OAuth/Authenticatie_via_oauth.md).

### Endpoints

De endpoints die gebruikt worden in dit document zijn relatief ten opzichte van de betreffende API’s. Bijvoorbeeld de service "gebiedsinformatieAanvragen" wordt
voluit "https://service10.kadaster.nl/klic/ntd/leveren/api/v2/web/gebiedsinformatieAanvragen".

### Opvoeren testmelding

Om het afhandelen van een gebiedsinformatie-aanvraag te kunnen testen, biedt de NTD de mogelijkheid om een testmelding op te voeren.

#### Mijn Kadaster
Na het inloggen in Mijn Kadaster kiest u via het menu voor "Klic Netbeheerder Testdienst".

:information_source: Hiervoor dient u geautoriseerd te zijn.

![mijnKadaster](images/mijn-kadaster-ntd.png "Mijn Kadaster - Klic Netbeheerder TestDienst")

_Figuur 1 Mijn Kadaster - Klic Netbeheerder Testdienst_

#### KLIC Netbeheerder Testdienst portaal

Vervolgens opent zich het "Klic Netbeheerder Testdienst" portaalscherm met hierop alle opties die binnen de NTD beschikbaar worden gesteld,
mits u hiervoor geautoriseerd bent. Op dit portaalscherm vindt u de links waar u een testmelding kunt opvoeren:

- "Opvoeren testmelding - BMKL 2.0 centraal (b&egrave;ta-versie)" waar u als centrale netbeheerder een testmelding kunt opvoeren
- "Opvoeren testmelding - BMKL 2.0 decentraal (b&egrave;ta-versie)" waar u als decentrale netbeheerder een testmelding kunt opvoeren

![mijnKadaster](images/NTD-Portaal-BMKL20-TestMelding.png "NTD Portaal - Testmelding")

_Figuur 2 Optie voor opvoeren testmelding - BMKL 2.0 (b&egrave;ta-versie)_

#### Opvoeren testmelding - 1 van 5

Nadat u de link "Opvoeren testmelding - BMKL 2.0 centraal (b&egrave;ta-versie)" of "Opvoeren testmelding - BMKL 2.0 decentraal (b&egrave;ta-versie)" heeft aangeklikt opent zich het 1e scherm van het opvoeren van een testmelding.

![mijnKadaster](images/NTD-Testmelding-BMKL20-1.png "NTD Portaal - Testmelding opvoeren 1")

_Figuur 3 Opvoeren testmelding - BMKL 2.0 (b&egrave;ta-versie) - scherm 1_

U maakt de keuze, of u een testcase uitvoert voor een Graafmelding, Orientatieverzoek of Calamiteitenmelding.
Kies voor een test met een Graafmelding, de meldingssoort ‘Graafmelding’. In dit voorbeeld wordt uitgegaan van een Graafmelding.

In dit scherm moet minimaal de volgende gegevens worden ingevoerd:
- _Endpoint:_ dit betreft het adres van uw eigen webservice waarop u een notificatie wilt ontvangen als er een gebiedsinformatie-aanvraag voor u als belanghebbende klaarstaat.
- _Meldingsoort:_ het soort melding; Graafmelding, Calamiteitenmelding of Orientatieverzoek
- _Gebiedspolygoon (WKT):_ de gebiedspolygoon in Well Known Text (WKT)

:information_source: De informatiepolygoon (WKT) wordt nu nog niet ondersteund / gebruikt. In een latere release zal de informatiepolygoonfunctionaliteit worden toegevoegd.

Kies daarna "Verder".

#### Opvoeren testmelding - 2 van 5

Nadat alle gegevens zijn ingevoerd en de knop "Verder" is geklikt opent zich het volgende scherm waarin u de aanvangsdatum, verwachte einddatum en graafwerkzaamheden kunt opgeven.

![mijnKadaster](images/NTD-Testmelding-BMKL20-2.png "NTD Portaal - Testmelding opvoeren 2")

_Figuur 4 Opvoeren testmelding - BMKL 2.0 (b&egrave;ta-versie) - scherm 2_

#### Opvoeren testmelding - 3 van 5

Controleer het gegeven BAG-adres en pas deze, indien nodig, aan. Selecteer Ja of Nee voor het aanvragen van huisaansluitschetsen. Indien gekozen is voor Nee, start de test.

![mijnKadaster](images/NTD-Testmelding-BMKL20-3.png "NTD Portaal - Testmelding opvoeren 3")

_Figuur 5 Opvoeren testmelding - BMKL 2.0 (b&egrave;ta-versie) - scherm 3_

Indien gekozen is om huisaansluitschetsen toe te voegen kunt u deze in het volgende scherm aanvragen.

#### Opvoeren testmelding - 4 van 5

![mijnKadaster](images/NTD-Testmelding-BMKL20-4.png "NTD Portaal - Testmelding opvoeren 4")

_Figuur 6 Opvoeren testmelding - BMKL 2.0 (b&egrave;ta-versie) - scherm 4_

In dit voorbeeld is gekozen om huisaansluitschetsen toe te voegen. U kunt deze in het volgende scherm aanvragen.
Klik nu op de button “Start test”. Dit zorgt er voor dat er een gebiedsinformatie-aanvraag wordt ingeschoten waarmee de testmelding is gedaan.

#### Opvoeren testmelding - 5 van 5

Wanneer het bericht succesvol is verzonden, verschijnt onderstaand scherm.

**Let op: vanaf het moment dat het bericht succesvol is verzonden, kan het een paar minuten duren voordat de gebiedsinformatie-aanvraag beschikbaar is.**

![mijnKadaster](images/NTD-Testmelding-BMKL20-5.png "NTD Portaal - Testmelding opvoeren 5")

_Figuur 7  Opvoeren testmelding - BMKL 2.0 (b&egrave;ta-versie) - scherm 5_

## Beheerdersinformatie en documenten aanleveren (enkel decentraal)

Beheerdersinformatie en de bijbehorende documenten worden aangeleverd in een zipbestand door de decentrale netbeheerder. Dit bestand moet voldoen aan de volgende voorwaarden:

- Het zipbestand bevat exact één bestand met de extentie `.xml`. Dit bestand bevat de beheerdersinformatie in [IMKL 2015 formaat](https://register.geostandaarden.nl/imkl2015/index.html).
- Het zipbestand mag één of meerdere PDF bestanden bevatten. Elk van deze bestanden moet gerefereerd worden vanuit het XML bestand.
- Het zipbestand mag geen mappenstructuur bevatten; alle bestanden in het zipbestand moeten op het hoogste niveau in het zipbestand opgeslagen worden.

Het aanbieden van beheerdersinformatie gaat in een aantal fases:

1. Het opvragen van openstaande beheerdersinformatie aanvragen.  
2. Het opvragen van gebiedsinformatie-aanvragen waarvoor beheerdersinformatie moet worden aangeleverd
3. Het bevestigen van een specifieke beheerdersinformatie-aanvraag, door deze te markeren als 'bevestigingOntvangen'
4. Het aanbieden van beheerdersinformatie voor de bevestigde gebiedsinformatie-aanvraag

### Beheerdersinformatie aanleveren mbv REST interface (enkel decentraal)

Voor het geautomatiseerd aanleveren van beheerdersinformatie heeft het Kadaster REST interfaces beschikbaar gesteld. De documentatie over de werking van
deze interfaces is beschikbaar in de vorm van [Swagger](http://swagger.io) specificatie. Deze documentatie is te vinden bij de “KLIC API documentatie”-applicatie.
Deze applicatie is te bereiken via de KLIC Netbeheerder Testdienst portal of via de link <https://service10.kadaster.nl/klic/ntd/api-docs/>.

De applicatie biedt een overzicht van de endpoints van de verschillende API’s en hoe deze endpoints gebruikt kunnen worden. Voor de “Beheerdersinformatie” API zijn
al deze endpoints meteen uit te proberen via de aangeboden interface. Met uitzondering van het downloaden van de aangeleverde beheerdersinformatie, deze zal via
een browsers of via CURL moeten worden uitgevoerd aangezien Swagger ZIP responses niet ondersteunt.

_De voorbeelden die hieronder zijn beschreven gaan er vanuit dat er	&eacute;&eacute;n testmelding is gedaan en er zal voor deze testmelding beheerdersinformatie worden aangeleverd._

#### De REST API voor BMKL 2.0 ondersteunt de volgende functionaliteit:

- Haal als belanghebbende netbeheerder een lijst met gebiedsinformatie-aanvragen op die voldoen aan opgegeven criteria.
- Haal als netbeheerder één gebiedsinformatie-aanvraag op.
- Haal als belanghebbende netbeheerder een lijst met beheerdersinformatie-aanvragen op die voldoen aan opgegeven criteria.
- Bevestig een beheerdersinformatie-aanvraag door deze te markeren als 'bevestigingOntvangen'.
- Lever als belanghebbende netbeheerder de beheerdersinformatie aan voor een specifieke gebiedsinformatie-aanvraag (decentraal).
- Ophalen van eerder aangeleverde beheerdersinformatie voor een specifieke gebiedsinformatie-aanvraag (decentraal).
- Haal als netbeheerder de uitgeleverde beheerdersinformatie op voor een specifieke gebiedsinformatie-aanvraag.

#### CURL

De “KLIC API Documentatie”-applicatie maakt het mogelijk om de meeste endpoints aan te roepen vanuit de browser.
In het voorbeeld in dit document wordt echter gebruik gemaakt van de command-line tool CURL (https://curl.haxx.se/). Dit heeft meer analogie met de werkwijze als een netbeheerder of serviceprovider een eigen applicatie wil ontwikkelen voor het decentraal aanleveren van beheerdersinformatie via de B2B-koppeling.
De CURL commando's worden in dit document voor de leesbaarheid weergegeven op meerdere regels. Deze commando's dienen of als één enkele regel ingevoerd te worden, of de regels dienen afgesloten te worden met een '^' (Windows) of een '\\' (Unix).

#### Swagger API Documentatie

De API Documentatie kan bereikt worden via een link op het NTD portaalscherm.

![mijnKadaster](images/NTD-Portaal-BMKL20-API-Documentatie.png "NTD Portaal - API Documentatie")

_Figuur 8 API Documentatie Link_

Het klikken van de link brengt u naar de overzichtspagina van de API Documentatie. Onder "Beheerdersinformatie" vindt u een link naar:

**API Testfaciliteit**

Een hulpmiddel om op basis van de API specificatie eenvoudig de beschikbare services uit te proberen.

**API Specificatie document**

Een beschrijving van de API volgens de OpenAPI specificatie in YAML (JSON) formaat. Dit biedt de softwareontwikkelaar een duidelijke beschrijving van de interface ten behoeve van integratie in eigen software.

![mijnKadaster](images/KLIC-API-documentatie-BMKL20.png "NTD Portaal - API Documentatie")

_Figuur 9 API Documentatie Beheerdersinformatie / BMKL 2.0_

De "API Testfaciliteit" link brengt u naar een Swagger pagina waar alle services beschreven zijn.

![mijnKadaster](images/KLIC-API-documentatie-BMKL20-detail.png "NTD Portaal - API Documentatie detail")

_Figuur 10 API Documentatie Beheerdersinformatie / BMKL 2.0 detail_

#### Gebiedsinformatie-aanvragen opvragen

**Pad**
```
GET /gebiedsinformatieAanvragen
GET /gebiedsinformatieAanvragen/{giAanvraagId}
```

**benodigde scope**
```
klic.gebiedsinformatieaanvraag.readonly
```
Het endpoint voor het opvragen van de lijst met gebiedsinformatie-aanvragen waar de betreffende netbeheerder bij betrokken is,
kan aangeroepen worden met of zonder `giaAanvraagId`. De aanroep zonder `giaAanvraagId` levert een lijst op en kan worden aangeroepen
met verschillende parameters om zo naar één specifieke, of een bepaalde set gebiedsinformatie-aanvragen te kunnen zoeken.
Het systeem haalt alle gebiedsinformatie-aanvragen op die voldoen aan de criteria en waarvoor de ingelogde gebruiker geautoriseerd is.

De aanroep met `giaAanvraagId` levert slechts 1 resultaat op, of een status `404` indien niet gevonden.

**Voorbeeld: alle gebiedsinformatie-aanvragen opvragen**
```sh
curl
 -X GET --header "Authorization: Bearer 1d021976-91c8-4b46-ab9b-529088d0f3de"
 https://service10.kadaster.nl/klic/ntd/leveren/api/v2/web/gebiedsinformatieAanvragen
```

**Voorbeeld: Eén specifieke gebiedsinformatie-aanvraag opvragen**
```sh
curl
 -X GET --header "Authorization: Bearer 1d021976-91c8-4b46-ab9b-529088d0f3de"
  https://service10.kadaster.nl/klic/ntd/leveren/api/v2/web/gebiedsinformatieAanvragen/4c8353bd-3907-40ee-84b0-5f54ac38d4d1
```

**Voorbeeld van response**
```json
{
  "aanvraagId" : "4c8353bd-3907-40ee-84b0-5f54ac38d4d1",
  "ordernummer" : "2015000924",
  "klicMeldnummer" : "17G000649",
  "aanvrager" : {
    "bedrijfsNaam" : "Netbeheerder Actualiseren02",
    "bezoekAdres" : {
      "openbareRuimteNaam" : "Laan van Westenenk",
      "huisnummer" : "701",
      "postcode" : "7334 DP",
      "woonplaatsNaam" : "APELDOORN"
    },
    "telefoon" : "0881235648",
    "fax" : "0888795641",
    "email" : "klicwin@kadaster.nl"
  },
  "opdrachtgever" : {
    "bedrijfsNaam" : "Kadaster",
    "naam" : "Kadaster",
    "bezoekAdres" : {
      "openbareRuimteNaam" : "Hofstraat",
      "huisnummer" : "110",
      "postcode" : "7311KZ",
      "woonplaatsNaam" : "Apeldoorn"
    },
    "telefoon" : "(088) 183 20 00",
    "email" : "noreply@kadaster.nl"
  },
  "aanvraagSoort" : "https://api.kadaster.nl/klic/v1/cl/aanvraagSoorten/graafmelding",
  "aanvraagDatum" : "2017-11-03T10:38:14+01:00",
  "giAanvraagStatus" : "https://api.kadaster.nl/klic/v1/cl/giAanvraagStatussen/open",
  "soortWerkzaamheden" : [ "https://api.kadaster.nl/klic/v1/cl/soortWerkzaamheden/leggenLaagspanning" ],
  "locatieWerkzaamheden" : "Laan van Westenenk 701 7334DP Apeldoorn",
  "startDatum" : "2017-11-13",
  "eindDatum" : "2017-11-22",
  "graafGebied" : {
    "type" : "Polygon",
    "crs" : {
      "type" : "name",
      "properties" : {
        "name" : "EPSG:28992"
      }
    },
    "coordinates" : [ [ [ 153606.0, 391101.0 ], [ 153594.0, 391095.0 ], [ 153602.0, 391080.0 ], [ 153622.0, 391094.0 ], [ 153606.0, 391101.0 ] ] ]
  },
  "informatieGebied" : {
    "type" : "Polygon",
    "crs" : {
      "type" : "name",
      "properties" : {
        "name" : "EPSG:28992"
      }
    },
    "coordinates" : [ [ [ 153606.0, 391101.0 ], [ 153594.0, 391095.0 ], [ 153602.0, 391080.0 ], [ 153622.0, 391094.0 ], [ 153606.0, 391101.0 ] ] ]
  }
}
```

#### Beheerdersinformatie-aanvragen opvragen

**Pad**
```sh
GET /gebiedsinformatieAanvragen/{giAanvraagId}/beheerdersinformatieAanvragen
GET /gebiedsinformatieAanvragen/{giAanvraagId}/beheerdersinformatieAanvragen/{beheerdersinformatieId}
```

**benodigde scope**
```
klic.beheerdersinformatie
of
klic.beheerdersinformatie.readonly
```

Het endpoint voor het opvragen van de lijst met beheerdersinformatie-aanvragen van de netbeheerder,
kan aangeroepen worden met of zonder `beheerdersinformatieId`. De aanroep zonder `beheerdersinformatieId` levert een lijst op en kan worden aangeroepen
met verschillende parameters om zo naar één specifieke, of een bepaalde set beheerdersinformatie-aanvragen te kunnen zoeken.
Het systeem haalt alle beheerdersinformatie-aanvragen op die voldoen aan de criteria en waarvoor de ingelogde gebruiker geautoriseerd is.

De aanroep met `beheerdersinformatieId` levert slechts 1 resultaat op, of een status `404` indien niet gevonden.

De pad-parameter `giAanvraagId` is verplicht maar mag `-` zijn. In dat geval wordt beheerdersinformatie gezocht over alle
beheerdersinformatie-aanvragen waar de netbeheerder bij betrokken is.

**Voorbeeld: open beheerdersinformatie-aanvragen opvragen**

In dit voorbeeld wordt gezocht naar alle beheerdersinformatie-aanvragen voor de ingelogde netbeheerder waarbij de productiestatus gelijk is aan "open". Hiervoor wordt de parameter `biProductieStatus` met de waarde `open` toegevoegd aan het request met de waarde `open`.
```sh
curl
 -X GET --header "Authorization: Bearer 1d021976-91c8-4b46-ab9b-529088d0f3de"
 https://service10.kadaster.nl/klic/ntd/leveren/api/v2/web/gebiedsinformatieAanvragen/-/beheerdersinformatieAanvragen?biNotificatieStatus=open
```

**Voorbeeld: Eén specifieke beheerdersinformatie-aanvraag opvragen**
```sh
curl
 -X GET --header "Authorization: Bearer 1d021976-91c8-4b46-ab9b-529088d0f3de"
 https://service10.kadaster.nl/klic/ntd/leveren/api/v2/web/gebiedsinformatieAanvragen/4c8353bd-3907-40ee-84b0-5f54ac38d4d1/beheerdersinformatieAanvragen/330d0526-0586-4843-ad86-04d8969fc768
```

**Voorbeeld van response**
```json
{
  "aanvraagId" : "4c8353bd-3907-40ee-84b0-5f54ac38d4d1",
  "beheerdersinformatieId" : "330d0526-0586-4843-ad86-04d8969fc768",
  "biNotificatieStatus" : "https://api.kadaster.nl/klic/v1/cl/biNotificatieStatussen/bevestigingOntvangen",
  "biProductieStatus" : "https://api.kadaster.nl/klic/v1/cl/biProductieStatussen/gereedVoorSamenstellenProduct",
  "datumGenotificeerd" : "2017-11-03T10:38:44+01:00",
  "datumBevestigingOntvangen" : "2017-11-03T11:05:31+01:00",
  "datumNetInformatieOntvangen" : "2017-11-03T16:23:58+01:00",
  "netInformatie" : "/klic/ntd/netbeheerdersinformatie/2017/11/03/2015000924_G/0000000051/",
  "bronhoudercode" : "nbact2"
}
```

#### Beheerdersinformatie-aanvraag bevestigen

**Pad**
```
PATCH /gebiedsinformatieAanvragen/{giAanvraagId}/beheerdersinformatieAanvragen/{beheerdersinformatieId}
```

**benodigde scope**
```
klic.beheerdersinformatie
of
klic.beheerdersinformatie.readonly
```
Voordat een netbeheerder beheerdersinformatie kan uploaden voor een gebiedsinformatie-aanvraag, moet de netbeheerder bevestigen dat hij de beheerdersinformatie-aanvraag ontvangen heeft.

**Voorbeeld:**
```sh
curl
 -X PATCH --header 'Authorization: Bearer 1d021976-91c8-4b46-ab9b-529088d0f3de'
 -d "{  \"biNotificatieStatus\": \"bevestigingOntvangen\" }"
 https://service10.kadaster.nl/klic/ntd/leveren/api/v2/web/gebiedsinformatieAanvragen/4c8353bd-3907-40ee-84b0-5f54ac38d4d1/beheerdersinformatieAanvragen/330d0526-0586-4843-ad86-04d8969fc768
```

**Response:**
```json
HTTP/1.1 200 OK
```

Voor de centrale netbeheerder wordt aanbevolen de gebiedsinformatieaanvraag te bevestigen. Als een centrale netbeheerder geen ontvangstbevestiging stuurt op een
gebiedsinformatieaanvraag, blijft deze de status 'open' houden. Het Kadaster zal ongeacht de notificatiestatus beheerdersinformatie namens de centrale
netbeheerder produceren en uitleveren.

#### Beheerdersinformatie aanleveren (enkel decentraal)

**Pad**
```
POST /gebiedsinformatieAanvragen/{giAanvraagId}/beheerdersinformatieAanvragen/{beheerdersinformatieId}/aanleveringen
```

**benodigde scope**
```
klic.beheerdersinformatie
```
Als bevestigd is dat de beheerdersinformatie-aanvraag ontvangen is, kan de beheerdersinformatie aangeleverd worden. In onderstaand voorbeeld wordt een POST request gedaan
en wordt de beheerdersinformatie in de vorm van een zipbestand aangeleverd.

**Voorbeeld:**
```sh
curl
 -X POST --header 'Authorization: Bearer 1d021976-91c8-4b46-ab9b-529088d0f3de'
 -F "netinformatie=@C:/Aanleveringen/Decentraal/nbact1/BMKL20_DECENTRAAL.zip"
 https://service10.kadaster.nl/klic/ntd/leveren/api/v2/web/gebiedsinformatieAanvragen/4c8353bd-3907-40ee-84b0-5f54ac38d4d1/beheerdersinformatieAanvragen/330d0526-0586-4843-ad86-04d8969fc768/aanleveringen
```

**Response:**
```JSON
HTTP/1.1 200 OK
```
Wanneer de ontvangst van de beheerdersinformatie-aanvraag nog niet bevestigd is verschijnt de volgende melding. De beheerdersinformatie-aanvraag moet dus
bevestigd ('bevestigingOntvangen') zijn alvorens er beheerdersinformatie kan worden aangeleverd.

**Response:**
```JSON
{
  "status" : 405,
  "meldingCode" : 1000405,
  "gebruikerMelding" : "methode niet toegestaan",
  "ontwikkelaarMelding" : "de gebiedsinformatie-aanvraag is nog niet bevestigd",
  "meerInformatie" : "http://developer.klic.nl/foutCode/1000405"
}
```


#### Opvragen gegevens aangeboden beheerdersinformatie (enkel decentraal)

**Pad**
```
GET /gebiedsinformatieAanvragen/{giAanvraagId}/beheerdersinformatieAanvragen/{beheerdersinformatieId}/aanleveringen
```

**benodigde scope**
```
klic.beheerdersinformatie
```
Wanneer u als netbeheerder beheerdersinformatie heeft aangeleverd, kunt u gegevens opvragen over de betreffende aanlevering.
Deze informatie bevat de status van de aanlevering en gegevens over de verwerking en validatie ervan. Dit gaat met een GET request naar hetzelfde
endpoint als waar de beheerdersinformatie met een POST naar toe gestuurd is.

**Voorbeeld:**
```sh
curl
 -X GET --header 'Authorization: Bearer 1d021976-91c8-4b46-ab9b-529088d0f3de'
 https://service10.kadaster.nl/klic/ntd/leveren/api/v2/web/gebiedsinformatieAanvragen/4c8353bd-3907-40ee-84b0-5f54ac38d4d1/beheerdersinformatieAanvragen/330d0526-0586-4843-ad86-04d8969fc768/aanleveringen
```

**Voorbeeld van response:**
```json
[ {
  "aanleveringId" : "3950e2eb-8942-4e6b-99ff-f4f06c5824db",
  "bronhouderCode" : "nbact2",
  "informatieSoort" : "beheerdersinformatie",
  "bestandsnaam" : "nbact2_met documenten.zip",
  "locatieInOpslag" : "beheerdersinformatie/2017/11/03/2017-11-03_16H23M53S260_9ad9ddef-221c-42ea-9e3e-6917e4de3aae_nbact2.zip",
  "netbeheerder" : "Netbeheerder Actualiseren02",
  "relatienummer" : "949094    ",
  "fileSizeInBytes" : 40955,
  "aanleverNummer" : 15,
  "aanleverDatum" : "2017-11-03T16:23:53.459",
  "aanleverStatus" : "https://klic.kadaster.nl/klic/apidocs/v1/cl/aanleverStatus/biGevalideerdZonderFouten",
  "aanleverStatusMutatieDatum" : "2017-11-03T16:23:56.829",
  "aanleverStatusHistorieList" : [ {
    "mutatieDatum" : "2017-11-03T16:23:56.829",
    "aanleverStatus" : "https://klic.kadaster.nl/klic/apidocs/v1/cl/aanleverStatus/biGevalideerdZonderFouten"
  }, {
    "mutatieDatum" : "2017-11-03T16:23:55.744",
    "aanleverStatus" : "https://klic.kadaster.nl/klic/apidocs/v1/cl/aanleverStatus/biWordtGevalideerd"
  }, {
    "mutatieDatum" : "2017-11-03T16:23:54.231",
    "aanleverStatus" : "https://klic.kadaster.nl/klic/apidocs/v1/cl/aanleverStatus/biAangeleverd"
  }, {
    "mutatieDatum" : "2017-11-03T16:23:53.470",
    "aanleverStatus" : "https://klic.kadaster.nl/klic/apidocs/v1/cl/aanleverStatus/biGestart"
  } ],
  "aanleverStapList" : [ {
    "aanleverStapAanduiding" : "https://klic.kadaster.nl/klic/apidocs/v1/cl/aanleverStapAanduiding/biAanleveren",
    "startDatum" : "2017-11-03T16:23:53.465",
    "eindDatum" : "2017-11-03T16:23:54.236",
    "stapStatus" : "succes",
    "gebruikersnaam" : "0000302112"
  }, {
    "aanleverStapAanduiding" : "https://klic.kadaster.nl/klic/apidocs/v1/cl/aanleverStapAanduiding/biValideren",
    "startDatum" : "2017-11-03T16:23:55.734",
    "eindDatum" : "2017-11-03T16:23:56.832",
    "stapStatus" : "succes",
    "gebruikersnaam" : "system"
  } ]
} ]
```

#### Uitgeleverde beheerdersinformatie opvragen

**Pad**
```
GET /gebiedsinformatieAanvragen/{giAanvraagId}/beheerdersinformatieAanvragen/{beheerdersinformatieId}/beheerdersinformatieLevering/zip
```

**benodigde scope**
```
klic.beheerdersinformatie
of
klic.beheerdersinformatie.readonly
```
Wanneer de beheerdersinformatie is aangeleverd kan de uitgeleverde beheerdersinformatie worden opgevraagd behorend bij de aangegeven gebiedsinformatie-aanvraag.

**Voorbeeld:**
```sh
curl
 -X GET --header 'Authorization: Bearer 1d021976-91c8-4b46-ab9b-529088d0f3de'
 https://service10.kadaster.nl/klic/ntd/leveren/api/v2/web/gebiedsinformatieAanvragen/4c8353bd-3907-40ee-84b0-5f54ac38d4d1/beheerdersinformatieAanvragen/330d0526-0586-4843-ad86-04d8969fc768/beheerdersinformatieLevering/zip
 > download.zip
```

**Response:**
Deze aanroep levert een zipbestand met daarin een uitlevering zoals die naar de graafmelder zou gaan, maar dan enkel met gegevens van de netbeheerder
welke bij de meegegeven `beheerdersinformatieId` hoort. Het is dus niet de volledige uitlevering zoals die gaat naar de graafmelder want het bevat geen gegevens van andere netbeheerders.

## Swagger UI ##

De link 'API Testfaciliteit' brengt u naar een overzicht van alle endpoints die in dit document beschreven zijn.
De applicatie biedt een overzicht van de endpoints van de verschillende API’s en hoe deze endpoints gebruikt kunnen worden.
Al deze endpoints zijn meteen uit te proberen via de aangeboden interface. Met uitzondering van het downloaden van de aangeleverde beheerdersinformatie, deze zal via
een browsers of via CURL moeten worden uitgevoerd aangezien Swagger ZIP responses niet ondersteunt.

### OAuth token meegeven ###

Net als in alle beschreven curl-commando's moet een OAuth-token als Authorization header meegegeven worden. In curl gaat dat via een parameter,
de Swagger-UI is een webapplicatie dus de browser moet verteld worden de header mee te geven. In Chrome kan dat door een extensie te installeren: [ModHeader](https://chrome.google.com/webstore/detail/modheader/idgpnmonknjnojddfkpgkljpfnnfcklj?hl=nl).
Wanneer de extensie geïnstalleerd is, is naast de adresbalk een icoon toegevoegd. Hierop klikken geeft onderstaand invulformulier:

![ModHeader](images/ModHeader-OAuth.png "ModHeader invulformulier voor OAuth")

_Figuur 12 ModHeader en Oauth_

Vul bij `Request Headers` "Authorization" in en als waarde "Bearer " plus het OAuth token (net als bij de curl-commandos).
Optioneel kan een filter toegevoegd worden. Een filter zorgt ervoor dat de Authorization-token alleen voor bepaalde URLs wordt meegegeven.
Dit is sterk aan te raden omdat anders andere diensten die gebruik maken van OAuth (Google-diensten bijvoorbeeld) niet meer correct zullen werken.
Om een filter toe te voegen klik op `+` en kies Filter. Selecteer `URL Pattern` en vul een patroon in dat uniek is voor de B2B-koppeling,
bijvoorbeeld "*/gebiedsinformatieAanvragen*". (dit betekent dat ieder URL waarin "/gebiedsinformatieAanvragen" voorkomt de Authorization-header meegestuurd krijgt)

Zonder Authorization-header zal iedere klik op `Try it out!` leiden tot een HTML-pagina met de melding: "Kadaster - Niet geauthenticeerd".

**Procesmodel BMKL 2.0 (decentrale netbeheerder)**

![procesmodel](images/Produceren-volgens-BMKL2.0-decentraal.png "Procesmodel BMKL 2.0 (decentrale netbeheerder)")

**Procesmodel BMKL 2.0 (centrale netbeheerder)**

![procesmodel](images/Produceren-volgens-BMKL2.0-centraal.png "Procesmodel BMKL 2.0 (centrale netbeheerder)")
