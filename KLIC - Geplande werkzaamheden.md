# Geplande werkzaamheden (bijgewerkt 29 oktober 2018)

--------------------------------------------------------------------------------------
## Planning voor release - 2019
Voor deze release zijn de volgende onderwerpen gepland:

**B2B aanvraag**:

Ter voorbereiding op de KLIC-WIN implementatie wordt er een XSD aanpassing doorgevoerd. In de nieuwe versie van het interface KlicB2BAanvraag zijn de volgende optionele attributen van een gebiedsinformatie-aanvraag toegevoegd: 
- KvkNummer van aanvrager; het KvK-nummer (Kamer van Koophandel) van de aanvrager (klant) van de aanvraag.
- KvkNummer van opdrachtgever; het KvK-nummer (Kamer van Koophandel) van de opdrachtgever voor de aanvraag. 
- VoorbereidingMedegebruikFysiekeInfrastructuur; een specifiek orientatieverzoek ter voorbereiding op een verzoek tot medegebruik van fysieke infrastructuur. 
- VoorbereidingCoordinatieCivieleWerken; een specifiek orientatieverzoek ter voorbereiding op een verzoek tot coördinatie van civiele werken. 
- IdentificatieBAG van een dichtstbijzijnd adres (DAS); de identificatie van het adresseerbare object van een dichtstbijzijnd adres. 
- Informatiepolygoon; de geometrie van het gebied (een polygoon) waarover informatie gevraagd wordt, niet zijnde het graafgebied.

Op [Github](https://github.com/kadaster/klic-win/tree/master/Aanvragen%20gebiedsinformatie) is een uitgebreide toelichting over deze aanpassing.

--------------------------------------------------------------------------------------
## Planning voor release - januari 2019
Voor deze release zijn de volgende onderwerpen gepland:

**Documentenbeheer**:
- Validatie dat een aangeleverd document maximaal 8 MB groot mag zijn. (ID 2653)
  * dit geldt zowel voor het actualiseren (centrale netbeheerder) als het aanleveren van beheerdersinformatie (decentraal)

**Bug-fixes**:
- nader te bepalen 

--------------------------------------------------------------------------------------
## Planning voor release - december 2018
Voor deze release zijn de volgende onderwerpen gepland:

**BMKL API v2.0**:
- Toepassing url's naar Kadaster-waardelijsten in BMKL API's. (ID 2522)
  * Het betreft: `giAanvraagStatus`, `biNotificatieStatus`, `biProductieStatus`, `aanleverStatus` en `aanleverStapAanduiding`
  * De waardelijsten zijn momenteel nog niet opvraagbaar op deze url's
  * Zie [Versieverschillen BMKL API v2.pdf](B2B-koppeling%20beheerdersinformatie%20(BMKL%202.0)/Versieverschillen%20BMKL%20API%20v2.pdf).
  * Zie [B2B-koppeling beheerdersinformatie BMKL 2.0](B2B-koppeling%20beheerdersinformatie%20(BMKL%202.0)/B2B-koppeling%20beheerdersinformatie%20BMKL2.0.md) (versie 2018-05-01)

**Aanleveringen API**:
- Aanleveringen API qua naamgeving en gebruik laten aansluiten op de BMKL API's. (ID 2674)
  * Zie [Versieverschillen Aanleveringen API v1.0.pdf](Actualiseren/Versieverschillen%20Aanleveringen%20API%20v1.0.pdf).
 
**Synchronisatie API**:
- Voor Agentschap Telecom worden API's beschikbaar gesteld om KLIC procesgegevens te synchroniseren met hun eigen registratie.

**Bug-fixes**:
- nader te bepalen 

--------------------------------------------------------------------------------------
## Planning voor release - medio november 2018
Voor deze release zijn de volgende onderwerpen gepland:

**Keten Acceptatietest Bevindingen**:
- Visualisatie bevindingen (deel 2). Zie issue 220 tot en met 227 op de [Github van Geonovum](https://github.com/Geonovum/imkl2015-review/issues)
- nader te bepalen 

**Synchronisatie API**:
- Voor Agentschap Telecom worden API's beschikbaar gesteld om KLIC procesgegevens te synchroniseren met hun eigen registratie.

**Bug-fixes**:
- nader te bepalen 

--------------------------------------------------------------------------------------
## Planning voor release - begin november 2018
Voor deze release zijn de volgende onderwerpen gepland:

**KLIC-WIN Proces actualiseren netinformatie, Voorzorgsmaatregelen (EV)**:
- In EV brief wordt locatieWerkzaamheden correct gevuld. (ID 3112) 
- Controleren of alle meegeleverde sjablonen gebruikt zijn in de beslisregels en een waarschuwing indien niet gebruikt. (ID 1964)
- In NTD worden contactpersoon van de aanvrager opgeslagen. Voorheen was er een omissie en werd de contactgegevens van de organisatie opgeslagen. (ID 2260)
- Keten Acceptaties bevinding: Bij het aanleveren van het voorzorgsmaatregelen bestand worden nu alle associaties met waardelijsten gecontroleerd. (ID 3248)

**BeheerdersinformatieAanvragen API**:
- De mogelijkheid om de resultaten uit de API te pagineren is toegevoegd. (ID 2139)

**Synchronisatie API**:
- Voor Agentschap Telecom worden API's beschikbaar gesteld om KLIC procesgegevens te synchroniseren met hun eigen registratie.

**Beheren communicatie gegevens**: Dienst onder Mijn Kadaster voor netbeheerders en de serviceproviders
- Er komt een update van de pagina ‘ Beheren Communicatie gegevens”, waarin het mogelijk wordt een ‘WebsiteKlic’ (zie IMKL v1.2.1) op te geven. (ID 2192, ID 2970, ID 3067)
- Van netbeheerder wordt ‘WebsiteKlic’ gepresenteerd op leveringsbrief. (ID 2903, ID 2954,  ID 2955)
- Van netbeheerder wordt de ‘WebsiteKlic’ weergegeven in de GebiedsinformatieLevering (KLIC-WIN per 1 januari 2019) (ID 2904)

**Keten Acceptatietest Bevindingen**:
- Visualisatie bevindingen (deel 1). Zie issues 221, 223, 225 en 226 op de [Github van Geonovum](https://github.com/Geonovum/imkl2015-review/issues). (ID 2838, ID 3186, ID 3207, ID 3208, ID 3209, ID 3253, ID 3265, ID 3266)   

**Bug-fixes**:
- Aanleveren Documenten houdt nu niet meer de status "Wordt gevalideerd". (ID 3089, ID 3202)
- Als er meer dan 1000 validatiemeldingen zijn bij het aanleveren van documenten, komt er te staan "Er zijn meer dn 1000 validatie meldingen. Meer meldingen worden niet getoond." (ID 3253, ID 2261)
- Diverse performance verbeteringen. (ID 2338, ID 2687, ID 3277)

--------------------------------------------------------------------------------------
## Planning voor release - eind oktober 2018
Voor deze release zijn de volgende onderwerpen gepland:

**Beheren Belangen**:

Ter voorbereiding op de KLIC-WIN implementatie wordt binnenkort mogelijk gemaakt om 2 nieuwe contactsoorten op te voeren in de belangenregistratie.
- Contact netinformatie: De contactpersoon voor de grondroerder voor vragen over de kabels en leidingen. (ID 2361)
- Contact storing/schade: Contactgegevens voor de grondroerder bij schade of storing. (ID 2361)

**Aanpassing leveringsbrief**:
- Deze bovengenoemde contacten, indien gevuld, worden gebruikt in de leveringsbrief.
- De layout van de leveringsbrief wordt aangepast. Hiermee wordt de leveringsbrief overzichtelijker.

**BGT**:

De Basisregistratie Grootschalige Topografie (BGT) leidt tot een gedetailleerde digitale kaart van Nederland. De GBKN achtergrondkaart die gebruikt wordt binnen KLIC, zal vervangen worden door een BGT achtergrondkaart.

Deze nieuwe achtergondkaart zal op 3 plaatsen binnen KLIC gebruikt gaan worden:
- Klic-online (bij het doen van een graafmelding, oriëntatieverzoek en calamiteitenmelding);</br>
  Als achtergrondkaart wordt hier de visualisatie van "BGT omtrekgericht" gebruikt. (ID 2161)
- In de Klic-ontvangstbevestiging;</br>
  Als achtergrondkaart wordt ook hier de "BGT omtrekgericht" gebruikt.  (ID 2162)
- Binnen de Klic-levering;</br>
  Als achtergrondkaart wordt hier de visualisatie van "BGT pastel" gebruikt. (ID 2163)


Er zijn verschillende voorbeeldbestanden op [onze GitHub pagina](https://github.com/kadaster/klic-win/tree/master/Uitleveren/Voorbeelden%20met%20BGT) gepubliceerd.

**Synchronisatie API**:
- Voor Agentschap Telecom worden API's beschikbaar gesteld om KLIC procesgegevens te synchroniseren met hun eigen registratie. (ID 2137)

**KLIC-WIN Proces actualiseren netinformatie, Voorzorgsmaatregelen (EV)**:
- De controle op placeholdernamen is verruimd. (ID 2887, ID 2893)
- Vulling van EV bijlage placeholder "Avg-Contactpersoon-naam". Dit veld wordt nu met de correcte waarde gevuld. (ID 2243)

**Beheer Communicatie**:
- Aanpassen van de communicatiegegevens (URL netbeheerder & Uitvalcontact berichten) geen selfservice meer. Wijzigingsverzoeken worden voortaan afgehandeld via Klantenservice Klic. (ID 3218)

**Bug-fixes / Performance / Tekstueel**:
- Aanpassing van de tekstuele toelichting bij de 3 keuzes bij een Oriëntatieverzoek. (ID 2827)
- Tekstuele wijziging in het proces van het opvoeren van een graafmelding: WION is gewijzigd in WIBON. (ID 2564)
- Log-bestand na uploaden Netinformatie m.b.t. aantal foutmeldingen aangepast. (ID 2842)
- Bij actualiseren documenten worden nu documenten correct opgeslagen als er meerdere malen worden verwezen naar hetzelfde bestand. (ID 2889)
- HAS-adressen toegevoegd aan li-xml. (ID 2436)
- HAS-adressen en DAS-adressen toegevoegd aan GebiedsInformatieAanvraag via bmkl-api. (ID 2516, ID 2755, ID 2696)
- HAS adressen opgenomen in feature GebiedsinformatieAanvraag van GI.xml. (ID 2727)
- Geen foutmelding wanneer een serviceprovider alle BeheerdersInformatieAanvragen (BIA) opvraagt.  (ID 2737)
- Tekst op scherm Actualiseren Netinfo veranderd van ‘IMKL2015’ naar ‘IMKL’. (ID 3150)
- Diverse performance verbeteringen met betrekking tot uitleveren en actualiseren.


--------------------------------------------------------------------------------------
## Planning voor release - eind september 2018
Voor deze release zijn de volgende onderwerpen gepland:

**NTD**:

Diverse Performance verbeteringen met betrekking tot actualiseren. (ID 3026)

--------------------------------------------------------------------------------------
## Planning voor release - medio augustus 2018
Voor deze release zijn de volgende onderwerpen gepland:

**IMKL contacten**:
- De (de)centrale netbeheerder krijgt de mogelijkheid om van een belang per aanvraagsoort vast te kunnen leggen welk contact van toepassing is voor "netinformatie" (ID 2361)
- De (de)centrale netbeheerder krijgt de mogelijkheid om van een belang vast te kunnen leggen welk contact van toepassing is voor "beschadiging" (ID 2361)
- Let wel: dit wordt niet in de NTD beschikbaar gesteld

Voor de NTD worden de volgende onderwerpen geïmplementeerd:

**KLIC-WIN Proces actualiseren netinformatie, Voorzorgsmaatregelen (EV)**:
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