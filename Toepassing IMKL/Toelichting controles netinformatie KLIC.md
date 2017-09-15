# Toelichting controles netinformatie KLIC

**Inhoudsopgave**

- [Inleiding](#inleiding)
  - [Centrale Voorziening](#centrale-voorziening)
    - [Aanleveren gegevens](#aanleveren-gegevens)
  - [Decentrale aanlevering](#decentrale-aanlevering)
    - [Aanleveren gegevens](#aanleveren-gegevens-1)
- [Controles](#controles)
  - [Zipbestand eigenschappen](#zipbestand-eigenschappen)
  - [XML](#xml)
    - [Encoding, tekenset](#encoding-tekenset)
    - [XSD validatie](#xsd-validatie)
    - [Codelijsten/Waardelijsten](#codelijstenwaardelijsten)
    - [Object Identificatie](#object-identificatie)
    - [gml:id](#gmlid)
    - [Numerieke waarden](#numerieke-waarden)
      - [Hoogte](#hoogte)
      - [Diepte](#diepte)
    - [Tijdaanduiding](#tijdaanduiding)
    - [Geometrie](#geometrie)
      - [Referentiestelsel en dimensie](#referentiestelsel-en-dimensie)
        - [srsName](#srsname)
        - [srsDimension](#srsdimension)
      - [Geldige geometrietype](#geldige-geometrietype)
        - [Punt](#punt)
        - [Lijn](#lijn)
        - [Vlak](#vlak)
      - [Geometrie niet leeg en voldoende coördinaten](#geometrie-niet-leeg-en-voldoende-co%C3%B6rdinaten)
      - [Topologisch correct](#topologisch-correct)
      - [Aantal punten](#aantal-punten)
      - [Draairichting van polygonen](#draairichting-van-polygonen)
      - [Nauwkeurigheid coördinaten](#nauwkeurigheid-co%C3%B6rdinaten)
  - [Associaties](#associaties)
    - [href](#href)
    - [Controles](#controles)
    - [1..n associaties naar Utiliteitsnet](#1n-associaties-naar-utiliteitsnet)
  - [Extra regels](#extra-regels)
    - [Network Element](#network-element)
    - [Utility Node Container](#utility-node-container)
    - [Utiliteitsnet](#utiliteitsnet)
    - [UtilityLink](#utilitylink)
    - [IMKL](#imkl)

## Inleiding

In het nieuwe KLIC wordt netinformatie uitgewisseld in XML conform het IMKL2015 model.

Netbeheerders krijgen in het nieuwe KLIC de keuze om centraal te gaan, waarbij ze hun netinformatie in een centrale voorziening zetten, of decentraal te gaan waarbij ze - net als in de oude situatie - per gebiedsinformatie-aanvraag informatie aanleveren aan het Kadaster.

In beide gevallen wordt voor de definiëring van de aan te leveren vectordata gebruik gemaakt van hetzelfde model wat vooralsnog conform de IMKL2015_wion XSD is. De validatie van de vector informatie is in beide gevallen gelijk, tenzij hieronder aangegeven.

Ongeacht hoe de netbeheerder de informatie aanlevert, is de netbeheerder zelf verantwoordelijk voor de kwaliteit van de aangeleverde netinformatie.

Er wordt een Netbeheerder TestDienst (NTD) beschikbaar gesteld, waarmee de netbeheerder zijn aanleveringen kan controleren.

De IMKL2015 versie die het Kadaster gebruikt (1.2.1) staat gepubliceerd op https://register.geostandaarden.nl/imkl2015/

### Centrale voorziening

Het Kadaster beheert de centrale voorziening kabels en leidingen, waar de door de centrale netbeheerders aangeleverde netinformatie samenkomt.
De aanlevering van netinformatie van een centrale netbeheerder bestaat mogelijk uit
* alle gegevens over kabels en leidingen behorende bij een utiliteitsnet
* eigen topografie (optioneel)
* bijlagen van het type `algemeen` en/of `nietBetrokken` (optioneel)

Om de goede verwerking van de centrale voorziening te kunnen garanderen, wordt een aangeleverd bestand technisch en functioneel gecontroleerd alvorens de gegevens in de centrale voorziening opgenomen worden.

#### Aanleveren gegevens

Een centrale netbeheerder of serviceprovider kan op twee manieren netinformatie aanleveren:
* In Mijn Kadaster is de functie _KLIC Actualiseren Netinformatie_ beschikbaar
* Via de _Actualiseren Netinformatie_ API

In beide gevallen wordt de netinformatie aangeleverd in een zipbestand. De specifieke eigenschappen van het zipbestand worden verderop in het document beschreven.

In het zipbestand staat in de root één XML-bestand conform de IMKL2015_wion XSD. Er zitten verder geen andere bestanden in het zipbestand.

Het XML-bestand bevat altijd alle assets van de netbeheerder die van belang zijn voor de WION.

### Decentrale aanlevering

Een decentrale netbeheerder of serviceprovider levert informatie op basis van een gebiedsinformatie-aanvraag d.m.v. de _KLIC Netbeheerder API_.

De aanlevering van beheerdersinformatie van een belanghebbende decentrale netbeheerder bestaat mogelijk uit
* gegevens over de belanghebbende
* alle gegevens over kabels en leidingen behorende bij utiliteitsnetten die binnen het aangevraagde gebied liggen
* eigen topografie binnen het aangevraagde gebied (optioneel)
* bijlagen van het type `algemeen` en/of `nietBetrokken` (optioneel)
* bijlage(n) van het type `eisVoorzorgsmaatregel` (optioneel)

Voor de decentraal aangeleverde netinformatie worden dezelfde validatie regels gehanteerd als voor het aanleveren aan de centrale voorziening.

#### Aanleveren gegevens

De netinformatie wordt inclusief bijlagen aangeleverd in een zipbestand. De specifieke eigenschappen van het zipbestand worden verderop in het document beschreven.

In het zipbestand staat in de root één XML-bestand conform de IMKL2015_wion XSD. De bijlages bevinden zich ook in de root van het zipbestand.

Het XML-bestand bevat alle assets van de netbeheerder die van belang zijn voor de WION en binnen de gebiedsinformatie-aanvraag vallen. Geometrieën zijn daarbij geklipt op het informatiegebied indien beschikbaar en anders worden de geometriën geklipt op het graafgebied.

![aanleveringen](images/KLIC-API-documentatie-aanlevering.png "Aanleveringen")

## Controles

Hieronder worden de controles behandeld.

### Zipbestand eigenschappen

Een aangeleverd zipbestand wordt gecontroleerd op de punten:
* Het aangeleverde bestand moet een ZIP-archief zijn en mag niet groter zijn dan een bepaalde grootte. De maximale grootte voor de eindsituatie is voorlopig gesteld op 2GB.
* Het te gebruiken ZIP-formaat is beschreven in Info-ZIP Application Note 970311 (ZIP). Sommige ZIP-tools gebruiken compressie methodes die niet in deze specificatie staan, deze methodes worden niet ondersteund.
* Het aangeleverde ZIP-archief mag maximaal 1 XML-bestand bevatten. Dit XML-bestand bevindt zich in de root van het ZIP-archief en heeft de bestands-extensie .xml. De bestands-extensie is met kleine letters.
* De bestandsnaam van het ZIP-archief of XML-bestand mag een maximaal aantal tekens en geen ongeldige tekens bevatten.
  * Bestandsnaam mag niet langer zijn dan 120 tekens.
  * De bestandsnaam mag niet bestaan uit vreemde tekens; als geldige tekens worden gezien de ASCII-characters:<br>"a-z", "A-Z", "0-9", "<spatie>", ".", "-", "\_", "(" en ")"
* Het aangeleverde bestand mag niet beveiligd zijn met een wachtwoord.

### XML

Het format waarin data worden geleverd is GML 3.2.1. simple features profile 2 (SF-2).

De aangeleverde netinformatie XML wordt gecontroleerd op de volgende punten:

#### Encoding, tekenset
Voor de encoding van het GML bestand wordt UTF-8 gebruikt. Van UTF-8 wordt de tekenset ISO-8859-1 ondersteunt en binnen deze tekenset wordt gebruikt: unicode \[32 – 128\] en \[160 – 255\]. Opgemerkt wordt dat (U+8216), (U+8217), (U+8220), (U+8221) ook als tekens op een kaart weer te geven moeten zijn.

We controleren alleen op het UTF-8 zijn van de informatie.

#### XSD validatie

Voor IMKL2015 is een GML applicatieschema gemaakt. Datasets van utiliteitsnetten die conform deze specificatie zijn gemaakt moeten foutloos valideren tegen het IMKL2015 applicatieschema.

Het IMKL2015 UML is toegepast in 4 profielen. Voor elk van die is er een GML applicatieschema gemaakt.

De netinformatie voor KLIC wordt gevalideerd tegen de IMKL2015-wion.xsd die gepubliceerd staat op: https://register.geostandaarden.nl/gmlapplicatieschema/imkl2015/1.2.1/imkl2015-wion.xsd

Deze XSD geldt voor zowel de WION als INSPIRE.

Van de features types die beschreven zijn in de XSD accepteren we de volgende feature types niet:
* Electricity Network::ElectricityCable
* Telecommunications Network::TelecommunicationsCable
* OilGasChemicals Network::OilGasChemicalsPipe
* Water Network::WaterPipe
* Sewer Network::SewerPipe
* Thermal Network::ThermalPipe
* Common Utility Network Elements::Duct
* Common Utility Network Elements::Pipe
* Common Utility Network Elements::Appurtenance
* Common Utility Network Elements::Cabinet
* Common Utility Network Elements::Manhole
* Common Utility Network Elements::Pole
* Common Utility Network Elements::Tower
* Common Utility Network Elements::UtilityNetwork

We accepteren alleen de IMKL variant van deze feature types.

Bij het uitleveren van INSPIRE informatie zorgt het Kadaster voor de correcte INSPIRE feature benaming en filtering van attributen. In een INSPIRE levering zitten namelijk alleen features en attributen die geldig zijn binnen INSPIRE.

We ondersteunen, conform de afspraak in de Dataspecificatie IMKL2015, de volgende INSPIRE feature types ook niet:
* Common Utility Network Elements::UtilityLinkSequence; deze lijkt vooralsnog niet zinvol
* ActivityComplex; deze lijkt vooralsnog niet zinvol en er is ook geen visualisatie voor opgenomen

#### Codelijsten/Waardelijsten

De attributen die verwijzen naar code of waarde lijsten worden gevalideerd tegen de lijst gepubliceerd op https://register.geostandaarden.nl/waardelijst/imkl2015/1.2.1/imkl-waardelijsten-1.2.1.rdf.

Niet alle waardelijsten in deze publicatie hebben een betekenis binnen de WION of INSPIRE.

#### Object Identificatie

Alle concrete objecttypen en daarmee objecten in een dataset hebben een attribuut voor identificatie. Met deze identificatie kunnen ze uniek geïdentificeerd worden. INSPIRE gebruikt hiervoor het attribuut `inspireId` met het datatype `Identifier`. Veel objecttypen uit IMKL2015 overerven die attributen. Voor objecttypen die specifiek voor IMKL2015 zijn gecreëerd en die niet via een generalisatie aan INSPIRE zijn gekoppeld, is er een attribuut `identificatie` met het datatype `NEN3610ID`.

De systematiek voor het format van een identifier is gebaseerd op de combinatie van een uniek benoemde namespace voor een applicatiedomein en unieke lokale id's binnen een applicatiedomein. Omdat er voor utiliteitsnetten vele bronhouders zijn is het niet mogelijk om met één namespace te garanderen dat er in de combinatie van namespace en lokale identifier, unieke identifiers ontstaan. Om toch met één namespace te kunnen werken die het applicatiedomein representeert, is het volgende afgesproken:
* namespace: 'nl.imkl'
* lokaalID: bronhoudercode.lokaalID (met een totaal van maximaal 255 tekens)

De namespace is geregistreerd bij INSPIRE en in het nationale namespace register.

De bronhoudercode is uniek en representeert de bronhouder van de gegevens en wordt geregistreerd in een register van de nationale voorziening. Met de bronhouder wordt niet bedoeld de mogelijke inwinner van de gegevens. De code bestaat uit zes alfanumerieke posities. Dit is afgestemd met het format van CBS codes voor gemeenten en provincies.

Het lokaalID maakt het mogelijk per bronhouder de objecten uniek te identificeren. Het lokaalID is vrij door de bronhouder in te vullen en zal in de meeste gevallen gelijk zijn aan het id in de lokale registratie.
Om te voorkomen dat er eventuele dubbelingen gaan ontstaan bij objecten die door het Kadaster namens een bronhouder worden aangemaakt, mag het lokaalID echter niet beginnen met "_". Dit is voorbehouden aan objecten die door het Kadaster worden aangemaakt en daarmee onderscheidend.
Voorbeelden van identificaties van objecten die door het Kadaster namens een bronhouder kunnen worden aangemaakt:
```xml
<imkl:Belanghebbende gml:id="nl.imkl-KL9999._Belanghebbende_17G000041">
    <imkl:identificatie>
        <imkl:NEN3610ID>
            <imkl:namespace>nl.imkl</imkl:namespace>
            <imkl:lokaalID>KL9999._Belanghebbende_17G000041</imkl:lokaalID>
        </imkl:NEN3610ID>
    </imkl:identificatie>
    <imkl:beginLifespanVersion>2017-01-11T09:09:11.31+01:00</imkl:beginLifespanVersion>
    ...
    <imkl:netbeheerder xlink:href="nl.imkl-KL9999._Beheerder"/>
</imkl:Belanghebbende>
```

```xml
<imkl:EisVoorzorgsmaatregelBijlage gml:id="nl.imkl-KL9999._EisVoorzorgsmaatregelBijlage_17G000041_gasHogeDruk">
    <imkl:identificatie>
        <imkl:NEN3610ID>
            <imkl:namespace>nl.imkl</imkl:namespace>
            <imkl:lokaalID>KL9999._EisVoorzorgsmaatregelBijlage_17G000041_gasHogeDruk</imkl:lokaalID>
        </imkl:NEN3610ID>
    </imkl:identificatie>
    <imkl:beginLifespanVersion>2017-01-11T09:09:15.00+01:00</imkl:beginLifespanVersion>
    ...
</imkl:EisVoorzorgsmaatregelBijlage>
```

Het Kadaster geeft op verzoek bronhoudercodes uit.

De volgende karakters mogen in een lokaalID voorkomen: {"A"…"Z", "a"…"z", "0"…"9", "\_", "-", ",", "."}. (bron: NEN3610)

In NEN3610 en INSPIRE kunnen identifiers ook nog voorzien zijn van een versienummer van een object. Hier maken we in de IMKL2015 slechts beperkt gebruik van.

Het Kadaster controleert of aanleverende partij geautoriseerd is om gegevens te leveren met de opgegeven bronhoudercode.

#### gml:id

Elk object in het GML bestand krijgt een `gml:id`. Dit `gml:id` heeft geen informatiewaarde maar is nodig om interne en externe referenties te realiseren. De in een GML bestand opgenomen `gml:id` is een concatenatie van de volledige identifier, bestaande uit de namespace, het lokale id en eventueel een versie.

Voor het concateneren van `namespace`, `lokaalID` en mogelijk in de toekomst `versie` gebruiken we als scheidingsteken `-` (in INSPIRE-termen respectievelijk `namespace`, `localId` en `versionId`). Binnen het lokale id en de versie mogen dus geen `-`-tekens meer voorkomen.

Als scheidingsteken binnen lokaalId geldt `.`. De eerste punt komt dus na de bronhoudercode. Daarna komt de Id van de bronhouder intern en dan weer een `.` met daarna het volgnummer voor uitlevering. Binnen het Id van de bronhouder intern mag dus geen punt meer voorkomen.

#### Numerieke waarden

Numerieke waarden bij attributen worden opgenomen conform de bij het attribuut opgegeven eenheid en nauwkeurigheid.

Indien de waarde als label is opgenomen en dus een alfanumeriek datatype heeft geldt de komma als decimaal scheidingsteken. Waarden in labels worden niet gecontroleerd.

Voor de in specifieke datatypen gedefinieerde waarden geldt een punt als het afgesproken decimaal scheidingsteken. Dit wordt tijdens de XSD validatie gecontroleerd

De specifieke datatypen voor waarden zoals Measure bestaan uit een combinatie van een waarde en een eenheid (UOM). In de [Extra regels](#extra-regels) wordt dit per attribuut uitgewerkt.

##### Hoogte

De hoogte van een leidingelement is met het attribuut hoogte op te nemen. De hoogte betreft de lengte van het hele leidingelement in verticale richting ongeacht of er een deel onder of boven het maaiveld bevindt. Het datatype is 'Length' waarbij de meeteenheid apart wordt gespecificeerd. Voor WION wordt er altijd meters gebruikt met maximaal 2 decimalen.

Het aantal decimalen wordt niet gecontroleerd.

##### Diepte

Het datatype van dieptepeil is 'Measure' waarbij de meeteenheid apart wordt gespecificeerd. Voor WION wordt er altijd meters (urn:ogc:def:uom:OGC::m) gebruikt met maximaal 2 decimalen.

Het aantal decimalen wordt niet gecontroleerd.

#### Tijdaanduiding

Alle tijdsaanduidingen zijn gebaseerd op de Gregoriaanse kalender en uitgedrukt is overeenstemming met de internationale standaard ISO 8601.

Voorbeelden daarvan zijn:
* 2014; het jaar 2014
* 2014-04; april 2014
* 2014-04-15; 15 april 2014
* 2014-04-15T16:30:20+01:00; 15 april 2014, 16:30 20sec, tijdzone UTC+1

Wij bevelen aan om de tijdaanduiding te hanteren, zoals genoemd in het laatste voorbeeld. Daarmee is de lokale tijd snel inzichtelijk en wordt duidelijk rekening gehouden met zomer- en wintertijd.
Voorbeelden (wisseling wintertijd/zomertijd is voor Nederland in 2017 respectievelijk 26 maart en 29 oktober):
```xml
...
2017-03-26T01:59:45+01:00 <!-- wintertijd 1:59:45 -->
...
2017-03-26T03:01:45+02:00 <!-- zomertijd 3:01:45 -->
...

...
2017-10-29T01:30:45+02:00 <!-- zomertijd 1:30:45 -->
...
2017-10-29T02:30:45+02:00 <!-- zomertijd 2:30:45 -->
...
2017-10-29T02:30:45+01:00 <!-- wintertijd 2:30:45 -->
...
2017-10-29T10:30:45+01:00 <!-- wintertijd 10:30:45 -->
...
```

#### Geometrie

##### Bounding Box _(gml:boundedBy)_
Het is in GML optioneel om een bounding box te definiëren waarin een rechthoek is opgenomen die
middels een linkerbenedenhoek en rechterbovenhoek de extent van de coördinaten weergeeft.
Voor WION geldt de volgende regel:
Een bounding box is verplicht alleen voor het hele bestand bij uitleveringen en is niet opgenomen bij
individuele geometrieën.

Voorbeeld:
```xml
<gml:boundedBy>
    <gml:Envelope>
        <gml:lowerCorner srsName="urn:opengis:def:crs:EPSG::28992">......</gml:lowerCorner>
        <gml:upperCorner srsName="urn:opengis:def:crs:EPSG::28992">......</gml:upperCorner>
    </gml:Envelope>
</gml:boundedBy>
```

De geometrie van de objecten wordt individueel gecontroleerd op de volgende punten:

##### Referentiestelsel en dimensie

###### srsName

srsName wordt ingevuld bij elk object op hoogste geometrie niveau.

Voor IMKL2015 is het coördinaat referentiesysteem Rijksdriehoekstelsel, epsg code 28992, verplicht en wordt dit als volgt ingevuld:

`srsName="urn:ogc:def:crs:EPSG::28992"`

###### srsDimension

De srsDimension geeft aan uit hoeveel elementen een coördinaat bestaat. Voor IMKL2015 is dat standaard 2 (x,y). Dit past ook bij het GML-SF2 profiel.

srsDimension in verplicht bij elk geometrie object en wordt als volgt ingevuld:

`srsDimension="2"`

##### Geldige geometrietype

De volgende geometrietype worden ondersteund:

| Type | in GML                      | in UML     | Restricties                                                                          | Opmerking |
|------|-----------------------------|------------|--------------------------------------------------------------------------------------|-----------|
| Punt | gml:Point                   | GM_Point   | geen                                                                                 | Zie Type  |
| Lijn | gml:LineString<br>gml:Curve | GM_Curve   | gml:LineString<br>gml:Curve met:<br>- gml:LineStringSegment                          | Zie Type  |
| Vlak | gml:Polygon                 | GM_Surface | gml:Polygon<br><br>Surface grenzen kunnen beschreven worden met:<br>- gml:LinearRing | Zie Type  |

Een geometry wordt gevalideerd tegen de regels gespecificeerd in de OpenGIS Simple Feature Specification http://www.opengeospatial.org/standards/sfa en http://www.opengeospatial.org/standards/sfs.

###### Punt

**gml:Point**

| Groep/Element/@attribute | Type               | Card. | Opmerking                                                                          |
|--------------------------|--------------------|:-----:|------------------------------------------------------------------------------------|
| @id                      | ID                 |   1   | `<nameSpace>-<lokaalID>(-<versie>)`<br>Voorbeeld: `gml:id=nl.imkl-GM0124.12345678` |
| @srsName                 | anyURI             |  0…1  | `srsName="urn:ogc:def:crs:EPSG::28992"`                                            |
| @srsDimension            | Positiveinteger    |  0…1  |                                                                                    |
| - pos                    | list of xsd:double |   1   |                                                                                    |
|   pos@srsName            | anyURI             |  0…1  |                                                                                    |
|   pos@srsDimension       | Positiveinteger    |  0…1  | `srsDimension="2"`                                                                 |

Voorbeeld:
```xml
<gml:Point srsName="urn:ogc:def:crs:EPSG::28992" gml:id="nl.imkl-KL9999.LS_p835263">
   <gml:pos srsDimension="2">155203.526 389052.316</gml:pos>
</gml:Point>
```

###### Lijn

**xml:LineString**

| Groep/Element/@attribute | Type               | Card. | Opmerking                                                                          |
|--------------------------|--------------------|:-----:|------------------------------------------------------------------------------------|
| @id                      | ID                 |   1   | `<nameSpace>-<lokaalID>(-<versie>)`<br>Voorbeeld: `gml:id=nl.imkl-GM0124.12345678` |
| @srsName                 | anyURI             |  0…1  | `srsName="urn:ogc:def:crs:EPSG::28992"`                                            |
| @srsDimension            | Positiveinteger    |  0…1  |                                                                                    |
| - posList                | list of xsd:double |   1   |                                                                                    |
|   posList@srsName        | anyURI             |  0…1  |                                                                                    |

Voorbeeld:
```xml
<gml:LineString srsName="urn:ogc:def:crs:EPSG::28992" gml:id="nl.imkl-KL9999.W_ls118334">
   <gml:posList srsDimension="2">154430.283 389769.995 154431.859 389767.832 154430.610 389766.544</gml:posList>
</gml:LineString>
```

**gml:Curve**

| Groep/Element/@attribute   | Type               | Card. | Opmerking                                                                          |
|----------------------------|--------------------|:-----:|------------------------------------------------------------------------------------|
| @id                        | ID                 |   1   | `<nameSpace>-<lokaalID>(-<versie>)`<br>Voorbeeld: `gml:id=nl.imkl-GM0124.12345678` |
| @srsName                   | anyURI             |  0…1  | `srsName="urn:ogc:def:crs:EPSG::28992"`                                            |
| @srsDimension              | Positiveinteger    |  0…1  |                                                                                    |
| - segments                 |                    |   1   |                                                                                    |
|   - LineStringSegment      |                    |  0…*  |                                                                                    |
|     - posList              | list of xsd:double |   1   |                                                                                    |
|       posList@srsName      | anyURI             |  0…1  |                                                                                    |
|       posList@srsDimension | Positiveinteger    |  0…1  | `srsDimension="2"`                                                                 |

Voorbeeld:
```xml
<gml:Curve srsName="urn:ogc:def:crs:EPSG::28992" gml:id="nl.imkl-KL9999.LS_C436270">
   <gml:segments>
      <gml:LineStringSegment>
         <gml:posList srsDimension="2">154430.283 389769.995 154431.859 389767.832 154430.610 389766.544</gml:posList>
      </gml:LineStringSegment>
   </gml:segments>
</gml:Curve>
```

Voor Curves wordt gecontroleerd dat de segmenten aan elkaar vast zitten (beginnen waar het vorige segment eindigt).

###### Vlak

**gml:Polygon**

| Groep/Element/@attribute   | Type               | Card. | Opmerking                                                                          |
|----------------------------|--------------------|:-----:|------------------------------------------------------------------------------------|
| @id                        | ID                 |   1   | `<nameSpace>-<lokaalID>(-<versie>)`<br>Voorbeeld: `gml:id=nl.imkl-GM0124.12345678` |
| @srsName                   | anyURI             |  0…1  | `srsName="urn:ogc:def:crs:EPSG::28992"`                                            |
| @srsDimension              | Positiveinteger    |  0…1  |                                                                                    |
| - exterior                 | Complex            |  0…1  |                                                                                    |
|   - LinearRing             |                    |   1   |                                                                                    |
|     - posList              | list of xsd:double |   1   |                                                                                    |
|       posList@srsName      | anyURI             |  0…1  |                                                                                    |
|       posList@srsDimension | Positiveinteger    |  0…1  | `srsDimension="2"`                                                                 |
| - interior                 | Complex            |  0…*  |                                                                                    |
|   - LinearRing             |                    |   1   |                                                                                    |
|     - posList              | list of xsd:double |   1   |                                                                                    |
|       posList@srsName      | anyURI             |  0…1  |                                                                                    |
|       posList@srsDimension | Positiveinteger    |  0…1  | `srsDimension="2"`                                                                 |

Voorbeeld:
```xml
<gml:Polygon srsName="urn:ogc:def:crs:EPSG::28992" gml:id="nl.imkl-KL9999.GHD_s538123224">
   <gml:exterior>
      <gml:LinearRing>
         <gml:posList srsDimension="2">154891.113 389309.387 154889.624 389309.867 154888.356 389310.783 154887.433 389312.047 154886.946 389313.533 154886.942 389315.098 154887.422 389316.587 154888.338 389317.854 154889.602 389318.777 154891.088 389319.264 154892.653 389319.268 154894.474 389318.984 154895.963 389318.504 154897.231 389317.588 154898.154 389316.325 154898.641 389314.838 154898.645 389313.274 154898.165 389311.785 154897.249 389310.517 154895.985 389309.594 154894.499 389309.107 154892.934 389309.103 154891.113 389309.387</gml:posList>
      </gml:LinearRing>
   </gml:exterior>
</gml:Polygon>
```

##### Geometrie niet leeg en voldoende coördinaten

De geometrie van een object wordt gevormd door een verzameling geldige coördinaten in een GML-string. Deze GML-string mag niet leeg zijn en moet uit voldoende coördinaten bestaan voor het geometrie-type: een punt bestaat uit minimaal en maximaal 1 coördinaat, een lijn uit minimaal 2 coördinaten, en een polygoon of ring uit minimaal 3 coördinaten.

Een coördinaat bevat altijd 2 ordinaten.

##### Topologisch correct

Een polygoon dient *gesloten* en *samenhangend* te zijn. Gesloten betekent dat de GML-string van een polygoon begint en eindigt met hetzelfde coördinaat.

De ring van een polygoon mag zichzelf niet snijden en moet een juiste oriëntatie hebben: een buitenring tegen de klok in (counter clockwise) en een binnenring met de klok mee (clockwise). Een binnenring mag niet buiten het gebied van een buitenring liggen. Twee identieke ringen mogen niet voorkomen in de geometrie van een object.

##### Aantal punten

Het maximaal aantal punten wat een geometrieobject mag bevatten is ingesteld op 5000 punten. Dit aantal wordt berekend door het aantal punten van de individuele geometrie-objecten op te tellen. De begin– en eindpunten van aansluitende lijnen worden daarom dubbel geteld.

##### Draairichting van polygonen

Hiervoor gelden de regels van ISO19107: Geographic information – Spatial Schema.

Voor een polygoon die je van de bovenkant bekijkt: exterior ring tegen de klok in, interior ring met de klok mee. In 2d GIS bekijk je polygonen altijd van de bovenkant.

##### Nauwkeurigheid coördinaten

Nauwkeurigheid van coördinaten is 3 decimalen. Alles wat nauwkeuriger is wordt afgerond op deze nauwkeurigheid (3 decimalen). 0.0015 -> 0.002; 0.0014 -> 0.001.

Het Kadaster controleert niet op het aantal decimalen en rond de gegevens ook niet af bij uitleveren.

### Associaties

#### href
Voor een associatie naar een ander feature in de featurecollection moet gebruik gemaakt worden van referenties (`xlink:href="..."`). In de referentie moet dan de identificatie van het gerefereerde feature worden aangegeven (`gml:id`).
Voorbeeld van een associatie van een elektriciteitskabel naar het utiliteitsnet waartoe deze behoort:
```xml
<imkl:Utiliteitsnet gml:id="nl.imkl-KL9999.netwerk_ls00058">
   ...
</imkl:Utiliteitsnet>

<imkl:Elektriciteitskabel gml:id="nl.imkl-KL9999.kb_ls07100034">
   ...
   <net:inNetwork xlink:href="nl.imkl-KL9999.netwerk_ls00058"/>
   ...
</imkl:Elektriciteitskabel>
```
Daarnaast zijn er natuurlijk associaties naar codelijsten/waardelijsten die elders beschikbaar worden gesteld. Ook deze worden gerefereerd met behulp van `xlink:href="..."`.
Voorbeelden:
```xml
<us-net-common:utilityNetworkType xlink:href="http://inspire.ec.europa.eu/codelist/UtilityNetworkTypeValue/thermal"/>

<us-net-common:authorityRole xlink:href="http://inspire.ec.europa.eu/codelist/RelatedPartyRoleValue/operator"/>

<imkl:thema xlink:href="http://definities.geostandaarden.nl/imkl2015/id/waarde/Thema/warmte"/>

<imkl:aanvraagSoort xlink:href="http://definities.geostandaarden.nl/imkl2015/id/waarde/AanvraagSoort/graafmelding"/>
```

#### Controles
Er wordt gecontroleerd of een object waar naar verwezen wordt, ook daadwerkelijk bestaat.
Momenteel wordt er niet gecontroleerd of deze associaties - functioneel gezien - juist zijn. Een elektriciteitskabel kan bijvoorbeeld verwijzen naar een utiliteitsnet die niet een thema laagspanning, middenspanning, hoogspanning of landelijkHoogspanningsnet heeft. Ook kan een netwerkelement refereren naar een ander utiliteitsnet dan de UtilityLink(s) waar vanuit dat netwerkelement naar gerefereerd wordt.

#### 1..n associaties naar Utiliteitsnet
In IMKL2015 is gemodelleerd dat een KabelEnLeidingContainer en een ContainerLeidingelement naar meerdere utiliteitsnetten kan refereren en daarmee ook naar meerdere thema's kan refereren.
Daarnaast kunnen featuretypes die vanuit een KabelEnLeidingContainer of een ContainerLeidingelement kunnen worden gerefereerd (Diepte, ExtraInformatie, ExtraGeometrie) daarmee ook naar meerdere utiliteitsnetten/thema's refereren.
Momenteel wordt de relatie vanuit deze featuretypes naar meerdere thema's nog niet ondersteund.

### Extra regels

Alleen de rode en groene INSPIRE-attributen uit het Excel-document met extra regels over de object-attributen van IMKL2015 worden hieronder toegelicht. Zie het document: https://register.geostandaarden.nl/regels/imkl2015/1.2.1/IMKL2015%20v%201.2.1_object-attributen-ExtraRegels.xlsx

#### Network Element

| Property naam                       | Card. | Extra regels                                                                                                                                                         | Implementatie-status                         |
|-------------------------------------|:-----:|----------------------------------------------------------------------------------------------------------------------------------------------------------------------|----------------------------------------------|
| **(Netwerk Element)**               |       |                                                                                                                                                                      |                                              |
| beginLifespanVersion                |   1   | Strikte verplichting IMKL. Voor niet INSPIRE plichtige dataset mag 'dummy waarde'                                                                                    | :heavy_minus_sign: Wordt niet gecontroleerd, alleen xsd-validatie |
| inspireId                           |  0…1  | Strikte verplichting IMKL; extra check op vorm IMKL identificator                                                                                                    | :heavy_check_mark:                           |
| endLifespanVersion                  |  0…1  | Geen extra regels                                                                                                                                                    | :heavy_check_mark:                           |
| inNetwork                           |   1   | Strikte verplichting IMKL; extra check of UtilityNetwork bestaat en op vorm IMKL identificator                                                                       | :heavy_check_mark: Alleen NTD, Alleen of feature bestaat |
| currentStatus                       |   1   | nilReason mag.                                                                                                                                                       | :heavy_check_mark:                           |
| validFrom                           |   1   | nilReason mag.                                                                                                                                                       | :heavy_check_mark:                           |
| validTo                             |  0…1  | Geen extra regels                                                                                                                                                    | :heavy_check_mark:                           |
| verticalPosition                    |   1   | nilReason mag.                                                                                                                                                       | :heavy_check_mark:                           |
| utilityFacilityReference            |  0…1  | Doet IMKL niets mee. nilReason mag.                                                                                                                                  | :heavy_check_mark:                           |
| governmentalServiceReference        |  0…1  | Doet IMKL niets mee. nilReason mag.                                                                                                                                  | :heavy_check_mark:                           |
|                                     |       |                                                                                                                                                                      |                                              |
| **Appurtenance**                    |       |                                                                                                                                                                      |                                              |
| geometry                            |   1   | Strikte verplichting IMKL.                                                                                                                                           | :heavy_minus_sign: Wordt niet gecontroleerd, alleen xsd-validatie |
| appurtenanceType                    |   1   | Strikte verplichting IMKL                                                                                                                                            | :heavy_check_mark:                           |
| specificAppurtenanceType            |  0…1  | Mag niet voorkomen in IMKL                                                                                                                                           | :heavy_minus_sign: Wordt niet gecontroleerd  |
| spokeEnd                            |  0…*  | nilReason mag.                                                                                                                                                       | :heavy_check_mark:                           |
| spokeStart                          |  0…*  | nilReason mag.                                                                                                                                                       | :heavy_check_mark:                           |
|                                     |       |                                                                                                                                                                      |                                              |
| **(KabelOfLeiding)**                |       |                                                                                                                                                                      |                                              |
| link                                |  1…*  | Strikte verplichting IMKL; Extra check: Alleen link naar een UtilityLink is toegestaan. UtilityLinkSequence komt niet voor.                                          | :heavy_check_mark: Alleen NTD, Alleen of feature bestaat |
| warningType                         |   1   | nilReason mag.                                                                                                                                                       | :heavy_check_mark:                           |
|                                     |       |                                                                                                                                                                      |                                              |
| **Electriciteitskabel**             |       |                                                                                                                                                                      |                                              |
| operatingVoltage                    |   1   | VerplichtDe UOM wordt uitgedrukt met urn:ogc:def:uom:OGC::V                                                                                                          | :heavy_check_mark:                           |
| nominalVoltage                      |   1   | Strikte verplichting IMKL<br>De UOM wordt uitgedrukt met urn:ogc:def:uom:OGC::V                                                                                      | :heavy_check_mark:                           |
|                                     |       |                                                                                                                                                                      |                                              |
| **Telecommunicatiekabel**           |       |                                                                                                                                                                      |                                              |
| telecommunicationsCableMaterialType |   1   | nilReason mag.                                                                                                                                                       | :heavy_check_mark:                           |
|                                     |       |                                                                                                                                                                      |                                              |
| **Duct/Kabelbed**                   |       |                                                                                                                                                                      |                                              |
| ductWidth                           |   1   | nilReason mag.<br>De UOM wordt uitgedrukt via 1 van de volgende OGC URN codes:<br>• urn:ogc:def:uom:OGC::m<br>• urn:ogc:def:uom:OGC::cm<br>• urn:ogc:def:uom:OGC::mm | :heavy_check_mark:                           |
| ducts                               |  0…*  | Geen extra regels                                                                                                                                                    | :heavy_check_mark: Alleen NTD, Alleen of feature bestaat |
| cables                              |  0…*  | Geen extra regels                                                                                                                                                    | :heavy_check_mark: Alleen NTD, Alleen of feature bestaat |
| pipes                               |  0…*  | Geen extra regels                                                                                                                                                    | :heavy_check_mark: Alleen NTD, Alleen of feature bestaat |
| aantalKabelsLeidingen               |  0…1  | Wordt opgenomen indien het aantal meer dan één is.                                                                                                                   | :heavy_minus_sign: Wordt niet gecontroleerd  |
|                                     |       |                                                                                                                                                                      |                                              |
| **(Leiding)**                       |       |                                                                                                                                                                      |                                              |
| pipeDiameter                        |   1   | nilReason mag.<br>De UOM wordt uitgedrukt via 1 van de volgende OGC URN codes:<br>• urn:ogc:def:uom:OGC::m<br>• urn:ogc:def:uom:OGC::cm<br>• urn:ogc:def:uom:OGC::mm | :heavy_check_mark:                           |
|                                     |       |                                                                                                                                                                      |                                              |
| **OlieGasChemicalienPijpleiding**   |       |                                                                                                                                                                      |                                              |
| pressure                            |  0…1  | Strikte verplichting IMKLDe UOM wordt uitgedrukt met urn:ogc:def:uom:OGC::bar                                                                                        | :heavy_check_mark:                           |
| cables                              |  0…*  | Mag niet voorkomen in IMKL                                                                                                                                           | :heavy_check_mark:                           |
| pipes                               |  0…*  | Mag niet voorkomen in IMKL                                                                                                                                           | :heavy_check_mark:                           |
| oilGasChemicalsProductType          |  1…*  | Strikte verplichting IMKL                                                                                                                                            | :heavy_check_mark:                           |
|                                     |       |                                                                                                                                                                      |                                              |
| **RioolPijpleiding**                |       |                                                                                                                                                                      |                                              |
| cables                              |  0…*  | Mag niet voorkomen in IMKL                                                                                                                                           | :heavy_check_mark:                           |
| pipes                               |  0…*  | Mag niet voorkomen in IMKL                                                                                                                                           | :heavy_check_mark:                           |
| sewerWaterType                      |   1   | Strikte verplichting IMKL                                                                                                                                            | :heavy_check_mark:                           |
|                                     |       |                                                                                                                                                                      |                                              |
| **WaterPijpleiding**                |       |                                                                                                                                                                      |                                              |
| cables                              |  0…*  | Mag niet voorkomen in IMKL                                                                                                                                           | :heavy_check_mark:                           |
| pipes                               |  0…*  | Mag niet voorkomen in IMKL                                                                                                                                           | :heavy_check_mark:                           |
| waterType                           |   1   | Strikte verplichting IMKL.                                                                                                                                           | :heavy_check_mark:                           |
|                                     |       |                                                                                                                                                                      |                                              |
| **ThermischePijpleiding**           |       |                                                                                                                                                                      |                                              |
| cables                              |  0…*  | Mag niet voorkomen in IMKL                                                                                                                                           | :heavy_check_mark:                           |
| pipes                               |  0…*  | Mag niet voorkomen in IMKL                                                                                                                                           | :heavy_check_mark:                           |
| thermalProductType                  |   1   | Strikte verplichting IMKL; extra check op codelijst                                                                                                                  | :heavy_check_mark:                           |
|                                     |       |                                                                                                                                                                      |                                              |
| **Mantelbuis**                      |       |                                                                                                                                                                      |                                              |
| pressure                            |  0…1  | Mag niet voorkomen in IMKL                                                                                                                                           | :heavy_check_mark:                           |
| cables                              |  0…*  | Geen extra regels                                                                                                                                                    | :heavy_check_mark: Alleen NTD, Alleen of feature bestaat |
| pipes                               |  0…*  | Geen extra regels                                                                                                                                                    | :heavy_check_mark: Alleen NTD, Alleen of feature bestaat |

#### Utility Node Container

| Property naam                | Card. | Extra regels                                                                                                                                       | Implementatie-status                         |
|------------------------------|:-----:|----------------------------------------------------------------------------------------------------------------------------------------------------|----------------------------------------------|
| **(Utility Node Container)** |       |                                                                                                                                                    |                                              |
| currentStatus                |   1   | nilReason mag.                                                                                                                                     | :heavy_check_mark:                           |
| validFrom                    |   1   | nilReason mag                                                                                                                                      | :heavy_check_mark:                           |
| validTo                      |  0…1  | Geen extra regels                                                                                                                                  | :heavy_check_mark:                           |
| verticalPosition             |   1   | nilReason mag                                                                                                                                      | :heavy_check_mark:                           |
| utilityFacilityReference     |  0…1  | Doet IMKL niets mee. nilReason mag.                                                                                                                | :heavy_check_mark:                           |
| governmentalServiceReference |  0…1  | Doet IMKL niets mee. nilReason mag.                                                                                                                | :heavy_check_mark:                           |
| geometry                     |   1   | Strikte verplichting IMKL.                                                                                                                         | :heavy_check_mark:                           |
| inspireId                    |  0…1  | Strikte verplichting IMKL; extra check op vorm IMKL identificator                                                                                  | :heavy_check_mark:                           |
| nodes                        |  0…*  | Aanbevolen om toe te voegen indien beschikbaar, dan ook check op vorm IMKL identificator                                                           | :heavy_check_mark: Alleen NTD, Alleen of feature bestaat |
| inNetwork                    |  1…*  | Strikte verplichting IMKL. Kan bij meerdere netwerken horen; extra check of UtilityNetwork bestaat en op vorm IMKL identificator.                  | :heavy_check_mark: Alleen NTD, Alleen of feature bestaat, Meerdere netwerken nu NIET mogelijk |
|                              |       |                                                                                                                                                    |                                              |
| **Toren**                    |       |                                                                                                                                                    |                                              |
| towerHeight                  |   1   | De UOM wordt uitgedrukt via 1 van de volgende OGC URN codes:<br>• urn:ogc:def:uom:OGC::m<br>• urn:ogc:def:uom:OGC::cm<br>• urn:ogc:def:uom:OGC::mm | :heavy_check_mark:                           |
|                              |       |                                                                                                                                                    |                                              |
| **Mast**                     |       |                                                                                                                                                    |                                              |
| poleHeight                   |   1   | De UOM wordt uitgedrukt via 1 van de volgende OGC URN codes:<br>• urn:ogc:def:uom:OGC::m<br>• urn:ogc:def:uom:OGC::cm<br>• urn:ogc:def:uom:OGC::mm | :heavy_check_mark:                           |
|                              |       |                                                                                                                                                    |                                              |
| **Mangat**                   |       |                                                                                                                                                    |                                              |
|                              |       |                                                                                                                                                    |                                              |
| **Kast**                     |       |                                                                                                                                                    |                                              |
|                              |       |                                                                                                                                                    |                                              |
| **TechnischGebouw**          |       |                                                                                                                                                    |                                              |
|                              |       |                                                                                                                                                    |                                              |

#### Utiliteitsnet

| Property naam           | Card. | Extra regels                                                                                                                                                                         | Implementatie-status                        |
|-------------------------|:-----:|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------------------------------|
| **Utiliteitsnet**       |       |                                                                                                                                                                                      |                                             |
| elements                |  0…*  | Niet gebruiken. Wordt genegeerd. NetwerkElement verwijst naar Untiliteitsnet en niet andersom.                                                                                       | :heavy_check_mark:                          |
| utilityNetworkType      |   1   | Strikte verplichting IMKL                                                                                                                                                            | :heavy_check_mark:                          |
| authorityRole           |  1…*  | Is technisch verkeerd opgenomen in INSPIRE. Strikte verplichting IMKL. Los dit op door een lege referentie optenemen.                                                                | :heavy_check_mark:                          |
| networks                |  0…*  | Voorlopig niet toestaan; Heeft geen bruikbare toepassing in KLICWIN. Zou data onnodig compliceren.                                                                                   | :heavy_minus_sign: Wordt niet gecontroleerd |
| identificatie           |   1   | Strikte verplichting IMKL; extra check op vorm IMKL identificator                                                                                                                    | :heavy_check_mark:                          |
| beginLifespanVersion    |   1   | Strikte verplichting IMKL. Voor niet INSPIRE plichtige dataset mag 'dummy waarde'                                                                                                    | :heavy_check_mark:                          |
| endLifespanVersion      |  0…1  | Geen extra regels                                                                                                                                                                    | :heavy_check_mark:                          |
| thema                   |   1   | Strikte verplichting IMKL, nilReason is niet toegelaten.                                                                                                                             | :heavy_check_mark:                          |
| technischContactpersoon |   1   | Strikte verplichting IMKL                                                                                                                                                            | :heavy_check_mark:                          |
| naam                    |   1   | Strikte verplichting IMKL, nilReason is niet toegelaten.                                                                                                                             | :heavy_check_mark:                          |
| telefoon                |   1   | Strikte verplichting IMKL, nilReason is niet toegelaten.                                                                                                                             | :heavy_check_mark:                          |
| email                   |   1   | Strikte verplichting IMKL, nilReason is niet toegelaten.                                                                                                                             | :heavy_check_mark:                          |
| standaardDieptelegging  |  0…1  | Voor WION eenheid is meter met max twee decimalen. Sterk aanbevolen om toe te voegen De UOM wordt uitgedrukt in meters middels de volgende OGC URN code:<br>• urn:ogc:def:uom:OGC::m | :heavy_check_mark: (URN code)               |
| heeftExtraInformatie    |  0…*  | Verplicht wanneer één of meerdere ExtraInformatie objecten zijn die bij het hele utiliteitsnet horen (binnen deze dataset), extra check op vorm IMKL identificator                   | :heavy_check_mark: Alleen NTD, Alleen of feature bestaat|

#### UtilityLink

Meervoudig gebruik van geometrieën (UtilityLink) is niet toegestaan.

In principe staat het INSPIRE model toe dat een UtilityLink door meerdere netwerkelementen wordt gebruikt. In de IMKL2015 uitwisseling is dat echter niet toegestaan. Elke link wordt maar door één netwerkelement gebruikt.

| Property naam                | Card. | Extra regels                                                                                                                                                                                      | Implementatie-status                                                         |
|------------------------------|:-----:|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-----------------------------------------------------------------|
| **UtilityLink**              |       |                                                                                                                                                                                                   |                                                                              |
| beginLifespanVersion         |   1   | Strikte verplichting IMKL. Voor niet INSPIRE plichtige dataset mag 'dummy waarde'                                                                                                                 | :heavy_minus_sign: Wordt niet gecontroleerd, alleen xsd-validatie |
| inspireId                    |  0…1  | Strikte verplichting IMKL; extra check op vorm IMKL identificator                                                                                                                                 | :heavy_check_mark:                                                           |
| endLifespanVersion           |  0…1  | Geen extra regels                                                                                                                                                                                 |                                                                              |
| inNetwork                    |   1   | Strikte verplichting IMKL; extra check of UtilityNetwork bestaat en op vorm identificator; 1 utilitylink mag maar door 1 Netwerkelement worden gebruikt. (geen meervoudig gebruik van geometrien) | :heavy_check_mark: Alleen NTD, Alleen of feature bestaat                     |
| centrelineGeometry           |   1   | Strikte verplichting IMKL.                                                                                                                                                                        | :heavy_minus_sign: Controle op soort geometrie Wordt niet gecontroleerd, alleen xsd-validatie |
| fictitious                   |   1   | false                                                                                                                                                                                             | :heavy_minus_sign: Wordt niet gecontroleerd, alleen xsd-validatie |
| currentStatus                |   1   | Deze info zit al in de UtilityLinkSet. Op niveau van de individuele link is dit niet meer nodig. Wordt bijgevolg genegeerd als toch meegegeven wordt.                                             |                                                                              |
| validFrom                    |   1   | Deze info zit al in de UtilityLinkSet. Op niveau van de individuele link is dit niet meer nodig. Wordt bijgevolg genegeerd als toch meegegeven wordt.                                             |                                                                              |
| validTo                      |  0…1  | Deze info zit al in de UtilityLinkSet. Op niveau van de individuele link is dit niet meer nodig. Wordt bijgevolg genegeerd als toch meegegeven wordt.                                             |                                                                              |
| verticalPosition             |   1   | Deze info zit al in de UtilityLinkSet. Op niveau van de individuele link is dit niet meer nodig. Wordt bijgevolg genegeerd als toch meegegeven wordt.                                             |                                                                              |
| utilityFacilityReference     |  0…1  | Deze info zit al in de UtilityLinkSet. Op niveau van de individuele link is dit niet meer nodig. Wordt bijgevolg genegeerd als toch meegegeven wordt.                                             |                                                                              |
| governmentalServiceReference |  0…1  | Deze info zit al in de UtilityLinkSet. Op niveau van de individuele link is dit niet meer nodig. Wordt bijgevolg genegeerd als toch meegegeven wordt.                                             |                                                                              |

#### IMKL

| Property naam                              | Card. | Extra regels                                                                                                                                                                                                                                                  | Implementatie-status                                                                              |
|--------------------------------------------|:-----:|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------|
| **(IMKLBasis)**                            |       |                                                                                                                                                                                                                                                               |                                                                                                   |
| identificatie                              |   1   | Strikte verplichting IMKL; extra check op vorm IMKL identificator                                                                                                                                                                                             | :heavy_check_mark:                                                                                |
| beginLifespanVersion                       |   1   | Strikte verplichting IMKL. Voor niet INSPIRE plichtige dataset mag 'dummy waarde'                                                                                                                                                                             | :heavy_minus_sign: Wordt niet gecontroleerd, alleen xsd-validatie                                 |
| endLifespanVersion                         |  0…1  | Geen extra regels                                                                                                                                                                                                                                             | :heavy_check_mark:                                                                                |
|                                            |       |                                                                                                                                                                                                                                                               |                                                                                                   |
| **ExtraGeometrie**                         |       |                                                                                                                                                                                                                                                               |                                                                                                   |
| vlakgeometrie2D                            |  0…*  | Geen extra regels                                                                                                                                                                                                                                             | :heavy_minus_sign: Wordt niet gecontroleerd, alleen xsd-validatie, zie ondersteunde geometriën    |
| puntgeometrie2.5D                          |  0…*  | Geen extra regels                                                                                                                                                                                                                                             | :heavy_minus_sign: Wordt niet gecontroleerd, alleen xsd-validatie, zie ondersteunde geometriën    |
| lijngeometrie2.5D                          |  0…*  | Geen extra regels                                                                                                                                                                                                                                             | :heavy_minus_sign: Wordt niet gecontroleerd, alleen xsd-validatie, zie ondersteunde geometriën    |
| vlakgeometrie2.5D                          |  0…*  | Geen extra regels                                                                                                                                                                                                                                             | :heavy_minus_sign: Wordt niet gecontroleerd, alleen xsd-validatie, zie ondersteunde geometriën    |
| geometrie3D                                |  0…*  | Geen extra regels                                                                                                                                                                                                                                             | :heavy_minus_sign: Wordt niet gecontroleerd, alleen xsd-validatie, zie ondersteunde geometriën    |
| inNetwork                                  |   1   | Strikte verplichting IMKL; extra check of UtilityNetwork bestaat en op vorm IMKL identificator                                                                                                                                                                | :heavy_check_mark: Alleen NTD, Alleen of feature bestaat                                          |
|                                            |       |                                                                                                                                                                                                                                                               |                                                                                                   |
| **ExtraDetailInfo**                        |       |                                                                                                                                                                                                                                                               |                                                                                                   |
| inNetwork                                  |   1   | Strikte verplichting IMKL; extra check of UtilityNetwork bestaat en op vorm IMKL identificator                                                                                                                                                                | :heavy_check_mark: Alleen NTD, Alleen of feature bestaat                                          |
| adres                                      |  0…1  | Verplicht indien betreft huisaansluiting                                                                                                                                                                                                                      | :heavy_minus_sign: Wordt niet gecontroleerd                                                       |
| extraInfoType                              |   1   | Strikte verplichting IMKL                                                                                                                                                                                                                                     | :heavy_minus_sign: Wordt niet gecontroleerd, alleen xsd-validatie                                 |
| bestandLocatie                             |   1   | Strikte verplichting IMKL; extra check op bestand en op vorm IMKL identificator                                                                                                                                                                               | :heavy_minus_sign: Wordt niet gecontroleerd, alleen xsd-validatie                                 |
| bestandMediaType                           |   1   | Strikte verplichting IMKL; extra check of in codelijst en of het bestandMediaType overeenkomt met de bestandsextensie van het bestand zelf                                                                                                                    | :heavy_minus_sign: Wordt niet gecontroleerd, behalve de codelijstwaarde                           |
| bestandIdentificator                       |   1   | Strikte verplichting IMKL                                                                                                                                                                                                                                     | :heavy_check_mark:                                                                                |
| ligging                                    |   1   | Strikte verplichting IMKL.                                                                                                                                                                                                                                    | :heavy_minus_sign: Wordt niet gecontroleerd, alleen xsd-validatie                                 |
|                                            |       |                                                                                                                                                                                                                                                               |                                                                                                   |
| **AanduidingEisVoorzorgsmaatregel**        |       |                                                                                                                                                                                                                                                               |                                                                                                   |
| inNetwork                                  |   1   | Strikte verplichting IMKL; extra check of UtilityNetwork bestaat en op vorm IMKL identificator                                                                                                                                                                | :heavy_check_mark: Alleen NTD, Alleen of feature bestaat                                          |
| eisVoorzorgsmaatregel                      |  0…1  | Verplicht bij uitlevering.                                                                                                                                                                                                                                    | :heavy_minus_sign: Wordt niet gecontroleerd                                                       |
| geometrie                                  |   1   | Strikte verplichting IMKL                                                                                                                                                                                                                                     | :heavy_minus_sign: Wordt niet gecontroleerd, alleen xsd-validatie                                 |
|                                            |       |                                                                                                                                                                                                                                                               |                                                                                                   |
| **Maatvoering**                            |       |                                                                                                                                                                                                                                                               |                                                                                                   |
| label                                      |  0…1  | Strikte verplichting in IMKL voor een maatvoeringsobject van het type maatvoeringsLabel.                                                                                                                                                                      | :heavy_minus_sign: Wordt niet gecontroleerd                                                       |
| inNetwork                                  |   1   | Strikte verplichting IMKL; extra check of UtilityNetwork bestaat en op vorm IMKL identificator                                                                                                                                                                | :heavy_check_mark: Alleen NTD, Alleen of feature bestaat                                          |
| maatvoeringsType                           |   1   | Strikte verplichting IMKL                                                                                                                                                                                                                                     | :heavy_check_mark:                                                                                |
| rotatiehoek                                |  0…1  | Strikte verplichting voor annotatieobjecten van het type  annotatieLabel of pijl. De unit of measure moet zijn OGC:URN:DEF:UOM:ogc:F16:deg- Bij annotatieobjecten van het type maatvoeringsLijn of annotatielijn wordt de waarde van deze property genegeerd. | :heavy_minus_sign: Wordt niet gecontroleerd                                                     |
| ligging                                    |   1   | Strikte verplichting IMKL.Toegelaten geometrietypes: - voor annotatietypes maatvoeringsHulplijn, maatvoeringsLijn en annotatielijn: enkel lijnen- voor maatvoeringsLabel, annotatieLabel, pijl: enkel punten                                                  | :heavy_minus_sign: Wordt niet gecontroleerd, alleen xsd-validatie                                 |
|                                            |       |                                                                                                                                                                                                                                                               |                                                                                                   |
| **Annotatie**                              |       |                                                                                                                                                                                                                                                               |                                                                                                   |
| label                                      |  0…1  | Strikte verplichting in IMKL voor een annotatieobject van het type annotatielabel.                                                                                                                                                                            | :heavy_minus_sign: Wordt niet gecontroleerd                                                       |
| inNetwork                                  |   1   | Strikte verplichting IMKL; extra check of UtilityNetwork bestaat en op vorm IMKL identificator                                                                                                                                                                | :heavy_check_mark: Alleen NTD, Alleen of feature bestaat                                          |
| annotatieType                              |   1   | Strikte verplichting IMKL                                                                                                                                                                                                                                     | :heavy_check_mark:                                                                                |
| rotatiehoek                                |  0…1  | Strikte verplichting voor annotatieobjecten van het type annotatieLabel of pijlpunt. De unit of measure moet zijn urn:ogc:def:uom:ogc::deg                                                                                                                    | :heavy_minus_sign: Wordt niet gecontroleerd                                                       |
| ligging                                    |   1   | Strikte verplichting IMKL.Toegelaten geometrietypes: - voor annotatietypes maatvoeringsHulplijn, maatvoeringsLijn en annotatielijn: enkel lijnen- voor maatvoeringsLabel, annotatieLabel, pijl: enkel punten                                                  | :heavy_minus_sign: Wordt niet gecontroleerd, alleen xsd-validatie                                 |
|                                            |       |                                                                                                                                                                                                                                                               |                                                                                                   |
| **EigenTopografie**                        |       |                                                                                                                                                                                                                                                               |                                                                                                   |
| status                                     |   1   | Strikte verplichting IMKL                                                                                                                                                                                                                                     | :heavy_check_mark:                                                                                |
| typeTopografischObject                     |   1   | Strikte verplichting IMKL                                                                                                                                                                                                                                     | :heavy_check_mark:                                                                                |
| ligging                                    |   1   | Strikte verplichting IMKL.Toegelaten geometrietypes:  punten, lijnen, polygonen en multigeometry bestaande uit punten, lijnen en/of polygonen                                                                                                                 | :heavy_minus_sign: Wordt niet gecontroleerd                                                       |
| inNetwork                                  |  1…*  | Strikte verplichting IMKL; extra check of UtilityNetwork bestaat en op vorm IMKL identificator                                                                                                                                                                | :heavy_check_mark: Alleen NTD, Alleen of feature bestaat, Meerdere netwerken nu NIET mogelijk.    |
|                                            |       |                                                                                                                                                                                                                                                               |                                                                                                   |
| **Bijlage / EisVoorzorgsmaatregelBijlage** |       |                                                                                                                                                                                                                                                               |                                                                                                   |
| bijlageType                                |   1   | Strikte verplichting IMKL                                                                                                                                                                                                                                     | :heavy_check_mark:                                                                                |
| bestandLocatie                             |   1   | Strikte verplichting IMKL; extra check op bestand en op vorm IMKL identificator                                                                                                                                                                               | :heavy_check_mark: Bij decentraal aanleveren                                                      |
| bestandMediaType                           |   1   | Strikte verplichting IMKL; extra check of in codelijst en of het bestandMediaType overeenkomt met de bestandsextensie van het bestand zelf                                                                                                                    | :heavy_plus_sign: Gaat gecontroleerd worden                                                       |
| bestandIdentificator                       |   1   | Strikte verplichting IMKL;                                                                                                                                                                                                                                    | :heavy_plus_sign: Gaat gecontroleerd worden                                                       |
| inNetwork                                  |   1   | Strikte verplichting IMKL; extra check of UtilityNetwork bestaat en op vorm IMKL identificator                                                                                                                                                                | :heavy_check_mark: Alleen NTD, Alleen of feature bestaat                                          |
|                                            |       |                                                                                                                                                                                                                                                               |                                                                                                   |
| **(Diepte)/DiepteTovMaaiveld**             |       |                                                                                                                                                                                                                                                               |                                                                                                   |
| diepteNauwkeurigheid                       |   1   | Strikte verplichting IMKL                                                                                                                                                                                                                                     | :heavy_check_mark:                                                                                |
| dieptePeil                                 |   1   | Strikte verplichting IMKLDe UOM wordt uitgedrukt in meters eenheid meter met max twee decimalen middels de volgende OGC URN code:<br>• urn:ogc:def:uom:OGC::m                                                                                                 | :heavy_minus_sign: Wordt niet gecontroleerd, alleen xsd-validatie                                 |
| diepteAangrijpingspunt                     |   1   | Strikte verplichting IMKL: default waarde is bovenkant                                                                                                                                                                                                        | :heavy_check_mark:                                                                                |
| inNetwork                                  |   1   | Strikte verplichting IMKL; extra check of UtilityNetwork bestaat en op vorm IMKL identificator                                                                                                                                                                | :heavy_check_mark: Alleen NTD, Alleen of feature bestaat                                          |
|                                            |       |                                                                                                                                                                                                                                                               |                                                                                                   |
| **DiepteNAP**                              |       |                                                                                                                                                                                                                                                               |                                                                                                   |
| maaiveldPeil                               |  0…1  | Voor WION is eenheid meter met max twee decimalen. Sterk aanbevolen indien beschikbaarDe UOM wordt uitgedrukt via 1 van de volgende OGC URN codes:<br>• urn:ogc:def:uom:OGC::m                                                                                | :heavy_minus_sign: Wordt niet gecontroleerd                                                       |