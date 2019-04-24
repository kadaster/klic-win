# Validatie documenten

De belangrijkste uitgangspunten met betrekking tot de documenten-validatie zijn:

- Het upload-bestand is een zipbestand.

- De bestandsnamen binnen het zipbestand zijn uniek.

- In het zipbestand zit exact 1 XML-bestand (ook wel de documentenbeheer.xml).  \
Dit bestand beschrijft de documenten die in het zipbestand worden aangeleverd (meta-informatie).

- Een aangeleverd document mag maximaal 8 MB groot zijn (uitgezonderd het XML-bestand met meta-informatie).

- Een totale aanlevering (zipbestand) mag maximaal 10 GB groot zijn.  \
Als de omvang van de alle te actualiseren documenten zodanig groot is, dat deze grens wordt overschreden, dan zal dit dus in meerdere aanleveringen moeten gebeuren.

- XSD-controle van het XML-bestand (meta-informatie).

- Alle genoemde documenten in het XML-bestand moeten aanwezig zijn in het zipbestand.

- Type aangeleverde documenten: dit moet een PDF-document zijn (extensie .pdf).  \
Dit moet dan ook als mediatype worden meegegeven als meta-informatie van het document.  \
Voorbeeld:
```xml
        <document>
            <documentID>
                <namespace>nl.imkl</namespace>
                <lokaalID>KL9999.EDI_aansluiting</lokaalID>
            </documentID>
            <bestandMediaType xlink:href="http://definities.geostandaarden.nl/imkl2015/id/waarde/BestandMediaTypeValue/PDF"/>
            <bestandsnaam>EDI_aansluiting.pdf</bestandsnaam>
        </document>
```

- `lokaalID` moet uniek zijn in documentenbeheer.xml: de identificatie mag één keer voorkomen.

- `documentID` moet juiste bronhoudercode bevatten.

- Wanneer het document wél in het zipbestand, maar niét in het XML-bestand (meta-informatie) voorkomt, is dit niet blokkerend (warning).
