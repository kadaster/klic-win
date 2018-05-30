# Geplande werkzaamheden

### Planning per 29 mei 2018
De komende periode worden de volgende onderwerpen geïmplementeerd in de NTD.

**Huisaansluitschetsen**:
- De centrale netbeheerder krijgt in de NTD de mogelijkheid om _ExtraDetailInfo_-objecten van het type `huisaansluiting` aan te bieden via _Actualiseren netinformatie_.
- Een huisaansluiting wordt binnen het IMKL-model geïdentificeerd met het BAG ID van het bijbehorende adresseerbare object (verblijfsobject, standplaats of ligplaats).
- Bij het aanleveren van ExtraDetailInfo-objecten wordt gevalideerd of het gerefereerde document ("huisaansluitschets") in de KLIC DocumentenOpslag aanwezig is.
- Toelichting:
  * [Aanleveren en uitleveren van documenten](https://github.com/kadaster/klic-win/tree/master/Actualiseren/Documenten/Aanleveren-uitleveren%20documenten%202017-10-20.ppsx) (diashow)
  * Map met [voorbeelden](https://github.com/kadaster/klic-win/tree/master/Actualiseren/Documenten/Voorbeelden) (voorbeeld 2. en 3.)
  
**BMKL API v2.0**:
- Bug-fix: Sommige BIA's komen dubbel voor in de BMKL API-lijst bij opvragen als Serviceprovider (ID 2521).
- Bug-fix: Responsebericht van de BMKL API voor het initiëren van een upload in NTD in JSON formaat (ID 2291).
- Toepassing url's naar Kadaster-waardelijsten in BMKL API's (ID 2522).
  * Het betreft: `giAanvraagStatus`, `biNotificatieStatus`, `biProductieStatus`, `aanleverStatus` en `aanleverStapAanduiding`
  * De waardelijsten zijn momenteel nog niet opvraagbaar op deze url's
  * Zie [Versieverschillen BMKL API v2.pdf](https://github.com/kadaster/klic-win/blob/master/B2B-koppeling%20beheerdersinformatie%20(BMKL%202.0)/Versieverschillen%20BMKL%20API%20v2.pdf).
  * Zie [B2B-koppeling beheerdersinformatie BMKL 2.0](B2B-koppeling%20beheerdersinformatie%20(BMKL%202.0)/B2B-koppeling%20beheerdersinformatie%20BMKL2.0.md) (versie 2018-05-01)
- Toepassen gebruik 3-letterige landencode (volgens ISO3166-1) (ID 2535).

**Actualiseren netinformatie**:
- Bug-fix: Specifieke technische fout tijdens uploaden netinformatie (ID 2635).
- Aanleveren van 'multi surface'-geometrieën voor Wion-features toestaan (ID 2440).
  * Het betreft: _ExtraDetailInfo_, _ExtraTopografie_, _ExtraGeometrie_, _AanduidingEisVoorzorgsmaatregel_
  * Validatie op aangeleverde netinformatie wordt ook aangepast
  * Het moet ook mogelijk zijn om (multi-)polygonen met gaten (donuts) aan te leveren

**EV**:
- Uitbreiding validatieregels: Controleren of één enkel PDF-bestand in meerdere documentsjablonen in de voorzorgsmaatregelen.xml voorkomt (ID 2457).

**Uitleveren gebiedsinformatie**:
- Aanpassen formaat van door het Kadaster gegenereerde PNG’s (ID 2489). Deze worden in het uitgeleverde zipbestand opgenomen.
  * opties: image/png8 met AntiAlias=Full