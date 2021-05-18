# Overzicht basispaden voor endpoints KLIC API's

**Inhoudsopgave**

- [Inleiding](#inleiding)
- [Overzicht](#overzicht)
  - [B2B-koppeling actualiseren netinformatie](#b2b-koppeling-actualiseren-netinformatie)
  - [B2B-koppeling actualiseren documenten](#b2b-koppeling-actualiseren-documenten)
  - [B2B-koppeling beheerdersinformatie (BMKL 2.0)](#b2b-koppeling-beheerdersinformatie-bmkl-20)
  - [Data synchronisatie (Agentschap Telecom)](#data-synchronisatie-agentschap-telecom)
  - [Upload servlet](#upload-servlet)
  - [OAuth Authorization](#oauth-authorization)

---------------------------------------------------------
## Inleiding


|Waarschuwing:  Versie 1 van de API zal uit dienst worden genomen op 30 april 2022. Een nieuwe versie zal vanaf 3 januari 2022 beschikbaar worden gesteld op endpoints die hieronder worden genoemd. Zie ook [Gewijzigde BMKL.md](../Toekomstige%20wijzigingen/Toelichting%20specifieke%20onderwerpen/Implementatie%20upgrade%20KLIC%20standaarden/Gewijzigde%20BMKL.md) voor de wijzigingen ten opzichte van versie 1 |
|------------------------------|

 

De uitwisseling van informatie tussen KLIC en andere partijen in de graafketen verloopt steeds meer met behulp van API's.  \
Dit document geeft een overzicht van basispaden voor endpoints die worden gebruikt voor KLIC API's.

Bij de endpoints wordt onderscheid gemaakt tussen twee omgevingen:
- productieomgeving KLIC
- Netbeheerder Testdienst (NTD), een separate productieomgeving waar een netbeheerder de B2B-koppelingen kan testen 

Per te benaderen "resource" worden de endpoints samengesteld op basis van
- host name
- base url
- /resource (objectenstructuur)

De API voor de resource "gebiedsinformatieAanvragen" wordt bijvoorbeeld voluit voor de productieomgeving KLIC:  \
  "https://service10.kadaster.nl/klic/leveren/api/v2/web/gebiedsinformatieAanvragen" (beschikbaar tot 30 april 2022)

De documentatie over de werking van deze interfaces is beschikbaar in de vorm van Swagger specificatie. Deze documentatie is te vinden bij de “KLIC API documentatie”-applicatie die in de Netbeheerder Testdienst beschikbaar wordt gesteld.

Voor een meer uitgebreide documentatie en toelichting over de functionaliteit en werking van de verschillende B2B-koppelingen verwijzen we naar de betreffende hoofdstukken in de GitHub-documentatie.

---------------------------------------------------------
## Overzicht

### B2B-koppeling actualiseren netinformatie

Het actualiseren van netinformatie gebeurt op basis van de resource "aanleveringen/netinformatie".  \
Deze resource is benaderbaar met de volgende endpoints (host + base url):

|IMKL versie |Omgeving                      |Host                           |Base url                           | Beschikbaarheid    | 
|------------|------------------------------|-------------------------------|-----------------------------------|--------------------|
|v1.2.1      |Productieomgeving KLIC        | https://service10.kadaster.nl | /klic/actualiseren/api/v2/web     |  tot 30 april 2022 |
|v1.2.1      |Netbeheerder Testdienst (NTD) | https://service10.kadaster.nl | /klic/ntd/actualiseren/api/v2/web |  tot 30 april 2022 |
|v2.0        |Netbeheerder Testdienst (NTD) | https://service10.kadaster.nl | /klic/ntd/actualiseren/v2/        |  vanaf 20 mei 2021 |

Merk op dat de bestandsnaam voor aanleveringen volgens het IMKL versie 2.0 formaat, dient te eindigen op "_V2.zip".


### B2B-koppeling actualiseren documenten

Het actualiseren van documenten gebeurt op basis van de resource "aanleveringen/documenten".  \
Deze resource is benaderbaar met de volgende endpoints (host + base url):


|IMKL versie |Omgeving                      |Host                           |Base url                           | Beschikbaarheid    | 
|------------|------------------------------|-------------------------------|-----------------------------------|--------------------|
|v1.2.1      |Productieomgeving KLIC        | https://service10.kadaster.nl | /klic/actualiseren/api/v2/web     |  tot 30 april 2022 |
|v1.2.1      |Netbeheerder Testdienst (NTD) | https://service10.kadaster.nl | /klic/ntd/actualiseren/api/v2/web |  tot 30 april 2022 |
|v2.0        |Netbeheerder Testdienst (NTD) | https://service10.kadaster.nl | /klic/ntd/actualiseren/v2/        |  vanaf 20 mei 2021 |

Merk op dat documenten die via het V1-endpoint zijn opgeleverd, ook bruikbaar blijven vanuit aanleveringen in IMKL versie 2.0.


### B2B-koppeling beheerdersinformatie (BMKL 2.0)

De B2B-koppeling voor het afhandelen van gebiedsinformatie en beheerdersinformatie gebeurt met de resource "gebiedsinformatieAanvragen".  \
Deze resource-structuur is benaderbaar met de volgende endpoints (host + base url):

|IMKL versie |Omgeving                      |Host                           |Base url                      | Beschikbaarheid    | 
|------------|------------------------------|-------------------------------|------------------------------|--------------------|
|v1.2.1      |Productieomgeving KLIC        | https://service10.kadaster.nl | /klic/leveren/api/v2/web     |  tot 30 april 2022 |
|v1.2.1      |Netbeheerder Testdienst (NTD) | https://service10.kadaster.nl | /klic/ntd/leveren/api/v2/web |  tot 30 april 2022 |
|v2.0        |Netbeheerder Testdienst (NTD) | https://service10.kadaster.nl | /klic/ntd/bmkl/v2/           |  vanaf 20 mei 2021 |

Merk op dat de bestandsnaam voor aanleveringen volgens het IMKL versie 2.0 formaat, dient te eindigen op "_V2.zip".

### Data synchronisatie (Agentschap Telecom)

Voor data synchronisatie ten behoeve van Agentschap Telecom worden de API's voor de resource "gebiedsinformatieAanvragen" gebruikt.  \
Zie daarvoor [B2B-koppeling beheerdersinformatie (BMKL 2.0)](#b2b-koppeling-beheerdersinformatie-bmkl-20).

Het opvragen van stamgegevens van netbeheerders gebeurt op basis van de resource "organisaties".
Deze resource is benaderbaar met de volgende endpoints (host + base url):

|IMKL versie |Omgeving                      |Host                           |Base url                      | Beschikbaarheid    | 
|------------|------------------------------|-------------------------------|------------------------------|--------------------|
|v1.2.1      |Productieomgeving KLIC        | https://service10.kadaster.nl | /klic/leveren/api/v2/web     |  tot 30 april 2022 |
|v1.2.1      |Netbeheerder Testdienst (NTD) | https://service10.kadaster.nl | /klic/ntd/leveren/api/v2/web |  tot 30 april 2022 |


### Upload servlet

Het endpoint voor het (in fragmenten) uploaden van data ("Upload servlet") wordt teruggegeven bij het verzoek om netinformatie of documenten te actualiseren.

Het uploaden gebeurt met de resource "upload".
Deze resource is benaderbaar met de volgende endpoints (host + base url):

|IMKL versie |Omgeving                      |Host                           |Base url                                  | Beschikbaarheid    | 
|------------|------------------------------|-------------------------------|------------------------------------------|--------------------|
|v1.2.1      |Productieomgeving KLIC        | https://service10.kadaster.nl | /klic/actualiseren/upload/api/v2/web     |  tot 30 april 2022 |
|v1.2.1      |Netbeheerder Testdienst (NTD) | https://service10.kadaster.nl | /klic/ntd/actualiseren/upload/api/v2/web |  tot 30 april 2022 |

### OAuth Authorization

Het OAuth Authorization endpoint voor alle KLIC-omgevingen is:
- https://authorization.kadaster.nl/auth/oauth/v2/