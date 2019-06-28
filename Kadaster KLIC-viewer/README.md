#### Nieuwe Kadaster KLIC-viewer (BETA-versie)

Met de invoering van KLIC-WIN bevatten de levering van gebiedsinformatie vectorinformatie over kabels en leidingen - conform IMKL1.2.1.  \
Omdat **_na_** de overgangsperiode in het zipbestand de PNG-bestanden van netbeheerders (rasterbestanden voor ligging, maatvoering, annotatie en eigenTopo) niet meer worden uitgeleverd, dienen applicaties die hier gebruik van maken, aangepast te worden.  \
Zie de presentatie [WIBON levering - producten NA overgangsperiode.ppsx](../Uitleveren/WIBON%20levering%20-%20producten%20NA%20overgangsperiode.ppsx) in de map [klic-win/Uitleveren](../Uitleveren).

Als gebruiker van KLIC-leveringen betekent dit, dat u een aansluitende/aangepaste viewer moet gebruiken.

Er worden diverse viewers gebruikt en aangeboden, zoals
* de Kadaster KLIC-viewer,
* eigen viewers van grondroerders/netbeheerders en/of
* commerciële viewers.

Zorg dat u tijdig een passende viewer gebruiksklaar heeft.  

Er is een BETA-versie beschikbaar van de online Kadaster KLIC-viewer waarin een aantal leveringen zoals die **_na_** de overgangsperiode geleverd worden, te bekijken zijn.  \
De volgende functies zijn beschikbaar in deze BETA-versie:
* Met behulp van “Menu” kunt u een KLIC-melding openen.
* Met behulp van “Weergave” kunt u de netinformatie per netbeheerder/thema inzien en Annotatie, Maatvoering en GeselecteerdGebied aan- en uitzetten.
* Met behulp van “Docs” kunt u de leveringsbrief, de gelaagde PDF en de door de netbeheerder geleverde bijlagen inzien.
* Met behulp van “Printen” kunt u
  - de leveringsbrief en de gelaagde PDF uitprinten
  - de door de netbeheerder geleverde bijlagen uitprinten
  - met de functie “Kaartselectie” een gebied aangeven waarvan de kaartlagen op een aangegeven schaal en papierformaat moeten worden uitgeprint.  \
  De uitvoer bestaat uit een overzichtskaart, een verzamelkaart en een themakaart per netbeheerder/thema.  \
  Let wel: het opbouwen van deze pdf is erg gevoelig voor verstoringen of muisbewegingen. Dit wordt momenteel robuuster gemaakt.
* Met behulp van een klik op de kaart kunt u attribuutinformatie van de geraakte kabel- en leidingobjecten opvragen (op basis van het Informatiemodel Kabels en Leidingen – IMKL).

De BETA-versie van de online KLIC-viewer is te openen met de link [online KLIC-viewer (BETA)](https://service10.acceptatie.kadaster.nl/klic-viewer/uitlevering).

Een levering van gebiedsinformatie is te openen door een zogenaamde GUID in te vullen bij de KLIC melding code.  \
Kopieer hiervoor één van onderstaande GUID's:
* voorbeeld levering 1 (19G000603): 12345678-1234-1234-1234-123456789603
* voorbeeld levering 2 (19G000604): 12345678-1234-1234-1234-123456789604

Mogelijk geeft uw browser een melding over het ontbreken van een beveiligingscertificaat. U kunt dan kiezen voor de optie “Doorgaan naar deze website”.  \
Voor een goede werking van de demo van de BETA-versie adviseren we het gebruik van Chrome als browser.

Binnenkort komt gefaseerd beschikbaar:
* Meten functionaliteit, om afstanden te meten.
* Printen op basis van selectie van bijlagen of printen van alle bijlagen.
* Een Windows executable voor de installatie op een desktop.  

U kunt de ontwikkelingen van de Kadaster KLIC-viewer via de [geplande werkzaamheden](../KLIC%20-%20Geplande%20werkzaamheden.md) volgen op GitHub.
