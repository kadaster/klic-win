# Release notes

### 16 mei 2018
Algemeen:
- Upgrade naar Java 8.
- Structuur verbetering in de database; hierdoor is de (eerder aangeleverde) netinformatie verwijderd.
- Validatie op gebruik standaard (namespace)prefixes in XML berichten.

WION Levering: 
- Complementeren gebiedsinformatielevering (GIL.xml).
- Complementeren leveringsinformatie (LI.xml).

EV:
- Controleren op juiste gebruikte placeholders in aangeleverde EV-sjablonen.
- Controleren op netbeheerdernetaanduidingen in de AanduidingEisVoorzorgsmaatregel-features: de netbeheerdernetaanduidingen moeten voorkomen bij de beslissingsregels.

BMKL API v2.0:
- Agentschap Telecom (AT) leestoegang verlenen.
- Gebiedsinformatielevering (GIL.xml) toegevoegd aan de service ‘Opvragen beheerdersinformatie-levering zoals deze voor belanghebbende netbeheerder is uitgeleverd bij de aangegeven beheerdersinformatie-aanvraag.’ 
- Leveringsinformatie (LI.xml) toegevoegd aan de service ‘Opvragen beheerdersinformatie-levering zoals deze voor belanghebbende netbeheerder is uitgeleverd bij de aangegeven beheerdersinformatie-aanvraag.’
- Teksten ontwikkelaarsmelding uniform gemaakt en benaming gelijkgetrokken aan IMKL benaming.
- Indien geen gegevens voor API call dan httpstatus 200 +lege lijst geven i.p.v. httpstatus 404.
- Het is als Service Provider niet meer mogelijk om gebiedsinformatieAanvragen (GIA's) van meerdere netbeheerders tegelijkertijd op te vragen middels BMKL API.
- Update BMKL API's ten aanzien van naamgeving e.d. 

Performance:
- Diverse performance verbeteringen met betrekking tot levering en de gebruikerservaringen van de door netbeheer geautoriseerde serviceprovider.

### 30 januari 2018
- Nieuwe functionaliteit: Beschikbaarheid van EV module. EV bijlagen met EV vlakken kunnen worden uitgeleverd.
- Nieuwe functionaliteit: Voorzorgsmaatregelen validatie op uniekheid prioritering per Thema en AanvraagSoort.
- Nieuwe functionaliteit: Voorzorgsmaatregelen validatie tegen KlicVoorzorgsmaatregelenBeheer-1.0.xsd.
- Nieuwe functionaliteit: Voorzorgsmaatregelen validatie op EV-sjabloon verwijzingen.
- Nieuwe functionaliteit: Voorzorgsmaatregelen validatie op bronhoudercode in attributen <lokaalID> en <bronhoudercode>.
- Fix: EV bijlagen aanwezig in de uitlevering wanneer er beheerdersinformatie (decentraal) met EV bijlagen wordt aangeleverd. Deze werden in de vorige versie niet uitgeleverd.
- Fix: EV vlak (AanduidingEisVoorzorgsmaatregel) wordt in de liggingskaart gevisualiseerd.
- Nieuwe functionaliteit: Netinformatie validatie op BAG-ID adresseerbaar object.
- Nieuwe functionaliteit: Als Centrale netbeheerder niet mogelijk om beheerdersinformatie (decentraal) aan te leveren op een gebiedsinformatieaanvraag.
- Nieuwe functionaliteit: In NTD wordt de GBKN-kaart en de selectiekaart opgenomen in de beheerdersinformatielevering.
- Verbetering: Tekst "Gereed voor handmatige controle" gewijzigd naar "Gereed voor beoordeling". Deze wordt gegeven bij het actualiseren van netinformatie en documenten.
- Diverse performance verbeteringen met betrekking tot Actualiseren netinformatie

### 2 januari 2018
- KLIC is voorbereid om nieuwe orientatieverzoeken in het kader van de WIBON te kunnen afhandelen;
Het betreft \
 a. voorbereiding voor medegebruik fysieke infrastructuur \
 b. voorbereiding voor coordinatie civiele werken
- De functionaliteit wordt geactiveerd, zodra de wetgeving in werking mag worden gesteld.

### 24 november 2017
- OAuth (Open Authorization); een open standaard voor autorisatie bij elke B2B-koppeling (REST API) van de KLIC-WIN systemen
- BMKL API endpoints aanpassingen conform Kadasterbeleid API-management
- Diverse performance verbeteringen met betrekking tot Actualiseren netinformatie
- NTD BMKL klassiek; bug-fix met betrekking tot graafbericht: standaard `aanvangsdatum` en `soort werkzaamheid` weer opgenomen in het verzonden graafbericht naar de netbeheerder

### 16 oktober 2017
- BMKL2.0 in NTD als centrale netbeheerder beschikbaar
- Bugfix (mogelijk om beheerdersinformatie in de NTD conform IMKL v1.2.1 aan te leveren)

### 14 september 2017

#### _IMKL versie 1.2.1 in Kadaster KLIC-WIN systemen_

> ##### Wijzigingen in waardelijsten
>
> 1. http://definities.geostandaarden.nl/imkl2015/id/waardelijst/AnnotatieTypeValue \
> Toegevoegd: http://definities.geostandaarden.nl/imkl2015/id/waarde/AnnotatieTypeValue/annotatiepijlDubbelgericht \
> Toegevoegd: http://definities.geostandaarden.nl/imkl2015/id/waarde/AnnotatieTypeValue/annotatiepijlEnkelgericht
>
>
> 2. http://definities.geostandaarden.nl/imkl2015/id/waardelijst/MaatvoeringsTypeValue \
> Toegevoegd: http://definities.geostandaarden.nl/imkl2015/id/waarde/MaatvoeringsTypeValue/maatvoeringspijl
>
> ##### Wijzigingen in features
>
> 1. Belanghebbende (XSD-wijziging) \
> Element “netinformatie” is hernoemd naar “utiliteitsnet”. \
> Element “geraaktBelangGraafpolygoon” is hernoemd naar “geraaktBelangBijGraafpolygoon”. \
> Element “geraaktBelangInformatiepolygoon” is hernoemd naar “geraaktBelangBijInformatiepolygoon”. \
> Element “geraaktBelangOrientatiepolygoon” is hernoemd naar “geraaktBelangBijOrientatiepolygoon”.
>
> 2. Diepte (XSD-wijziging) \
> Element “inNetwork” kan nu meerdere keren voorkomen (wordt nog niet ondersteund door de software)
>
> 3. ExtraGeometrie (XSD-wijziging) \
> Element “inNetwork” kan nu meerdere keren voorkomen (wordt nog niet ondersteund door de software)
>
> 4. Diepte (XSD-wijziging) \
> Element “inNetwork” kan nu meerdere keren voorkomen (wordt nog niet ondersteund door de software)
>
> 5. Organisatie (XSD-wijziging) \
> “Organisatie” is geen gml-feature meer, maar een element dat binnen andere features kan worden gebruikt
>
>
> ##### Nieuwe controles (naast XSD-controle)
> 1. rotatiehoek is verplicht bij Maatvoering van het type maatvoeringslabel of maatvoeringspijlpunt.
> 2. rotatiehoek is verplicht bij Annotatie van het type annotatielabel of annotatiepijlpunt.
> 3. label is verplicht bij Maatvoering van het type maatvoeringslabel.
> 4. label is verplicht bij Annotatie van het type annotatielabel.
> 5. Binnen “Appurtenance”-features moet element “inNetwork” eenmaal voorkomen.
> 6. Binnen “Elektriciteitskabel”-features moet element “inNetwork” eenmaal voorkomen.
> 7. Binnen “OlieGasChemicalienPijpleiding”-features moet element “inNetwork” eenmaal voorkomen.
> 8. Binnen “Overig”-features moet element “inNetwork” eenmaal voorkomen.
> 9. Binnen “Rioolleiding”-features moet element “inNetwork” eenmaal voorkomen.
> 10. Binnen “Telecommunicatiekabel”-features moet element “inNetwork” eenmaal voorkomen.
> 11. Binnen “ThermischePijpleiding”-features moet element “inNetwork” eenmaal voorkomen.
> 12. Binnen “Waterleiding”-features moet element “inNetwork” eenmaal voorkomen.
> 13. Binnen feature “Overig” mag element “pipeDiameter” geen “nilReason” hebben.


### 1 juni 2017
- Validaties conform IMKL versie 1.2 in Kadaster KLIC-WIN systemen

### 13 april 2017
- BMKL2.0 in NTD beschikbaar

### 31 maart 2017
- Technische aanpassingen t.b.v. livegang BMKL2.0 in NTD
- Bugfixes

### 23 februari 2017
- Bugfix m.b.t. B2B aanleveren netinformatie/documenten

### 3 februari 2017
- Bugfixes (o.a. tabblad ‘Kaart’ weer actief bij NTD Actualiseren netinformatie)

### 17 januari 2017
- B2B aanleveren van netinformatie
- Aanpassing NTD-Portaal
- KLIC API documentatie beschikbaar gesteld in NTD
- Bugfixes
