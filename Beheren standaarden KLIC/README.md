# Beheren standaarden KLIC

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

In **2020** worden de gewenste wijzigen op de KLIC-standaarden (IMKL, BMKL en PMKL) doorgevoerd. Het daadwerkelijk implementeren en aansluiten op de gewijzigde standaarden wordt verwacht in **2021**.

## Onderwerpen TCS

Voor het beheren van standaarden en het beoordelen van de issue's is een commissie ingesteld als vertegenwoordiging van de graafsector: de <u>T</u>echnische <u>C</u>ommissie <u>S</u>tandaarden (TCS).  \
Op deze GitHub-pagina's wordt een terugkoppeling gegeven van de onderwerpen en issue's die in deze commissie worden behandeld. Let wel, dat dit concept-uitwerkingen (kunnen) zijn die nog definitief vastgesteld moeten worden door besluitvormende organen (BAO KLIC, KGO KLIC).

Hieronder worden onderwerpen genoemd die momenteel in behandeling zijn.

- Issue-lijst (GitHub geregistreerde issues)
  - Issues IMKL en PMKL (visualisatie);  \
    voor voortgang per issue, zie https://github.com/Geonovum/imkl2015-review/issues
  - Issues BMKL, REST-API’s;  \
    voor voortgang per issue, zie https://github.com/kadaster/klic-win/issues
  - Overzicht issues met prioriteit, zie [GitHub geregistreerde issues (status 23-06-2020)](GitHub%20geregistreerde%20issues%20-%20overzicht.pdf)  \
    Let wel:
    - issues met prioriteit 'volgende' worden meegenomen in de volgende release van de standaarden;
    - van de oranje-gemarkeerde issues wordt nog een behandeling van de TCS gevraagd.

- Versie update strategie  \
  De TCS stelt voor om de overgang naar een nieuwe versie van het IMKL (IMKL v1.2.1 -> IMKL v2.0) geleidelijk te laten verlopen. Netbeheerders krijgen de mogelijkheid om tijdens een overgangsperiode over te schakelen naar aanlevering van netinformatie/beheerdersinformatie in de nieuwe versie.  \
  Ook afnemers worden in de gelegenheid gesteld om tijdens een overgangsperiode over te schakelen naar een nieuwe versie van de standaarden.  \
  Tevens is voorgesteld om deze overgang te laten gelden voor alle standaarden, dus zowel IMKL, als PMKL, als BMKL.  \
  Voor deze overgang zijn een aantal scenario's bekeken en is (door vrijwel alle stakeholders) een voorkeur uitgesproken voor scenario 1 (zie presentatie). Gedurende deze periode zal een KLIC-levering dan in zowel de huidige, als de nieuwe versie van het IMKL worden uitgeleverd.
  - Voor een toelichting op de scenario's, zie: [KLIC versie update strategie (vastgesteld)](KLIC%20versie%20update%20strategie%20(TCS).ppsx).

- Transformatieregels  \
  Tijdens de overgangsperiode zal een KLIC-levering in zowel de huidige versie (IMKL 1.2.1), als de nieuwe versie (IMKL 2.0) worden uitgeleverd.  \
  In transformatieregels wordt per IMKL-issue aangegeven hoe deze transformatie tussen beide versies zal worden uitgevoerd.
  - Overzicht van transformatieregels per IMKL-issue; zie [IMKL transformatieregels (vastgesteld 19-06-2020)](IMKL%20transformatieregels%20(TCS).ppsx).

- Wijzigingen op de berichtuitwisseling; zie [Overzicht BMKL-issues (status 23-06-2020)](Overzicht%20BMKL-issues%20(TCS).xslx)  \
  Bij de Github-issues zijn enkele verbetervoorstellen ingediend voor een nieuwe versie van het BMKL. Daarnaast kunnen wijzigingen van het nieuwe IMKL consequenties hebben voor uit te wisselen gegevens in de API-berichten.  \
  Ook is nog even kritisch gekeken naar verbeterpunten die al bij de implementatie van KLIC-WIN zouden worden opgepakt, maar toen onder tijdsdruk zijn blijven liggen. Van de meest relevante verbeterpunten zijn ook daarvoor issues aangemaakt.  \
  Denk daarbij ook aan het doorvoeren van een aangepaste hostname en base-path voor de KLIC-API's.  \
  Toelichting per onderdeel:
  - **Overzicht:** een overzicht van issues die (mogelijk) impact hebben op de BMKL-API;  \
  let wel: voor de oranje gemarkeerde issues moet nog besluitvorming plaatsvinden in het TCS
  - **Toelichting:** hier wordt aangegeven wat we in scope hebben genomen voor de nieuwe versie van het BMKL;
  voor een aantal opties moet nog een definitieve keuze worden gemaakt (blauwe markering)  
  - **Aanpassingen per API:**  \
  Vervolgens zijn er tabbladen gemaakt met relevante API’s die momenteel door KLIC worden beschikbaar gesteld voor externe gebruikers.  \
  Opgemerkt moet worden dat bij de analyse alle huidige BMKL-API’s zijn meegenomen, maar ook verbeteringen op andere API’s + B2B-aanvraag worden aanbevolen (blauwe tabbladen).  \
  Ook mogelijke verbeterpunten voor het gebruik van referenties naar KLIC-waardelijsten (bijv. url-paden, etc.) en statussen worden aanbevolen (blauw gemarkeerd).  \
  Per tabblad (dus per API + B2B-aanvraag) wordt een overzicht gegeven van:
    - de huidige situatie (huidige attribuutlijst)
	- de gewenste situatie (aangepaste attribuutlijst)
	- opmerkingen over de wijziging (met een referentie naar het GitHub-issue)
	- voorbeeldbericht van de huidige situatie
	- voorbeeldbericht van de gewenste situatie

Van onderstaande onderwerpen is een concept opgeleverd voor verdere besluitvorming.

- Vertaling van begrippen in de Nederlandse taal; zie [IMKL vertaaltabel (vastgesteld)](IMKL-vertaaltabel%20-%20publicatie.pdf)  \
  Status: vastgesteld door de commissie vastgesteld en voorgelegd voor besluitvorming.  \
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
  Status: vastgesteld door de commissie vastgesteld en voorgelegd voor besluitvorming.  \
  Toelichting per onderdeel:
  - **Ordening (TCS)**: overzicht van alle IMKL-objecten (inclusief INSPIRE-US) met hun attributen en ordening (systeembreed);  \
    attributen van IMKL-objecten die niet in een kaartlaag worden weergegeven, zijn niet uitgewerkt;
  - **Ordening (TCS) (NL)**: overzicht van alle IMKL-objecten waarbij de vertaaltabel is toegepast op de attributen (systeembreed);
  - **Ordening per entiteit:** overzicht van alle IMKL-objecten (inclusief INSPIRE-US) met hun attributen en ordening per entiteit; deze ordening is afgeleid van het eerste overzicht
  - **Voorbeelden per entiteit:** voorbeelden van ordening bij een verscheidenheid aan IMKL-objecten waarbij de vertaaltabel is toegepast op de attribuutnamen en de waarden uit de waardelijsten

Als u vragen heeft kunt u een mail sturen naar klic@kadaster.nl.

