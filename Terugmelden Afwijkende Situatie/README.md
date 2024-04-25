# Afwijkende situatie

| Deze pagina beschrijft functionaliteit die sinds 10 januari 2023 beschikbaar is. <br>  Er kan alleen nog maar gebruik gemaakt worden van terugmeldingen via een Applicatie die aangesloten is op de terugmeld API.<br>  Houdt [de geplande werkzaamheden pagina](../KLIC%20-%20Geplande%20werkzaamheden.md) in de gaten voor eventuele aanpassingen.|
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
Volgens de Wet informatie-uitwisseling bovengrondse en ondergrondse netten en netwerken (WIBON) moet u als grondroerder afwijkende liggingen en onbekende netten aan het Kadaster melden.  \
Na uw melding kunt u verder met uw werkzaamheden.  \
Het melden van een niet gevonden net dient bij de netbeheerder zelf te gebeuren.

### Doel:
Wanneer u een afwijkende situatie aan ons doorgeeft, verzoeken wij de netbeheerder dit te corrigeren. Mocht onduidelijk blijven wie de beheerder is van de kabel of leiding, zal de gemeente dit als weesleiding op moeten nemen. U kunt eventueel op de hoogte worden gehouden van uw terugmelding.

---

## Vernieuwing Afwijkende situatie

In overleg met het KLIC Gebruikersoverleg (KGO KLIC) is KLIC het proces 'Terugmelden Afwijkende Situatie' vernieuwd en sinds januari 2023 van kracht. Doel is het vereenvoudigen van het melden en afhandelen van afwijkingen op liggingsgegevens van netinformatie. Er is een REST API ontworpen en ontwikkeld voor het proces. 

### Toelichting vernieuwde proces
- Het proces dat sinds januari 2023 van kracht is, is vergelijkbaar met het proces van terugmelden wat daarvoor gehanteerd werd.
- Zie [https://www.kadaster.nl/zakelijk/informatie-per-sector/startpagina-grondroerders/melden-afwijkende-situatie](https://www.kadaster.nl/zakelijk/informatie-per-sector/startpagina-grondroerders/melden-afwijkende-situatie) voor een uitleg.
- Het terugmeldproces maakt gebruik van andere bestaande mogelijkheden voor terugmelden binnen het Kadaster (bv voor BAG terugmeldingen).  \
Bij terugmeldingen binnen het Kadaster is over het algemeen de brondhouder bekend (meestal de gemeente). Bij KLIC is de bronhouder echter niet (altijd) bekend: *Er is sprake van een ‘claim-proces’*. Dit claim-proces bestond ook in het oude terugmeldproces en is in het vernieuwde proces gefaciliteerd via een API.

### Wijzigingen die per januari 2023 van kracht zijn:
- De mail notificatie is aangepast. Een netbeheerder wordt genotificeerd dat er voor de netbeheerder een Afwijkende Situatie is gemeld.
- In de mail notificatie worden geen bijlagen meer opgenomen met de Afwijkende Situatie stukken. 
- Door deze mail notificatie wordt de netbeheerder op de hoogste gesteld van een Afwijkende Situatie.  \
  De netbeheerder kan met behulp van de REST API alle gegevens inzien en de Afwijkende Situatie melding afhandelen.  \
  De netbeheerder kan ook met behulp de Kadaster applicatie in Mijn Kadaster, “KLIC beheren terugmelding netbeheerder”, alle gegevens inzien en bijlagen downloaden om de Afwijkende Situatie melding af te handelen.  \
  Deze applicatie van het Kadaster is vanaf 10 januari 2023 beschikbaar gesteld. 

### Wijzigingen die per mei 2024 van kracht zijn:
Sinds de invoering van het terugmeldproces via de API is het de bedoeling dat een netbeheerder aangeeft of een terugmelding betrekking heeft op zijn/haar netwerk (claimen en afwijzen).  \
Het bleek echter dat ook bij terugmeldingen van afwijkende liggingen, het voorkwam dat de netbeheerder de melding afwijst. Het proces was zo ingericht dat dan de terugmelding ook bij de andere netbeheerders uit dezelfde KLIC-melding terecht kwam ter beoordeling. Dat laatste is vanaf deze release niet meer het geval. Op het moment dat de netbeheerder de melding afwijst; wordt het proces in het geval van 'een afwijkende situatie' gestopt. De terugmelding krijgt dan ook de status "ktsAfgewezen".  \
Dit betreft een nieuwe status die is toegevoegd aan de waardelijst (https://api.klic.kadaster.nl/waardelijsten/v2/tmKlicTerugmeldStatussen/)  \
In het geval het een terugmelding betreft over een in de grond gevonden kabel/leiding, die niet op de tekening staat (onbekend net); blijft het proces van kracht waarbij alle netbeheerders uit de KLIC-melding genotificeerd worden.

Hieronder staat een overzicht van het proces bij de verschillende terugmeld scenario’s:  \
![Terugmeldproces (versimpelde representatie)](images/terugmeldproces%20(versimpeld).png)

---

## Melden (grondroerder) en claim-proces (netbeheerder)

### Hoe te melden (grondroerder):
Een afwijkende situatie doorgeven aan het Kadaster kan op de volgende wijze:
- Via de nieuwste versie van de Kadaster KLIC-viewer 
- Als u gebruik maakt van een applicatie die aangesloten is op de terugmeld API.  \
Zie de API-specificatie hieronder.

### Afhandeling van terugmeldingen (netbeheerder):
Bij terugmeldingen binnen het Kadaster is over het algemeen de bronhouder bekend (meestal de gemeente); echter bij KLIC is de bronhouder niet (altijd) bekend. Er is sprake van een ‘claim-proces. Hierbij worden alle vermoedelijke netbeheerders genotificeerd over de terugmelding en kunnen de bronhouders aangeven of de terugmelding betrekking heeft op hun netinformatie. De netbeheerders zijn er dan zelf verantwoordelijk voor hun administratie aan te passen indien dat van toepassing is.

Toelichting vernieuwde afhandeling an terugmeldingen
- Een netbeheerder wordt via de email genotificeerd dat er voor de netbeheerder een Afwijkende Situatie is gemeld. In de email notificatie worden geen bijlagen meer opgenomen met de Afwijkende Situatie stukken. Deze email notificatie wordt conform het huidige proces gestuurd naar het contact-netinformatie emailadres en kan niet uitgezet worden.
  - De netbeheerder kan met behulp van de REST API alle gegevens inzien en de Afwijkende Situatie melding afhandelen.  \
    Dit 'claim proces' is onderdeel van het berichten-protocol voor netbeheerders. zie daarvoor [de berschrijving van BMKL 2.1](https://github.com/kadaster/klic-win/blob/master/BMKL/BMKL%202.1/BMKL%202.1%20(B2B-koppeling%20beheerdersinformatie).md#overzicht-bmkl-apis-voor-afhandelen-afwijkende-situatie)
  - De netbeheerder kan ook met behulp de Kadaster applicatie in Mijn Kadaster, “KLIC beheren terugmelding netbeheerder”, alle gegevens inzien en de Afwijkende Situatie melding afhandelen.  \
    Om deze applicatie van het Kadaster zichtbaar te maken in de mijn.kadaster omegeving, moet de eerste mijn.kadaster-beheerder artikel 'KLIC webservice' en 'beheren terugmelding netbeheerder'  toevoegen aan gebruiker om toegang te krijgen tot het terugmeldingen beheerscherm.  \
        *Door het toekennen van artikel 'KLIC webservice' kan deze gebruiker ook gebruik maken van de BMKL API, voorzowel het afhandelen van terugmeldingen via de API, als het afhandelen van KLIC-meldingen (bv downloaden beheerdersinformatielevering).*  \
       *Door het toekennen van artikel 'beheren terugmelding netbeheerder' krijgt de gebruiker een 'tegel' op zijn scherm als hij inlogt op mijn.kadaster (maar zonder 'KLIC webservice' heeft hij geen rechten om er gebruik van te maken).*
  

---
# Als software ontwikkelaar aansluiten op de terugmeld API (grondroerder)

Om het terugmelden te integreren in je sofware, dient een software ontwikkelaar aan te sluiten op de terugmeld API van het Kadaster. Hieronder staan de specificaties, afspraken, en het authorisatie proces beschreven.  \
Graag willen we bij het eerste aansluiten op de API controleren dat de Terugmelding aan de KLIC afspraken voldoet. Daarom vragen wij u dan even contact op te nemen via klic@kadaster.nl om uw terugmelding te controleren.

## API-specificatie voor doen van een terugmelding afwijkende situatie
In de basis gebeurt het terugmelden van een afwijkende situatie voor KLIC via de generieke terugmeld-API van het kadaster.  \
De specificatie hiervoor is te vinden op:  \
https://www.pdok.nl/restful-api/-/article/brt-terugmeldingen

###  Autorisatie voor gebruik van API:
De API is beveiligd door middel van een API-key. U kunt een API-key opvragen voor de acceptatieomgeving (voor test- en aansluitdoeleinden) en de productie omgeving. Vraag eenvoudig uw API-key aan via API-key aanvraagformulier. U ontvangt dan binnen enkele werkdagen uw API-key.  \
https://formulieren.kadaster.nl/aanvragen_api_key_terumelding_api


### Specifieke afspraken voor terugmeldingen die betrekking hebben op de kabel en leiding informatie:


| Velden             | beschrijving/vulling                                                                                                                                                                                  | in geval van `afwijkende ligging` | in geval van `onbekend net`                               | in geval van `niet gevonden net`<br> :triangular_flag_on_post: let op: de ondersteuning in de API voor deze situatie wordt uitgefaseerd. <br> De grondroerder dient direct contact op te nemen met de netbeheerder | 
|--------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-----------------------------------|-----------------------------------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| coordinates        | een coördinaat in RD formaat in de buurt van de terugmelding                                                                                                                                          | verplicht                         | verplicht                                                 | ~~verplicht~~                                                                                                                                                                                                      | 
| Registratie        | altijd `KLIC` voor terugmeldingen die betrekking hebben op afwijkende situaties  van Kabels en/of Leiding                                                                                             | verplicht                         | verplicht                                                 | ~~verplicht~~                                                                                                                                                                                                      | 
| Bron               | hiermee geeft u de naam van de applicatie op van waaruit de melding aangemaakt wordt.                                                                                                                 | verplicht                         | verplicht                                                 | ~~verplicht~~                                                                                                                                                                                                      | 
| Situatie           | er zijn drie opties: `afwijkende ligging`, `onbekend net` en `niet gevonden net`                                                                                                                      | verplicht: `afwijkende ligging`   | verplicht: `onbekend net`                                 | verplicht: `niet gevonden net` <br> :triangular_flag_on_post: let op: wordt uiegefaserd                                                                                                                            | 
| klicmeldnummer     | het nummer waarop de terugmelding betrekking heeft                                                                                                                                                    | verplicht                         | verplicht                                                 | ~~verplicht~~                                                                                                                                                                                                      | 
| objectId           | hier behoort het GML-id van de kabel/leiding waarop de terugmelding betrekking heeft                                                                                                                  | verplicht                         | niet van toepassing                                       | ~~verplicht~~                                                                                                                                                                                                      | 
| objectType         | hier behoort het feature type (zoals genoemd in de klic-melding) van de kabel/leiding waarop de terugmelding betrekking heeft                                                                         | verplicht                         | niet van toepassing                                       | ~~verplicht~~                                                                                                                                                                                                      | 
| netbeheerder       | hier behoort de bronhoudercode of de naam op exact de manier waarop die ook in de KLIC-melding genoemd wordt.                                                                                         | verplicht                         | optioneel: het betreft dan een "vermoedelijke bronhouder" | ~~verplicht~~                                                                                                                                                                                                      | 
| thema              | hier behoort het thema (zoals genoemd in de klic-melding) van de kabel/leiding waarop de terugmelding betrekking heeft. Let op: het formaat moet een URI zijn zoals in het IMKL gebruikt wordt.       | verplicht                         | optioneel: het betreft dan een "vermoedelijk thema"       | ~~verplicht~~                                                                                                                                                                                                      | 
| omschrijving       | omschrijving van de afwijkende ligging. Hier kan kan ook kleur, materiaal diameter etc. in het geval van een `onbekend net`                                                                           | verplicht                         | verplicht (denk aan kleur, materiaal, diameter, etc.)     | ~~verplicht~~                                                                                                                                                                                                      | 
| terugmelder        | de naam van de terugmelder                                                                                                                                                                            | verplicht                         | verplicht                                                 | ~~verplicht~~                                                                                                                                                                                                      | 
| bedrijfsnaam       | eventueel bedrijfsnaam waarvoor de terugmelder werkt                                                                                                                                                  | optioneel                         | optioneel                                                 | ~~optioneel~~                                                                                                                                                                                                      | 
| email              | emailadres van de terugmelder, voor bevestigingsmail van de terugmelding en waarmee  de netbeheerder eventueel contact kan opnemen.                                                                   | verplicht                         | verplicht                                                 | ~~verplicht~~                                                                                                                                                                                                      | 
| telefoonnummer     | telefoonnummer van de terugmelder, zodat de netbeheerder eventueel contact kan opnemen.                                                                                                               | optioneel                         | optioneel                                                 | ~~optioneel~~                                                                                                                                                                                                      | 
| referentie         | hier kan optioneel een referentie opgegeven worden waarmee de voortgang van deze terugmelding voor de terugmelder (of terugmelder app) te volgen is                                                   | optioneel                         | optioneel                                                 | ~~optioneel~~                                                                                                                                                                                                      | 
| getekendeGeometrie | In GEOJSON formaat (inclusief type) de coördinaten in RD formaat in de buurt van de terugmelding. Kan gebruikt worden als de terugmelder in de app bijvoorbeeld de werkelijke ligging getekend heeft. | optioneel                         | optioneel                                                 | ~~optioneel~~, bijvoorbeeld een polygoon waar gezocht is                                                                                                                                                           | 



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
				"thema": "http://definities.geostandaarden.nl/imkl2015/id/waarde/Thema/buisleidingGevaarlijkeInhoud",                    // optioneel bij `onbekend net`
				"omschrijving": "Omschrijving van de afwijkende ligging.",
				"terugmelder": "G. Raver",
				"bedrijfsnaam": "Kadaster Graafbedrijf",                    // optioneel 
				"email": "klic@kadaster.nl",
				"telefoonnummer": "0612345678",                             // optioneel 
				"referentie": "Hoofdstraat Apeldoorn januari",              // optioneel 
				"getekendeGeometrie": {                            //  (GEOJSON formaat) optioneel
					"type": "LineString",
					"coordinates": [
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
		}
	]
}
```
