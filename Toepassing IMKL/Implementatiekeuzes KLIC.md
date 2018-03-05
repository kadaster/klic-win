# Implementatiekeuzes KLIC

**Inhoudsopgave**

- [Inleiding](#inleiding)
- [Implementatiekeuzes](#implementatiekeuzes)
  - [Bronhoudercode Kadaster](#bronhoudercode-kadaster)
  - [Bronhoudercode bij objecten van netbeheerder](#bronhoudercode-objecten-netbeheerder)
  - [LokaalID bij objecten van netbeheerder](#lokaalid-objecten-netbeheerder)
  - [LokaalID bij objecten van KLIC](#lokaalid-objecten-klic)
  - [Versie](#versie)
	- [GebiedsinformatieLevering](#versie-gebiedsinformatielevering)
	- [Belang](#versie-belang)
  - [BeginLifespanVersion](#beginlifespanversion)

## Inleiding

Voor het samenstellen van een levering van gebiedsinformatie ten behoeve van een Klic-aanvraag zijn er, naast de informatie over de kabels en leidingen van een utiliteitsnet, nog een aantal aanvullende gegevens nodig.
In onderstaand diagram is de relatie tussen de verschillende gegevensgroepen in een WION Uitlevering weergegeven (zie ook het betreffende hoofdstuk in het document IMKL2015_Dataspecificatie):

<img src="images/WION Uitlevering IMKL.jpg" width="489" height="345" />

Hieronder worden een aantal begrippen nader toegelicht:
* WION Uitlevering: Het totaal aan informatie dat kan worden geleverd n.a.v. een WION gebiedsinformatie-aanvraag.
* Leveringsinformatie: Administratieve gegevens van de uitlevering (_GebiedsinformatieLevering_) inclusief de aanvraaggegevens met graaf-, informatie- en/of oriëntatiepolygoon.
* Beheerdersinformatie: De belanghebbende netbeheerder met contactgegevens, eventueel aangevuld met algemene bijlagen en/of bijlagen met eis voorzorgsmaatregelen.
* Netinformatie: Informatie over het netwerk met kabels en leidingen met eventuele details en extra aanduidingen.

De netbeheerder is bronhouder voor de netinformatie en algemene en eisVoorzorgsmaatregel-bijlagen.
Deze gegevens worden op verzoek van KLIC per aanvraag door de bronhouder aangeleverd als beheerdersinformatie (decentrale netbeheerder), of worden door de bronhouder in de centrale voorziening geplaatst (centrale netbeheerder). In het laatste geval zal KLIC namens de bronhouder de beheerdersinformatie voor de betreffende netbeheerder samenstellen.

Om te kunnen bepalen welke belanghebbende netbeheerders een rol spelen bij een gebiedsinformatie-aanvraag, is er een Belangenregistratie nodig. Hierin zijn de belangen van de netbeheerders geregistreerd en is per netbeheerder per thema contactinformatie opgenomen die meegeleverd wordt als beheerdersinformatie.

Zodra voor alle belanghebbende netbeheerders beheerdersinformatie is aangeleverd, kan door KLIC een gebiedsinformatielevering worden samengesteld.
Deze gebiedsinformatielevering bevat informatie over de oorspronkelijke gebiedsinformatie-aanvraag op basis waarvan de gegevens zijn verzameld. Daarin wordt ook gerefereerd naar de polygoon/polygonen uit de aanvraag en een kaartje van de achtergrond.
Voor de netbeheerders die betrokken zijn bij een aanvraag, zal KLIC de contactgegevens van de geraakte belangen bepalen en meeleveren bij de gebiedsinformatie.

Bij het samenstellen van een levering zullen door KLIC dus verschillende nieuwe objecten worden aangemaakt.

KLIC maakt dus intensief gebruik van IMKL.
Voor een goede werking en eenduidigheid in het toepassen van IMKL zijn door KLIC implementatiekeuzes gemaakt.
Een aantal daarvan worden hieronder nader toegelicht.

## Implementatiekeuzes

### Bronhoudercode Kadaster

In het Klic-proces worden door het Kadaster diverse Klic-specifieke objecten aangemaakt waarvan een netbeheerder geen bronhouder is. Denk bijv. aan _GebiedsinformatieAanvraag_, _GebiedsinformatieLevering_, _Graafpolygoon_, etc.
Ook deze objecten moeten een identificatie krijgen van het type NEN3610ID, bestaande uit
* namespace: 'nl.imkl'
* lokaalID: bronhoudercode.lokaalID
* versie (optioneel)

Om deze objecten herkenbaar te laten zijn en uniek te identificeren, wordt er voor deze objecten een speciale Kadaster-bronhoudercode gebruikt: "KA0000".
Daarnaast wordt de conventie gehanteerd dat het lokaalID begint met "_" gevolgd door de naam van het feature.

Voorbeelden:
```xml
<imkl:GebiedsinformatieLevering gml:id="nl.imkl-KA0000._GebiedsinformatieLevering_17G000041-1">

<imkl:GebiedsinformatieAanvraag gml:id="nl.imkl-KA0000._GebiedsinformatieAanvraag_17G000041">

<imkl:Informatiepolygoon gml:id="nl.imkl-KA0000._Informatiepolygoon_17G000041">

<imkl:Graafpolygoon gml:id="nl.imkl-KA0000._Graafpolygoon_17G000041">

<imkl:Orientatiepolygoon gml:id="nl.imkl-KA0000._Orientatiepolygoon_17O000016">
```

### Bronhoudercode bij objecten van netbeheerder

In de centrale voorziening zal het Kadaster namens een centrale netbeheerder de objecten voor de beheerdersinformatie selecteren. Deze objecten behouden de identiteit zoals die door de bronhouder is aangeleverd (eventueel iets unieker gemaakt tijdens het clippen).
Daarnaast zullen er in het Klic-proces door het Kadaster __namens een bronhouder__ nieuwe objecten worden aangemaakt. Denk bijv. aan
* _Belanghebbende_ (bij de bepaling van de belanghebbende (net)beheerder bij een aanvraag)
* _Beheerder_
* _EisVoorzorgsmaatregelBijlage_ (bij de bepaling van voorzorgsmaatregelen)

In deze gevallen wordt voor het lokaalID de bronhoudercode gebruikt van de bronhouder waarvoor de dienst wordt verricht.
Om te voorkomen dat er eventuele dubbelingen gaan ontstaan met objecten die door de bronhouder zelf zijn aangemaakt, begint het lokaalID met "_" gevolgd door de naam van het feature.

Voorbeelden van identificaties van objecten die door het Kadaster namens een bronhouder kunnen worden aangemaakt:
```xml
<imkl:Belanghebbende gml:id="nl.imkl-KL9999._Belanghebbende_17G000041-1">
    <imkl:identificatie>
        <imkl:NEN3610ID>
            <imkl:namespace>nl.imkl</imkl:namespace>
            <imkl:lokaalID>KL9999._Belanghebbende_17G000041</imkl:lokaalID>
            <imkl:versie>1</imkl:versie>
        </imkl:NEN3610ID>
    </imkl:identificatie>
    <imkl:beginLifespanVersion>2017-01-11T09:09:11.31+01:00</imkl:beginLifespanVersion>
    ...
    <imkl:netbeheerder xlink:href="nl.imkl-KL9999._Beheerder"/>
</imkl:Belanghebbende>
```

```xml
<imkl:EisVoorzorgsmaatregelBijlage gml:id="nl.imkl-KL9999._EisVoorzorgsmaatregelBijlage_17G000041_gasHogeDruk">
    <imkl:identificatie>
        <imkl:NEN3610ID>
            <imkl:namespace>nl.imkl</imkl:namespace>
            <imkl:lokaalID>KL9999._EisVoorzorgsmaatregelBijlage_17G000041_gasHogeDruk</imkl:lokaalID>
        </imkl:NEN3610ID>
    </imkl:identificatie>
<imkl:beginLifespanVersion>2017-01-11T09:09:15.00+01:00</imkl:beginLifespanVersion>
...
</imkl:EisVoorzorgsmaatregelBijlage>
```

NB.
Bijlagen van het type `algemeen` en/of `nietBetrokken` wordt/worden door bronhouder zelf aangeleverd in de centrale voorziening.
De NEN3610-identificatie is door de bronhouder zelf opgegeven en uniek geïdentificeerd. Het tweede deel van het lokaalID (na bronhoudercode+".") mag niet beginnen met "_", zoals dat geldt voor alle features die door de bronhouder worden aangemaakt.

Voorbeelden van naamgeving van algemene bijlagen die door een bronhouder zijn aangemaakt:
```xml
<imkl:Bijlage gml:id="nl.imkl-KL1031.mijnAlgemeneBijlage">

<imkl:Bijlage gml:id="nl.imkl-KL1520.ikBenNietBetrokkenBijlage">
```

### LokaalID bij objecten van netbeheerder

Het lokaalID maakt het mogelijk per bronhouder de objecten uniek te identificeren. Het lokaalID is vrij door de bronhouder in te vullen en zal in de meeste gevallen gelijk zijn aan het id in de lokale registratie.
Om te voorkomen dat er eventuele dubbelingen gaan ontstaan met objecten die door het Kadaster namens een bronhouder worden aangemaakt, mag het lokaalID echter niet beginnen met "_". Dit is voorbehouden aan objecten die door het Kadaster worden aangemaakt en daarmee onderscheidend.\
Uitzondering hierop zijn de objecten die worden meegeleverd in de beheerdersinformatie, maar in de levenscyclus van deze objecten al door het Kadaster (namens de bronhouder) waren aangemaakt. Dit zijn _Belanghebbende_ en _Beheerder_.


### LokaalID bij objecten van KLIC

Zoals eerder genoemd worden objecten die door het Kadaster in het Klic-proces worden aangemaakt, geidentificeerd met een speciale Kadaster-bronhoudercode ("KA0000"), gevolgd door "_" en de naam van het feature.
Om de objecten ook uniek te maken over meerdere leveringen heen, wordt daaraan in veel gevallen het KlicMeldnummer toegevoegd. Omdat er mogelijk meerdere bijlagen van het type `eisVoorzorgsmaatregel` in een levering kunnen voorkomen, worden deze bijlagen uniek gemaakt door daar de naam van het thema nog aan toe te voegen.

Voorbeelden:
```xml
<imkl:GebiedsinformatieLevering gml:id="nl.imkl-KA0000._GebiedsinformatieLevering_17G000041-1">

<imkl:GebiedsinformatieAanvraag gml:id="nl.imkl-KA0000._GebiedsinformatieAanvraag_17G000041">

<imkl:Graafpolygoon gml:id="nl.imkl-KA0000._Graafpolygoon_17G000041">

<imkl:Belanghebbende gml:id="nl.imkl-KL1031._Belanghebbende_17G000041-1">

<imkl:Beheerder gml:id="nl.imkl-KL1031._Beheerder">

<imkl:EisVoorzorgsmaatregelBijlage gml:id="nl.imkl-KL1031._EisVoorzorgsmaatregelBijlage_17G000041_gasHogeDruk">
```

### Versie

In INSPIRE en volgens NEN3610 is het mogelijk om versies van objecten te gebruiken. Dit kan bijv. worden toegepast als objecten in hun levenscyclus een aangepaste inhoud (kunnen) krijgen.
Een object krijgt dan een nieuwe versie met een nieuwe beginLifespanVersion.
In KLIC onderkennen we het gebruik van een versie momenteel bij onderstaande features.

#### GebiedsinformatieLevering
Als niet alle netbeheerders binnen een gestelde tijd hun beheerdersinformatie aanleveren, zullen er deellevering(en) worden samengesteld en uitgeleverd.
Elke (deel)levering wordt dan uniek geidentificeerd door een versie.
Voorbeeld:
```xml
<imkl:GebiedsinformatieLevering gml:id="nl.imkl-KA0000._GebiedsinformatieLevering_17G000041-1">

<imkl:GebiedsinformatieLevering gml:id="nl.imkl-KA0000._GebiedsinformatieLevering_17G000041-2">
```

#### Belang
Deze objecten kennen vanouds al verschillende versies met geldigheidstermijnen.
Voorbeeld:
```xml
<imkl:Belang gml:id="nl.imkl-KL1031._Belang_PetroBGIregioNoordOost-3">

<imkl:Belang gml:id="nl.imkl-KL1031._Belang_PetroBGIregioNoordOost-4">
```

#### Belanghebbende
Als een bronhouder als belanghebbende bij een gebiedsinformatie-aanvraag is onderkend, ontstaat een eerste ruwe "0-versie" van het object.
Op dat moment is zijn betrokkenheid bij de aanvraag nog niet bekend.
Pas wanneer een belanghebbende voor deze aanvraag beheerdersinformatie heeft aangeleverd, kan zijn betrokkenheid - en daarmee de aanvullende kenmerken van het object - worden ingevuld.
Er ontstaat een nieuwe versie van het Belanghebbende-object.
Voorbeeld:
```xml
<imkl:Belanghebbende gml:id="nl.imkl-KL1031._Belanghebbende_17G000041-0">

<imkl:Belanghebbende gml:id="nl.imkl-KL1031._Belanghebbende_17G000041-1">
```

### BeginLifespanVersion

Het attribuut 'beginLifespanVersion' geeft de begindatum weer waarop een data object in de registratie werd aangemaakt; het begin van de levenscyclus van een data object.
Dit attribuut is afkomstig van INSPIRE maar wordt ook gebruikt in de IMKL-specieke objecten. Voor niet INSPIRE plichtige datasets kan hier een dummy waarde worden ingevuld.
Dit attribuut heeft DateTime als datatype.

Voorbeeld:
```xml
<gml:featureMember>
    <imkl:GebiedsinformatieLevering gml:id="nl.imkl-KA0000._GebiedsinformatieLevering_17G000041-2">
        <imkl:identificatie>
            <imkl:NEN3610ID>
                <imkl:namespace>nl.imkl</imkl:namespace>
                <imkl:lokaalID>KA0000._GebiedsinformatieLevering_17G000041</imkl:lokaalID>
                <imkl:versie>2</imkl:versie>
            </imkl:NEN3610ID>
        </imkl:identificatie>
        <imkl:beginLifespanVersion>2017-01-11T09:09:11+01:00</imkl:beginLifespanVersion>
        <imkl:leveringsvolgnummer>2</imkl:leveringsvolgnummer>
        <imkl:datumLeveringSamengesteld>2017-01-11T09:09:11+01:00</imkl:datumLeveringSamengesteld>
        ...
    </imkl:GebiedsinformatieLevering>
</gml:featureMember>
```

Voor de featuretypes die in het Klic-proces door het Kadaster worden aangemaakt, wordt de invulling van `beginLifespanVersion` hieronder toegelicht.

| FeatureType                  | datumtijdstip voor `beginLifespanVersion`                                    |
|------------------------------|------------------------------------------------------------------------------|
| GebiedsinformatieLevering    | 'datumLeveringSamengesteld'; het moment dat de levering wordt samengesteld |
| GebiedsinformatieAanvraag    | 'aanvraagDatum' uit GebiedsinformatieAanvraag; het moment dat de gebiedsinformatie-aanvraag bij KLIC is ingediend |
| Informatiepolygoon           | 'aanvraagDatum' uit GebiedsinformatieAanvraag;  |
| Graafpolygoon                | 'aanvraagDatum' uit GebiedsinformatieAanvraag;  |
| Orientatiepolygoon           | 'aanvraagDatum' uit GebiedsinformatieAanvraag;  |
| Belanghebbende               | versie 0: het moment dat de bepaling van geraakte belangen wordt uitgevoerd (datumBelangGeraakt); <br/>versie 1: het moment dat beheerdersinformatie is aangeleverd  |
| EisVoorzorgsmaatregelBijlage | het moment dat de beheerdersinformatie wordt samengesteld (datumBeheerdersinformatieOntvangen)  |
| Bijlage                      | het object Bijlage (algemeen/nietBetrokken) wordt overgenomen uit de centrale voorziening; daarmee wordt de `beginLifespanVersion` ook overgenomen  |
| Belang                       | het object Belang wordt overgenomen uit de centrale voorziening; daarmee wordt de `beginLifespanVersion` ook overgenomen  |
| Beheerder                    | laatste mutatiedatum van een feature uit de Klic-registratie  |
</PRE></BODY></HTML>
