#### Uitleveren gebiedsinformatie (voorbeelden met _Informatiepolygoon_)

**Informatiepolygoon**  \
Het wordt mogelijk gemaakt om - in geval van een graafmelding of calamiteitenmelding - naast een graafpolygoon óók een informatiepolygoon op te geven.  \
Daardoor is het voor de sector mogelijk om onderscheid te maken tussen het gebied waar gegraven gaat worden, en het ruimere gebied waarover KLIC-informatie wordt gevraagd.  \

Documentatie over de informatiepolygoon is te vinden in de map [klic-win/Geplande wijzigingen/Informatiepolygoon](https://github.com/kadaster/klic-win/tree/master/Geplande%20wijzigingen/Informatiepolygoon).

Als een informatiepolygoon wordt opgegeven kan hierover informatie worden weergegeven in de volgende producten:
- ontvangstbevestiging
- leveringsbrief
- gebiedsinformatie-levering (GI.xml in het (BIL) zipbestand)
- GET gebiedsinformatieAanvragen (WebAPI)

In deze map worden hiervan voorbeelden gegeven voor een aantal KLIC-aanvragen.  \
Het betreft de volgende aanvragen;:
- 20C000882 - een calamiteitenmelding waarbij de informatiepolygoon ruim om de graafpolygoon is getekend
- 20C000883 - een calamiteitenmelding waarbij de informatiepolygoon gelijk is aan de graafpolygoon
- 20G004725 - een graafmelding waarbij de informatiepolygoon ruim om de graafpolygoon is getekend
- 20G004726 - een graafmelding waarbij de informatiepolygoon gelijk is aan de graafpolygoon


*Extra voorbeelden*:
- 20G006168 - een graafmelding waarbij de informatiebuffer 20 meter is
- 20G006169 - een graafmelding waarbij de informatiepolygoon gelijk is aan graafpolygoon
- 20C001301 - een calamiteitmelding waarbij de informatiebuffer 20 meter is
- 20O000793 - een orientatieverzoek

*Speciale scenario's op basis van test-data*:
- Ontvangstbevestiging waarbij er onderscheid is tussen Netbeheerder-Thema's combinatie die alleen van toepassing zijn op het opgegeven informatiegebied of op zowel graaf- als informatiegebied (op basis van belangenregistraie)
  - 20G003270 - een graafmelding waarbij er belang geraakt wordt door alleen informatiepolygoon.
  - 20G003271 - een graafmelding waarbij er belangen geraakt worden door graafpolygoon en door alleen informatiepolygoon.
  - 20G003272 - een graafmelding waarbij er belangen geraakt worden door zowel graafpolygoon als informatiepolygoon.
  - 20C000580 - een calamiteitmelding waarbij er belangen geraakt worden door graafpolygoon en door alleen informatiepolygoon.
- Leveringsbrief die de een indicatie toont bij netbeheerder-thema’s die alleen van toepassing zijn voor de informatiepolygoon (voor de netbeheerders die geleverd hebben is dit gebaseerd op de geleverde informatie; voor de netbeheerders die nog moeten leveren is dit gebaseerd op de belangenregistratie):
  - 20G006144 - een graafmelding waarbij van alle netbeheerders de aangeleverde thema's alleen binnen informatiebuffer liggen (behalve 2 thema's van KL1031)
  - 20G006145 - een graafmelding waarbij van alle netbeheerders de aangeleverde thema's zowel binnen de graafpolygoon als informatiebuffer liggen.
  - 20G006147 - een graafmelding waarbij netbeheerder met bronhoudercode nbact6 thema datatransport en warmte aanlevert waarbij alleen datatransport binnen informatiebuffer ligt.

