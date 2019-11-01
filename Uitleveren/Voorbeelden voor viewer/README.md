#### Uitleveren gebiedsinformatie (voorbeelden voor viewer-bouwers)

Na de overgangsperiode zullen er door KLIC geen rasterbestanden (png's) met netinformatie meer worden uitgeleverd bij een gebiedsinformatielevering (versie 2.2).  \
Een KLIC-viewer zal dan eigen functionaliteit moeten ontwikkelen om de geleverde features uit de gebiedsinformatielevering (GI.xml) te visualiseren. Daarvoor zijn er door de sector visualisatie-afspraken gemaakt.

Deze afspraken zijn vastgelegd in een visualisatie-document die door Geonovum op de GitHub van IMKL1.2 is gepubliceerd (zie [IMKL2015/visualisatie](https://github.com/Geonovum/imkl2015/tree/master/visualisatie)).
Naast deze [IMKL2015-Handreiking-visualisatie_1.2.1.2.pdf](https://github.com/Geonovum/imkl2015/blob/master/visualisatie/1.2.1.2/IMKL2015-Handreiking-visualisatie_1.2.1.2.pdf) worden ook daaraan gerelateerde technische componenten beschikbaar gesteld (zoals SLD's en iconen).

Voor de ontwikkeling van een KLIC-viewer is het prettig om een breed scala aan (uitzonderlijke) testgevallen te hebben om de werking van de viewer te kunnen testen.  \
In deze map zijn een aantal voorbeeld-leveringen opgenomen die hierbij behulpzaam kunnen zijn. Het betreft:
* Levering_19O900151_1  \
een uitlevering waarbij voor netbeheerder met bronhoudercode TS1392 alle 15 thema's en alle IMKL-features worden uitgeleverd;
* Levering_19O900152_1  \
een uitlevering met verschillende geometrieen bij netbeheerder met bronhoudercode TS1001  \
(zie ook de toelichting over mogelijk te gebruiken [geldige geometrietypen](https://github.com/kadaster/klic-win/blob/master/Toepassing%20IMKL/Toelichting%20controles%20netinformatie%20KLIC.md#geldige-geometrietypen));

Let wel:
Deze voorbeelden zijn handmatig opgesteld.  \
Ze zijn niet compleet t.a.v. alle denkbare varianten, maar bevatten wel een grote diversiteit aan features.

#### Praktijkvoorbeelden (in versie 2.2)

Door bouwers van KLIC-viewers is de behoefte aan praktijkvoorbeelden aangegeven.  \
Daarom zijn door het Kadaster een 6-tal KLIC-meldingen gedaan in het centrum van de stad Groningen die varieren in aanvraagsoort en gebiedsomvang. Alle betrokken netbeheerders hebben aangeleverd in vectorformaat (IMKL1.2).

Aan de betrokken netbeheerders in het aangevraagde gebied is toestemming gevraagd om de betreffende leveringen voor demo-doeleinden te mogen gebruiken.  \
We willen daarom expliciet vermelden dat deze informatie alleen bedoeld is ter lering en beeldvorming over de wijze(n) waarop vectorleveringen worden gedaan.

De enkele netbeheerder(s) die hiervoor geen toestemming hebben gegeven, zijn uit de leveringen gehaald.  \
Daarvoor zijn handmatig wijzigingen doorgevoerd in
- de leveringsbrief
- leveringsinformatie (LI.xml)
- gebiedsinformatielevering (GI.xml)
- de netbeheerdermap is verwijderd;

Aangezien de aanvragen zijn ingediend tijdens de overgangsperiode, hebben de leveringen het formaat van versie 2.1.  \
Om te voldoen aan het formaat van versie 2.2 zijn handmatig de volgende wijzigingen doorgevoerd in de leveringen:
- leveringsinformatie (LI.xml): `version` =  2.2
- leveringsinformatie (LI.xml): de verwijzing naar de `soortBijlage` _geselecteerdGebied_ (rasterkaart) is verwijderd
- leveringsinformatie (LI.xml): alle verwijzingen naar rasterkaarten (PNG) van netbeheerders zijn verwijderd
- in de map _bronnen_ is de rasterkaart met het geselecteerde gebied (SEL.png) verwijderd
- in de netbeheerdermappen zijn de rasterkaarten (PNG-bestanden) verwijderd
- de netbeheerdermappen zelf zijn ook verwijderd als de netbeheerder geen bijlagen heeft;

Ook de gelaagdePDF (met rasterkaarten) (LP.pdf) is uit alle leveringen gehaald.

Hieronder is een overzicht van enkele kenmerken van de (bewerkte) leveringen (versie 2.2).

| KLIC-meldnummer | aan-<br>vraag<br>soort | gebieds-<br>grootte (m) | aantal<br>betrokken<br>netbeheerders | zipbestand<br>(MB) | uitgepakt<br>(MB) | GIL.xml<br>(MB) | Opmerking |
|-----------------|-------|-------------|---------------|------------|-----------|---------|--------------|
| 19G558958_1     | G     | 50 x 50     | 7             |        3,3 |       7,3 |     3,2 |              |
| 19G558991_1     | G     | 100 x 100   | 8             |        8,7 |      17,1 |     6,8 |              |
| 19G559028_1     | G     | 200 x 200   | 8             |       11,6 |      38,1 |    25,3 |              |
| 19G559122_1     | G     | 500 x 500   | 9             |       26,0 |     136,6 |   111,4 |              |
| 19O090647_1     | O     | 1250 x 1250 | 15            |      108,7 |     798,6 |   705,4 |              |
| 19O090648_1     | O     | 2500 x 2500 | 25            |      230,1 |   1.622,8 | 1.417,1 | deellevering |

NB.  \
Vanwege de omvang van de laatste twee leveringen (> 100 MB) zijn deze zipbestanden niet beschikbaar op dit kanaal.  \
Neem contact op met de helpdesk van KLIC (via klic@kadaster.nl) om afspraken te maken om deze voor u beschikbaar te stellen.