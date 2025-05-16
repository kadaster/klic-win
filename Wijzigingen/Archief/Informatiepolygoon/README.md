# Informatiepolygoon

Op deze pagina wordt de implementatie van de informatiepolygoon toegelicht.
De presentatie die gegeven is op de voorlichtingsbijeenkomst op 31 januari 2020 is [hier](Informatiepolygoon%20(KLIC%20bijeenkomst%2031%20januari%202020).ppsx) te vinden.
In [dit document](Beschrijving%205%20scenarios%20thema%20BGI%20versus%20Graafpolygoon%20en%20Informatiepolygoon%20(2016-10-02).pdf) staan 5 scenario's voor een netbeheerder met een thema Buisleiding Gevaarlijke Inhoud die eis voorzorgsmaatregelen kent (EV-vlakken) en netinformatie heeft, in relatie met de graaf- en informatiepolygoon.

## Omschrijving begrippen
- Graafpolygoon (voor graafmeldingen en calamiteitenmeldingen)
  - Gebied waarbinnen de graafwerkzaamheden plaats vinden.
- Informatiepolygoon 
  - Gebied waarover kabel- en leidinginformatie opgevraagd wordt.
    - Deze informatiepolygoon omvat (of is gelijk aan) de graafpolygoon.
    - Niets van de graafpolygoon ligt buiten de informatiepolygoon.
  - Met de informatiepolygoon is het mogelijk om meer informatie te krijgen zonder dat hierdoor een eis voorzorgsmaatregel (EV) geldend wordt, voor bijvoorbeeld:
    - oriëntatie (t.o.v. bijvoorbeeld gebouwen op de achtergrondkaart)
    - afstemming van bijvoorbeeld aanrijroutes van zwaar materieel
- `geometrieVoorVisualisatie` (“informatiebuffer”)
  - Het gebied wat binnen in de informatiepolygoon valt en buiten de graafpolygoon.

## Aandachtspunten:
- Kabel- en leidinginformatie wordt geleverd over alle kabels en leidingen die binnen de informatiepolygoon liggen.
- Vaststellen van de toepasselijkheid van een eis voorzorgmaatregel (EV) bij een graafmelding en calamiteitenmelding is op basis van de graafpolygoon.
- Bepaling veiligheidsgebied wordt gedaan aan de hand van de informatiepolygoon. 
- Niet graven in informatiebuffer, wel in graafgebied.
- De `geometrieVoorVisualisatie` (“informatiebuffer”) wordt volgens het presentatiemodel voor kabels en leidingen [(PMKL)](https://github.com/Geonovum/imkl2015/tree/master/visualisatie) gevisualiseerd (roze gearceerd).


## Implementatiekeuzes:
- In de _GebiedsinformatieAanvraag_ API zal altijd een informatiepolygoon getoond worden. Als de informatiepolygoon niet is opgegeven in de aanvraag, wordt de geometrie van de graafpolygoon ook als informatiepolygoon getoond.
- Gerelateerd aan [IMKL issue 240](https://github.com/Geonovum/imkl2015-review/issues/240) zijn de volgende keuzes gemaakt:
  - In de _GebiedsinformatieLevering_ (GI.xml) wordt de informatiepolygoon niet getoond als de graafpolygoon gelijk is aan de informatiepolygoon.
  - Er is voor de B2B-aanvraag een extra validatie regel toegevoegd ter voorkoming van invalide IMKL: Als de combinatie van graafpolygoon en informatiepolygoon leidt tot een `geometrieVoorVisualisatie` die een meervoudig polygoon is, wordt de aanvraag afgekeurd.

## Overzicht van de wijzigingen:
**Melding doen**:
- Aanvraag via website
  - mogelijkheid om informatiebuffer om graafpolygoon toe te voegen met ingestelde aantal meters.
- Aanvraag via B2B-kanaal
  - extra [validatie regels](../../../Aanvragen%20gebiedsinformatie/B2B%20REST%20API#152-validaties-van-de-polygonen) voor de aanvraag
  - in het responsebericht bij calamiteitenmeldingen wordt onderscheid gemaakt tussen netbeheerder-thema's die op basis van hun geregistreerde belang alleen voor de informatiepolygoon van toepassing zijn, en netbeheerders die (ook) in de graafpolygoon van toepassing zijn.  \
     Zie het tabblad `POLL-Response messages` van de excel sheet met [het modelschema](../../../Aanvragen%20gebiedsinformatie/B2B%20REST%20API/README.md#13-modelschema-en-swagger-documentatie). Het veld 'alleenInInformatiepolygoon' geeft dit onderscheid aan. 
- NetbeheerdersTestDienst (NTD)
  - mogelijk om testmeldingen te doen met informatiepolygoon

**Ontvangstbevestiging (pdf)**:
- Onderscheid tussen netbeheerder-thema's die op basis van hun geregistreerde belang alleen voor de informatiepolygoon van toepassing zijn, en netbeheerders die (ook) in de graafpolygoon van toepassing zijn.

**API - gebiedsinformatieAanvragen**:
- Informatiepolygoon toegevoegd

**Uitlevering**:
- Leveringsbrief (LI.pdf)
  - Onderscheid tussen netbeheerder-thema's die op basis van hun netinformatie alleen voor de informatiepolygoon van toepassing zijn, en netbeheerders die (ook) in de graafpolygoon van toepassing zijn.
- Gelaagde PDF (LP.pdf)
  - De `geometrieVoorVisalisie` van de informatiepolygoon is weergegeven conform het presentatiemodel kabels en leidingen (PMKL).
- _GebiedsinformatieLevering_ (GI.xml) 
  - Informatiepolygoon wordt genoemd.
  - Bounding box (`BoundedBy`) op basis van informatiepolygoon.
  - Referenties naar geraakt belang aangepast. (let op: een geraakt belang kan van toepassing zijn voor zowel de graafpolygoon en de informatiepolygoon)

**BeheerdersinformatieLevering (zip)**:
- _GebiedsinformatieLevering_ (GI.xml) 
  - Informatiepolygoon wordt genoemd.
  - Bounding box (`BoundedBy`) op basis van informatiepolygoon.
  - Referenties naar geraakt belang aangepast (let op: een geraakt belang kan van toepassing zijn voor zowel de graafpolygoon en de informatiepolygoon).



