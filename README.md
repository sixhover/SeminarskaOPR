1. Uvod
Namen dokumenta: Ta navodila so pripravljena za vsakogar, ki bi rad preizkusil moj media player. Namenjena so hitri postavitvi okolja in zagonu programa brez kompliciranja.
Opis aplikacije: Predvajalnik je preprosto orodje za Windows, ki omogoča nalaganje, organizacijo in predvajanje glasbenih ter video datotek na enem mestu.

2. Sistemske zahteve
Strojna oprema: Vsak normalen računalnik ali prenosnik, ki poganja Windows. Potrebuješ vsaj kakšen GB prostora na disku in zvočnike (ali slušalke), da boš sploh kaj slišal.

Programska oprema: * Operacijski sistem: Windows 10 ali 11.

Orodja: Nameščen moraš imeti .NET SDK 6.0 (ali novejši) in pa Visual Studio 2022 (Community verzija je čisto dovolj).

Knjižnice: Program uporablja Windows Media Player (ActiveX), ki je ponavadi že del Windowsov, tako da s tem ne bi smelo biti težav.

3. Pridobitev programske opreme (GitHub)
Povezava do repozitorija: https://github.com/sixhover/SeminarskaOPR/

Postopek prenosa:

Z uporabo Gita: Odpri terminal (ali CMD) v mapi, kjer želiš imeti projekt, in vtipkaj:

git clone https://github.com/sixhover/SeminarskaOPR/

Brez Gita: Če nimaš nameščenega Gita, enostavno klikni na zeleni gumb "Code" na vrhu strani repozitorija in izberi "Download ZIP". Ko se prenese, datoteke samo razpakiraš v svojo mapo.

4. Namestitev in priprava okolja
Razširjanje datotek: Če si prenesel ZIP, ga razpakiraj nekam, kjer ga boš našel (npr. na Namizje ali v mapo Dokumenti).

Odpiranje projekta: Pojdi v to mapo in poišči datoteko, ki se konča na .sln (npr. SeminarskaOPR.sln). Dvakrat klikni nanjo in projekt se bo odprl v Visual Studiu.

Obnova paketov (NuGet): Ko se Visual Studio naloži, včasih manjka kakšna knjižnica. Desno klikni na ime projekta v "Solution Explorerju" in izberi "Restore NuGet Packages". To bo avtomatsko potegnilo vse, kar manjka.

5. Prevajanje in zagon (Build & Run)
Konfiguracija: Na vrhu v orodni vrstici preveri, da je nastavljeno na "Debug" in "Any CPU" (ali x86, če uporabljaš starejši player).

Prevajanje: Pritisni tipko F6 ali pojdi pod meni Build > Build Solution. Spodaj v oknu "Output" mora izpisati, da je bilo uspešno (0 failed).

Zagon: Ko je vse pripravljeno, samo pritisni F5 ali klikni na zeleni gumb "Start". Program bi se moral odpreti.

6. Navodila za prvo uporabo
Dodajanje datotek: Klikni gumb "Add". Odprlo se bo okno, kjer izbereš svoje MP3 ali MP4 datoteke. Te se bodo nato prikazale na seznamu (Playlista).

Iskanje: Na desni strani imaš iskalnik. Najprej izberi enega od RadioButtonov (npr. "Po naslovu"), vpiši besedo v polje in klikni "Search". Program bo takoj sfiltriral tvoj seznam.

Kontrole:

Play/Pause: Logično, za začetek in premor.

Skip/Backward: Za skok naprej ali nazaj za 10 sekund.

Fade: Super funkcija, ki počasi utiša glasbo in potem ugasne player (uporabno za zvečer).

7. Reševanje težav (Troubleshooting)
Napake pri ActiveX: Če ti Visual Studio javi, da ne najde AxWMPLib, pomeni, da nimaš registrirane komponente Media Playerja. Ponavadi pomaga, če samo enkrat zaženeš klasični Windows Media Player na računalniku ali pa v Visual Studiu ponovno dodaš to komponento v "Toolbox".

Manjkajoči SDK: Če projekt sploh noče "buildat", preveri, če imaš pravo verzijo .NET SDK-ja. Dobiš ga na Microsoftovi uradni strani.
