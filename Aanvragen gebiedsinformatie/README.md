#### Aanvragen gebiedsinformatie

Het aanvragen van gebiedsinformatie over kabels en leidingen is in de volksmond beter bekend als het opvoeren van een "KLIC-melding".
Met de geleverde gebiedsinformatie krijgt de aanvrager of grondroerder inzage in de ligging van kabels en leidingen.

Een aanvrager heeft - vanuit het perspectief van het KLIC-systeem - de volgende mogelijkheden om een aanvraag in te dienen:
- met de KLIC-online applicatie; een grafisch userinterface (GUI) om de specificaties van de aanvraag in te geven
- met een B2B-koppeling; een SOAP-interface waarmee de aanvraag wordt ingediend (ook wel: KLIC B2B-aanvraag)

Veel informatie over deze functionaliteit is gepubliceerd op de KLIC-pagina's van de Kadaster website. Zie: https://www.kadaster.nl/KLIC.

De toelichting op de werking van de KLIC B2B-aanvraag is te vinden op deze GitHub-pagina's.  \
In het kader van het programma KLIC-WIN worden er ook veranderingen doorgevoerd bij het aanvragen van gebiedsinformatie. In deze map worden hierover documentatie en diverse voorbeelden beschikbaar gesteld.  \
De beschikbaar gestelde functionaliteit zal zich steeds verder ontwikkelen op basis van een Agile-aanpak.  \
Op [deze GitHub pagina](Schemas/Schemawijzigingen%20KLIC%20B2B-aanvraag.md) is de fasering te vinden.

Deze map bevat:
* B2B-koppeling voor afhandelen gebiedsinformatie-aanvraag 
  * [B2B-koppeling gebiedsinformatie-aanvraag (KLIC B2B-aanvraag)](B2B-koppeling%20gebiedsinformatie-aanvraag%20(KLIC%20B2B-aanvraag).md)  \
een technische notitie die het koppelvlak beschrijft tussen externe systemen en Kadaster KLIC voor het aanvragen van gebiedsinformatie door middel van een SOAP-interface.
  * [Controles B2B-koppeling gebiedsinformatie-aanvraag](Controles%20B2B-koppeling%20gebiedsinformatie-aanvraag.md)  \
een overzicht van de validaties op de ingediende aanvragen, inclusief de wijzigingen voor versie 1.1
* map met schemadefinities (XSD's, WSDL's)
  * hierbij worden de wijzigingen voor de nieuwe versies uitgebreid toegelicht
* map met diverse voorbeelden, waaronder
  * gebruik KlicB2BAanvraag, versie 1.1
  * gebruik KlicB2BBetrokkenBeheerders, versie 1.1