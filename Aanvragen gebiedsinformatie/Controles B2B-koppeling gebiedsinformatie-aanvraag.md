# Validaties bij B2B-koppeling gebiedsinformatie-aanvraag

Het systeem van een aanvrager kan met een B2B-koppeling een gebiedsinformatie-aanvraag ("Klic-melding") aanbieden aan Kadaster-KLIC. Deze interface is momenteel nog gebaseerd op een SOAP-protocol.

Het aanvragen van gebiedsinformatie gebeurt met een _KlicB2BAanvraag_-bericht. Deze interface wordt binnenkort uitgebreid.  \
Hieronder wordt een overzicht gegeven van de belangrijkste wijzigingen op de validaties die worden uitgevoerd bij een B2B-aanvraag.

**Controle minimaal één type soort werkzaamheden bij graafmelding en oriëntatieverzoek**:
- Bij het opvoeren van een graafmelding of oriëntatieverzoek moet er altijd minimaal één soort werkzaamheden worden opgegeven. Tevens is het geven van een toelichting van de werkzaamheden alleen mogelijk als er minimaal één soort werkzaamheden is opgegeven. Dit geld voor aanvragen via de web applicatie Klic-online en aanvragen via een B2B aanvraag-kanaal. (ID 2533)

## B2BAanvraag, wijzigingen versie 1.1

### Soort werkzaamheden
Bij een graafmelding en een oriëntatieverzoek moet er altijd minimaal één soort werkzaamheden (in `SoortWerkzaamheden`) worden opgegeven.
Deze verplichting is gesteld, omdat mogelijke eis voorzorgsmaatregelen mede worden bepaald op basis van de aangegeven soorten werkzaamheden.  \
Tevens is het geven van een toelichting op de werkzaamheden (in `Notitie`) alleen mogelijk als er minimaal één soort werkzaamheden is opgegeven.

### Dichtstbijzijnd adres (DAS)

Een dichtstbijzijnd adres kan worden geidentificeerd met een `IdentificatieBAG`.  \
Hierbij wordt aangesloten op het stelsel van basisregistraties, waarbij een gegeven maar op één plek wordt geidentificeerd en beschikbaar gesteld, in dit geval de BAG (Basisregistratie Adressen en Gebouwen).  \
Deze `IdentificatieBAG` is in BAG vastgelegd als identificatie van een adresseerbaar object (_Verblijfsobject_, _Ligplaats_ of _Standplaats_).

De identificatie is leidend voor de verwerking van een Klic-aanvraag.  \
Als er van een dichtstbijzijnd adres een `IdentificatieBAG` wordt meegegeven, wordt gecontroleerd of hiervan een bijbehorend adresseerbaar object kan worden gevonden in BAG. Als er ook overige adresgegevens zijn meegegeven, dan moeten deze exact overeenstemmen met het hoofdadres van het adresseerbare object.  \
Is er geen `IdentificatieBAG` meegegeven, dan moeten minimaal een `huisnummer` en `postcode` worden meegegeven voor de bepaling van een geldig dichtstbijzijnd adres.
Het controleren van hiervoor een geldig adres kan worden gevonden in BAG en de bepaling van (een) corresponderend BAGid van adresseerbare object(en) is reeds bestaande functionaliteit.

Als er van een dichtstbijzijnd adres een `IdentificatieBAG` wordt meegegeven, hoeven geen overige adresgegevens te worden meegegeven. Het eventueel meegegeven adres moet het hoofdadres zijn van het adresseerbare object en overeenstemmen met de adresgegevens zoals deze in BAG zijn vastgelegd.
Is er geen `IdentificatieBAG` meegegeven, dan moeten minimaal een `huisnummer` en `postcode` worden meegegeven voor de bepaling van een geldig dichtstbijzijnd adres.

### Huisaansluitschets-adres (HAS)

Ook een huisaansluitschets-adres kan worden geidentificeerd met een `IdentificatieBAG`.  \
De identificatie is leidend voor de verwerking van een Klic-aanvraag.

Het gebruik en de controles van adresgegevens die een huisaansluitschets-adres specificeren, is gelijksoortig aan de werking bij een dichtstbijzijnd adres. Zie [Dichtstbijzijnd adres (DAS)](#dichtstbijzijnd-adres-das).

### Voorbereiding medegebruik fysieke infrastructuur _en_
### Voorbereiding coordinatie civiele werken

In het kader van de EU-stimulering breedband (nieuwe WIBON-regelgeving) kan er een specifiek orientatieverzoek worden gedaan:
- ter voorbereiding op een verzoek tot medegebruik van fysieke infrastructuur (`VoorbereidingMedegebruikFysiekeInfrastructuur`), of
- ter voorbereiding op een verzoek tot coordinatie van civiele werken (`VoorbereidingCoordinatieCivieleWerken`).

Deze velden mogen alleen worden gebruikt bij een orientatieverzoek.  \
Slechts één van deze velden mag geselecteerd worden.
Als een van deze velden wordt gebruikt, mogen geen soorten werkzaamheden worden opgegeven.

### Kamer van Koophandel (KvK) nummer van aanvrager

In de nieuwe versie van het interface kan het `KvkNummer` (Kamer van Koophandel) van de aanvrager (klant) van de aanvraag worden meegegeven.  \
Voorlopig zal dit veld nog niet gebruikt worden in het Klic-proces.  \
Er wordt ook niet gecontroleerd of een eventueel ingevuld KvK-nummer bestaat in de NHR-registratie en geldend is voor de aanvragende organisatie.

Op termijn zal het KvK-nummer worden overgenomen uit het klantenbeheer-systeem van Kadaster-KLIC.

### Kamer van Koophandel (KvK) nummer van opdrachtgever

In de nieuwe versie van het interface kan - in geval van een graafmelding - ook het `KvkNummer` (Kamer van Koophandel) van de opdrachtgever worden meegegeven.  \
Voorlopig zal dit veld nog niet gebruikt worden in het Klic-proces.  \
Er wordt ook niet gecontroleerd of een eventueel ingevuld KvK-nummer bestaat in de NHR-registratie en geldend is voor de opdrachtgevende organisatie.

Het KvK-nummer van opdrachtgevers is niet bekend bij het Kadaster-KLIC.

### Informatiepolygoon

Voor een graafmelding en een calamiteitenmelding gaat de mogelijkheid worden geboden om rond het graafgebied een ruimer gebied aan te geven waarover informatie wordt gewenst. Dit gebied wordt gespecificeerd met een `informatiepolygoon`.  \
Een opgegeven informatiegebied moet een graafgebied volledig omvatten: niets van de graafpolygoon mag buiten de informatiepolygoon liggen.

De volgende validaties zijn van toepassing:  \
|Validatie                             | Omschrijving                                                                                                                                                        |
|--------------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------|
|Type aanvraagsoort                    | Informatiepolygoon alleen bij graafmelding en calamiteitenmelding (niet bij oriëntatieverzoek).                                                                     |
|Geometrisch valide                    | Geometrische afspraken die van toepassing zijn op graafpolygoon gelden ook voor informatiepolygoon, denk aan kruisende lijnen, geen gaten.                          |
|Geen decimalen                        | Net als een graafpolygoon is het voor de coordinaten van een informatiepolygoon alleen toegestaan om deze in gehele meters op te geven; decimalen niet toegestaan.  |
|Maximale omvang                       | Net als een graafpolygoon mag de informatiepolygoon maximaal 500x500 meter zijn.                                                                                    | 
|Maximale aantal punten                | De informatiepolygoon mag uit maximaal 200 punten bestaan.                                                                                                          |
|Relatie met graafpolygoon             | Niets van de graafpolygoon ligt buiten informatiepolygoon.                                                                                                          |
|Maximale afstand t.o.v. graafpolygoon | Maximale afstand tot de graafpolygoon is 100 meter, waarbij het toegestaan is dat eventuele gaten gevuld worden.                                                    |
|Alleen eenvoudige informatiebuffer    | Als de combinatie van graafpolygoon en informatiepolygoon leiden tot een `geometrieVoorVisualisatie` die een meervoudig polygoon is, wordt de aanvraag afgekeurd.   |


