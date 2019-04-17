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