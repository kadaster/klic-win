#### Aanvragen gebiedsinformatie - Schema's

Voor het gebruik van de B2B-koppeling voor aanvragen van gebiedsinformatie zijn schema-definities ("XSD's") opgesteld.  \
In het document [Schemawijzigingen KLIC B2B-aanvraag](Schemawijzigingen%20KLIC%20B2B-aanvraag.md) wordt een overzicht gegeven van de recente wijzigingen in deze schema-definities.

Deze B2B-koppeling is momenteel geimplementeerd op basis van het SOAP-protocol en kent onderstaande interfaces:
- _KlicB2BAanvraag_ (KlicB2BAanvraag-1.2.xsd)  \
voor het aanvragen van gebiedsinformatie.
- _KlicB2BOrderbevestiging_ (KlicB2BOrderbevestiging-1.0.xsd)  \
voor het terugkoppelen door het Kadaster van order-informatie van een succesvolle aanvraag.  \
Als er fouten worden geconstateerd, worden deze hiermee ook teruggekoppeld.
- _KlicB2BBetrokkenBeheerders_ (KlicB2BBetrokkenBeheerders-1.1.xsd)  \
voor een overzicht van beheerders met een belang bij een calamiteitenmelding.

De interfaces van de webservices voor het gebruik van deze KLIC B2B-koppeling zijn beschreven in onderstaande WSDL's (Web Service Description Language):
- _KlicB2BAanvraag-1.2.wsdl_  \
bericht van de aanvrager naar Kadaster KLIC voor het aanvragen van gebiedsinformatie ("KLIC-melding").
- _KlicB2B-terugkoppeling-1.1.wsdl_  \
met berichten van Kadaster KLIC naar de aanvrager (orderbevestiging en eventueel overzicht betrokken beheerders).
- _KlicB2BTestAanvraag-1.1.wsdl_  \
bericht van de aanvrager naar Kadaster KLIC voor het testen van het (technische) koppelvlak met het Kadaster.

De definities van de vorige versie zijn te vinden in de submap: [Aanvragen gebiedsinformatie/Schemas/KLIC B2B-terugkoppeling 1.0](../../../../tree/master/Aanvragen%20gebiedsinformatie/Schemas/KLIC%20B2B-terugkoppeling%201.0).


De wijzigingen tussen de verschillende versies en een toelichting over de overgang naar de nieuwste versie is te vinden in: [Schemawijzigingen KLIC B2B-aanvraag.md](Schemawijzigingen%20KLIC%20B2B-aanvraag.md)