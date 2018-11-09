# Toepassen standaarden bij KLIC API's

**Inhoudsopgave**

- [Inleiding](#inleiding)
- [Paginering](#paginering)
  - [`"_links"`](#_links)
  - [Selecteren aantal objecten per pagina](#selecteren-aantal-objecten-per-pagina)
  - [Voorbeelden](#voorbeelden)
- [Referenties](#referenties)  

---------------------------------------------------------
## Inleiding

De uitwisseling van informatie tussen KLIC en andere partijen in de graafketen verloopt steeds meer met behulp van API's.  \
Dit document beschrijft richtlijnen en standaarden die Kadaster-KLIC toepast (of wil gaan toepassen) bij het beschikbaar stellen van deze API's.

Voor het toepassen van deze richtlijnen en standaarden is mede gebruik gemaakt van ervaringen bij andere diensten van het Kadaster, in het bijzonder het "Digitaal Stelsel Omgevingswet".

---------------------------------------------------------
## Paginering

### `"_links"`
Voor API-requests die een lijst van objecten opleveren, pagineren we de output.  \
In het request kan het gewenste aantal objecten per pagina opgegeven worden. Aan de serverkant zal hiervoor een maximum gelden om de systeembelasting te kunnen beperken. 

Voor paginering wordt aangesloten op de JSON Hypertext Application Language (HAL). Dit is een standaard voor het uitdrukken van hyperlinks met JSON [RFC4627].
Door het beschikbaar stellen van links in de response van een API kan een client-applicatie de gewenste links selecteren en gegevensverzamelingen doorkruisen.

Op basis van dit principe worden bij KLIC aan geretourneerde objecten-verzamelingen een gereserveerd veld `"_links"` toegevoegd (gedefinieerd door RFC5988) waarin _Link Object_(s) met een hyperlink (`"href"`-property) worden opgenomen.  \
Het andere gereserveerde veld `"_embedded"` wordt momenteel nog niet door KLIC toegepast.

Momenteel gebruiken we bij KLIC de volgende Link Object-relatietypes bij het opleveren van een lijst van objecten:

- `"self"`  \
met een referentie naar de URI die tot de betreffende lijst van objecten heeft geleid
- `"next"`  (optioneel)\
met een referentie naar een URI die naar de volgende pagina van de zoek-resultaten leidt

Hieronder is een voorbeeld van een JSON+HAL representatie voor het opvragen van een lijst van gebiedsinformatie-aanvragen met een limiet van 5 objecten per pagina:

``` json
{
    "_links": {
        "next": {
            "href": "https://api.kadaster.nl/klic/v2/gebiedsinformatieAanvragen?limiet=5&offset=5"
        },
        "self": {
            "href": "https://api.kadaster.nl/klic/v2/gebiedsinformatieAanvragen?limiet=5"
        }
    },
    "gebiedsinformatieAanvragen": [
        {
           //lijst met eerste 5 gebiedsinformatie-aanvragen...
        }
    ]
}
```

### Selecteren aantal objecten per pagina

Voor het beperken van de lijst van objecten die per pagina worden teruggegeven, gebruiken we in KLIC de query-parameter:

- 'limiet'

Deze parameter geeft het maximum aantal objecten aan die in het antwoord teruggegeven mogen worden.  \
Het systeem zal een beperking stellen aan het te gebruiken maximum (bijv. maximum 50). Als de opgegeven limiet groter is dan het door het systeem toegelaten maximum, zal er een HTTP 400 status worden teruggegeven (ongeldig request).

Voor het navigeren door de objectenverzameling (bijv. volgende pagina) gebruiken we de Link Object-relatietypes zoals hierboven aangegeven.  \
De API kan deze functionaliteit op een eigen manier ondersteunen, bijvoorbeeld door het gebruik van een 'offset' (een volgnummer van het object in een objectenverzameling).

Als een zoekopdracht resulteert in een lijst _zonder_ objecten, zal deze opdracht als een geldig request worden beschouwd. De HTTP-status zal dan 200 zijn:

```json
HTTP/1.1 200 OK
```

### Voorbeelden
Onderstaand worden voorbeelden gegeven van de huidige werking van enkele API's.  \
Het in de voorbeelden gebruikte endpoint waar de Kadaster-API's voor KLIC zijn te vinden is (nog) fictief.

**Voorbeeld 1. Zoeken op eerste en volgende pagina in een objectenverzameling.**

In dit voorbeeld wordt gezocht naar alle beheerdersinformatie-aanvragen voor de ingelogde netbeheerder met de status "open". Hiervoor wordt de parameter `biNotificatieStatus` met de waarde `biOpen` toegevoegd aan het request.  \
Het maximaal aantal teruggegeven objecten per pagina is hier op 5 gesteld (limiet).

_request:_
```sh
curl https://api.kadaster.nl/klic/v2/gebiedsinformatieAanvragen/-/beheerdersinformatieAanvragen?biNotificatieStatus=biOpen&limiet=5
 -X GET
 -H "Authorization: Bearer 1d021976-91c8-4b46-ab9b-529088d0f3de"
 -H 'Accept: application/json'
```

_response:_
```json
{
    "_links": {
        "next": {
            "href": "https://api.kadaster.nl/klic/v2/gebiedsinformatieAanvragen/-/beheerdersinformatieAanvragen?biNotificatieStatus=biOpen&limiet=5&offset=5"
        },
        "self": {
            "href": "https://api.kadaster.nl/klic/v2/gebiedsinformatieAanvragen/-/beheerdersinformatieAanvragen?biNotificatieStatus=biOpen&limiet=5"
        }
    },
    "beheerdersinformatieAanvragen": [
        {
            "biAanvraagId" : "330d0526-0586-4843-ad86-04d8969fc768",
            "giAanvraagId" : "4c8353bd-3907-40ee-84b0-5f54ac38d4d1",
            "bronhoudercode" : "KL3131",
            "biNotificatieStatus" : "https://api.kadaster.nl/klic/v2/waarde/biNotificatieStatussen/biOpen",
            "biProductieStatus" : "https://api.kadaster.nl/klic/v2/waarde/biProductieStatussen/biWachtOpAntwoord",
            "datumGenotificeerd" : "2017-11-03T10:38:44+01:00",
            "mutatieDatum":"2017-11-03T10:38:44.653+01:00"
        },{
            "biAanvraagId" : "130k5426-0586-4843-ad86-04d89623fd28",
            "giAanvraagId" : "8dc933bd-3907-40ee-84b0-5f54ah37a4d1",
            "bronhoudercode" : "KL3131",
            "biNotificatieStatus" : "https://api.kadaster.nl/klic/v2/waarde/biNotificatieStatussen/biBevestigingOntvangen",
            "biProductieStatus" : "https://api.kadaster.nl/klic/v2/waarde/biProductieStatussen/biWachtOpAntwoord",
            "datumGenotificeerd" : "2017-11-03T10:43:25+01:00",
            "datumBevestigingOntvangen" : "2017-11-03T10:55:36+01:00",
            "mutatieDatum":"2017-11-03T10:55:36.399+01:00"
        },{
            //overige 3 beheerdersinformatie-aanvragen uit resultaatlijst...
        }
    ]
}
```

Een vervolgpagina (met de volgende 5 objecten) kan dan worden aangeroepen met het request zoals als dat teruggegeven is in het Link Object `"next"` volgens:

_request:_
```sh
curl https://api.kadaster.nl/klic/v2/gebiedsinformatieAanvragen/-/beheerdersinformatieAanvragen?biNotificatieStatus=biOpen&limiet=5&offset=5
 -X GET
 -H "Authorization: Bearer 1d021976-91c8-4b46-ab9b-529088d0f3de"
 -H 'Accept: application/json'
```

met als response:

_response:_
```json
{
    "_links": {
        "next": {
            "href": "https://api.kadaster.nl/klic/v2/gebiedsinformatieAanvragen/-/beheerdersinformatieAanvragen?biNotificatieStatus=biOpen&limiet=5&offset=10"
        },
        "self": {
            "href": "https://api.kadaster.nl/klic/v2/gebiedsinformatieAanvragen/-/beheerdersinformatieAanvragen?biNotificatieStatus=biOpen&limiet=5&offset=5"
        }
    },
    "beheerdersinformatieAanvragen": [
        {
            //volgende 5 beheerdersinformatie-aanvragen uit resultaatlijst...
        }
    ]
}
```
  /
  /
**Voorbeeld 2. Zoeken op een objectenverzameling die geen vervolgpagina heeft.**

In dit voorbeeld wordt gezocht naar alle beheerdersinformatie-aanvragen voor de ingelogde gebruiker voor een specifieke gebiedsinformatie-aanvraag.  \
Het aantal teruggegeven objecten is in dit geval slechts 1, dus de `"next"`-link ontbreekt in het resultaat.

_request:_
```sh
curl https://api.kadaster.nl/klic/v2/gebiedsinformatieAanvragen/7ba96f08-1a49-4b2a-b7f5-04e5155cf53f/beheerdersinformatieAanvragen
 -X GET
 -H "Authorization: Bearer 1d021976-91c8-4b46-ab9b-529088d0f3de"
 -H 'Accept: application/json'
```

_response:_
```json
{
  "_links" : {
    "self" : {
      "href" : "https://api.kadaster.nl/klic/v2/gebiedsinformatieAanvragen/7ba96f08-1a49-4b2a-b7f5-04e5155cf53f/beheerdersinformatieAanvragen"
    }
  },
  "beheerdersinformatieAanvragen" : [ {
    "biAanvraagId" : "2eb8b0cb-c371-4558-b9bf-04599b0d540f",
    "giAanvraagId" : "7ba96f08-1a49-4b2a-b7f5-04e5155cf53f",
    "bronhoudercode" : "KL3131",
    "biNotificatieStatus" : "https://api.kadaster.nl/klic/v1/cl/biNotificatieStatussen/open",
    "biProductieStatus" : "https://api.kadaster.nl/klic/v1/cl/biProductieStatussen/gereedVoorSamenstellenProduct",
    "datumGenotificeerd" : "2018-10-25T14:08:53+02:00",
    "mutatieDatum" : "2018-10-25T14:09:01+02:00"
  } ]
}
```
  /
  /
**Voorbeeld 3. Geen objecten gevonden bij zoeken op een objectenverzameling.**

In dit voorbeeld wordt gezocht naar beheerdersinformatie-aanvragen die voldoen aan bepaalde selectie-criteria, maar waarvoor geen objecten zijn gevonden.  \
De verzameling teruggegeven objecten is dus leeg, en de `"next"`-link ontbreekt in het resultaat.

_request:_
```sh
curl https://api.kadaster.nl/klic/v2/gebiedsinformatieAanvragen/-/beheerdersinformatieAanvragen?biNotificatieStatus=biOpen
 -X GET
 -H "Authorization: Bearer 1d021976-91c8-4b46-ab9b-529088d0f3de"
 -H 'Accept: application/json'
```

_response:_
```json
{
  "_links" : {
    "self" : {
      "href" : "https://api.kadaster.nl/klic/v2/gebiedsinformatieAanvragen/-/beheerdersinformatieAanvragen?biNotificatieStatus=biOpen"
    }
  },
  "beheerdersinformatieAanvragen" : [ ]
}
```
  /
  /
**Voorbeeld 4. Opvragen objectenverzameling met een limiet die de systeemlimiet overschrijdt.**

In onderstaand voorbeeld is de systeemlimiet ingesteld op 50.

_request:_
```sh
curl https://api.kadaster.nl/klic/v2/gebiedsinformatieAanvragen/-/beheerdersinformatieAanvragen?limiet=500
 -X GET
 -H "Authorization: Bearer 1d021976-91c8-4b46-ab9b-529088d0f3de"
 -H 'Accept: application/json'
```

_response:_
```json
{
  "status" : 400,
  "meldingCode" : 1000400,
  "attribuut" : "limiet",
  "gebruikerMelding" : "ongeldig request",
  "ontwikkelaarMelding" : "ongeldige waarde (500) voor atribuut opgegeven",
  "meerInformatie" : "http://developer.klic.nl/foutCode/1000400"
}
```

---------------------------------------------------------
## Referenties

- [JSON:API - Latest Specification, Pagination](https://jsonapi.org/format/#fetching-pagination)
