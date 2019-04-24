# Validaties bij actualiseren voorzorgsmaatregelen

In het document [Handreiking bij het invullen van de EV-beslissingsmatrix KLIC](Handreiking%20voor%20invullen%20EV-beslissingsmatrix.md) wordt aangegeven waar de netbeheerder op moet letten, als hij de EV-bepaling door de centrale voorziening wil laten verzorgen.
Daarbij wordt speciaal aandacht gegeven aan het vullen van een technisch correct XML-bestand met EV-voorzorgsmaatregelen.

Hieronder wordt een overzicht gegeven van de belangrijkste validaties die worden uitgevoerd bij het actualiseren van voorzorgsmaatregelen.

## Aanduidingen en beslissingsregels bij voorzorgsmaatregelen

- De bestandsnamen binnen het zipbestand moeten uniek zijn.

- Er wordt een XSD-validatie uitgevoerd op de "voorzorgsmaatregelen.xml" in het zipbestand van de aanlevering.

- Er is een controle op `bronhoudercode` in _VoorzorgsmaatregelenBeheer_: de bronhoudercode moet overeenstemmen met de bronhouder die (namens wie) de voorzorgsmaatregelen aanlevert (worden aangeleverd).  \
Voorbeeld van aanlevering door bronhouder "KL3131":
```xml
    <bronhoudercode>KL3131</bronhoudercode>
```

- Bij elementen waarvoor een waarde uit een IMKL-waardelijst moet worden ingevuld, wordt gecontroleerd of
  - de juiste waardelijst wordt gebruikt;
  - een waarde wordt gebruikt die bekend is in de betreffende waardelijst.

  Het betreft de volgende waardelijsten:
  
  |gegevensgroep                      |element             |waardelijst / waarde                       |
  |-----------------------------------|--------------------|-------------------------------------------------------------------------------------------|	
  |utiliteitsnetAanduiding            | thema              | http://definities.geostandaarden.nl/imkl2015/id/waarde/Thema/_<waarde>_                   |
  |werkzaamhedenAanduiding            | soortWerkzaamheden | http://definities.geostandaarden.nl/imkl2015/id/waarde/SoortWerkzaamhedenValue/_<waarde>_ |
  |voorzorgsmaatregelBeslissingsregel | thema              | http://definities.geostandaarden.nl/imkl2015/id/waarde/Thema/_<waarde>_                   |
  |                                   | aanvraagSoort      | http://definities.geostandaarden.nl/imkl2015/id/waarde/AanvraagSoortValue/_<waarde>_      |
  |documentSjabloon                   | bestandMediaType   | http://definities.geostandaarden.nl/imkl2015/id/waarde/BestandMediaTypeValue/_<waarde>_   |
Voorbeeld:
```xml
    <utiliteitsnetAanduiding>
	    <thema xlink:href="http://definities.geostandaarden.nl/imkl2015/id/waarde/Thema/buisleidingGevaarlijkeInhoud"/>
	    ...
    </utiliteitsnetAanduiding>
```

> **Let wel:**  \
Bovengenoemde elementen mogen niet met een "lege" waarde worden gevuld. Dit wordt niet bij alle elementen gecontroleerd!

- Er wordt gecontroleerd of de identificatie van een documentsjabloon (`sjabloonID`) correct wordt samengesteld. Het format van `namespace` ("nl.imkl") en `lokaalID` wordt gecontroleerd, evenals de gebruikte bronhoudercode bij het `lokaalID`.  \
Voorbeeld:
```xml
    <documentSjabloon>
        <sjabloonID>
            <namespace>nl.imkl</namespace>
            <lokaalID>KL3131.<...........></lokaalID>
        </sjabloonID>
		...
    </documentSjabloon>
```

- Er mogen alleen documentsjablonen van het mediatype "PDF" worden meegeleverd bij de aanlevering. Dit moet dan ook als kenmerk worden meegegeven bij de definitie van het sjabloon.  \
Voorbeeld:
```xml
    <documentSjabloon>
		...
        <bestandMediaType xlink:href="http://definities.geostandaarden.nl/imkl2015/id/waarde/BestandMediaTypeValue/PDF"/>
		...
    </documentSjabloon>
```

- De bij de documentsjablonen gerefereerde pdf-sjablonen (zie `bestandsnaam`) moeten zijn meegeleverd bij de aanlevering.  \
Voorbeeld van aanlevering van het pdf-sjabloon "BGI-StrikteBegeleidingWerkzaamheden.sjabloon_v1.2.pdf":
```xml
    <documentSjabloon>
		...
        <bestandsnaam>BGI-StrikteBegeleidingWerkzaamheden.sjabloon_v1.2.pdf</bestandsnaam>
    </documentSjabloon>
```

- Een pdf-sjabloon mag maximaal 8 MB groot zijn.

- De bestandsnaam van een pdf-sjabloon wordt als _documentSjabloon_ uniek geïdentificeerd door zijn `sjabloonID`.  \
Iedere bestandsnaam van een pdf-sjabloon mag dus maar in één _documentSjabloon_ voorkomen.

- Er wordt gecontroleerd of er bij de EV-beslissingsregels een unieke prioritering per thema / aanvraagsoort is voor de opgegegeven netaanduidingen en werkaanduidingen.  \
Foutmelding: "De combinatie van thema '...', aanvraagsoort '...' en prioriteit '...' is niet uniek.

- Bij de EV-beslissingsregels mag (moet) in geval van een calamiteitenmmelding geen soort werkzaamheden (`netbeheerderWerkAanduiding`) worden opgegeven.  \
Voorbeeld:
```xml
    <voorzorgsmaatregelBeslissingsregel>
        <thema xlink:href="http://definities.geostandaarden.nl/imkl2015/id/waarde/Thema/middenspanning"/>
        <netbeheerderNetAanduiding>distributie_4-100kV</netbeheerderNetAanduiding>
        <aanvraagSoort xlink:href="http://definities.geostandaarden.nl/imkl2015/id/waarde/AanvraagSoortValue/calamiteitenmelding"/>
        <!-- geen netbeheerderWerkAanduiding -->
        <maatregel>MS-D-W3</maatregel>
        <maatregelPrioriteit>6</maatregelPrioriteit>
    </voorzorgsmaatregelBeslissingsregel>
```

> **Let wel:**  \
De "referentiële integriteit" tussen attributen van _VoorzorgsmaatregelenBeslissingsregel_ naar attributen van gerefereerde gegevensgroepen (_UtiliteitsnetAanduiding_, _WerkzaamhedenAanduiding_ en _VoorzorgsmaatregelToelichting_) wordt niet gecontroleerd!  \
Deze validatie moet nog worden toegevoegd!

> **Let wel:**  \
De "referentiële integriteit" tussen het attribuut `sjabloonID` van _VoorzorgsmaatregelToelichting_ naar de gerefereerde gegevensgroep _DocumentSjabloon_ wordt niet gecontroleerd!  \
Deze validatie moet nog worden toegevoegd!  \
Zie de paragraaf [Referentiële integriteit](Handreiking%20voor%20invullen%20EV-beslissingsmatrix.md#referenti%C3%ABle-integriteit) in de handreiking met invulinstructies.

> **Let wel:**  \
Er wordt onvoldoende gecontroleerd of de waarden van primaire sleutels van gegevensgroepen uniek zijn ("uniciteit")!  \
Deze validatie moet nog worden toegevoegd!  \
Zie de paragraaf [Unieke primaire sleutels](Handreiking%20voor%20invullen%20EV-beslissingsmatrix.md#unieke-primaire-sleutels) in de handreiking met invulinstructies.


## Netinformatie met voorzorgsmaatregelen

- Controle op `netbeheerderNetAanduiding` in de _AanduidingEisVoorzorgsmaatregel_-features: een `netbeheerderNetAanduiding` moet voorkomen in de XML-groep `utiliteitsnetAanduiding` bij de aangeleverde voorzorgsmaatregelen.

> **Let wel:**  \
De `netbeheerderNetAanduiding` moet - **in combinatie met het `thema` van het `Utiliteitsnet`** - bekend zijn bij de aangeleverde voorzorgsmaatregelen (in de XML-groepen `utiliteitsnetAanduiding` en `voorzorgsmaatregelBeslissingsregel`).  \
De validatie op de juiste combinatie met een thema moet nog worden toegevoegd!

- Controle op aanwezigheid van utiliteitsnet in de _AanduidingEisVoorzorgsmaatregel_-features: het utiliteitsnet waarnaar gerefereeerd wordt met het attribuut `inNetwork` moet als _Utiliteitsnet_ zijn meegeleverd in de netinformatie.  \
Hiermee wordt zeker gesteld dat er een thema kan worden gevonden bij de `netbeheerderNetAanduiding` ter bepaling van eventuele voorzorgsmaatregelen.


## EV-sjablonen

- Controle op juist gebruikte 'placeholders' in aangeleverde EV-sjablonen.


> **Let wel:**  \
In tegenstelling tot eerdere uitgangspunten, mag het invulveld in het EV-sjabloon worden aangeduid met zijn exacte naam, of zijn naam gevolgd door een "\_<volgnummer>".  \
Een invulveld mag meerdere keren in een EV-sjabloon worden gebruikt.  \
Het invulveld `EV-naam` kan dus ook meerdere keren worden gebruikt door de volgende velden `EV-naam_1`, `EV-naam_2`, etcetera te noemen.


Zie [Invulvelden EV-sjabloon](Invulvelden%20EV-sjabloon%20(2018-05-23).pdf) voor een overzicht van de te gebruiken invulvelden.