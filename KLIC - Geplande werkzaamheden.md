# Geplande werkzaamheden (bijgewerkt 23 augustus 2018)

## Planning voor release - oktober 2018
Voor deze release zijn de volgende onderwerpen gepland:

**BMKL API v2.0**:
- Toepassing url's naar Kadaster-waardelijsten in BMKL API's (ID 2522).
  * Het betreft: `giAanvraagStatus`, `biNotificatieStatus`, `biProductieStatus`, `aanleverStatus` en `aanleverStapAanduiding`
  * De waardelijsten zijn momenteel nog niet opvraagbaar op deze url's
  * Zie [Versieverschillen BMKL API v2.pdf](B2B-koppeling%20beheerdersinformatie%20(BMKL%202.0)/Versieverschillen%20BMKL%20API%20v2.pdf).
  * Zie [B2B-koppeling beheerdersinformatie BMKL 2.0](B2B-koppeling%20beheerdersinformatie%20(BMKL%202.0)/B2B-koppeling%20beheerdersinformatie%20BMKL2.0.md) (versie 2018-05-01)
- Toepassen gebruik 3-letterige landencode (volgens ISO3166-1) (ID 2535).

**BGT**:
- Gebruik BGT als achtergrondkaart in belangenbeheer

**Bug-fixes**:
- nader te bepalen

--------------------------------------------------------------------------------------
## Planning voor release - september 2018
Voor deze release zijn de volgende onderwerpen gepland:

**IMKL contacten**:
- Gebruik van IMKL contacten (type "aanvraag") op de ontvangstbevestiging
- Gebruik van IMKL contacten (type "netinformatie", "beschadiging") op de leveringsbrief
- Gebruik van IMKL contacten (type "netinformatie", "beschadiging") op de gelaagde PDF

**Documentenbeheer**:
- Validatie dat een aangeleverd document maximaal 8 MB groot mag zijn (ID 2653)
  * dit geldt zowel voor het actualiseren (centrale netbeheerder) als het aanleveren van beheerdersinformatie (decentraal)

**Aanleveringen API**:
- Aanleveringen API qua naamgeving en gebruik laten aansluiten op de BMKL API's (ID 2674).
  * Zie [Versieverschillen Aanleveringen API v1.0.pdf](Actualiseren/Versieverschillen%20Aanleveringen%20API%20v1.0.pdf).
  
**Synchronisatie API**:
- Voor Agentschap Telecom worden API's beschikbaar gesteld om KLIC procesgegevens te synchroniseren met hun eigen registratie.

**Bug-fixes**:
- nader te bepalen

--------------------------------------------------------------------------------------
## Planning voor release - medio augustus 2018
De komende periode worden de volgende onderwerpen geïmplementeerd:

**IMKL contacten**:
- De (de)centrale netbeheerder krijgt de mogelijkheid om van een belang per aanvraagsoort vast te kunnen leggen welk contact van toepassing is voor "netinformatie" (ID 2361)
- De (de)centrale netbeheerder krijgt de mogelijkheid om van een belang vast te kunnen leggen welk contact van toepassing is voor "beschadiging" (ID 2361)
- Let wel: dit wordt niet in de NTD beschikbaar gesteld

**BGT**:
- Gebruik BGT als achtergrondkaart in Klic-online (ID 2161)
- Gebruik BGT als achtergrondkaart in de ontvangstbevestiging (ID 2162)
- Gebruik BGT als achtergrondkaart in de levering (ID 2163)

Voor de NTD worden de volgende onderwerpen geïmplementeerd:

**EV**:
- Uitbreiding validatieregels: Controleren of één enkel PDF-bestand in meerdere documentsjablonen in de voorzorgsmaatregelen.xml voorkomt (ID 2457).
- In het pdf-sjabloon mag een invulveld meerder keren worden gebruikt door daar een suffix aan toe te voegen (_\_\<volgnummer\>_) (ID 2778)

**WIBON**:
- De (de)centrale netbeheerder krijgt in de NTD de mogelijkheid om bij een oriëntatieverzoek de optie ´coördinatie´ of ´medegebruik´ aan te geven.

**Bug-fixes**:
- nader te bepalen

--------------------------------------------------------------------------------------
## Planning voor release - 13 juli 2018
De volgende onderwerpen worden geïmplementeerd in de NTD:

**Huisaansluitschetsen**:
- De centrale netbeheerder krijgt in de NTD de mogelijkheid om _ExtraDetailInfo_-objecten van het type `huisaansluiting` aan te bieden via _Actualiseren netinformatie_.
- Een huisaansluiting wordt binnen het IMKL-model geïdentificeerd met het BAG ID van het bijbehorende adresseerbare object (verblijfsobject, standplaats of ligplaats).
- Bij het aanleveren van ExtraDetailInfo-objecten wordt gevalideerd of het gerefereerde document ("huisaansluitschets") in de KLIC DocumentenOpslag aanwezig is.
- Toelichting:
  * [Aanleveren en uitleveren van documenten](Actualiseren/Documenten/Aanleveren-uitleveren%20documenten%202017-10-20.ppsx) (diashow)
  * Map met [voorbeelden](Actualiseren/Documenten/Voorbeelden) (voorbeeld 2. en 3.)
  
**BMKL API v2.0**:
- Bug-fix: Sommige BIA's komen dubbel voor in de BMKL API-lijst bij opvragen als Serviceprovider (ID 2521).
- Bug-fix: Responsebericht van de BMKL API voor het initiëren van een upload in NTD in JSON formaat (ID 2291).

**Actualiseren netinformatie**:
- Bug-fix: Specifieke technische fout tijdens uploaden netinformatie (ID 2635).
- Aanleveren van 'multi'-geometrieën voor Wion-features toestaan (ID 2440).
  * multi-lines en multi-polygonen (incl. donuts) toestaan voor geometrieën van het type 'GM_Object';  \
het betreft: _ExtraDetailInfo_, _Annotatie_, _Maatvoering_, _ExtraTopografie_
  * polygonen met gaten (donuts) toestaan voor geometrieën van het type 'GM_Surface';  \
het betreft: _ExtraGeometrie_, _AanduidingEisVoorzorgsmaatregel_
  * Let wel: multi-polygonen voor geometrieën van het type 'GM_Surface' zijn niet toegestaan
  * Validatie op aangeleverde netinformatie wordt ook aangepast

**Uitleveren gebiedsinformatie**:
- Aanpassen formaat van door het Kadaster gegenereerde PNG’s (ID 2489). Deze worden in het uitgeleverde zipbestand opgenomen.
  * opties: image/png8 met AntiAlias=None