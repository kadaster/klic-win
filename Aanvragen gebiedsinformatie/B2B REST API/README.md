# B2B-koppeling gebiedsinformatie-aanvraag (KLIC B2B-aanvraag)

Deze technische notitie beschrijft het koppelvlak tussen externe systemen en Kadaster KLIC voor het aanvragen van gebiedsinformatie door middel van een REST-API.

**Inhoudsopgave**


- [1. KLIC B2B-aanvraag](#1-klic-b2b-aanvraag)
  - [1.1 Inleiding](#11-inleiding)
  - [1.2 Gebruik van GUID in bericht](#12-gebruik-van-guid-in-bericht)
  - [1.3 Modelschema en Swagger documentatie](#13-modelschema-en-swagger-documentatie)
    - [1.3.1 Modelschema onderdeel "bestelling"](#131-modelschema-onderdeel-bestelling)
    - [1.3.2 Modelschema onderdeel "testparameters"](#132-modelschema-onderdeel-testparameters)
    - [1.3.3. Modelschema onderdeel "gebiedsinformatie aanvragen"](#133-modelschema-onderdeel-gebiedsinformatie-aanvragen)
    - [1.3.4 Modelschema wijzigingen voor bmkl 3.0](#134-modelschema-wijzigingen-voor-bmkl-30)
  - [1.4 Terugkoppeling door het Kadaster](#14-terugkoppeling-door-het-kadaster)
  - [1.5 Validaties](#15-validaties)
    - [1.5.1 Algemeen](#151-algemeen)
    - [1.5.2 Validaties van de polygonen](#152-validaties-van-de-polygonen)
    - [1.5.3 Aanvragen in het kader van de EU-stimulering breedband (WIBON-regelgeving)](#153-aanvragen-in-het-kader-van-de-eu-stimulering-breedband-wibon-regelgeving)
    - [1.5.4 Veiligheidsgebieden](#154-veiligheidsgebieden)
- [2. Endpoints](#2-endpoints)
- [3. Authenticatie en Autorisatie](#3-authenticatie-en-Autorisatie)
  - [3.1 Overzicht per scenario](#31-overzicht-per-scenario)



---------------------------------------------------------
# 1. KLIC B2B-aanvraag

## 1.1 Inleiding

Via een B2B-koppeling kan door een extern systeem een bericht aan het Kadaster worden aangeboden met daarin een aanvraag voor gebiedsinformatie, kortweg een KLIC B2B-aanvraag.  \
De KLIC B2B-aanvraag ondersteunt daarbij de volgende aanvraagsoorten: een graafmelding, een calamiteitenmelding of een oriëntatieverzoek. Ook is er de mogelijkheid om een collectie (verzameling) van meldingen in één keer op te sturen, als ondersteuning van tracé-functionaliteit.

Nadat een bericht is ontvangen volgt er een response bericht met daarin een poll-URL. Als het bericht bij het Kadaster (a-synchroon) gevalideerd is, volgt op het poll-URL het validatie resultaat en hiermee of de aanvraag in verwerking is genomen of dat de aanvraag is afgekeurd. \
Indien de aanvraag een calamiteitenmelding betreft die in verwerking is genomen, wordt door het Kadaster in het bericht dat beschikbaar is op de poll-URL ook een lijst getoond met de betrokkenBeheerders. In dit bericht wordt teruggekoppeld welke netbeheerders met welke thema's een belang hebben in het aangevraagde gebied.



## 1.2 Gebruik van GUID in bericht


Om een B2B-aanvraag uniek te identificeren moet in het bericht een uniek ID worden toegevoegd onder het kopje `bestelling` bij het veld `postId`.  \
Als er -bijvoorbeeld door een netwerkverstoring- een bericht met hetzelfde ID meermaals door het Kadaster wordt ontvangen, wordt alleen het eerste bericht verwerkt. Hierdoor is het mogelijk zonder dubbele verwerking een 'retry' te versturen als het antwoord op een POST bericht niet ontvangen is.

Het verdient aanbeveling om als unieke MessageID een zogenaamde UUID of GUID te gebruiken:

- Java:	_java.util.UUID.randomUUID().toString();_
- C#:	_System.Guid.NewGuid().ToString("D")_

## 1.3 Modelschema en Swagger documentatie

Het modelschema voor een GIA-POST is gebaseerd op het IMKL en heeft daardoor een grote overeenkomst met de GIA-GET-API (die reeds voor netbeheerders beschikbaar is).

:arrow_forward: [Het modelschema voor de GIA-POST-API is beschikbaar in een Excel bestand](GIA-POST-API_specificatie_v0.89.xlsx).

Er is gekozen voor één modelschema voor alle type aanvragen. Er zijn validatie regels toegevoegd om aan de bestaande business logica te voldoen.
In het werkblad staat in kolom E en F het modelschema inclusief een voorbeeld.  \
Of een bepaalde regel van toepassing is, is afhankelijk van (o.a.) het type melding (graafmelding, calamiteitenmelding, oriëntatieverzoek). Dat staat toegelicht in kolom B/C/D.  \
Kolom H/I/J geeft een toelichting over de vulling van de velden.  \
Kolom L-U geeft de validatie meldingen die voor de betreffende regel van toepassing is. 

Er is Swagger documentatie beschikbaar in de Mijn Kadaster omgeving:  \
:arrow_forward: [Swagger documentatie](https://service10.kadaster.nl/klic/api-docs/?urls.primaryName=B2B%20aanvraag%20api).


### 1.3.1 Modelschema onderdeel "bestelling"

Een POST bericht op de GIA-API dient altijd het onderdeel `bestelling` te hebben. Deze geldt voor het hele bericht. (*concreet: in het geval van meerdere aanvragen in een bericht, geldt het voor alle aanvragen*)

```json
"bestelling": {
  "postId": "string",
  "factuurReferentie": "string",
  "factuurInkoopnummer": "string"
  },
```

- Het `postId` is een uniek ID (zie de inleiding) benodigd voor een robuuste verwerking van het bericht.  \
Als er -bijvoorbeeld door een netwerkverstoring- een bericht met hetzelfde ID meermaals door het Kadaster wordt ontvangen, wordt alleen het eerste bericht verwerkt. Hierdoor is het mogelijk zonder dubbele verwerking een 'retry' te versturen als het antwoord op een POST bericht niet ontvangen is.
- Het `factuurReferentie` of `factuurInkoopnummer` is verplicht voor klanten die bij het Kadaster hebben aangegeven dat ze gebruik willen maken van e-facturatie. In dat geval is minimaal een van de twee verplicht en mag de andere optioneel worden ingevuld. Indien de klant geen gebruik maakt van e-facturatie, zijn beide velden optioneel.

### 1.3.2 Modelschema onderdeel "testparameters"

Een netbeheerder die een test wil doen, kan ook een melding aanbieden via de REST-API. Hiervoor is een eigen endpoint beschikbaar. In het geval van een Netbeheerder test (op de NTD) zijn bepaalde stuurparemters nodig. Deze parameters zijn niet toegestaan voor grondroerder testen of op de productie omgeving. Een melding wordt dan afgekeurd.
  
> N.B. Meldingen worden op dezelfde manier verwerkt als meldingen die via het portaal zijn aangemaakt. Hiermee kan de netbeheerder een (de)centrale aanlevering  simuleren en de BeheerdersinformatieLeverings-zip downloaden

De testParameter velden zijn gedocumenteerd in het Excel bestand die te vinden is in [1.3 Modelschema en Swagger documentatie](#13-modelschema-en-swagger-documentatie).  \
Hieronder staan de velden die alleen voor netbeheerders testen van toepassing zijn ook toegelicht:
```json
"testParameters": {
  "centraleAanlevering": false,
  "belanghebbendeBronhoudercodes": [
    "string"
  ],
  "endpointGiaNotificatie": "string",
  "endpointTerugmeldNotificatie": "string"
},
```

- het veld `centraleAanlevering` dient gebuikt te worden om aan te geven of het een test betreft voor een centrale nebeheerder (`true`) of een decentrale netbeheerder (`false`). Deze keuze is ook op het scherm in het NTD portaal  beschikbaar.
- het veld `belanghebbendeBronhoudercodes` dient gevuld te worden met de bronhoudercode van de netbeheerder voor wie de test is.
- bij het veld `endpointGiaNotificatie`  moet een URL ingevuld worden waarop de netbeheerder een PING ontvangt dat er een GIA beschikbaar is. Dit veld is ook  op het scherm in het NTD portaal  beschikbaar.
- het veld `endpointTerugmeldNotificatie` is nog niet geimplementeerd.


### 1.3.3. Modelschema onderdeel "gebiedsinformatie aanvragen"


Het onderdeel  `gebiedsinformatieAanvragen` is gedefinieerd als een lijst van aanvragen. Naar verwachting zal in de meeste gevallen de lijst maar één aanvraag bevatten. In sommige situaties is het echter wenselijk om meerdere aanvragen in een keer aan te bieden. Dit kan bijvoorbeeld gebruikt worden als een gebruiker een groter gebied wil bevragen dan toegestaan (zoals in KLIC online de tracé melding). De applicatie dient dan een opdeling te maken naar meerdere aanvragen, die met behulp van deze functionaliteit in een keer aangeboden kunnen worden. Mocht er een fout in (minimaal) één van de aanvragen zitten, worden ***alle*** aanvragen (lees: de hele bestelling) afgekeurd.  \
In de terugkoppeling is een JSON-pointer opgenomen, waaruit blijkt in welke melding de validatie error zit.  \
bv: `"jsonPointer": "/gebiedsinformatieAanvragen/1/eindDatum"` In dit geval zit de fout in 'element 1' uit de lijst (aangezien dit 0-based is, betreft het de 2e aanvraag).

**Beperkingen voor het gebruik van meerdere berichten per bestelling**:
- Deze functionaliteit is niet toegestaan bij een calamiteitenmelding.
- De meldingen dienen aan elkaar gerelateerd te zijn.  \
  Dat betekend identieke: `aanvraagSoort`, `aanvrager`, `opdrachtgever`, `referentie`,   `soortWerkzaamheden`, `omschrijvingWerkzaamheden`,  `startDatum`, `eindDatum`.   \
  De locatie gerelateerde velden mogen wel verschillen (`locatieWerkzaamheden`, `locatieOmschrijving`, `huisaansluitingAdressen`, en de polygonen).

 
- Er dient bij elke aanvraag een positienummer toegevoegd te worden die begint bij 10 en oploopt met 10 (dus: 0000000010, 0000000020, etc).
- De meldingen dienen allemaal binnen een vlak van 5000x5000 meter te vallen voor een graafmelding of 10.000x10.000 voor oriëntatieverzoek.
- Er mogen niet meer dan 100 meldingen per bestelling ingediend worden.


### 1.3.4. Modelschema wijzigingen voor BMKL 3.0

| :information_source: Hier staat BMKL versie 3.0 *in concept* beschreven. Dit is de versie die volgt op de huidge BMKL versie 2.1.  <br> Planning over de implementatie van BMKL 3.0 is nog niet bekend. |
|:------|

De aanleiding van het wijzigen van het modelschema is de beoogde upgrade van de KLIC-standaarden.  \
De issues die impact hebben het het `GebiedsInformatieAanvraag`-object, leiden tot een aanpassing in het modelschema van de aanvraag.  \
[Issue #346](https://github.com/Geonovum/imkl2015-review/issues/346) heeft betrekking op de soort werkzaamheden. In BMKL 2.1 was er een lijst van 51 soorten werkzaamhede; dat is nu een lijst van 18 soorten, maar met de verplichting een methode en maximale werkdiepte op te geven.  \
[issue #333](https://github.com/Geonovum/imkl2015-review/issues/333) heeft betrekking op het aantal toegestande tekens voor de klantreferentie. Dat heeft geen invloed op het modelschema van het `GebiedsInformatieAanvraag`-object, maar heeft wel impact op de validatie regels en mogelijk  voor een partij die de API consumeert.


<table style="width:100%">
  <tr>
    <th>BMKL 2.1</th>
    <th>BMKL 3.0</th>

  </tr>
  <tr>
    <td> Fragment gebiedsinformatieAanvragen: 

 ```json
"gebiedsinformatieAanvragen": [
    {
      "giAanvraagId": "string",
     … //
      "voorbereidingMedegebruikFysiekeInfrastructuur": false,

      "soortWerkzaamheden": [
        "string"
      ],





      "omschrijvingWerkzaamheden": "string",
     … //
}
```

</td>
<td> Fragment gebiedsinformatieAanvragen:


 ```json
  "gebiedsinformatieAanvragen": [
    {
      "giAanvraagId": "string",
     … //
      "voorbereidingMedegebruikFysiekeInfrastructuur": false,
      "werkzaamhedenInfo": {
        "soortWerkzaamheden": [
          "string"
        ],
        "methode": [
          "string"
        ],
        "maximaleWerkdiepte": "string",
      },
      "omschrijvingWerkzaamheden": "string",
     … //
}
```
</td>
</tr>
</table>

_Tabel: SoortWerkzaamheden in gebiedsinformatieAanvraag_


| :information_source: Het is nog niet bekend wat de planning is met betrekking tot de implementatie van de Upgrade van de KLIC-standaarden, derhalve beschrijft de rest van deze documentatie de werking volgens het huidige modelschema. <br> Houdt de geplande werkzaamheden pagina in de gaten om te zien vanaf wanneer versie 3.0 verplicht gaat worden.|
|:------|

## 1.4 Terugkoppeling door het Kadaster

Als een POST bericht voldoet aan het modelschema, krijgt de gebruiker een HTTP-202 code terug met het volgende bericht:

```json
{
    "postId": "12345-12345-12345-12345-12345",
    "pollUrl": "http:/[URL nader te communiceren]/[POSTid]/resultaat"
}
```
De daadwerkelijke validatie vindt A-synchroon plaats. Het resultaat is op te halen via de `pollUrl`.  \
*Merk op: De `pollUrl` zal ogenschijnlijk een logische opbouw hebben als combinatie van de URL en het opgegeven `postId`. Echter houdt het Kadaster zich het recht voor het `pollUrl` zonder verdere communicatie aan te passen.  Het is dus strikt noodzakelijk een implementatie te kiezen waarbij de  door het Kadaster terug geven URL gebruikt wordt voor het vervolg proces.*

De terugkoppelingen bij bv onjuiste Autorisatie, onjuist gebruik van modelschema; staan opgenomen in het tabblad 'POST-response messages' van de Excelsheet die te vinden is onder paragraaf [1.3 Modelschema en Swagger documentatie](#13-modelschema-en-swagger-documentatie).

Op het PollUrl kunnen verschillende responses gevonden worden.
- Melding aangenomen, maar nog niet gevalideerd (HTTP-200)
- Melding goedgekeurd (HTTP-200)
- Validatie errors gevonden (HTTP-200)
- Response Betrokken netbeheerder (HTTP-200): In het geval van een calimiteitenmeldig wordt er in dit bericht teruggekoppeld welke netbeheerders met welke thema's een belang hebben in het aangevraagde gebied. 
- Niet gevonden (HTTP-404): De aanvraag is (nog) niet bekend bij het Kadaster

**Validatie waarschuwingen**  \
Naast *validatie fouten* kunnen er ook *validatie waarschuwingen* terug gekoppeld worden. Als er minimaal één fout gevonden is wordt het bericht afgekeurd. Alléén een warning is niet blokkerend voor het aannemen van de order.  \
Voorbeelden van deze berichten en een opsomming van de validatie meldingen zijn te vinden in de Excelsheet die te vinden is onder paragraaf [1.3 Modelschema en Swagger documentatie](#13-modelschema-en-swagger-documentatie).


---------------------------------------------------------
## 1.5 Validaties
### 1.5.1 Algemeen

De controles die worden uitgevoerd op een B2B-aanvraag staan genoemd in de Excelsheet die te vinden is onder paragraaf [1.3 Modelschema en Swagger documentatie](#13-modelschema-en-swagger-documentatie).  \
Elke regel heeft een bepaalde kardinaliteit (verplicht, verboden, optioneel, etc) die afhankelijk kan zijn van het type aanvraagsoort (graafmelding, calamiteitenmelding,  oriëntatieverzoek).  \
Elke regel heeft een bepaalde beperking voor de vulling. Bijvoorbeeld toegestane tekens of maximale lengte.  \
Elke regel moet voldoen aan de business logica. Bijvoorbeeld dat de aanvangsdatum van werkzaamheden in de toekomst moet liggen.

:information_source: De validatie codes met omschrijving die genoemd zijn, representeert de huidige stand. Het Kadaster houdt zich het recht voor om (tekstuele) aanpassingen te maken in de terugkoppeling.

### 1.5.2 Validaties van de polygonen

De geometrie van de meegeleverde polygonen (gebiedspolygoon en eventueel informatiepolygoon) worden op onderstaande aspecten gecontroleerd.


**Geometrisch**  \
De volgende controles worden uitgevoerd:
- de geometrie moet gespecificeerd zijn in RD-coördinaten
- het betreft een 2D-polygoon (x en y).
- alleen een enkelvoudige polygoon (zonder gaten, donuts) is toegestaan.
- de polygoon mag zichzelf niet kruisen of raken.
- de polygoon mag geen repeterende punten hebben.
- de coördinaten van de polygoon mogen 0, 1, 2 of 3 decimalen bevatten.
- de geometrie mag niet meer lijnpunten bevatten dan het ingestelde maximum.  \
Voor de gebiedspolygoon is dit 50 voor de informatiepolygoon is dit 200. 

**Ligging en omvang**  \
De volgende controles worden uitgevoerd:
- de punten van de geometrie moeten binnen het gebied van Nederland liggen.
- het systeem controleert of de gebiedspolygoon de grenzen van de maximumgrootte van het in te tekenen gebied overschrijdt. De maximum gebiedsgroote is:
  - graafpolygoon bij graafmelding - 500 x 500 m
  - graafpolygoon bij calamiteitenmelding - 500 x 500 m
  - oriëntatiepolygoon bij oriëntatieverzoek - 2500 x 2500 m
- het systeem controleert of de informatiepolygoon de grenzen van de maximum grootte overschrijdt. Dit betreft:
  - informatiepolygoon - 500 x 500 m

**Specifieke controles voor informatiepolygoon**  \
Voor een graafmelding en een calamiteitenmelding gaat de mogelijkheid worden geboden om rond het graafgebied een ruimer gebied aan te geven waarover informatie wordt gewenst. Dit gebied wordt gespecificeerd met een `informatiepolygoon`.  \
Een opgegeven informatiegebied moet een graafgebied volledig omvatten: niets van de graafpolygoon mag buiten de informatiepolygoon liggen.

De volgende validaties zijn van toepassing:
- een informatiepolygoon mag alleen opgegeven worden bij een graafmelding en een calamiteitenmelding, en niet bij een oriëntatieverzoek. 
- niets van de graafpolygoon mag buiten de informatiepolygoon liggen.
- de maximale afstand van de informatiepolygoon tot de graafpolygoon moet minder of gelijk zijn aan 100 meter, waarbij het is toegestaan dat eventuele gaten gevuld worden.
- Het is niet toegestaan dat het verschil tussen het graafgebied en de informatiegebied een meervoudig polygoon betreft.

### 1.5.3 Aanvragen in het kader van de EU-stimulering breedband (WIBON-regelgeving)

In het kader van de EU-stimulering breedband (onderdeel van WIBON-regelgeving) kan er een specifiek oriëntatieverzoek worden gedaan:
- ter voorbereiding op een verzoek tot medegebruik van fysieke infrastructuur (`VoorbereidingMedegebruikFysiekeInfrastructuur`), of
- ter voorbereiding op een verzoek tot coördinatie van civiele werken (`VoorbereidingCoordinatieCivieleWerken`).

De volgende controles worden uitgevoerd:
- voorbereiding op een verzoek tot medegebruik van fysieke infrastructuur mag alleen worden gebruikt bij een oriëntatieverzoek.
- voorbereiding op een verzoek tot coördinatie van civiele werken mag alleen worden gebruikt bij een oriëntatieverzoek.
- per aanvraag mag slechts één van deze velden worden geselecteerd.
- als één van deze velden wordt gebruikt, mogen geen soorten werkzaamheden worden opgegeven .

### 1.5.4 Veiligheidsgebieden
Als het graafgebied van een KLIC-melding een veiligheidsgebied (BVG) overlapt, volgt er bij de validatiemeldingen een `warning`. De aanvraag wordt dan wel door het systeem aangenomen en verwerkt. De levering wordt echter niet naar de grondroerder gestuurd maar naar de veiligheidsgebied beheerder. De grondroerder moet dan in contact treden met de veiligheidsgebied beheerder voor de levering.  \
Vaak is dit onnodig veel hand werk, aangezien de grondroerder in de praktijk ook zijn graafgebied om het veiligheidsgebied heen had kunnen tekenen.  \
Daarvoor moet de grondroerder (via de applicatie die hij gebruikt) weten waar de veiligheidgebieden liggen. Gebruikers van Mijn Kadaster zien een markering op de kaart tijdens het tekenen van het graafgebied.   \
De B2B REST API gebruiker kan een verzoek indienen om de Geometrie van de veiligheidsgebieden beschikbaar te krijgen via een REST API, dat kan [via dit contactformulier](https://formulieren.kadaster.nl/contact_klic).  

  Meer informatie over de procedure bij een KLIC-melding in een veiligheidsgebied, is te vinden op [deze site van het Kadaster](https://www.kadaster.nl/-/wat-is-de-procedure-bij-een-klic-melding-graafmelding-of-een-ori-c3-abntatieverzoek-in-een-veiligheidsgebied-).

---------------------------------------------------------
## 2. Endpoints

### Grondroerders

Het **test** endpoint wat door grondroerders (of door serviceproviders namens grondroerders) gebruikt kan worden voor het testen is:  \
:arrow_forward: [https://service10.kadaster.nl/klic/ntd/aanvragen/v1/gebiedsinformatieaanvragen](https://service10.kadaster.nl/klic/ntd/aanvragen/v1/gebiedsinformatieaanvragen)  

Het **productie** endpoint wat door grondroerders (of door serviceproviders namens grondroerders) gebruikt kan worden voor het testen is:  \
:arrow_forward: [https://service10.kadaster.nl/klic/aanvragen/v1/gebiedsinformatieaanvragen](https://service10.kadaster.nl/klic/aanvragen/v1/gebiedsinformatieaanvragen)


Aandachtspunten:
- Deze URL is hoofdletter gevoelig.
- De validatie van het bericht vindt plaats en de (a synchrone) terugkoppeling is zoals het op productie gaat werken.
- Als het bericht aangenomen wordt, staat er in het bericht een poll-URL. Met deze URL is het validatie resultaat op te vragen.
- Voor het aanmaken van een testmelding in de NetbeheerderTestDienst (NTD) is een eigen endpoint en zijn er extra parameters in het modelschema opgenomen. (zie [1.3.2 Modelschema onderdeel "testparameters"](#132-modelschema-onderdeel-testparameters))  
- Voor het ophalen van de levering is er ook een API beschikbaar. Zie daarvoor [deze documentatie](../../Uitleveren/B2B%20REST%20API/).

### Netbeheerders
Het test endpoint wat door **netbeheerders** (of door serviceproviders namens netbeheerders) gebruikt kan worden voor het testen is:  \
:arrow_forward: [https://service10.kadaster.nl/klic/ntd/testaanvragen/v1/gebiedsinformatieaanvragen](https://service10.kadaster.nl/klic/ntd/testaanvragen/v1/gebiedsinformatieaanvragen)

Aandachtspunten:
- Deze URL is hoofdletter gevoelig.
- De validatie van het bericht vindt plaats en de (a synchrone) terugkoppeling is zoals het op productie gaat werken.
- Als het bericht aangenomen wordt, staat er in het bericht een poll-URL. Met deze URL is het validatie resultaat op te vragen.
- Voor het aanmaken van een testmelding in de NetbeheerderTestDienst (NTD) is een eigen endpoint en zijn er extra parameters in het modelschema opgenomen. (zie [1.3.2 Modelschema onderdeel "testparameters"](#132-modelschema-onderdeel-testparameters))  
- Conform de huidige werking van de NTD is het mogelijk om het aanleverproces zowel centraal an decentraal te testen en wordt er een  BeheerdersInformatieLevering-zip beschikbaar gesteld.

---------------------------------------------------------
## 3. Authenticatie en Autorisatie

De Authenticatie verloopt net als de ander KLIC API's via OAuth.  \
[De beschrijving is hier](../../API%20management/Authenticatie_via_oauth.md) te vinden.  

De scopes die nodig zijn voor het doen van een aanvraag zijn:
- Testomgeving: `klic.eto.b2baanvraag`
- Productie: `klic.b2baanvraag`
- NetbeheersTestDient (NTD:) `klic.ntd.gebiedsinformatieaanvraag.readonly`



Bij het scenario waarbij een serviceprovider de aanvraag doet in naam van een grondroerder, dient de serviceprovider met zijn eigen gegevens in te loggen. De grondroerder die de applicatie gebruikt dient de serviceprovider te machtigingen om namens de grondroerder de aanvraag te doen.
In het GIA-POST bericht staat in dit scenario bij de aanvrager het relatienummer van de grondroerder.  \
Het autoriseren van serviceproviders zal op vergelijkbare wijze gaan verlopen als dat het nu gebeurt voor netbeheerders die een serviceprovider machtigen. De beschrijving daarvoor [is hier te vinden](https://www.kadaster.nl/-/klic-klantinstructie-autoriseren-serviceprovider).

Het `relatienummer` van de `aanvrager` dient uit 10 tekens te bestaan en moet aangevuld worden met voorloop-nullen.

## 3.1 Overzicht per scenario

|                                                                                                                                                                                                                                                                                                                                  Scenario: | Grondroerder die melding doet via SP-app met CC                                                                             | Grondroerder die melding doet via eigen app met CC                                                              | Grondroerder die melding doet via app met EH3 of mijn-kadasterlogin                                           |
|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------:|:----------------------------------------------------------------------------------------------------------------------------|:----------------------------------------------------------------------------------------------------------------|:--------------------------------------------------------------------------------------------------------------|
|                                                                                                                                                                                                                                                                                                                   **App ontwikkeld door**: | Serviceprovider                                                                                                             | Grondroerder                                                                                                    | Serviceprovider of Grondroerder                                                                               |
|                                                                                                                                                                                                                         **Te gebruiken token bij de API**:<br>Zie: [deze Github pagina](../../API%20management/Authenticatie_via_oauth.md) | Serviceprovider                                                                                                             | Grondroerder                                                                                                    | Grondroerder                                                                                                  |
|                                                                                             **Relatienummer bij aanvrager van**:<br>Je kan je relatienummer vinden door in te loggen op Mijn Kadaster op de pagina profielinstellingen onder het kopje "klantnummer". Je geeft deze op inclusief voorloop-nullen om op 10 tekens te komen. | Grondroerder                                                                                                                | Grondroerder                                                                                                    | Grondroerder                                                                                                  |
|                                                                                                                                                                                                                                                                                                                                            |                                                                                                                             |                                                                                                                 |                                                                                                               |
|                                                                                                                                                                                                                              **Mijn kadasteraccount nodig**:<br>Zie: https://formulieren.kadaster.nl/aanmelden_klic (rol: serviceprovider) | Grondroerder en serviceprovider (met de rol Serviceprovider)                                                                | Grondroerder                                                                                                    | Grondroerder                                                                                                  |
|                                                                                                                                                                                                                        **PKI overheidscertificaat nodig**:<br>Zie https://www.logius.nl/domeinen/toegang/pkioverheidcertificaat-aanvragen  | Serviceprovicer                                                                                                             | Grondroerder                                                                                                    | nvt                                                                                                           |
|                                                                                                                                                                                                                                                                                                                                            |                                                                                                                             |                                                                                                                 |                                                                                                               |
|                                                                                                                                                                                                                                                                                                                                   **Type** | Machine 2 Machine                                                                                                           | Machine 2 Machine                                                                                               | Interactieve gebruiker                                                                                        |
|                                                                                                                                                                                                                                                 **Oauth**:<br>Zie: [deze Github pagina](../../API%20management/Authenticatie_via_oauth.md) | App ontwikkelaar: App aanmelden bij Oauth via CC flow                                                                       | App ontwikkelaar: App aanmelden bij Oauth via CC flow                                                           | App ontwikkelaar: App aanmelden bij OAuth via autorisation-grant-flow                                         |
|                                                                                                                                                                                                                                                                                                                                            |                                                                                                                             |                                                                                                                 |                                                                                                               |
|                                                                                                                                                                                                                                                                                        **Mijn Kadasterdienst benodigd** (Serviceprovider): | KLIC B2B (test) aanvraag REST                                                                                               | nvt                                                                                                             | nvt                                                                                                           |
|                                                                                                                  **Mijn Kadasterdienst benodigd** (Grondroerder):<br>  | **Organisatie**:<br><br>- KLIC Graafmelding<br>- KLIC Calamiteite<br>- KLIC Orientatieverzoek<br>- KLIC Autoriseren SP      | **Organisatie**:<br>- KLIC B2B (test) aanvraag REST<br>- KLIC Graafmelding<br>- KLIC Calamiteiten<br>- KLIC Orientatieverzoek | **Gebruiker**:<br>- KLIC B2B (test) aanvraag REST<br>- KLIC Graafmelding<br>- KLIC Calamiteiten<br>- KLIC Orientatieverzoek |
| **Grondroerder mandaat geven aan serviceprovider**?<br>Het autoriseren van serviceproviders zal op vergelijkbare wijze gaan verlopen als dat het nu gebeurt voor netbeheerders die een serviceprovider machtigen. De beschrijving daarvoor is hier te vinden. (https://www.kadaster.nl/-/klic-klantinstructie-autoriseren-serviceprovider) | Ja (om dit mandaat te mogen geven heeft de grondroerder de dienst "KLIC Autoriseren SP" nodig in het Mijn Kadaster account) | nvt                                                                                                             | nvt                                                                                                           |

Bent u **Grondroerder die melding doet via eigen app met CC** en `KLIC B2B (test) aanvraag REST` nog niet in het Mijn Kadaster account aanwezig? Mail naar klic@kadaster.nl   \
Vermeld hierbij uw relatienummer.