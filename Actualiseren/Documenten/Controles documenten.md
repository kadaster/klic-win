# Validatie documenten

De belangrijkste uitgangspunten met betrekking tot de documenten-validatie zijn:

- Het upload-bestand is een zipbestand.
- In het zipbestand zit exact 1 XML-bestand (ook wel de documentenbeheer.xml).  \
  Dit bestand beschrijft de documenten die in het zipbestand worden aangeleverd (meta-informatie).
- XSD-controle van het XML-bestand (meta-informatie).
- Alle genoemde bestanden in het XML-bestand moeten aanwezig zijn in het zipbestand.
- Type aangeleverde documenten: dit moet een PDF-document zijn (extensie .pdf).
- `lokaalID` moet uniek zijn in documentenbeheer.xml: mag één keer voorkomen.
- `documentID` moet juiste bronhoudercode bevatten.
- Wanneer het document wél in het zipbestand, maar niét in het XML-bestand (meta-informatie) voorkomt: is niet blokkerend (warning).
