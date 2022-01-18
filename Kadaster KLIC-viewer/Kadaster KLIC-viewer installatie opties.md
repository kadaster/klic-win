# Parameters meegeven in commandline bij installeren Kadaster KLIC-viewer

## NSIS KLIC-viewer Installer Opties

KLIC levert voor Windows KLIC-viewer een desktop applicatie. Deze kan geïnstalleerd worden met een NSIS installer.

De Kadaster KLIC-viewer kan via de commandline geïnstalleerd met verschillende opties.

- **/S** Silent install
- **/D** Geef een locatie voor installatie mee bv. `C:\Program Files\NSIS`
- **/CurrentUser** Installeer voor de huidige gebruiker
- **/AllUsers** Installeer voor alle gebruikers van de machine


Wordt er gekozen voor _CurrentUser_ zonder meegave van een locatie dan is de standaard locatie:
`C:\Users\{CURRENT_USERNAME}\AppData\Local\Programs\Kadaster KLIC-viewer`

Wordt er gekozen voor _AllUsers_ zonder meegave van een locatie dan is de standaard locatie:
`C:\Program Files\Kadaster\Kadaster KLIC-viewer`

Wordt er ook nog de _/S_ optie meegegeven dan installeert hij zonder GUI.



**Advies is om voor _AllUsers_ te installeren en de verschillende versies altijd met dezelfde installatiemodus te installeren.**

**Vanaf de commandline is dat bijvoorbeeld op deze wijze:**
 `& '.\Kadaster KLIC-viewer Setup 5.7.4.exe' /AllUsers` 



Bij de installatie van de Kadaster KLIC-viewer wordt er automatisch een snelkoppeling op het Bureaublad en een snelkoppeling in het StartMenu gezet onder de folder 'Kadaster'.

Let er op dat dit commando moet worden uitgevoerd in een Powershell die draait met Administrator rechten; anders kan de `/AllUsers` niet worden uitgevoerd. De `/CurrentUser` optie werkt dan wel.



## Mogelijke problemen
Worden er verschillende versies met verschillende installModus op verschillende plekken gezet, dan kunnen er problemen ontstaan bij het de-installeren.

Het kan dat de Uninstaller niet gevonden kan worden als men het probeert via Apps / Features.
Er komt dan een melding dat de applicatie niet meer bestaat.
Er blijven dan bijvoorbeeld snelkoppelingen bestaan op het Bureaublad en/of in het Start menu. 
Kijk in dat geval waar de snelkoppelingen precies heen leiden. Bekijk of er op die locatie de uninstaller staat genaamd ‘Uninstall Kadaster KLIC-viewer.exe’. Deze dient dan opgestart te worden.

Het kan zijn dat de entry puur een restant is van een andere de-installatie en dat de applicatie er überhaupt niet meer is. De entry kan dan verwijderd worden in de registry.

Open via Run => regedit
Ga naar:
`Computer\HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall`
Zoek dan de wees entry en verwijder hem. Hij verdwijnt dan uit de lijst met entries in Apps / Features.


## Installatie op een Netwerk Share

Het installeren van de Kadaster KLIC-viewer op een netwerk share wordt niet ondersteund. 

  De Kadaster KLIC-viewer is een Electron app. Kort gezegd is dat een webapplicatie verpakt in een uitgeklede Chrome browser.  \
Het lijkt er op dat er een beperking in chromium zit en dat dit een security gerelateerde keuze is. Zie ook https://bugs.chromium.org/p/chromium/issues/detail?id=103902#c27  \
Wij adviseren om de Kadaster KLIC-viewer op elke client te installeren via de standaard installatie procedure.  \
Zelfs als het zou lukken om de huidige versie op een share te installeren dan is er geen enkele garantie dat dit blijft werken na de volgende update. 

