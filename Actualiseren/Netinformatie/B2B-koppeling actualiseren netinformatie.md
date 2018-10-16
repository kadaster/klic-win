# B2B-koppeling actualiseren netinformatie

Dit document biedt een handleiding voor het actualiseren van netinformatie in de centrale voorziening van KLIC met behulp van de B2B-koppeling.

**Inhoudsopgave**

- [Leeswijzer](#leeswijzer)
- [Actualiseren van netinformatie](#actualiseren-van-netinformatie)
  - [Zipbestand](#zipbestand)
- [Gebruik KLIC API's](#gebruik-klic-apis)
  - [REST interfaces](#rest-interfaces)
  - [Endpoints](#endpoints)
  - [Authenticatie](#authenticatie)
  - [_Accept_ header](#accept-header)
  - [Rechten in Mijn Kadaster](#rechten-in-mijn-kadaster)
  - [CURL](#curl)
  - [KLIC API Documentatie](#klic-api-documentatie)
- [Gebruik Swagger UI](#gebruik-swagger-ui)
- [Overzicht KLIC API's voor actualiseren netinformatie](#overzicht-klic-apis-voor-actualiseren-netinformatie)
  - [Netbeheerders en serviceproviders](#netbeheerders-en-serviceproviders)
  - [Netinformatie aanleveren](#netinformatie-aanleveren)
    - [Aanlevering aanmelden](#aanlevering-aanmelden)
    - [Data versturen](#data-versturen)
    - [Data in fragmenten aanleveren](#data-in-fragmenten-aanleveren)
    - [Aanlevering hervatten](#aanlevering-hervatten)
  - [Aanleveringen raadplegen](#aanleveringen-raadplegen)
    - [Lijst van aanleveringen](#lijst-van-aanleveringen)
    - [Individuele aanlevering](#individuele-aanlevering)
  - [Aanlevering goedkeuren/afkeuren/annuleren](#aanlevering-goedkeurenafkeurenannuleren)

---------------------------------------------------------
## Leeswijzer

Dit document beschrijft de inhoud van het zipbestand met de netinformatie en de procedure voor het aanleveren en verwerken van dit zipbestand.

In de sectie [Zipbestand](#zipbestand) wordt de inhoud van het zipbestand toegelicht.

Om netinformatie aan te kunnen leveren zijn er bepaalde rechten nodig. In deze documentatie gaan we uit van een aanlevering van netinformatie in de NTD omgeving. De sectie [Rechten in Mijn Kadaster](#rechten-in-mijn-kadaster) beschrijft hoe gecontroleerd kan worden of de gebruiker over de benodigde rechten beschikt.

De sectie [REST interfaces](#rest-interfaces) beschrijft de verschillende componenten van de REST API’s voor het actualiseren van netinformatie in de centrale voorziening van KLIC. Voor het actualiseren van netinformatie is er geen beperking op de grootte van het aangeleverde zipbestand, maar het aanleverproces verschilt voor kleine en grotere bestanden. Voor het aanleveren van een zipbestand van 34 Mb of kleiner kunnen achtereenvolgens de volgende secties doorlopen worden:

-   [Authenticatie](#authenticatie)
-   [Netbeheerders en serviceproviders](#netbeheerders-en-serviceproviders)
-   [Endpoints](#endpoints)
-   [Netinformatie aanleveren](#netinformatie-aanleveren)
    -   [Aanlevering aanmelden](#aanlevering-aanmelden)
    -   [Data versturen](#data-versturen)
-   [Aanleveringen raadplegen](#aanleveringen-raadplegen)
    -   [Lijst van aanleveringen](#lijst-van-aanleveringen)
    -   [Individuele aanlevering](#individuele-aanlevering)
-   [Aanlevering goedkeuren/afkeuren/annuleren](#aanlevering-goedkeurenafkeurenannuleren)

Voor aanleveringen van een zipbestand groter dan 34 Mb moet naast de sectie [Data versturen](#data-versturen) ook de sectie [Data in fragmenten aanleveren](#data-in-fragmenten-aanleveren) doorgenomen worden.

De sectie [Aanlevering hervatten](#aanlevering-hervatten) beschrijft hoe een aanlevering hervat kan worden wanneer er tijdens het uploaden onverhoopt iets fout gaat.

---------------------------------------------------------
## Actualiseren van netinformatie

Netinformatie in de centrale voorziening kan worden geactualiseerd door deze aan te leveren in een zipbestand.

Dit zipbestand bevat een XML-bestand met daarin de netinformatie. De sectie [Zipbestand](#zipbestand) beschrijft de inhoud van het zipbestand.

Het actualiseren van netinformatie gaat in een aantal fases:

1.  Het aanmelden van een aanlevering. Dit gaat door middel van een request naar de “Netinformatie API” waardoor een aanlevering geïnitieerd wordt.
2.  Het verzenden van het zipbestand naar het Kadaster. Dit gaat door middel van één of meerdere requests naar de “Upload servlet” API waarin de daadwerkelijke bytes van het zipbestand verstuurd worden.
3.  Het beoordelen van de aanlevering. Een aanlevering die gevalideerd is zonder fouten kan door de netbeheerder/serviceprovider beoordeeld worden op basis van de beschikbare statistieken en goed- of afgekeurd worden door middel van verschillende requests naar de “Netinformatie API”.

Al deze fases worden doorlopen in de sectie [REST interfaces](#rest-interfaces).

### Zipbestand

De voorwaarden waaraan het zipbestand en de netinformatie daarin moeten voldoen staan [hier](https://github.com/kadaster/klic-win/blob/master/Toepassing%20IMKL/Toelichting%20controles%20netinformatie%20KLIC.md).

Zie hieronder een voorbeeld.
```xml
<?xml version="1.0" encoding="UTF-8" standalone="no"?>
<gml:FeatureCollection xmlns:gml="http://www.opengis.net/gml/3.2" xmlns:base="http://inspire.ec.europa.eu/schemas/base/3.3" xmlns:base2="http://inspire.ec.europa.eu/schemas/base2/2.0" xmlns:imkl="http://www.geostandaarden.nl/imkl/2015/wion/1.1" xmlns:net="http://inspire.ec.europa.eu/schemas/net/4.0" xmlns:us-net-common="http://inspire.ec.europa.eu/schemas/us-net-common/4.0" xmlns:us-net-el="http://inspire.ec.europa.eu/schemas/us-net-el/4.0" xmlns:us-net-ogc="http://inspire.ec.europa.eu/schemas/us-net-ogc/4.0" xmlns:us-net-sw="http://inspire.ec.europa.eu/schemas/us-net-sw/4.0" xmlns:us-net-tc="http://inspire.ec.europa.eu/schemas/us-net-tc/4.0" xmlns:us-net-th="http://inspire.ec.europa.eu/schemas/us-net-th/4.0" xmlns:us-net-wa="http://inspire.ec.europa.eu/schemas/us-net-wa/4.0" xmlns:xlink="http://www.w3.org/1999/xlink" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" gml:id="ID_1c0c5554-5c4a-467a-a9ef-9f36b5af2bfq" xsi:schemaLocation="http://www.geostandaarden.nl/imkl/2015/wion/1.1 IMKL2015-wion.xsd">
    <gml:featureMember>
        <imkl:Utiliteitsnet gml:id="nl.imkl-KL9999.00001">
            <us-net-common:utilityNetworkType xlink:href="http://inspire.ec.europa.eu/codelist/UtilityNetworkTypeValue/water"/>
            <us-net-common:authorityRole/>
            <imkl:identificatie>
                <imkl:NEN3610ID>
                    <imkl:namespace>nl.imkl</imkl:namespace>
                    <imkl:lokaalID>KL9999.00001</imkl:lokaalID>
                </imkl:NEN3610ID>
            </imkl:identificatie>
            <imkl:beginLifespanVersion>2001-12-17T09:30:47+01</imkl:beginLifespanVersion>
            <imkl:thema xlink:href="http://definities.geostandaarden.nl/imkl2015/id/waarde/Thema/water"/>
            <imkl:standaardDieptelegging uom="urn:ogc:def:uom:OGC::m">0.63</imkl:standaardDieptelegging>
        </imkl:Utiliteitsnet>
    </gml:featureMember>
    <gml:featureMember>
        <imkl:Waterleiding gml:id="nl.imkl-KL9999.00002">
            <net:beginLifespanVersion>2001-12-17T09:30:47+01</net:beginLifespanVersion>
            <net:inspireId>
                <base:Identifier>
                    <base:localId>KL9999.00002</base:localId>
                    <base:namespace>nl.imkl</base:namespace>
                </base:Identifier>
            </net:inspireId>
            <net:inNetwork xlink:href="nl.imkl-KL9999.00001"/>
            <net:link xlink:href="nl.imkl-KL9999.00003"/>
            <us-net-common:currentStatus xlink:href="http://inspire.ec.europa.eu/codelist/ConditionOfFacilityValue/functional"/>
            <us-net-common:validFrom>2001-12-17T09:30:47+01</us-net-common:validFrom>
            <us-net-common:validTo>2099-12-31T23:59:59+01</us-net-common:validTo>
            <us-net-common:verticalPosition>underground</us-net-common:verticalPosition>
            <us-net-common:warningType xlink:href="http://inspire.ec.europa.eu/codelist/WarningTypeValue/net"/>
            <us-net-common:pipeDiameter uom="urn:ogc:def:uom:OGC::cm">10</us-net-common:pipeDiameter>
            <us-net-common:pressure uom="urn:ogc:def:uom:OGC::bar">2</us-net-common:pressure>
            <us-net-wa:waterType xlink:href="http://inspire.ec.europa.eu/codelist/WaterTypeValue/potable"/>
        </imkl:Waterleiding>
    </gml:featureMember>
    <gml:featureMember>
        <us-net-common:UtilityLink gml:id="nl.imkl-KL9999.00003">
            <net:beginLifespanVersion>2001-12-17T09:30:47+01</net:beginLifespanVersion>
            <net:inspireId>
                <base:Identifier>
                    <base:localId>KL9999.00003</base:localId>
                    <base:namespace>nl.imkl</base:namespace>
                </base:Identifier>
            </net:inspireId>
            <net:inNetwork xlink:href="nl.imkl-KL9999.00001"/>
            <net:centrelineGeometry>
                <gml:LineString gml:id="Line_1" srsName="http://spatialreference.org/ref/epsg/28992/">
                    <gml:posList>154302.227 387498.753 153792.245 388647.008</gml:posList>
                </gml:LineString>
            </net:centrelineGeometry>
            <net:fictitious>false</net:fictitious>
            <us-net-common:currentStatus xlink:href="http://inspire.ec.europa.eu/codelist/ConditionOfFacilityValue/functional"/>
            <us-net-common:validFrom>2001-12-17T09:30:47+01</us-net-common:validFrom>
            <us-net-common:verticalPosition xsi:nil="true" nilReason="Unknown"/>
        </us-net-common:UtilityLink>
    </gml:featureMember>
</gml:FeatureCollection>
```
_Figuur 2 - Voorbeeld netinformatie.xml_

---------------------------------------------------------
## Gebruik KLIC API's

### REST interfaces

Voor het geautomatiseerd actualiseren van netinformatie heeft het Kadaster REST interfaces beschikbaar gesteld.  \
De documentatie over de werking van deze interfaces is beschikbaar in de vorm van Swagger specificatie. Deze documentatie is te vinden bij de “KLIC API documentatie”-applicatie die in de Netbeheerder Testdienst beschikbaar wordt gesteld.

De applicatie biedt een overzicht van de endpoints van de verschillende API’s en hoe deze endpoints gebruikt kunnen worden. Voor de “Netinformatie” API zijn al deze endpoints meteen uit te proberen via de aangeboden interface.  \
Voor de “Upload servlet” API is de PUT operatie niet uit te voeren vanuit de browser.

### Endpoints

De endpoints die gebruikt worden in dit document zijn relatief ten opzichte van de betreffende API’s.  \
De service "/aanleveringen/netinformatie" wordt bijvoorbeeld voluit
- voor de productieomgeving KLIC:  \
  "https://service10.kadaster.nl/klic/api/v2/aanleveringen/netinformatie"
- voor de Netbeheerder Testdienst (NTD):  \
  "https://service10.kadaster.nl/klic/ntd/actualiseren/api/v2/web/aanleveringen/netinformatie"

De API voor het (in fragmenten) uploaden van data ("Upload servlet") bevindt zich
- voor de productieomgeving KLIC:  \
  "https://service10.kadaster.nl/klic/api/v2/web/netinformatie/upload"
- voor de Netbeheerder Testdienst (NTD):  \
  "https://service10.kadaster.nl/klic/ntd/actualiseren/api/v2/web/netinformatie/upload"
	
Het OAuth Authorization endpoint voor de productie-omgevingen is:
- "https://authorization.kadaster.nl/auth/oauth/v2/"

In de voorbeelden in deze documentatie wordt uitgegaan van de API's op de NTD-omgeving.

### Authenticatie

De KLIC REST API's zijn beveiligd middels de OAuth 2.0 specificatie. Zie daarvoor [Authenticatie via OAuth](../../API%20management/Authenticatie_via_oauth.md).  \
De benodigde scope voor het actualiseren van netinformatie is `klic.centraal`.

### _Accept_ header

Wanneer je een KLIC API met een verlopen/ongeldige token gebruikt, dan is het response met foutmelding erin per default in HTML-formaat.  \
Vanuit een client-applicatie is het veelal gewenst om het response-bericht in JSON-formaat terug te krijgen. Om zeker te stellen dat dit formaat wordt teruggegeven, moet een _Accept_-header worden meegegeven in het request.  \
Voorbeeld:

**Request**  
```sh
curl https://service10.kadaster.nl/klic/ntd/actualiseren/api/v2/web/aanleveringen/netinformatie/netbeheerder
 -v
 -X POST
 -H 'Authorization: Bearer 9e25ab45-82a4-4f9e-8bf6-b9ef0eb7568e'
 -H 'Accept: application/json'
 -H 'Content-Type: application/json'
 -H 'X-Upload-Content-Length: 1366'
 -H 'X-Upload-Content-Type: application/zip'
 -H 'X-Upload-Filename: niAanlevering.zip'
```
**Response:**  (indien toegang geweigerd)
```json
{
    "error": "Kadaster - Niet geauthenticeerd.",
    "error_description": "Toegang tot de dienst Klic Online is alleen voor geauthenticeerde gebruikers. "
}
```  
Bij een HTTP 200 response, wordt de response wél in JSON-formaat teruggegeven.

### Rechten in Mijn Kadaster

Om te verifiëren of een gebruiker rechten heeft om een aanlevering te kunnen doen, moet deze eerst inloggen in "Mijn Kadaster". Gecontroleerd kan worden of de gebruiker toegang heeft tot de gewenste dienst: "Klic Netbeheerder Testdienst" (kortweg NTD) of "Klic Actualiseren netinformatie".

![Figuur 3](images/image2.png "Figuur 3 - Toegang tot de Klic Netbeheerder Testdienst vanuit Mijn Kadaster")  \
_Figuur 3 - Toegang tot de Klic Netbeheerder Testdienst vanuit Mijn Kadaster_

Figuur 3 toont de home pagina van Mijn Kadaster van een gebruiker die toegang heeft tot de Klic Netbeheerder Testdienst.

### CURL

De “KLIC API Documentatie”-applicatie maakt het mogelijk om de meeste endpoints aan te roepen vanuit de browser.
In het voorbeeld in dit document wordt echter gebruik gemaakt van de command-line tool CURL (https://curl.haxx.se/). Dit heeft meer analogie met de werkwijze als een netbeheerder of serviceprovider een eigen applicatie wil ontwikkelen voor het decentraal aanleveren van beheerdersinformatie via de B2B-koppeling. \
De CURL-commando's worden in dit document voor de leesbaarheid weergegeven op meerdere regels. Deze commando's dienen of als één enkele regel ingevoerd te worden, of de regels dienen afgesloten te worden met een '^' (Windows) of een '\\' (Unix).

### KLIC API Documentatie

Om de “KLIC API documentatie”-applicatie te openen, moet de gebruiker ingelogd zijn in Mijn Kadaster (zie de sectie [Rechten in Mijn Kadaster](#rechten-in-mijn-kadaster)). Vervolgens kan bovenstaande link gekopieerd worden naar het tabblad waarin de gebruiker is ingelogd in Mijn Kadaster.

![Figuur 4](images/KLIC-API-documentatie-actualiseren.png "Figuur 4 - home pagina van de KLIC API documentatie applicatie")
_Figuur 4 - home pagina van de KLIC API netinformatie applicatie_

De “KLIC API documentatie”-applicatie maakt het mogelijk om de meeste endpoints aan te roepen vanuit de browser.

In het voorbeeld in dit document wordt echter gebruik gemaakt van de command-line tool CURL (<https://curl.haxx.se/>). Dit heeft meer analogie met de werkwijze als een netbeheerder of serviceprovider een eigen applicatie wil ontwikkelen voor het actualiseren van netinformatie via de B2B-koppeling.

In dit voorbeeld wordt een bestand aangeleverd voor de netbeheerder “Kadaster KLIC-WIN” met de bronhouder “KL9999”. Dit gebeurt op de NTD-omgeving en er wordt dan ook gebruik gemaakt van de documentatie onder de kop “NTD” zoals te zien in Figuur 4.

Voor het actualiseren van netinformatie worden voornamelijk operaties gebruikt van de “Netinformatie” API, behalve voor het versturen van data van het aan te leveren bestand. In dat geval wordt er gebruik gemaakt van de “Upload servlet” API.

---------------------------------------------------------
## Gebruik Swagger UI ##

De link 'API Testfaciliteit' in de KLIC API-documentatie brengt u naar een overzicht van alle endpoints die in dit document beschreven zijn.
Al deze endpoints zijn meteen uit te proberen via de aangeboden interface. Met uitzondering van de upload-operaties van de "Upload servlet" voor het aanleveren van een bestand.

### OAuth token meegeven ###

Net als in alle beschreven CURL-commando's moet een OAuth-token als Authorization header meegegeven worden. In CURL gaat dat via een parameter,
de Swagger-UI is een webapplicatie dus de browser moet verteld worden de header mee te geven. In Chrome kan dat door een extensie te installeren: [ModHeader](https://chrome.google.com/webstore/detail/modheader/idgpnmonknjnojddfkpgkljpfnnfcklj?hl=nl).
Wanneer de extensie geïnstalleerd is, is naast de adresbalk een icoon toegevoegd. Hierop klikken geeft onderstaand invulformulier:

![Figuur 15](images/ModHeader-OAuth.png "Figuur 15 - ModHeader invulformulier voor OAuth")

Vul bij `Request Headers` "Authorization" in en als waarde "Bearer " plus het OAuth token (net als bij de CURL-commandos).
Optioneel kan een filter toegevoegd worden. Een filter zorgt ervoor dat de Authorization-token alleen voor bepaalde URLs wordt meegegeven.
Dit is sterk aan te raden omdat anders andere diensten die gebruik maken van OAuth (Google-diensten bijvoorbeeld) niet meer correct zullen werken.
Om een filter toe te voegen klik op `+` en kies Filter. Selecteer `URL Pattern` en vul een patroon in dat uniek is voor de B2B-koppeling,
bijvoorbeeld "*/klic/ntd/*". (dit betekent dat ieder URL waarin "/klic/ntd/" voorkomt de Authorization-header meegestuurd krijgt)

Zonder Authorization-header zal iedere klik op `Try it out!` leiden tot een HTML-pagina met de melding: "Kadaster - Niet geauthenticeerd".

---------------------------------------------------------
## Overzicht KLIC API's voor actualiseren netinformatie

### Netbeheerders en serviceproviders

De REST interfaces kennen verschillende endpoints voor netbeheerders en voor serviceproviders. Serviceproviders moeten in de URL van het endpoint dat ze aanroepen de bronhoudercode opnemen van de netbeheerder waarvoor zij de betreffende operatie willen uitvoeren. In de documentatie zijn deze endpoints te herkennen aan de parameter "{bronhoudercode}".

In dit voorbeeld wordt uitgegaan van een netbeheerder die zelf een aanlevering doet. Er wordt dus geen gebruik gemaakt van de endpoints met "{bronhoudercode}" erin.

### Netinformatie aanleveren

Het bestand dat eerder beschreven werd in de sectie [Zipbestand](#zipbestand), wordt nu aangeleverd. Dit is een bestand voor de bronhouder KL9999 en wordt aangeleverd door de bronhouder (netbeheerder) zelf.

Het aanleveren van een zipbestand gaat in twee fases:

1.  Het aanmelden van een aanlevering van netinformatie.  \
Dit gaat door middel van een POST request naar de “Netinformatie API”. Het response op dit request bevat een header “Location” met daarin een URI naar de “Upload servlet API” waarnaar de data verzonden kan worden.  \
In de body van het response worden tevens gegevens over de aanlevering teruggegeven (o.a. 'aanleveringId').  \
NB. Feitelijk zorgt de API er voor dat de aanlevering wordt aangemeld bij de "Upload servlet API" zoals beschreven in de sectie "Uploaden" van de KLIC API Documentatie.  \
Hierbij wordt de "Upload servlet" aangeroepen met de parameter "/netinformatie/upload/init"

2.  Het verzenden van de data naar het Kadaster.  \
Dit gaat door middel van één of meerder PUT requests naar de “Upload servlet” API waarin de daadwerkelijke bytes van het zipbestand verstuurd worden.

#### Aanlevering aanmelden

Het aanmelden van de aanlevering gaat met een POST request naar het endpoint */aanleveringen/netinformatie/netbeheerder*.

![Figuur 5](images/ni-init-upload.png "Figuur 5 - Swagger-UI voor het uitvoeren van een POST request naar /aanleveringen/netinformatie/netbeheerder")
_Figuur 5 - Swagger-UI voor het uitvoeren van een POST request naar /aanleveringen/netinformatie/netbeheerder_

Figuur 5 toont de Swagger-UI voor het aanmelden van een aanlevering. Dit endpoint kent een aantal parameters die als header meegestuurd moeten worden. De dikgedrukte parameters zijn verplicht, de andere parameter is optioneel.

De parameters zijn ingevuld met gegevens voor het aan te leveren bestand, “aanlevering.zip”. Dit is een klein voorbeeldbestand van in totaal 32107 bytes groot. Deze parameters vertalen zich naar het volgende CURL-commando:

**Request**  
```sh
curl https://service10.kadaster.nl/klic/ntd/actualiseren/api/v2/web/aanleveringen/netinformatie/netbeheerder
 -v
 -X POST
 -H 'Authorization: Bearer 9e25ab45-82a4-4f9e-8bf6-b9ef0eb7568e'
 -H 'Accept: application/json'
 -H 'Content-Type: application/json'
 -H 'X-Upload-Content-Length: 1366'
 -H 'X-Upload-Content-Type: application/zip'
 -H 'X-Upload-Filename: niAanlevering.zip'
```
**Response:**  
```
HTTP/1.1 200 OK
Location: https://service10.kadaster.nl/klic/ntd/actualiseren/api/v2/web/netinformatie/upload/upload?upload_id=57eca5b8-543b-4f42-b4d4-e52bed10ab84
```  
_Figuur 6 - Het CURL-commando voor het aanmelden van een aanlevering en een deel van de response_

In de body van de response worden kenmerkende gegevens over de aanlevering teruggegeven.  \
Om dit response (met zekerheid) in json-formaat terug te krijgen, moet dit in de header van het request worden meegegeven als 'Content-Type: application/json'.

Voorbeeld:
```json
[{
	"aanleveringId": "a77aff2b-c794-4ad3-a021-7c1a29096770",
	"bronhouderCode": "KL9999",
	"informatieSoort": "netinformatie",
	"bestandsnaam": "niAanlevering.zip",
	"netbeheerder" : "Kadaster KLIC-WIN",
	"fileSizeInBytes": 34097,
	"aanleverNummer": 15,
	"aanleverDatum": "2017-01-12T08:41:48.665",
	"aanleverStatus": "https://klic.kadaster.nl/klic/apidocs/v1/cl/aanleverStatus/niGestart"
}]
```
Bovenstaand voorbeeld laat de attributen van het response-bericht zien, zoals deze er in versie 2 uit gaat zien.

> **N.B.** De CURL-commando's worden in dit document voor de leesbaarheid weergegeven op meerdere regels. Deze commando's dienen of als één enkele regel ingevoerd te worden, of de regels dienen afgesloten te worden met een '^' (Windows) of een '\\' (Unix).

Figuur 6 toont het CURL-commando en het resultaat van het request. De response code 200 geeft aan dat het request succesvol verwerkt is. Een belangrijke parameter in de response is de header “Location”. Dit is een endpoint in de “Upload servlet” API waarnaar het zipbestand geüpload moet worden.

#### Data versturen

Figuur 7 toont de Swagger-UI voor een PUT request naar het */upload* endpoint van de “Upload servlet” API. Het veld "body" is in dit overzicht niet gevuld omdat de Swagger-UI interface geen binaire data ondersteunt. Dit endpoint kan dan ook niet getest worden vanuit de Swagger-UI.

De documentatie van dit endpoint toont een aantal parameters:

**upload\_id** – het identificerend gegeven van een specifieke upload. Dit is een URL parameter en onderdeel van de URL die in de “Location” header teruggegeven is bij het aanmelden van de aanlevering (zie sectie [Aanlevering aanmelden](#aanlevering-aanmelden)).

**Content-Range** – De bytes die aangeleverd gaan worden. De upload servlet ondersteunt de mogelijkheid om een bestand in meerdere fragmenten aan te leveren (zie sectie [Data in fragmenten aanleveren](#data-in-fragmenten-aanleveren)). In dit geval wordt het bestand in één keer aangeleverd. Het formaat van deze parameter is `bytes <van>-<tot>/<totaal>`. In dit geval is het bestand 1405 bytes lang. De eerste byte is byte 0, en de laatste byte 1404.

> **N.B.** Dit endpoint ondersteunt PUT requests met een body van maximaal **34 Mb** groot. Aanleveringen van zipbestanden groter dan **34 Mb** dienen verdeeld te worden over meerdere PUT requests. Zie hiervoor de sectie [Data in fragmenten aanleveren](#data-in-fragmenten-aanleveren).

**Content-Length** – Het aantal bytes in de body van het request. In dit geval komt dat overeen met de grootte van het bestand; 1366 bytes.

**body** – De inhoud van het request. Hier worden de bytes van het aan te leveren bestand in meegegeven.

![Figuur 7](images/image7.png "Figuur 7 - Swagger-UI voor het uitvoeren van een PUT request naar /upload")
_Figuur 7 - Swagger-UI voor het uitvoeren van een PUT request naar /upload_

De parameters vertalen zich naar het volgende CURL-commando:

**Request**  
```sh
curl https://service10.kadaster.nl/klic/ntd/actualiseren/api/v2/web/netinformatie/upload/upload?upload_id=57eca5b8-543b-4f42-b4d4-e52bed10ab84
 -v
 -X PUT
 -H 'Authorization: Bearer 9e25ab45-82a4-4f9e-8bf6-b9ef0eb7568e'
 -H 'Accept: application/json'
 -H 'Content-Type: application/octet-stream&quot'
 -H 'Content-Length: 1366'
 -H 'Content-Range: bytes 0-1365/1366'
 --data-binary @'D:\niAanlevering.zip'
```  
**Response:**  
```
HTTP/1.1 200 OK
Range: bytes=0-1365
```  
_Figuur 8 - CURL-commando en het response voor het versturen van data_

> **N.B.** De CURL-commando's worden in dit document voor de leesbaarheid weergegeven op meerdere regels. Deze commando's dienen of als één enkele regel ingevoerd te worden, of de regels dienen afgesloten te worden met een '^' (Windows) of een '\\' (Unix).

Wanneer het request succesvol verwerkt wordt, geeft de server een 200 OK response en de range aan bytes die ontvangen is voor deze upload. Deze **Range** header wordt uitgebreid besproken in de sectie [Aanlevering hervatten](#aanlevering-hervatten).

#### Data in fragmenten aanleveren

Er is voor het aanleveren van netinformatie geen limiet op het formaat van het zipbestand. Echter, er zit wel een maximum op het aantal bytes dat per keer verstuurd kan worden naar het Kadaster. Dit is maximaal 34 Mb per request. Voor zipbestanden groter dan 34 Mb moet het bestand dus in fragmenten aangeleverd worden. De aanmelding van de aanlevering gaat zoals beschreven in de sectie [Aanlevering aanmelden](#aanlevering-aanmelden). Hierbij moet als **X-Upload-Content-Length** de grootte van het volledige zipbestand opgegeven worden.

Voor elke fragment van het bestand moet er een request verstuurd worden, zoals beschreven in de sectie [Data versturen](#data-versturen), met de volgende parameters:

| Parameter      | Waarde                           | Omschrijving                                                                                                                                                                                                                                                              |
|----------------|----------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Content-Type   | application/octet-stream         | Deze parameter is voor ieder request hetzelfde.                                                                                                                                                                                                                           |
| Content-Length | 1405                             | De lengte van de body van het request. Deze waarde verschilt per request.                                                                                                                                                                                                 |
| Content-Range  | bytes \<van\>-\<tot\>/\<totaal\> | De reeks bytes ten opzichte van het totaal aantal bytes van het aan te leveren zipbestand. De bytes zijn zero-indexed, dat wil zeggen dat de eerste byte, byte 0 is. De eerste 10 bytes van een bestand van 10 bytes groot wordt dus als volgt aangeduid: “bytes 0-9/10”. |
| Body           | \<bytes\>                        | De body van het request bevat de bytes van het betreffende fragment.                                                                                                                                                                                                       |

Wanneer er bijvoorbeeld een bestand aangeleverd wordt van 80.000.000 bytes (~76 Mb), dan kan dat in 3 fragmenten, met de volgende parameters:

| Content-Length | Content-Range                    |
|----------------|----------------------------------|
| 30000000       | bytes 0-29999999/80000000        |
| 30000000       | bytes 30000000-59999999/80000000 |
| 20000000       | bytes 60000000-79999999/80000000 |

#### Aanlevering hervatten

Ieder PUT request naar het */upload* endpoint van de “Upload servlet” API bevat in het response de **Range** header. Deze header bevat een aanduiding van de reeks aan bytes die door het Kadaster ontvangen is. In het voorbeeld in de sectie [Data in fragmenten aanleveren](#data-in-fragmenten-aanleveren), waarbij 80.000.000 bytes in 3 requests verstuurd worden naar het Kadaster, zou deze header na elk request achtereenvolgens de waarden bevatten: “0-29999999”, “0-59999999”, “0-79999999”.

Deze header maakt het ook mogelijk om een upload te hervatten wanneer er - om wat voor reden dan ook - iets fout gaat. Om de status van een upload op te vragen kan er een PUT request zonder body verstuurd worden naar het */upload* endpoint. In dit request heeft de parameter **Content-Length** de waarde “0” en de parameter **Content-Range** een waarde in de vorm “bytes \*/&lt;totaal&gt;”.

**Request**  
```sh
curl https://service10.kadaster.nl/klic/ntd/actualiseren/api/v2/web/netinformatie/upload/upload?upload_id=57eca5b8-543b-4f42-b4d4-e52bed10ab84
 -v
 -X PUT
 -H 'Authorization: Bearer 9e25ab45-82a4-4f9e-8bf6-b9ef0eb7568e'
 -H 'Accept: application/json'
 -H 'Content-Type: application/octet-stream'
 -H 'Content-Length: 0'
 -H 'Content-Range: bytes */1366'
 --data-binary @'D:\niAanlevering.zip'
```
**Response:**  
```
HTTP/1.1 200 OK
Range: bytes=0-1365
```  
_Figuur 9 - CURL-commando voor het ophalen van de status van een upload_

> **N.B.** De CURL-commando's worden in dit document voor de leesbaarheid weergegeven op meerdere regels. Deze commando's dienen of als één enkele regel ingevoerd te worden, of de regels dienen afgesloten te worden met een '^' (Windows) of een '\\' (Unix).

Wanneer nog niet alle bytes van een zipbestand ontvangen zijn, kan aan de **Range** header afgeleid worden vanaf welke byte de draad weer opgepakt kan worden.

### Aanleveringen raadplegen

De “Netinformatie” API biedt een aantal endpoints voor het raadplegen van de aanleveringen.

#### Lijst van aanleveringen

Het endpoint */aanleveringen/netinformatie/netbeheerder* levert een lijst van aanleveringen van de netbeheerder op. Deze lijst is gepagineerd, dat wil zeggen dat de totale lijst van aanleveringen opgedeeld is in pagina’s. Per request wordt er één pagina met aanleveringen teruggegeven. Standaard bevat een pagina 5 aanleveringen en wordt de eerste pagina teruggegeven. Dit kan door middel van de optionele parameters **page** en **size** aangepast worden. De paginanummering begint bij pagina 1 (dus niet bij 0) en de maximale paginagrootte (**size**) is 15.

**Request**  
```sh
curl https://service10.kadaster.nl/klic/ntd/actualiseren/api/v2/web/aanleveringen/netinformatie/netbeheerder
 -H 'Authorization: Bearer 9e25ab45-82a4-4f9e-8bf6-b9ef0eb7568e'
 -H 'Accept: application/json'
```  
_Figuur 10 - CURL-commando voor het opvragen van een lijst van aanleveringen_

Het response van dit request is weergegeven in Figuur 11. In deze afbeelding is voor het overzicht een aantal aanleveringen weggelaten.

```json
{
  "link": [
    {
      "rel": "first",
      "href": "https://service10.kadaster.nl/klic/ntd/actualiseren/api/v2/web/aanleveringen/netinformatie/netbeheerder?page=1&size=5"
    },
    {
      "rel": "self",
      "href": "https://service10.kadaster.nl/klic/ntd/actualiseren/api/v2/web/aanleveringen/netinformatie/netbeheerder"
    },
    {
      "rel": "next",
      "href": "https://service10.kadaster.nl/klic/ntd/actualiseren/api/v2/web/aanleveringen/netinformatie/netbeheerder?page=2&size=5"
    },
    {
      "rel": "last",
      "href": "https://service10.kadaster.nl/klic/ntd/actualiseren/api/v2/web/aanleveringen/netinformatie/netbeheerder?page=3&size=5"
    }
  ],
  "content": [
    {
	  "aanleveringId": "a77aff2b-c794-4ad3-a021-7c1a29096770",
	  "bronhouderCode": "KL9999",
	  "informatieSoort": "netinformatie",
	  "bestandsnaam": "niAanlevering.zip",
	  "netbeheerder" : "Kadaster KLIC-WIN",
	  "fileSizeInBytes": 34097,
	  "aanleverNummer": 15,
	  "aanleverDatum": "2017-01-12T08:41:48.665",
	  "aanleverStatus": "https://klic.kadaster.nl/klic/apidocs/v1/cl/aanleverStatus/niTerBeoordeling",
	  "aanleverStatusMutatieDatum": "2017-01-12T08:41:54.755",
      "link": []
    }
    
   /* ... */
   
  ],
  "page": {
    "size": 5,
    "totalElements": 15,
    "totalPages": 3,
    "number": 0
  }
}
```  
_Figuur 11 - Response body met een lijst van aanleveringen_

Per aanlevering is er een JSON object met daarin de basisgegevens van een aanlevering en de actuele status. In Figuur 11 is te zien dat de aanlevering die zojuist gedaan is, de status “Gereed voor handmatige controle” heeft gekregen. Voor deze aanlevering kunnen de details opgehaald worden en op basis daarvan kan worden besloten om de aanlevering goed of af te keuren.

#### Individuele aanlevering

Voor het ophalen van de details van een specifieke aanlevering wordt het endpoint */aanleveringen/netinformatie/{aanleveringId}/netbeheerder* aangeroepen. Dit endpoint heeft als parameter in het pad het **aanleveringId** van de aanlevering waarvoor de gegevens opgehaald worden.

**Request**  
```sh
curl https://service10.kadaster.nl/klic/ntd/actualiseren/api/v2/web/aanleveringen/netinformatie/a77aff2b-c794-4ad3-a021-7c1a29096770/netbeheerder
 -H 'Authorization: Bearer 9e25ab45-82a4-4f9e-8bf6-b9ef0eb7568e'
 -H 'Accept: application/json'
```  
_Figuur 12 - CURL-commando voor het opvragen van details van een aanlevering_

Figuur 12 toont het request voor het opvragen van detailgegevens van een specifieke aanlevering. Hierin is het **aanleveringId** veld overgenomen van de aanlevering die zojuist gedaan is. Figuur 13 toont het response. Het response bevat een JSON object met daarin de basisgegevens van de aanlevering, aangevuld met een lijst van statussen die de aanlevering heeft gehad, de **aanleverStatusHistorieList**, een lijst van stappen die de aanlevering doorlopen heeft, de **aanleverStapList** en een lijst van statistieken, de **aanleverStatistiekList**.

Wanneer er fouten, waarschuwingen of informatiemeldingen optreden bij het doorlopen van de aanleverstappen, wordt dit getoond in de **aanleverStapMeldingList** van de betreffende aanleverstap. Hierbij kun je denken aan foutmeldingen of waarschuwingen die optreden tijdens de validatie van het zipbestand.

In de **aanleverStatistiekList** is te zien dat deze aanlevering 69 waterleidingen betreft (**aantal** = 69). Als de aanlevering de status “Gereed voor handmatige controle” heeft en de statistieken zijn naar verwachting, dan kan de aanlevering goedgekeurd worden (zie de sectie [Aanlevering goedkeuren/afkeuren/annuleren](#aanlevering-goedkeurenafkeurenannuleren)).

**Response**  
```json
{
  "aanleveringId": "a77aff2b-c794-4ad3-a021-7c1a29096770",
  "bronhouderCode": "KL9999",
  "informatieSoort": "netinformatie",
  "bestandsnaam": "niAanlevering.zip",
  "netbeheerder" : "Kadaster KLIC-WIN",
  "fileSizeInBytes": 34097,
  "aanleverNummer": 15,
  "aanleverDatum": "2017-01-12T08:41:54.755",
  "aanleverStatus": "https://klic.kadaster.nl/klic/apidocs/v1/cl/aanleverStatus/niTerBeoordeling",
  "aanleverStatusMutatieDatum": "2017-01-12T08:41:54.755",
  "aanleverStatusHistorieList": [
    {
      "mutatieDatum": "2017-01-12T08:41:54.755",
      "aanleverStatus": "https://klic.kadaster.nl/klic/apidocs/v1/cl/aanleverStatus/niTerBeoordeling"
    },
    {
      "mutatieDatum": "2017-01-12T08:41:54.612",
      "aanleverStatus": "https://klic.kadaster.nl/klic/apidocs/v1/cl/aanleverStatus/niGevalideerdZonderFouten"
    },
    {
      "mutatieDatum": "2017-01-12T08:41:49.811",
      "aanleverStatus": "https://klic.kadaster.nl/klic/apidocs/v1/cl/aanleverStatus/niWordtGevalideerd"
    },
    {
      "mutatieDatum": "2017-01-12T08:41:49.224",
      "aanleverStatus": "https://klic.kadaster.nl/klic/apidocs/v1/cl/aanleverStatus/niAangeleverd"
    },
    {
      "mutatieDatum": "2017-01-12T08:41:48.672",
      "aanleverStatus": "https://klic.kadaster.nl/klic/apidocs/v1/cl/aanleverStatus/niGestart"
    }
  ],
  "aanleverStapList": [
    {
      "aanleverStapAanduiding": "https://klic.kadaster.nl/klic/apidocs/v1/cl/aanleverStapAanduiding/niAanleveren",
      "startDatum": "2017-01-12T08:41:48.670",
      "eindDatum": "2017-01-12T08:41:49.228",
      "stapStatus": "succes",
      "gebruikersnaam": "system"
    },
    {
      "aanleverStapAanduiding": "https://klic.kadaster.nl/klic/apidocs/v1/cl/aanleverStapAanduiding/niValideren",
      "startDatum": "2017-01-12T08:41:49.808",
      "eindDatum": "2017-01-12T08:41:54.615",
      "stapStatus": "succes",
      "gebruikersnaam": "system"
    },
    {
      "aanleverStapAanduiding": "https://klic.kadaster.nl/klic/apidocs/v1/cl/aanleverStapAanduiding/niBeoordelen",
      "startDatum": "2017-01-12T08:41:54.752",
      "stapStatus": "nietUitgevoerd",
      "gebruikersnaam": "system"
    }
  ],
  "aanleverStatistiekList": [
	{
	  "statistiekSoort": "IMKL-netinformatie-WION",
	  "statistiekAanduidingNiveau1": "utiliteitsnet",
	  "statistiekAanduidingNiveau2": "water",
	  "aantal": 1,
	  "aantalNieuw": 0,
	  "aantalGewijzigd": 0,
	  "aantalVerwijderd": 0
	},
	{
	  "statistiekSoort": "IMKL-netinformatie-WION",
	  "statistiekAanduidingNiveau1": "kabelOfLeiding",
	  "statistiekAanduidingNiveau2": "water",
	  "aantal": 69,
	  "aantalNieuw": 0,
	  "aantalGewijzigd": 0,
	  "aantalVerwijderd": 0
	}
	/* ... */
  ]
}
```  
_Figuur 13 - Response body met details van een specifieke aanlevering_

### Aanlevering goedkeuren/afkeuren/annuleren

Wanneer een aanlevering de status “Gereed voor handmatige controle” heeft, kan deze goedgekeurd of afgekeurd worden. In het geval dat er een fout is opgetreden bij een aanlevering, dan moet deze aanlevering eerst geannuleerd worden, voordat er een nieuwe aanlevering verwerkt kan worden.

Deze operaties werken op dezelfde manier, alleen wordt er een ander endpoint aangeroepen. De betreffende endpoints zijn: 

-   /aanlevering/netinformatie/{aanleveringId}/netbeheerder/goedkeuren
-   /aanlevering/netinformatie/{aanleveringId}/netbeheerder/afkeuren
-   /aanlevering/netinformatie/{aanleveringId}/netbeheerder/annuleren

In dit voorbeeld wordt de aanlevering goedgekeurd en wordt dus het eerste endpoint aangeroepen.

**Request**  
```sh
curl https://service10.kadaster.nl/klic/ntd/actualiseren/api/v2/web/aanleveringen/netinformatie/a77aff2b-c794-4ad3-a021-7c1a29096770/netbeheerder/goedkeuren
 -v
 -X POST
 -H 'Authorization: Bearer 9e25ab45-82a4-4f9e-8bf6-b9ef0eb7568e'
 -H 'Accept: application/json'
```
**Response:**
```
HTTP/1.1 200 OK
```  
_Figuur 14 - Het CURL-commando voor het goedkeuren van een aanlevering en een deel van de response_

> **N.B.** De CURL-commando's worden in dit document voor de leesbaarheid weergegeven op meerdere regels. Deze commando's dienen of als één enkele regel ingevoerd te worden, of de regels dienen afgesloten te worden met een '^' (Windows) of een '\\' (Unix).

Na het goedkeuren wordt de aanlevering verwerkt en in productie gezet. De aanlevering krijgt dan uiteindelijk de status “In productie”. Dit kun je verifiëren door de aanlevering nogmaals op te halen (zie de sectie [Individuele aanlevering](#individuele-aanlevering)).
