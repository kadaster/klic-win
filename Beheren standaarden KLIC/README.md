# Beheren standaarden KLIC

Voor het beheren van standaarden en het beoordelen van de issue's is een commissie ingesteld als vertegenwoordiging van de graafsector: de Technische Commissie Standaarden (TCS).  \
De KLIC-dienst verzorgt de informatie-uitwisseling over de ligging van kabels en leidingen in de graafsector, met als primair doel het voorkomen van graafschade. Ten behoeve van uniformiteit en eenduidigheid zijn daarvoor standaarden ontwikkeld. Denk daarbij aan standaarden voor

- het modelleren van IMKL-objecten (informatiemodel IMKL)
- het visualiseren van deze objecten (presentatiemodel PMKL)
- berichtuitwisseling (berichtenmodel BMKL)

De leden zijn te vinden op [deze site van het Kadaster](https://www.kadaster.nl/-/klic-ledenlijst-klic-tcs).


In de [presentatie van de KLIC-bijeenkomst](Beheren%20KLIC-standaarden%20(context).ppsx) wordt hierover een en ander toegelicht.  \
Daarin is ook aangegeven dat er soms behoefte is om de huidige versie van de standaarden aan te passen, bijv. vanwege onvolkomenheden of aanvullende wensen.  \
Voor het doorvoeren van wijzigingen op deze standaarden zijn procesafspraken gemaakt. Zie daarvoor o.a.

- [Wijzigingsproces standaarden KLIC](Wijzigingsproces%20standaarden%20KLIC.md)
- toelichting op [documentatie en versiebeheer](../API%20management/API-documentatie%20en%20versiebeheer.md) van KLIC API's

Uitgangspunten met betrekking tot de wijzigingen zijn:
- maximaal 1 major aanpassing van de KLIC-standaarden per jaar;
- ruim van te voren communiceren of er wel of niet geplande wijzigingen voorzien zijn op de KLIC-standaarden;
- wijzigingen en het wijzigingsproces zijn inzichtelijk voor de gebruikers;

De afgelopen jaren zijn er weer nieuwe gewenste wijzigen op de KLIC-standaarden (IMKL, PMKL en BMKL) vastgelegd. De planning voor het daadwerkelijk implementeren en aansluiten op de gewijzigde standaarden zal in 2024 duidelijk worden.

## Traject upgrade KLIC standaarden gestart

Aan de hand van aangedragen issue's heeft de Technische Commissie Standaarden wijzigingen op de KLIC-standaarden voorgesteld.  \
Deze worden vervolgens door Geonovum en het Kadaster verwerkt in een update van de standaarden ter consultatie voorgelegd. De commissie gaat de aandachtspunten uit de terugkoppeling behandelen.

  
Zie de website van Geonovum: https://www.geonovum.nl/geo-standaarden/informatiemodel-kabels-en-leidingen  en https://register.geostandaarden.nl/?url=kabelsleidingen/imkl

Er zal en sectorprogramma “Upgrade KLIC standaarden” georganiseerd worden in opdracht van het BAO KLIC. Net als in 2022 zal de implementatie gefaseerd zijn.

## Onderwerpen TCS

Op deze GitHub-pagina's wordt een terugkoppeling gegeven van de onderwerpen en issue's die in deze commissie worden behandeld. Let wel, dat dit concept-uitwerkingen (kunnen) zijn die nog definitief vastgesteld moeten worden door besluitvormende organen (BAO KLIC, KGO KLIC).

Hieronder worden onderwerpen genoemd die momenteel in behandeling zijn.

Continu beheer van issue-lijst (GitHub geregistreerde issues)
- Issues IMKL en PMKL (visualisatie);
- Issues BMKL, REST-API’s;
- Nieuwe (waarde)lijst soort werkzaamheden;
- Vastleggen mantelbuizen waar meerdere kabels en leidingen doorheen gaan;
- Vastleggen “Relevante eigenschappen van het net”;
- Extra informatie vastleggen kabelbed(geul) door netbeheerders;
- Nieuwe versie objectcatalogus

Het complete overzicht met de [issues die behandeling zijn, is hier](https://github.com/Geonovum/imkl2015-review/issues) te vinden.  

Een aantal beoogde aanpassingen zijn door middel van een TCS KLIC werkgroep uitgewerkt met de sector. Hieronder worden deze extra toegelicht

**Resultaten werkgroep Soort werkzaamheden**
  - Dit is link naar het gerelateerde [GitHub issue #347](https://github.com/Geonovum/imkl2015-review/issues/346)  
- De nieuwe lijst (resultaten) met Soort werkzaamheden zijn beoordeeld door de sector.
- [Hier is de versie gepubliceerd](Soort%20Werkzaamheden%201%20april%202022.pdf) met een toelichting.


**Resultaten werkgroep Kabelbed**
- Dit is link naar het gerelateerde [GitHub issue #347](https://github.com/Geonovum/imkl2015-review/issues/347)  
- De informatievoorziening m.b.t. een kabelbed moet verbeterd worden.
- De gebruikers hebben aangegeven meer informatie te willen over de specifieke kabels in het kabelbed.
- Een verdere detaillering van de data in een Kabelbed en hierdoor een betere representatie van de werkelijkheid.
- De werkgroep heeft een voorstel uitgewerkt en dit is beoordeeld door de sector.
- [Hier is de wijziging gepubliceerd](Kabelbed%201%20april%202022.pdf) met een toelichting.

  
**Resultaten werkgroep relevante eigenschappen van het net**
- Dit is link naar het gerelateerde [GitHub issue #345](https://github.com/Geonovum/imkl2015-review/issues/345)  
-	Bij het gebruik van de viewers moet voor de grondroerder nog beter de belangrijkste attributen als eerst getoond worden.
-	In de upgrade van de KLIC standaarden per januari 2022 is er al een [sortering/ordening](https://register.geostandaarden.nl/visualisatie/imkl/2.0.0/IMKL-Ordening-attributen-viewer-(2020-11-05).xlsx)  wettelijk vastgelegd, echter gebruikers hebben hier alweer een verdere verfijning van gewenst.  
-	De werkgroep heeft een aantal punten uitgewerkt
    -	Welke attributen relevante eigenschappen van het net zijn
    -	De naamgeving of vertaling van de attributen
    -	De restricties van de attributen
-	De werkgroep heeft een voorstel uitgewerkt en dit is beoordeeld door de sector.
-	[Hier is de wijziging](Relevante%20eigenschappen%20van%20het%20net%201%20april%202022.xlsx) gepubliceerd met een toelichting.


**Resultaten werkgroep mantelbuizen**
- Dit is link naar het gerelateerde [GitHub issue #324](https://github.com/Geonovum/imkl2015-review/issues/324)  
-	Bij het aanleveren van mantelbuizen kan het voorkomen dat één netbeheerder meerdere thema’s in één mantelbuis heeft of meerder netbeheerders gebruik maken van dezelfde mantelbuis
-	Het huidige IMKL en PMKL is niet geschikt om hiermee om te gaan
-	De werkgroep heeft een aantal punten uitgewerkt
    -	Éen netbeheerder meerdere thema’s in één mantelbuis (aanleveren)
    -	Meerdere netbeheerders gebruiken dezelfde mantelbuis (aanleveren)
    -	Impact op het IMKL en PMKL
-	De werkgroep heeft een voorstel uitgewerkt en dit is beoordeeld door de sector.
-	[Hier is de wijziging](Mantelbuizen%201%20april%202022.pdf) gepubliceerd met een toelichting.


**Resultaten werkgroep review objectcatalogus**
-	Dit is link naar het gerelateerde [GitHub issue #351](https://github.com/Geonovum/imkl2015-review/issues/351)  
-	De IMKL Objectcatalogus bevat alle objecttypen, hun attributen en relaties, waardelijsten die in IMKL voorkomen. Al deze informatie-elementen zijn voorzien van een definitie en eventueel een toelichting. Het document is daarmee een normatief onderdeel van de dataspecificatie IMKL. In de praktijk is gebleken dat niet alle termen een duidelijk begrijpbare definitie en of toelichting hebben die aansluit bij het gebruik. Een review en aanpassing waar nodig verbetert het begrip en juist gebruik van het IMKL.
-	De werkgroep heeft een voorstel uitgewerkt en dit is beoordeeld door de sector.
-	[Hier is de wijziging](WG%20IMKL-Objectcatalogus-2.0-review2023.pdf) gepubliceerd met een toelichting.


 Als u vragen heeft kunt u een mail sturen naar klic@kadaster.nl.