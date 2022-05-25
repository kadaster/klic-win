# Upgrade KLIC standaarden - wijzigingen Berichtenmodel Kabels en Leidingen (BMKL)


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