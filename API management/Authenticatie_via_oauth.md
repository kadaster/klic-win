# Authenticatie via OAuth Client Credentials voor de KLIC API's

De KLIC REST API's zijn beveiligd middels de [OAuth 2.0](https://oauth.net/2/) specificatie.
Dit document biedt een handleiding voor het aansluiten op de KLIC API's met OAuth.

**Inhoudsopgave**
- [Interactief of machine to machine](#interactief-of-machine-to-machine)
- [Client Applicatie aanmelden](#client-applicatie-aanmelden)
- [Scopes](#scopes)

#### Interactief of machine to machine
Het gebruik van de KLIC REST API's kunnen we opdelen in 2 scenario's
* **interactief gebruik**: Hierbij wordt de API gebruikt door gebruiker via een client applicatie. Bijvoorbeeld een beheer applicatie bij een netbeheerder. Voor dit scenario gebruiken we de OAuth Authorisation grant flow. Voor de werking van de Authorisation grant flow zie [Authorisation grant](Authenticatie_via_oauth%20authorisation%20grant.md)
* **Machine to machine**: Hierbij wordt de API gebruikt door een geautomatiseerd proces. Bijvoorbeeld een server proces waarmee gebiedsinformatie aanvragen verwerkt worden of netinformatie geactualiseerd wordt. Voor dit scenario gebruiken we de OAuth Client credentials flow. Voor de werking van de client credentials flow zie [Client credentials](Authenticatie_via_oauth%20Client%20Credentials.md)

#### Client Applicatie aanmelden

Voordat u kunt beginnnen met testen van uw applicatie dient u deze aan te melden bij het kadaster. Dit kan via een formulier op de kadaster website. Dit formulier vindt u op https://formulieren.kadaster.nl/klic-oauth.

Na goedkeuring van de aanvraag krijgt u een client_id.

U dient eerst een client registratie aan te vragen voor de Netbeheerder Testdienst (NTD). Na een succesvolle test in de NTD kunt u gaan aansluiten op [KLIC](https://www.kadaster.nl/zakelijk/informatie-per-sector/startpagina-netbeheerders/aansluiten-netbeheerder).
Na binnenkomst van het aansluitformulier zullen de scopes worden uitgebreid op dezelfde Client ID die u voor de NTD gebruikt.

#### Scopes

Voor de KLIC API kennen we voor de productieomgeving de volgende scopes:

|Scope                                      |Omschrijving	                                                                           |
|-------------------------------------------|------------------------------------------------------------------------------------------|	
|klic.centraal                              |Actualiseren van netinformatie, documenten, voorzorgsmaatregelen tbv centrale voorziening |
|klic.gebiedsinformatieaanvraag.readonly    |Opvragen gebiedsinformatie-aanvragen (door aanvrager of belanghebbende beheerder)	       |
|klic.beheerdersinformatie                  |Aanleveren en opvragen eigen beheerdersinformatie (decentraal)	                           |
|klic.beheerdersinformatie.readonly         |Inzien eigen beheerdersinformatie                                                         |
|klic.toezicht                              |Inzien gebiedsdinformatie en beheerdersinformatie                                         |

Voor de Netbeheerder Testdienst (NTD) kennen onderstaande corresponderende scopes:

|Scope (NTD)                                |Omschrijving	                                                                           |
|-------------------------------------------|------------------------------------------------------------------------------------------|	
|klic.ntd.centraal                          |Actualiseren van netinformatie, documenten, voorzorgsmaatregelen tbv centrale voorziening |
|klic.ntd.gebiedsinformatieaanvraag.readonly|Opvragen gebiedsinformatie-aanvragen (door aanvrager of belanghebbende beheerder)	       |
|klic.ntd.beheerdersinformatie              |Aanleveren en opvragen eigen beheerdersinformatie (decentraal)	                           |
|klic.ntd.beheerdersinformatie.readonly     |Inzien eigen beheerdersinformatie                                                         |
|klic.ntd.toezicht                          |Inzien gebiedsdinformatie en beheerdersinformatie                                         |

De klic.ntd.*-scopes geven toegang tot de Netbeheerder Testdienst (NTD). Deze scope moet dus toegevoegd worden voor testen in de NTD.  \
Deze klic.ntd.*-scopes geven geen toegang bij requests naar de productieomgeving.


