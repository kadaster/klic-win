#PKIoverheid certificaten#                                                                                                                                                                                                                                                                 |

**Inhoudsopgave**

- [Inleiding](#inleiding)
- [Achtergrond](#achtergrond)
  - [Wat is een PKIoverheid-certificaat?](#wat-is-een-pkioverheid-certificaat)
  - [Waarvoor heb ik als netbeheerder of serviceprovider een certificaat nodig?](#waarvoor-heb-ik-als-netbeheerder-of-serviceprovider-een-certificaat-nodig)
  - [Kan ik een PKIoverheid certificaat wat ik al in bezit heb ook gebruiken voor KLIC?](#kan-ik-een-pkioverheid-certificaat-wat-ik-al-in-bezit-heb-ook-gebruiken-voor-KLIC)
  - [Hoe wordt een certificaat gemaakt?](#hoe-wordt-een-certificaat-gemaakt)
- [Praktische stappen](#praktische-stappen)
  - [Stappenplan voor aanvraag of verlenging PKIoverheid-certificaat](#stappenplan-voor-aanvraag-of-verlenging-pkioverheid-certificaat)
  - [Welke partijen kunnen certificaten leveren?](#welke-partijen-kunnen-certificaten-leveren)
  - [Wie moet wat doen binnen de organisatie?](#wie-moet-wat-doen-binnen-de-organisatie)
  - [Wat houdt het registreren in?](#wat-houdt-het-registreren-in)
  - [Hoe vraag ik een certificaat aan?](#hoe-vraag-ik-een-certificaat-aan)
  - [Hoe installeer ik een certificaat?](#hoe-installeer-ik-een-certificaat)
  - [Wat moet er worden opgestuurd waarheen en waarom?](#wat-moet-er-worden-opgestuurd-waarheen-en-waarom)
  - [Welk type certificaat heb ik nodig?](#welk-type-certificaat-heb-ik-nodig)
  - [Is het certificaat gekoppeld aan de organisatie, de servernaam, of iets anders?](#is-het-certificaat-gekoppeld-aan-de-organisatie-de-servernaam-of-iets-anders)
  - [Kan ik één certificaat gebruiken voor zowel KLIC als BAG als Wkpb?](#kan-ik-één-certificaat-gebruiken-voor-zowel-KLIC-als-bag-als-wkpb)
  - [Hoe lang is een certificaat geldig?](#hoe-lang-is-een-certificaat-geldig)
  - [Wat zijn de aanschafkosten voor een certificaat?](#wat-zijn-de-aanschafkosten-voor-een-certificaat)
- [Bijzondere situaties](#bijzondere-situaties)
  - [Kan ik hetzelfde certificaat hergebruiken bij vervanging van de server?](#kan-ik-hetzelfde-certificaat-hergebruiken-bij-vervanging-van-de-server)
  - [Kan ik hetzelfde certificaat gebruiken bij virtual servers, redundantie, back-up of uitwijk?](#kan-ik-hetzelfde-certificaat-gebruiken-bij-virtual-servers-redundantie-back-up-of-uitwijk)
  - [Heb ik ook een certificaat nodig voor een testserver of alleen voor de productieserver?](#heb-ik-ook-een-certificaat-nodig-voor-een-testserver-of-alleen-voor-de-productieserver)
  - [Serviceprovider](#serviceprovider)
  - [Kan ik gebruik maken van een testomgeving?](#kan-ik-gebruik-maken-van-een-testomgeving)
- [Voor meer informatie](#voor-meer-informatie)

## Inleiding

Als onderdeel van de nieuwe KLIC Web API’s die als onderdeel van het KLIC-WIN project ingevoerd worden wordt voor alle nieuwe B2B koppelingen gebruik gemaakt van PKIOverheid “client” certificaten.

Deze PKIoverheid-certificaten bevatten informatie die de eigenaar, de organisatie, uniek identificeert binnen het PKIoverheid domein en op basis waarvan we autorisaties toekennen.

Dit document bevat achtergrondinformatie over de PKIoverheid-certificaten en legt in praktische stappen uit hoe te werk te gaan om een dergelijk certificaat aan te schaffen en te implementeren. Diepgaande technische aspecten van de implementatie zoals installatie en technisch beheer van certificaten komen niet aan de orde in dit document; voor meer informatie daarover verwijzen wij u naar uw certificaatdienstverlener of de leverancier van uw applicatie. Dit document gaat ook niet in op andersoortige PKIoverheid-certificaten zoals bijvoorbeeld persoonsgebonden certificaten.

Hoofdstuk 1 beschrijft de achtergrond, het wat en waarom van PKIoverheid-certificaten. Wie alleen wil weten hoe hij een certificaat aanvraagt kan terecht in hoofdstuk 2. Hoofdstuk 3 behandelt een aantal bijzondere situaties die niet voor alle organisaties van toepassing zijn. Hoofdstuk 4 bevat een aantal verwijzingen naar meer informatie en een lijst van gebruikte termen en afkortingen met de verklaringen.

## Achtergrond

### Wat is een PKIoverheid-certificaat?

Een PKIoverheid-certificaat is een klein digitaal bestand waarmee de echtheid van een website aangetoond kan worden of waarmee een organisatie zich kan identificeren voor het uitwisselen van informatie. Net zoals een paspoort fungeert als identiteitsbewijs voor personen, wordt een certificaat gebruikt om langs elektronische weg de identiteit van een organisatie aan te tonen. Certificaten worden op internet al op grote schaal gebruikt om de echtheid van websites aan te tonen (van belang bij bijv. telebankieren). KLIC kan aan de hand van het certificaat zien welke organisatie zich meldt om informatie uit te wisselen.

De meeste certificaten die op internet worden gebruikt zijn uitgegeven door commerciële CSP’s. PKIoverheid-certificaten zijn technisch gezien hetzelfde, met als bijzonderheid dat ze worden uitgegeven door CSP’s die voldoen aan de eisen die de Nederlandse overheid stelt. KLIC accepteert alleen PKIoverheid-certificaten, aangezien de kwaliteit hiervan eenduidig is en op een hoog niveau ligt. Daarnaast worden PKIoverheid-certificaten steeds meer gebruikt voor e-overheidsprojecten, bijv. voor BAG, BSN, DigiD, mGBA, en LVWOZ.

Bij elk certificaat hoort een geheime sleutel – eveneens een klein digitaal bestand, zonder welke het certificaat onbruikbaar is. Deze geheime sleutel moet zorgvuldig worden bewaard en mag niet worden gekopieerd of aan derden verstrekt: Als de geheime sleutel in handen valt van een kwaadwillende partij dan kan die namelijk de identiteit van de organisatie op internet overnemen. Het certificaat zelf is openbaar en kan zonder problemen worden gekopieerd of opgestuurd.

Meer algemene informatie over PKIoverheid certificaten vind u op de website van Logius: https://www.logius.nl/diensten/pkioverheid/

### Waarvoor heb ik als netbeheerder of serviceprovider een certificaat nodig?

Elke netbeheerder of serviceprovider moet beschikken over een geldig PKIoverheid-certificaat om gegevens te kunnen uitwisselen met de KLIC Web API’s.

Wanneer netbeheerder of serviceprovider met de KLIC Web API’s informatie wil uitwisselen met KLIC moet de netbeheerder of serviceprovider een communicatiesessie opzetten KLIC. Voordat KLIC deze communicatie accepteert, moet ze er zeker van zijn wie de netbeheerder of serviceprovider is. Dit doet KLIC door het certificaat gebruikt bij het opzetten van de communicatiesessie te controleren aan het begin van de sessie; zonder een geldig certificaat wordt de communicatiesessie met een foutmelding Met andere woorden, het certificaat is het digitale identiteitsbewijs waarmee de netbeheerder of serviceprovider aantoont wie hij is.

Het certificaat bevat alleen gegevens om vast te stellen wie communicatiesessie wil opzetten, maar niet wát die eigenaar mag doen. Die gegevens liggen vast in KLIC.

### Kan ik een PKIoverheid certificaat wat ik al in bezit heb ook gebruiken voor KLIC?

Alle voor identificatie gebruikte certificaten worden voorzien van een OIN, als dit in uw certificaat het geval is kunt u met dit certificaat ook gebruik maken van KLIC.

### Hoe wordt een certificaat gemaakt?

Certificaten worden uitgegeven door CSP’s en bevatten een aantal gegevens over de organisatie, waaronder de naam. De gegevens op het certificaat worden vóór uitgifte door de CSP geverifieerd, en als bewijs daarvan wordt het certificaat door de CSP digitaal ondertekend.

Simpel gesteld bestaat het maken van een geldig certificaat uit de volgende twee stappen.

-   Stap 1: Aanmaken van een zogenaamde Certificate Signing Request (CSR)[1]. Dit is een soort ‘blanco certificaat’ met alleen de identificerende gegevens erop, maar nog niet ondertekend. Het aanmaken van de CSR levert tegelijk, in een separaat bestand, ook de bijbehorende geheime sleutel.
-   Stap 2: Ondertekenen van de CSR. De CSP controleert de aanvraag en de gegevens op de CSR. Als alles klopt dan wordt de CSR digitaal ondertekend door de CSP en wordt daarmee een geldig certificaat.

Aangezien de geheime sleutel goed beveiligd moet worden en niet in handen van derden mag komen, is het gebruikelijk dat de eigenaar zelf de CSR aanmaakt en deze naar de CSP opstuurt bij de aanvraag. Het is echter ook mogelijk om het aanmaken van de CSR uit te besteden bij de CSP, mits deze kan garanderen dat zijn uitgifteproces ingericht is met zodanige veiligheidswaarborgen dat de geheime sleutel uitsluitend en vertrouwelijk wordt overhandigd aan de bevoegde persoon van de netbeheerder of serviceprovider, en er ook geen kopie wordt bewaard bij de CSP.

## Praktische stappen

### Stappenplan voor aanvraag of verlenging PKIoverheid-certificaat

Onderstaande figuur geeft schematisch weer welke stappen de netbeheerder of serviceprovider moet doorlopen om een werkend PKIoverheid-certificaat te krijgen. Elke stap bestaat uit een keuze en/of een actie voor de organisatie die de keuze moet maken of de actie moet uitvoeren is per stap aangegeven.

In de rest van dit hoofdstuk worden enkele stappen nader toegelicht.

<image src="images/image3.png" width="576" height="707" />

### Welke partijen kunnen certificaten leveren?

PKIoverheid-certificaten worden geleverd door CSP’s die zijn toegetreden tot PKIoverheid. Deze certificaatdienstverleners kunt u vinden op de website van Logius: https://www.logius.nl/diensten/pkioverheid/aanschaffen/

Als uw organisatie nog niet eerder een PKIoverheid-certificaat heeft aangeschaft, is het van belang dat u een CSP kiest.

### Wie moet wat doen binnen de organisatie?

Naast de KLIC beheerder bij de netbeheerder of de serviceprovider is een aantal rollen van belang bij de aanvraag en implementatie van een PKIoverheid-certificaat: Bevoegd vertegenwoordiger, certificaatbeheerder, technisch beheerder. Deze rollen moeten dan ook duidelijk worden belegd[2].

De **bevoegd vertegenwoordiger** is de functionaris die bevoegd is om de organisatie te vertegenwoordigen inzake PKIoverheid-certificaten; dit kan bijvoorbeeld de burgemeester of directeur zijn. In de praktijk zal de bevoegd vertegenwoordiger een certificaatbeheerder mandateren om namens de netbeheerder of serviceprovider op te treden bij de aanvraag en het beheer van certificaten.

**Certificaatbeheerders** zijn de enigen die namens de organisatie certificaten kunnen aanvragen; die rol moet worden belegd bij een of meer medewerkers van de organisatie[3]. Wij adviseren u de rol van certificaatbeheerder te beleggen bij de beveiligingscoördinator (indien aanwezig). In de praktijk komt het ook voor dat het hoofd P&O of het hoofd I&A die rol op zich neemt. Tot de verantwoordelijkheid van de certificaatbeheerder behoort onder meer het aanvragen en ontvangen van certificaten, het veilig bewaren van de geheime sleutel, zicht houden en reageren op relevante beveiligingsissues, en het bewaken van de geldigheidstermijnen en tijdig aanvragen van nieuwe certificaten.

De **technisch beheerder** zorgt voor de installatie en het technisch beheer van de verkregen certificaten en, indien van toepassing, het aanmaken van een CSR ten behoeve van de aanvraag (zie paragraaf 1.4). De technisch beheerder kan dezelfde zijn als de certificaatbeheerder, maar in de praktijk gaat het vaak om een andere functionaris die de genoemde taken uitvoert in opdracht van de certificaatbeheerder.

### Wat houdt het registreren in?

Voordat u als organisatie een PKIoverheid-certificaat kunt aanvragen, dient u zich eerst als abonnee te laten registreren bij de CSP van uw keuze. Dit kan normaliter tegelijkertijd met de eerste certificaataanvraag worden geregeld. Indien u eerder een certificaat bij die CSP heeft aangeschaft (voor andere doeleinden zoals DigiD, BSN, elektronische handtekening, LVWOZ etc.) dan is uw organisatie al geregistreerd als abonnee en kunt u deze stap overslaan. In dat geval is er ook al een certificaatbeheerder binnen uw organisatie bekend.

Bij de registratie als abonnee geeft de organisatie één of meer certificaatbeheerders op; eventueel kan de organisatie op een later moment nog certificaatbeheerders toevoegen. De opgegeven certificaatbeheerders dienen zich eenmalig te identificeren door persoonlijk langs te gaan bij een instantie, met een geldig identiteitsbewijs en een document dat zijn bevoegdheid als certificaatbeheerder aantoont. De CSP kan u meer vertellen over de precieze eisen die hieraan gesteld worden en beschikken over modelverklaringen, de wijze van identificeren verschilt per CSP.

### Hoe vraag ik een certificaat aan?

Na registratie als abonnee kan de certificaatbeheerder namens de organisatie certificaten aanvragen, eventueel per post of e-mail. Op het aanvraagformulier vult de certificaatbeheerder een aantal gegevens, waaronder het OIN, in. Hoe het CSR aangemaakt wordt is per CSP verschillend, voor meer informatie verwijzen wij u naar uw CSP.

De websites van de CSP’s vermelden de precieze aanvraagprocedures en de te overleggen documenten.

De doorlooptijd van aanvraag tot levering bedraagt één tot drie weken; houd rekening met deze doorlooptijd in uw planning. Na ontvangst van het ondertekende certificaat dient het te worden geïnstalleerd.

### Hoe installeer ik een certificaat?

Zowel het door de CSP ondertekende certificaat als de geheime sleutel dienen te worden geïnstalleerd. Vervolgens dient men de applicatie zodanig te configureren dat ze gebruik kan maken van het certificaat. De precieze werkwijze voor installatie en gebruik van het certificaat kan per platform en applicatie erg verschillen, daarom is het niet mogelijk daarvoor concrete aanwijzingen te geven in dit document. Wij adviseren u de informatie van de CSP en de applicatieleverancier te raadplegen. Er is veel geschreven over de installatie en het beheer van certificaten. In het laatste hoofdstuk van dit document is een verwijzing naar enkele nuttige documenten opgenomen.

### Wat moet er worden opgestuurd waarheen en waarom?

Na succesvolle installatie van het certificaat dient de organisatie het publieke deel van het PKI-certificaat op gestuurd te worden naar het Kadaster. Het Kadaster gebruikt het OIN zoals vermeld in het certificaat voor autorisatie.

Bij het vernieuwen van een certificaat wordt deze procedure niet herhaald. Na het vaststellen van de identiteit communicatiepartner wordt enkel het OIN gebruikt voor het bepalen van de autorisatie.

Let op: Stuur alleen het publieke deel van het certificaat (NB in ZIP-formaat omdat deze anders niet aankomt via de mail) naar klic@kadaster.nl, niet de geheime sleutel! Die laatste dient u te allen tijde goed verborgen te houden. Neem in geval van twijfel contact op met uw leverancier. Het publieke deel kunt u altijd openen zonder een wachtwoord te hoeven gebruiken. Het begint vaak met de woorden "begin certificaat" dan allemaal letters en cijfers en vervolgens "einde certificaat".

Een eenvoudige manier om het certificaat te exporteren voor verzending is door vanuit een web-browser als Internet Explorer de volgende stappen te ondernemen:

Extra (Tools) &gt; Internetopties (Internet Options) &gt; Inhoud (Content) &gt; Certificaten (Certificates) &gt; Export. Selecteer het bewuste certificaat in het tabblad persoonlijk (personal) en kies voor exporteer. Het certificaat dient geëxporteerd te worden zonder privé-sleutel en in DER X509 formaat(.cer). Voor verzending dient het certificaat om beveiligingsredenen gezipt te worden.

### Welk type certificaat heb ik nodig?

Er bestaan diverse typen PKIoverheid-certificaten, zoals persoonsgebonden certificaten of organisatie/servicesgebonden certificaten. Voor de aansluiting op KLIC wordt het type *Services Servercertificaat* gebruikt. Dit type certificaat identificeert de server, het kan zijn dat dit anders heet bij uw CSP.

### Is het certificaat gekoppeld aan de organisatie, de servernaam, of iets anders?

Het certificaat bevat altijd de naam van de organisatie plus de identificerende gegevens van de server: Dit kan een domeinnaam zijn (een zogenaamde *fully qualified domain name*), een servernaam, of – minder gebruikelijk – het IP-adres waarop de server is te bereiken.

### Kan ik één certificaat gebruiken voor zowel KLIC als BAG als Wkpb?

De basisregel is dat een PKIoverheid-certificaat op maximaal één server tegelijk geïnstalleerd mag zijn. In principe kan hetzelfde certificaat van de organisatie dus worden gebruikt voor zowel KLIC, BAG als voor de Wkpb en andere toepassingen, mits deze allemaal op één en dezelfde server zijn geïnstalleerd als het certificaat.

Indien u de KLIC, BAG of Wkpb-applicatie op verschillende servers gaat implementeren, dan kunt u toch hetzelfde certificaat gebruiken door gebruik te maken van een zogenaamde proxy-server (zie onderstaande figuur). Of dit een optie is in uw technische infrastructuur kunt u het beste overleggen met de afdeling binnen uw organisatie die hierover gaat.

<image src="images/image4.png" width="579" height="321" />

### Hoe lang is een certificaat geldig?

Certificaten zijn drie jaar geldig vanaf de datum van afgifte. In verband met de levertijd van de PKI certificaten raden wij raden u aan om hier vroegtijdig een nieuw certificaat aan te vragen.

U hoeft de vernieuwing van uw certificaat niet aan ons door te geven omdat de identificatie op basis van het OIN nummer plaats vindt.

### Wat zijn de aanschafkosten voor een certificaat?

De kosten een 3 jaar geldig certificaat plus registratie bij de CSP verschillen. Voor de actuele prijzen kunt u de websites van de CSP’s raadplegen.

## Bijzondere situaties

### Kan ik hetzelfde certificaat hergebruiken bij vervanging van de server?

Bij vervanging van de server kan hetzelfde certificaat worden hergebruikt op de nieuwe server. Indien van het certificaat en de geheime sleutel geen kopieën zijn bewaard dan dienen deze eerst van de oude server te worden geëxporteerd. Vervolgens moeten het certificaat inclusief geheime sleutel van de oude server worden verwijderd en op de nieuwe server worden geïnstalleerd. De identificerende gegevens van de nieuwe server moeten identiek zijn aan de gegevens op het certificaat.

### Kan ik hetzelfde certificaat gebruiken bij virtual servers, redundantie, back-up of uitwijk?

Virtual servers hebben geen invloed op het gebruik van certificaten. Het certificaat kan worden geïnstalleerd en gebruikt op een virtual server alsof het om een fysieke server gaat.

Indien de applicatie tegelijk draait op meerdere servers ten behoeve van redundantie of load balancing, dan zal op elke server een ander certificaat moeten worden geïnstalleerd. Een alternatief is om gebruik te maken van een proxy-server (zie paragraaf 2.10).

De organisatie kan een back-up server inrichten met de applicatie erop geïnstalleerd, die normaal niet actief is maar uitsluitend ten behoeve van uitwijk klaarstaat. In dat geval moet op de back-up server *een ander certificaat* van de organisatie worden geïnstalleerd dan dat van de ‘hoofdserver’, omdat het certificaat slechts op één server tegelijk mag staan.

### Heb ik ook een certificaat nodig voor een testserver of alleen voor de productieserver?

Als de testserver berichten uitwisselt met de KLIC, bijv. voor testdoeleinden, dan is ook daarvoor een certificaat benodigd.

### Serviceprovider

Een Serviceprovider die door netbeheerders geautoriseerd is om namens hen informatie met KLIC uit te wisselen moet een eigen certificaat aanvragen. Een serviceprovider heeft een eigen identiteit en daarmee ook een OIN. Welke rechten de serviceprovider in KLIC heeft valt buiten de scope van dit PKI-document.

Een Netbeheerder die zijn KLIC diensten uitbesteed heeft aan een serviceprovider en zelf geen gebruik maakt van de B2B voorzieningen hoeft geen certificaat aan te schaffen.

### Kan ik gebruik maken van een testomgeving? 

Ja, dit is mogelijk. Hiervoor is de Netbeheerder Test Dienst beschikbaar. Indien U hier niet voor geautoriseerd bent kunt u deze autorisatie aanvragen bij Kadaster Klantcontactcenter.

### Voor meer informatie

Over PKIoverheid voor uw organisatie:

<https://www.logius.nl/diensten/pkioverheid/>

Indien u meer informatie wilt over PKIoverheid-certificaten voordat u een CSP kiest, of als u met uw vraag onvoldoende wordt geholpen door een CSP, dan kunt u contact opnemen met Logius de policy authority van PKIoverheid. Servicecenter Logius: Telefoon: 0900 - 555 4555 e-mail: <servicecentrum@logius.nl>.

De onderstaande tabel bevat een aantal gebruikte termen en afkortingen en begrippen die nader worden verklaard.

| Term of Afkorting | Verklaring |
| ----------------- | ---------- |
| CSP               | *Certificate Service Provider*<br>Een natuurlijke of rechtspersoon die certificaten afgeeft of andere diensten in verband met elektronische handtekeningen, identiteit en vertrouwelijkheid verleent.<br>De officiële Nederlandse term is ‘Certificatiedienstverlener’. |
| CSR               | *Certificate Signing Request*<br>Een ‘blanco certificaat’ met alleen de identificerende gegevens erop maar nog niet ondertekend door de CSP. Een CSR wordt pas bruikbaar nadat hij is ondertekend door een CSP; na ondertekening spreekt men van een certificaat. |
| Geheime sleutel   | Een klein digitaal bestand dat samen met het certificaat moet worden geïnstalleerd op de server. De geheime sleutel vormt samen met het certificaat een onlosmakelijk paar; zonder de geheime sleutel kan het certificaat niet worden gebruikt in de elektronische communicatie met de server. Doordat de organisatie als enige beschikt over haar geheime sleutel, weet KLIC zeker dat de berichten verzonden met het betreffende certificaat van de organisatie afkomstig moeten zijn.<br>De officiële Nederlandse term is ‘private sleutel’. |
| Publieke deel     | Het publieke deel kunt u altijd openen zonder een wachtwoord te hoeven gebruiken. Het begint vaak met de woorden "begin certificaat" dan allemaal letters en cijfers en vervolgens "einde certificaat". |
| Policy Authority  | Logius is de policy authority van PKIoverheid, deze rol bestaat uit de volgende taken:<br>-   het leveren van bijdragen voor de ontwikkeling en het beheer van het normenkader dat aan de PKI voor de overheid ten grondslag ligt, het zogeheten Programma van Eisen (PvE)<br>-   het proces van toetreding door Certification Service Providers (CSP's) tot de PKI voor de overheid begeleiden en voorbereiden van de afhandeling<br>-   het toezicht houden op en controleren van de werkzaamheden van CSP's die onder de root van de PKI voor de overheid certificaten uitgeven |

Zijn er vragen waarop u geen antwoord hebt kunnen vinden? Neem dan contact op met Kadaster Klantcontactcenter. Kadaster Klantcontactcenter: e-mail: <klic@kadaster.nl> Telefoon: 0800 - 0080. Onze medewerkers zijn u op werkdagen van 08:00 -17:00 uur graag van dienst.

[1]: Hiervoor is specifieke technische kennis en tools vereist. Raadpleeg hiervoor de afdeling die binnen uw organisatie belast is met dergelijke aanvragen, of vraag ondersteuning van de CSP.

[2]: De CSP’s hanteren verschillende namen voor deze rollen, maar de rolverdeling is dezelfde.

[3]: Het is ook toegestaan om iemand buiten de eigen organisatie te mandateren om als certificaatbeheerder op te treden, maar tenminste één certificaatbeheerder dient medewerker van de eigen organisatie te zijn.
