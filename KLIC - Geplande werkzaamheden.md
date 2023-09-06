# Geplande en uitgevoerde werkzaamheden (bijgewerkt 6 september 2023)
--------------------------------------------------------------------------------------

## 31 december 2023: einde overgangsperiode wijziging toegang KLIC-API’s Netbeheerders

De methode waarmee ***Netbeheerders*** toegang krijgen tot de KLIC-API’s gaat veranderen. Er zal -zoals gebruikelijk- een overgangsperiode van een half jaar gelden. Binnen de overgangsperiode kunnen zowel de oude als de nieuwe methodes gebruikt worden. Na afloop van de overgangsperiode kunnen alleen de nieuwe methodes nog gebruikt worden.  
  \
  De overgangsperiode start op **1 juli 2023** en zal eindigen op **31 december 2023**.

**Meer informatie**
- Op 2 juni zijn in een technische bijeenkomst voor netbeheerders en serviceproviders de wijzigingen toegelicht. [De presentaties van deze bijeenkomst](Presentaties%20bijeenkomsten/KLIC%20Technische%20Bijeenkomst/2023-06-02) zijn beschikbaar. 
- Testen is al mogelijk: Sinds 7 juni zijn de nieuwe methodes beschikbaar in de KLIC-systemen ([zie de releasenotes van de release van 6 juni](#planning-voor-release--6-juni-2023)). 
- Technische documentatie is te vinden op deze [Github pagina](API%20management/Authenticatie_via_oauth.md).

--------------------------------------------------------------------------------------

## 1 oktober 2023: Terugmelden alleen via KLIC-viewer

In overleg met het KLIC Gebruikers Overleg (KGO) is bepaald dat vanaf 1 oktober het terugmelden van afwijkende situaties alleen nog kan via een KLIC-viewer. Het webformulier op de Kadasterwebsite is vanaf die datum niet meer beschikbaar.

**Meer informatie**
- Bekijk [hier het nieuwsartikel](https://www.kadaster.nl/-/vanaf-1-oktober-alleen-terugmelden-via-klic-viewer?redirect=%2Fzakelijk%2Fregistraties%2Flandelijke-voorzieningen%2Fklic%2Fklic-nieuws) op de website van het Kadaster.
- Bekijk [hier de release beschrijving van 10 januari](#planning-voor-release---10-januari-2023) voor een toelichting op de nieuwe manier van terugmelden.


--------------------------------------------------------------------------------------
## Release – 14 September 2023

Voor deze release is het volgende onderwerp gepland:

**GebiedsinformatieAanvragen via REST API**:
- Er komt een endpoint beschikbaar waar (met de juiste authorisatie) een testmelding gedaan kan worden.
- De validatie van het bericht vindt plaats en de (a synchrone) terugkoppeling is zoals het op productie gaat werken.
- Uit deze aanvraag volgt géén levering: het productieproces is op deze testomgeving niet ingericht.
- De documentatie voor het vernieuwde aanvraagproces via een REST API is te vinden op deze [Github pagina](Aanvragen%20gebiedsinformatie/). 

Naar verwachting komt in januari 2024 de GebiedsinformatieAanvragen via REST API beschikbaar op productie. Dan blijft er gedurende een overgangsperiode van 3 maanden ook het huidige SOAP protocol beschikbaar.



--------------------------------------------------------------------------------------
## Release – 5 juli 2023

Voor deze release is het volgende onderwerp gepland:

**Kadaster KLIC-viewer**:
- **Wettelijke toegankelijkheidseisen**:  \
  De Kadaster KLIC-viewer wordt op basis van de wettelijke toegankelijkheidseisen verbeterd. Hierbij moet je denken aan toetsenbordtoegankelijkheid, leesbaarheid teksten en pop-ups.  \
Voor meer informatie zie [Uitleg WCAG](https://www.digitoegankelijk.nl/uitleg-van-eisen/wat-wcag) (Web Content Accessibility Guidelines) op digitoegankelijk.nl
--------------------------------------------------------------------------------------
## 1 juli 2023: start overgangsperiode wijziging toegang KLIC-API’s Netbeheerders

De methode waarmee ***Netbeheerders*** toegang krijgen tot de KLIC-API’s gaat veranderen. Er zal -zoals gebruikelijk- een overgangsperiode van een half jaar gelden. Binnen de overgangsperiode kunnen zowel de oude als de nieuwe methodes gebruikt worden. Na afloop van de overgangsperiode kunnen alleen de nieuwe methodes nog gebruikt worden.  
  \
  De overgangsperiode start op **1 juli 2023** en zal eindigen op **31 december 2023**.

**Meer informatie**
- Op 2 juni zijn in een technische bijeenkomst voor netbeheerders en serviceproviders de wijzigingen toegelicht. [De presentaties van deze bijeenkomst](Presentaties%20bijeenkomsten/KLIC%20Technische%20Bijeenkomst/2023-06-02) zijn beschikbaar. 
- Testen is al mogelijk: Sinds 7 juni zijn de nieuwe methodes beschikbaar in de KLIC-systemen ([zie de releasenotes van de release van 6 juni](#planning-voor-release--6-juni-2023)). 
- Technische documentatie is te vinden op deze [Github pagina](API%20management/Authenticatie_via_oauth.md).


--------------------------------------------------------------------------------------

## Documentatie GebiedsinformatieAanvragen via REST API - 30 juni 2023

**GebiedsinformatieAanvragen POST-API** : 
- De documentatie voor het vernieuwde aanvraagproces via een REST API is te vinden op deze [Github pagina](Aanvragen%20gebiedsinformatie/)
- Naar verwachting komt er een testomgeving in het derde kwartaal van 2023 beschikbaar.



--------------------------------------------------------------------------------------

## Planning voor release – 6 juni 2023


##### Beveiliging KLIC (netbeheerders en serviceproviders)
In verband met de WDO (Wet digitale overheid) zijn er aanpassingen voorzien. Dit zijn aanpassingen met betrekking tot authenticatie. Het betreft een security upgrade bij gebruik van OAuth voor de M2M/B2B processen van KLIC, zoals de REST API’s BMKL, Actualiseren en afhandelen van terugmeldingen. Deze zullen gefaseerd georganiseerd worden. Het Kadaster wil voor de M2M/B2B gebruikers tijdig testmogelijkheden beschikbaar stellen. 

***Huidige situatie***  \
Op dit moment is het niveau van berichten uitwisselen op niveau “Authorisation Grant Flow” door middel van verversen van tokens of het gebruik van een autorisatie met een Mijn Kadaster account. Dit geldt voor de zogenaamde M2M gebruikers en de interactieve gebruikers. Voor beide type gebruikers moet het niveau van berichten uitwisseling naar een hoger niveau.

***Wat gaat er veranderen voor de M2M gebruikers***
- Dit moet naar het niveau “Authorisation Client Credentials (CC) ”. Dit heeft gevolgen voor de NTD en reguliere proces (productie). 
- Er zal een overgangsfase van 6 maanden gelden waarna alleen Client Credentials (CC) gebruik mogelijk is. 


***Voor de interactieve gebruikers***
- Dit moet naar het niveau eH3. Ook hiervoor geldt dat dit gevolgen heeft voor de NTD en reguliere proces (productie). 
- Er zal een overgangsfase van 6 maanden gelden waarna alleen authenticatie met behulp van eH3 mogelijk is. 


N.B. handmatig inloggen in Mijn Kadaster is sinds [maart 2020](#planning-voor-release---17-maart-2020) al geïmplementeerd.


Voor meer informatie:
- Er wordt een technische bijeenkomst georganiseerd op 2 juni. [De presentaties van deze bijeenkomst](Presentaties%20bijeenkomsten/KLIC%20Technische%20Bijeenkomst/2023-06-02) zijn beschikbaar.
- Technische documentatie is te vinden op deze [Github pagina](API%20management/Authenticatie_via_oauth.md).


--------------------------------------------------------------------------------------
## Planning voor release – 23 mei 2023

Voor deze release is het volgende onderwerp gepland:

**Kadaster KLIC-viewer**:
- **Wettelijke toegankelijkheidseisen**:  \
  De Kadaster KLIC-viewer wordt op basis van de wettelijke toegankelijkheidseisen verbeterd. Hierbij moet je denken aan toetsenbordtoegankelijkheid, leesbaarheid teksten en pop-ups.  \
Voor meer informatie zie [Uitleg WCAG](https://www.digitoegankelijk.nl/uitleg-van-eisen/wat-wcag) (Web Content Accessibility Guidelines) op digitoegankelijk.nl

--------------------------------------------------------------------------------------
## Planning voor release - 2 mei 2023

Voor deze release is het volgende onderwerp gepland:

**Beheren Terugmelden Netbeheerder**:
- In de Mijn Kadaster applicatie 'Beheren Terugmelden Netbeheerder' wordt de naamgeving van statussen en knoppen gelijk getrokken met de terminologie uit de API. Bijvoorbeeld: `Weigeren` of `Accepteren` is na deze wijziging `Afwijzen` of `Claimen`. Het proces blijft ongewijzigd.

--------------------------------------------------------------------------------------
## Planning voor release – NTD: 16 februari 2023; Productie: 21 februari 2023

Voor deze release zijn de volgende onderwerpen gepland:

**Netbeheerder Test Dienst**:
- Mogelijkheid om KLIC-meldnummer met 6 naar 7 cijfers te testen wordt verwijderd (ID 8242).  \
Dit betreft testfunctionaliteit in de NTD die sinds [23 juni 2022](#planning-voor-release--ntd-23-juni-2022-productie-28-juni-2022) beschikbaar was.  \
Per 1 januari 2023 is het nummergedeelte van het KLIC-meldnummer regulier en op NTD uitgebreid van 6 naar 7 cijfers. Nieuw formaat: `<jj><G/C/O><nnnnnnn>` (7 cijfers). 

**Terugmelden afwijkende situatie**:
- In Mijn Kadaster applicatie “KLIC beheren terugmelding netbeheerder” het tonen van de naam van de netbeheerder naast de bronhoudercode.
- Aanpassingen op Mijn Kadaster applicatie “KLIC beheren terugmelding netbeheerder” omtrent toegankelijkheid [(WCAG)](https://digitoegankelijk.nl/toegankelijkheid/en-301-549-en-wcag) (ID 8318).

**Overig**:
- Mogelijk gemaakt om met KLIC-meldnummer met 7 cijfers graafschade te rapporteren (ID 8351).
- Er worden een aantal (technische) verbeteringen doorgevoerd



--------------------------------------------------------------------------------------
## Planning voor release - 15 februari 2023

Voor deze release zijn de volgende onderwerpen gepland:

De eisen die gesteld worden aan een Mijn Kadaster wachtwoord zijn verzwaard. Vanaf 15 februari aanstaande zullen deze ook afgedwongen worden. Het kan zijn dat u of uw gebruikers het wachtwoord moeten aanpassen. De 1e beheerders zijn hierover per mail geïnformeerd. 

**Wijzig Mijn Kadaster wachtwoorden zo snel mogelijk**  \
Om het wachtwoord te wijzigen nemen gebruikers de volgende stappen:
1.	Log in op Mijn Kadaster
2.	Klik rechtsboven op uw naam en op ‘Profielinstellingen’
3.	Klik rechtsboven op ‘Wachtwoord wijzigen’

**Verander ook het wachtwoord van webservices**  \
Gebruikt u webservices zoals BMKL/Actualiseren/TMS/B2B aanvraag?  \
Na het wijzigen van het wachtwoord in Mijn Kadaster moet u ook direct het wachtwoord in de webservice wijzigen. Neem hiervoor eventueel contact op met uw eigen software leverancier.

**Strengere eisen voor wachtwoord**  \
Het nieuwe wachtwoord moet bestaan uit:
- minimaal 1 kleine letter
- minimaal 1 hoofdletter
- minimaal 1 cijfer
- minimaal 1 speciaal teken (bijvoorbeeld: ! @ # $ % ^ &)
- minimaal 8 en maximaal 20 tekens

**Vanaf 15 februari automatische melding bij inloggen Mijn Kadaster**  \
Zijn er vanaf 15 februari nog gebruikers en beheerders met een wachtwoord dat niet aan de eisen voldoet? Dan krijgen zij een melding als ze inloggen in Mijn Kadaster. Op dat moment moet het wachtwoord gewijzigd worden. De melding kan niet worden genegeerd.



--------------------------------------------------------------------------------------
## Presentaties KLIC bijeenkomst 10 februari 2023

 
Vrijdag 10 februari is een KLIC bijeenkomst via Teams georganiseerd.  \
De presentaties kunt u terugvinden in deze map: [Presentaties bijeenkomsten](Presentaties%20bijeenkomsten/KLIC%20informatiebijeenkomst/2023-02-10)

Op 2 juni van 10.00 uur tot 12.00 houdt het Kadaster de volgende KLIC informatiebijeenkomst.  \
De bijeenkomsten worden gehouden via Teams.  \
Aanmelden kan via [https://www.kadaster.nl/-/informatiebijeenkomst-klic-juni](https://www.kadaster.nl/-/informatiebijeenkomst-klic-juni)


--------------------------------------------------------------------------------------
## Planning voor release - 10 januari 2023

**Kadaster KLIC-viewer (versie 6.0.0)**:
- Mogelijkheid tot het doen van een terugmeldingen.
- Bugfix waardoor niet meer onterecht de status "incompleet" in de titelbalk verschijnt.
- Bugfix waardoor met behulp van de rechter-muisknop weer gegevens 'gekopieerd en 'geplakt' kunnen worden in het scherm voor het openen van nieuwe melding.
- Bugfix waardoor de KLIC-viewer beter om gaat met de 'geschatte locatie'-functionaliteit van Android 12.


**Terugmelden afwijkende situatie**:  \
Na het afronden van de Keten Acceptatie Test (KAT) in oktober 2022 en het aansluitend oplossen van eventuele bevindingen is de livegang van het vernieuwde proces rondom het terugmelden van afwijkende situatie gepland op 10 januari 2023.

Voor meer informatie zie:
- [Melden afwijkende situatatie via API](Terugmelden%20Afwijkende%20Situatie/) 
- Netbeheerder afhandeling van afwijkende situatie via [BMKL-API versie 2.1](BMKL/BMKL%202.1/BMKL%202.1%20(B2B-koppeling%20beheerdersinformatie).md#overzicht-bmkl-apis-voor-afhandelen-afwijkende-situatie)
- [Wijzigingen](Wijzigingen/Terugmelden%20Afwijkende%20Situatie)



**Fasering**:
- In januari 2023 start de overgangsfase van 6 maanden. In overleg met het KLIC Gebruikersoverleg is gekozen voor een periode van zes maanden.
- Wijzigingen vanaf de start van de overgangsfase (10 januari):
  - De mail notificatie is aangepast. Een netbeheerder wordt genotificeerd dat er voor de netbeheerder een Afwijkende Situatie is gemeld.
  - In de mail notificatie worden geen bijlagen meer opgenomen met de Afwijkende Situatie stukken. 
  - Door deze mail notificatie wordt de netbeheerder op de hoogste gesteld van een Afwijkende Situatie.  \
  De netbeheerder kan met behulp van de REST API alle gegevens inzien en de Afwijkende Situatie melding afhandelen.  \
  De netbeheerder kan ook met behulp de Kadaster applicatie in Mijn Kadaster, “KLIC beheren terugmelding netbeheerder”, alle gegevens inzien en bijlagen downloaden om de Afwijkende Situatie melding af te handelen.  \
  Deze applicatie van het Kadaster zal vanaf 10 januari 2023 beschikbaar gesteld worden.  Bekijk ook deze [presentatie](Wijzigingen/Terugmelden%20Afwijkende%20Situatie/2022%209%20december%20-%20Netbeheerder%20Afw.%20Sit.%202023.pdf).


Als u vragen heeft hierover kunt u een mail sturen naar klic@kadaster.nl

--------------------------------------------------------------------------------------
## Planning voor release – 1 januari 2023

**Verlenging KLIC-meldnummer**:
- Het KLIC-meldnummer wordt per 1 januari 2023 met 1 cijfer uitgebreid, om op die manier meer KLIC-meldingen per jaar te kunnen ondersteunen.  \
  Huidig formaat: `<jj><G/C/O><nnnnnn>` (6 cijfers)   \
  Het nummergedeelte van het KLIC-meldnummer wordt uitgebreid van 6 naar 7 cijfers.  \
  Nieuw formaat: `<jj><G/C/O><nnnnnnn>` (7 cijfers)

--------------------------------------------------------------------------------------
## Planning voor release – 13 december 2022

**Verlenging KLIC-meldnummer**:
- Voorbereidingen op de wijziging van 1 januari 2023 waarbij er langere KLIC-meldnummers worden gehanteerd.

Voor voorbeeld leveringen zie: [Uitleveren / Langer KLIC-meldnummer](Uitleveren/Langer%20KLIC-meldnummer) 

--------------------------------------------------------------------------------------
## Planning aanpassing documentatie – 24 november 2022

- Ten behoeve van de implementatie van het verlengen van het KLIC-meldnummer per 1 januari 2023, zijn een aantal voorbeeld uitleveringen gepubliceerd met een langer KLIC-meldnummer.  \
Zie [Uitleveren / Langer KLIC-meldnummer](Uitleveren/Langer%20KLIC-meldnummer).

--------------------------------------------------------------------------------------


## Planning voor release – 15 november 2022

Voor deze release is het volgende onderwerp gepland:

**Kadaster KLIC-viewer**:
- Bij een KLIC-melding met een informatiepolygoon: In het kaartlagen menu is de keuze over het weergeven van de graafpolygoon en informatiepolygoon aangepast, waardoor de grens tussen deze twee altijd zichtbaar blijft (ID 7812).
- Bugfix: Met deze versie van de Kadaster KLIC-viewer kan je (weer) met de Exe en DMG een terugmelding van een afwijkende situatie testen als netbeheerder.  \
De terugmelding kan met een BIL.zip uit de NTD omgeving (Netbeheerder testdienst) worden opgevoerd (ID 8229).
- Ketenacceptatietest (KAT) bevindingen en andere bugfixes.

--------------------------------------------------------------------------------------

## Planning KAT terugmelden afwijkende situatie – 22 september 2022

Voor het testen van het terugmelden van afwijkende situatie en afhandelen daarvan wordt er een Keten Acceptatie Test (KAT) georganiseerd. Deze start 22 september en duurt 4 weken (verlenging van 2 weken).  \
Tijdens de KAT worden afwijkende meldingen met het nieuwe technische protocol gemeld en door netbeheerders afgehandeld met het nieuwe technische protocol.

De ketentester zal met een specifieke versie van de Kadaster KLIC-viewer die geschikt is voor deze testperiode de afwijkende situatie melden.  

Na het oplossen van eventuele bevindingen is de livegang van het vernieuwde proces rondom het terugmelden van afwijkende situatie gepland in januari 2023.  


Voor meer informatie zie:
- [Melden afwijkende situatatie via API](Terugmelden%20Afwijkende%20Situatie/) 
- Netbeheerder afhandeling van afwijkende situatie via [BMKL-API versie 2.1](BMKL/BMKL%202.1/BMKL%202.1%20(B2B-koppeling%20beheerdersinformatie).md#overzicht-bmkl-apis-voor-afhandelen-afwijkende-situatie)
- [Wijzigingen](Wijzigingen/Terugmelden%20Afwijkende%20Situatie)


--------------------------------------------------------------------------------------
## Planning voor release – 25 augustus 2022

Voor deze release is het volgende onderwerp gepland:

**Vernieuwing aanvraag via KLIC-online**: 
-   De Kadaster websites worden op basis van de wettelijke toegankelijkheidseisen verbeterd. Hierbij moet je denken aan toetsenbordtoegankelijkheid, leesbaarheid teksten en pop-ups.  \
Voor meer informatie zie [Uitleg WCAG](https://www.digitoegankelijk.nl/uitleg-van-eisen/wat-wcag) (Web Content Accessibility Guidelines) op digitoegankelijk.nl
- Bekijk [de presentatie met een impressie](Aanvragen%20gebiedsinformatie/images/Impressie-Vernieuwd-Graafmelding.pdf) van de graafmelding schermen.
--------------------------------------------------------------------------------------
## Planning voor release – NTD: 23 juni 2022; Productie: 28 juni 2022

Voor deze release zijn de volgende onderwerpen gepland

**Netbeheerder Test Dienst**:
- In de NTD wordt de het mogelijk om te testen met een langer KLIC-meldnummer, op aangeven van de gebruiker. (id 6837)  \
   Huidig formaat: `<jj><G/C/O><nnnnnn>` (6 cijfers)   \
  Het nummergedeelte van het KLIC-meldnummer wordt uitgebreid van 6 naar 7 cijfers.  \
  Nieuw formaat: `<jj><G/C/O><nnnnnnn>` (7 cijfers)
- Opschonen zaken die betrekking hebben op V1 (IMKL v1.2.1) (id 6881)

**KLIC-online** (bij het doen van een graafmelding, calimiteitenmelding en oriëntatieverzoek):
- De validaties met betrekking tot emailadressen (bv extra emailadres of opdrachtever emailadres) zijn aangepast en consistent gemaakt. Het is toegestaan om een '+' teken en een '&' teken te gebruiken. (id 7817)  \
  Er wordt gebruik gemaakt van een marktconforme (en bewezen) email validatie van de OWASP (Open Web Application Security Project).  \
  De reguliere expressie is: 

  ```
  ^[a-zA-Z0-9_+&*-]+(?:\\.[a-zA-Z0-9_+&*-]+)*@(?:[a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,25}$
  ```
 
  Het volgende is hierbij toegestaan:
  - Kleine letters:   a-z
  - hoofdetters:   A-Z
  - cijfers:   0-9
  - speciale tekens:   _ + & * -  
 
  De maximale lengte is 70 tekens.

--------------------------------------------------------------------------------------

## Planning voor release – begin mei 2022

| Eind april 2022 : *Einde overgangsperiode upgrade KLIC-standaarden.* |
|------|

**Doel**: Niet meer ondersteunen van IMKL versie 1.2.1 en PMKL 1.2.1 en BMKL 2.0. en doorvoeren aanpassingen zoals afgesproken in [Mijlpaal 6 van het programma](Wijzigingen/Archief/Upgrade%20KLIC%20standaarden#toelichting-mijlpaal-6).


**Samenvatting**:
- API: alleen de V2 API kan nog gebruikt worden; de V1 API gaat uit.
- Aanleveren mag alleen nog maar in IMKL versie 2.0; aanleveringen in IMKL versie 1.2.1 worden afgekeurd.
- Uitleveringen (ook BILzip) bevatten alleen nog maar IMKL versie 2.0 van de Gebiedsinformatie-xml; de Gebiedsinformatie-xml van IMKL versie 1.2.1 zit niet meer in de leveringzip (*merk op dat de V2 xml zal voldoen aan dezelfde naamgevingsconventies als tijdens de overgangsperiode, dus mét* `_V2`)
- Viewers moeten voldoen aan de PMKL versie 2.0
- Implementatie op productie van bevindingen uit de Keten Acceptatie Testen (KAT)


Tot het einde van de overgangsperiode worden een aantal zaken niet toegestaan omdat het transformeren naar IMKL 1.2.1 dan niet mogelijk is. Ná de overgangsperiode kan er bijvoorbeeld gebruik gemaakt worden van de mogelijkheid om "overige appurtenances" van het type "onbekend" aan te leveren.  \
Daarnaast zijn er een aantal zaken die gecontroleerd zullen plaats vinden zoals het clippen op EV vlakken (gerelateerd aan issue 210), of een langer KLIC-meldnummer. 



:bulb: Zie ook het **schematische overzicht** rond het einde van de overgangsperiode bij de  [toelichting van Mijlpaal 6 van het programma](Wijzigingen/Archief/Upgrade%20KLIC%20standaarden#toelichting-mijlpaal-6).  

![Einde overgangsperiode](Wijzigingen/Archief/Upgrade%20KLIC%20standaarden/bijlagen/Detail-mijlpaal6.png "Details rond einde overgangsperiode")  
*Schematisch overzicht met betrekking tot het in gebruikname van functionaliteit rond het einde van de overgangsperiode*

**Toeliching ijkpunt KLIC-aanvragen**:  \
Net als bij de start van de overgangsperiode, is het moment van aanvragen van een KLIC-melding het ijkpunt om te bepalen of een KLIC-melding in de periode 'voor-', 'tijdens-' of 'na-' de overgangsperiode valt.  \
Een KLIC-melding die gedaan wordt op of na 1 mei 0:00 uur wordt beschouwd als "na de overgangsperiode", en wordt dan alleen in versie 2 uitgeleverd.  \
Een KLIC-melding die gedaan wordt op of voor 30 april 23:59 uur wordt beschouwd als "tijdens de overgangsperiode", en wordt dan in beide versies uitgeleverd; ook als de daadwerkelijke levering pas op na 1 mei plaatsvindt.

--------------------------------------------------------------------------------------
## Planning voor release – NTD: 21 april 2022; Productie 26 april 2022
 

Voor deze release is het volgende onderwerp gepland:

**Upgrade KLIC-standaarden**:
- Voorbereidingen t.b.v. Mijlpaal 6, einde  overgangsperiode (30 april 2022).


  Alles over het **IMKL versie 2.0**, de overgangsperiode, de implementatie strategie en inzicht in de wijzigingen; is te vinden op de speciale pagina van deze Github:  \
 :white_check_mark:  [/Wijzigingen / Archief / Upgrade KLIC standaarden /](Wijzigingen/Archief/Upgrade%20KLIC%20standaarden/) 
 
 **Kadaster KLIC-viewer (versie 5.17)**:
- Diverse bugfixes
 
--------------------------------------------------------------------------------------
## Planning aanpassing documentatie – 1 april 2022

- Ten behoeve van de implementatie van de upgrade van de KLIC-standaarden zijn een aantal voorbeeld uitleveringen gepubliceerd voor ná de overgangsperiode.  \
Zie [Uitleveren / Voorbeelden IMKL v2.0](Uitleveren/Voorbeelden%20IMKL%20v2.0).
- Publicatie van de resultaten van de diverse werkgroepen met betrekking tot 'Beheren van de Standaarden'.  \
Zie [Beheren standaarden KLIC](Beheren%20standaarden%20KLIC/README.md).

--------------------------------------------------------------------------------------
## Planning voor release – 22 maart 2022

Voor deze release is het volgende onderwerp gepland:

**Upgrade KLIC-standaarden**:
- Voorbereidingen t.b.v. Mijlpaal 6, einde  overgangsperiode (30 april 2022).


  Alles over het **IMKL versie 2.0**, de overgangsperiode, de implementatie strategie en inzicht in de wijzigingen; is te vinden op de speciale pagina van deze Github:  \
 :white_check_mark:  [Wijzigingen / Archief / Upgrade KLIC standaarden /](Wijzigingen/Archief/Upgrade%20KLIC%20standaarden/) 

--------------------------------------------------------------------------------------

## Planning voor release – Netbeheerder Testdienst (NTD): 17 maart 2022

Voor deze release zijn de volgende onderwerpen gepland:

**Voorbereiding einde overgangsperiode**: 
- Vanaf 17 maart kunnen netbeheerders in de Netbeheerder Testdienst (NTD) de situatie simuleren van na de overgangsperiode waarin er alleen nog maar een V2-xml in de beheerdersinformatieLevering (BIL-Zip) zit en waarbij er multivlakken zijn toegestaan voor `AanduidingEisVoorzorgzorgsmaatregel` en `ExtraGeometrie`.  \
Dat betekend dat vanuit de Centrale Voorziening geclipt zal worden en dat een decentrale netbeheerder, beheerdersinformatie kan aanleveren met multi-vlakken.  \
  Zie https://github.com/Geonovum/imkl2015-review/issues/210 
  
 
  Deze keuze is per test in te stellen op het eerste scherm bij het doen van de aanvraag. Zie onderstaand figuur:  \
   ![Testparameters NTD](Aanvragen%20gebiedsinformatie/images/testparametersNTD2.png "Testparameters NTD")   \
   *fragment van NTD scherm "Opvoeren testmelding" (stap 1) ter illustratie* 

**Planning vernieuwing Afwijkende Situatie**:
- Vanaf 17 maart zal in de Netbeheerder Testdienst (NTD) functionaliteit beschikbaar zijn om het vernieuwde proces rondom 'Afwijkende Situaties' te testen. Dat wil zeggen dat de netbeheerder een afwijkende melding kan simuleren en deze daarna zelf kan afhandelen door middel van een REST API.

  Voor meer informatie zie:
- [Melden afwijkende situatatie via API](Terugmelden%20Afwijkende%20Situatie/) 
- Netbeheerder afhandeling van afwijkende situatie via [BMKL-API versie 2.1](BMKL/BMKL%202.1/BMKL%202.1%20(B2B-koppeling%20beheerdersinformatie).md#overzicht-bmkl-apis-voor-afhandelen-afwijkende-situatie)
- [Wijzigingen](Wijzigingen/Terugmelden%20Afwijkende%20Situatie)

  Zie onderstaand figuur:  \
   ![Melden Afwijkende situatie op NTD](Terugmelden%20Afwijkende%20Situatie/images/stappen-testmelding-afwijkende-situatie-op-NTD.png "Afwijkende situatie testen op NTD")   \
   *Stappen voor testen afwijkende situatie op NTD ter illustratie* 
   
  Toelichting:
- Stap 1: Bestaand NTD proces
- Stap 2 en 3: Melden afwijkende functionaliteit alleen beschikbaar in nieuwste versie van de Kadaster KLIC-viewer in het geval van het openen van een BIL.zip uit de NTD (in de EXE of DMG).  \
  Voor melden via de API zie: [deze Github pagina](Terugmelden%20Afwijkende%20Situatie/). Gebruik het test-endpoint: `https://api.acceptatie.kadaster.nl/tms/v1/terugmeldingen`
- Stap 4: Zie hiervoor de specificatie op:  [deze Github pagina](BMKL/BMKL%202.1/BMKL%202.1%20(B2B-koppeling%20beheerdersinformatie).md#overzicht-bmkl-apis-voor-afhandelen-afwijkende-situatie).

--------------------------------------------------------------------------------------
## Planning voor release – 8 maart 2022

Voor deze release is het volgende onderwerp gepland:

**Kadaster KLIC-viewer**:
- **Wettelijke toegankelijkheidseisen**:  \
  De Kadaster KLIC-viewer wordt op basis van de wettelijke toegankelijkheidseisen verbeterd. Hierbij moet je denken aan toetsenbordtoegankelijkheid, leesbaarheid teksten en pop-ups.  \
Voor meer informatie zie [Uitleg WCAG](https://www.digitoegankelijk.nl/uitleg-van-eisen/wat-wcag) (Web Content Accessibility Guidelines) op digitoegankelijk.nl

- **Visualisatie Extra Detail informatie**:  \
Er is ontdekt dat in de Kadaster KLIC-viewer het ExtraDetailinfo-vlak iets groter gevisualiseerd wordt dan bedoeld is in de visualisatie standaard. 
Tevens blijkt dat om sommige schaalniveaus het icoontje behorend bij de Extra Detailinfo te groot wordt weergegeven in de Kadaster KLIC-viewer.  \
Met deze release zal dit opgelost worden in de Kadaster KLIC-viewer. (id 7312 en 7358)  \
Dit was een Keten Acceptatie Testen (KAT) bevinding van Upgrade Standaarden.

- **Bugfix**:  \
De BIL (Beheerdersinformatielevering) uit de NTD kan weer bekeken worden met deze versie van de Exe viewer (id 7517).

- **Testen vernieuwde terugmeldvoorziening**:  \
  Met deze versie van de Kadaster KLIC-viewer kan je met de Exe en DMG een terugmelding van een afwijkende situatie testen als netbeheerder.  \
De terugmelding kan met een BIL.zip uit de NTD omgeving (Netbeheerder testdienst) worden opgevoerd.  \
Vanaf 17 maart zal in de Netbeheerder Testdienst (NTD) functionaliteit beschikbaar komen om het vernieuwde proces rondom 'Afwijkende Situaties' te testen. Dat wil zeggen dat de netbeheerder een afwijkende melding kan simuleren en deze daarna zelf kan afhandelen door middel van een REST API.




--------------------------------------------------------------------------------------
## Planning voor release – 8 maart 2022


**Planning vernieuwing generieke Mijn Kadaster portaal**:  \
Vanaf 8 maart zal het algemene Mijn Kadaster portaal vernieuwd worden.  \
Na het inloggen in Mijn Kadaster zijn dit de verandering: 
- De vormgeving is opgefrist en sluit aan op de (al vernieuwde) kadaster websites;
- Het menu is aangepast waardoor de gebruikers makkelijker kunnen navigeren;
- Op de homepage van Mijn Kadaster kunnen de gebruikers veelgebruikte applicaties als favoriet vastzetten.  

De specifieke KLIC applicaties in Mijn Kadaster blijven hetzelfde.

Voor meer informatie zie [deze pagina van het Kadaster](https://www.kadaster.nl/zakelijk/mijn-kadaster/vernieuwing-mijn-kadaster).



--------------------------------------------------------------------------------------
## Planning voor release – 8 februari 2022

Voor deze release zijn de volgende onderwerpen gepland:

**Bevindingen Keten Acceptatie Testen (KAT) van Upgrade Standaarden**.
- **In XML altijd Landcode opgeven**  \
  Er is een inconsistentie ontdekt tussen het UML-model en de XSD met betrekking tot de verplichting van de landcode als onderdeel van een adres. Gezien de impact is besloten om geen wijzigen door te voeren in de XSD en deze dus leidend te laten zijn.  \
  Dit heeft tot gevolg dat er ook voor adressen die altijd Nederlandse adressen zijn (locatieWerkzaamheden-adres en Huisaansluitschets-adressen) in de leverings-XML een landcode in het adres-object getoond wordt. (id 7338)  \
Deze wijziging heeft impact op de GebiedsInformatieLevering-XML (in zowel de leverings-ZIP als de BeheerdersinformatieLevering-ZIP).  \
  Met deze release wordt dit in de NetbeheerdersTestDient (NTD) beschikbaar gesteld. 

- **Aanvraag met RD-coördinaten in maximaal 3 decimalen**  \
Volgens de IMKL-standaard worden RD-coördinaten uitgewisseld met maximaal 3 decimalen. Voor de polygonen uit de gebiedsinformatie aanvraag zijn er tot op heden echter alleen maar coördinaten met 0 decimalen uitgewissel omdat aanvragen met (graaf)polygonen in decimalen afgekeurd werden.  \
Genoemde validatie is echter niet in lijn met het IMKL en daarom wordt het na deze implementatie goedgekeurd als er een graafpolygoon, oriëntatiepolygoon en/of informatiepolygoon wordt aangevraagd met 0,1,2 of 3 decimalen.  \
Deze wijziging heeft impact op de GebiedsinformatieAanvragen-API en op de GebiedsInformatieLevering-XML (in zowel de leverings-ZIP als de BeheerdersinformatieLevering-ZIP).  \
Met deze release komt in de NetbeheerdersTestDient (NTD) de mogelijkheid om testmeldingen te doen met polygonen tot 3 decimalen. 

**Toelichting Testen in NTD**:  \
Na deze release kan de gebruiker zelf bepalen of hij coordinaten ingeeft met 0, 1, 2 en/of 3 decimalen.  \
De gebruiker kan tevens met een checkbox aangeven of hij wil dat in de Gebiedsinformatie-xml de landcode wordt aangevuld bij de Huisaansluitschetsen (HAS) en het dichtstbijzijnd adres (DAS).


Deze keuze is per test in te stellen op het eerste scherm bij het doen van de aanvraag. \
Zie onderstaand figuur:  \
 ![Testparameters NTD](Aanvragen%20gebiedsinformatie/images/testparametersNTD.png "Testparameters NTD")   \
 *fragment van NTD scherm "Opvoeren testmelding" (stap 1) ter illustratie* 



--------------------------------------------------------------------------------------
## Planning voor release – 18 januari 2022

Voor deze release is het volgende onderwerp gepland:

**Aanpassing proces eenmalige melder (via Selfservice/webwinkel)**:
- In verband met eisen vanuit de Overheid m.b.t. veilig uitwisselen van gegevens zal het proces via Selfservice enigszins aangepast worden. Voor specifiek deze aanvragers wordt een toegangscode vereist voor het downloaden van de KLIC-levering. De toegangscode staat in de KLIC-ontvangstbevestiging. Bij het downloaden van de zip wordt om deze code gevraagd. Bij gebruik van de downloadlink in de Kadaster KLIC-viewer wordt ook om de toegangscode gevraagd.

**Kadaster KLIC-viewer (versie 5.15)**:
- Aanpassing voor proces eenmalige melder (via Selfservice/webwinkel) zoals hierboven benoemd.
- Het kan voorkomen dat informatie afgedekt wordt door de weergave van extradetailinfo tijdens het printen. Met deze wijziging wordt de extradetailinfo niet meer getoond in de geproduceerde PDF's.

--------------------------------------------------------------------------------------
## Planning voor release – 4 januari 2022

**Kadaster KLIC-viewer (versie 5.14.1)**:
- Update met betrekking tot weergave van extradetailinfo. Ten behoeve van het gebruikersgemak wordt de toggle voor het weergeven van de extradetailinformatie standaard uitgezet. Deze is aan te zetten via het menu "Weergave" in het tabblad "Kaartlagen".  \
  Let op: Deze aanpassing heeft geen invloed op de printfunctionaliteit; de extradetailinformatie wordt hierin getoond. Vanaf de release van 18 januari wordt deze niet meer getoond bij het printen.


------------------------------------------------------------------------------------
## Start overgangsperiode Upgrade Standaarden - 3 januari 2022

> Vanaf 3 januari gaan geleidelijk steeds meer netbeheerders over naar aanleveren volgens de nieuwe versie van de KLIC-standaarden. Voor de grondroerders wijzigt per 3 januari 2022 **direct** de KLIC-uitlevering. Daarnaast wijzigt voor de netbeheerder hiermee ook de BILzip per 3 januari 2022.

**Samenvatting van de wijzigingen bij aanvang van de overgangsperiode**:
- Uitlevering: V1-xml én V2-xml (ook in BILzip)
- Aanvraag: Referentie veld verplicht bij aanvraag (en nog aantal optionele extra’s)
- API: V2 naast V1
- Aanleveren: V1 óf V2 (documenten hóéft niet opnieuw)
- Voor meer details zie de uitleg [op deze pagina](Wijzigingen/Archief/Upgrade%20KLIC%20standaarden#toelichting-implementatie-upgrade-standaarden).

**Documenten**:  \
Een presentatie met de hoofdlijnen van het implementatieplan [is hier te vinden](Wijzigingen/Archief/Upgrade%20KLIC%20standaarden/Implementatie%20hoofdlijnen%20KLIC%20standaarden-sept21.pdf)  \
Het Implementatieplan [is hier te vinden](Wijzigingen/Archief/Upgrade%20KLIC%20standaarden/IMPLEMENTATIEPLAN%20upgrade%20standaarden%20KLIC-1.1.pdf)

  \
Alles over het **IMKL versie 2.0**, de overgangsperiode, de implementatie strategie en inzicht in de wijzigingen; is te vinden op de speciale pagina van deze Github:  \
:white_check_mark: [/Wijzigingen / Archief / Upgrade KLIC standaarden /](Wijzigingen/Archief/Upgrade%20KLIC%20standaarden/) 

--------------------------------------------------------------------------------------
## Planning Upgrade Standaarden - 21 december 2021

**Kadaster KLIC-viewer**:
- De Kadaster KLIC-viewer wordt op basis van de wettelijke toegankelijkheidseisen gefaseerd verbeterd. Hierbij moet je denken aan toetsenbordtoegankelijkheid, leesbaarheid teksten en pop-ups.

Voor meer informatie zie:
- [Uitleg WCAG](https://www.digitoegankelijk.nl/uitleg-van-eisen/wat-wcag) (Web Content Accessibility Guidelines) op digitoegankelijk.nl

--------------------------------------------------------------------------------------
## Planning Upgrade Standaarden - 14 december 2021

Voor deze release zijn de volgende onderwerpen gepland:

**Upgrade KLIC-standaarden**:
- Voorbereidingen t.b.v. Mijlpaal 5, start overgangsperiode (3 januari 2022).



  Alles over het **IMKL versie 2.0**, de overgangsperiode, de implementatie strategie en inzicht in de wijzigingen; is te vinden op de speciale pagina van deze Github:  \
:white_check_mark:   [/Wijzigingen / Archief / Upgrade KLIC standaarden /](Wijzigingen/Archief/Upgrade%20KLIC%20standaarden/) 

--------------------------------------------------------------------------------------
## Planning aanpassing documentatie – 5 november 2021

Ten behoeve van de implementatie van de upgrade van de KLIC-standaarden zijn een aantal voorbeeld uitleveringen gepubliceerd.  \
Zie [Uitleveren / Voorbeelden Overgangsperiode](Uitleveren/Voorbeelden%20Overgangsperiode).

--------------------------------------------------------------------------------------
## Planning voor release – 26 oktober 2021

Voor deze release is het volgende onderwerp gepland:

**KLIC-online** (bij het doen van een graafmelding en oriëntatieverzoek):
- Opvallende melding als gebruiker aanvangsdatum binnen 3 dagen kiest bij een graafmelding.  \
  Het KLIC gebruikersoverleg (KGO KLIC) heeft extra aandacht gevraagd voor het EV proces in KLIC-online. Gebruikers die binnen 3 dagen een datum kiezen realiseren zich wellicht niet dat er een EV van toepassing kan zijn.  \
   De volgende melding wordt getoond:  \
    ![Graven Binnen 3 Werkdagen](Aanvragen%20gebiedsinformatie/images/GravenBinnen3Werkdagen.png "Graven Binnen 3 Werkdagen")  

   


--------------------------------------------------------------------------------------
## Planning Upgrade Standaarden vanaf 13 september 2021

Op 13 september is een Keten Acceptatie Test (KAT) gestart als onderdeel van de Upgrade van de Standaarden.  

Aanmelden voor de KAT kan nog via klic.project@kadaster.nl

Alles over het **IMKL versie 2.0**, de overgangsperiode, de implementatie strategie en inzicht in de wijzigingen; is te vinden op de speciale pagina van deze Github:  \
:white_check_mark: [/Wijzigingen / Archief /Upgrade KLIC standaarden /](Wijzigingen/Archief/Upgrade%20KLIC%20standaarden/) 



--------------------------------------------------------------------------------------
## Planning voor release – 28 september 2021

Voor deze release is het volgende onderwerp gepland:

**Kadaster KLIC-viewer (versie 5.13.0)**:
- Bij recent geopende lijst met KLIC-meldingen is ook de Referentie uit de KLIC-aanvraag toegevoegd (naast KLIC-nummer) (id 6642).
- Diverse bugfixes.


--------------------------------------------------------------------------------------
## Planning voor release – NTD: 23 september 2021; Productie 28 september 2021

Voor deze release is het volgende onderwerp gepland:

Diverse verbeteringen:
- Performance centraal aanleveren.
- Textuele aanpassing in NTD schermen.
- Aanpassing waarde van veld `positienummer` in GI.xml in NTD.
- De (optionele) velden van BAGid van het bezoekadres van de aanvrager en opdrachtgever worden in de NTD in de IMKL-Versie 2 nu weergegeven in zowel de API-V2 als de GI_V2.xml.


--------------------------------------------------------------------------------------
## Planning voor release – 12 augustus 2021

Voor deze release is het volgende onderwerp gepland:

**Kadaster KLIC-viewer (versie 5.12.1):**
- Wijzging in het weergeven van informatie op het scherm met betrekking tot de volgorde, groepering, vertalingen en klikbaarheid van links. Zichtbaar in:
  - Gebiedsinformatie-aanvraag menu scherm
  - Details schermen na selectie
- Diverse bugfixes met betrekking tot de 'recent geopend' functionaliteit.
- De viewer is voorbereid om nieuwe leveringen mbt de standaarden upgrade (IMKL 2.0) te laten zien.

--------------------------------------------------------------------------------------
## Planning voor release – Netbeheerder Testdienst (NTD): 12 augustus 2021

Voor deze release is het volgende onderwerp gepland:

In verband met de upgrade van de KLIC-standaarden wordt aan de sector de mogelijkheid gegeven om in de NTD gebruik te maken van de nieuwe API's. De nieuwe endpoints zijn naast de huidige endpoints te gebruiken.  \
Beide API’s kunnen gebruikt worden voor alle dossiers/meldingen op te vragen.  \
  \
Zie ook [de toelichting op de derde mijlpaal](Wijzigingen/Archief/Upgrade%20KLIC%20standaarden#toelichting-mijlpaal-3) van de upgrade van de standaarden. 


--------------------------------------------------------------------------------------
## Planning voor release – 20 juli 2021

Voor deze release is het volgende onderwerp gepland:

**Kadaster KLIC-viewer (iOS, versie 5.11.):**

1.	Om op je mobiele device offline gebruik te kunnen maken van je KLIC-levering, wordt de Kadaster KLIC-viewer ook als iOS App beschikbaar gesteld.
De Kadaster KLIC-viewer is sinds [7 april 2021](https://github.com/kadaster/klic-win/blob/master/KLIC%20-%20Geplande%20werkzaamheden.md#planning-voor-release--7-april-2021) als Android App beschikbaar (6343).
2.	Met de sector [afgestemde vertaling](https://github.com/kadaster/klic-win/blob/master/Beheren%20standaarden%20KLIC/Eisen%20overheid%20ordening%20attributen%20(concept).xlsx) van attribuutwaarden worden geïmplementeerd bij het klikken op de kaart informatie (Feature informatie). 
Met name Engelse waarden zijn vertaald naar Nederlandse waarden (5152)
3.	Inkorten lange URL waarden bij het klikken op de kaart informatie (Feature informatie) (4022).
4.	Extra Detailinformatie PDF bestanden zal een link worden, waardoor het makkelijker te openen is bij het klikken op de kaart informatie (Feature informatie) (4477).
5.	Bij het gebruik van de Kadaster KLIC-viewer App (iOS en Android) zal de smartphone of tablet kort trillen indien er een Eis Voorzorgsmaatregel (EV) van toepassing is bij de geopende KLIC-levering (6844).
6.	Diverse bugfixes.


--------------------------------------------------------------------------------------
## Planning voor release – Netbeheerder Testdienst (NTD): 15 juli 2021

Voor deze release is het volgende onderwerp gepland:

In verband met de upgrade van de KLIC-standaarden wordt aan de sector de mogelijkheid gegeven om in de NTD een testmelding te doen, waarbij er 2 XML’s (V1 én V2) in de BeheerdersinformatieLevering (BIL-Zip) zit.  \
Beide XML's representeren de complete set aan data: een XML is volgens IMKL versie 1.2.1 en de andere volgens IMKL versie 2.0.  \
  \
Mocht u gebruik maken van de Kadaster KLIC-viewer, dan kunt u de BIL-Zip van de NTD openen met de viewer die op 20 juli gereleased wordt. Deze zal volgens de huidige visualisatie regels het IMKL 1.2.1 presenteren.  

Zie ook [de toelichting op de tweede mijlpaal](Wijzigingen/Archief/Upgrade%20KLIC%20standaarden#toelichting-mijlpaal-2) van de upgrade van de standaarden.  
Op bovenstaande pagina zijn ook enkele **voorbeeldbestanden** te vinden.




--------------------------------------------------------------------------------------
## Planning voor release - 1 juli 2021

Voor deze release is het volgende onderwerp gepland:

**Vernieuwing proces eenmalige melder (particulier)**:
- De éénmalige gebruiker kan een KLIC-melding doen door middel van selfservice in plaats van het webformulier.

--------------------------------------------------------------------------------------
## Planning voor release - 26 mei 2021

Voor deze release is het volgende onderwerp gepland:

**Kadaster KLIC-viewer (versie 5.10.0)**:
- De BeheerdersinformatieLevering (BIL ZIP) uit de Netbeheerders Testdienst (NTD) kan door netbeheerders bekeken worden met de Windows-versie van de Kadaster KLIC-viewer (id 5613).
- De attributen en waarden zullen op de vastgestelde vaste volgorde worden getoond (ook wel ordening genoemd).   
De Technische Commissie Standaarden KLIC (TCS) heeft deze volgorde vastgesteld. De gebruiker ziet de belangrijkste attributen en waarden bovenaan in de resultaten na een klik op de kabels of leidingen (id 6340).  \
U kunt de vastgestelde ordening bekijken op de pagina van de TCS (Eisen overheid ordening attributen (vastgesteld 15-05-2020).
- Betere werking van de “Backbutton” in de Android App (id 6565).
- In het Printen menu wordt de optie “Overzichtskaart” als 1e optie getoond 
(id 6575).
- Diverse bugfixes.


--------------------------------------------------------------------------------------
## Planning aanpassing documentatie – 21 mei 2021

Door de upgrade van de KLIC-standaarden zullen gefaseerd een aantal aanpassingen doorgevoerd worden in het B2B aanvraag proces. Hiervoor is een nieuwe versie opgesteld. De nieuwe versie heeft impact op de KLIC-aanvraag (KLIC-melding).  

- Per 21 mei 2021 is de [nieuwe XSD v1.2](Aanvragen%20gebiedsinformatie/Schemas/) beschikbaar.
- In Q3 2021 zal het mogelijk zijn om in een Acceptatieomgeving van het Kadaster testen uit te voeren. Dit is onderdeel van het programma “[Upgrade KLIC standaarden](Wijzigingen/Archief/Upgrade%20KLIC%20standaarden/)”.
- Per 3 januari 2022 wordt het verplicht om de nieuwe XSD v1.2 te gebruiken. 


--------------------------------------------------------------------------------------
## Planning voor release – Netbeheerder Testdienst (NTD): 20 mei 2021

In verband met de upgrade van de KLIC-standaarden komt actualiseren voor versie 2 beschikbaar.  \
Met deze aanpassing is het mogelijk om centraal en decentraal aan te leveren met de geüpgrade versie inclusief validatie op basis van de geüpgrade IMKL standaard.  \
Testen in de NTD in de huidige versie blijft ongewijzigd beschikbaar.  \
Vanaf medio juli 2021 zal de Beheerdersinformatielevering (BIL.ZIP) beide versies bevatten.  \
Let op dus bij het testen van de huidige versie én testen van de geüpgrade versie worden 2 XML’s in de BIL.ZIP opgenomen!  \
  \
Zie ook [de toelichting op de eerste mijlpaal](Wijzigingen/Archief/Upgrade%20KLIC%20standaarden#toelichting-mijlpaal-1) van de upgrade van de standaarden. 


--------------------------------------------------------------------------------------
## Planning voor release – 12 april 2021
Voor deze release is het volgende onderwerp gepland:
- De inhoud van de leveringsmail is aangepast.

Voorbeelden:
- [Complete levering](Uitleveren/KLIC%20complete%20levering%201%20980708428010%2021C000981%20Ref.pdf)
- [Deel levering](Uitleveren/KLIC%20deellevering%201%20980708428310%2021G000765%20Ref%20voorbeeld%20tekst.pdf)
- [Levering leeg](Uitleveren/KLIC%20levering%20(leeg)%201%20980708428410%2021G000766%20Ref%20voorbeeld%20tekst.pdf)

--------------------------------------------------------------------------------------
## Planning voor release – 7 april 2021

Voor deze release is het volgende onderwerp gepland:
Kadaster KLIC-viewer (versie 5.9)

De Kadaster KLIC-viewer kan online en offline gebruikt worden en wordt multi-platform beschikbaar gesteld.
- Om op je mobiele device offline gebruik te kunnen maken van je KLIC-levering, wordt de Kadaster KLIC-viewer ook als App beschikbaar gesteld. In de eerste release zal dit een Android App zijn. Daarna komt een IOS variant beschikbaar.
  - Merk op dat je vanaf [1 april 2021](https://www.agentschaptelecom.nl/onderwerpen/kabels-en-leidingen/documenten/publicaties/2021/01/22/gebiedsinformatie-en-viewers) verplicht bent om een digitaal hulpmiddel bij je te hebben op de graaflocatie. Als de Kadaster KLIC-viewer App niet exact op 1 april beschikbaar is, wordt geadviseerd om de Kadaster KLIC-viewer online te gebruiken.
Tevens is de performance van kaartlagen uit en aanzetten is verhoogd voor alle platformen (ID 5298)

--------------------------------------------------------------------------------------
## Planning voor release - 2 maart 2021
Voor deze release is het volgende onderwerp gepland:

- Geen functionele aanpassingen, enkel technische aanpassingen ter voorbereiding op de upgrade van de standaarden.

--------------------------------------------------------------------------------------
## Planning voor release - 2 februari 2021
Onderstaande is op 8 juli 2020 afgestemd met het KLIC gebruikersoverleg (KGO KLIC).

**Uitlevering**:
- Het zipbestand met de KLIC-uitlevering wordt aangepast in productie:
  - de Gelaagde PDF (LP.pdf) wordt niet meer meegeleverd. 
- De layout en de inhoud van de ontvangstbevestiging en de leveringsmail worden gemoderniseerd.
  - Tevens zal de tweede link die in de leveringsemail staat en verwijst naar een web-service niet meer ondersteund worden.
Meer informatie is in [deze korte presentatie](Uitleveren/KLIC-uitleveringen%20-%20volgende%20versie.pdf) beschikbaar.
Voorbeelden met de nieuwe layout van de [ontvangstbevestigingsmail](Uitleveren/KLIC%20ontvangstbevestigingsmail%20-%20per%202%20februari%202021.pdf) en de [leveringsmail](Uitleveren/KLIC%20leveringsmail%20-%20per%202%20februari%202021.pdf) zijn reeds [gepubliceerd op GitHub](Uitleveren/).

--------------------------------------------------------------------------------------
## Planning voor release - 26 januari 2021
Voor deze release is het volgende onderwerpen gepland:

**Aanleveren (centraal en decentraal)**:
- Ter voorbereiding op de upgrade van de standaarden, zijn aanleveringen van bestanden met een bestandnaam die eindigt op `_v2` of `_V2` niet meer toegestaan.
  * dit geldt zowel voor het actualiseren (centrale netbeheerder) als het aanleveren van beheerdersinformatie (decentraal)

--------------------------------------------------------------------------------------
## Planning voor release - 22 januari 2021
Voor deze release is het volgende onderwerpen gepland:

**API's voor afhandelen afwijkende situatie**:
- De documentatie voor de API's voor het afhandelen van afwijkende situaties is [gepubliceerd op de GitHub](BMKL/BMKL%202.1/BMKL%202.1%20(B2B-koppeling%20beheerdersinformatie).md#overzicht-bmkl-apis-voor-afhandelen-afwijkende-situatie).  \
  Dit betreft de specificatie van de API die nog ontwikkeld moet worden (*gepland in 2021*).

--------------------------------------------------------------------------------------
## Planning voor release - 19 januari 2021
Voor deze release zijn de volgende onderwerpen gepland:

**Kadaster KLIC-viewer (versie 5.8.0)**:
- Er wordt een extra print-optie toegevoegd om een overzichtskaart te genereren. Dit is één pagina waarop alle netbeheerders/thema zichtbaar zijn, zonder annotatie en maatvoering. (ID 6133)
- Bij het meten worden nu ook de de afstanden van de deelstukken weergegeven. (ID 4792)
- De meetresultaten worden mee geprint, als de weergave aan staat in het tabblad `KAARTLAGEN` onder het menu-item `Weergave`.

--------------------------------------------------------------------------------------
## Planning voor release - 15 december 2020
Voor deze release zijn de volgende onderwerpen gepland:

**KLIC-online** (bij het doen van een graafmelding en oriëntatieverzoek):
- Bij het opgeven van de soort werkzaamheden staat nu expliciet vermeld dat er maximaal 6 soorten graafwerkzaamheden opgegeven kunnen worden.

--------------------------------------------------------------------------------------
## Planning voor release - 14 december 2020
Voor deze release zijn de volgende onderwerpen gepland:

**Wijziging in afzenderadres van emails**:
- Het afzender-emailadres verandert. Waar nu de afzender "noreply@kadaster.nl" is, wordt dat vanaf deze release "klic@kadaster.nl". Dit geldt voor alle emails verstuurd vanuit het KLIC-systeem.  \
  Mocht u regels in uw emailprogramma hebben toegevoegd op basis van het huidige afzenderadres, dient u hier rekening mee te houden.

--------------------------------------------------------------------------------------
## Planning voor release - 24 november 2020
Voor deze release zijn de volgende onderwerpen gepland:

**Kadaster KLIC-viewer (versie 5.7.20 )**:
- De leesbaarheid van de schaalbalk is verbeterd (id 5275).
- Het menu item `Menu` is hernoemd naar `Meer` met aangepast icoon (id 5828).
- Als een gebruiker de meten-functionaliteit heeft gebruikt, is de weergave hiervan uit en aan te zetten in het tabblad `KAARTLAGEN` onder het menu-item `Weergave` (id 5617).
- De responsiviteit van de viewer is verbeterd.
- Verbetering bij het meegeven van parameters tijdens het opstarten van het installatiebestand (bv locatie voor de installatie) (id 5529). Zie de [documentatie op GitHub](Kadaster%20KLIC-viewer/Kadaster%20KLIC-viewer%20installatie%20opties.md) voor een beschrijving van de opties.
- Diverse bugfixes.


**Terugmeldvoorziening**:
- Vervolg pilot voor het automatiseren van deel 1 (melden afwijkende ligging)
  - betreft melden van onbekend net, melden niet gevonden net en melden afwijkende ligging.
  - de pilot zal met ketenpartners worden georganiseerd.
  - er wordt gebruik gemaakt van het generieke terugmeldsysteem van het Kadaster. Voor meer informatie zie [de website van Geoforum](https://geoforum.nl/t/terugmelding-api-beschikbaar-in-acceptatie-omgeving/2251).

--------------------------------------------------------------------------------------
## Planning voor release - 16 november 2020

**Nieuwe KLIC-standaarden**:
- Oplevering van de nieuwe KLIC-standaarden.  \
  De nieuwe versies van de standaarden lagen in juli en augustus 2020 in consultatie, in oktober zijn deze als release candidate gepubliceerd en nu is de versie ter vaststelling uitgebracht.  Het Kadaster stelt samen met het KLIC gebruikersoverleg een planning op voor de implementatie.  \
  Zie [dit nieuwsbericht](https://www.kadaster.nl/-/nieuwe-versie-informatiestandaarden-beschikbaar?redirect=%2Fzakelijk%2Fregistraties%2Flandelijke-voorzieningen%2Fklic%2Fklic-nieuws).

--------------------------------------------------------------------------------------
## Planning voor release - 11 november 2020

**Performance verbetering**:
- De performance van de BMKL-API is verbeterd (id 6086).

--------------------------------------------------------------------------------------
## Planning voor release - NTD: 15 oktober 2020; Productie: 20 oktober 2020
Voor deze release zijn de volgende onderwerpen gepland:

**Leveringsmail (LP.pdf)**:
- Als voorbereiding op de wijziging van begin 2021 om de Gelaagde PDF (LP.pdf) niet meer uit te leveren, komt een vooraankondiging op de Gelaagde PDF (LP.pdf) te staan. 

**Bugfix van teruggedraaide release (oorspronkelijk 27 augustus)**:
- Groepering foutmeldingen bij actualiseren netinformatie
- Schermaanpassingen Actualiseren netinformatie / documenten
- Validatiefout bij aanlevering van netinformatie met een dubbele quote in de gml:id

--------------------------------------------------------------------------------------
##  Bugfix release Informatiepolygoon – 29 september 2020 (12:00 uur)

De bug m.b.t. het aanvragen van een informatiepolygoon is met deze release verholpen. Na het uitrollen van deze release is het weer mogelijk om deze functionaliteit te gebruiken.

--------------------------------------------------------------------------------------
## Planning voor release - 24 september 2020
Voor deze release zijn de volgende onderwerpen gepland:

**Leveringsmail**:
- Als voorbereiding op de wijziging van begin 2021 om de Gelaagde PDF (LP.pdf) niet meer uit te leveren, wordt de tekstuele verwijzing naar deze pdf in de leveringsmail nu al niet meer opgenomen. Het betreft twee zinnen die niet meer opgenomen worden. [Bekijk het voorbeeld](Uitleveren/KLIC%20leveringsmail%20-%20zonder%20verwijzing%20naar%20LP-pdf.pdf) om te zien hoe de leveringsmail er na deze release uit ziet. (ID 5920)

--------------------------------------------------------------------------------------
## Planning voor release - 22 september 2020
Op dringend verzoek van het KLIC gebruikersoverleg (KGO KLIC) is de live-gang van de Informatiepolygoon verplaatst naar medio september 2020.

**Informatiepolygoon**:
- Het wordt mogelijk om een informatiepolygoon op te geven bij een graafmelding en een calamiteitenmelding.
- De wijzigingen zullen ook betrekking hebben op: KLIC-online, Ontvangstbevestiging, Gelaagde pdf, GI.xml LI.pdf.  \
  Hiervoor zijn uitgewerkte voorbeelden van de uitleveringen [gepubliceerd op GitHub](Uitleveren/Voorbeelden%20met%20Informatiepolygoon/).  \
  Zie de [documentatie op GitHub](Wijzigingen/Archief/Informatiepolygoon/) voor een overzicht van de wijzigingen.
- De Kadaster KLIC-viewer is reeds geschikt voor het gebruik van de informatiepolygoon. Hiervoor hoeft u geen speciale update te doen.

--------------------------------------------------------------------------------------
## Planning voor release - 8 september 2020

**Kadaster KLIC-viewer**:
- Ter bevordering van het gebruikersgemak wordt er een markering op de kaart getoond op de plek waar een gebruiker geklikt heeft. (ID 4223)
- In het menu bij de gebiedsinformatie-aanvraag wordt nu indien bekend ook het KvK-nummer van de aanvrager en opdrachtgever getoond. (ID 5010)
- Printen op schaal 1:4000 is toegevoegd. (ID 5619)
- Voor het aan en uit zetten van netbeheerders en kaartlagen in het weergave menu is het nu mogelijk om op de hele regel te klikken, in plaats van alleen op de checkbox. (ID 4645)
- Er komt een knop waarmee in één keer de melding gecentreerd en het standaard zoom niveau wordt getoond op het scherm. (ID 5143)

	In verband met technische wijzigingen aan de KLIC-viewer, wordt vanaf deze oplevering alleen nog maar KLIC-Viewer versie 5.5.8 (gereleased op 25 juni) of hoger ondersteund. Dit geldt alleen voor gebruikers van de Windows desktop versie. Heeft u de MacOS versie van de KLIC-viewer geïnstalleerd dan hoeft u niet te updaten.

--------------------------------------------------------------------------------------
## Planning voor release - NTD: 27 augustus 2020
> Let op: deze release is teruggedraaid per 1 september. Zie [release notes van 1 september 2020](https://github.com/kadaster/klic-win/blob/master/KLIC%20-%20Release%20notes.md#1-september-2020).  \
> Deze release is op 15 oktober op de NTD opnieuw doorgevoerd.

Voor deze release is het volgende onderwerp gepland:

**Groepering foutmeldingen bij actualiseren netinformatie**
- Foutmeldingen van dezelfde categorieën en type worden gegroepeerd. Er worden nu maximaal 50 meldingen per groep weergegeven. Voorheen werden de eerste 1000 foutmeldingen weergegeven onafhankelijk van de categorie en type. Hierdoor krijgt de gebruiker overzichtelijker en mogelijk meer verschillende feedback op de aanlevering (ID 3291).  \
Tevens wordt het hierdoor mogelijk om aanleveringen te doen met meer dan 1000 niet-blokkerende waarschuwingen (ID 5709).

**Actualiseren netinformatie / documenten**:
- De schermen voor het actualiseren van netinformatie en documenten zijn nu meer in lijn gebracht.  \
Bovendien zijn de namen van de kolommen duidelijker gemaakt en is de aanleverdatum als kolom toegevoegd (ID 4517).

**Bugfix**:
- Een aanlevering van netinformatie met een dubbele quote in de gml:id resulteert nu (altijd) in een validatiefout (ID 5630).
  
--------------------------------------------------------------------------------------
## Planning voor release - NTD: 13 augustus 2020; Productie: 18 augustus 2020
Voor deze release zijn de volgende onderwerpen gepland:

**Extra validaties op aangeleverde netinformatie/documenten**:
- Bestandnamen van aangeleverde ZIPs worden nu afgekeurd met een foutmelding als ze niet aan de voorwaarden voldoen. Zie [uitleg over zipbestand-eigenschappen op deze Github pagina](Toepassing%20IMKL/Toelichting%20controles%20netinformatie%20KLIC.md#zipbestand-eigenschappen) (ID 5097).

**Aanleveren netinformatie in NTD**:
- Validatie van [bestaande afspraak](Toepassing%20IMKL/Toelichting%20controles%20netinformatie%20KLIC.md#srsname) toegevoegd op het attribuut `srsName` voor zowel Centrale als Decentrale aanleveringen. De waarde moet `urn:ogc:def:crs:EPSG::28992` of `epsg:28992` zijn. Indien een andere waarde gebruikt wordt, krijgt de gebruiker een waarschuwing. Op termijn wordt de waarschuwing aangepast naar een 'error'-melding waarmee de aangeleverde netinformatie niet meer geaccepteerd wordt. Deze validatie zal voorafgaand aan de overgangsperiode naar de nieuwe versie van het IMKL ook doorgevoerd worden voor aanleveringen op de productie-omgeving (ID 5577).
- Netinformatie wordt afgekeurd als een IMKL-object gekoppeld is aan meerdere netwerken: Een IMKL-object mag maar gekoppeld worden aan één netwerk (ID 5634).

**Centrale uitleveringen**:
- Als er binnen de polygoon van een gebiedsinformatie-aanvraag bij een centrale netbeheerder voor een thema enkel Annotatie en/of Maatvoering aanwezig zijn (en geen "assets"), dan wordt voor dit thema helemaal geen data uitgeleverd (ID 3162).

--------------------------------------------------------------------------------------
## Planning - 10 juli 2020

**Nieuwe KLIC-standaarden**:
- Oplevering van de nieuwe KLIC-standaarden ter review.  \
  Zie de [website van Geonovum](https://www.geonovum.nl/geo-standaarden/informatiemodellen/consultatie-imkl).

--------------------------------------------------------------------------------------
## Planning voor release - NTD: 25 juni 2020; Productie: 30 juni 2020
Voor deze release zijn de volgende onderwerpen gepland:

**Aanleveren netinformatie in NTD**:
- Validatie toegevoegd op de lengte van het attribuut `label` van aangeleverde features voor zowel Centrale als Decentrale aanleveringen. De lengte mag maximaal 40 tekens zijn. Indien dit overschreden wordt, krijgt de gebruiker een waarschuwing. Op termijn wordt de waarschuwing aangepast naar een 'error'-melding waarmee de aangeleverde netinformatie niet meer geaccepteerd wordt. Deze validatie zal voorafgaand aan de overgangsperiode naar de nieuwe versie van het IMKL ook doorgevoerd worden voor aanleveringen op de productie-omgeving. (ID 5478)

**Aanleveren netinformatie**:
- Voor decentrale aanleveringen is er geen beperking meer van 50 MB, echter dit is wel de wenselijke maximale omvang.

**Kadaster KLIC-viewer**:
- Kadaster KLIC-viewer beschikbaar op MacOS. Deze wordt beschikbaar gesteld op [https://zakelijk.kadaster.nl/klic-viewer](https://zakelijk.kadaster.nl/klic-viewer) (ID 5300)
- Nieuws notificatie functionaliteit beschikbaar voor bijvoorbeeld algemene KLIC nieuws en KLIC-viewer nieuws. (ID 5457)
- In de viewer staat nu een extra toelichting over de wettelijke verplichting bij een EisVoorzorgsmaatregel. (ID 5374)

	In verband met technische wijzigingen aan de KLIC-viewer verzoeken wij de gebruikers om voor september up-te-daten naar KLIC-Viewer versie 5.5.8. Dit geldt alleen voor gebruikers van de Windows desktop versie. Met de release van deze versie wordt de vorige versie van de KLIC-viewer nog 10 weken ondersteund. Heeft u de MacOS versie van de KLIC-viewer geïnstalleerd dan hoeft u niet te updaten.

--------------------------------------------------------------------------------------
## Planning voor release - 8 juni 2020
Voor deze release zijn de volgende onderwerpen gepland:

**Bugfix**:
- Het systeem is robuuster gemaakt zodat er niet meer een inconsitent ordernummer in een email verstuurd wordt. (ID 5575, [ID#88](https://github.com/kadaster/klic-win/issues/88))
- In de leveringsmail staat nu alle tekst weer op de juiste plaats. (ID 5576)

--------------------------------------------------------------------------------------
## Planning voor release - 2 juni 2020
Voor deze release zijn de volgende onderwerpen gepland:

**KvK-nummer (Kamer van Koophandel)**:
- In een KLIC-melding wordt het KvK-nummer van de aanvrager zoals bekend bij het Kadaster opgenomen. Het wijzigen van de klantgegevens gaat via een [formulier](https://formulieren.kadaster.nl/wijzigen_klantgegevens). (ID 4942)
- In het geval van een graafmelding kan optioneel het KvK-nummer van de opdrachtgever worden opgeven. 
- Het KvK-nummer wordt indien aanwezig weergegeven in de Ontvangstbevestiging, de GI.xml en de GebiedsinformatieAanvragen API. (ID 4669, ID 4670, ID 4671)
- Hiervoor zijn reeds uitgewerkte voorbeelden van de uitleveringen [gepubliceerd op GitHub](Uitleveren/Archief/Voorbeelden%20met%20KvK-nummer/).

-------------------------------------------------------------------------------------
## Planning voor release - 26 mei 2020
Voor deze release zijn de volgende onderwerpen gepland:

**Actualiseren netinformatie**:
- Validatie toegevoegd in het proces actualiseren Netinformatie voor Centrale netbeheerders: bij de `VoorzorgsmaatregelBeslissingsregel`-s moet een geldige `netbeheerderWerkaanduiding` worden aangegeven. De `netbeheerderWerkaanduiding` is geldig als deze bekend is bij `WerkzaamhedenAanduiding`-en. (ID: 5156)

**Ontvangstbevestiging / Leveringsbrief**: 
- In de Ontvangstbevestiging wordt nu ook de 'geschatte einddatum werkzaamheden' getoond zoals die is opgegeven tijdens de aanvraag. (ID: 5530)
- In de Leveringsbrief staat nu een extra toelichting over de wettelijke verplichting bij een EisVoorzorgsmaatregel. (ID: 5521)

**Beheren belangen**:
- Beheren belangen proces robuuster gemaakt: een belang kan pas beoordeeld worden nadat bij KLIC de technische bewerking van de belangengeometrie is afgerond. (ID: 5316)

**Bugfix NTD**:
- In de NTD moest ten onrechte het soort werkzaamheden worden opgegeven bij een calamiteitenmelding. Dat is nu opgelost. (ID 5419)

-------------------------------------------------------------------------------------
## Planning voor release - 30 april 2020
Voor deze release zijn de volgende onderwerpen gepland:

**Terugmeldvoorziening**:
- Pilot voor het automatiseren van fase 1 ("niet gevonden net") van het proces "Afwijkende situatie" (Terugmeldvoorziening)
  - de pilot zal met ketenpartners worden georganiseerd
  - er wordt gebruik gemaakt van het generieke terugmeldsysteem van het Kadaster. Voor meer informatie zie [de website van Geoforum](https://geoforum.nl/t/terugmelding-api-beschikbaar-in-acceptatie-omgeving/2251).

-------------------------------------------------------------------------------------
## Planning voor release - 28 april 2020
Voor deze release zijn de volgende onderwerpen gepland:

**Informatiepolygoon**:
- De 'KlicB2BBetrokkenBeheerders' response in het geval van een Calamiteitenmelding bij B2B TEST-aanvraag is gereed voor de informatiepolygoon: Er wordt een boolean getoond die aangeeft of een belang alleen betrekking heeft of de informatiepolygoon of ook op het graafgebied. (ID 5372)

**Kadaster KLIC-viewer**  (versie 5.4.3 / 5.4.7):
- Printen: de optie om te printen op schaal 1:400 is toegevoegd
- Helpfunctionaliteit: Er is een help-button toegevoegd op het scherm waarin je een levering kunt selecteren, zodat ook vanuit dit scherm uitleg over de viewer gevonden kan worden.
- Bugfix: Schaalbalk bij printen naar pdf (ID 5443)

**Bugfix**:
- Herstellen controle bij aanleveringen: Voor Curves wordt gecontroleerd dat de segmenten (<gml:LineStringSegment>) aan elkaar vast zitten (beginnen waar het vorige segment eindigt). (ID: 5373)  \
  Voor een overzicht van controles en validaties zie: [deze pagina op github](Toepassing%20IMKL/Toelichting%20controles%20netinformatie%20KLIC.md)

--------------------------------------------------------------------------------------
## Planning voor release - 10 april 2020
Voor deze release zijn de volgende onderwerpen gepland:

**Publicatie op Github**:
- Publicatie extra voorbeeldbestanden met informatiepolygoon.  \
  zie [deze link op GitHub](Uitleveren/Voorbeelden%20met%20Informatiepolygoon/) voor de voorbeelden.

--------------------------------------------------------------------------------------
## Planning voor release - 23 maart 2020
Voor deze release zijn de volgende onderwerpen gepland:

**Informatiepolygoon in NTD**:
- In de NTD wordt het mogelijk om een informatiepolygoon op te geven bij een graafmelding en een calamiteitenmelding.
- De informatiepolygoon is zichtbaar in de BMKL-API. (GebiedsInformatieAanvraag, BeheerdersinformatieLevering e.d.)  \
  Hiervoor zijn uitgewerkte voorbeelden van de uitleveringen [gepubliceerd op GitHub](Uitleveren/Voorbeelden%20met%20Informatiepolygoon/).  \
  Zie de [documentatie op GitHub](Wijzigingen/Archief/Informatiepolygoon/) voor een overzicht van de wijzigingen  \
  De aanpassingen worden eerst in NTD beschikbaar gesteld en na minimaal 6 weken in de reguliere omgeving. In de reguliere omgeving wordt naast bovengenoemde ook de Ontvangstbevestiging aangepast.

--------------------------------------------------------------------------------------
## Planning voor release - 17 maart 2020
Voor deze release zijn de volgende onderwerpen gepland:

**eHerkenning**:
- Per 17 maart aanstaande bieden wij naast de reguliere inlogmogelijkheid op Mijn Kadaster, ook eHerkenning aan als inlog voor Mijn Kadaster.
Communicatie over eHerkenning zal via de reguliere kanalen verlopen.

**Calamiteitenmelding**:
- Als een calamiteitenmelding na de 2e uitlevering (45 minuten) compleet wordt, zal er direct een complete levering uitgeleverd worden.


--------------------------------------------------------------------------------------
## Planning voor release - 2 maart 2020
Voor deze release zijn de volgende onderwerpen gepland:

**Kadaster KLIC-viewer (versie 5.3.1)**:
- In de Kadaster KLIC-viewer worden en aantal functionele verbeteringen doorgevoerd. Onder andere:
  - Het is mogelijk in menu Weergave om de BGT kaartachtergrond uit te schakelen.
  - In het Feature informatie resultaten schertm is een kleurcode geralateerd aan het thema zichtbaar.
  - Betere toelichting over aantal EV aanduidingen per netbeheerder.
  - Het installatiepakker voor Windows is veel kleiner qua MB.
  - De gebruiker kan tijdens zelf bepalen in welke map/netwerkschijf de viewer wordt geïnstalleerd in het geval van het installeren in Windows.
  - Bij het openen van een levering is het nu mogelijk met om de leveringslink te plakken via een menu als gedrukt wordt op de rechtermuisknop.
  - Het KLIC-meldnummer is zichtbaar in de menubalk.
  - In het print-menu kun je ook kiezen voor A1 en A2 (staand/liggend)
  - In het print-menu kun je ook kiezen voor schaal 1:200
  - Het print-menu opent nu standaard in het bladindeling scherm
  - Bugfix: In de Windows versie werden EV en Extra Geometrie toggles meer dan 1 keer getoond. 
  - Bugfix: Betere afhandeling 502 foutmelding
  - Bugfix: Bij het opslaan/downloaden van een PDF staat de extentie van het bestand nu standaard ingesteld.
- Mogelijkheid voor de netbeheerders om uitgepakte beheerdersinformatieleveringen (BIL) te bekijken in de Windows versie van de viewer.  

--------------------------------------------------------------------------------------
## Planning voor release - 1 maart 2020
De inhoud van deze release is afhankelijk van het einde van de overgangsperiode.  \
Zie de berichtgeving van Agentschap Telecom op: [https://www.agentschaptelecom.nl/onderwerpen/kabels-en-leidingen/documenten/publicaties/2019/05/29/gebiedsinformatie-en-viewers](https://www.agentschaptelecom.nl/onderwerpen/kabels-en-leidingen/documenten/publicaties/2019/05/29/gebiedsinformatie-en-viewers)


**Uitlevering zipbestand**:
- Het zipbestand met de KLIC-uitlevering wordt aangepast in productie (ID 3849):
  - in het zipbestand worden de PNG-bestanden van netbeheerders (rasterbestanden voor ligging, maatvoering, annotatie en eigenTopo) niet meer uitgeleverd in productie.
  - Hiervoor zijn reeds uitgewerkte voorbeelden van de uitleveringen [gepubliceerd op GitHub](Uitleveren/Archief/Voorbeelden%20levering%20v2.2/).

**Het BIL zipbestand**:
- Het zipbestand met de BeheerdersinformatieLevering van een specifieke netbeheerder wordt in productie aangepast in lijn met de wijzigingen in de KLIC-uitlevering.
  - Hiervoor zijn reeds uitgewerkte voorbeelden van de uitleveringen [gepubliceerd op GitHub](Uitleveren/Archief/Voorbeelden%20levering%20v2.2/).

--------------------------------------------------------------------------------------
## Planning voor release - 2 februari 2020
Voor deze release zijn de volgende onderwerpen gepland:

**Ontvangstbevestiging**:
- Er zijn visuele aanpassingen in de Ontvangstbevestiging ter voorbereiding op toekomstige wijzigingen. (ID 5051)

**Bugfix**:
- Er konden dubbele vermeldingen naar bestanden in de LI.xml voorkomen. Dit is opgelost. (ID 5065, [ID#67](https://github.com/kadaster/klic-win/issues/67))

--------------------------------------------------------------------------------------
## Planning voor release - 20 januari 2020
Voor deze release zijn de volgende onderwerpen gepland:

**Leveringsemail**:
- De inhoud van de leveringsemail wordt aangepast. (ID 3897)
- Hiervoor is een voorbeeld [beschikbaar op GitHub](/Uitleveren/Archief/Voorbeeld%20vernieuwde%20leveringsemail%20(verwacht%20december%202019).pdf).

**Nieuwe Kadaster KLIC-viewer**:
- Oplevering van nieuwe Kadaster KLIC-viewer op basis van een uitlevering 
  - met alleen vectorinformatie (GI.xml) en PDF-bestanden (bijlagen) van netbeheerders (zónder PNG-bestanden voor ligging, maatvoering, annotatie en eigenTopo van netbeheerders)
  - met een BGT-achtergrondkaart in PNG-formaat
  - met geselecteerd gebied in vectorinformatie (in _GebiedsinformatieLevering_, GI.xml)
- Hiervoor zijn uitgewerkte voorbeelden van de uitleveringen [beschikbaar op GitHub](/Kadaster%20KLIC-viewer/).

Zie ook de berichtgeving van Agentschap Telecom op: [https://www.agentschaptelecom.nl/onderwerpen/kabels-en-leidingen/documenten/publicaties/2019/05/29/gebiedsinformatie-en-viewers](https://www.agentschaptelecom.nl/onderwerpen/kabels-en-leidingen/documenten/publicaties/2019/05/29/gebiedsinformatie-en-viewers)

--------------------------------------------------------------------------------------
## Planning voor release - 9 januari 2020 (NTD)
Voor deze release zijn de volgende onderwerpen gepland:

**BIL zip-bestand in versie 2.2**:
- Ter voorbereiding op de afloop van de overgangsperiode (1 maart 2020), wordt in de NTD het BIL zip-bestand in versie 2.2 uitgeleverd. (ID 4232). 
  - in het zipbestand worden de PNG-bestanden van netbeheerders (rasterbestanden voor ligging, maatvoering, annotatie en eigenTopo) niet meer uitgeleverd in productie.
  - Hiervoor zijn reeds uitgewerkte voorbeelden van de uitleveringen [gepubliceerd op GitHub](Uitleveren/Archief/Voorbeelden%20levering%20v2.2/).

**KvK-nummer (Kamer van Koophandel)**:
- Het wordt in de NTD mogelijk om een KvK-nummer van de aanvrager en het KvK-nummer van de opdrachtgever (in geval van graafmelding) op te geven. (ID 4981)
- Het KvK-nummer wordt indien aanwezig weergegeven in de GI.xml en de GebiedsinformatieAanvragen API. (ID 4670, ID 4671)
- De aanpassingen worden eerst in NTD beschikbaar gesteld en na 6 weken in de reguliere omgeving. In de reguliere omgeving wordt naast bovengenoemde ook de Ontvangstbevestiging aangepast. (ID 5006, ID 5007, ID 4669)
- Hiervoor zijn uitgewerkte voorbeelden van de uitleveringen [gepubliceerd op GitHub](Uitleveren/Archief/Voorbeelden%20met%20KvK-nummer/).

--------------------------------------------------------------------------------------
## Planning voor release - 29 oktober 2019
Voor deze release is het volgende onderwerp gepland:

**NTD**:
- In de NTD is het niet meer mogelijk om een klassieke testmelding (BMKL 1.2) te doen. (ID 4418)

--------------------------------------------------------------------------------------
## Planning voor release - 7 oktober 2019
Voor deze release zijn de volgende onderwerpen gepland:

**Bug-fixes / Performance**:
- Centrale netbeheerders kunnen een BMKL-alert krijgen, ook als er niet gepatched is. (ID 4531)
- Performanceverbetering voor de Serviceprovider bij het ophalen van de lijst waarvoor de Serviceprovider geautoriseerd is (bijvoorbeeld Belangenbeheer). (ID 3605)
- Achtergrondkaart bij het controleren van netinformatie (actualiseren) is hersteld. (ID 4809)

**Publicatie op Github**:
- Update van de BETA-versie van de Kadaster KLIC-viewer (Online en Windows).  \
  Zie [deze link op GitHub](/Kadaster%20KLIC-viewer/).

--------------------------------------------------------------------------------------
## Planning voor release - 28 augustus 2019
Voor deze release zijn de volgende onderwerpen gepland:

**Publicatie op Github**:
- Publicatie voorbeeldbestanden nieuwe uitlevering, inclusief bijbehorende BeheerdersinformatieLeveringen. (ID 3849)  \
  zie [deze link op GitHub](Uitleveren/Archief/Voorbeelden%20levering%20v2.2/) voor voorbeelden van uitleveringen in versie 2.2.
- Update van de BETA-versie van de Kadaster KLIC-viewer (Online en Windows).  \
  Zie [deze link op GitHub](/Kadaster%20KLIC-viewer/).

--------------------------------------------------------------------------------------
## Planning voor release - 26 augustus 2019
Voor deze release zijn de volgende onderwerpen gepland:

**Bug-fix**:
- Extra validaties toegevoegd om beter om te gaan met dubbele of te late netbeheerder levering (Centrale Netbeheerders) of het te laat ophalen van het BIL zip-bestand. (ID 4641, ID 4449)

--------------------------------------------------------------------------------------
## Planning voor NTD onderhoud - 25 juli 2019


**Onderhoud KLIC Netbeheerder Testdienst**:
- Onbeschikbaarheid NTD verwacht van 10.00 tot 12.00.
- Alle test data wordt gewist  \
  Zie de [storingen en onderhoud website van het Kadaster](https://zakelijk.kadaster.nl/-/onderhoud-klic-netbeheerder-testdienst-nt-1) voor meer details.

--------------------------------------------------------------------------------------
## Planning voor release - 11 juli 2019
Voor deze release zijn de volgende onderwerpen gepland:

**Publicatie op Github**:
- Er is een voorbeeld gepubliceerd van de leveringsemail zoals die er per september uit komt te zien.  \
  Zie [deze link op GitHub](/Uitleveren/Archief/Voorbeeld%20vernieuwde%20leveringsemail%20(verwacht%20december%202019).pdf).

--------------------------------------------------------------------------------------
## Planning voor release - 2 juli 2019
Voor deze release zijn de volgende onderwerpen gepland:

**Publicatie op Github**:
- Er komt een update van de BETA-versie beschikbaar van de online Kadaster KLIC-viewer. 
  Zie [deze link op GitHub](/Kadaster%20KLIC-viewer/).

**Bug-fix**:
- Er traden problemen op bij zoeken en verwijderen van belangen met een apostrof in de omschrijving. Deze zijn verholpen. (ID 4042)

**De autorisatie  methode wordt geüpdatet**:
- Het inlog scherm zier er anders uit. Na het opgeven van je wachtwoord, verschijnt een scherm om de autorisatie te bevestigen. Hierop staan de scopes die je hebt aangevraagd en waarvoor je autorisatie hebt.
- Bij het ophalen van een token via `grant_type= authorization_code` en `grant_type= refresh_token`:
  - Als de gebruiker doorgestuurd is naar de  redirect_uri dan worden de scopes waarvoor een gebruiker geautoriseerd is alleen nog maar teruggegeven in de body van de response; en niet meer in de URL parameters 
- Bij het ophalen van een token via `grant_type=password`:
  - De parameters `username`, `password`, `client_id`, `client_secret`, `grant_type` en `scope` kunnen niet meer opgegeven worden in de URL parameters, maar alleen nog maar in de body.

- Sommige responses voor foutsituaties zijn gewijzigd:

|Foutsituatie                                                                |Tot 2 juli 2019                                                                                                                                                                                                                |Vanaf 2 juli 2019                                                                                                                                                         |
|--------------------------------------------------------------------------- |-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
|Ophalen van token waarbij er 1 niet bestaande scope is meegegeven           |HTTP 403 <br> `{`<br> `error: "invalid request",`<br> `error_description: "The requested SCOPE is not valid"`<br> `}`                                                                                                          |HTTP 400 <br> `{`<br> `error: "invalid_scope",`<br> `error_description: "No registered scope value for this client has been requested"`<br> `}`                           |
|Ophalen van token waarbij er meerdere niet bestaande scopes zijn meegegeven |HTTP 200 <br> `{`<br> `access_token: " eb7929c4-4259-442c-931f-14fba228a6aa",`<br> `token_type: "Bearer",` <br> `expires_in: 3600,`<br> `refresh_token: " 29786b93-24ca-4e91-9c8c-b87715f48ba9",` <br> `scope: "oob"` <br> `}` |HTTP 400 <br> `{`<br> `error: "invalid_scope",`<br> `error_description: "No registered scope value for this client has been requested"`<br> `}`                           |
|Aanroepen API's met een ongeldige token                                     |HTTP 401 <br> `{`<br> `error: "invalid_request",`<br> `error_description: "Validation error"`<br> `}`                                                                                                                          |HTTP 401 <br> `{`<br> `error: "invalid_token",`<br> `error_description: "The access token provided is expired, revoked, malformed, or invalid for other reasons"`<br> `}` |
|Aanroepen API's met een verlopen token                                      |HTTP 400 <br> `{`<br> `error: "Token retrieval error",`<br> `error_description: "The requested token could not be retrieved"`<br> `}`                                                                                          |HTTP 401 <br> `{`<br> `error: "invalid_token",`<br> `error_description: "The access token provided is expired, revoked, malformed, or invalid for other reasons"`<br> `}` |
|Ophalen token met een verkeerd userid en/of password.                       |HTTP 400 <br> `{`<br> `error: "invalid_grant",`<br> `error_description: "Resource Owner authentication failed"`<br> `}`                                                                                                        |HTTP 401 <br> `{`<br> `error: "invalid_request",`<br> `error_description: "The resource owner could not be authenticated due to missing or invalid credentials"`<br> `}`  |

Zie [deze link op GitHub](API%20management/Authenticatie_via_oauth.md) voor een beschrijving van de Authenticatie via OAuth voor de KLIC API's. 


--------------------------------------------------------------------------------------
## Planning voor release - NTD: 20 juni 2019; Productie: 24 juni 2019
Voor deze release zijn de volgende onderwerpen gepland:

**Uitlevering zipbestand**:
- Spaties in bestandsnamen van bijlagen in de uitlevering worden vanaf nu vervangen door een '+' teken, waardoor deze ook in de KLIC-viewer te openen zijn. (ID 4247)

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
  zie [deze link op GitHub](Uitleveren/Archief/Voorbeelden%20levering%20v2.2/) voor voorbeelden van uitleveringen in versie 2.2.



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
- Bij het opvoeren van een graafmelding of oriëntatieverzoek moet er altijd minimaal één soort werkzaamheden worden opgegeven. Tevens is het geven van een toelichting van de werkzaamheden alleen mogelijk als er minimaal één soort werkzaamheden is opgegeven. Dit geldt voor aanvragen via de web applicatie KLIC-online en aanvragen via een B2B aanvraag-kanaal. (ID 2533)

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
- Wanneer je het BIL zip-bestand ophaalt middels de API, kijgt het bestand een naam die is opgebouwd uit "BeheerdersinformatieLevering", het KLIC-meldnummer en de bronhoudercode. Bijvoorbeeld: `BeheerdersinformatieLevering_19G003456_kl4141.zip`. (ID 3448)
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
- KLIC-online (bij het doen van een graafmelding, oriëntatieverzoek en calamiteitenmelding);</br>
  Als achtergrondkaart wordt hier de visualisatie van "BGT omtrekgericht" gebruikt. (ID 2161)
- In de KLIC-ontvangstbevestiging;</br>
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