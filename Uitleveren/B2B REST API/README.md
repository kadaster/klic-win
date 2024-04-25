# B2B-koppeling gebiedsinformatie-levering (KLIC B2B-levering) via REST API

| De implementatie staat gepland op 2 mei in de NTD en 7 mei in productie. <br> Houdt de pagina met [geplande werkzaamheden](../../KLIC%20-%20Geplande%20werkzaamheden.md) in de gaten voor eventuele updates. |
|------------------------------|

Deze technische notitie beschrijft het koppelvlak tussen externe systemen en Kadaster KLIC voor het opvragen van de dowloadlink voor de gebiedsinformatie levering door middel van een REST-API.

**Inhoudsopgave**:  
- [Inleiding](#1-inleiding)
- [Gebruik API](#2-gebruik-api)
- [Endpoints](#3-endpoints)
- [Modelschema en Swagger doucmentatie](#4-modelschemaswaggervoorbeeld-response)
  - [voorbeeld response giAanvraag](#41-giaanvraag)
  - [voorbeeld response gebiedsinformatieLeveringen](#42-gebiedsinformatieleveringen)
  


---------------------------------------------------------
# 1. Inleiding

Via een B2B-koppeling kan er een KLIC-aanvragen worden ingediend. Ook kan er via een B2B-koppeling door een extern systeem een bericht aan het Kadaster worden opgevraagd met daarin de downloadlink voor een aanvraag voor gebiedsinformatie; beter bekend als de **KLIC-levering**.  \
Er zijn twee objecten op te halen: gegevens over de aanvraag en gegevens over de levering. Beide worden ze geïdentificeerd door het giAanvraagId. Deze identifier is dezelfde idientifier als die teruggegeven wordt bij het via de API ophalen van het validatie resultaat van een aanvraag.
([zie ook de GitHub documentatie over "aanvragen gebiedsinformatie"](../../Aanvragen%20gebiedsinformatie/B2B%20REST%20API)) \
Ook is het mogelijk om een lijst op te vragen met de leveringsobjecten via een van de endpoints.    \
Ten behoeve van het gebruik door service providers is het mogelijk een lijst op te vragen op basis van een relatienummer. Bij het gebruik zonder de relatienummer prameter wordt alleen de meldingen getoond van de ingelogde gebruiker.

# 2. Gebruik API:  
Authenticatie, paginering en gebruik van parameters is conform de standaarden van de BMKL-api's. zie daarvoor:
https://github.com/kadaster/klic-win/blob/master/BMKL/BMKL%202.1/BMKL%202.1%20(B2B-koppeling%20beheerdersinformatie).md

# 3. Endpoints
> De endpoints worden later gecommuniceerd.  

:warning: Let op: In de testomgeving is alleen een voorbeeld response op te halen. Dit is een vast ingestelde response ten behoeve van test doeleinden. Het ophalen van objecten op basis van een echt giAanvraagId is niet mogelijk in de testomgeving.

 


# 4. Modelschema/Swagger/voorbeeld response

Het modelschema is te vinden in de swagger documentatie.
> De link naar de Swagger documentatie wordt later gecommuniceerd.  


Hieronder staan voorbeeld responses:
## 4.1 giAanvraag

```json
{
    "giAanvraagId": "4c8353bd-3907-40ee-84b0-5f54ac38d4d1",
    "ordernummer": "2015000924",
    "positienummer": "0000000010",
    "klicMeldnummer": "17G000649",
    "aanvrager":{
        "contactpersoon": {
            "naam":"Aanvrager01",
            "telefoon":"0881235648",
            "email":"klicwin@kadaster.nl"
        },
        "organisatie":{
            "naam":[
                "Grondroerder Apeldoorn B.V."
            ],
            "kvkNummer": "12345678",
            "bezoekAdres":{
                "BAGid": "0200010000130331",
                "openbareRuimteNaam":"Laan van Westenenk",
                "huisnummer":"701",
                "woonplaatsNaam":"Apeldoorn",
                "postcode":"7334DP",
                "landcode": "http://publications.europa.eu/resource/authority/country/NLD"
            }
        },
        "extraContact": {
            "naam":"Tester",
            "telefoon":"0612345678",
            "email":"ordervoorbereiding@operator.net"
        }
    },
    "opdrachtgever":{
        "contactpersoon":{
            "naam":"Kadaster",
            "telefoon":"(088) 183 20 00",
            "email":"noreply@kadaster.nl"
        },
        "organisatie":{
            "naam":[
                "Kadaster"
            ],
            "kvkNummer": "87654321",
            "bezoekAdres":{
                "BAGid": "0200010000090244",
                "openbareRuimteNaam":"Hofstraat",
                "huisnummer":"110",
                "woonplaatsNaam":"Apeldoorn",
                "postcode":"7311KZ",
                "landcode": "http://publications.europa.eu/resource/authority/country/NLD"
            }
        }
    },
    "aanvraagSoort":"http://definities.geostandaarden.nl/imkl2015/id/waarde/AanvraagSoortValue/graafmelding",
    "aanvraagDatum":"2017-11-03T10:38:14+01:00",
    "mutatieDatum":"2017-11-03T10:38:14.451+01:00",
    "giAanvraagStatus": "https://api.klic.kadaster.nl/waardelijsten/v2/giAanvraagStatussen/giInProductie",
    "soortWerkzaamheden":[
        "http://definities.geostandaarden.nl/imkl2015/id/waarde/SoortWerkzaamhedenValue/leggenLaagspanning",
        "http://definities.geostandaarden.nl/imkl2015/id/waarde/SoortWerkzaamhedenValue/huisaansluitingenMaken"
    ],
    "locatieWerkzaamheden":{
        "BAGid": "0200010000130331",
        "openbareRuimteNaam":"Laan van Westenenk",
        "huisnummer":"701",
        "woonplaatsNaam":"Apeldoorn",
        "postcode":"7334DP",
    },
    "locatieOmschrijving": "bij fonteinaansluiting",
    "startDatum": "2017-11-13",
    "eindDatum": "2017-11-22",
    "huisaansluitingAdressen":[{
       "BAGid": "0200010000130331",
       "openbareRuimteNaam":"Laan van Westenenk",
       "huisnummer":"701",
       "woonplaatsNaam":"Apeldoorn",
       "postcode":"7334DP",
	}, {
       "BAGid": "0200010003923183",
       "openbareRuimteNaam":"Evert van 't Landstraat",
       "huisnummer":"15",
       "woonplaatsNaam":"Apeldoorn",
       "postcode":"7334DR",
           }],
    "graafpolygoon":{
        "type":"Polygon",
        "crs":{
            "type":"name",
            "properties":{
                "name":"EPSG:28992"
            }
        },
        "coordinates":[ [ [ 153606.0, 391101.0 ], [ 153594.0, 391095.0 ], [ 153602.0, 391080.0 ], [ 153622.0, 391094.0 ], [ 153606.0, 391101.0 ] ] ]
    },
    "informatiepolygoon":{
        "type":"Polygon",
        "crs":{
            "type":"name",
            "properties":{
                "name":"EPSG:28992"
            }
        },
        "coordinates":[ [ [ 153606.0, 391101.0 ], [ 153594.0, 391095.0 ], [ 153602.0, 391080.0 ], [ 153622.0, 391094.0 ], [ 153606.0, 391101.0 ] ] ]
    }
}
```


:information_source: Merk op dat dit hetzelfde object is, als ingestuurd via de [GIA-POST-API](../../Aanvragen%20gebiedsinformatie/B2B%20REST%20API), aangevuld met:
`giAanvraagId`, `ordernummer`, `positienummer` (in geval van tracé meldingen reeds door aanvrager opgegeven), `klicMeldnummer`, `aanvraagDatum`, `mutatieDatum`, `giAanvraagStatus`.  

Indien het GIA bericht opgehaald wordt direct na het insturen van de aanvraag; dan zijn een aantal velden nog niet bepaald. Het betreft `ordernummer` en `klicMeldnummer`. Deze velden zijn daarom "optioneel" in het modelschema. De velden komen beschikbaar in de API, als ze door KLIC bepaald zijn. Aangezien er gebruik gemaakt wordt van caching, dient de retry-tijd ingesteld te worden op meer dan 1 minuut.


## 4.2 gebiedsinformatieLeveringen

```json
{
    "_links": {
        "self": {
            "href": "https://service10.kadaster.nl/klic/aanvragen/v1/gebiedsinformatieleveringen?datumVanaf=2017-11-02T09:00:00%2B01&datumTot=2017-11-02T10:00:00%2B01"
        },
        "next": {
            "href": "https://service10.kadaster.nl/klic/aanvragen/v1/gebiedsinformatieleveringen?datumVanaf=2017-11-02T09:35:22.323%2B01&datumTot=2017-11-02T10:00:00%2B01"
        }
    },
    "gebiedsinformatieLeveringen": [{
        "giAanvraagId": "2109992d-90f6-4bc7-815e-e72a02d46220",
        "leveringsvolgnummer": "2",
	"isVeiligheidsgebiedGeraakt": "false",
        "datumLeveringSamengesteld": "2017-11-02T09:16:01+01",
        "indicatieLeveringCompleet": "true",
        "giLeveringUrl": "https://service10.kadaster.nl/gds2/download/public/ce417a87-92cd-4c57-a70e-8a0c405b2701"
    }, {
        "giAanvraagId": "2109992d-90f6-4bc7-815e-e72a02d46220",
        "leveringsvolgnummer": "1",
	"isVeiligheidsgebiedGeraakt": "false",
        "datumLeveringSamengesteld": "2017-11-02T09:25:01+01",
        "indicatieLeveringCompleet": "false",
        "giLeveringUrl": "https://service10.kadaster.nl/gds2/download/public/cfbdaaf6-c84b-4a05-9d71-657cd43ecf21"
    }, {
        "giAanvraagId": "525f1830-0b70-461e-a780-5bd4e8a90973",
        "leveringsvolgnummer": "1",
	"isVeiligheidsgebiedGeraakt": "true"
    }]
} 
```
 
:information_source: Merk op dat de lijst ook deelleveringen kan bevatten. De `indicatieLeveringCompleet` is dan false, en er zal nog een levering zijn of volgen met een hoger `leveringsvolgnummer`.  

 
De `giLeveringUrl` bevat de download URL die ook in de leveringsmail verzonden is. Deze link is tot 20 werkdagen te gebruiken nadat de levering is samengesteld.

In het geval er een veiligeidsgebied geraakt is (`isVeiligheidsgebiedGeraakt` is `true`), is er geen download link beschikbaar. Het reguliere proces waarbij er contact gezocht moet worden met de veilgheidsgebied beheerder dient dan gevolgd te worden.

:warning: In de testomgeving is alleen een voorbeeld response op te halen. Dit is een vast ingestelde response ten behoeve van test doeleinden. Het ophalen van objecten op basis van een echt giAanvraagId is niet mogelijk in de testomgeving.

 













