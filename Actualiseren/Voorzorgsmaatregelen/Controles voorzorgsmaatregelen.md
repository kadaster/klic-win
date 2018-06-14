# Validaties bij actualiseren voorzorgsmaatregelen

In het document [Handreiking bij het invullen van de EV-beslissingsmatrix KLIC](Handreiking%20voor%20invullen%20EV-beslissingsmatrix.md) wordt aangegeven waar de netbeheerder op moet letten, als hij de EV-bepaling door de centrale voorziening wil laten verzorgen.
Daarbij wordt speciaal aandacht gegeven aan het vullen van een technisch correct XML-bestand met EV-beslissingsregels.

Hieronder wordt een overzicht gegeven van de belangrijkste validaties die worden uitgevoerd bij het actualiseren van voorzorgsmaatregelen.

## Beslissingsregels bij voorzorgsmaatregelen
- XSD controle van EV-beslissingsregels.xml in de aanleverings-zip.
- In de beslissingsregels genoemde sjablonen moeten zijn meegeleverd.
- Controle op `bronhoudercode` in EV-beslissingsregels.
- Unieke prioritering per thema, aanvraagsoort voor een netaanduiding, werkaanduiding.

## Netinformatie met voorzorgsmaatregelen
- Controle op `netbeheerderNetAanduiding` in de AanduidingEisVoorzorgsmaatregel-features: de netbeheerdernetaanduidingen moeten voorkomen bij de beslissingsregels.

## EV-sjablonen
- Controle op juiste gebruikte 'placeholders' in aangeleverde EV-sjablonen.

Let wel:  \
In tegenstelling tot een eerder uitgangspunt, mag alleen de exacte naam van het invulveld worden gebruikt in het EV-sjabloon. De naam van het invulveld moet dus niet (meer) uniek gemaakt te worden.  \
Gebruik dus bijvoorbeeld het invulveld `EV-naam` meerdere keren in plaats van `EV-naam_1`, `EV-naam_2`, etcetera.

Zie [Invulvelden EV-sjabloon](Invulvelden%20EV-sjabloon%20(2018-05-23).pdf) voor een overzicht van de te gebruiken invulvelden.