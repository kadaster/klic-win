# Implementatie upgrade KLIC standaarden

Voor het beheren van standaarden en het beoordelen van de issue's is een commissie ingesteld als vertegenwoordiging van de graafsector: de <u>T</u>echnische <u>C</u>ommissie <u>S</u>tandaarden (TCS).  \
Op deze GitHub-pagina's wordt een terugkoppeling gegeven van de onderwerpen en issue's die in deze commissie worden behandeld. Let wel, dat dit concept-uitwerkingen (kunnen) zijn die nog definitief vastgesteld moeten worden door besluitvormende organen (BAO KLIC, KGO KLIC).

Hieronder worden onderwerpen genoemd die momenteel in behandeling zijn.

- Issue-lijst (GitHub geregistreerde issues)
  - Issues IMKL en PMKL (visualisatie);  \
    voor voortgang per issue, zie https://github.com/Geonovum/imkl2015-review/issues
  - Issues BMKL, REST-API’s;  \
    voor voortgang per issue, zie https://github.com/kadaster/klic-win/issues
  - Overzicht issues met prioriteit, zie [GitHub geregistreerde issues (status 10-02-2021)](../../Toelichting%20specifieke%20onderwerpen/Implementatie%20upgrade%20KLIC%20standaarden/Upgrade%20KLIC%20standaarden%20GitHub%20geregistreerde%20issues%2020210210.pdf)  \
    Let wel:
    - issues zijn aangevuld en bijgewerkt n.a.v. de consultatie en de terugkoppeling uit de TCS;
    - issues met prioriteit 'volgende' worden meegenomen in de volgende release van de standaarden;
    - de oranje-gemarkeerde issues ("parkeren") zijn nog een behandeling bij de TCS of TCS-werkgroepen;  \
	  de resultaten uit deze werkgroepen zullen niet meer worden meegenomen in de nieuwe versie.
  - Status: aandachtspunten uit de consultatie zijn behandeld door de commissie en de stakeholders;
    aanpassingen worden verwerkt in de Release Candidate.
  - Geonovum is bezig om de aanpassingen door te voeren en te publiceren;  \
    zie: https://www.geonovum.nl/geo-standaarden/informatiemodel-kabels-en-leidingen

- Versie update strategie  \
  De TCS stelt voor om de overgang naar een nieuwe versie van het IMKL (IMKL v1.2.1 -> IMKL v2.0) geleidelijk te laten verlopen. Netbeheerders krijgen de mogelijkheid om tijdens een overgangsperiode over te schakelen naar aanlevering van netinformatie/beheerdersinformatie in de nieuwe versie.  \
  Ook afnemers worden in de gelegenheid gesteld om tijdens een overgangsperiode over te schakelen naar een nieuwe versie van de standaarden.  \
  Tevens is voorgesteld om deze overgang te laten gelden voor alle standaarden, dus zowel IMKL, als PMKL, als BMKL.  \
  Voor deze overgang zijn een aantal scenario's bekeken en is (door vrijwel alle stakeholders) een voorkeur uitgesproken voor scenario 1 (zie presentatie). Gedurende deze periode zal een KLIC-levering dan in zowel de huidige, als de nieuwe versie van het IMKL worden uitgeleverd.
  - Voor een toelichting op de scenario's, zie: [KLIC versie update strategie (vastgesteld)](../../Toelichting%20specifieke%20onderwerpen/Implementatie%20upgrade%20KLIC%20standaarden/KLIC%20versie%20update%20strategie%20(TCS).pdf).

- Transformatieregels  \
  Tijdens de overgangsperiode zal een KLIC-levering in zowel de huidige versie (IMKL 1.2.1), als de nieuwe versie (IMKL 2.0) worden uitgeleverd.  \
  In transformatieregels wordt per IMKL-issue aangegeven hoe deze transformatie tussen beide versies zal worden uitgevoerd.
  - Overzicht van transformatieregels per IMKL-issue; zie [IMKL transformatieregels (vastgesteld 11-02-2021)](../../Toelichting%20specifieke%20onderwerpen/Implementatie%20upgrade%20KLIC%20standaarden/IMKL%20transformatieregels%20(TCS)%20v1.1.pdf).

- Wijzigingen op de berichtuitwisseling; zie [Overzicht BMKL-issues (status 10-02-2021)](../../Toelichting%20specifieke%20onderwerpen/Implementatie%20upgrade%20KLIC%20standaarden/Overzicht%20BMKL-issues%20(TCS)%2020210210.xlsx)  \
  Status: issues zijn bijgewerkt n.a.v. de consultatie en de terugkoppeling uit de TCS.  \
  Bij de Github-issues zijn enkele verbetervoorstellen ingediend voor een nieuwe versie van het BMKL. Daarnaast kunnen wijzigingen van het nieuwe IMKL consequenties hebben voor uit te wisselen gegevens in de API-berichten.  \
  Ook is nog even kritisch gekeken naar verbeterpunten die al bij de implementatie van het programma KLIC-WIN zouden worden opgepakt, maar toen onder tijdsdruk zijn blijven liggen. Van de meest relevante verbeterpunten zijn ook daarvoor issues aangemaakt.  \
  Denk daarbij ook aan het doorvoeren van een aangepaste hostname en base-path voor de KLIC-API's.  \
  Toelichting per onderdeel:
  - **Overzicht:** een overzicht van issues die (mogelijk) impact hebben op de BMKL-API;  \
  let wel: alle ingediende issues zijn behandeld door het TCS en worden meegenomen in de volgende versie
  - **Toelichting:** hier wordt aangegeven wat we in scope hebben genomen voor de nieuwe versie van het BMKL;
  let wel: naast de API's die tot het BMKL gerekend worden, worden ook de andere API's tussen Kadaster KLIC en netbeheerders aangepast t.b.v. eenduidigheid.  \
  Dit geldt ook voor de B2B-aanvraag.
  - **Aanpassingen per API:**  \
  Vervolgens zijn er tabbladen gemaakt met relevante API’s die momenteel door KLIC worden beschikbaar gesteld voor externe gebruikers.  \
  Bij de analyse zijn alle huidige BMKL-API’s meegenomen, maar ook verbeteringen op andere API’s en de B2B-aanvraag.  \
  Ook mogelijke verbeterpunten voor het gebruik van referenties naar KLIC-waardelijsten (bijv. url-paden, etc.) en statussen zijn voorgesteld (blauw gemarkeerd).  \
  Per tabblad (dus per API + B2B-aanvraag) wordt een overzicht gegeven van:
    - de huidige situatie (huidige attribuutlijst)
	- de gewenste situatie (aangepaste attribuutlijst)
	- opmerkingen over de wijziging (met een referentie naar het GitHub-issue)
	- voorbeeldbericht van de huidige situatie
	- voorbeeldbericht van de gewenste situatie



Als u vragen heeft kunt u een mail sturen naar klic@kadaster.nl.