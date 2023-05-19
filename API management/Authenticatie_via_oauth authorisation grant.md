# Authenticatie via OAuth voor de KLIC API's

De KLIC REST API's zijn beveiligd middels de [OAuth 2.0](https://oauth.net/2/) specificatie.
Dit document biedt een handleiding voor het aansluiten op de KLIC API's met OAuth.

**Inhoudsopgave**
- [Interactief of Machine to machine](#interactief-of-machine-to-machine)  
- [Werking](#werking)
- [Client Applicatie aanmelden](#client-applicatie-aanmelden)
- [Scopes](#scopes)
- [Authorization token opvragen](#authorization-token-opvragen)
- [Access token opvragen](#access-token-opvragen)
- [Access token gebruiken](#access-token-gebruiken)
- [Access token verversen](#access-token-verversen)
- [Voorbeeld client applicatie](#voorbeeld-client-applicatie)

#### Interactief of machine to machine
Het gebruik vn de KLIC REST API's kunnen we opdelen in 2 scenario's
* **interactief gebruik**: Hierbij wordt de API gebruikt door gebruiker via een client applicatie. Bijvoorbeeld een beheer applicatie bij een netbeheerder. Voor dit scenario gebruiken we de OAuth Authorisation grant flow. De werking van de Authorisation grant is in dit document beschreven.
* **Machine to machine**: Hierbij wordt de API gebruikt door een geautomatiseerd proces. Bijvoorbeeld een server proces waarmee gebiedsinformatie aanvragen verwerkt worden of netinformatie geactualiseerd wordt. Voor dit scenario gebruiken we de OAuth Client credentials flow. Voor de werking van de client credentials flow zie [Client credentials](Authenticatie_via_oauth%20Client%20Credentials.md)

#### Werking (interactief gebruik)

Bij elk request naar een API endpoint moet een access token in de header van het request meegestuurd worden. Om dit token te verkrijgen moeten onderstaande stappen doorlopen worden.
 
1. Client Applicatie aanmelden. Dit moet éénmalig per client apllicatie gedaan worden.   
2. Authorization token opvragen. Dit moet éénmalig per gebruiker gedaan worden.
3. Access token opvragen. Dit token geeft toegang tot de API. Dit token is één uur geldig en zal daarna ververst moeten worden.  
4. Access token verversen. Als het access token verlopen is kan deze ververst worden. Daarvoor hoeven stap 1 t/m 3 niet opnieuw doorlopen te worden.
<img src="images/oauth_klic.png" />


#### Client Applicatie aanmelden

Voordat u kunt beginnnen met testen van uw applicatie dient u deze aan te melden bij het kadaster. Dit kan via een formulier op de kadaster website. Dit formulier vindt u op https://formulieren.kadaster.nl/klic-oauth.

Na goedkeuring van de aanvraag krijgt u een client_id en client_secret.

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
Deze klic.ntd.*-scopes mogen niet gebruikt worden bij requests naar de productieomgeving.


#### Authorization token opvragen
Rechten voor gebruik van de API endpoints zijn gekoppeld aan mijn kadaster accounts. De gebruiker zal de client applicatie hiervoor éénmalig toestemming moeten geven door in te loggen via mijn kadaster.  
Ga naar: https://authorization.kadaster.nl/auth/oauth/v2/authorize?response_type=code&client_id=[client_id]&client_secret=[client_secret]&redirect_uri=[redirect_uri]&scope=[scope]  

De gebruiker kan kiezen voor inloggen met een eHerkenning of een mijn kadaster account.  
<img src="images/loginkeuze.png"/>

<img src="images/logink.png" /> of <img src="images/logineh.png" />

Na het inloggen verschijnt onderstaand scherm:

<img src="images/consent.png" />

Klik op **GRANT** als de gegevens kloppen.


De gebruiker wordt daarna doorgestuurd naar de redirect_uri. Uit de request parameters kan de authorization code gehaald worden.
Bijvoorbeeld:    
http://localhost:14057/authorize/?code=42283687-7c09-4018-8a7a-9e9533366dbb 
Deze code is 30 seconden geldig, haal daarom direct daarna een access code op.  

#### Access token opvragen

Met het client id, client secret en authorization token kunnen we een access token opvragen.  
**request (POST)**    
***URL***: https://authorization.kadaster.nl/auth/oauth/v2/token  
***Header***: Geef in de header als ContentType `application/x-www-form-urlencoded` mee.  
***Body***: De parameters moeten in de body meegegeven worden. Zie voorbeeld:
```
client_id=[client_id]&client_secret=[client_secret]&grant_type=authorization_code&code=[authorisation_token]&redirect_uri=[redirect_url]
```

**response**  
```json
{
    "access_token": "9e25ab45-82a4-4f9e-8bf6-b9ef0eb7568e",
    "token_type": "Bearer",
    "expires_in": 3600,
    "refresh_token": "a413b322-59ab-4573-dd0b-000547d929b3",
    "scope": "klic.ntd.centraal"
}
```
Dit access token en refresh token moet door de client apllicatie op een veilige manier bewaard worden.
Het access token moet meegestuurd worden bij elke call naar de Klic API.   

#### Access token gebruiken
Een voorbeeld van een API call met access token via curl.
```sh
curl
--header 'Authorization: Bearer 9e25ab45-82a4-4f9e-8bf6-b9ef0eb7568e'
https://service10.kadaster.nl/klic/api/v2/gebiedsInformatieAanvragen/netbeheerder/?aanvraagSoort=graafmelding&biNotificatieStatus=open&limiet=50
```

#### Access token verversen
Het access token is 1 uur geldig. Als het access token verlopen is dan kan een nieuw access token en refresh token opgevraagd worden.  
**request (POST)**    
***URL***: https://authorization.kadaster.nl/auth/oauth/v2/token  
***Header***: Geef in de header als ContentType `application/x-www-form-urlencoded` mee.  
***Body***: De parameters moeten in de body meegegeven worden. Zie voorbeeld:
```
client_id=[client_id]&client_secret=[client_secret]&grant_type=refresh_token&refresh_token=[refresh_token]  
```

**response**
```json
{
    "access_token": "eb7929c4-4259-442c-931f-14fba228a6aa",
    "token_type": "Bearer",
    "expires_in": 3600,
    "refresh_token": "29786b93-24ca-4e91-9c8c-b87715f48ba9",
    "scope": "klic.ntd.centraal"
}
```
### Voorbeeld client applicatie

Er is een voorbeeld client applicatie in c# beschikbaar op [KlicOauthExample](/API%20management/Voorbeelden/KlicOauthExample).
