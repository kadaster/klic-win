# Afwijkende situatie

| Deze pagina beschrijft functionaliteit die de tweede helft van 2022 beschikbaar komt. <br>  Tot die tijd kan er alleen gebruik gemaakt worden van het [webformulier](https://www.kadaster.nl/zakelijk/informatie-per-sector/startpagina-grondroerders/melden-afwijkende-situatie). <br> Er komt ook een testfase waarin de mogelijkheid wordt geboden terugmeldingen te doen. Hiervoor zal er een eigen end-point gecommuniceerd worden. <br> Houdt [de geplande werkzaamgeden pagina](../KLIC%20-%20Geplande%20werkzaamheden.md) in de gaten voor de planning.|
|------|

## Uitleg Afwijkende Situatie
Soms ligt een kabel of leiding niet op de plek waar deze volgens de informatie zou moeten liggen. Of iemand vindt een net dat niet op de geleverde informatie staat. Dit zijn zogenoemde afwijkende situaties. Het gaat altijd om een verschil tussen de geleverde KLIC-melding en de daadwerkelijke situatie in de grond. Een terugmelding is dus altijd gerelateerd aan een KLIC-melding.

### Er zijn 3 soorten afwijkende situaties:
- `afwijkende ligging`  \
  De afstand in horizontale richting van het net verschilt in werkelijkheid meer dan 1 meter met de ligging op de verstrekte KLIC-levering.
- `niet gevonden net`  \
  Een net is op de werkelijke plaats niet gevonden, terwijl deze wel op de verstrekte KLIC-levering staat.
- `onbekend net`  \
  Er is sprake van een onbekend net als er 1 of meerdere netten gevonden worden die niet op de gebiedsinformatie vermeld staan.

### Verplichting:  
Volgens de Wet informatie-uitwisseling bovengrondse en ondergrondse netten en netwerken (WIBON) moet u als grondroerder afwijkende situaties aan het Kadaster melden.  \
Na uw melding kunt u verder met uw werkzaamheden.

### Doel:
Wanneer u een afwijkende situatie aan ons doorgeeft, verzoeken wij de netbeheerder dit te corrigeren. Mocht onduidelijk blijven wie de beheerder is van de kabel of leiding, zal de gemeente dit als weesleiding op moeten nemen. U kunt eventueel op de hoogte worden gehouden van uw terugmelding.

### Hoe te melden:
- via een webformulier van het kadaster op deze pagina:   \
  https://www.kadaster.nl/zakelijk/informatie-per-sector/startpagina-grondroerders/melden-afwijkende-situatie
- via de Kadaster KLIC-viewer (vanaf medio 2022)
- Als u gebruik maakt van een applicatie die aangesloten is op de terugmeld API (vanaf medio 2022).

### Afhandeling van terugmeldingen:
- Bij terugmeldingen binnen het Kadaster is over het algemeen de brondhouder bekend (meestal de gemeente); echter bij KLIC is de bronhouder niet (altijd) bekend.	Er is sprake van een ‘claim-proces. Hierbij worden alle vermoedelijke netbeheerders genotificeerd over de terugmelding en kunnen de bronhouders aangeven of de terugmelding betrekking heeft op hun netinformatie. De netbeheerders zijn er dan zelf verantwoordelijk voor hun administratie aan te passen indien dat van toepassing is.
- Dit 'claim proces' is onderdeel van het berichten-protocol voor netbeheerders. zie daarvoor [de berschrijving van BMKL 2.1](https://github.com/kadaster/klic-win/blob/master/BMKL/BMKL%202.1/BMKL%202.1%20(B2B-koppeling%20beheerdersinformatie).md#overzicht-bmkl-apis-voor-afhandelen-afwijkende-situatie)

# Als software ontwikkelaar aansluiten op de terugmeld API

## API-specificatie voor doen van een terugmelding afwijkende situatie
In de basis gebeurt het terugmelden van een afwijkende situatie voor KLIC via de generieke terugmeld-API van het kadaster.  \
De specificatie hiervoor is te vinden op:  \
https://www.pdok.nl/restful-api/-/article/terugmeldingen-1#

###  Autorisatie voor gebruik van API:
De API is beveiligd door middel van een API-key. U kunt een API-key opvragen voor de acceptatieomgeving (voor test- en aansluitdoeleinden) en de productie omgeving. Vraag eenvoudig uw API-key aan via API-key aanvraagformulier. U ontvangt dan binnen enkele werkdagen uw API-key.  \
https://formulieren.kadaster.nl/aanvragen_api_key_terumelding_api


### Specifieke afspraken voor terugmeldingen die betrekking hebben op de kabel en leiding informatie:


| Velden                      | beschrijving/vulling                                                                                                                                                       | in geval van `afwijkende ligging`| in geval van `onbekend net`                               | in geval van `niet gevonden net`| 
|-----------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------|----------------------------------|----------------------------------------------------------|---------------------------------|
| coordinates                 | een coördinaat in RD formaat in de buurt van de terugmelding                                                                                                               | verplicht                        | verplicht                                                | verplicht                       | 
| Registratie                 | altijd `KLIC` voor terugmeldingen die betrekking hebben op afwijkende situaties  van Kabels en/of Leiding                                                                  | verplicht                        | verplicht                                                | verplicht                       | 
| Bron                        | hiermee geeft u de naam van de applicatie op van waaruit de melding aangemaakt wordt.                                                                                      | verplicht                        | verplicht                                                | verplicht                       | 
| Situatie                    | er zijn drie opties: `afwijkende ligging`, `onbekend net` en `niet gevonden net`                                                                                           | verplicht: `afwijkende ligging`  | verplicht: `onbekend net`                                | verplicht: `niet gevonden net`  | 
| klicmeldnummer              | het nummer waarop de terugmelding betrekking heeft                                                                                                                         | verplicht                        | verplicht                                                | verplicht                       | 
| objectId                    | hier behoort het GML-id van de kabel/leiding waarop de terugmelding betrekking heeft                                                                                       | verplicht                        | niet van toepassing                                      | verplicht                       | 
| objectType                  | hier behoort het feature type (zoals genoemd in de klic-melding) van de kabel/leiding waarop de terugmelding betrekking heeft                                             | verplicht                        | niet van toepassing                                      | verplicht                       | 
| netbeheerder                | hier behoort de bronhoudercode of de naam op exact de manier waarop die ook in de KLIC-melding genoemd wordt.                                                              | verplicht                        | optioneel: het betreft dan een "vermoedelijke bronhouder"| verplicht                       | 
| thema                       | hier behoort het thema (zoals genoemd in de klic-melding) van de kabel/leiding waarop de terugmelding betrekking heeft                                                     | verplicht                        | optioneel: het betreft dan een "vermoedelijk thema"      | verplicht                       | 
| omschrijving                | omschrijving van de afwijkende ligging. Hier kan kan ook kleur, materiaal diameter etc. in het geval van een `onbekend net`                                                 | verplicht                        | verplicht (denk aan kleur, materiaal, diameter, etc.)    | verplicht                       | 
| terugmelder                 | de naam van de terugmelder                                                                                                                                                  | verplicht                        | verplicht                                                | verplicht                       | 
| bedrijfsnaam                | eventueel bedrijfsnaam waarvoor de terugmelder werkt                                                                                                                       | optioneel                        | optioneel                                                | optioneel                       | 
| email                       | emailadres van de terugmelder, voor bevestigingsmail van de terugmelding en waarmee  de netbeheerder eventueel contact kan opnemen.                                       | verplicht                        | verplicht                                                | verplicht                       | 
| telefoonnummer              | telefoonnummer van de terugmelder, zodat de netbeheerder eventueel contact kan opnemen.                                                                                    | optioneel                        | optioneel                                                | optioneel                       | 
| referentie                  | hier kan optioneel een referentie opgegeven worden waarmee de voortgang van deze terugmelding voor de terugmelder (of terugmelder app) te volgen is                      | optioneel                        | optioneel                                                | optioneel                       | 
| getekendeFeatureCoordinaten | een lijst van coördinaten in RD formaat in de buurt van de terugmelding. Kan gebruikt worden als de terugmelder in de app bijvoorbeeld de werkelijke ligging getekend heeft.| optioneel                        | optioneel                                                | optioneel                       | 



**Bijlagen (minimaal 1 verplicht)**:
-  Net als in de generieke terugmeldAPI is het mogelijk om bestanden als bijlage toe te voegen. Voor KLIC is de aanvullende eis dat minimaal 1 bijlage verplicht is. Dit betreft een werkafspraak waarop geen validatie is.  
  Denk hierbij een foto van de situatie, of een afbeelding/screenshot van een tekening of schets.


### Voorbeeld bericht

```
{
	"type": "FeatureCollection",
	"name": "TerugmeldingGeneriek",
	"crs": {
		"type": "name",
		"properties": {
			"name": "urn:ogc:def:crs:EPSG::28992"
		}
	},
	"features": [
		{
			"type": "Feature",
			"geometry": {
				"type": "Point",
				"coordinates": [
					155057.25831335414,
					387936.4399967957
				]
			},
			"properties": {
				"registratie": "KLIC",                                      // voor KLIC altijd "KLIC"
				"bron": "applicatie naam",
				"situatie": "afwijkende ligging",                           // er zijn drie opties: `afwijkende ligging`, `onbekend net` en `niet gevonden net`
				"klicmeldnummer": "22G003066",
				"objectId": "nl.imkl-TS1381.BGI_ogc00001-f",                // vullen met GMLid; optioneel bij `onbekend net`
				"objectType": "OlieGasChemicalienPijpleiding",              // vullen met FeatureType; optioneel bij `onbekend net`
				"netbeheerder": "Netbeheerder Regressie05",                 // mag BHC of de naam exact zoals die in de melding staat; optioneel bij `onbekend net`
				"thema": "buisleidingGevaarlijkeInhoud",                    // optioneel bij `onbekend net`
				"omschrijving": "Omschrijving van de afwijkende ligging.",
				"terugmelder": "G. Raver",
				"bedrijfsnaam": "Kadaster Graafbedrijf",                    // optioneel 
				"email": "klic@kadaster.nl",
				"telefoonnummer": "0612345678",                             // optioneel 
				"referentie": "Hoofdstraat Apeldoorn januari",              // optioneel 

				"getekendeFeatureCoordinaten": [                            // optioneel 
					[
						155049.15,
						387936.48
					],
					[
						155065.36,
						387936.4
					]
				]
			}
		}
	]
}
```