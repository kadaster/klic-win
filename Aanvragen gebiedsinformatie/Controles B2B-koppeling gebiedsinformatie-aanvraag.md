# Validaties bij B2B-koppeling gebiedsinformatie-aanvraag

Het systeem van een aanvrager kan met een B2B-koppeling een gebiedsinformatie-aanvraag (_KlicB2BAanvraag_-bericht) aanbieden aan Kadaster KLIC.  \
Voordat de aanvraag door KLIC in verwerking wordt genomen, wordt deze eerst gevalideerd. Hieronder wordt een overzicht gegeven van de belangrijkste validaties die worden uitgevoerd.  \

**Inhoudsopgave**

- [1. Controle algemene gegevens van de order](#1-controle-algemene-gegevens-van-de-order)
  - [1.1 Aantal orderregels](#11-aantal-orderregels)
  - [1.2 Klantreferentie](#12-klantreferentie)
- [2. Controle contactgegevens van de klant](#2-controle-contactgegevens-van-de-klant)
  - [2.1 Relatienummer](#21-relatienummer)
  - [2.2 Kamer van Koophandel (KvK) nummer van de klant](#22-kamer-van-koophandel-kvk-nummer-van-de-klant)
  - [2.3 Overige klantgegevens](#23-overige-klantgegevens)
  - [2.4 Contactgegevens aanvrager](#24-contactgegevens-aanvrager)
  - [2.5 Extra e-mailadres](#25-extra-e-mailadres)
- [3. Controle product](#3-controle-product)
- [4. Controle opdrachtgever](#4-controle-opdrachtgever)
  - [4.1 Bedrijfs- en contactgegevens](#41-bedrijfs--en-contactgegevens)
  - [4.2 Kamer van Koophandel (KvK) nummer van opdrachtgever](#42-kamer-van-koophandel-kvk-nummer-van-de-opdrachtgever)
  - [4.3 Binnenlands adres](#43-binnenlands-adres)
  - [4.4 Postbusadres NL](#44-postbusadres-nl)
  - [4.5 Buitenlands adres](#45-buitenlands-adres)
- [5. Controle kenmerken werkzaamheden](#5-controle-kenmerken-werkzaamheden)
  - [5.1 Aanvangsdatum graafwerkzaamheden (AanvangGraafwerkzaamheden)](#51-aanvangsdatum-graafwerkzaamheden-aanvanggraafwerkzaamheden)
  - [5.2 Gepland einde graafwerkzaamheden (EindeWerkzaamheden)](#52-gepland-einde-graafwerkzaamheden-eindewerkzaamheden)
  - [5.3 Soort werkzaamheden](#53-soort-werkzaamheden)
  - [5.4 Notitieveld](#54-notitieveld)
- [6. Controle gebiedspolygoon](#6-controle-gebiedspolygoon)
  - [6.1 Toepasselijkheid informatiepolygoon](#61-toepasselijkheid-informatiepolygoon)
  - [6.2 Geometrisch stelsel](#62-geometrisch-stelsel)
  - [6.3 Nauwkeurigheid geometrie](#63-nauwkeurigheid-geometrie)
  - [6.4 Ligging en omvang](#64-ligging-en-omvang)
  - [6.5 Specifieke controles voor informatiepolygoon](#65-specifieke-controles-voor-informatiepolygoon)
- [7. Controle dichtstbijzijnd adres (DAS)](#7-controle-dichtstbijzijnd-adres-DAS)
  - [7.1 Controles adresvelden](#71-controles-adresvelden)
  - [7.2 Toepassing `IdentificatieBAG`](#72-toepassing-identificatiebag)
- [8. Controle huisaansluitschetsadressen (HAS)](#8-controle-huisaansluitschetsadressen-has)
  - [8.1 Controles adresvelden](#81-controles-adresvelden)
  - [8.2 Toepassing `IdentificatieBAG`](#82-toepassing-identificatiebag)
- [9. Specifieke controles oriëntatieverzoek](#9-specifieke-controles-orientatieverzoek)
  - [9.1 Aanvragen in het kader van de EU-stimulering breedband (WIBON-regelgeving)](#91-aanvragen-in-het-kader-van-de-eu-stimulering-breedband-wibon-regelgeving)

**Let wel**
In versie 1.1 van de B2B-aanvraag is de interface uitgebreid met nieuwe (optionele) attributen.  \
In eerste instantie controleren we alleen of het gebruik van de nieuwe attributen valide is, en geen verstoring geeft op de verwerking in KLIC.

Vervolgens zal de functionaliteit voor het gebruik van de nieuwe attributen gefaseerd worden uitgerold.  \
Deze fasering ziet er voorlopig als volgt uit:

1. Het gebruik van `IdentificatieBAG` voor een dichtstbijzijnd adres (DAS) en een huisaansluitschets-adres (HAS).
2. Het gebruik van opties voor het aanvragen van een orientatieverzoek in het kader van de EU-stimulering breedband (`VoorbereidingMedegebruikFysiekeInfrastructuur` en `VoorbereidingCoordinatieCivieleWerken`).
3. Het vastleggen en gebruiken van een `KvkNummer` bij een aanvrager en opdrachtgever.
4. Het vastleggen en gebruiken van `Informatiepolygoon` bij een graafmelding of calamiteitenmelding.

Voor een overzicht van de geplande en gerealiseerde implementaties van deze functionaliteit, zie:
* [KLIC - Geplande werkzaamheden](../KLIC%20-%20Geplande%20werkzaamheden.md) 
* [KLIC - Release notes](../KLIC%20-%20Release%20notes.md) 


---------------------------------------------------------
## 1. Controle algemene gegevens van de order
De order waarin de gebiedsinformatie wordt aangevraagd, wordt gecontroleerd op onderstaande punten. Bij een foutsituatie wordt tevens de foutmelding genoemd.

### 1.1 Aantal orderregels
De volgende controles worden uitgevoerd:

- De order moet uit minimaal 1 orderregel bestaan (foutmelding: COR0101).
- De order mag maximaal 1 orderregel bevatten (foutmelding: COR0102).

### 1.2 Klantreferentie
Het element `Klantreferentie` mag maximaal 30 tekens bevatten (foutmelding: COR0193).

---------------------------------------------------------
## 2. Controle contactgegevens van de klant
Een order wordt vastgelegd ten behoeve van een klant (in KLIC-termen: aanvrager).  \
Van deze klant worden onderstaande controles uitgevoerd.

### 2.1 Relatienummer
Vooreerst wordt als voorwaarde gesteld dat de aanbieder van de _KlicB2BAanvraag_ dezelfde organisatie is als de aanvrager (klant), zoals deze in de aanvraag is opgenomen.
Het is (nog) niet mogelijk gemaakt dat een aanbieder namens een andere organisatie (=klant) een aanvraag indient ("serviceprovider").

Het relatienummer van de aanbieder (de klant die zich bij de toegangsdienst heeft aangemeld) moet hetzelfde zijn als het relatienummer van de aanvrager (`Order.Aanvrager.Relatienummer`) (foutmelding: COR0110).

Het element `Relatienummer` mag maximaal 10 tekens bevatten (melding COR0196).

### 2.2 Kamer van Koophandel (KvK) nummer van de klant

In versie 1.1 van het interface kan het `KvkNummer` (Kamer van Koophandel) van de aanvrager (klant) van de aanvraag worden meegegeven.  \
Er wordt niet gecontroleerd of een eventueel ingevuld KvK-nummer bestaat in de NHR-registratie en geldend is voor de aanvragende organisatie.

Het element `Klant.KvkNummer` mag maximaal 25 tekens bevatten (foutmelding: COR0208).

Op termijn zal het KvK-nummer worden overgenomen uit het klantenbeheer-systeem van Kadaster-KLIC.  \
Volg [KLIC - Geplande werkzaamheden](../KLIC%20-%20Geplande%20werkzaamheden.md) voor de implementatiestappen.

### 2.3 Overige klantgegevens
Overige gegevens van de klant worden overgenomen uit het Kadaster-portaal ten behoeve van de aanvrager-gegevens van de gebiedsinformatie-aanvraag. Het betreft:
-	bedrijfsnaam
-	e-mailadres
-	telefoonnummer

en de adresgegevens
-	straat
-	huistnummer
-	huisnummertoevoeging
-	postcode
-	plaats
-	land

Er moet een geldig telefoonnummer en/of e-mailadres geregistreerd zijn (foutmelding: COR0197).

### 2.4 Contactgegevens aanvrager
De verplichte velden voor de contactpersoon van de aanvragende organisatie worden geborgd door de XML-schema-definitie.

Het e-mailadres van de aanvrager (`Klant.Contactgegevens.Email`) moet syntactisch juist zijn (foutmelding: COR0112).

Het telefoonnummer van de aanvrager (`Klant.Contactgegevens.Telefoon`) mag geen ongeldige tekens bevatten (foutmelding: COR0195).

### 2.5 Extra e-mailadres
Het opgegeven extra e-mailadres (`Klant.ExtraEmail`) moet syntactisch juist zijn (foutmelding: COR0111).


---------------------------------------------------------
## 3. Controle product
Een aangevraagd product moet voorkomen in de lijst van producten die door het KLIC-proces via het B2B-kanaal worden afgehandeld.

Op het moment kennen we de volgende producten:
- Klic levering graafmelding
- Klic levering orientatieverzoek
- Klic levering calamiteit

De beschikbaar gestelde producten zijn opgenomen in de XSD, en worden daarmee gevalideerd.

---------------------------------------------------------
## 4. Controle opdrachtgever
Bij een graafmelding moet worden gecontroleerd of er gegevens van de opdrachtgever zijn meegegeven. Is dat niet het geval dan wordt een foutmelding teruggegeven (melding COR0130).

Alleen in geval van een graafmelding mogen gegevens van de opdrachtgever meegegeven worden. Als deze voor andere KLIC-producten ten onrechte zijn meegegeven, dan wordt een foutmelding teruggegeven (melding COR0131).

Als er wel een opdrachtgever is meegegeven, dan worden vervolgens onderstaande controles uitgevoerd.

### 4.1 Bedrijfs- en contactgegevens
De bedrijfsnaam van de opdrachtgever (`Opdrachtgever.Bedrijfsnaam`) moet zijn ingevuld (foutmelding: COR0132).  \
Eveneens moeten contactgegevens van de opdrachtgever juist zijn ingevuld. Dit geeft de volgende validaties:

- naam van contactpersoon bij opdrachtgever (`Opdrachtgever.Naam`) moet zijn ingevuld (melding COR0133)
- telefoonnummer van contactpersoon bij opdrachtgever (`Opdrachtgever.Telefoon`) moet zijn ingevuld (melding COR0134)
- e-mailadres van contactpersoon bij opdrachtgever (`Opdrachtgever.Email`) moet zijn ingevuld (melding COR0135)
- e-mailadres van contactpersoon bij opdrachtgever (`Opdrachtgever.Email`) moet syntactisch correct zijn (melding COR0136).

De adresgegevens van de opdrachtgever (`Opdrachtgever.Adres`) moeten ook ingevuld te zijn, te weten:
- valideer of de postcode (`Postcode`) is ingevuld (melding COR0140)
- valideer of het huisnummer (`Huisnummer`) is gevuld met een numerieke waarde (melding COR0141)
- als huisletter (`Huisletter`) is gevuld: valideer of dit een letter is (melding COR0142)
- als land (`Landcode`) is ingevuld: controleer of landcode bestaat in ISO-lijst (melding COR0143).

Overige validaties hangen af van het feit welk soort adres het betreft.

### 4.2 Kamer van Koophandel (KvK) nummer van opdrachtgever

In versie 1.1 van het interface kan - in geval van een graafmelding - ook het `KvkNummer` (Kamer van Koophandel) van de opdrachtgever worden meegegeven.  \
Er wordt niet gecontroleerd of een eventueel ingevuld KvK-nummer bestaat in de NHR-registratie en geldend is voor de opdrachtgevende organisatie.

Het element `Opdrachtgever.KvkNummer` mag maximaal 25 tekens bevatten (foutmelding: COR0208).

Het KvK-nummer van opdrachtgevers is niet bekend bij het Kadaster-KLIC.
Volg [KLIC - Geplande werkzaamheden](../KLIC%20-%20Geplande%20werkzaamheden.md) voor de implementatiestappen.

### 4.3 Binnenlands adres
Er is sprake van een binnenlands adres, indien
- het land niet is ingevuld, of land=="NL",
- straatnaam <> "Postbus".

De volgende controles worden uitgevoerd:
- valideer of postcode/huisnummer/huisletter/huisnummertoevoeging bestaat in BAG (melding COR0144)
- (postcode 6 posities, zonder spaties) (melding COR0144)
- als straatnaam gevuld: valideer of dezelfde als BAG (melding COR0145)
- als plaats gevuld: valideer of dezelfde als BAG (melding COR0146)

### 4.4 Postbusadres NL
Er is sprake van een binnenlands postbusadres, indien
- het land niet is ingevuld, of land=="NL".
- straatnaam == "Postbus".

De volgende controles worden uitgevoerd:
- valideer of postcode is NL-formaat (zonder spaties: 6 posities, formaat 9999XX) (melding COR0147)
- valideer of plaatsnaam is ingevuld (melding COR0148)
- valideer of plaatsnaam voorkomt in BAG (melding COR0149).

### 4.5 Buitenlands adres
Er is sprake van een buitenlands adres, indien het land <> "NL".

De volgende controles worden uitgevoerd:
- valideer of straatnaam is ingevuld (melding COR0150)
- valideer of plaatsnaam is ingevuld (melding COR0151).

Stijl van foutmeldingen:
"Het adres van opdrachtgever met postcode/aanduiding '9999XX 9aX' is ......."

---------------------------------------------------------
## 5. Controle kenmerken van werkzaamheden
Bij een graafmelding en een oriëntatieverzoek moet worden gecontroleerd of er kenmerken van de werkzaamheden zijn meegegeven.  \
Is dat niet het geval dan wordt een foutmelding teruggegeven (melding COR0180).

Bij een calamiteitenmelding moet juist worden gecontroleerd of er ten onrechte kenmerken van werkzaamheden zijn meegegeven.  \
Is dat het geval dan wordt een foutmelding teruggegeven (melding COR0181).

### 5.1 Aanvangsdatum graafwerkzaamheden (AanvangGraafwerkzaamheden)
Alleen bij een graafmelding moet aanvangsdatum voor graafwerkzaamheden (`Werkzaamheden.AanvangGraafwerkzaamheden`) worden meegegeven.  \
De volgende controles worden uitgevoerd
- dit datumveld is verplicht in te vullen (melding COR0182)
- de aanvangsdatum moet in de toekomst liggen (melding COR0183)
- de aanvangsdatum mag niet meer dan 20 werkdagen in de toekomst liggen (melding COR0184).

Bij een oriëntatieverzoek mag deze aanvangsdatum voor graafwerkzaamheden (`Werkzaamheden.AanvangGraafwerkzaamheden`) juist niet worden meegegeven.  \
De volgende controle worden uitgevoerd:
- de aanvangsdatum mag niet ingevuld zijn (melding COR0188).

### 5.2 Gepland einde graafwerkzaamheden (EindeWerkzaamheden)
Alleen bij een graafmelding moet een geplande einddatum voor graafwerkzaamheden (`Werkzaamheden.EindeWerkzaamheden`) worden meegegeven.  \
De volgende controles worden uigevoerd
- dit datumveld is verplicht in te vullen (COR0185)
- de datum van einde werkzaamheden moet in de toekomst liggen (melding COR0186)
- datum van einde werkzaamheden ligt na de aanvangsdatum van de werkzaamheden (melding COR0187).

Bij een oriëntatieverzoek mag deze einddatum voor graafwerkzaamheden (`Werkzaamheden.EindeWerkzaamheden`) juist niet worden meegegeven.  \
De volgende controle worden uitgevoerd:
- de einddatum van werkzaamheden mag niet ingevuld zijn (melding COR0189).

### 5.3 Soort werkzaamheden
De volgende controles voor het soort werkzaamheden (`Werkzaamheden.SoortWerkzaamheden`) worden uitgevoerd:
- er dient minimaal 1 soort werkzaamheid te worden opgegeven (melding COR0190)
- er mogen maximaal 6 soorten werkzaamheid worden opgegeven (een eventueel notitieveld meegerekend) (melding COR0191).

Bij een graafmelding en een oriëntatieverzoek moet er altijd minimaal één soort werkzaamheden worden opgegeven.  \
Deze verplichting is gesteld, omdat mogelijke eis voorzorgsmaatregelen mede worden bepaald op basis van de aangegeven soorten werkzaamheden.

### 5.4 Notitieveld
Op het notitieveld (`Werkzaamheden.Notitie`) worden de volgende controles uitgevoerd:
- het notitieveld mag maximaal 1000 tekens bevatten (melding COR0192).

---------------------------------------------------------
## 6. Controle gebiedspolygoon
De geometrie van de meegeleverde gebiedspolygoon/gebiedspolygonen worden op onderstaande aspecten gecontroleerd.

### 6.1 Toepasselijkheid informatiepolygoon
De volgende controle wordt uitgevoerd:
- een informatiepolygoon mag alleen opgegeven worden bij een graafmelding en een calamiteitenmelding, en niet bij een oriëntatieverzoek (melding GEO0024)

### 6.2 Geometrisch stelsel
De volgende controles worden uitgevoerd:
- de geometrie moet gespecificeerd zijn in RD-coördinaten.
Als informatie over het stelsel is meegegeven, dan dient dit het RD-stelsel te zijn (srsName="epsg:28992") (melding GEO_ERR)
- als informatie over de dimensie is meegegeven, dan dient dit 2-dimensionaal te zijn (x/y-coördinaten; srsDimension="2") (melding GEO0081)
- als informatie over de eenheid is meegegeven, dan dient dit meters te zijn (uomLabels="m m") (melding GEO0082)

### 6.3 Nauwkeurigheid geometrie
De volgende controles worden uitgevoerd:
- de coördinaten van de polygoon moeten bestaan uit gehele getallen (geen fracties), zodat deze zonder bewerking gebruikt kunnen worden voor het samenstellen van het graafbericht (melding GEO0021).
- alleen een enkelvoudige polygoon zonder gaten is toegestaan; is dit niet het geval dan wordt een foutmelding gegeven (melding GEO_ERR).
- de polygoon mag zichzelf niet kruisen of raken. Als dit wel wordt geconstateerd, dan wordt een foutmelding gegeven (melding: GEO_ERR)
- de geometrie mag niet meer lijnpunten bevatten dan het ingestelde maximum. Voor de gebiedspolygoon is dit 50 voor de informatiepolygoon is dit 200. Als dit het geval is, wordt een foutmelding teruggegeven (melding GEO_ERR)

### 6.4 Ligging en omvang
De volgende controles worden uitgevoerd:
- de punten van de geometrie moeten binnen het gebied van Nederland liggen, zoals gedefinieerd door [5700, 289700 / 290300, 640300] (melding GEO_ERR).
- het systeem controleert of de gebiedspolygoon de grenzen van de maximum grootte van het in te tekenen gebied overschrijdt. Dit zijn:
  - graafmelding 500 x 500 m
  - oriëntatieverzoek 2500 x 2500 m
  - calamiteitenmelding 500 x 500 m
als de grenswaarde wordt overschreden, wordt een foutmelding teruggegeven (melding GEO_ERR)
- het systeem controleert of de informatiepolygoon de grenzen van de maximum grootte overschrijdt. Dit betreft:
  - Informatiepolygoon 500 x 500 m  (GEO_ERR)
- niets van de graafpolygoon mag buiten informatiepolygoon liggen (melding GEO0022)
- het systeem controleert of de maximale afstand tot de graafpolygoon minder of gelijk aan 100 meter is, waarbij het toegestaan is dat eventuele gaten gevuld worden. (GEO0023)
- het systeem controleert in het geval er een informatiepolygoon is opgegeven, of de combinatie van de opgegeven graaf- en informatiepolygoon leidt tot invalide IMKL in de geometrieVoorVisualisatie (IMKL v1.2.1). Dit gebeurt als na een verschil-berekening tussen het graafgebied en de informatiegebied een meervoudig polygoon ontstaat. (GEO0025)


### 6.5 Specifieke controles voor informatiepolygoon

Voor een graafmelding en een calamiteitenmelding gaat de mogelijkheid worden geboden om rond het graafgebied een ruimer gebied aan te geven waarover informatie wordt gewenst. Dit gebied wordt gespecificeerd met een `informatiepolygoon`.  \
Een opgegeven informatiegebied moet een graafgebied volledig omvatten: niets van de graafpolygoon mag buiten de informatiepolygoon liggen.

De volgende validaties zijn van toepassing:  \
|Validatie                             | Omschrijving                                                                                                                                                        |
|--------------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------|
|Type aanvraagsoort                    | Informatiepolygoon alleen bij graafmelding en calamiteitenmelding (niet bij oriëntatieverzoek).                                                                     |
|Geometrisch valide                    | Geometrische afspraken die van toepassing zijn op graafpolygoon gelden ook voor informatiepolygoon, denk aan kruisende lijnen, geen gaten.                          |
|Geen decimalen                        | Net als een graafpolygoon is het voor de coordinaten van een informatiepolygoon alleen toegestaan om deze in gehele meters op te geven; decimalen niet toegestaan.  |
|Maximale omvang                       | Net als een graafpolygoon mag de informatiepolygoon maximaal 500x500 meter zijn.                                                                                    | 
|Maximale aantal punten                | De informatiepolygoon mag uit maximaal 200 punten bestaan.                                                                                                          |
|Relatie met graafpolygoon             | Niets van de graafpolygoon ligt buiten informatiepolygoon.                                                                                                          |
|Maximale afstand t.o.v. graafpolygoon | Maximale afstand tot de graafpolygoon is 100 meter, waarbij het toegestaan is dat eventuele gaten gevuld worden.                                                    |
|Alleen eenvoudige informatiebuffer    | Als de combinatie van graafpolygoon en informatiepolygoon leiden tot een `geometrieVoorVisualisatie` die een meervoudig polygoon is, wordt de aanvraag afgekeurd.   |

---------------------------------------------------------
## 7. Controle dichtstbijzijnd adres (DAS)
Het dichtstbijzijnd adres (locatieadres) moet ingevuld zijn als een binnenlands huisadres die terug is te vinden in BAG.

### 7.1 Controles adresvelden

De volgende controles worden uitgevoerd:
- valideer of de postcode is ingevuld (melding COR0160)
- valideer of het huisnummer is gevuld met een numerieke waarde (melding COR0161)
- als huisletter is gevuld: valideer of dit een letter is (melding COR0162)
- als land is ingevuld: valideer dat hierin "NL" staat (melding COR0163)
- als straatnaam is ingevuld: valideer dat hier geen postbus-aanduiding in staat (melding COR0167)
- valideer of postcode/huisnummer/huisletter/huisnummertoevoeging bestaat in BAG
- (postcode 6 posities, zonder spaties) (melding COR0164)
- als straatnaam gevuld: valideer of dezelfde als BAG (melding COR0165)
- als plaats gevuld: valideer of dezelfde als BAG (melding COR0166)

Stijl van foutmeldingen:
"Het locatieadres (DAS) met postcode/nummeraanduiding '999XX 9aX': ........ onjuist"

### 7.2 Toepassing `IdentificatieBAG`

Een dichtstbijzijnd adres kan worden geidentificeerd met een `IdentificatieBAG`.  \
Hierbij wordt aangesloten op het stelsel van basisregistraties, waarbij een gegeven maar op één plek wordt geidentificeerd en beschikbaar gesteld, in dit geval de BAG (Basisregistratie Adressen en Gebouwen).  \
Deze `IdentificatieBAG` is in BAG vastgelegd als identificatie van een adresseerbaar object (_Verblijfsobject_, _Ligplaats_ of _Standplaats_).

De identificatie is leidend voor de verwerking van een KLIC-aanvraag.  \
Als er van een dichtstbijzijnd adres een `IdentificatieBAG` wordt meegegeven, wordt gecontroleerd of hiervan een bijbehorend adresseerbaar object kan worden gevonden in BAG. Als er ook overige adresgegevens zijn meegegeven, dan moeten deze exact overeenstemmen met het hoofdadres van het adresseerbare object.  \
Is er geen `IdentificatieBAG` meegegeven, dan moeten minimaal een `huisnummer` en `postcode` worden meegegeven voor de bepaling van een geldig dichtstbijzijnd adres.
Het controleren van hiervoor een geldig adres kan worden gevonden in BAG en de bepaling van (een) corresponderend BAGid van adresseerbare object(en) is reeds bestaande functionaliteit.

Als er van een dichtstbijzijnd adres een `IdentificatieBAG` wordt meegegeven, hoeven geen overige adresgegevens te worden meegegeven. Het eventueel meegegeven adres moet het hoofdadres zijn van het adresseerbare object en overeenstemmen met de adresgegevens zoals deze in BAG zijn vastgelegd.
Is er geen `IdentificatieBAG` meegegeven, dan moeten minimaal een `huisnummer` en `postcode` worden meegegeven voor de bepaling van een geldig dichtstbijzijnd adres.


---------------------------------------------------------
## 8. Controle huisaansluitschetsadressen (HAS)
Het adressen voor aanvraag van huisaansluitschetsen moeten als een binnenlands huisadres zijn opgegeven die terug zijn te vinden in BAG.

Deze HAS'en kunnen alleen worden aangevraagd bij een graafmelding of oriëntatieverzoek. Als deze voor een andere melding soort worden gevraagd, wordt er een foutmelding teruggegeven (COR0178).

Maximaal mogen 100 HAS'en worden aangevraagd. Als er meer worden gevraagd, wordt een foutmelding gegeven (COR0179).

### 8.1 Controles adresvelden

Per adres worden de volgende controles uitgevoerd:
- valideer of de postcode is ingevuld (melding COR0170)
- valideer of het huisnummer is gevuld met een numerieke waarde (melding COR0171)
- als huisletter is gevuld: valideer of dit een letter is (melding COR0172)
- als land is ingevuld: valideer dat hierin "NL" staat (melding COR0173)
- als straatnaam is ingevuld: valideer dat hier geen postbus-aanduiding in staat (melding COR0177)
- valideer of postcode/huisnummer/huisletter/huisnummertoevoeging bestaat in BAG
- (postcode 6 posities, zonder spaties) (melding COR0174)
- als straatnaam gevuld: valideer of dezelfde als BAG (melding COR0175)
- als plaats gevuld: valideer of dezelfde als BAG (melding COR0176)

Stijl van foutmeldingen:
"Het HAS-adres met postcode/nummeraanduiding '999XX 9aX': ........ onjuist"

### 8.2 Toepassing `IdentificatieBAG`

Ook een huisaansluitschets-adres kan worden geidentificeerd met een `IdentificatieBAG`.  \
De identificatie is leidend voor de verwerking van een KLIC-aanvraag.

Het gebruik en de controles van adresgegevens die een huisaansluitschets-adres specificeren, is gelijksoortig aan de werking bij een dichtstbijzijnd adres. Zie [Dichtstbijzijnd adres (DAS)](#dichtstbijzijnd-adres-das).



---------------------------------------------------------
## 9. Specifieke controles oriëntatieverzoek

### 9.1 Aanvragen in het kader van de EU-stimulering breedband (WIBON-regelgeving)

In het kader van de EU-stimulering breedband (nieuwe WIBON-regelgeving) kan er een specifiek orientatieverzoek worden gedaan:
- ter voorbereiding op een verzoek tot medegebruik van fysieke infrastructuur (`VoorbereidingMedegebruikFysiekeInfrastructuur`), of
- ter voorbereiding op een verzoek tot coordinatie van civiele werken (`VoorbereidingCoordinatieCivieleWerken`).

Deze velden mogen alleen worden gebruikt bij een orientatieverzoek.  \
Slechts één van deze velden mag geselecteerd worden.
Als een van deze velden wordt gebruikt, mogen geen soorten werkzaamheden worden opgegeven.
