# Geplande werkzaamheden (bijgewerkt 17 mei 2019)

--------------------------------------------------------------------------------------
## Planning voor release - september 2019
Voor deze release zijn de volgende onderwerpen gepland:

**Terugmeldvoorziening**:
- Pilot voor het automatiseren van fase 1 van het proces "Afwijkende situatie" (Terugmeldvoorziening)
  - de pilot zal met ketenpartners worden georganiseerd
  - er wordt gebruik gemaakt van de generieke terugmeldsysteem van het Kadaster. Voor meer informatie zie [de website van Geoforum](https://geoforum.nl/t/terugmelding-api-beschikbaar-in-acceptatie-omgeving/2251).

--------------------------------------------------------------------------------------
## Planning voor release - 1 juli 2019
Per 1 juli 2019 zijn de oude Klic-standaarden niet meer geldig.  \
Voor deze release zijn daarom de volgende onderwerpen gepland:

**Nieuwe Kadaster KLIC-viewer**:
- Oplevering van nieuwe Kadaster KLIC-viewer op basis van een uitlevering 
  - met alleen vectorinformatie (GI.xml) en PDF-bestanden (bijlagen) van netbeheerders (zónder PNG-bestanden voor ligging, maatvoering, annotatie en eigenTopo van netbeheerders)
  - met een BGT-achtergrondkaart in PNG-formaat
  - met geselecteerd gebied in vectorinformatie (in _GebiedsinformatieLevering_, GI.xml)

**Uitlevering zipbestand**:
- Het zipbestand met de Klic-uitlevering wordt aangepast (ID 3849):
  - in het zipbestand worden de PNG-bestanden van netbeheerders (rasterbestanden voor ligging, maatvoering, annotatie en eigenTopo) niet meer uitgeleverd.
- Binnenkort wordt daarvoor gepubliceerd:
  - uitgewerkte voorbeelden van uitleveringen

**Leverings email**:
- De inhoud van de leveringsmail wordt aangepast. (ID 3897)

** Het BIL zipbestand**:
- Het zipbestand met de Beheerders Informatie Levering van een specifieke netbeheerder wordt aangepast in lijn met de wijzigingen in de Klic-uitlevering.
- Binnenkort wordt daarvoor gepubliceerd:
  - uitgewerkte voorbeelden van uitleveringen

--------------------------------------------------------------------------------------
## Planning voor release - 3 juni 2019
Voor deze release zijn de volgende onderwerpen gepland:

**Actualiseren**:
- Bij het actualiseren van documenten en netinformatie loopt de validatie soms dusdanig snel dat de processtatus updates elkaar soms inhaalden. Hierdoor werd in de API niet altijd de juiste status weergegeven. Het updaten van statussen is meer robuust gemaakt, waardoor dit niet meer kan gebeuren. (ID 3843, ID 4070, ID 4075, ID 4076)
- Performance verbetering bij het controleren of er vanuit de netinformatie naar bestaande documenten wordt verwezen. (ID 3979)

**Bug-fix**:
- Het kan soms voorkomen dat een BeheerdersinformatieAanvraag de status "Open" heeft, terwijl de aanvraag wel bevestigd is door de netbeheerder. Dit is opgelost. (ID 4016)
- De performance voor het ophalen van actualiseren geschiedenis is verbeterd. Voorheen kon dit soms zo lang duren dat een timeout optrad. Dit is opgelost. (ID 4166)

--------------------------------------------------------------------------------------
## Planning voor release - 17 mei 2019
Voor deze release zijn de volgende onderwerpen gepland:

**Publicatie op Github**:
- Er komt een BETA-versie beschikbaar van de online Kadaster KLIC-viewer.  \
  Zie [deze link op GitHub](/Kadaster%20KLIC-viewer/).

--------------------------------------------------------------------------------------
## Planning voor release - NTD: 25 april 2019; Productie: 1 mei 2019
Voor deze release zijn de volgende onderwerpen gepland:

**Aanleveren netinformatie**:
- Bij het aanleveren van netinformatie wordt een validatie toegevoegd of een feature label niet de maximale lengte van 200 tekens overschrijdt. (ID 3978)
- Bij het aanleveren van een ZIP bestand (Documenten, Netinformatie, Voorzorgsmaatregelen) wordt gecontroleerd of ieder bestandsnaam in de ZIP uniek is. (ID 3995)

**Voorzorgsmaatregelen (EV)**:
- Bij het aanleveren van een EV-vlak in de netinformatie moet de **`netbeheerderNetAanduiding`** in combinatie met **het `thema` van het `Utiliteitsnet`** - bekend zijn bij de aangeleverde voorzorgsmaatregelen. (ID 3546)  \
  Zie voor meer informatie [deze link op GitHub](https://github.com/kadaster/klic-win/blob/master/Actualiseren/Voorzorgsmaatregelen/Controles%20voorzorgsmaatregelen.md#netinformatie-met-voorzorgsmaatregelen). 

**Bug-fixes**:
- In de NTD omgeving wordt nu ook voor een oriëntatieverzoek het veld "omschrijvingWerkzaamheden" in de GI.xml correct getoond. (ID 3974)
- In de NTD omgeving kon een testmelding vastlopen als er een informatiepolygoon was opgegeven met een ongeldige geometrie. Voor dit optionele veld wordt nu gecontroleerd of de geometrie valide is, als deze is ingevuld. (ID 4051)

--------------------------------------------------------------------------------------
## Planning voor release - 24 april Github update:

**Uitlevering zipbestand**:
- Publicatie voorbeeldbestanden nieuwe uitlevering. (ID 3849)  \
  zie [deze link op GitHub](https://github.com/kadaster/klic-win/tree/master/Uitleveren/Voorbeelden%20levering%20v2.2) voor voorbeelden van uitleveringen in versie 2.2.



--------------------------------------------------------------------------------------
## Planning voor release - NTD: 28 maart 2019; Productie: 2 april 2019
Voor deze release zijn de volgende onderwerpen gepland:

**Bug-fixes**:
- Er is een extra validatie op de voorzorgsmaatregelen toegevoegd: iedere 'voorzorgsmaatregelToelichting' moet genoemd worden bij 'voorzorgsmaatregelBeslissingsregel' en andersom. (ID 3752)
- In de NTD-omgeving wordt vanaf nu de naam + relatienummer van de Aanvrager (NTD-gebruiker) overgenomen in de GI.xml het EV sjabloon en de GebiedsinformatieAanvragen API. Voorheen werd deze in de NTD gevuld met een default waarde. (ID 3689)

--------------------------------------------------------------------------------------
## Planning voor release - NTD: 14 maart 2019; Productie: 20 maart 2019
Voor deze release zijn de volgende onderwerpen gepland:

**B2B-koppeling BMKL 2.0**:
- Aan het zipbestand met de BeheerdersinformatieLeveringen wordt nu ook een LI.xml toegevoegd in de Productie omgeving. (ID 3411)  \
  Naar aanleiding van de Keten Acceptatietesten geprioriteerd.

**Voorzorgsmaatregelen (EV)**:
- Bugfix: Vulling van placeholders bij EV bijlage. Bij placeholder "Werk-adres" wordt nu niet meer de woonplaats gevuld. (ID 3776)

**Actualiseren documenten**:
- Performance verbetering en robuustere afhandeling.

--------------------------------------------------------------------------------------
## Planning voor release - NTD: 1 maart 2019; Productie: 4/11 maart 2019
Voor deze release zijn de volgende onderwerpen gepland:

**Actualiseren netinformatie**:
- Actualiseren netinformatie: Specificatie bij één van de onbekende technische fouten: Als er een onjuiste alias gebruikt wordt voor de namespace van 'imkl'. (ID 3702, ID 3733)
- Bugfix: Actualiseren netinformatie: Het is nu niet meer mogelijk om als service provider onder de login van een klant, informatie van een andere klant te plaatsen in de tijdelijke validatie tabellen. (ID 3742)

**Performance verbeteringen**:
- Actualiseren netinformatie: Performance verbetering door nieuwe opzet van de controle kaartjes bij het actualiseren van netinformatie. (ID 2687)
- Bugfix: Het verwerken van geuploade documenten kon op de NTD tot een Out-Of-Memory probleem leiden. Dit is nu opgelost. (ID 3772)
- Actualiseren documenten: Performance verbetering 
- Performance verbetering voor het ophalen van alle openstaande BIA’s via de API. (ID 3719)

--------------------------------------------------------------------------------------
## Planning voor release - NTD: 14 februari 2019; Productie: 18 februari 2019
Voor deze release zijn de volgende onderwerpen gepland:

**Controle minimaal één type soort werkzaamheden bij graafmelding en oriëntatieverzoek**:
- Bij het opvoeren van een graafmelding of oriëntatieverzoek moet er altijd minimaal één soort werkzaamheden worden opgegeven. Tevens is het geven van een toelichting van de werkzaamheden alleen mogelijk als er minimaal één soort werkzaamheden is opgegeven. Dit geldt voor aanvragen via de web applicatie Klic-online en aanvragen via een B2B aanvraag-kanaal. (ID 2533)

**Beheren belangen**:
- Het emailadres van contacten wordt alleen verplicht als het contact gekoppeld is als contactAanvraag of contactNetinformatie. (ID 3577, ID 3676)


--------------------------------------------------------------------------------------
## Planning voor release - 30 januari 2019
Voor deze release zijn de volgende onderwerpen gepland:

**B2B-koppeling BMKL 2.0**:
- Aan het zipbestand met de BeheerdersinformatieLeveringen wordt nu ook een LI.xml toegevoegd in de NTD-omgeving. (ID 3411)  \
  Naar aanleiding van de Keten Acceptatietesten geprioriteerd.

**B2B aanvraag**:

Ter voorbereiding op de KLIC-WIN implementatie wordt er een XSD aanpassing doorgevoerd. In de nieuwe versie van het interface KlicB2BAanvraag zijn de volgende optionele attributen van een gebiedsinformatie-aanvraag toegevoegd: 
- KvkNummer van aanvrager; het KvK-nummer (Kamer van Koophandel) van de aanvrager (klant) van de aanvraag.
- KvkNummer van opdrachtgever; het KvK-nummer (Kamer van Koophandel) van de opdrachtgever voor de aanvraag. 
- VoorbereidingMedegebruikFysiekeInfrastructuur; een specifiek orientatieverzoek ter voorbereiding op een verzoek tot medegebruik van fysieke infrastructuur. 
- VoorbereidingCoordinatieCivieleWerken; een specifiek orientatieverzoek ter voorbereiding op een verzoek tot coördinatie van civiele werken. 
- IdentificatieBAG van een dichtstbijzijnd adres (DAS); de identificatie van het adresseerbare object van een dichtstbijzijnd adres. 
- Informatiepolygoon; de geometrie van het gebied (een polygoon) waarover informatie gevraagd wordt, niet zijnde het graafgebied.

Op [Github](https://github.com/kadaster/klic-win/tree/master/Aanvragen%20gebiedsinformatie) is een uitgebreide toelichting over deze aanpassing.

**Bug-fix**:
- Bij het uitleveringsbestand in het JSON formaat wordt bij de 'BestandMediaTypeValue' nu altijd de correcte waarde weergegeven. (ID 3580)
- PKIoverheid-certificaat niet meer verplicht bij PING naar de op KLIC-WIN aangesloten netbeheerders. (ID 3635)
- Op het moment dat de (graaf)polygoon een EV vlak raakt zonder de bijbehorende kabel of leiding, wordt na deze wijziging ook het bijbehorende utiliteitsnet uitgeleverd in de NTD-omgeving voor KLIC-WIN uitleveringen. (ID 3665)

--------------------------------------------------------------------------------------
## Planning voor release - 23 januari 2019
Voor deze release zijn de volgende onderwerpen gepland:

**Bug-fix**:
- Voorkomen van een http 503 response bij ophalen BIA via API zonder parameters. (ID 3683)

--------------------------------------------------------------------------------------
## Planning voor release - NTD: 17 januari 2019; Productie: 21 januari 2019
Voor deze release zijn de volgende onderwerpen gepland:

**Documentenbeheer**:
- Validatie dat een aangeleverd document maximaal 8 MB groot mag zijn. (ID 2653, ID 2654)
  * dit geldt zowel voor het actualiseren (centrale netbeheerder) als het aanleveren van beheerdersinformatie (decentraal)

**Performance**:
- Performance verbetering bij het genereren van het zipbestand met de BeheerdersinformatieLeveringen (ID 3558)

--------------------------------------------------------------------------------------
## Planning voor release - 18 januari 2019
Voor deze release zijn de volgende onderwerpen gepland:

**Bug-fix**:
- De status van de BIA's van voor 28 december 2018 zijn geupdate. Hierdoor krijgt een op KLIC-WIN aangesloten netbeheerder bij het opvragen van zijn openstaande BIA's via de API niet meer deze historische aanvragen te zien. (ID 3586)

--------------------------------------------------------------------------------------
## Planning voor release - 11 januari 2019
Voor deze release zijn de volgende onderwerpen gepland:

**Bug-fixes NTD**:
- Bugfix: in de NTD-omgeving worden nu alle statussen in de API response als volledige URL weergegeven. (ID 3557)
- Bugfix: in de NTD-omgeving is het probleem opgelost waardoor nu tijdens het opvoeren van een BMKL 2.0 testmelding, niet meer versprongen wordt naar het beginscherm van een klasieke testmelding. (ID 3562)

--------------------------------------------------------------------------------------
## Planning voor release - 2 januari 2019
	Tijdens deze release is KLIC in de ochtend niet beschikbaar.
Voor deze release zijn de volgende onderwerpen gepland:

**Nieuwe ZIP-structuur**:  \
Vanaf 2 januari wordt het ZIP-bestand uitgeleverd met de nieuwe structuur.  \
Zie voor meer informatie over de nieuwe structuur [deze link op GitHub](https://github.com/kadaster/klic-win/tree/master/Uitleveren).  \
Hier is ook de presentatie 'WION levering - producten 2018-05-16.ppsx' te vinden.  \
De leveringen met de nieuwe structuur zijn alleen te bekijken met versie 4.3 van de Klic-viewer. Met deze versie van de Klic-viewer zijn zowel de oude, als de nieuwe leveringen te bekijken.


**Vector-aanlevering**:  \
Op 7 januari staat gepland om de eerste netbeheerder over te sluiten op het nieuwe aanleveringsformaat (IMKL 1.2.1). Netbeheerders die aanleveren via dit formaat, leveren hun netinformatie aan als geo-objecten (features, vectoren). De nieuwe ZIP-structuur, die vanaf 2 januari gebruikt wordt, is hiervoor geschikt.


**Tariefswijziging Klic-melding**:  \
De [tariefswijziging die per 1 januari 2019](https://www.kadaster.nl/-/tarieven-per-1-januari-2019) van kracht is, wordt zichtbaar op het scherm getoond bij een Tracémelding. 


**Synchronisatie API**:  \
Voor Agentschap Telecom zijn de API’s live gezet om KLIC procesgegevens te synchroniseren met hun eigen registratie. 

--------------------------------------------------------------------------------------
## Planning voor release - 28 december 2018
Voor deze release zijn de volgende onderwerpen gepland:

**Huisaansluitschetsen**:
- In de productie omgeving is begin december het proces rondom de aanvraag en registratie van huisaansluitschetssen gewijzigd; Deze wijziging wordt ook doorgevoerd op NTD (ID 3246, ID 3457). Het betreft:
  * Voor de aanvraag voor huisaansluitschets (HAS) is er een maximum van 100 adresseerbare objecten (verblijfsobject, standplaats of ligplaats), waar dat voorheen was op basis van 100 unieke adressen. Soms is één unieke adres gerelateerd aan meerdere adresseerbare objecten in de Basisregistratie Adressen en Gebouwen (BAG). De telling van het maximum (100) is gebaseerd op adresseerbare objecten. (ID 3246, ID 3337, ID 3338, ID 3339, ID 3340, ID 3341)
- In de productie omgeving is 22 november het proces rondom de aanvraag en registratie van huisaansluitschetssen gewijzigd; Deze wijziging wordt ook doorgevoerd op NTD (ID 2728). Het betreft: 
    * Omdat ook KLIC aansluit op de wettelijke basisregistratie BAG, moet dit adres in de basisregistratie BAG bestaan. Hierdoor worden alleen nog maar hoofdadressen geaccepteerd, en geen nevenadressen meer. 
        - Bij bestellen via de website is het selecteren van nevenadressen niet meer mogelijk. 
        - Een B2B aanvraag met een HAS aanvraag op een nevenadres wordt afgekeurd.
        - Een HAS die bij de netbeheerder geregistreerd staat onder het nevenadres, kan dus niet meer opgevraagd worden.


--------------------------------------------------------------------------------------
## Planning voor release IMKL v1.2.1.2 - 13 december 2018
Naar aanleiding van de Keten Acceptatietesten zijn bevindingen geconstateerd op het IMKL.  \
De voorgestelde wijzigingen zijn geaccordeerd door Werkgroep standaarden KLIC en het BAO KLIC.  \
Voor deze IMKL-release zijn de volgende onderwerpen gepland:
 
**[IMKL2015/visualisatie](https://github.com/Geonovum/imkl2015/tree/master/visualisatie)** (versie 1.2.1.2) en
**[IMKL2015/symbool](https://github.com/Geonovum/imkl2015/tree/master/symbool)** (versie 1.2.1.2):
- Aanpassingen van de visualisatie (en gebruikte symbolen) zijn beschreven in [IMKL2015-Handreiking-visualisatie_1.2.1.2.pdf](https://github.com/Geonovum/imkl2015/blob/master/visualisatie/1.2.1.2/IMKL2015-Handreiking-visualisatie_1.2.1.2.pdf)
- Er zijn geen aanpassingen aan het UML-model of het gml-applicatieschema gedaan
- Afgehandelde issues:
  * [Issue 221](https://github.com/Geonovum/imkl2015-review/issues/221)  \
Visualisatie van EV-gebieden is aangepast. Door gebruik te maken van een patroon (i.p.v. transparantie) blijft kabel- en leidinginformatie zichtbaar, ook bij meerdere, overlappende EV-gebieden.
  * [Issue 223](https://github.com/Geonovum/imkl2015-review/issues/223)  \
De visualisatie van de kop van een mantelbuis is aangepast. De kop eindigt nu op het einde van de geometrie van de mantelbuis.
  * [Issue 224](https://github.com/Geonovum/imkl2015-review/issues/224)  \
Het symbool en de grootte voor mof is aangepast (zie SLD).
  * [Issue 225](https://github.com/Geonovum/imkl2015-review/issues/225)  \
De grootte van de symbolen van overige leidingelementen (_Toren_, _Mast_, _Mangat_, _Kast_, _TechnischGebouw_) is aangepast.
  * [Issue 226](https://github.com/Geonovum/imkl2015-review/issues/226)  \
Ook de transparantie van de symbolen van overige leidingelementen is aangepast, om eigen geometrie te kunnen zien.
  * [Issue 227](https://github.com/Geonovum/imkl2015-review/issues/227)  \
Het aangrijpingspunt van het symbool voor een blaasgat op de leiding is verplaatst naar de onderkant.
  * [Issue 230](https://github.com/Geonovum/imkl2015-review/issues/230)  \
Het label met `dieptePeil` wordt nu (onderscheidend) getoond bij de features _DiepteTovMaaiveld_ en _DiepteNAP_.
- Onderstaande [SLD's](https://github.com/Geonovum/imkl2015/tree/master/visualisatie/1.2.1.2) zijn aangepast:
  * sld-aanduidingeisvoorzorgsmaatregel.xml
  * sld-dieptenap.xml
  * sld-dieptetovmaaiveld.xml
  * sld-kast.xml
  * sld-leidingelement.xml
  * sld-mangat.xml
  * sld-mantelbuis.xml
  * sld-mast.xml
  * sld-technischgebouw.xml
  * sld-toren.xml
- De volgende [iconen](https://github.com/Geonovum/imkl2015/tree/master/symbool/1.2.1.2/iconen) zijn aangepast: 
  * dieptenap
  * dieptetovmaaiveld
- Map met [patronen](https://github.com/Geonovum/imkl2015/tree/master/symbool/1.2.1.2/patronen) is toegevoegd; fonts worden niet meer toegepast.


--------------------------------------------------------------------------------------
## Planning voor release - 13 december 2018
Voor deze release zijn de volgende onderwerpen gepland:
 
**Synchronisatie API**:
- Voor Agentschap Telecom worden API's beschikbaar gesteld om KLIC procesgegevens te synchroniseren met hun eigen registratie. (ID 3409, ID 3492)

**B2B-koppeling BMKL 2.0**:
- Wijziging in de Scopes van OAuth: De benaming van de scope `klic.ntd` in de NTD-omgeving wijzigt. De scope `klic.ntd` zal worden vervangen door: `klic.ntd.centraal`, `klic.ntd.gebiedsinformatieaanvraag.readonly`, `klic.ntd.beheerdersinformatie`, `klic.ntd.beheerdersinformatie.readonly`. (ID 3231, ID 3353)
- De responses van alle BMKL api's bevatten het veld "mutatiedatum". Deze wordt soms gevuld met de default waarde '1999-12-31T23:59:59+01:00'. De Mutatiedatum van de API's krijgen de timestamp van de laatste wijziging. (ID 2673)
- Het veld `giAanvraagStatus` in de GebiedsinformatieAanvragen API wordt met de juiste status gevuld, in plaats van een default waarde `open`. (ID 1992)
- Wanneer je het BIL zip-bestand ophaalt middels de API, kijgt het bestand een naam die is opgebouwd uit "BeheerdersinformatieLevering", het Klicmeldnummer en de bronhoudercode. Bijvoorbeeld: `BeheerdersinformatieLevering_19G003456_kl4141.zip`. (ID 3448)
- Bugfix: Als er bij het opvragen van BeheerdersinformatieAanvraag ook een giAanvraagId wordt opgegeven, wordt vanaf nu alleen de BeheerdersinformatieAanvraag gefilterd met de opgegeven giAanvraagId. (ID 3468)
- BeheerdersinformatieLeveringen worden alleen uitgeleverd in de API als er een levering is geweest. (ID 3278)


**Keten Acceptatietest Bevindingen**:
- Uitlevering (Zip) Bugfix: In de LI.xml wordt nu maar een keer naar één bijlage verwezen. (ID 3438)
- Uitlevering (Zip) Bugfix: Bij het bekijken van de LI.pdf kwam soms een pop-up over mogelijk geen correcte weergave. Dit is opgelost. (ID 3429)
- Uitlevering (Zip) Bugfix: De rotatiehoekSymbool van DiepteNap en DiepeTovMaaiveld wordt nu getoond in png. (ID 3412)

**Bug-fixes**:
- Weer mogelijk voor nieuwe netbeheerder om belangen aan te maken. (ID 3404)
- Performance verbetering. (ID 3113)


--------------------------------------------------------------------------------------
## Planning voor release - 10 december
Voor deze release zijn de volgende onderwerpen gepland:

**Huisaansluitschetsen**: <i>(let op: NTD volgt later)</i>

Het proces rondom de aanvraag en registratie van HAS gaat wijzigen:
- Voor de aanvraag voor huisaansluitschets (HAS) is er een maximum van 100 adresseerbare objecten (verblijfsobject, standplaats of ligplaats), waar dat voorheen was op basis van 100 unieke adressen. Soms is één unieke adres gerelateerd aan meerdere adresseerbare objecten in de Basisregistratie Adressen en Gebouwen (BAG). De telling van het maximum (100) is gebaseerd op adresseerbare objecten. (ID 3246, ID 3337, ID 3338, ID 3339, ID 3340, ID 3341)


Voor meer informatie, zie [deze link op GitHub](Toepassing%20IMKL/Gebruik%20huisaansluitschetsen%20in%20IMKL%20v1.2.1.md). <br>
<br>

--------------------------------------------------------------------------------------
## Planning voor release - 5 december
Voor deze release zijn de volgende onderwerpen gepland:

**B2B-koppeling BMKL 2.0**:
- De API's voor GebiedinformatieLevering (voor AT) en BeheerdersinformatieLevering (voor netbeheerders en AT) worden nu gesorteerd met oplopende datum. (ID 3319)
- Documentatie van de API-sprecificatie (OAS, Swagger) van Beheerdersinformatie Services is geactualiseerd.

**Bug-fixes KLIC-WIN (in de NTD)**:
- Diverse performance verbeteringen. (ID 3272)

--------------------------------------------------------------------------------------
## Planning voor release IMKL v1.2.1.1 - 3 december 2018
Naar aanleiding van de Keten Acceptatietesten zijn bevindingen geconstateerd op beschrijvingen van het IMKL.  \
Voor deze IMKL-release zijn de volgende onderwerpen gepland:
 
**[IMKL2015/regels](https://github.com/Geonovum/imkl2015/tree/master/regels)** (versie 1.2.1.1):
- Aanpassingen van extra regels zijn beschreven in [IMKL2015 v 1.2.1.1_object-attributen-ExtraRegels.xlsx](https://github.com/Geonovum/imkl2015/blob/master/regels/1.2.1.1/IMKL2015%20v%201.2.1.1_object-attributen-ExtraRegels.xlsx);  \
De aanpassingen zijn geel gemarkeerd in het document.
- Er zijn geen aanpassingen aan het UML-model of het gml-applicatieschema gedaan
- Afgehandelde issues:
  * Tabblad _Annotatie_ mist attribuut `labelpositie` met extra regels. Zie [issue 212](https://github.com/Geonovum/imkl2015-review/issues/212)
  * Bij tabblad _Maatvoering_ zijn extra regels toegevoegd bij attribuut `labelpositie`. Zie [issue 213](https://github.com/Geonovum/imkl2015-review/issues/213)
  * Bij tabblad _Utiliteitsnet_ is afkomstklasse van attribuut `beginLifespanVersion` aangepast. Zie [issue 217](https://github.com/Geonovum/imkl2015-review/issues/217)
  * Bij tabblad _Utiliteitsnet_ maar één keer attribuut `beginLifespanVersion`. Zie [issue 218](https://github.com/Geonovum/imkl2015-review/issues/218)
  * Bij attribuut `currentStatus` (afkomst: _UtilityNetworkElement_) is nilReason niet toegestaan. Zie [issue 220](https://github.com/Geonovum/imkl2015-review/issues/220)  \
Hierdoor worden netwerkelementen die hiervan overerven wél gevisualiseerd met de meegeleverde SLD.
  * Bij tabblad _ExtraDetailinfo_ zijn aan de attributen `bestandLocatie` en `bestandMediaType` extra regels toegevoegd. Zie [issue 222](https://github.com/Geonovum/imkl2015-review/issues/222)

--------------------------------------------------------------------------------------
## Planning voor release - 22 november 2018
Voor deze release zijn de volgende onderwerpen gepland:

**Huisaansluitschetsen**:

Het proces rondom de aanvraag en registratie van HAS gaat wijzigen:
- Omdat ook KLIC aansluit op de wettelijke basisregistratie BAG, moet dit adres in de basisregistratie BAG bestaan. Hierdoor worden alleen nog maar hoofdadressen geaccepteerd, en geen nevenadressen meer. 
	- Bij bestellen via de website is het selecteren van nevenadressen niet meer mogelijk. 
	- Een B2B aanvraag met een HAS aanvraag op een nevenadres wordt afgekeurd.
	- Een HAS die bij de netbeheerder geregistreerd staat onder het nevenadres, kan dus niet meer opgevraagd worden.


Voor meer informatie, zie [deze link op GitHub](Toepassing%20IMKL/Gebruik%20huisaansluitschetsen%20in%20IMKL%20v1.2.1.md). <br>
<br>

**Keten Acceptatietest Bevindingen**:
- Uitlevering (Zip) aanpassing: Markering Voorzorgsmaatregelen thema’s in leveringsbrief (weergeven in rood). (ID 3244)
- Uitlevering (Zip) Bugfix: In de leveringsbrief wordt nu altijd correct vermeld dat de netbeheerder heeft geleverd. (ID 3259)
- Uitlevering (Zip) Bugfix: Contactinformatie van Klassieke NB wordt in het LI.xml nu correct weergegeven. (ID 3293)
- Uitlevering (Zip) Bugfix: Visualisatie van labels DiepteTovMaaiveld en DiepteNAP (ID 3376)
- Bugfix: Een probleem die op kon treden tijdens het produceren is opgelost. (ID 3333)
- Bugfix: Geen excepties meer bij calamiteitenmelding met eisvoorzorgsmaatregel (EV). (ID 3418)

**B2B-koppeling BMKL 2.0**:
- In de BeheerdersinformatieAanvragen API is er voor de voor biProductiestatus een interne tussenstatus geïntroduceerd: `biGereedVoorLevering`.</br>
  De volgende waarden zijn nu mogelijk voor de biProductiestatus: `biWachtOpAntwoord`, `biInAanlevering`, `biOphalenUitCV`, `biGereedVoorLevering`, `biGereedVoorSamenstellenProduct`. (ID 2844, ID 3431)

**Bug-fixes KLIC-WIN (in de NTD)**:
- Diverse performance verbeteringen. (ID 2844, ID 3107, ID 3195, ID 3272)
- Aanleveren beheerdersinformatie houdt nu niet meer de status "Wordt gevalideerd". (ID 3316)

**Synchronisatie API**:
- Voor Agentschap Telecom worden API's beschikbaar gesteld om KLIC procesgegevens te synchroniseren met hun eigen registratie.

--------------------------------------------------------------------------------------
## Planning voor release - 7 november 2018
Voor deze release zijn de volgende onderwerpen gepland:

**Beheren communicatie gegevens**: Dienst onder Mijn Kadaster voor netbeheerders en de serviceproviders
- Aanpassen van de communicatiegegevens (URL netbeheerder & Uitvalcontact berichten) geen selfservice meer. Wijzigingsverzoeken worden voortaan afgehandeld via Klantenservice Klic. (ID 3218)
- Er komt een update van de pagina ‘ Beheren Communicatie gegevens”, waarin het mogelijk wordt een ‘WebsiteKlic’ (zie IMKL v1.2.1) op te geven. (ID 2192, ID 2970, ID 3067)
- Van netbeheerder wordt ‘WebsiteKlic’ gepresenteerd op leveringsbrief. (ID 2903, ID 2954,  ID 2955)
- Van netbeheerder wordt de ‘WebsiteKlic’ weergegeven in de GI.xml (KLIC-WIN per 1 januari 2019) (ID 2904)

**KLIC-WIN Voorzorgsmaatregelen (EV) (in de NTD)**:
- Uitleveren EV brief: In de brief wordt locatieWerkzaamheden correct gevuld. (ID 3112) 
- Aanleveren: Controleren of alle meegeleverde sjablonen gebruikt zijn in de beslisregels en een waarschuwing indien niet gebruikt. (ID 1964)
- Aanleveren: De contactpersoon van de aanvrager wordt opgeslagen. Voorheen was er een omissie en werd de contactgegevens van de organisatie opgeslagen. (ID 2260)
- Aanleveren: Keten Acceptaties bevinding: Bij het aanleveren van het voorzorgsmaatregelen bestand worden nu alle associaties met waardelijsten gecontroleerd. (ID 3248)

**B2B-koppeling BMKL 2.0: BeheerdersinformatieAanvragen**:
- De mogelijkheid om de resultaten uit de API te pagineren is in de NTD toegevoegd. (ID 2139)

**Synchronisatie API**:
- Voor Agentschap Telecom worden API's beschikbaar gesteld om KLIC procesgegevens te synchroniseren met hun eigen registratie.

**Keten Acceptatietest Bevindingen**:
- Uitlevering (Zip) aanpassing: Visualisatie bevindingen. Zie issues 221, 223, 224, 225, 226 en 227 op de [Github van Geonovum](https://github.com/Geonovum/imkl2015-review/issues). (KLIC-WIN ID 2838, ID 3186, ID 3207, ID 3208, ID 3209, ID 3253, ID 3264, ID 3265, ID 3266)   
- Uitlevering (Zip) bugfix: Sommige annotaties werden niet weergegeven (ID 3292)
- Uitlevering (Zip) bugfix: Het lettertype van het Maatvoering-/Annotatielabel is aangepast naar 'Liberation Sans' conform het visualisatie document van Geonovum. (ID 3314, ID 3296)
- Uitlevering (Zip) bugfix: EigenTopo met status "plan" wordt nu gevisualiseerd in de png. (ID 3310)
- Uitlevering (Zip) bugfix: ExtraDetailInfo type "profielschets" en "overig" worden nu ook gevisualiseerd in de png bij een 2500x2500 melding. (ID 3311)
- Uitlevering (Zip) bugfix: Alle appurtenances worden nu uitgeleverd in de png. (ID 3312)
- Uitlevering (Zip) bugfix: Visualisatie van ExtraDetailinfo in de png heeft nu juiste kleur bij alle zoomniveaus. (ID 3313)
- Aanleveren netinformatie: “nilReason” waarde bij "currentStatus" van UtilityNetworkElement, worden niet meer toegestaan. (ID 3221)

**Bug-fixes KLIC-WIN (in de NTD)**:
- Aanleveren Documenten houdt nu niet meer de status "Wordt gevalideerd". (ID 3089, ID 3202)
- Als er meer dan 1000 validatiemeldingen zijn bij het aanleveren van documenten, komt er te staan "Er zijn meer dan 1000 validatie meldingen. Meer meldingen worden niet getoond." (ID 3253, ID 2261)
- Testmeldingen met een grote (graaf)polygoon kunnen door de netbeheerder opgevraagd worden via de API. (ID 3276, ID 3350, ID 3355)
- Diverse performance verbeteringen. (ID 2338, ID 2687, ID 3277)

--------------------------------------------------------------------------------------
## Planning voor release - 29 oktober 2018
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

**KLIC-WIN Voorzorgsmaatregelen (EV)**:
- De controle op placeholdernamen is verruimd. (ID 2887, ID 2893)
- Vulling van EV bijlage placeholder "Avg-Contactpersoon-naam". Dit veld wordt nu met de correcte waarde gevuld. (ID 2243)

**Bug-fixes / Performance / Tekstueel**:
- Aanpassing van de tekstuele toelichting bij de 3 keuzes bij een Oriëntatieverzoek. (ID 2827)
- Tekstuele wijziging in het proces van het opvoeren van een graafmelding: WION is gewijzigd in WIBON. (ID 2564)
- Log-bestand na uploaden netinformatie m.b.t. aantal foutmeldingen aangepast. (ID 2842)
- Bij actualiseren documenten worden nu documenten correct opgeslagen als er meerdere malen worden verwezen naar hetzelfde bestand. (ID 2889)
- HAS-adressen toegevoegd aan LI.xml. (ID 2436)
- HAS-adressen en DAS-adressen toegevoegd aan GebiedsinformatieAanvraag via BMKL-API. (ID 2516, ID 2755, ID 2696)
- HAS adressen opgenomen in feature GebiedsinformatieAanvraag van GI.xml. (ID 2727)
- Geen foutmelding wanneer een serviceprovider alle BeheerdersinformatieAanvragen opvraagt.  (ID 2737)
- Tekst op scherm Actualiseren netinformatie veranderd van ‘IMKL2015’ naar ‘IMKL’. (ID 3150)
- Diverse performance verbeteringen met betrekking tot uitleveren en actualiseren.


--------------------------------------------------------------------------------------
## Planning voor release - eind september 2018
Voor deze release zijn de volgende onderwerpen gepland:

**NTD**:
- Diverse Performance verbeteringen met betrekking tot actualiseren. (ID 3026)

--------------------------------------------------------------------------------------
## Planning voor release - medio augustus 2018
Voor deze release zijn de volgende onderwerpen gepland:

**IMKL contacten**:
- De (de)centrale netbeheerder krijgt de mogelijkheid om van een belang per aanvraagsoort vast te kunnen leggen welk contact van toepassing is voor "netinformatie" (ID 2361)
- De (de)centrale netbeheerder krijgt de mogelijkheid om van een belang vast te kunnen leggen welk contact van toepassing is voor "beschadiging" (ID 2361)
- Let wel: dit wordt niet in de NTD beschikbaar gesteld

Voor de NTD worden de volgende onderwerpen geïmplementeerd:

**KLIC-WIN Voorzorgsmaatregelen (EV)**:
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