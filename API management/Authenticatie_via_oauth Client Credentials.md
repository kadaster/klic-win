# Authenticatie via OAuth Client Credentials voor de KLIC API's

De KLIC REST API's zijn beveiligd middels de [OAuth 2.0](https://oauth.net/2/) specificatie.
Dit document biedt een handleiding voor het aansluiten op de KLIC API's met OAuth.

**Inhoudsopgave**
- [Interactief of machine to machine](#interactief-of-machine-to-machine)
- [Client Applicatie aanmelden](#client-applicatie-aanmelden)
- [Scopes](#scopes)
- [JWT client assertion](#jwt-client-assertion)
- [Access token opvragen](#access-token-opvragen)
- [Access token gebruiken](#access-token-gebruiken)
- [Access token verversen](#access-token-verversen)
- [Voorbeeld code jwt genereren](#voorbeeld-code-jwt-genereren)

#### Interactief of machine to machine
Het gebruik vn de KLIC REST API's kunnen we opdelen in 2 scenario's
* **interactief gebruik**: Hierbij wordt de API gebruikt door gebruiker via een client applicatie. Bijvoorbeeld een beheer applicatie bij een netbeheerder. Voor dit scenario gebruiken we de OAuth Authorisation grant flow. Voor de werking van de Authorisation grant flow zie [Authorisation grant](Authenticatie_via_oauth%20authorisation%20grant.md)
* **Machine to machine**: Hierbij wordt de API gebruikt door een geautomatiseerd proces. Bijvoorbeeld een server proces waarmee gebiedsinformatie aanvragen verwerkt worden of netinformatie geactualiseerd wordt. Voor dit scenario gebruiken we de OAuth Client credentials flow. De werking daarvan is in dit document beschreven.

#### Werking (machine to machine)

Bij elk request naar een API endpoint moet een access token in de header van het request meegestuurd worden. Om dit token te verkrijgen moeten onderstaande stappen doorlopen worden.
 
1. Client Applicatie aanmelden. Dit moet éénmalig per client apllicatie gedaan worden.   
2. Access token opvragen. Dit token geeft toegang tot de API. Dit token is één uur geldig en zal daarna ververst moeten worden.  

<img src="images/oauth_algemeen_CC.png" />

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
Deze klic.ntd.*-scopes mogen niet gebruikt worden bij requests naar de productieomgeving.


#### JWT client assertion

(stap 1,2) 

Om een access token te verkrijgen dient een JWT (client assertion) samengesteld te worden welke met het PKIoverheid certificaat van de organisatie wordt ondertekend. Ter controle van de signature van het JWT dient een JWKS (idealiter via een endpoint) beschikbaar gesteld te zijn met het publieke certificaat. Het PKIoverheid certificaat moet vallen in de Hiërarchie: Staat der Nederlanden Private Root CA - G1. Tevens dient het organisatie OIN te zijn opgenomen in het subject en dit OIN in de Kadaster klant registratie bekend te zijn.

Validatie van het JWT word gedaan adhv de signature en de volgende claims worden geverifieerd:
* **iss** *(issuer): moet gelijk zijn aan het client id*
* **aud** *(audience): moet gelijk zijn aan het authorization server token endpoint (zonder protocol, inclusief port): authorization.kadaster.nl:443/auth/oauth/v2/token*
* **sub** *(subject): moet gelijk zijn aan het client id*
* **exp** *(expiry time): moet in de toekomst liggen (een korte expiry van enkele minuten is aanbevolen)*
* **jti** *(jwt id): word gecached tot de expiry time en hierop word replay attack protection uitgevoerd (een jwt kan dus slechts eenmalig worden gebruikt!)*

Voorbeeld JWT claims:

header:
```json
 {
   "typ": "JWT",
   "alg": "RS256",
   "kid": "<the key id from the jwks>"
 }
``` 
payload:
```json
 {
   "iss": "<client_id>",
   "sub": "<client_id>",
   "aud": "authorization.kadaster.nl:443/auth/oauth/v2/token",
   "exp": 1645632001,
   "nbf": 1645628101,
   "iat": 1645628401,
   "jti": "e43cf74c-d278-4b34-8d49-b08e7a52b216"
 }
```



#### Access token opvragen

De client kan vervolgens met het JWT client assertion een access token opvragen door een post op het token endpoint en de juiste headers en content:  
**request (POST)**    
***URL***: https://authorization.kadaster.nl/auth/oauth/v2/token  
***Header***: Geef in de header als ContentType `application/x-www-form-urlencoded` mee.  
***Body***: De parameters moeten in de body meegegeven worden. Zie voorbeeld:
```
grant_type=client_credentials&scope=<scope(s)&client_assertion=<jwt assertion>&client_assertion_type=urn%3Aietf%3Aparams%3Aoauth%3Aclient-assertion-type%3Ajwt-bearer
```

Het token endpoint zal hierop het JWT client assertion valideren en een response geven met daarin een access token.

**response**  
```json
{
    "access_token": "9e25ab45-82a4-4f9e-8bf6-b9ef0eb7568e",
    "token_type": "Bearer",
    "expires_in": 3600,
    "scope": "klic.ntd.centraal"
}
```
Dit access token moet door de client apllicatie op een veilige manier bewaard worden. Het access token moet meegestuurd worden bij elke call naar de API.   

De signature van de JWT wordt gecontroleerd aan de hand van de bij de client geconfigureerde JWKS (idealiter dynamisch adhv de jwks uri opgehaald). De kid in de header van de jwt geeft aan met welke key de signing is uitgevoerd en komt overeen met een kid in het jwks. Het gebruikte certificaat zal worden gecontroleerd op geldigheid en zal onderdeel moeten zijn van de **PKIoverheid chain** en het **OIN  in de Kadaster klant registratie** te zijn opgenomen.

https://datatracker.ietf.org/doc/html/rfc7517

Voorbeeld jwks:
```json
 {
   "keys": [
     {
       "alg": "RS256",
       "e": "AQAB",
       "n": "<...cut her for readability...>-gTlQ",
       "kty": "RSA",
       "kid": "oude_nog_geldige_key",
       "x5c": [
                "MIIG<...cut her for readability...>TbQjZh0i"
            ],
     },
     {
       "alg": "RS256",
       "e": "AQAB",
       "n": "<...cut her for readability...>-gTlQ",
       "kty": "RSA",
       "kid": "nieuwe_ook_geldige_key",
       "x5c": [
                "MIIG<...cut her for readability...>TbQjZh0i"
            ],
     }
   ]
}

```

#### Access token gebruiken
Een voorbeeld van een API call met access token via curl.
```sh
curl
--header 'Authorization: Bearer 9e25ab45-82a4-4f9e-8bf6-b9ef0eb7568e'
https://service10.kadaster.nl/klic/api/v2/gebiedsInformatieAanvragen/netbeheerder/?aanvraagSoort=graafmelding&biNotificatieStatus=open&limiet=50
```

#### Access token opnieuw opvragen
Het access token is 1 uur geldig. Als het access token verlopen is dan kan een weer nieuw access token  opgevraagd worden zoals beschreven onder 'Access token opvragen'.  

### Voorbeeld code jwt genereren

Voorbeeld code voor het genereren van JWKS en JWT in java is beschikbaar op [KlicOauth_CC_JWT_Example](/API%20management/Voorbeelden/KlicOauth_CC_JWT_Example).
