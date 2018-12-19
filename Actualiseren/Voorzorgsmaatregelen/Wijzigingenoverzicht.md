#### Actualiseren en bepalen voorzorgsmaatregelen - Overzicht wijzigingen

18-12-2018
* Documentatie over controles van voorzorgsmaatregelen uitgebreid:
  - nieuwe validaties toegevoegd
  - aanvulling met voorbeelden voor invullen XML-bestand met voorzorgsmaatregelen
  - aanvulling met aandachtspunten die mogelijk wél van enig belang kunnen zijn voor de toepassing door de netbeheerder, maar waarop nú nog niet wordt gevalideerd
* Kolomnamen van invulvelden EV-sjabloon (pdf) aangepast: onderscheid technisch naam invulveld en de logische naam (volgens IMKL 1.2)

18-07-2018
* Documentatie aangepast t.a.v. onderstaande gewijzigde functionaliteit:
  - Invulvelden die vaker in een sjabloon worden gebruikt, mogen nu ook met een suffix worden aangegeven;  \
    format: <naam invulveld>_<volgnummer> (voorbeeld: `EV-naam`, `EV-naam_1`, e.d.)
  - Het is mogelijk om `soortWerkzaamheden` te categoriseren bij meerdere `netbeheerderWerkaanduiding`-en.
  - Een meegeleverd pdf-sjabloon mag maar één keer als `documentSjabloon` worden opgevoerd.  

01-07-2018
* Voorbeeld 5. toegevoegd: EV-bepaling indien `soortWerkzaamheden` bij meerdere `werkzaamhedenAanduiding`-klassen worden ingedeeld

12-06-2018
* Explicieter benoemen dat invulvelden onder dezelfde naam vaker zijn te gebruiken (zonder suffix!), bij
  * Controles voorzorgsmaatregelen
  * Handreiking voor invullen EV-beslissingsmatrix KLIC

23-05-2018
* Invulvelden EV-sjabloon (pdf): aanvulling dat invulvelden onder dezelfde naam vaker zijn te gebruiken (zonder suffix)
* Voorbeelden 1 t/m 4: EV-sjablonen en EV-brieven aangepast; invulvelden onder dezelfde naam vaker gebruikt
* Toelichting op voorbeelden (presentatie) aangepast:
  - Klicnummer toegevoegd aan bestandsnaam van uitgeleverde documenten

16-05-2018
* Klicnummer toegevoegd aan bestandsnaam van meegeleverde EV-bijlagen (zie uitleveringen voorbeeld 4)

26-04-2018
* KlicVoorzorgsmaatregelenBeheer-1.0.xsd gepubliceerd als xmlns="http://www.kadaster.nl/schemas/klic/voorzorgsmaatregelen/v20180418"
* XML-voorbeelden zijn hierop aangepast; geen XSD-verwijzing in XML-bericht

23-03-2018
* Handreiking voor invullen EV-beslissingsregels aangevuld: pdf-sjabloonbestanden enkelvoudig refereren in _DocumentSjabloon_

19-03-2018
* Documentatie_pdf_sjabloon_aanmaken (zip): invulvelden onder dezelfde naam vaker te gebruiken in een EV-sjabloon

21-02-2018
* Voorbeelden verplaatst naar aparte map
* Kleine wijzigingen in features in voorbeeldbestanden doorgevoerd:
  * coordinatenstelsel `srsname="epsg:28992"`
  * gml:id's van geometrie conform richtlijnen: "nl.imkl-<bronhoudercode>.lokaalid" (*_geo)

01-02-2018
* Documentatie over controles toegevoegd

31-01-2018
* KlicVoorzorgsmaatregelenBeheer-1.0.xsd opgeleverd
* Handreiking voor het invullen van de EV-beslissingsregels opgeleverd
* Documentatie over het invullen van het EV-sjabloon, inclusief testprogramma
* Oplevering grote set aan voorbeelden (1 t/m 4)
