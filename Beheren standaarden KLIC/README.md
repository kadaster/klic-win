# Beheren standaarden KLIC

Voor het beheren van standaarden en het beoordelen van de issue's is een commissie ingesteld als vertegenwoordiging van de graafsector: de Technische Commissie Standaarden (TCS).
De KLIC-dienst verzorgt de informatie-uitwisseling over de ligging van kabels en leidingen in de graafsector, met als primair doel het voorkomen van graafschade. Ten behoeve van uniformiteit en eenduidigheid zijn daarvoor standaarden ontwikkeld. Denk daarbij aan standaarden voor

- het modelleren van IMKL-objecten (informatiemodel IMKL)
- het visualiseren van deze objecten (presentatiemodel PMKL)
- berichtuitwisseling (berichtenmodel BMKL)

In de [presentatie van de KLIC-bijeenkomst](Beheren%20KLIC-standaarden%20(context).ppsx) wordt hierover een en ander toegelicht.  \
Daarin is ook aangegeven dat er soms behoefte is om de huidige versie van de standaarden aan te passen, bijv. vanwege onvolkomenheden of aanvullende wensen.  \
Voor het doorvoeren van wijzigingen op deze standaarden zijn procesafspraken gemaakt. Zie daarvoor o.a.

- [Wijzigingsproces standaarden KLIC](Wijzigingsproces%20standaarden%20KLIC.md)
- toelichting op [documentatie en versiebeheer](../API%20management/API-documentatie%20en%20versiebeheer.md) van KLIC API's

Uitgangspunten met betrekking tot de wijzigingen zijn:
- maximaal 1 major aanpassing van de KLIC-standaarden per jaar;
- ruim van te voren communiceren of er wel of niet geplande wijzigingen voorzien zijn op de KLIC-standaarden;
- wijzigingen en het wijzigingsproces zijn inzichtelijk voor de gebruikers;

In **2020** zijn de gewenste wijzigen op de KLIC-standaarden (IMKL, PMKL en BMKL) vastgelegd. Het daadwerkelijk implementeren en aansluiten op de gewijzigde standaarden zal per januari **2022** mogelijk zijn.

## Upgrade KLIC standaarden zijn vastgelegd

Aan de hand van aangedragen issue's heeft de Technische Commissie Standaarden wijzigingen op de KLIC-standaarden voorgesteld.  \
Deze zijn vervolgens door Geonovum en het Kadaster verwerkt in een update van de standaarden en in juli/augustus 2020 ter consultatie voorgelegd.
De commissie heeft de aandachtspunten uit de terugkoppeling behandeld. De aanpassingen zijn verwerkt in een nieuwe versie en definitief vastgelegd. \
Zie de website van Geonovum: https://www.geonovum.nl/geo-standaarden/informatiemodel-kabels-en-leidingen en https://register.geostandaarden.nl/?url=kabelsleidingen/imkl

Dit betreft dan IMKL 2.0, PMKL 2.0 en BMKL 2.1.

## Onderwerpen TCS

Op deze GitHub-pagina's wordt een terugkoppeling gegeven van de onderwerpen en issue's die in deze commissie worden behandeld. Let wel, dat dit concept-uitwerkingen (kunnen) zijn die nog definitief vastgesteld moeten worden door besluitvormende organen (BAO KLIC, KGO KLIC).

Hieronder worden onderwerpen genoemd die momenteel in behandeling zijn.

- Continu beheer van issue-lijst (GitHub geregistreerde issues)
  - Issues IMKL en PMKL (visualisatie);
  - Issues BMKL, REST-API’s;
  - Nieuwe (waarde)lijst soort werkzaamheden;
  - Vastleggen mantelbuizen waar meerdere kabels en leidingen doorheen gaan;
  - Onderzoek en bepalen “Relevante eigenschappen van het net”;
  - Onderzoek gebruik kabelbed(geul) door netbeheerders en de visualisatie;

Van onderstaande onderwerpen is door de TCS een definitief ontwerp opgeleverd. Na definitieve besluitvorming van Agentschap Telecom, zullen deze worden opgenomen in de nieuwe versie van de standaarden.

- Vertaling van begrippen in de Nederlandse taal; zie [IMKL vertaaltabel (vastgesteld)](IMKL-vertaaltabel%20-%20publicatie.pdf)  \
  Status: vastgesteld door de commissie en voorgelegd voor besluitvorming.  \
  Toelichting per onderdeel:
  - **metainformatie:** metagegevens en uitleg over dit document
  - **conventies:** uitgangspunten en uniformering bij IMKL-vertaling
  - **vertaaltabel:** de term in het model en de vertaling daarvan;  \
    de modeltermen zijn gebaseerd op [IMKL2015 v 1.2.1.1_object-attributen-ExtraRegels.xlsx](https://github.com/Geonovum/imkl2015/blob/master/regels/1.2.1.1/IMKL2015%20v%201.2.1.1_object-attributen-ExtraRegels.xlsx), aangevuld met geaccordeerde toevoegingen voor de nieuwe versie van het IMKL en aangevuld met relevante objecttypen en complexe datatypen die nog in INSPIRE-US zijn genoemd;
  - **IMKL waardelijsten**: waarden uit waardelijsten zoals gedefinieerd in IMKL (incl. [GWSW](https://data.gwsw.nl), INSPIRE-US-deel);  \
    zie [imkl-waardelijsten-1.2.1.1.rdf](https://github.com/Geonovum/imkl2015/blob/master/waardelijst/1.2.1.1/imkl-waardelijsten-1.2.1.1.rdf), aangevuld met INSPIRE-enumerations die gebruikt worden in het IMKL: http://inspire.ec.europa.eu/enumeration;
  - **IMKL concepten**:  \
    gedefinieerde termen in conceptenbibliotheek https://definities.geostandaarden.nl/doc/begrippenkader/imkl;
    de termen zijn als referentie gebruikt
- Ordening van attributen per IMKL-object; zie [Eisen overheid ordening attributen (vastgesteld 15-05-2020)](Eisen%20overheid%20ordening%20attributen%20(concept).xlsx)  \
  Status: vastgesteld door de commissie en voorgelegd voor besluitvorming.  \
  Toelichting per onderdeel:
  - **Ordening (TCS)**: overzicht van alle IMKL-objecten (inclusief INSPIRE-US) met hun attributen en ordening (systeembreed);  \
    attributen van IMKL-objecten die niet in een kaartlaag worden weergegeven, zijn niet uitgewerkt;
  - **Ordening (TCS) (NL)**: overzicht van alle IMKL-objecten waarbij de vertaaltabel is toegepast op de attributen (systeembreed);
  - **Ordening per entiteit:** overzicht van alle IMKL-objecten (inclusief INSPIRE-US) met hun attributen en ordening per entiteit; deze ordening is afgeleid van het eerste overzicht
  - **Voorbeelden per entiteit:** voorbeelden van ordening bij een verscheidenheid aan IMKL-objecten waarbij de vertaaltabel is toegepast op de attribuutnamen en de waarden uit de waardelijsten

Als u vragen heeft kunt u een mail sturen naar klic@kadaster.nl.