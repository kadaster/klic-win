# Netbeheerder Testdienst (NTD)

Dit document geeft een handleiding voor het gebruik van portaalfuncties van de Netbeheerder Testdienst (NTD).

**Inhoudsopgave**

  - [Context](#context)
  - [Documentatie over gebruik BMKL API's](#documentatie-over-gebruik-bmkl-apis)
      - [REST interfaces](#rest-interfaces)
	  - [KLIC API Documentatie](#klic-api-documentatie)
         - [API Testfaciliteit](#api-testfaciliteit)
         - [API Specificatie document](#api-specificatie-document)
	  - [Swagger UI](#swagger-ui)
	  - [OAuth token meegeven](#oauth-token-meegeven)
  - [Opvoeren testmelding](#opvoeren-testmelding)
	  - [Mijn Kadaster](#mijn-kadaster)
	  - [KLIC Netbeheerder Testdienst portaal](#klic-netbeheerder-testdienst-portaal)
	  - [Opvoeren testmelding - 1 van 5](#opvoeren-testmelding---1-van-5)
	  - [Opvoeren testmelding - 2 van 5](#opvoeren-testmelding---2-van-5)
	  - [Opvoeren testmelding - 3 van 5](#opvoeren-testmelding---3-van-5)
	  - [Opvoeren testmelding - 4 van 5](#opvoeren-testmelding---4-van-5)
	  - [Opvoeren testmelding - 5 van 5](#opvoeren-testmelding---5-van-5)

---------------------------------------------------------
## Context
De netbeheerder heeft een wezenlijke rol bij het samenstellen van gebiedsinformatie op basis van een gebiedsinformatie-aanvraag.

Als een netbeheerder belanghebbend is bij een aanvraag, zal deze beheerdersinformatie voor deze aanvraag moeten aanleveren.
Bij een decentrale netbeheerder zal dit per aanvraag afgehandeld moeten worden, bij een centrale netbeheerder verzameld KLIC deze beheerdersinformatie namens de netbeheerder uit de centrale voorziening van KLIC.
De centrale netbeheerder heeft daarvoor reeds eerder alle netinformatie, eventueel aangevuld met bijbehorende documenten en voorzorgsmaatregelen, geactualiseerd in de centrale voorziening.

Zowel de centrale, als de decentrale netbeheerder zullen behoefte hebben om het proces van aanleveren en uitleveren van beheerdersinformatie nauwlettend te volgen. \
Daarvoor is een koppelvlak tussen KLIC en netbeheerders ontworpen, geimplementeerd door REST-API's. Het koppelvlak met berichtuitwisseling wordt kortweg BMKL genoemd (vanaf Januari 2022 is dat BMKL  versie 2.1).

Voor de netbeheerder is een platform ontwikkeld, waarmee de netbeheerder dit koppelvlak kan testen: de Netbeheerder Testdienst (NTD). \
De NTD heeft tevens een online-portaal. Hiermee kunnen testmeldingen worden aangemaakt, waarvoor de netbeheerder belanghebbend is. De netbeheerder kan vervolgens voor deze melding de berichtuitwisseling met betrekking tot het afhandelen van beheerdersinformatie testen.

Dit document beschrijft de functionaliteit die in het portaal van de Netbeheerder Testdienst worden aangeboden.
De werking van het koppelvlak en de BMKL API's wordt in andere documentatie beschreven.

---------------------------------------------------------
## Documentatie over gebruik BMKL API's

### REST interfaces
Voor het geautomatiseerd afhandelen van berichten tussen KLIC en netbeheerder heeft het Kadaster REST interfaces beschikbaar gesteld. \
De documentatie over de werking van deze interfaces is beschikbaar in de vorm van [Swagger](http://swagger.io) specificatie. Deze documentatie is te vinden bij de “KLIC API Documentatie”-applicatie.

De applicatie biedt een overzicht van de endpoints van de verschillende API’s en hoe deze endpoints gebruikt kunnen worden. \
De API's zijn onderverdeeld naar
- "aanleveringen"
- "uploaden" en
- “beheerdersinformatie”
en de meeste endpoints zijn uit te proberen via de aangeboden interface.

### KLIC API Documentatie

De API Documentatie is beschikbaar via een Swagger-implementatie. Deze is te bereiken via een link het KLIC Netbeheerder Testdienst portaal.

![mijnKadaster](bijlagen/NTD-Portaal-BMKL-API-Documentatie.png "NTD Portaal - API Documentatie")

_Figuur 1 KLIC API documentatie_

Het klikken van de link brengt u naar de overzichtspagina van de API Documentatie.
Voor de verschillende onderdelen vindt u een link naar:

#### API Testfaciliteit ####

Een hulpmiddel om op basis van de API specificatie eenvoudig de beschikbare services uit te proberen.

#### API Specificatie document ####

Een beschrijving van de API volgens de OpenAPI specificatie in YAML (JSON) formaat. Dit biedt de softwareontwikkelaar een duidelijke beschrijving van de interface ten behoeve van integratie in eigen software.

![mijnKadaster](bijlagen/KLIC-API-documentatie-BMKL.png "NTD Portaal - API Documentatie")

_Figuur 2 API Testfaciliteit en API Specificatie document_

De "API Testfaciliteit" link brengt u naar een Swagger pagina waar alle services beschreven zijn.

### Swagger UI ###

De link 'API Testfaciliteit' brengt u naar een overzicht van alle endpoints die in dit document beschreven zijn.
De applicatie biedt een overzicht van de endpoints van de verschillende API’s en hoe deze endpoints gebruikt kunnen worden.
Al deze endpoints zijn meteen uit te proberen via de aangeboden interface. Met uitzondering van het downloaden van de aangeleverde beheerdersinformatie, deze zal via een browser of via CURL moeten worden uitgevoerd aangezien Swagger ZIP responses niet ondersteunt.

### OAuth token meegeven ###

Net als in alle beschreven curl-commando's moet een OAuth-token als Authorization header meegegeven worden. In curl gaat dat via een parameter,
de Swagger-UI is een webapplicatie dus de browser moet verteld worden de header mee te geven. In Chrome kan dat door een extensie te installeren: [ModHeader](https://chrome.google.com/webstore/detail/modheader/idgpnmonknjnojddfkpgkljpfnnfcklj?hl=nl).
Wanneer de extensie geïnstalleerd is, is naast de adresbalk een icoon toegevoegd. Hierop klikken geeft onderstaand invulformulier:

![ModHeader](bijlagen/ModHeader-OAuth.png "ModHeader invulformulier voor OAuth")

_Figuur 3 ModHeader en Oauth_

Vul bij `Request Headers` "Authorization" in en als waarde "Bearer" plus het OAuth token (net als bij de curl-commandos).
Optioneel kan een filter toegevoegd worden. Een filter zorgt ervoor dat de Authorization-token alleen voor bepaalde URLs wordt meegegeven.
Dit is sterk aan te raden omdat anders andere diensten die gebruik maken van OAuth (Google-diensten bijvoorbeeld) niet meer correct zullen werken.
Om een filter toe te voegen klik op `+` en kies Filter. Selecteer `URL Pattern` en vul een patroon in dat uniek is voor de B2B-koppeling,
bijvoorbeeld "*/gebiedsinformatieAanvragen*". (dit betekent dat ieder URL waarin "/gebiedsinformatieAanvragen" voorkomt de Authorization-header meegestuurd krijgt)

Zonder Authorization-header zal iedere API aanroep (in de swagger klikken op `Try it out!`) leiden tot een HTML-pagina met de melding: "Kadaster - Niet geauthenticeerd".


---------------------------------------------------------
## Opvoeren testmelding

Om het afhandelen van een gebiedsinformatie-aanvraag te kunnen testen, biedt de NTD de mogelijkheid om een testmelding op te voeren.

### Mijn Kadaster
Na het inloggen in Mijn Kadaster kiest u via het menu voor "Klic Netbeheerder Testdienst".

:information_source: Hiervoor dient u geautoriseerd te zijn.

![mijnKadaster](bijlagen/mijn-kadaster-ntd.png "Mijn Kadaster - Klic Netbeheerder TestDienst")

_Figuur 4 Mijn Kadaster - Klic Netbeheerder Testdienst_

### KLIC Netbeheerder Testdienst portaal

Vervolgens opent zich het "Klic Netbeheerder Testdienst" portaalscherm met hierop alle opties die binnen de NTD beschikbaar worden gesteld,
mits u hiervoor geautoriseerd bent. Op dit portaalscherm vindt u de links waar u een testmelding kunt opvoeren:

- "Opvoeren testmelding - centraal " waar u als centrale netbeheerder een testmelding kunt opvoeren
- "Opvoeren testmelding - decentraal " waar u als decentrale netbeheerder een testmelding kunt opvoeren

![mijnKadaster](bijlagen/NTD-Portaal-BMKL-Testmelding.png "NTD Portaal - Testmelding")

_Figuur 5 Optie voor opvoeren testmelding_

### Opvoeren testmelding - 1 van 5

Nadat u de link "Opvoeren testmelding - centraal" of "Opvoeren testmelding - decentraal" heeft aangeklikt opent zich het 1e scherm van het opvoeren van een testmelding.

![mijnKadaster](bijlagen/NTD-Testmelding-1.png "NTD Portaal - Testmelding opvoeren 1")

_Figuur 6 Opvoeren testmelding - scherm 1_

U maakt de keuze, of u een testcase uitvoert voor een Graafmelding, Orientatieverzoek of Calamiteitenmelding.  \
 In dit voorbeeld wordt uitgegaan van een Graafmelding.

In dit scherm kunnen de volgende gegevens worden ingevoerd:
- _Endpoint:_ dit betreft het adres van uw eigen webservice waarop u een notificatie wilt ontvangen als er een gebiedsinformatie-aanvraag voor u als belanghebbende klaarstaat. (Dit betreft een verplicht veld.)
- _KvK-nummer:_ Kvk nummer dat wordt gebruikt bij de aanvrager en opdrachtgever
- _Extra naam, Extra e-mailadres, Extra Telefoon:_ Dit betreffen extra contactgegevens voor de aanvraag die in zichtbaar zijn in de API en de levering.
- _Meldingsoort:_ het soort melding; Graafmelding, Calamiteitenmelding of Orientatieverzoek (Dit betreft een verplicht veld.)
- _Uw referentie:_ een referentie van de indiener die zichtbaar is in de API en de levering. (Dit betreft een verplicht veld.)
- _Gebiedspolygoon (WKT):_ de gebiedspolygoon in Well Known Text (WKT) (Dit betreft een verplicht veld bij een graafmelding.)
- _Informatiepolygoon (WKT):_ de informatiepolygoon in Well Known Text (WKT); optioneel op te voeren bij graafmelding en calamiteitenmelding.
- _Genereer Informatiepolygoon op basis van buffer:_ vult het informatiepolygoon veld in Well Known Text met de geselecteerde buffer


Kies daarna "Verder".

### Opvoeren testmelding - 2 van 5

Nadat alle gegevens zijn ingevoerd en op de knop "Verder" is geklikt opent zich het volgende scherm waarin u de aanvangsdatum, verwachte einddatum en graafwerkzaamheden kunt opgeven.

![mijnKadaster](bijlagen/NTD-Testmelding-2.png "NTD Portaal - Testmelding opvoeren 2")

_Figuur 7 Opvoeren testmelding - scherm 2_

### Opvoeren testmelding - 3 van 5

Controleer het gegeven BAG-adres en pas deze, indien nodig, aan. Optioneel kan er een tekstuele verduidelijking van de graaflocatie worden opgegeven bij het veld _Locatieomschrijving_.  

Selecteer Ja of Nee voor het aanvragen van huisaansluitschetsen. Indien gekozen is voor Nee, start de test.

![mijnKadaster](bijlagen/NTD-Testmelding-3.png "NTD Portaal - Testmelding opvoeren 3")

_Figuur 8 Opvoeren testmelding - scherm 3_

Indien gekozen is om huisaansluitschetsen toe te voegen kunt u deze in het volgende scherm aanvragen.

### Opvoeren testmelding - 4 van 5

In dit voorbeeld is gekozen om huisaansluitschetsen toe te voegen. U kunt deze in het volgende scherm aanvragen.

![mijnKadaster](bijlagen/NTD-Testmelding-4.png "NTD Portaal - Testmelding opvoeren 4")

_Figuur 9 Opvoeren testmelding - scherm 4_

Klik nu op de button “Start test”. Dit zorgt er voor dat er een gebiedsinformatie-aanvraag wordt opgevoerd waarmee de testmelding is gedaan.

### Opvoeren testmelding - 5 van 5

Wanneer het bericht succesvol is verzonden, verschijnt onderstaand scherm.

**Let op: vanaf het moment dat het bericht succesvol is verzonden, kan het een paar minuten duren voordat de gebiedsinformatie-aanvraag beschikbaar is.**

![mijnKadaster](bijlagen/NTD-Testmelding-5.png "NTD Portaal - Testmelding opvoeren 5")

_Figuur 10  Opvoeren testmelding - scherm 5_