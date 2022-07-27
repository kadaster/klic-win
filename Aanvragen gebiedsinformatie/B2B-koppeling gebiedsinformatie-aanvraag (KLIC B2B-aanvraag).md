# B2B-koppeling gebiedsinformatie-aanvraag (KLIC B2B-aanvraag)

Deze technische notitie beschrijft het koppelvlak tussen externe systemen en Kadaster KLIC voor het aanvragen van gebiedsinformatie door middel van een SOAP-interface.

**Inhoudsopgave**

- [1. KLIC B2B-aanvraag](#1-klic-b2b-aanvraag)
  - [1.1 Inleiding](#11-inleiding)
  - [1.2 Gebruik WS-Addressing bij aanvraag](#12-gebruik-ws-addressing-bij-aanvraag)
  - [1.3 Overzicht van de WS-Addressing attributen bij aanvraag](#13-overzicht-van-de-ws-addressing-attributen-bij-aanvraag)
  - [1.4 Terugkoppeling door het Kadaster](#14-terugkoppeling-door-het-kadaster)
  - [1.5 Overzicht van de WS-Addressing attributen bij terugkoppeling](#15-overzicht-van-de-ws-addressing-attributen-bij-terugkoppeling)
  - [1.6 Terugkoppeling procesverwerking](#16-terugkoppeling-procesverwerking)
- [2. WSDL’s Interface](#2-wsdls-interface)
- [3. Voorbeeldberichten](#3-voorbeeldberichten)
- [4. Interfaces](#4-interfaces)
- [5. Validaties](#5-validaties)
- [6. Beveiliging](#6-beveiliging)
  - [6.1 Van Kadaster naar aanvrager](#61-van-kadaster-naar-aanvrager)
  - [6.2 Van aanvrager naar Kadaster](#62-van-aanvrager-naar-kadaster)
  - [6.3 IP-adressen en logische namen](#63-ip-adressen-en-logische-namen)

---------------------------------------------------------
## 1. KLIC B2B-aanvraag

### 1.1 Inleiding

Via een B2B-koppeling kan door een extern systeem een bericht aan het Kadaster worden aangeboden met daarin een aanvraag voor gebiedsinformatie, kortweg een KLIC B2B-aanvraag.  \
De KLIC B2B-aanvraag ondersteunt daarbij de volgende aanvraagsoorten: een graafmelding, een calamiteitenmelding of een oriëntatieverzoek.

Nadat een bericht is ontvangen en gecontroleerd, wordt aan het externe systeem teruggekoppeld of de aanvraag in verwerking is genomen of dat de aanvraag is afgekeurd. Dit gebeurt door een bericht terug te sturen van het type KLIC B2B-orderbevestiging.  \
Indien de aanvraag een calamiteitenmelding betreft die in verwerking is genomen, wordt door het Kadaster - na de orderbevestiging - nog een additioneel bericht terug gestuurd van het type KLIC B2B-betrokkenBeheerders. In dit bericht wordt teruggekoppeld welke netbeheerders met welke thema's een belang hebben in het aangevraagde gebied.

De uitwisseling van berichten is geheel asynchroon op basis van SOAP. Het response op een bericht dat technisch in orde is en voldoet aan het schema, is een leeg bericht met een technische HTTP 200 of 202 statuscode (geaccepteerd).  \
Zie onderstaand sequence diagram.

![Berichtenstroom KLIC B2B-aanvraag](images/Fig.1%20Berichtenstroom%20KLIC%20B2B-aanvraag.png "Berichtenstroom KLIC B2B-aanvraag")  \
_Figuur 1 Berichtenstroom KLIC B2B-aanvraag_

### 1.2 Gebruik WS-Addressing bij aanvraag

Het antwoordadres waarnaar het Kadaster het bericht met de B2B-orderbevestiging en, indien van toepassing, het bericht met de B2B-betrokkenBeheerders terugkoppelt, moet worden meegegeven bij de B2B-aanvraag.  \
Hiervoor wordt de WS-Addressing header gebruikt.

Het antwoordadres is een webservice endpoint dat meegegeven moet worden via het `wsa:ReplyTo` attribuut in de WS-Addressing header.
Tevens moet in de WS-Addressing header via het `wsa:Action` attribuut worden meegegeven of het een reguliere B2B-aanvraag betreft of een B2B-aanvraag bedoeld om de berichtuitwisseling te testen.  \
De volgende waarden kunnen meegegeven worden in het `wsa:Action` attribuut uit WS-Addressing:

- KLIC-B2B-AANVRAAG - voor een reguliere aanvraag
- KLIC-B2B-TESTAANVRAAG - voor het testen van het koppelvlak

Andere waarden worden niet geaccepteerd en geven een foutmelding.

De berichtenuitwisseling is idempotent. Dat wil zeggen dat een al eerder aangeboden bericht met een B2B-aanvraag niet opnieuw in verwerking wordt genomen, maar op dezelfde wijze reageert als bij de eerste keer dat het bericht werd aangeboden.
De initiële B2B-orderbevestiging (plus het eventuele bericht met B2B-betrokkenBeheerders) wordt dan opnieuw teruggestuurd.  \
Om een B2B-aanvraag uniek te identificeren moet in het `wsa:MessageID` attribuut van de WS-Addressing header een unieke identificatie worden meegestuurd.
Het verdient aanbeveling om als unieke MessageID een zogenaamde UUID of GUID te gebruiken:

- Java:	_java.util.UUID.randomUUID().toString();_
- C#:	_System.Guid.NewGuid().ToString("D")_

### 1.3 Overzicht van de WS-Addressing attributen bij aanvraag

| WS-Addressing attribuut  | Toepassing bij indienen B2B-aanvraag                                 |
|--------------------------|----------------------------------------------------------------------|
| wsa:To                   | n.v.t.<br>(default "http://www.w3.org/2005/08/addressing/anonymous") |
| wsa:Action               | KLIC-B2B-AANVRAAG of<br>KLIC-B2B-TESTAANVRAAG                        |
| wsa:ReplyTo              | antwoordadres (endpoint bij aanvrager)                               |
| wsa:MessageID            | unieke identificatie (UUID of GUID)                                  |
| wsa:RelatesTo            | n.v.t. in aanvraag-bericht                                           |

Voorbeeld van WS-Addressing bij een aanvraag:
```xml
  <soapenv:Header xmlns:wsa="http://www.w3.org/2005/08/addressing">
  <wsa:Action>KLIC-B2B-AANVRAAG</wsa:Action>
  <wsa:ReplyTo>
    <wsa:Address>https://data.networkoperator.nl/klic/soap/v1</wsa:Address>
  </wsa:ReplyTo>
  <wsa:MessageID>uuid:3a2714da-0ba5-4633-9ee2-f2090dc12f75</wsa:MessageID>
</soapenv:Header>
```

### 1.4 Terugkoppeling door het Kadaster

De unieke identificatie die bij de aanvraag in het `wsa:MessageID` attribuut is opgegeven, wordt in de teruggekoppelde B2B-orderbevestiging en eventueel het bericht met B2B-betrokkenBeheerders weer teruggegeven in het `wsa:RelatesTo` attribuut.  \
Met dit attribuut kan door de aanvrager de relatie worden gelegd tussen de B2B-aanvraag en de teruggekoppelde berichten met een B2B-orderbevestiging (plus eventueel de B2B-betrokkenBeheerders).

De volgende waarde wordt door het Kadaster meegegeven in het `wsa:Action` attribuut uit WS-Addressing bij een teruggekoppeld bericht:

- KLIC-B2B-ONTVANGSTBEVESTIGING - voor het bericht met de B2B-orderbevestiging
- KLIC-B2B-BETROKKENBEHEERDERS - voor het bericht met B2B-betrokkenBeheerders

### 1.5 Overzicht van de WS-Addressing attributen bij terugkoppeling

| WS-Addressing attribuut  | Toepassing bij terugkoppeling op B2B-aanvraag                        |
|--------------------------|----------------------------------------------------------------------|
| wsa:To                   | n.v.t.<br>(default "http://www.w3.org/2005/08/addressing/anonymous") |
| wsa:Action               | KLIC-B2B-ONTVANGSTBEVESTIGING of<br>KLIC-B2B-BETROKKENBEHEERDERS     |
| wsa:MessageID            | unieke identificatie (UUID of GUID)                                  |
| wsa:To                   | antwoordadres (endpoint bij aanvrager)                               |
| wsa:RelatesTo            | oorspronkelijke identificatie (wsa:MessageID uit aanvraag-bericht)   |

Voorbeeld van WS-Addressing bij een response op bovenstaande aanvraag:
```xml
  <soapenv:Header xmlns:wsa="http://www.w3.org/2005/08/addressing">
  <wsa:Action>KLIC-B2B-ONTVANGSTBEVESTIGING</wsa:Action>
  <wsa:MessageID>ed897cd6-06e0-40a5-b209-4701ba340378</wsa:MessageID>
  <wsa:To>https://data.networkoperator.nl/klic/soap/v1</wsa:To>
  <wsa:RelatesTo>uuid:3a2714da-0ba5-4633-9ee2-f2090dc12f75</wsa:RelatesTo>
</soapenv:Header>
```

### 1.6 Terugkoppeling procesverwerking

In de B2B-orderbevestiging wordt in de sectie `Procesverwerking` aangegeven of de aanvraag voor gebiedsinformatie succesvol in verwerking is genomen door middel van de elementen `ProcesVerwerkingCode`, `SeverityCode` en `Melding`.

De `ProcesVerwerkingCode` geeft het resultaat van de verwerking aan: goed (1) of fout (0). De default waarde is 1. Dit betekent dat het verzoek succesvol in verwerking is genomen.  \
De `SeverityCode` wordt gebruikt om de ernst van een fout aan te geven. De standaard classificaties die worden gebruikt, zijn: SECURITY, FATAL, ERROR, WARNING, INFO. De default waarde is INFO.  \
Het attribuut `Melding` kan meerdere keren voorkomen en wordt gebruikt om specifieke foutmeldingen terug te koppelen, zoals bijvoorbeeld validatiefouten.

| _Procesverwerking_ attribuut  | Toelichting                                                  |
|-------------------------------|--------------------------------------------------------------|
| ProcesVerwerkingCode          | resultaat van de verwerking: goed (1) of fout (0)            |
| SeverityCode                  | ernst van een fout                                           |
| Melding                       | terugmelding van validatiefouten                             |

Indien een aanvraag succesvol in verwerking is genomen, wordt in het bericht met B2B-orderbevestiging de volgende informatie teruggekoppeld:

| _Orderbevestiging_ attribuut  | Toelichting                                                                                          |
|-------------------------------|------------------------------------------------------------------------------------------------------|
| OrderID                       | ordernummer van de order, zoals deze uitgegeven is door het ordermanagement systeem van het Kadaster |
| Klantreferentie               | eigen referentie die de klant bij de aanvraag heeft meegegeven                                       |
| AanvraagDatumTijd             | datumtijd waarop de order als aanvraag bij het Kadaster is geregistreerd                             |

Voorbeeld van een B2B-orderbevestiging, inclusief _Procesverwerking_-attributen:
```xml
    <KlicB2BOrderbevestiging xmlns="http://www.kadaster.nl/schemas/klic/KlicB2BOrderbevestiging/20150129">
  <Procesverwerking>
    <ProcesVerwerkingCode>1</ProcesVerwerkingCode>
    <SeverityCode>INFO</SeverityCode>
  </Procesverwerking>
  <Orderbevestiging>
    <OrderID>1234567890</OrderID>
    <Klantreferentie>Project APD-3661</Klantreferentie>
    <AanvraagDatumtijd>2020-04-29T18:03:36.580+02:00</AanvraagDatumtijd>
  </Orderbevestiging>
</KlicB2BOrderbevestiging>
```
Voorbeeld van een B2B-orderbevestiging waarbij fouten zijn gevonden bij het valideren van de aanvraag:
```xml
    <KlicB2BOrderbevestiging xmlns="http://www.kadaster.nl/schemas/klic/KlicB2BOrderbevestiging/20150129">
  <Procesverwerking>
    <ProcesVerwerkingCode>0</ProcesVerwerkingCode>
    <SeverityCode>ERROR</SeverityCode>
    <Melding>
      <Code>COR0144</Code>
      <Omschrijving>Het adres van de opdrachtgever met postcode/aanduiding (7334XX 701) is niet bekend in BAG.</Omschrijving>
    </Melding>
  </Procesverwerking>
</KlicB2BOrderbevestiging>
```

---------------------------------------------------------
## 2. WSDL’s Interface

Voor het gebruik van de nieuwste interfaces voor de KLIC B2B-koppeling dient u gebruik te maken van de volgende WSDL’s plus bijbehorende XSD’s:

- KlicB2BAanvraag-1.1.wsdl  \
  bericht van aanvrager naar Kadaster, in figuur 1 aangegeven als 1a
- KlicB2BTestAanvraag-1.1.wsdl  \
  bericht van aanvrager naar Kadaster t.b.v. de communicatietest van het koppelvlak, in figuur 1 aangegeven als 1a
- KlicB2B-terugkoppeling-1.1.wsdl  \
  berichten van Kadaster naar aanvrager, in figuur 1 aangegeven als 2a en 3a.

Deze WSDL’s en bijbehorende schema’s kunt u vinden in de map: [Aanvragen gebiedsinformatie/Schemas](../../../tree/master/Aanvragen%20gebiedsinformatie/Schemas).

De WSDL’s zijn zoveel mogelijk getoetst op de WS-I Basic profile 1.1 standaard, waaraan de meeste softwareleveranciers zich conformeren. Vanuit het Kadaster wordt het SOAP-protocol versie 1.1 ondersteund.  \
Berichten dienen te worden samengesteld m.b.v. de UTF-8 karakterset.

Bij de implementatie dient u er rekening mee te houden dat de z.g. namespace-prefix conform de XML-standaard (zie http://www.w3.org/TR/xmlschema-0/#NS) niet een vaste waarde heeft.  \
De namespace-prefix kan dan ook per bericht anders zijn. We adviseren u om uw webservice zelf op dit aspect te controleren, zodat u niet onverwacht met problemen in de berichtuitwisseling wordt geconfronteerd.

---------------------------------------------------------
## 3. Voorbeeldberichten

Met diverse voorbeeldberichten wordt het gebruik van de KLIC B2B-koppeling voor aanvragen van gebiedsinformatie toegelicht.
Zie daarvoor de map: [Aanvragen gebiedsinformatie/Voorbeelden](../../../tree/master/Aanvragen%20gebiedsinformatie/Voorbeelden).

---------------------------------------------------------
## 4. Interfaces

| Naam                | **Aanvraag**                                                                                         |
|---------------------|------------------------------------------------------------------------------------------------------|
| Eigenaar            | Kadaster (KLIC)                                                                                      |
| Business object(en) | KlicB2BAanvraag                                                                                      |
| Patroon             | In-Only / Idempotent                                                                                 |
| Standaarden         | Webservice Digikoppeling WUS. Zie [logius.nl/diensten/digikoppeling](https://www.logius.nl/diensten/digikoppeling/documentatie)<br>Authenticatie = PKIoverheid. Zie http://www.pkioverheid.nl |
| Protocol            | HTTPS                                                                                                |
| Toegang             | URI / URL <br>https://service10.kadaster.nl/klic/klic-b2baanvraag/service                            |

| Naam                | **Orderbevestiging**                                                                                 |
|---------------------|------------------------------------------------------------------------------------------------------|
| Eigenaar            | Aanvrager                                                                                            |
| Business object(en) | KlicB2BOrderbevestiging                                                                              |
| Patroon             | Out-Only                                                                                             |
| Standaarden         | Webservice Digikoppeling WUS. Zie [logius.nl/diensten/digikoppeling](https://www.logius.nl/diensten/digikoppeling/documentatie)<br>Authenticatie = PKIoverheid. Zie http://www.pkioverheid.nl |
| Protocol            | HTTPS                                                                                                |
| Toegang             | URI / URL <br>WS-Addressing ReplyTo endpoint uit de B2B-aanvraag                                     |

| Naam                | **BetrokkenBeheerders**                                                                              |
|---------------------|------------------------------------------------------------------------------------------------------|
| Eigenaar            | Aanvrager                                                                                            |
| Business object(en) | KlicB2BBetrokkenBeheerders                                                                           |
| Patroon             | Out-Only                                                                                             |
| Standaarden         | Webservice Digikoppeling WUS. Zie [logius.nl/diensten/digikoppeling](https://www.logius.nl/diensten/digikoppeling/documentatie)<br>Authenticatie = PKIoverheid. Zie http://www.pkioverheid.nl |
| Protocol            | HTTPS                                                                                                |
| Toegang             | URI / URL <br>WS-Addressing ReplyTo endpoint uit de B2B-aanvraag                                     |

---------------------------------------------------------
## 5. Validaties

De controles die worden uitgevoerd op een B2B-aanvraag van gebiedsinformatie zijn uitgewerkt in een apart dpcument.  \
Zie daarvoor [Controles B2B-koppeling gebiedsinformatie-aanvraag](Controles%20B2B-koppeling%20gebiedsinformatie-aanvraag.md).

---------------------------------------------------------
## 6. Beveiliging

Het technische koppelvlak bij het Kadaster voldoet aan de Digikoppeling standaard. Digikoppeling stelt met name eisen
aan het gebruik van http over TLS (rfc2818) en het gebruik van PKIoverheid certificaten voor de authenticatie.

Informatie over het PKIoverheid certificaat kunt u vinden op http://www.pkioverheid.nl/

Voor zowel het verzenden, als het ontvangen van informatie kan de B2B-aanvraag-dienst alleen communiceren met de standaard https-poort (443).

### 6.1 Van Kadaster naar aanvrager
Voor het indienen van de B2B-aanvraag is, conform de voorschriften, een certificaat onder de root “Staat der Nederlanden Private Root CA G1” ('private root') in gebruik.
Het betreft hier service10.kadaster.nl. Om gebruik te kunnen maken van de B2B-aanvraag-dienst, dient u certificaten uit de “private root” te vertrouwen.
Het OIN van het Kadaster is “00000001802327497000”.  
Alle gegevens in het certificaat kunnen in de loop van de tijd veranderen. Het certificaat kan verlopen, het Kadaster kan een ander certificaat-uitgever (CA) gaan gebruiken, etc.
Het OIN van het Kadaster blijft echter altijd gelijk.

### 6.2 Van aanvrager naar Kadaster
Bij het versturen van de B2B-aanvraag naar het Kadaster wordt gebruik gemaakt van HTTP Basic Authentication (gebruik van gebruikersnaam en wachtwoord).
De https (enkelzijdig TLS) verbinding is conform Digikoppeling standaard RFC 2818 http over TLS.
De gebruikersnaam en wachtwoord kunnen door de aanvrager in het Mijn Kadaster-portaal zelf beheerd worden.

### 6.3 IP-adressen en logische namen

Door het Kadaster worden geen logische namen of IP-adressen van de webservice die het bericht verstuurd naar de aanvrager, bekend gemaakt.  \
U kunt in uw eigen netwerkomgeving controleren m.b.v. het certificaat of het bericht afkomstig is van het Kadaster.  \
Een aanvrager kan uiteraard zelf besluiten om middels eigen tooling op IP-adressen te controleren als dat voor zijn eigen beveiliging wenselijk is. Vanuit Kadaster kunnen we de IP-adressen en logische namen echter niet garanderen (deze kunnen dus wijzigen).
