
2. Sistemske zahteve
Strojna oprema: Vsak normalen računalnik ali prenosnik, ki poganja Windows. Potrebuješ vsaj kakšen GB prostora na disku in zvočnike (ali slušalke), da boš sploh kaj slišal.



Knjižnice: Program uporablja Windows Media Player (ActiveX), ki je ponavadi že del Windowsov, tako da s tem ne bi smelo biti težav.

3. Pridobitev programske opreme (GitHub)
Povezava do repozitorija: https://github.com/sixhover/SeminarskaOPR/

Postopek prenosa:




4. Namestitev in priprava okolja
Razširjanje datotek: Če si prenesel ZIP, ga razpakiraj nekam, kjer ga boš našel (npr. na Namizje ali v mapo Dokumenti).

Odpiranje projekta: Pojdi v to mapo in poišči datoteko, ki se konča na .sln (npr. SeminarskaOPR.sln). Dvakrat klikni nanjo in projekt se bo odprl v Visual Studiu.


5. Prevajanje in zagon (Build & Run)
Konfiguracija: Na vrhu v orodni vrstici preveri, da je nastavljeno na "Debug" in "Any CPU" (ali x86, če uporabljaš starejši player).

Prevajanje: Pritisni tipko F6 ali pojdi pod meni Build > Build Solution. Spodaj v oknu "Output" mora izpisati, da je bilo uspešno (0 failed).


6. Navodila za prvo uporabo
Dodajanje datotek: Klikni gumb "Add". Odprlo se bo okno, kjer izbereš svoje MP3 ali MP4 datoteke. Te se bodo nato prikazale na seznamu (Playlista).

Iskanje: Na desni strani imaš iskalnik. Najprej izberi enega od RadioButtonov (npr. "Po naslovu"), vpiši besedo v polje in klikni "Search". Program bo takoj sfiltriral tvoj seznam.



Skip/Backward: Za skok naprej ali nazaj za 10 sekund.

Fade: Super funkcija, ki počasi utiša glasbo in potem ugasne player (uporabno za zvečer).


Manjkajoči SDK: Če projekt sploh noče "buildat", preveri, če imaš pravo verzijo .NET SDK-ja. Dobiš ga na Microsoftovi uradni strani.
