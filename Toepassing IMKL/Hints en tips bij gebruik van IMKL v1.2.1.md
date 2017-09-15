# Hints en tips bij het gebruik van IMKL2015 v1.2.1

**Inhoudsopgave**

- [Inleiding](#inleiding)
  - [Doel](#doel)
- [Namespaces](#namespaces)
  - [Verkeerde namespace declaraties](#verkeerde-namespace-declaraties)
  - [Incorrecte imkl/2015/ namespace](#incorrecte-imkl2015-namespace)
  - [Verkeerde character encoding](#verkeerde-character-encoding)
  - [Missende namespace bij afsluitende tag](#missende-namespace-bij-afsluitende-tag)
- [XSD fouten](#xsd-fouten)
  - [Verplicht attribuut niet toegevoegd](#verplicht-attribuut-niet-toegevoegd)
  - [Niet toegestaan attribuut toegevoegd](#niet-toegestaan-attribuut-toegevoegd)
  - [Geen NilReason opgegeven](#geen-NilReason-opgegeven)
  - [Incorrecte geometrie](#incorrecte-geometrie)
  - [Verkeerde volgorde in gml-features](#verkeerde-volgorde-in-gml-features)
  - [Volgorde van elementen](#volgorde-van-elementen)
- [Verwijzingen](#verwijzingen)
  - [Verouderde codelijst gebruikt](#verouderde-codelijst-gebruikt)
  - [Verkeerde waarde uit codelijst gebruikt](#verkeerde-waarde-uit-codelijst-gebruikt)
  - [Verwijzingen naar AppurtenanceType](#verwijzingen-naar-appurtenancetype)
  - [Verwijzingen met authorityRole](#verwijzingen-met-authorityrole)
  - [Gebruik van Maatvoering en Annotatie](#gebruik-van-maatvoering-en-annotatie)
  - [Lege xlink's](#lege-xlinks)
  - [Gebruik van eenheden (uom, Unit of Measure)](#gebruik-van-eenheden-uom-unit-of-measure)
- [Identificaties van objecten](#identificaties-van-objecten)
  - [Format van identifiers](#format-van-identifiers)
  - [Vergelijking van identifier en gml:id](#vergelijking-van-identifier-en-gmlid)
  - [Associatie naar Utiliteitsnet en UtilityLink](#associatie-naar-utiliteitsnet-en-utilitylink)
  - [Driehoeksverhouding feature - Utiliteitsnet - UtilityLink](#driehoeksverhouding-feature---utiliteitsnet---utilitylink)

## Inleiding

Met de introductie van IMKL2015 zal de wijze waarop de graafsector kabel- en leidinginformatie uitwisselt, sterk gaan veranderen. Waar tot nog deze informatie werd uitgewisseld op basis van "plaatjes" en bijlages, zal nu steeds meer informatie worden uitgewisseld op basis van objecten en vectordata (ook wel "features" genoemd).
Ondertussen hebben al veel verschillende netbeheerders enige ervaring opgedaan met de wijze waarop deze IMKL-features toegepast kunnen/moeten worden.

Dit document is ontstaan naar aanleiding van veel voorkomende bevindingen die in het voortraject bij het toepassen van IMKL2015 zijn geconstateerd. Een aantal voorlopende netbeheerders heeft in dat traject IMKL2015-data samengesteld en aangeleverd aan het Kadaster.\
Daarnaast is het document aangevuld met kleine voorbeelden hoe IMKL-features kunnen worden gebruikt. Wellicht handig als leidraad bij de toepassing van IMKL.

Dit document is geen wijziging, toelichting of aanvulling op de IMKL2015-standaard. Hiervoor wordt naar de IMKL2015-documentatie van Geonovum verwezen. Deze is terug te vinden op
https://github.com/Geonovum/imkl2015. \
Daarnaast heeft het Kadaster diverse presentaties opgesteld en voorbeelden uitgewerkt die de IMKL2015-gebruiker veel informatie kan geven over de toepassing van IMKL bij het KLIC-WIN-systeem.
Zie daarvoor ook https://github.com/kadaster/klic-win.

### Doel

Doel van dit document is de lezer een samenvatting met opgedane ervaringen te geven bij het toepassen van het IMKL2015-model tot nog toe. Dit kan toekomstig aansluitende netbeheerders helpen om veelvoorkomende fouten te voorkomen, waardoor het
aansluitproces soepel en effectief verloopt.

## Namespaces

De volgende bevindingen komen voort uit het gebruik van namespaces in IMKL2015 compliant GML.

### Verkeerde namespace declaraties

De namespace van de nieuwe IMKL2015 is `"http://www.geostandaarden.nl/imkl/2015/wion/1.2"`.
Een voorbeeld van correcte namespace declaraties in IMKL2015 met een verwijzing naar versie 1.2.1 van IMKL:

```xml
<?xml version="1.0" encoding="UTF-8"?>
<gml:FeatureCollection xmlns:imkl="http://www.geostandaarden.nl/imkl/2015/wion/1.2"
                       xmlns:us-net-wa="http://inspire.ec.europa.eu/schemas/us-net-wa/4.0"
                       xmlns:us-net-sw="http://inspire.ec.europa.eu/schemas/us-net-sw/4.0"
                       xmlns:us-net-th="http://inspire.ec.europa.eu/schemas/us-net-th/4.0"
                       xmlns:us-net-common="http://inspire.ec.europa.eu/schemas/us-net-common/4.0"
                       xmlns:us-net-el="http://inspire.ec.europa.eu/schemas/us-net-el/4.0"
                       xmlns:us-net-tc="http://inspire.ec.europa.eu/schemas/us-net-tc/4.0"
                       xmlns:us-net-ogc="http://inspire.ec.europa.eu/schemas/us-net-ogc/4.0"
                       xmlns:net="http://inspire.ec.europa.eu/schemas/net/4.0"
                       xmlns:base="http://inspire.ec.europa.eu/schemas/base/3.3"
                       xmlns:base2="http://inspire.ec.europa.eu/schemas/base2/2.0"
                       xmlns:gml="http://www.opengis.net/gml/3.2" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
                       xmlns:xlink="http://www.w3.org/1999/xlink" gml:id="ID_1c0c5554-5c4a-467a-a9ef-9f36b5af2bfq"
                       xsi:schemaLocation="http://www.geostandaarden.nl/imkl/2015/wion/1.2 http://register.geostandaarden.nl/gmlapplicatieschema/imkl2015/1.2.1/imkl2015-wion.xsd">
```

### Incorrecte imkl/2015/ namespace

Op dit moment ondersteunt het Kadaster de imkl/2015/wion/1.2 namespace.

### Verkeerde character encoding

IMKL2015 hanteert de UTF-8 encoding. Een voorbeeld van waar zoiets mis kan gaan is bijvoorbeeld het oude florijn teken.
Een correct voorbeeld:

```xml
    <?xml version="1.0" encoding="UTF-8"?>
```

### Missende namespace bij afsluitende tag

De afsluitende tag bevat verplicht een namespace.
Een voorbeeld is: “Afsluitende tag voor rotatiehoek mist de namespace: `</rotatiehoek>` moet `</imkl:rotatiehoek>` zijn.”

## XSD fouten

Een door netbeheerders aangeleverd XML-bestand met IMKL2015-features wordt gevalideerd door een laag XSD-validaties op basis van schema-definities. Dit niveau bevat een eigen laag feedback.
De volgende bevindingen komen voort uit het valideren van een XML-bestand (IMKL2015 compliant gml) op basis van de imkl2015-wion.xsd.
Het voorbeeld heeft betrekking op het aanleveren van een _Rioolleiding_ met attributen die gedefinieerd zijn volgens de onderliggende INSPIRE-definities.
In het klasse-diagram van IMKL2015 is deze beschreven volgens onderstaande figuur.

<img src="images/IMKL2015 - rioolleiding.png" width="788" height="573" />

### Verplicht attribuut niet toegevoegd

Attribuut vergeten toe te voegen welke verplicht is voor dat feature type.

voorbeeld: Element `pipeDiameter` is verplicht binnen het IMKL maar heeft geen waarde.

voorbeeld: Rioolleiding element `Currentstatus` is verplicht binnen het IMKL maar heeft geen waarde.

Een syntactisch juiste invulling zou kunnen zijn:
```xml
<imkl:Rioolleiding gml:id="nl.imkl-KL9999.riool00057">
    <net:beginLifespanVersion>2001-12-17T09:30:47.00+01:00</net:beginLifespanVersion>
    <net:inspireId>
        <base:Identifier>
            <base:localId>KL9999.riool00057</base:localId>
            <base:namespace>nl.imkl</base:namespace>
        </base:Identifier>
    </net:inspireId>
    <net:inNetwork xlink:href="nl.imkl-KL9999.nw_riool00052"/>
    <net:link xlink:href="nl.imkl-KL9999.ulink_00413"/>
    <us-net-common:currentStatus xlink:href="http://inspire.ec.europa.eu/codelist/ConditionOfFacilityValue/functional"/>
    <us-net-common:validFrom>2001-12-17T09:30:47.00+01:00</us-net-common:validFrom>
    <us-net-common:verticalPosition>underground</us-net-common:verticalPosition>
    <us-net-common:warningType xlink:href="http://inspire.ec.europa.eu/codelist/WarningTypeValue/net"/>
    <us-net-common:pipeDiameter uom="urn:ogc:def:uom:OGC::cm">12</us-net-common:pipeDiameter>
    <us-net-common:pressure uom="urn:ogc:def:uom:OGC::bar">2</us-net-common:pressure>
    <us-net-sw:sewerWaterType xlink:href="http://inspire.ec.europa.eu/codelist/SewerWaterTypeValue/sanitary"/>
</imkl:Rioolleiding>
```

### Niet toegestaan attribuut toegevoegd
Attribuut toegevoegd welke niet is toegestaan voor dat feature type.

voorbeeld: Element 'us-net-el:operatingVoltage' is niet toegestaan binnen het IMKL van dit feature type.

Een syntactisch *onjuiste* invulling...:
```xml
<imkl:Rioolleiding gml:id="nl.imkl-KL9999.riool00057">
    ...
    <us-net-el:operatingVoltage uom="urn:ogc:def:uom:OGC::V">220</us-net-el:operatingVoltage>
    ...
</imkl:Rioolleiding>
```

### Geen NilReason opgegeven
Vergeten een NilReason op te geven bij het ontbreken van een waarde, daar waar deze verplicht is, indien een waarde niet ingevuld is.
In het klasse-diagram van IMKL2015 zijn deze attributen aangegeven als "\<\<voidable\>\>".

voorbeeld: Attribuut `us-net-common:verticalPosition` heeft geen waarde en geen NilReason.

In bovenstaande figuur zijn een aantal codelists getoond die bij een rioolleiding toegepast zouden kunnen worden.
Voorbeelden van syntactisch juiste invullingen zouden kunnen zijn:
```xml
    ...
    <!-- attribuutwaarden toegekend -->
    <us-net-common:currentStatus xlink:href="http://inspire.ec.europa.eu/codelist/ConditionOfFacilityValue/projected"/>
    <us-net-common:verticalPosition>underground</us-net-common:verticalPosition>
    <us-net-common:warningType xlink:href="http://inspire.ec.europa.eu/codelist/WarningTypeValue/net"/>
    <us-net-common:pipeDiameter uom="urn:ogc:def:uom:OGC::cm">12</us-net-common:pipeDiameter>
    <us-net-sw:sewerWaterType xlink:href="http://inspire.ec.europa.eu/codelist/SewerWaterTypeValue/sanitary"/>
    ...
    <!-- attribuutwaarden met NilReason -->
    <us-net-common:verticalPosition xsi:nil="true" nilReason="Withheld"/>
    <us-net-common:warningType xsi:nil="true" nilReason="Unknown"/>
    <us-net-common:pipeDiameter xsi:nil="true" nilReason="Unpopulated"/>
    ...
```

### Incorrecte geometrie
In de dataset is incorrecte INSPIRE GML geometrie gebruikt, bijvoorbeeld het type Multicurve.

voorbeeld: XSD validatiefout: cvc-complex-type.2.4.a: Invalid content was found starting with element 'gml:MultiCurve'

Een niet in IMKL gedefinieerd GML 3.2.1 geometrie type is gebruikt.
Het type Multicurve is weliswaar ondersteund in GML, echter niet ondersteund in geometrie in INSPIRE (UtilityLink).

### Verkeerde volgorde in gml-features
Een fout in de volgorde van hóe het feature is gedefinieerd in de GML.

voorbeeld:
Invalid content was found starting with element 'imkl:Annotatie'. One of '{"http://www.opengis.net/gml/3.2":AbstractFeature}' is expected. \[lineNr: x, columnNr: y\]

Voorbeeld van syntactisch juiste invulling:
```xml
<imkl:Annotatie gml:id="nl.imkl-KL9999.ann_tst00532">
	...
	<imkl:ligging>
		<gml:LineString srsName="urn:ogc:def:crs:EPSG::28992" gml:id="ID_463d65cb-8bfe-491e-837f-599efdc78bd0x-ann">
			<gml:posList>123281.263 383887.883 123279.616 383891.403</gml:posList>
		</gml:LineString>
	</imkl:ligging>
</imkl:Annotatie>
```

### Volgorde van elementen
De volgorde van de elementen `thema` en `standaardDieptelegging` is niet correct.

Voorbeeld van _onjuiste_ volgorde:
```xml
<imkl:Utiliteitsnet gml:id="nl.imkl-KL9999.nw_00004">
	<us-net-common:utilityNetworkType xlink:href="http://inspire.ec.europa.eu/codelist/UtilityNetworkTypeValue/electricity"/>
	<us-net-common:authorityRole xlink:href="http://inspire.ec.europa.eu/codelist/RelatedPartyRoleValue/operator"/>
	...
	<imkl:standaardDieptelegging uom="urn:ogc:def:uom:OGC::m">0.65</imkl:standaardDieptelegging>
	<imkl:thema xlink:href="http://definities.geostandaarden.nl/imkl2015/id/waarde/Thema/laagspanning"/>
</imkl:Utiliteitsnet>
```
Het IMKL-thema-element dient in IMKL2015 boven het optionele element `standaardDieptelegging` te worden geplaatst.


## Verwijzingen

Onderstaande bevindingen komen voort uit validaties waarbij wordt gecontroleerd of er juiste (geldige) verwijzingen worden gebruikt in de IMKL-dataset.
Let op dat bepaalde waardelijsten thema-gebonden zijn: niet elke waarde kan voor elk IMKL-thema worden gebruikt.

### Verouderde codelijst gebruikt

De gebruikte codelijst is verouderd. Er moet een referentie naar de nieuwe codelijst moet worden gebruikt.

Incorrect is bijvoorbeeld: `<imkl:thema xlink:href="http://www.geonovum.nl/imkl/2015/1.0/def/Thema/water"/>`

Correct is hier: `<imkl:thema xlink:href="http://definities.geostandaarden.nl/imkl2015/id/waarde/Thema/water"/>`

### Verkeerde waarde uit codelijst gebruikt

De ingevulde waarde komt komt niet voor in de gebruikte codelijst. Foutmelding is dan: Waarde '\[CODELIJSTWAARDE\] komt niet
voor in codelijst '\[CODELIJST\]'. (Incorrecte codelijst gebruikt).


### Verwijzingen naar AppurtenanceType

Veel voorkomende foutieve verwijzingen naar een codelijst (waardelijst) hebben betrekking op de invulling van het 'AppurtenanceType'.
Een extra bijzonderheid hierbij is dat deze waardelijst varierend is per INSPIRE-thema. Er is een verschillende codelijst voor

| INSPIRE-thema      | INSPIRE-codelijst                       | IMKL-codelijst                              |
|--------------------|-----------------------------------------|---------------------------------------------|
| electricity        | ElectricityAppurtenanceTypeValue        | ElectricityAppurtenanceTypeIMKLValue        |
| oilGasChemicals    | OilGasChemicalsAppurtenanceTypeValue    | OilGasChemicalsAppurtenanceTypeIMKLValue    |
| sewer              | SewerAppurtenanceTypeValue              | SewerAppurtenanceTypeIMKLValue              |
| telecommunications | TelecommunicationsAppurtenanceTypeValue | TelecommunicationsAppurtenanceTypeIMKLValue |
| thermal            | ThermalAppurtenanceTypeValue            | ThermalAppurtenanceTypeIMKLValue            |
| water              | WaterAppurtenanceTypeValue              | WaterAppurtenanceTypeIMKLValue              |

De toegestane waardes voor IMKL kunnen een uitbreiding of een inperking op de waardelijst zijn zoals deze in INSPIRE is gedefinieerd.
Zie daarvoor ook de Geonovum-documentatie op Github:
https://github.com/Geonovum/imkl2015/tree/master/waardelijst/1.2.1\
Het is niet de bedoeling dat gebruik wordt gemaakt van de verwijzingen naar de INSPIRE-waardelijst, omdat dan de inperking op de lijst niet wordt gerespecteerd.

In onderstaande figuur worden de toegestane waarden weergegeven voor een IMKL rioolleiding.
De waarden onder het kopje \<\<inspire\>\> met een '-' teken, zijn een inperking van de INSPIRE-codelijst. Ze mogen niet worden gebruikt.
De waarden onder het kopje \<\<imkl\>\> en \<\<gwsw\>\> zijn uitbreidingen op de INSPIRE-lijst.

<img src="images/SewerAppurtenanceTypeIMKLValue.png" width="561" height="628" />

Voorbeelden (mix van verschillende thema's):

```xml
    ...
    <!-- onderstaande verwijzing NIET gebruiken: -->
    <us-net-common:appurtenanceType xlink:href="http://inspire.ec.europa.eu/codelist/ElectricityAppurtenanceTypeValue/connectionBox"/>
    <!-- daarvoor in de plaats WEL gebruiken: -->
    <us-net-common:appurtenanceType xlink:href="http://definities.geostandaarden.nl/imkl2015/id/waarde/ElectricityAppurtenanceTypeIMKLValue/connectionBox"/>

    <us-net-common:appurtenanceType xlink:href="http://definities.geostandaarden.nl/imkl2015/id/waarde/OilGasChemicalsAppurtenanceTypeIMKLValue/pumpingStation"/>

    <us-net-common:appurtenanceType xlink:href="http://definities.geostandaarden.nl/imkl2015/id/waarde/SewerAppurtenanceTypeValue/connection"/>

    <us-net-common:appurtenanceType xlink:href="http://definities.geostandaarden.nl/imkl2015/id/waarde/TelecommunicationsAppurtenanceTypeIMKLValue/mof"/>

    <us-net-common:appurtenanceType xlink:href="http://definities.geostandaarden.nl/imkl2015/id/waarde/ThermalAppurtenanceTypeIMKLValue/puntVanLevering"/>

    <us-net-common:appurtenanceType xlink:href="http://definities.geostandaarden.nl/imkl2015/id/waarde/WaterAppurtenanceTypeIMKLValue/afsluiter"/>
    ...
```

### Verwijzingen met authorityRole

INSPIRE biedt de mogelijkheid om veel gegevens over "gerelateerde partijen" (_RelatedParty_) vast te leggen met het attribuut `authorityRole` van een _UtilityNetwork_. Het attribuut refereert naar 'Parties authorized to manage a utility network, such as maintainers, operators or owners.'. \
In het INSPIRE-model zit een omissie, waardoor het niet mogelijk is om objecten van het type "RelatedParty" vast te leggen...\
Vanuit een WION-perspectief hoeven we daar geen gebruik van te maken, omdat veel contactgegevens van netbeheerders al op een andere wijze worden geregistreerd. Denk aan de organisatiegegevens van een beheerder, verschillende contactgegevens bij een belang, of een contact bij een eis voorzorgsmaatregel.
Voor het verplicht in te vullen attribuut `authorityRole` worden nu referenties vastgelegd naar een INSPIRE-codelijst "RelatedPartyRoleValue". In de Geonovum-documentatie over waardelijsten is aangegeven dat slechts een beperkte set is toegestaan.

Waardelijst RelatedPartyRoleValue (IMKL2015 v1.2.1):

| waarde    | naam       | definitie                                                                                                    |
|-----------|------------|--------------------------------------------------------------------------------------------------------------|
| authority | autoriteit | Een betrokkene die wettelijk is verplicht om toe te zien op een hulpbron en/of bij een hulpbron betrokkenen. |
| operator  | exploitant | Een betrokkene die een hulpbron beheert.                                                                     |
| owner     | eigenaar   | Een betrokkene die een hulpbron bezit, d.w.z. aan wie een hulpbron wettelijk toebehoort.                     |

Voorbeeld van het gebruik van `authorityRole`:
```xml
<imkl:Utiliteitsnet gml:id="nl.imkl-KL9999.nw_GLD00023">
	<us-net-common:utilityNetworkType xlink:href="http://inspire.ec.europa.eu/codelist/UtilityNetworkTypeValue/oilGasChemical"/>
	<us-net-common:authorityRole xlink:href="http://inspire.ec.europa.eu/codelist/RelatedPartyRoleValue/operator"/>
	<imkl:identificatie>
		...
	</imkl:identificatie>
	...
	<imkl:thema xlink:href="http://definities.geostandaarden.nl/imkl2015/id/waarde/Thema/gasLageDruk"/>
</imkl:Utiliteitsnet>
```

### Gebruik van Maatvoering en Annotatie
De featuretypes _Maatvoering_ en _Annotatie_ ondersteunen een grote variatie aan mogelijkheden om maatvoering/annotatie te plaatsen bij liggingsgegevens van kabels en leidingen.
De relevante kenmerken van deze features, zoals gedefinieerd in IMKL2015 v1.2.1, zijn weergegeven in onderstaande figuur.

<img src="images/IMKL2015 - Maatvoering en Annotatie.png" width="895" height="542" />

De labels behorend bij de objecttypen _Maatvoering_ en _Annotatie_ worden ingevuld via het object Label.
Het af te beelden label (getal of tekst) wordt opgenomen bij het attribuut `label`. In het attribuut `omschrijving` kan een betekenis worden opgenomen.
Het plaatsingspunt van een label wordt bepaald op basis van aangrijpingspunten t.a.v. de geometrie in het attribuut `ligging`.

In onderstaand voorbeeld is een object _Maatvoering_ gespecificeerd met als `maatvoeringsType` "maatvoeringspijl" waarbij de ligging is vastgelegd met een "LineString". Het aangrijpingspunt van het label "4,5" is horizontaal en vertikaal het midden van de geometrie.

<img src="images/Voorbeeld gebruik maatvoering.png" width="149" height="171" />

```xml
<imkl:Maatvoering gml:id="nl.imkl-KL9999.mvpijl_00543">
	...
	<imkl:label>4,5</imkl:label>
	<imkl:inNetwork xlink:href="..."/>
	<imkl:maatvoeringsType xlink:href="http://definities.geostandaarden.nl/imkl2015/id/waarde/MaatvoeringsTypeValue/maatvoeringspijl"/>
	<imkl:rotatiehoek uom="urn:ogc:def:uom:OGC::deg">20</imkl:rotatiehoek>
	<imkl:labelpositie>
		<imkl:Labelpositie>
			<imkl:aangrijpingHorizontaal xlink:href="http://definities.geostandaarden.nl/imkl2015/id/waarde/LabelpositieValue/0"/>
			<imkl:aangrijpingVerticaal xlink:href="http://definities.geostandaarden.nl/imkl2015/id/waarde/LabelpositieValue/0"/>
		</imkl:Labelpositie>
	</imkl:labelpositie>
	<imkl:ligging>
		<gml:LineString srsName="urn:ogc:def:crs:EPSG::28992" gml:id="ID_463d65cb-8bfe-491e-837f-599efdc78bd0">
			<gml:posList>154965.763 389492.883 154967.803 3894488.403</gml:posList>
		</gml:LineString>
	</imkl:ligging>
</imkl:Maatvoering>
```

In de huidige praktijk blijkt dat het grootste deel van aangeleverde objecten van het type _Annotatie_ en _Maatvoering_ zijn!
Het heeft dus voorkeur om als `maatvoeringsType` en `annotatieType` waarden te gebruiken die een combinatie van verschillende objectdelen beschrijven.
Gebruik dus bijv. 1 Annotatie-object van het type 'annotatiepijlDubbelgericht' i.p.v. meerdere Annotatie-objecten van resp. de types 'annotatiepijlpunt', 'annotatielijn', 'annotatiepijlpunt' en 'annotatielabel'.

### Verwijzingen naar buismateriaal
Features die leidingen definieren (bijv. _Rioolleiding_, _Waterleiding_), objecten van het type _Mantelbuis_ en objecten van het type _Overig_ overerven van het abstracte feature _BuisSpecifiek_.
Hiermee bestaat de mogelijkheid om het buismateriaal van de leiding vast te leggen.
De te gebruiken buismaterialen zijn genoemd in de codelijst "PipeMaterialTypeIMKLValue", een set met INSPIRE-waarden aangevuld met IMKL-specifieke waarden.

Voorbeeld:
```xml

<imkl:Mantelbuis gml:id="nl.imkl-KL9999.mb_00536">
	...
	<us-net-common:verticalPosition>underground</us-net-common:verticalPosition>
	<us-net-common:warningType xlink:href="http://inspire.ec.europa.eu/codelist/WarningTypeValue/net"/>
	<us-net-common:pipeDiameter uom="urn:ogc:def:uom:OGC::cm">100</us-net-common:pipeDiameter>
	<imkl:buismateriaalType xlink:href="http://definities.geostandaarden.nl/imkl2015/id/waarde/PipeMaterialTypeIMKLValue/asbestos-cement"/>
</imkl:Mantelbuis>


<imkl:Overig gml:id="nl.imkl-KL9999.ml_00537">
	...
	<imkl:buismateriaalType xlink:href="http://definities.geostandaarden.nl/imkl2015/id/waarde/PipeMaterialTypeIMKLValue/polyester"/>
	<imkl:pipeDiameter uom="urn:ogc:def:uom:OGC::cm">12.5</imkl:pipeDiameter>
	<imkl:pressure uom="urn:ogc:def:uom:OGC::bar">5.3</imkl:pressure>
	<imkl:producttype>Melkleiding van boer naar grootafnemer</imkl:producttype>
</imkl:Overig>
```

### Lege xlink's

Het is niet toegestaan om een `xlink` te gebruiken zonder referentie.

Voorbeelden:
```xml
    <!-- NIET correct, omdat de referentie niet is ingevuld:	-->
    <net:inNetwork xlink:href=""/>

    <!-- WEL (semantisch) correct:								-->
    <net:inNetwork xlink:href="nl.imkl-KL9999.nw_riool00052"/>
    <us-net-common:utilityNetworkType xlink:href="http://inspire.ec.europa.eu/codelist/UtilityNetworkTypeValue/thermal"/>
```

### Gebruik van eenheden (uom, Unit of Measure)

Veel objecten kennen attributen waarbij een waarde opgegeven moet worden, Denk bijvoorbeeld aan `lengte`, `diepte`, `diameter`, `rotatiehoek`, `druk`, etc.
Bij deze waarden is het verplicht op de eenheid op te geven voor de betreffende waarde. Denk bijvoorbeeld aan 'm' (meter), 'cm' (centimeter), 'deg' (graden), 'bar', etc.
Bij de waarde van het attribuut moet dan een extra attribuut worden gebruikt met de toegepaste eenheid, de 'Unit of Measure (uom)'.
Deze eenheden zijn gedefinieerd door de OGC en als standaard beschikbaar gesteld (OGC URN codes), bijvoorbeeld: `<us-net-common:pipeDiameter uom="urn:ogc:def:uom:OGC::cm">`.

De toegestane eenheden varieren per soort attribuut. Zie daarvoor ook de extra regels voor object-attributen zoals gepubliceerd in de Geonovum-documentatie op Github:
https://github.com/Geonovum/imkl2015/tree/master/regels/1.2.1

Voorbeelden van het gebruik van eenheden

| objecttype                    | attribuut              | UML-type | toegestane eenheden (URN-codes) |
|-------------------------------|------------------------|----------|---------------------------------|
| Elektricteitskabel            | operatingVoltage       | Measure  | urn:ogc:def:uom:OGC::V   |
| Elektricteitskabel            | kabelDiameter          | Measure  | urn:ogc:def:uom:OGC::m   |
|                               |                        |          | urn:ogc:def:uom:OGC::cm  |
| Telecommunicatiekabel         | kabelDiameter          | Measure  | urn:ogc:def:uom:OGC::m   |
|                               |                        |          | urn:ogc:def:uom:OGC::cm  |
|                               |                        |          | urn:ogc:def:uom:OGC::mm  |
| OlieGasChemicalienPijpleiding | pipeDiameter           | Measure  | urn:ogc:def:uom:OGC::m   |
|                               |                        |          | urn:ogc:def:uom:OGC::cm  |
|                               |                        |          | urn:ogc:def:uom:OGC::mm  |
| OlieGasChemicalienPijpleiding | pressure               | Measure  | urn:ogc:def:uom:OGC::bar |
| Duct                          | ductWidth              | Length   | urn:ogc:def:uom:OGC::m   |
|                               |                        |          | urn:ogc:def:uom:OGC::cm  |
| Appurtenance                  | hoogte                 | Length   | urn:ogc:def:uom:OGC::m   |
|                               |                        |          | urn:ogc:def:uom:OGC::cm  |
|                               |                        |          | urn:ogc:def:uom:OGC::mm  |
| Toren                         | towerHeight            | Length   | urn:ogc:def:uom:OGC::m   |
|                               |                        |          | urn:ogc:def:uom:OGC::cm  |
|                               |                        |          | urn:ogc:def:uom:OGC::mm  |
| Mast                          | poleHeight             | Length   | urn:ogc:def:uom:OGC::m   |
|                               |                        |          | urn:ogc:def:uom:OGC::cm  |
|                               |                        |          | urn:ogc:def:uom:OGC::mm  |
| Maatvoering                   | rotatieHoek            | Measure  | urn:ogc:def:uom:OGC::deg |
| DiepteTovMaaiveld             | dieptePeil             | Measure  | urn:ogc:def:uom:OGC::m   |
| DiepteNAP                     | maaiveldPeil           | Measure  | urn:ogc:def:uom:OGC::m   |
| Utiliteitsnet                 | standaardDieptelegging | Measure  | urn:ogc:def:uom:OGC::m   |

Voorbeelden:
```xml
    <us-net-el:operatingVoltage uom="urn:ogc:def:uom:OGC::V">220</us-net-el:operatingVoltage>

    <imkl:kabelDiameter uom="urn:ogc:def:uom:OGC::cm">12</imkl:kabelDiameter>

    <us-net-common:pipeDiameter uom="urn:ogc:def:uom:OGC::cm">15</us-net-common:pipeDiameter>

    <us-net-common:pressure uom="urn:ogc:def:uom:OGC::bar">5</us-net-common:pressure>

    <us-net-common:ductWidth uom="urn:ogc:def:uom:OGC::cm">40</us-net-common:ductWidth>

    <imkl:hoogte uom="urn:ogc:def:uom:OGC::cm">25</imkl:hoogte>

    <us-net-common:towerHeight uom="urn:ogc:def:uom:OGC::m">112</us-net-common:towerHeight>

    <us-net-common:poleHeight uom="urn:ogc:def:uom:OGC::m">46</us-net-common:poleHeight>

    <imkl:rotatiehoek uom="urn:ogc:def:uom:OGC::deg">20</imkl:rotatiehoek>

    <imkl:dieptePeil uom="urn:ogc:def:uom:OGC::m">1.40</imkl:dieptePeil>

    <imkl:maaiveldPeil uom="urn:ogc:def:uom:OGC::m">-2.30</imkl:maaiveldPeil>

    <imkl:standaardDieptelegging uom="urn:ogc:def:uom:OGC::m">1.25</imkl:standaardDieptelegging>
```

## Identificaties van objecten

Bij het valideren van een GML-compliant dataset met IMKL-objecten wordt gecontroleerd of de objecten een (syntactisch) juiste ID hebben.
Eveneens wordt gecontroleerd op gebruikte referenties naar andere objecten uit de GML-dataset. Onderstaand overzicht zijn aandachtspunten die voortkomen uit het onjuist gebruik van (referenties naar) object-ID's.

### Format van identifiers

Objecten (ook wel 'Features') worden in INSPIRE geidentificeerd door een `inspireId` van het type `Identifier`.
In IMKL worden features geidentificeerd door een `identificatie` van het type `NEN3610ID`.

Beide identifiers hebben een attribuut `namespace`, die in beide gevallen ingevuld moet zijn met “nl.imkl”.
Ook hebben beide identifiers een attribuut ten behoeve van unieke lokale identifier van een feature, respectievelijk `localId` en `lokaalID` genoemd.
Deze lokale identifier bestaat altijd uit de eigen bronhoudercode van de netbeheerder gevolgd door een punt en een door de netbeheerder vrij te bepalen unieke lokale identifier.
De bronhoudercode is een unieke code per bronhouder, uitgegeven door het Kadaster, met als format "XX9999".

Elk object in het GML-bestand krijgt een \<gml:id\>. Dit `gml:id` heeft geen informatiewaarde maar is nodig om interne en externe referenties te realiseren.
Het `gml:id` is een concatenatie van de volledige identifier, bestaande uit de namespace en lokale identifier, met een "-" als scheidingsteken.

Er is wel een beperking aan de te gebruiken karakters van de lokale identifier. Volgens NEN3610 mogen de volgende karakters voorkomen: {”A”…”Z”, “a”…”z”, ”0”…”9”, “_”, “-“, “,”, ”.”}.
Omdat echter de karakters "." en "-" ook anderszins als scheidingsteken kunnen worden gebruikt, mogen deze NIET in de lokale identifier worden gebruikt.
Zie daarvoor ook de hoofdstukken "Identifier management" en "Nadere GML implementatie specificaties" uit het 'IMKL2015_Dataspecificatie_1.2.1.pdf' document op de Github van Geonovum: https://github.com/Geonovum/imkl2015/tree/master/informatiemodel/1.2.1.

Voorbeeld van een INSPIRE-feature:
```xml
<us-net-common:UtilityLink gml:id="nl.imkl-KL9999.ul_825200388">
	<net:beginLifespanVersion>2001-12-17T09:30:47.00+01:00</net:beginLifespanVersion>
	<net:inspireId>
		<base:Identifier>
			<base:localId>KL9999.ul_825200388</base:localId>
			<base:namespace>nl.imkl</base:namespace>
		</base:Identifier>
	</net:inspireId>
	...
</us-net-common:UtilityLink>
```

Voorbeeld van een IMKL-feature:
```xml
<imkl:Utiliteitsnet gml:id="nl.imkl-KL9999.nw_GHD_509370004">
	...
	<imkl:identificatie>
		<imkl:NEN3610ID>
			<imkl:namespace>nl.imkl</imkl:namespace>
			<imkl:lokaalID>KL9999.nw_GHD_509370004</imkl:lokaalID>
		</imkl:NEN3610ID>
	</imkl:identificatie>
	...
</imkl:Utiliteitsnet>
```

### Vergelijking van identifier en gml:id

Bij een INSPIRE-object moet de concatenatie van `base:namespace` + "-" + `base:localId` gelijk zijn aan de GML-identificatie `gml:id`.
Evenzo moet bij een IMKL-object de concatenatie van `imkl:namespace` + "-" + `imkl:lokaalID` gelijk zijn aan de GML-identificatie `gml:id`.
Zie bovenstaand voorbeeld.

### Associatie naar Utiliteitsnet en UtilityLink

IMKL-objecten moeten een verwijzing hebben naar het netwerk waartoe deze behoort. Deze verwijzing wordt gemaakt met de associatie `inNetwork`.
Bij het valideren van de dataset wordt gecontroleerd of het object waarnaar wordt verwezen, binnen de dataset bestaat.
Is dat niet het geval dan wordt gemeld dat "Feature verwijst naar een niet in dataset bestaand Utiliteitsnetwerk".

IMKL-objecten die overerven van de abstracte featuretypes _KabelOfLeiding_ of _KabelEnLeidingContainer_ moeten minimaal een (1) verwijzing hebben naar een geometrie-object van het type _UtilityLink_. Deze verwijzing wordt gemaakt met de associatie `link`.

Voorbeeld van een  verwijzing naar een bestaand netwerk (zie hierboven) en een bestaande _UtilityLink_:
```xml
<imkl:OlieGasChemicalienPijpleiding gml:id="nl.imkl-KL9999.ghd_52885200018">
	<net:beginLifespanVersion>2001-12-17T09:30:47.00+01:00</net:beginLifespanVersion>
	<net:inspireId>
		<base:Identifier>
			<base:localId>KL9999.KL9999.ghd_52885200018</base:localId>
			<base:namespace>nl.imkl</base:namespace>
		</base:Identifier>
	</net:inspireId>
	<net:inNetwork xlink:href="nl.imkl-KL9999.nw_GHD_509370004"/>
	...
	<net:link xlink:href="nl.imkl-KL9999.ulink_4279931100403"/>
	...
</imkl:OlieGasChemicalienPijpleiding>

<us-net-common:UtilityLink gml:id="nl.imkl-KL9999.ulink_4279931100403">
	<net:beginLifespanVersion>2001-12-17T09:30:47.00+01:00</net:beginLifespanVersion>
	<net:inspireId>
		<base:Identifier>
			<base:localId>KL9999.ulink_4279931100403</base:localId>
			<base:namespace>nl.imkl</base:namespace>
		</base:Identifier>
	</net:inspireId>
	<net:inNetwork xlink:href="nl.imkl-KL9999.nw_GHD_509370004"/>
	<net:centrelineGeometry>
		<gml:Curve srsName="urn:ogc:def:crs:EPSG::28992" gml:id="idm522374155600">
			...
		</gml:Curve>
	</net:centrelineGeometry>
	...
</us-net-common:UtilityLink>
```

### Driehoeksverhouding feature - Utiliteitsnet - UtilityLink

Uit bovengenoemd voorbeeld is duidelijk zichtbaar dat een IMKL-feature een verwijzing heeft naar een _Utiliteitsnet_ en naar een _UtilityLink_.
Ook de _UtilityLink_ heeft een verwijzing naar een _Utiliteitsnet_ (_UtilityNetwork_).
De verwijzing naar het _Utiliteitsnet_ vanuit een IMKL-feature en de betrokken _UtilityLink_ moet gelijk zijn.
Wordt niet naar hetzelfde _Utiliteitsnet_ verwezen, dan is sprake van een inconsistente driehoeksverhouding.
