# Validatie documenten

De belangrijkste uitgangspunten met betrekking tot de documenten-validatie zijn:

- Het upload-bestand is een ZIP-file.
- Maximale bestandsgrootte van de ZIP-file is 200 MB (in de bèta versie van deze dienst).
- In de ZIP zit exact 1 XML-bestand. Dit bestand beschrijft de overige documenten (meta-informatie).
- XSD controle van het XML-bestand (meta-informatie).
- Alle genoemde bestanden in .XML-bestand moeten aanwezig zijn in het ZIP-bestand.
- Type aangeleverde documenten: deze moeten .PDF documenten zijn.
- Lokaal-ID moet uniek zijn: mag één keer voorkomen.
- Lokaal-ID moet juiste bronhoudercode bevatten.
- Wanneer document wel in .ZIP bestand maar niet in .XML bestand (meta-informatie) voorkomt: is niet blokkerend (warning).
