# Validaties bij actualiseren voorzorgsmaatregelen

In het document [Handreiking bij het invullen van de EV-beslissingsmatrix KLIC](Handreiking%20voor%20invullen%20EV-beslissingsmatrix.md) wordt aangegeven waar de netbeheerder op moet letten, als hij de EV-bepaling door de centrale voorziening wil laten verzorgen.
Daarbij wordt speciaal aandacht gegeven aan het vullen van een technisch correct XML-bestand met EV-beslissingsregels.

Hieronder wordt een overzicht gegeven van de belangrijkste validaties die worden uitgevoerd bij het actualiseren van voorzorgsmaatregelen.

## Beslissingsregels bij voorzorgsmaatregelen
- XSD-controle van de "voorzorgsmaatregelen.xml" in het zipbestand van de aanlevering.
- De in de beslissingsregels genoemde sjablonen moeten zijn meegeleverd.
- De bestandsnaam van een pdf-sjabloon wordt als `documentSjabloon` uniek geïdentificeerd met zijn `sjabloonID`.  \
Iedere bestandsnaam van een pdf-sjabloon mag dus maar in één `documentSjabloon` voorkomen.
- Controle op `bronhoudercode` in EV-beslissingsregels.
- Unieke prioritering per thema, aanvraagsoort voor een netaanduiding, werkaanduiding.

## Netinformatie met voorzorgsmaatregelen
- Controle op `netbeheerderNetAanduiding` in de _AanduidingEisVoorzorgsmaatregel_-features: de netbeheerdernetaanduidingen moeten voorkomen bij de beslissingsregels.

## EV-sjablonen
- Controle op juiste gebruikte 'placeholders' in aangeleverde EV-sjablonen.

Let wel:  \
In tegenstelling tot eerdere uitgangspunten, mag het invulveld in het EV-sjabloon worden aangeduid met zijn exacte naam, of zijn naam gevolgd door een "\_"_<volgnummer>_.  \
Een invulveld mag meerdere keren in een EV-sjabloon worden gebruikt.  \
Het invulveld `EV-naam` kan dus ook meerdere keren worden gebruikt door de volgende velden `EV-naam_1`, `EV-naam_2`, etcetera te noemen.

Zie [Invulvelden EV-sjabloon](Invulvelden%20EV-sjabloon%20(2018-05-23).pdf) voor een overzicht van de te gebruiken invulvelden.