# Terugmelden Afwijkende Situatie

In overleg met het KLIC Gebruikersoverleg (KGO KLIC) start KLIC de vernieuwing van het proces 'Terugmelden Afwijkende Situatie'. Doel is het vereenvoudigen van het melden en afhandelen van afwijkingen op liggingsgegevens van netinformatie. Er wordt een REST API ontworpen en ontwikkeld voor het proces. 

## Toelichting proces 
- Het vernieuwde proces is vergelijkbaar met het huidige proces van terugmelden.
- Zie [https://zakelijk.kadaster.nl/melden-afwijkende-situatie-professionele-graver](https://zakelijk.kadaster.nl/melden-afwijkende-situatie-professionele-graver) voor een uitleg.
- Het vernieuwde proces maakt gebruik van de reeds bestaande mogelijkheden voor terugmelden binnen het Kadaster (bv voor BAG terugmeldingen).  \
Bij terugmeldingen binnen het Kadaster is over het algemeen de brondhouder bekend (meestal de gemeente). Bij KLIC is de bronhouder echter niet (altijd) bekend: *Er is sprake van een ‘claim-proces’*. Dit claim-proces bestaat reeds in het huidige terugmeldproces en wordt in het vernieuwede proces gefaciliteerd via een API.



## Toelichting melden afwijking met REST API (grondroerder proces)
- De REST API die ontwikkeld wordt sluit aan op reeds bestaande mogelijkheden voor terugmelden binnen het Kadaster. 
  - Zie [https://www.pdok.nl/restful-api/-/article/terugmeldingen-1#](https://www.pdok.nl/restful-api/-/article/terugmeldingen-1#) voor een uitleg.
- Zie het onderdeel "[Terugmelden Afwijkende Situatie](../../Terugmelden%20Afwijkende%20Situatie)" op deze Github voor de toelichting wat de specifieke kenmerken voor KLIC zijn.

## Toelichting claimen/afwijzen van terugmeldingen (netbeheerder proces)
- Het claim-proces wordt vanuit de BMKL-API ondersteund. 
- Zie het onderdeel "[BMKL](../../BMKL/BMKL%202.1/BMKL%202.1%20(B2B-koppeling%20beheerdersinformatie).md)" op deze Github voor de toelichting.
- Het datamodel sluit aan bij de GebiedinformatieAanvragen (GIA) en BeheerdersinformatieAanvragen (BIA): één terugmelding-object kan gekoppeld zijn aan een of meerdere BeheerderTerugmelding-objecten.
- Analoog aan de GIA/BIA dient de netbeheerder eerst zijn BeheerderTerugmeldingen op te halen, om met de id's uit dat bericht de informatie van de terugmeldingen op te halen.
- Het terugmeld-bericht is een extentie op de algemene terugmeldingen faciliteit binnen het Kadaster, waardoor niet alle velden voor een nebeheerder relevant zijn voor het afhandelen van de terugmelding.
- Een netbeheerder dient de terugmeldingsdetails over de kabel/leiding te analyseren (ook de bijlagen) of het een terugmelding op diens netwerk betreft en daarna middels een PATCH de melding te claimen of af te wijzen. Voor het analyseren of de terugmelding betrekking heeft op je netwerk is de status van het terugmeld-object niet relevant: immers in het huidige proces kan het ook voorkomen dat twee netbeheerders aangeven dat het hun netwerk betreft.
- Zie ook [deze presentatie](Terugmeldproces.pdf)

## Fasering
- De vernieuwing zal gefaseerd ontworpen, ontwikkeld en geïmplementeerd worden. Dit zal in overleg met het KLIC Gebruikersoverleg plaatsvinden. 
- In januari 2023 start de overgangsfase van 6 maanden. In overleg met het KLIC Gebruikersoverleg is gekozen voor een periode van zes maanden.
- Wijzigingen vanaf de start van de overgangsfase (10 januari):
  - De mail notificatie is aangepast. Een netbeheerder wordt genotificeerd dat er voor de netbeheerder een Afwijkende Situatie is gemeld.
  - In de mail notificatie worden geen bijlagen meer opgenomen met de Afwijkende Situatie stukken. 
  - Door deze mail notificatie wordt de netbeheerder op de hoogste gesteld van een Afwijkende Situatie.  \
  De netbeheerder kan met behulp van de REST API alle gegevens inzien en de Afwijkende Situatie melding afhandelen.  \
  De netbeheerder kan ook met behulp de Kadaster applicatie in Mijn Kadaster, “KLIC beheren terugmelding netbeheerder”, alle gegevens inzien en bijlagen downloaden om de Afwijkende Situatie melding af te handelen.  \
  Deze applicatie van het Kadaster zal vanaf 10 januari 2023 beschikbaar gesteld worden. 
- Volg de [Geplande Werkzaamheden pagina van deze Github](../../KLIC%20-%20Geplande%20werkzaamheden.md) voor updates over de planning. 

## Presentaties
- [Presentatie 2019 3 april - Generieke API en KLIC API Afwijkende Situatie](2019%203%20april%20-%20Generieke%20API%20en%20KLIC%20API%20Afwijkende%20Situatie.pdf)
- [Presentatie 2019 3 april - KLIC API voor afwijkende situatie Pilot](2019%203%20april%20-%20KLIC%20API%20voor%20afwijkende%20situatie%20Pilot.pdf)
- [Presentatie 2019 12 juni - KLIC API voor afwijkende situatie Samenvatting Proces en Pilot bijeenkomst](2019%2012%20juni%20-%20KLIC%20API%20voor%20afwijkende%20situatie%20Samenvatting%20Proces%20en%20Pilot%20bijeenkomst.pdf)
- [Presentatie 2019 12 juni - Terugmelding Bronhouder API KLIC](2019%2012%20juni%20-%20Terugmelding%20Bronhouder%20API%20KLIC.pdf)
- [Presentatie 2022 9 december - Netbeheerder Afwijkende Situatie vanaf 10 jan 2023](2022%209%20december%20-%20Netbeheerder%20Afw.%20Sit.%202023.pdf)

## Deelnemen Pilot melden Afwijkende Situatie
-  U kunt een email sturen naar klic@kadaster.nl indien u wilt deelnemen aan de pilot van het melden van een afwijking.

