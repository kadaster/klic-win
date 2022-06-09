# Overzicht basispaden voor endpoints KLIC API's

**Inhoudsopgave**

- [Inleiding](#inleiding)
- [Overzicht](#overzicht)
  - [B2B-koppeling actualiseren netinformatie](#b2b-koppeling-actualiseren-netinformatie)
  - [B2B-koppeling actualiseren documenten](#b2b-koppeling-actualiseren-documenten)
  - [B2B-koppeling beheerdersinformatie (BMKL 2.1)](#b2b-koppeling-beheerdersinformatie-bmkl-21)
  - [Data synchronisatie (Agentschap Telecom)](#data-synchronisatie-agentschap-telecom)
  - [Upload servlet](#upload-servlet)
  - [OAuth Authorization](#oauth-authorization)

---------------------------------------------------------
## Inleiding



De uitwisseling van informatie tussen KLIC en andere partijen in de graafketen verloopt steeds meer met behulp van API's.  \
Dit document geeft een overzicht van basispaden voor endpoints die worden gebruikt voor KLIC API's.

Bij de endpoints wordt onderscheid gemaakt tussen twee omgevingen:
- Productieomgeving KLIC
- Netbeheerder Testdienst (NTD), een separate productieomgeving waar een netbeheerder de B2B-koppelingen kan testen 

Per te benaderen "resource" worden de endpoints samengesteld op basis van
- host name
- base url
- /resource (objectenstructuur)

De API voor de resource `gebiedsinformatieAanvragen` wordt bijvoorbeeld voluit voor de productieomgeving KLIC:  \
   "https://service10.kadaster.nl/klic/bmkl/v2/gebiedsinformatieAanvragen" 

De documentatie over de werking van deze interfaces is beschikbaar in de vorm van Swagger specificatie. Deze documentatie is te vinden bij de “KLIC API documentatie”-applicatie die in de Netbeheerder Testdienst beschikbaar wordt gesteld.

Voor een meer uitgebreide documentatie en toelichting over de functionaliteit en werking van de verschillende B2B-koppelingen verwijzen we naar de betreffende hoofdstukken in de GitHub-documentatie.

---------------------------------------------------------
## Overzicht

### B2B-koppeling actualiseren netinformatie

Het actualiseren van netinformatie gebeurt op basis van de resource `aanleveringen/netinformatie`.  \
Deze resource is benaderbaar met de volgende endpoints (host + base url):

|IMKL versie |Omgeving                      |Host                           |Base url                           | Beschikbaarheid    | 
|------------|------------------------------|-------------------------------|-----------------------------------|--------------------|
|v2.0        |Productieomgeving KLIC        | https://service10.kadaster.nl | /klic/actualiseren/v2/            |  vanaf 3 januari 2022 |
|v2.0        |Netbeheerder Testdienst (NTD) | https://service10.kadaster.nl | /klic/ntd/actualiseren/v2/        |  vanaf 20 mei 2021 |

Merk op dat de bestandsnaam voor aanleveringen volgens het IMKL versie 2.0 formaat, dient te eindigen op "_V2.zip".


### B2B-koppeling actualiseren documenten

Het actualiseren van documenten gebeurt op basis van de resource `aanleveringen/documenten`.  \
Deze resource is benaderbaar met de volgende endpoints (host + base url):


|IMKL versie |Omgeving                      |Host                           |Base url                           | Beschikbaarheid    | 
|------------|------------------------------|-------------------------------|-----------------------------------|--------------------|
|v2.0        |Productieomgeving KLIC        | https://service10.kadaster.nl | /klic/actualiseren/v2/            | vanaf 3 januari 2022 |
|v2.0        |Netbeheerder Testdienst (NTD) | https://service10.kadaster.nl | /klic/ntd/actualiseren/v2/        |  vanaf 20 mei 2021 |

Merk op dat documenten die via het V1-endpoint zijn opgeleverd, ook bruikbaar blijven vanuit aanleveringen in IMKL versie 2.0.


### B2B-koppeling beheerdersinformatie (BMKL 2.1)

De B2B-koppeling voor het afhandelen van gebiedsinformatie en beheerdersinformatie gebeurt met de resource `gebiedsinformatieAanvragen`.  \
Deze resource-structuur is benaderbaar met de volgende endpoints (host + base url):

|IMKL versie |Omgeving                      |Host                           |Base url                      | Beschikbaarheid    | 
|------------|------------------------------|-------------------------------|------------------------------|--------------------|
|v2.0        |Productieomgeving KLIC        | https://service10.kadaster.nl | /klic/bmkl/v2/               |  vanaf 3 januari 2022 |
|v2.0        |Netbeheerder Testdienst (NTD) | https://service10.kadaster.nl | /klic/ntd/bmkl/v2/           |  vanaf 20 mei 2021 |

Merk op dat de bestandsnaam voor aanleveringen volgens het IMKL versie 2.0 formaat, dient te eindigen op "_V2.zip".

### Data synchronisatie (Agentschap Telecom)

Voor data synchronisatie ten behoeve van Agentschap Telecom worden de API's voor de resource `gebiedsinformatieAanvragen` gebruikt.  \
Zie daarvoor [B2B-koppeling beheerdersinformatie (BMKL 2.1)](#b2b-koppeling-beheerdersinformatie-bmkl-21).

Het opvragen van stamgegevens van netbeheerders gebeurt op basis van de resource `organisaties`.
Deze resource is benaderbaar met de volgende endpoints (host + base url):

|IMKL versie    |Omgeving                      |Host                           |Base url                      |
|---------------|------------------------------|-------------------------------|------------------------------|
|v1.2.1 en v2.0 |Productieomgeving KLIC        | https://service10.kadaster.nl | /klic/leveren/api/v2/web     | 
|v1.2.1 en v2.0 |Netbeheerder Testdienst (NTD) | https://service10.kadaster.nl | /klic/ntd/leveren/api/v2/web | 


### Upload servlet

Het endpoint voor het (in fragmenten) uploaden van data ("Upload servlet") wordt teruggegeven bij het verzoek om netinformatie of documenten te actualiseren.

Het uploaden gebeurt met de resource `upload`.
Deze resource is benaderbaar met de volgende endpoints (host + base url):

|IMKL versie    |Omgeving                      |Host                           |Base url                                  | 
|---------------|------------------------------|-------------------------------|------------------------------------------|
|v1.2.1 en v2.0 |Productieomgeving KLIC        | https://service10.kadaster.nl | /klic/actualiseren/upload/api/v2/web     |
|v1.2.1 en v2.0 |Netbeheerder Testdienst (NTD) | https://service10.kadaster.nl | /klic/ntd/actualiseren/upload/api/v2/web |

Merk op dat de bestandsnaam voor aanleveringen van netinformatie volgens het IMKL versie 2.0 formaat, dient te eindigen op "_V2.zip".

### OAuth Authorization

Het OAuth Authorization endpoint voor alle KLIC-omgevingen is:
- https://authorization.kadaster.nl/auth/oauth/v2/

### Waardelijsten

In de BMKL-API worden meerdere waardelijsten onderkend. De toegestande waarde per waardelijst zijn vanaf 14 december 2021 te raadplegen middels onderstaande links:

|IMKL versie | waardelijst              | link                                                                    |
|------------|--------------------------|-------------------------------------------------------------------------|
|v2.0        | giAanvraagStatussen      | https://api.klic.kadaster.nl/waardelijsten/v2/giAanvraagStatussen/      |
|v2.0        | biNotificatieStatussen   | https://api.klic.kadaster.nl/waardelijsten/v2/biNotificatieStatussen    |
|v2.0        | biProductieStatussen     | https://api.klic.kadaster.nl/waardelijsten/v2/biProductieStatussen/     |
|v2.0        | aanleverStapAanduidingen | https://api.klic.kadaster.nl/waardelijsten/v2/aanleverStapAanduidingen/ |
|v2.0        | aanleverStapStatussen    | https://api.klic.kadaster.nl/waardelijsten/v2/aanleverStapStatussen/    |
|v2.0        | aanleverStatussen        | https://api.klic.kadaster.nl/waardelijsten/v2/aanleverStatussen/        |
|v2.0        | informatieSoorten        | https://api.klic.kadaster.nl/waardelijsten/v2/informatieSoorten/        |
|v2.0        | meldingGradaties         | https://api.klic.kadaster.nl/waardelijsten/v2/meldingGradaties/         |
|v2.0        | statistiekSoorten        | https://api.klic.kadaster.nl/waardelijsten/v2/statistiekSoorten/        |
|v2.0        | tmKlicTerugmeldStatussen        | https://api.klic.kadaster.nl/waardelijsten/v2/tmKlicTerugmeldStatussen/       |
|v2.0        | tmClaimStatussen        | https://api.klic.kadaster.nl/waardelijsten/v2/tmClaimStatussen/       |
|v2.0        | tmNotificatieStatussen        | https://api.klic.kadaster.nl/waardelijsten/v2/tmNotificatieStatussen/       |
|v2.0        | tmToegewezenStatussen        | https://api.klic.kadaster.nl/waardelijsten/v2/tmToegewezenStatussen/       |
