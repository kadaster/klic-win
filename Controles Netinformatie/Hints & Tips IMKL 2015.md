# Samenvatting bevindingen netbeheerder IMKL 2015 tot nu toe

## Introductie

Dit document bevat een korte behandeling van veel voorkomende bevindingen uit het voortraject IMKL2015. In dit traject hebben een aantal voorlopende netbeheerder IMKL 2015 data samengesteld en uitgeleverd aan het Kadaster. De bevindingen die het Kadaster hierbij heeft opgedaan zijn hier samengevat.

Dit document is geen wijziging, toelichting of aanvulling op de IMKL 2015 standaard. Hiervoor wordt naar de IMKL 2015 documentatie van Geonovum verwezen. Dit document focust op verschil van interpretatie van de standaard zonder zelf hier uitspraken over te doen.

## Doel

Doel van dit document is de lezer een samenvatting van de hands-on ervaring opgedaan uit uitwisseling van IMKL 2015 bestanden tot nu te geven. Dit kan toekomstig aansluitende Netbeheerders helpen om veelvoorkomende fouten te voorkomen, waardoor het aansluitproces soepel en effectief verloopt.

# Namespaces

De volgende bevindingen komen voort uit het gebruik van namespaces in IMKL 2015 compliant GML.

## Verkeerde namespace declaraties

De namespace van de nieuwe IMKL2015 is `"http://www.geostandaarden.nl/imkl/2015/wion/1.1"`.

Een voorbeeld van correcte namespace declaraties in IMKL 2015:

```xml
	<gml:FeatureCollection xmlns:imkl="http://www.geostandaarden.nl/imkl/2015/wion/1.1" 
		xmlns:us-net-wa="http://inspire.ec.europa.eu/schemas/us-net-wa/4.0" 
		xmlns:us-net-sw="http://inspire.ec.europa.eu/schemas/us-net-sw/4.0" 
		xmlns:us-net-common="http://inspire.ec.europa.eu/schemas/us-net-common/4.0" 
		xmlns:us-net-el="http://inspire.ec.europa.eu/schemas/us-net-el/4.0" 
		xmlns:us-net-ogc="http://inspire.ec.europa.eu/schemas/us-net-ogc/4.0" 
		xmlns:net="http://inspire.ec.europa.eu/schemas/net/4.0" 
		xmlns:base="http://inspire.ec.europa.eu/schemas/base/3.3" 
		xmlns:base2="http://inspire.ec.europa.eu/schemas/base2/1.0" 
		xmlns:gml="http://www.opengis.net/gml/3.2" 
		xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" 
		xmlns:xlink="http://www.w3.org/1999/xlink" 
		gml:id="ID_1c0c5554-5c4a-467a-a9ef-9f36b5af2bfq" 
		xsi:schemaLocation="http://www.geostandaarden.nl/imkl/2015/wion/1.1 
		https://register.geostandaarden.nl/gmlapplicatieschema/imkl2015/1.1/IMKL2015-wion.xsd">
```

## Incorrecte Imkl/2015/ namespace

Op dit moment ondersteund het Kadaster de imkl/2015/wion/1.1 namespace.

## Verkeerde character encoding

IMKL 2015 hanteert de UTF-8 encoding. Een voorbeeld van waar zoiets mis kan gaan is bijvoorbeeld het oude florijn teken.

Een correct voorbeeld:

```xml
	<?xml version="1.0" encoding="UTF-8"?>
```

## Onterecht gebruik van gml:boundedBy

`<gml:boundedBy>` is niet toegestaan. Deze tag is onderdeel van de technische GML specificatie maar niet van IMKL 2015.

## Missende namespace bij afsluitende tag

De afsluitende tag bevat verplicht een namespace. Een voorbeeld is: “Afsluitende tag voor rotatiehoek mist de namespace: `</rotatiehoek>` moet `</imkl:rotatiehoek>` zijn.”

# XSD fouten:

De vorm van de IMKL 2015 GML wordt gevalideerd door een laag validaties in de vorm van een XSD validatie. Dit niveau bevat een eigen laag feedback.

De volgende bevindingen komen voort uit validatie door XSD in IMKL 2015 compliant GML.

## Attribuut vergeten toe te voegen welke verplicht is voor dat feature type.

Bv: Element 'pipeDiameter' is verplicht binnen het IMKL maar heeft geen waarde.

Of: Rioolleiding element Currentstatus is verplicht binnen het IMKL maar heeft geen waarde.

## Attribuut toegevoegd welke niet is toegestaan voor dat feature type.

Bv: Element 'us-net-common:pressure' is niet toegestaan binnen het IMKL van dit feature type.

## Vergeten een Nil reason te geven bij het ontbreken van een waarde, daar waar deze verplicht is indien een waarde niet ingevuld is.

Bv: Attribuut 'us-net-common:verticalPosition' heeft geen waarde en geen nil reason.

## Incorrecte INSPIRE GML geometrie type Multicurve in de dataset gebruikt.

Een niet in IMKL gedefinieerd GML 3.2.1 geometrie type is gebruikt.

Bv: XSD validatiefout: cvc-complex-type.2.4.a: Invalid content was found starting with element 'gml:MultiCurve'

Het type Multicurve is ondersteund in GML echter is niet ondersteund in IMKL 2015.

## Verkeerde volgorde in opzet van GML features

Een fout in de volgorde van hóe het feature is gedefinieerd in de GML.

Bv: Invalid content was found starting with element 'imkl:Annotatie'. One of '{"http://www.opengis.net/gml/3.2":AbstractFeature}' is expected. \[lineNr: x, columnNr: y\]

# Thema’s

De volgende bevindingen komen voort uit validatie van feature type thematiek en attributen in IMKL 2015 compliant GML.

## Verouderde codelijsten gebruikt

De gebruikte codelijst voor thema’s is verouderd. De nieuwe codelijst moet worden gebruikt.

Incorrect is bijvoorbeeld: `<http://www.geonovum.nl/imkl/2015/1.0/def/Thema/water>`

Correct is hier: `<http://definities.geostandaarden.nl/imkl2015/doc/waarde/Thema/water>`

## Verkeerde codelijsten gebruikt

De gebruikte codelijst voor thema’s is niet de juiste voor dat feature. Foutcode is dan: Waarde '\[CODELIJSTWAARDE\] komt niet voor in codelijst '\[CODELIJST\]'. (Incorrecte codelijst gebruikt).

## Volgorde thema element en contactpersoon element incorrect

Volgordelijkheid: Het thema-element dient in IMKL 2015 boven het element met de contactpersoon te worden geplaatst.

## Verkeerde verwijzingen naar codelijsten

De meest voorkomende codelijst fouten zijn naar: AppurtenanceType, AuthorityRole, MaatvoeringsType, BuismateriaalType. De waarden ingevuld zijn geen onderdeel van de codelijst.

## Lege xLinks gebruikt

xLinks zonder referentie zijn niet toegestaan. `<net:inNetwork xlink:href=""/>` is bijvoorbeeld incorrect.

## Geen Unit of Measure gedefinieerd of leeg gelaten

Bijvoorbeeld een rotatiehoek moet in IMKL 2015 een OGC-compliant “Unit of measure” bevatten.

Voor bovenstaand voorbeeld: `<imkl:rotatiehoek uom="urn:ogc:def:uom:OGC::deg">`.

De waarde hiervan mag eveneens niet leeg zijn.

# ID’s en referenties

De volgende bevindingen komen voort uit validatie van ID’s en associatieve of relationele verhoudingen in IMKL 2015 compliant GML.

## INSPIRE ID of GML ID hebben een incorrect format
 
De Namespace van een INSPIRE/NEN3610 ID is altijd “nl.imkl”.

Het LocalID van een INSPIRE/NEN3610 ID bestaat altijd uit de eigen bronhoudercode gevolgd door een punt en een door de netbeheerder vrij te bepalen unieke lokale identifier.

Het GML ID wordt gevormd door de Namespace en het LocalID van het feature met een koppelteken aan elkaar te plakken.

Voorbeeld:

INSPIRE namespace: nl.imkl

INSPIRE localID: bwater.1274

GML-ID: nl.imkl-bwater.1274

## INSPIRE ID en lokaal GML ID niet gelijk voor een feature

Deze dienen voor hetzelfde feature overeen te komen.

De Concatenatie van base:namespace + base:localId moet gelijk zijn aan het GML ID.

## Feature verwijst naar een niet in dataset bestaand Utiliteitsnetwerk

Als een feature naar een utiliteitsnetwerk verwijst dient dat utiliteitsnetwerk ook binnen de dataset te bestaan. Dus bij gebruik van een xLink inNetwork GML ID verwijzen naar een binnen de dataset bestaand utiliteitsnetwerk.

## Feature verwijst naar Utilitynetwerk en een UtilityLink, maar driehoeksverhouding is inconsistent

Feature verwijst (xLink) naar een Utilitynetwerk en naar een UtilityLink. Echter die UtilityLink verwijst niet naar datzelfde Utilitynetwerk door. De verwijzing naar Utilitynetwerk vanuit een feature en de betrokken UtilityLink moet gelijk zijn.
