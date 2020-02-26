# Beheren standaarden KLIC

De KLIC-dienst verzorgt de informatie-uitwisseling over de ligging van kabels en leidingen in de graafsector, met als primair doel het voorkomen van graafschade. Ten behoeve van uniformiteit en eenduidigheid zijn daarvoor standaarden ontwikkeld. Denk daarbij aan standaarden voor

- het modelleren van IMKL-objecten (informatiemodel IMKL)..
- het visualiseren van deze objecten (presentatiemodel PMKL)
- berichtuitwisseling (berichtenmodel BMKL)

In de [presentatie van 31 januari 2020](KLIC-standaarden%20KLIC%20bijeenkomst%2031%20januari%202020.ppsx) wordt hierover een en ander toegelicht.  \
Daarin is ook aangegeven dat er soms behoefte is om de huidige versie van de standaarden aan te passen, bijv. vanwege onvolkomenheden of aanvullende wensen.  \
Voor het doorvoeren van wijzigingen op deze standaarden zijn procesafspraken gemaakt. Zie daarvoor o.a.

- [Wijzigingsproces standaarden KLIC](Wijzigingsproces%20standaarden%20KLIC.md)
- toelichting op [documentatie en versiebeheer](../API%20management/API-documentatie%20en%20versiebeheer.md) van KLIC API's

Voor het beheren van standaarden en het beoordelen van de issue's is een commissie ingesteld als vertegenwoordiging van de graafsector: de <u>T</u>echnische <u>C</u>ommissie <u>S</u>tandaarden (TCS).  \
Op deze GitHub-pagina's wordt een terugkoppeling gegeven van de onderwerpen en issue's die in deze commissie worden behandeld. Let wel, dat dit concept-uitwerkingen (kunnen) zijn die nog definitief vastgesteld moeten worden door besluitvormende organen (BAO KLIC, KGO KLIC).

Hieronder worden onderwerpen genoemd die momenteel in behandeling zijn.

- Vertaling van begrippen in de Nederlandse taal; zie [IMKL vertaaltabel (concept 14-02-2020)](IMKL_vertaaltabel_2020-02-14%20-%20publicatie.pdf)  \
  Toelichting per onderdeel:
  - **metainformatie:** metagegevens en uitleg over dit document
  - **conventies:** uitgangspunten en uniformering bij IMKL-vertaling
  - **vertaaltabel:** de term in het model en de vertaling daarvan;  \
    de modeltermen zijn gebaseerd op [IMKL2015 v 1.2.1.1_object-attributen-ExtraRegels.xlsx](https://github.com/Geonovum/imkl2015/blob/master/regels/1.2.1.1/IMKL2015%20v%201.2.1.1_object-attributen-ExtraRegels.xlsx), aangevuld met relevante objecttypen en complexe datatypen die nog in INSPIRE-US zijn genoemd;
  - **IMKL waardelijsten**: waarden uit waardelijsten zoals gedefinieerd in IMKL (incl. [GWSW](https://data.gwsw.nl), INSPIRE-US-deel);  \
    zie [imkl-waardelijsten-1.2.1.1.rdf](https://github.com/Geonovum/imkl2015/blob/master/waardelijst/1.2.1.1/imkl-waardelijsten-1.2.1.1.rdf), aangevuld met INSPIRE-enumerations die gebruikt worden in het IMKL: http://inspire.ec.europa.eu/enumeration;
  - **IMKL concepten**:  \
    gedefinieerde termen in conceptenbibliotheek https://definities.geostandaarden.nl/doc/begrippenkader/imkl;
	de termen zijn als referentie gebruikt
- Prioritering van attributen; zie [Eisen overheid ordening attributen (concept 19-02-2020)](Eisen%20overheid%20ordening%20attributen%20(concept%202020-02-19)%20-%20publicatie.pdf)  \
  Toelichting per onderdeel:
  - **Prioritering (TCS)**: overzicht van alle IMKL-objecten (inclusief INSPIRE-US) met hun attributen en ordening (systeembreed);  \
    attributen van IMKL-objecten die niet in een kaartlaag worden weergegeven, zijn niet uitgewerkt;
  - **Prio per entiteit:** overzicht van alle IMKL-objecten (inclusief INSPIRE-US) met hun attributen en ordening per entiteit; deze ordening is afgeleid van het eerste overzicht
- Issue-lijst (GitHub geregistreerde issues)
  - Issues IMKL en PMKL (visualisatie);  \
    voor voortgang per issue, zie https://github.com/Geonovum/imkl2015-review/issues
  - Issues BMKL, REST-API’s;  \
    voor voortgang per issue, zie https://github.com/kadaster/klic-win/issues
  - Overzicht issues met prioriteit, zie [GitHub geregistreerde issues (concept 18-02-2020)](GitHub%20geregistreerde%20issues%202020-02-18%20v1.3%20-%20publicatie.pdf)

