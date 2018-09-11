# B2B-koppeling actualiseren documenten

Dit document biedt een handleiding voor het actualiseren van documenten in de documentenopslag van KLIC met behulp van de B2B-koppeling.

**Inhoudsopgave**

- [Leeswijzer](#leeswijzer)
- [Actualiseren van documenten](#actualiseren-van-documenten)
  - [Zipbestand](#zipbestand)
    - [XML-bestand](#xml-bestand)
    - [Validatieregels](#validatieregels)
  - [Mijn Kadaster](#mijn-kadaster)
  - [REST interfaces](#rest-interfaces)
    - [Authenticatie](#authenticatie)
    - [Netbeheerders en serviceproviders](#netbeheerders-en-serviceproviders)
    - [Endpoints](#endpoints)
    - [Documenten aanleveren](#documenten-aanleveren)
      - [Aanlevering aanmelden](#aanlevering-aanmelden)
      - [Data versturen](#data-versturen)
      - [Data in stukken aanleveren](#data-in-stukken-aanleveren)
      - [Aanlevering hervatten](#aanlevering-hervatten)
    - [Aanleveringen raadplegen](#aanleveringen-raadplegen)
      - [Lijst van aanleveringen](#lijst-van-aanleveringen)
      - [Individuele aanlevering](#individuele-aanlevering)
    - [Aanlevering goedkeuren/afkeuren/annuleren](#aanlevering-goedkeurenafkeurenannuleren)

## Leeswijzer

Dit document beschrijft de structuur en inhoud van het zipbestand met aangeleverde documenten en de procedure voor het aanleveren en verwerken van dit zipbestand.

In de sectie [Zipbestand](#zipbestand) wordt de structuur van het zipbestand toegelicht.

Om documenten aan te kunnen leveren zijn er bepaalde rechten nodig. In deze documentatie gaan we uit van een aanlevering van documenten in de NTD omgeving. De sectie [Mijn Kadaster](#mijn-kadaster) beschrijft hoe gecontroleerd kan worden of de gebruiker over de benodigde rechten beschikt.

De sectie [REST interfaces](#rest-interfaces) beschrijft de verschillende componenten van de REST API’s voor het actualiseren van documenten in de documentenopslag van KLIC. Voor het actualiseren van documenten is er geen beperking op de grootte van het aangeleverde zipbestand, maar het aanleverproces verschilt voor kleine en grotere bestanden. Voor het aanleveren van een zipbestand van 34 Mb of kleiner kunnen achtereenvolgens de volgende secties doorlopen worden:

-   [Authenticatie](#authenticatie)
-   [Netbeheerders en serviceproviders](#netbeheerders-en-serviceproviders)
-   [Endpoints](#endpoints)
-   [Documenten aanleveren](#documenten-aanleveren)
    -   [Aanlevering aanmelden](#aanlevering-aanmelden)
    -   [Data versturen](#data-versturen)
-   [Aanleveringen raadplegen](#aanleveringen-raadplegen)
    -   [Lijst van aanleveringen](#lijst-van-aanleveringen)
    -   [Individuele aanlevering](#individuele-aanlevering)
-   [Aanlevering goedkeuren/afkeuren/annuleren](#aanlevering-goedkeurenafkeurenannuleren)

Voor aanleveringen van een zipbestand groter dan 34 Mb moet naast de sectie [Data versturen](#data-versturen) ook de sectie [Data in stukken aanleveren](#data-in-stukken-aanleveren) doorgenomen worden.

De sectie [Aanlevering hervatten](#aanlevering-hervatten) beschrijft hoe een aanlevering hervat kan worden wanneer er tijdens het uploaden onverhoopt iets fout gaat.

## Actualiseren van documenten

Documenten in de documentenopslag kunnen worden geactualiseerd door deze aan te leveren in een zipbestand. Nieuwe documenten worden toegevoegd aan de documentenopslag, bestaande documenten worden vervangen.

Dit zipbestand bevat een XML-bestand met daarin gegevens over de aangeleverde documenten en alle documenten waarnaar vanuit dat XML-bestand verwezen wordt. De sectie [Zipbestand](#zipbestand) beschrijft de structuur van het zipbestand.

Het actualiseren van documenten gaat in een aantal fases:

1.  Het aanmelden van een aanlevering. Dit gaat door middel van een request naar de “Documentenbeheer API” waardoor een aanlevering geïnitieerd wordt.
2.  Het verzenden van het zipbestand naar het Kadaster. Dit gaat door middel van één of meerdere requests naar de “Upload servlet” API waarin de daadwerkelijke bytes van het zipbestand verstuurd worden.
3.  Het beoordelen van de aanlevering. Een aanlevering die gevalideerd is zonder fouten kan door de netbeheerder/serviceprovider beoordeeld worden op basis van de beschikbare statistieken en goed- of afgekeurd worden door middel van verschillende requests naar de “Documentenbeheer API”.

Al deze fases worden doorlopen in de sectie [REST interfaces](#rest-interfaces).

### Zipbestand

De structuur binnen het zipbestand kan door de netbeheerder/serviceprovider zelf bepaald worden. Alle documenten kunnen in de root van het bestand geplaatst worden, maar het is ook mogelijk om hier een mappenstructuur in op te nemen. De netbeheerder/serviceprovider is ook vrij in het bepalen van de diepte van de mappenstructuur die gehanteerd wordt.

Figuur 1 toont de inhoud van een voorbeeld zipbestand *aanlevering.zip*

![Figuur 1 - aanlevering.zip](images/image1.png "Figuur 1 - aanlevering.zip")
_Figuur 1 - aanlevering.zip_

#### XML-bestand

Het XML-bestand *meta.xml* bevat een beschrijving van de meegeleverde documenten in het zipbestand. De inhoud van dit XML-bestand moet voldoen aan de XSD KlicDocumentenBeheer. Deze XSD is te vinden op de Kadaster GitHub (<https://github.com/Kadaster/KLIC-WIN/blob/master/Actualiseren/Documenten/KlicDocumentenBeheer-0.6.xsd>). Dit voorbeeld is gebaseerd op v0.6 van dit document.
Figuur 2 toont de inhoud van het bestand *meta.xml*.

Het XML-bestand bevat een aantal basisgegevens over de bronhouder waarvoor de aanlevering wordt gedaan, zoals naam en bronhoudercode.

Daarnaast bevat het bestand een lijst van documenten die aangeleverd worden. Deze documenten zitten in het element **aangeleverdeDocumenten**. Voor elk aangeleverd **document** moet er een **documentID** opgegeven zijn en een **bestandsnaam**.

Het veld **documentID** is het identificerende kenmerk van een document. Om eenduidigheid te hebben met het gebruik van identificaties in IMKL, worden hiervoor dezelfde regels toegepast.

Het **documentID** is opgebouwd uit een **namespace**, in dit geval altijd “nl.imkl”, en een **lokaalID**. Het **lokaalID** is een referentie die de netbeheerder/serviceprovider aan het document toekent. De combinatie van **namespace**.**lokaalID** is de sleutel waarmee vanuit de netinformatie verwezen kan worden naar een specifiek document. Het **lokaalID** moet beginnen met de bronhoudercode van de netbeheerder, gevolgd door een punt “.”.

Het veld **documentID** moet uniek zijn voor elk **document** binnen **aangeleverdeDocumenten**. Wanneer een document met een bepaalde **documentID** al aanwezig is in de documentenopslag (een eerdere keer is aangeleverd), zal het bestaande document overschreven worden met de nieuw aangeleverde versie.

Het veld **bestandsnaam** bevat een verwijzing naar een bestand (inclusief pad) in het zipbestand.

Het is mogelijk om meerdere **document** elementen op te nemen in het XML-bestand die verwijzen naar hetzelfde bestand in het zipbestand. Een voorbeeld hiervan is te zien is in Figuur 2; zowel document “nl.imkl-KL9999.water_bestand2” als “nl.imkl-KL9999.water_bestand3“ verwijzen naar “map2/bestandD.pdf”.

#### Validatieregels

Het zipbestand moet aan een aantal voorwaarden voldoen:

-   Het bevat exact één XML-bestand.
-   In het XML-bestand mag ieder *lokaalID* slechts één keer voorkomen.
-   Alle meegeleverde bestanden hebben de extensie “.pdf”.
-   Elk bestand waarnaar verwezen wordt vanuit het XML-bestand moet daadwerkelijk aanwezig zijn in het zipbestand.
-   Wanneer er documenten in het zipbestand aanwezig zijn waarnaar niet verwezen wordt vanuit het XML-bestand, dan levert dit een waarschuwing op. Het zipbestand kan verder wel verwerkt worden.

```xml
<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<DocumentenBeheer 
xmlns="http://www.kadaster.nl/schemas/klic/documentenbeheer/v20180418" 
xmlns:xlink="http://www.w3.org/1999/xlink">
    <versie>1.0</versie>
    <bronhoudercode>KL9999</bronhoudercode>
    <bronhouderNaam>Kadaster KLIC-WIN</bronhouderNaam>
    <indAutomatischNaarProductie>false</indAutomatischNaarProductie>
    <aangeleverdeDocumenten>
        <document>
            <documentID>
                <namespace>nl.imkl</namespace>
                <lokaalID>KL9999.electriciteit_bestand1</lokaalID>
            </documentID>
            <bestandMediaType xlink:href="http://definities.geostandaarden.nl/imkl2015/id/waarde/BestandMediaTypeValue/PDF"/>
            <bestandsnaam>map1/bestandA.pdf</bestandsnaam>
        </document>
        <document>
            <documentID>
                <namespace>nl.imkl</namespace>
                <lokaalID>KL9999.elektriciteit_bestand2</lokaalID>
            </documentID>
            <bestandMediaType xlink:href="http://definities.geostandaarden.nl/imkl2015/id/waarde/BestandMediaTypeValue/PDF"/>
            <bestandsnaam>map1/bestandB.pdf</bestandsnaam>
        </document>
        <document>
            <documentID>
                <namespace>nl.imkl</namespace>
                <lokaalID>KL9999.water_bestand1</lokaalID>
            </documentID>
            <bestandMediaType xlink:href="http://definities.geostandaarden.nl/imkl2015/id/waarde/BestandMediaTypeValue/PDF"/>
            <bestandsnaam>map2/bestandC.pdf</bestandsnaam>
        </document>
        <document>
            <documentID>
                <namespace>nl.imkl</namespace>
                <lokaalID>KL9999.water_bestand2</lokaalID>
            </documentID>
            <bestandMediaType xlink:href="http://definities.geostandaarden.nl/imkl2015/id/waarde/BestandMediaTypeValue/PDF"/>
            <bestandsnaam>map2/bestandD.pdf</bestandsnaam>
        </document>
        <document>
            <documentID>
                <namespace>nl.imkl</namespace>
                <lokaalID>KL9999.water_bestand3</lokaalID>
            </documentID>
            <bestandMediaType xlink:href="http://definities.geostandaarden.nl/imkl2015/id/waarde/BestandMediaTypeValue/PDF"/>
            <bestandsnaam>map2/bestandD.pdf</bestandsnaam>
        </document>
    </aangeleverdeDocumenten>
</DocumentenBeheer>
```  
_Figuur 2 - meta.xml_

### Mijn Kadaster

Om te verifiëren of een gebruiker rechten heeft om een aanlevering te kunnen doen, moet deze inloggen in Mijn Kadaster en moet de gebruiker toegang hebben tot de Klic Netbeheerder Testdienst (kortweg NTD).

![Figuur 3](images/image2.png "Figuur 3 - Toegang tot de Klic Netbeheerders Testdienst vanuit Mijn Kadaster")
_Figuur 3 - Toegang tot de Klic Netbeheerders Testdienst vanuit Mijn Kadaster_

Figuur 3 toont de home pagina van Mijn Kadaster van een gebruiker die toegang heeft tot de Klic Netbeheerder Testdienst.

### REST interfaces

Voor het geautomatiseerd actualiseren van documenten heeft het Kadaster REST interfaces beschikbaar gesteld. De documentatie over de werking van deze interfaces is beschikbaar in de vorm van Swagger specificatie. Deze documentatie is te vinden bij de “KLIC API documentatie”-applicatie (<https://service10.kadaster.nl/klic/ntd/actualiseren/api-docs/>).

Om de “KLIC API documentatie”-applicatie te openen, moet de gebruiker ingelogd zijn in Mijn Kadaster (zie de sectie [Mijn Kadaster](#mijn-kadaster)). Vervolgens kan bovenstaande link gekopieerd worden naar het tabblad waarin de gebruiker is ingelogd in Mijn Kadaster.

![Figuur 4](images/KLIC-API-documentatie-actualiseren.png "Figuur 4 - home pagina van de KLIC API documentatie applicatie")
_Figuur 4 - home pagina van de KLIC API documentatie applicatie_


In het voorbeeld in dit document wordt gebruik gemaakt van de command-line tool CURL (<https://curl.haxx.se/>). Dit heeft een duidelijke analogie met de werkwijze als een netbeheerder of serviceprovider een eigen applicatie wil ontwikkelen voor het actualiseren van documenten via de B2B-koppeling.

In dit voorbeeld wordt een bestand aangeleverd voor de netbeheerder “Kadaster KLIC-WIN” met de bronhouder “KL9999”. Dit gebeurt op de NTD-omgeving en er wordt dan ook gebruik gemaakt van de documentatie onder de kop “NTD” zoals te zien in Figuur 4.

Voor het actualiseren van documenten worden voornamelijk operaties gebruikt van de “Documentenbeheer” API, behalve voor het versturen van data van het aan te leveren bestand. In dat geval wordt er gebruik gemaakt van de “Upload servlet” API.

### Authenticatie

De KLIC REST API's zijn beveiligd middels de OAuth 2.0 specificatie. Zie daarvoor 
 [Authenticatie via oauth](../../API%20management/Authenticatie_via_oauth.md).
De benodigde scope voor het actualiseren van documenten is `klic.centraal`


#### Netbeheerders en serviceproviders

De REST interfaces kennen verschillende endpoints voor netbeheerders en voor serviceproviders. Serviceproviders moeten in de URL van het endpoint dat ze aanroepen de bronhoudercode opnemen van de netbeheerder waarvoor zij de betreffende operatie willen uitvoeren. In de documentatie zijn deze endpoints te herkennen aan de parameter "{bronhoudercode}".

In dit voorbeeld wordt uitgegaan van een netbeheerder die zelf een aanlevering doet. Er wordt dus geen gebruik gemaakt van de endpoints met "{bronhoudercode}" erin.

#### Endpoints

De endpoints die gebruikt worden in dit document zijn relatief ten opzichte van de betreffende API’s. Voor NTD documentenbeheer bevindt deze API zich op <https://service10.kadaster.nl/klic/ntd/actualiseren/api/v2/web>.

Voor de NTD Upload servlet bevindt deze API zich op <https://service10.kadaster.nl//klic/ntd/actualiseren/upload/api/v2/web>.

Het OAuth Authorization endpoint voor NTD is
<https://authorization.test.kadaster.nl/auth/oauth/v2/>

#### Documenten aanleveren

Het bestand dat eerder beschreven werd in de sectie [Zipbestand](#zipbestand), wordt nu aangeleverd. Dit is een bestand voor de netbeheerder “Kadaster KLIC-WIN” het wordt aangeleverd door de netbeheerder zelf.

Het aanleveren van een zipbestand gaat in twee fases:

1.  Het aanmelden van een aanlevering. Dit gaat door middel van een POST request naar de “Documentenbeheer API”. Het response op dit request bevat een header “Location” met daarin een URI naar de “Upload servlet API” waarnaar de data verzonden kan worden.
2.  Het verzenden van de data naar het Kadaster. Dit gaat door middel van één of meerder PUT requests naar de “Upload servlet” API waarin de daadwerkelijke bytes van het zipbestand verstuurd worden.

##### Aanlevering aanmelden

Het aanmelden van de aanlevering gaat met een POST request naar het endpoint */aanleveringen/documenten/netbeheerder*.

![Figuur 5](images/image6.png "Figuur 5 - Swagger-UI voor het uitvoeren van een POST request naar /aanleveringen/documenten/netbeheerder")
_Figuur 5 - Swagger-UI voor het uitvoeren van een POST request naar /aanleveringen/documenten/netbeheerder_

Figuur 5 toont de Swagger-UI voor het aanmelden van een aanlevering. Dit endpoint kent een aantal parameters die als header meegestuurd moeten worden. De dikgedrukte parameters zijn verplicht, de andere parameter is optioneel.

De parameters zijn ingevuld met gegevens voor het aan te leveren bestand, “aanlevering.zip”. Dit is een klein voorbeeldbestand van in totaal 1405 bytes groot. Deze parameters vertalen zich naar het volgende CURL commando:

**Request**  
```sh
curl https://service10.kadaster.nl/klic/actualiseren/api/v2 
/aanleveringen/documenten/netbeheerder
-v
-X POST
-H 'Authorization: Bearer 9e25ab45-82a4-4f9e-8bf6-b9ef0eb7568e'
-H 'Content-Type: application/json'
-H 'X-Upload-Content-Length: 1405'
-H 'X-Upload-Content-Type: application/zip'
-H 'X-Upload-Filename: aanlevering.zip'
```
**Response:**  
```
HTTP/1.1 200 OK
Location: https://service10.kadaster.nl/klic/actualiseren/upload/api/v2/upload?upload_id=57eca5b8-543b-4f42-b4d4-e52bed10ab84
```  
_Figuur 6 - Het CURL commando voor het aanmelden van een aanlevering en een deel van de response_

In de body van de response worden kenmerkende gegevens over de aanlevering teruggegeven.  \
Om dit response (met zekerheid) in json-formaat terug te krijgen, moet dit in de header van het request worden meegegeven als 'Content-Type: application/json'.

Voorbeeld:
```json
[{
    "aanleveringId" : "a77aff2b-c794-4ad3-a021-7c1a29096770",
    "bronhouderCode" : "KL9999",
    "informatieSoort" : "documenten",
    "bestandsnaam" : "aanlevering.zip",
    "netbeheerder" : "Kadaster KLIC-WIN",
    "fileSizeInBytes" : 1405,
    "aanleverNummer" : 29,
    "aanleverDatum" : "2016-11-08T15:58:47.062",
    "aanleverStatus" : "https://klic.kadaster.nl/klic/apidocs/v1/cl/aanleverStatus/docGestart"
}]
```
> **N.B.** De CURL commando's worden in dit document voor de leesbaarheid weergegeven op meerdere regels. Deze commando's dienen of als één enkele regel ingevoerd te worden, of de regels dienen afgesloten te worden met een '^' (Windows) of een '\\' (Unix).

Figuur 6 toont het CURL commando en het resultaat van het request. De response code 200 geeft aan dat het request succesvol verwerkt is. Een belangrijke parameter in de response is de header “Location”. Dit is een endpoint in de “Upload servlet” API waarnaar het zipbestand geüpload moet worden.

##### Data versturen

Figuur 7 toont de Swagger-UI voor een PUT request naar het */upload* endpoint van de “Upload servlet” API. Het veld "body" is in dit overzicht niet gevuld omdat de Swagger-UI interface geen binaire data ondersteund. Dit endpoint kan dan ook niet getest worden vanuit de Swagger-UI.

De documentatie van dit endpoint toont een aantal parameters:

**upload\_id** – het identificerend gegeven van een specifieke upload. Dit is een URL parameter en onderdeel van de URL die in de “Location” header teruggegeven is bij het aanmelden van de aanlevering (zie sectie [Aanlevering aanmelden](#aanlevering-aanmelden)).

**Content-Range** – De bytes die aangeleverd gaan worden. De upload servlet ondersteunt de mogelijkheid om een bestand in meerdere stukken aan te leveren (zie sectie [Data in stukken aanleveren](#data-in-stukken-aanleveren)). In dit geval wordt het bestand in één keer aangeleverd. Het formaat van deze parameter is `bytes <van>-<tot>/<totaal>`. In dit geval is het bestand 1405 bytes lang. De eerste byte is byte 0, en de laatste byte 1404.

> **N.B.** Dit endpoint ondersteunt PUT requests met een body van maximaal **34 Mb** groot. Aanleveringen van zipbestanden groter dan **34 Mb** dienen verdeeld te worden over meerdere PUT requests. Zie hiervoor de sectie [Data in stukken aanleveren](#data-in-stukken-aanleveren).

**Content-Length** – Het aantal bytes in de body van het request. In dit geval komt dat overeen met de grootte van het bestand; 1405 bytes.

**body** – De inhoud van het request. Hier worden de bytes van het aan te leveren bestand in meegegeven.


![Figuur 7](images/image7.png "Figuur 7 - Swagger-UI voor het uitvoeren van een PUT request naar /upload")
_Figuur 7 - Swagger-UI voor het uitvoeren van een PUT request naar /upload_

De parameters vertalen zich naar het volgende CURL commando:

**Request**  
```sh
curl https://service10.kadaster.nl/klic/actualiseren/upload/api/v2/upload?upload_id=57eca5b8-543b-4f42-b4d4-e52bed10ab84
-v
-X PUT
--header 'Authorization: Bearer 9e25ab45-82a4-4f9e-8bf6-b9ef0eb7568e'
-H 'Content-Type: application/octet-stream'
-H 'Content-Length: 1405'
-H 'Content-Range: bytes 0-1404/1405'
--data-binary @'D:\aanlevering.zip'
```  
**Response:**  
```
HTTP/1.1 200 OK
Range: bytes=0-1404
```  
_Figuur 8 - CURL commando en het response voor het versturen van data_

> **N.B.** De CURL commando's worden in dit document voor de leesbaarheid weergegeven op meerdere regels. Deze commando's dienen of als één enkele regel ingevoerd te worden, of de regels dienen afgesloten te worden met een '^' (Windows) of een '\\' (Unix).

Wanneer het request succesvol verwerkt wordt, geeft de server een 200 OK response en de range aan bytes die ontvangen is voor deze upload. Deze **Range** header wordt uitgebreid besproken in de sectie [Aanlevering hervatten](#aanlevering-hervatten).

##### Data in stukken aanleveren

Er is voor het aanleveren van documenten geen limiet op het formaat van het zipbestand. Echter, er zit wel een maximum op het aantal bytes dat per keer verstuurd kan worden naar het Kadaster. Dit is maximaal 34 Mb per request. Voor zipbestanden groter dan 34 Mb moet het bestand dus in stukken aangeleverd worden. De aanmelding van de aanlevering gaat zoals beschreven in de sectie [Aanlevering aanmelden](#aanlevering-aanmelden). Hierbij moet als **X-Upload-Content-Length** de grootte van het volledige zipbestand opgegeven worden.

Voor elke segment van het bestand moet er een request verstuurd worden, zoals beschreven in de sectie [Data versturen](#data-versturen), met de volgende parameters:

| Parameter      | Waarde                           | Omschrijving                                                                                                                                                                                                                                                              |
|----------------|----------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Content-Type   | application/octet-stream         | Deze parameter is voor ieder request hetzelfde.                                                                                                                                                                                                                           |
| Content-Length | 1405                             | De lengte van de body van het request. Deze waarde verschilt per request.                                                                                                                                                                                                 |
| Content-Range  | bytes \<van\>-\<tot\>/\<totaal\> | De reeks bytes ten opzichte van het totaal aantal bytes van het aan te leveren zipbestand. De bytes zijn zero-indexed, dat wil zeggen dat de eerste byte, byte 0 is. De eerste 10 bytes van een bestand van 10 bytes groot wordt dus als volgt aangeduid: “bytes 0-9/10”. |
| Body           | \<bytes\>                        | De body van het request bevat de bytes van het betreffende segment.                                                                                                                                                                                                       |

Wanneer er bijvoorbeeld een bestand aangeleverd wordt van 80.000.000 bytes (~76 Mb), dan kan dat in 3 segmenten, met de volgende parameters:

| Content-Length | Content-Range                    |
|----------------|----------------------------------|
| 30000000       | bytes 0-29999999/80000000        |
| 30000000       | bytes 30000000-59999999/80000000 |
| 20000000       | bytes 60000000-79999999/80000000 |

##### Aanlevering hervatten

Ieder PUT request naar het */upload* endpoint van de “Upload servlet” API bevat in het response de **Range** header. Deze header bevat een aanduiding van de reeks aan bytes die door het Kadaster ontvangen is. In het voorbeeld in de sectie [Data in stukken aanleveren](#data-in-stukken-aanleveren), waarbij 80.000.000 bytes in 3 requests verstuurd worden naar het Kadaster, zou deze header na elk request achtereenvolgens de waarden bevatten: “0-29999999”, “0-59999999”, “0-79999999”.

Deze header maakt het ook mogelijk om een upload te hervatten wanneer er - om wat voor reden dan ook - iets fout gaat. Om de status van een upload op te vragen kan er een PUT request zonder body verstuurd worden naar het */upload* endpoint. In dit request heeft de parameter **Content-Length** de waarde “0” en de parameter **Content-Range** een waarde in de vorm “bytes \*/&lt;totaal&gt;”.

**Request**  
```sh
curl https://service10.kadaster.nl/klic/actualiseren/upload/api/v2/upload?upload_id=57eca5b8-543b-4f42-b4d4-e52bed10ab84
-v
-X PUT
--header 'Authorization: Bearer 9e25ab45-82a4-4f9e-8bf6-b9ef0eb7568e'
-H 'Content-Type: application/octet-stream'
-H 'Content-Length: 0'
-H 'Content-Range: bytes */1405'
--data-binary @'D:\aanlevering.zip'
```
**Response:**  
```
HTTP/1.1 200 OK
Range: bytes=0-1404
```  
_Figuur 9 - CURL commando voor het ophalen van de status van een upload_

> **N.B.** De CURL commando's worden in dit document voor de leesbaarheid weergegeven op meerdere regels. Deze commando's dienen of als één enkele regel ingevoerd te worden, of de regels dienen afgesloten te worden met een '^' (Windows) of een '\\' (Unix).

Wanneer nog niet alle bytes van een zipbestand ontvangen zijn, kan aan de **Range** header afgeleid worden vanaf welke byte de draad weer opgepakt kan worden.

#### Aanleveringen raadplegen

De “Documentenbeheer” API biedt een aantal endpoints voor het raadplegen van de aanleveringen.

##### Lijst van aanleveringen

Het endpoint */aanleveringen/documenten/netbeheerder* levert een lijst van aanleveringen van de netbeheerder op. Deze lijst is gepagineerd, dat wil zeggen dat de totale lijst van aanleveringen opgedeeld is in pagina’s. Per request wordt er één pagina met aanleveringen teruggegeven. Standaard bevat een pagina 5 aanleveringen en wordt de eerste pagina teruggegeven. Dit kan door middel van de optionele parameters **page** en **size** aangepast worden. De paginanummering begint bij pagina 1 (dus niet bij 0) en de maximale paginagrootte (**size**) is 15.

**Request**  
```sh
curl 
--header 'Authorization: Bearer 9e25ab45-82a4-4f9e-8bf6-b9ef0eb7568e' https://service10.kadaster.nl/klic/actualiseren/api/v2/aanleveringen/documenten/netbeheerder
```  
_Figuur 10 - CURL commando voor het opvragen van een lijst van aanleveringen_

Het response van dit request is weergegeven in Figuur 11. In deze afbeelding is voor het overzicht een aantal aanleveringen weggelaten.

```json
{
  "link" : [ {
    "rel" : "first",
    "href" : "https://service10.kadaster.nl/klic/ntd/actualiseren/documenten/backend/rest/aanleveringen/documenten/netbeheerder?page=1&size=5"
  }, {
    "rel" : "self",
    "href" : "https://service10.kadaster.nl/klic/ntd/actualiseren/documenten/backend/rest/aanleveringen/documenten/netbeheerder"
  }, {
    "rel" : "next",
    "href" : "https://service10.kadaster.nl/klic/ntd/actualiseren/documenten/backend/rest/aanleveringen/documenten/netbeheerder?page=2&size=5"
  }, {
    "rel" : "last",
    "href" : "https://service10.kadaster.nl/klic/ntd/actualiseren/documenten/backend/rest/aanleveringen/documenten/netbeheerder?page=6&size=5"
  } ],
  "content" : [ {
    "aanleveringId" : "a77aff2b-c794-4ad3-a021-7c1a29096770",
    "bronhouderCode" : "KL9999",
    "informatieSoort" : "documenten",
    "bestandsnaam" : "aanlevering.zip",
    "netbeheerder" : "Kadaster KLIC-WIN",
    "fileSizeInBytes" : 1405,
    "aanleverNummer" : 29,
    "aanleverDatum" : "2016-11-08T15:58:47.062",
    "aanleverStatus" : "https://klic.kadaster.nl/klic/apidocs/v1/cl/aanleverStatus/docTerBeoordeling",
    "aanleverStatusMutatieDatum" : "2016-11-08T16:07:31.424",
    "link" : [ ]
  }

  /* ... */

  ],
  "page" : {
    "size" : 5,
    "totalElements" : 29,
    "totalPages" : 6,
    "number" : 0
  }
}
```  
_Figuur 11 - Response body met een lijst van aanleveringen_

Per aanlevering is er een JSON object met daarin de basisgegevens van een aanlevering en de actuele status. In Figuur 11 is te zien dat de aanlevering die zojuist gedaan is, de status “Gereed voor handmatige controle” heeft gekregen. Voor deze aanlevering kunnen de details opgehaald worden en op basis daarvan kan worden besloten om de aanlevering goed of af te keuren.

##### Individuele aanlevering

Voor het ophalen van de details van een specifieke aanlevering wordt het endpoint */aanleveringen/documenten/{aanleveringId}/netbeheerder* aangeroepen. Dit endpoint heeft als parameter in het pad het **aanleveringId** van de aanlevering waarvoor de gegevens opgehaald worden.

**Request**  
```sh
curl 
--header 'Authorization: Bearer 9e25ab45-82a4-4f9e-8bf6-b9ef0eb7568e' https://service10.kadaster.nl/klic/actualiseren/api/v2/aanleveringen/documenten/a77aff2b-c794-4ad3-a021-7c1a29096770/netbeheerder
```  
_Figuur 12 - CURL commando voor het opvragen van details van een aanlevering_

Figuur 12 toont het request voor het opvragen van detailgegevens van een specifieke aanlevering. Hierin is het **aanleveringId** veld overgenomen van de aanlevering die zojuist gedaan is. Figuur 13 toont het response. Het response bevat een JSON object met daarin de basisgegevens van de aanlevering, aangevuld met een lijst van statussen die de aanlevering heeft gehad, de **aanleverStatusHistorieList**, een lijst van stappen die de aanlevering doorlopen heeft, de **aanleverStapList** en een lijst van statistieken, de **aanleverStatistiekList**.

Wanneer er fouten, waarschuwingen of informatiemeldingen optreden bij het doorlopen van de aanleverstappen, wordt dit getoond in de **aanleverStapMeldingList** van de betreffende aanleverstap. Hierbij kun je denken aan foutmeldingen of waarschuwingen die optreden tijdens de validatie van het zipbestand.

In de **aanleverStatistiekList** is te zien dat deze aanlevering 5 documenten betreft, die allemaal nog niet eerder aangeleverd zijn (**aantalNieuw** = 5). Als de aanlevering de status “Gereed voor handmatige controle” heeft en de statistieken zijn naar verwachting, dan kan de aanlevering goedgekeurd worden (zie de sectie [Aanlevering goedkeuren/afkeuren/annuleren](#aanlevering-goedkeurenafkeurenannuleren)).

**Response**  
```json
{
  "aanleveringId" : "a77aff2b-c794-4ad3-a021-7c1a29096770",
  "bronhouderCode" : "KL9999",
  "informatieSoort" : "documenten",
  "bestandsnaam" : "aanlevering.zip",
  "netbeheerder" : "Kadaster KLIC-WIN",
  "fileSizeInBytes" : 1405,
  "aanleverNummer" : 29,
  "aanleverDatum" : "2016-11-08T15:58:47.062",
  "aanleverStatus" : "https://klic.kadaster.nl/klic/apidocs/v1/cl/aanleverStatus/docTerBeoordeling",
  "aanleverStatusMutatieDatum" : "2016-11-08T16:07:31.424",
  "aanleverStatusHistorieList" : [ {
    "mutatieDatum" : "2016-11-08T16:07:31.424",
    "aanleverStatus" : "https://klic.kadaster.nl/klic/apidocs/v1/cl/aanleverStatus/docTerBeoordeling"
  }, {
    "mutatieDatum" : "2016-11-08T16:07:31.410",
    "aanleverStatus" : "https://klic.kadaster.nl/klic/apidocs/v1/cl/aanleverStatus/docGevalideerdZonderFouten"
  }, {
    "mutatieDatum" : "2016-11-08T16:07:31.382",
    "aanleverStatus" : "https://klic.kadaster.nl/klic/apidocs/v1/cl/aanleverStatus/docWordtGevalideerd"
  }, {
    "mutatieDatum" : "2016-11-08T16:07:30.147",
    "aanleverStatus" : "https://klic.kadaster.nl/klic/apidocs/v1/cl/aanleverStatus/docAangeleverd"
  }, {
    "mutatieDatum" : "2016-11-08T15:58:47.069",
    "aanleverStatus" : "https://klic.kadaster.nl/klic/apidocs/v1/cl/aanleverStatus/docGestart"
  } ],
  "aanleverStapList" : [ {
    "aanleverStapAanduiding" : "https://klic.kadaster.nl/klic/apidocs/v1/cl/aanleverStapAanduiding/docAanleveren",
    "startDatum" : "2016-11-08T15:58:47.074",
    "eindDatum" : "2016-11-08T16:07:30.143",
    "stapStatus" : "succes",
    "gebruikersnaam" : "veerkj1"
  }, {
    "aanleverStapAanduiding" : "https://klic.kadaster.nl/klic/apidocs/v1/cl/aanleverStapAanduiding/docValideren",
    "startDatum" : "2016-11-08T16:07:31.378",
    "eindDatum" : "2016-11-08T16:07:31.413",
    "stapStatus" : "succes",
    "gebruikersnaam" : "system"
  }, {
    "aanleverStapAanduidingId" : "https://klic.kadaster.nl/klic/apidocs/v1/cl/aanleverStapAanduiding/docBeoordelen",
    "startDatum" : "2016-11-08T16:07:31.422",
    "eindDatum" : "2016-11-08T16:07:31.427",
    "stapStatus" : "succes",
    "gebruikersnaam" : "system"
  } ],
  "aanleverStatistiekList" : [ {
    "statistiekSoort" : "IMKL_DOCUMENTEN",
    "niveau1" : 0,
    "statistiekAanduidingNiveau1" : "aanleveren",
    "niveau2" : 0,
    "statistiekAanduidingNiveau2" : "documentenAangeleverd",
    "aantal" : 5,
    "aantalNieuw" : 5,
    "aantalGewijzigd" : 0,
    "aantalVerwijderd" : 0
  } ]
}
```  
_Figuur 13 - Response body met details van een specifieke aanlevering_

### Aanlevering goedkeuren/afkeuren/annuleren

Wanneer een aanlevering de status “Gereed voor handmatige controle” heeft, kan deze goedgekeurd of afgekeurd worden. In het geval dat er een fout is opgetreden bij een aanlevering, dan moet deze aanlevering eerst geannuleerd worden, voordat er een nieuwe aanlevering verwerkt kan worden.

Deze operaties werken op dezelfde manier, alleen wordt er een ander endpoint aangeroepen. De betreffende endpoints zijn:

-   /aanlevering/documenten/{aanleveringId}/netbeheerder/goedkeuren
-   /aanlevering/documenten/{aanleveringId}/netbeheerder/afkeuren
-   /aanlevering/documenten/{aanleveringId}/netbeheerder/annuleren

In dit voorbeeld wordt de aanlevering goedgekeurd en wordt dus het eerste endpoint aangeroepen.

**Request**  
```sh
curl https://service10.kadaster.nl/klic/actualiseren/api/v2/aanleveringen/documenten/a77aff2b-c794-4ad3-a021-7c1a29096770/netbeheerder/goedkeuren
--header 'Authorization: Bearer 9e25ab45-82a4-4f9e-8bf6-b9ef0eb7568e'
-v
-X POST
```
**Response:**
```
HTTP/1.1 200 OK
```  
_Figuur 14 - Het CURL commando voor het goedkeuren van een aanlevering en een deel van de response_

> **N.B.** De CURL commando's worden in dit document voor de leesbaarheid weergegeven op meerdere regels. Deze commando's dienen of als één enkele regel ingevoerd te worden, of de regels dienen afgesloten te worden met een '^' (Windows) of een '\\' (Unix).

Na het goedkeuren wordt de aanlevering verwerkt en in productie gezet. De aanlevering krijgt dan uiteindelijk de status “In productie”. Dit kun je verifiëren door de aanlevering nogmaals op te halen (zie de sectie [Individuele aanlevering](#individuele-aanlevering)).


## Swagger UI ##

De link 'API Testfaciliteit' in de KLIC API-documentatie brengt u naar een overzicht van alle endpoints die in dit document beschreven zijn.
Al deze endpoints zijn meteen uit te proberen via de aangeboden interface. Met uitzondering van de PUT-operatie voor het aanleveren van een bestand.

### OAuth token meegeven ###

Net als in alle beschreven curl-commando's moet een OAuth-token als Authorization header meegegeven worden. In curl gaat dat via een parameter,
de Swagger-UI is een webapplicatie dus de browser moet verteld worden de header mee te geven. In Chrome kan dat door een extensie te installeren: [ModHeader](https://chrome.google.com/webstore/detail/modheader/idgpnmonknjnojddfkpgkljpfnnfcklj?hl=nl).
Wanneer de extensie geïnstalleerd is, is naast de adresbalk een icoon toegevoegd. Hierop klikken geeft onderstaand invulformulier:

![Figuur 15](images/ModHeader-OAuth.png "Figuur 15 - ModHeader invulformulier voor OAuth")

Vul bij `Request Headers` "Authorization" in en als waarde "Bearer " plus het OAuth token (net als bij de curl-commandos).
Optioneel kan een filter toegevoegd worden. Een filter zorgt ervoor dat de Authorization-token alleen voor bepaalde URLs wordt meegegeven.
Dit is sterk aan te raden omdat anders andere diensten die gebruik maken van OAuth (Google-diensten bijvoorbeeld) niet meer correct zullen werken.
Om een filter toe te voegen klik op `+` en kies Filter. Selecteer `URL Pattern` en vul een patroon in dat uniek is voor de B2B-koppeling,
bijvoorbeeld "*/klic/ntd/*". (dit betekent dat ieder URL waarin "/klic/ntd/" voorkomt de Authorization-header meegestuurd krijgt)

Zonder Authorization-header zal iedere klik op `Try it out!` leiden tot een HTML-pagina met de melding: "Kadaster - Niet geauthenticeerd".
