# Seminarska Naloga: Multimedijski Predvajalnik (SeminarskaOPR)

**Predmet**: Objektno Programiranje (OPR)  
**Šola**: Srednja Šola Celje  
**Jezik**: C# (.NET Framework 4.7.2)  
**Tehnologija**: Windows Forms  
**Datum**: 2024

---

## 1. Uvod

Seminarska naloga opisuje razvoj **multimedijskega predvajalnika** - aplikacije, ki omogoča predvajanje avdio in video vsebin iz računalnika. Aplikacija je razvita z uporabo objektno orientiranega programiranja (OOP) v jeziku C# z grafičnim vmesnikom Windows Forms.

Namen aplikacije je demonstracija **naprednih konceptov OOP**, kot so:
- **Polimorfizem** (različne vrste medijev)
- **Dedovanje** (AudioItem in VideoItem dedujeta od MediaItem)
- **Delegati in Eventi** (za fleksibilno komunikacijo med objekti)
- **Inkapsuacija** (prikrivanje notranje logike)

Aplikacija omogoča osnovno upravljanje s predvajalniki:
- Dodajanje pesmi in videov
- Predvajanje, pavziranje, premotavanje
- Iskanje in filtriranje po različnih kriterijih
- Kontrolo glasnosti s posebnimi efekti

---

## 2. Funkcionalne Zahteve

Aplikacija mora zagotavljati naslednje funkcionalnosti:

### Osnovne Funkcionalnosti Predvajanja
- Uporabnik lahko **dodaja nove datoteke** (MP3, WAV, MP4, AVI) v playlistu
- Uporabnik lahko **predvaja izbrano pesem** s klikom na gumb "Predvajaj"
- Uporabnik lahko **pauzira** trenutno predvajajočo pesem
- Uporabnik lahko **prehaja med pesmijo** (naslednja, prejšnja)
- Uporabnik lahko **dostopa do kontrole glasnosti** preko drsnika

### Napredne Kontrole
- Uporabnik lahko **preskoči naprej/nazaj** za 10 sekund v pesmi
- Uporabnik lahko **utišane in reaktivira** zvok s klikom na "Utišaj"
- Uporabnik lahko **počasi zmanjša glasnost** s klikom na "Fade Out"
- Uporabnik lahko **gleda video v polnem zaslonu** (samo za video datoteke)
- Sistem **avtomatsko predi na naslednjo pesem** ko se trenutna konča

### Upravljanje Playliste
- Uporabnik lahko **sortira pesmi po trajanju**
- Uporabnik lahko **naključno meša pesmi** (Shuffle)
- Sistem **preprečuje dodajanje duplikatov** in prikaže obvestilo
- Sistem **shranjuje statistiko** koliko pesmi je bilo predvajanih

### Iskanje in Filtriranje
- Uporabnik lahko **išče pesmi po naslovu**
- Uporabnik lahko **filtrira po trajanju** (le pesmi daljše od 5 minut)
- Uporabnik lahko **filtrira po tipu** (samo video ali samo audio)
- Rezultati se **posodabljajo v realnem času**

---

## 3. Opis Arhitekture

### 3.1 Razred MediaItem - Osnovna Klasa

```csharp
public abstract class MediaItem
{
    public string Title { get; set; }
    public string FilePath { get; set; }
    public TimeSpan Duration { get; set; }
    public MediaType Type { get; set; }
    
    public virtual string GetInfo()
    {
        return $"{Title} ({Duration.Minutes}m {Duration.Seconds}s)";
    }
}
```

**Opis**: `MediaItem` je **abstraktna osnovna klasa**, ki predstavlja splošni multimedijski predmet. Vsak multimedijski predmet ima:
- **Title** - naslov pesmi/videa
- **FilePath** - pot do datoteke
- **Duration** - trajanje
- **Type** - tip (audio ali video)

Klasa ima tudi metodo `GetInfo()`, ki vrne tekstovni opis predmeta.

### 3.2 Izpeljani Razredi - Polimorfizem

#### AudioItem - Zvočna Datoteka

```csharp
public class AudioItem : MediaItem
{
    public AudioItem(string filePath)
    {
        FilePath = filePath;
        Title = Path.GetFileNameWithoutExtension(filePath);
        Type = MediaType.Audio;
        Duration = TimeSpan.FromMinutes(5); // privzeta vrednost
    }

    public override string GetInfo()
    {
        return $"🎵 {base.GetInfo()}";
    }
}
```

**Opis**: `AudioItem` je **izpeljani razred** od `MediaItem`, ki predstavlja zvočno datoteko (MP3, WAV). Ko ustvarimo nov `AudioItem`, se avtomatsko nastavi tip na `Audio`.

#### VideoItem - Video Datoteka

```csharp
public class VideoItem : MediaItem
{
    public VideoItem(string filePath)
    {
        FilePath = filePath;
        Title = Path.GetFileNameWithoutExtension(filePath);
        Type = MediaType.Video;
        Duration = TimeSpan.FromMinutes(10); // privzeta vrednost
    }

    public override string GetInfo()
    {
        return $"🎬 {base.GetInfo()}";
    }
}
```

**Opis**: `VideoItem` je **izpeljani razred** za video datoteke (MP4, AVI). Podoben kot `AudioItem`, vendar s tipom `Video`.

**Polimorfizem**: Oba razreda preglasita (override) metodo `GetInfo()`, da vrneta drugačen opis z različno ikono. To je primer **polimorfizma** - isti tip objekta (MediaItem) ima različno obnašanje glede na to, ali je audio ali video.

### 3.3 Razred Playlist - Upravljanje Zbirke

```csharp
public class Playlist
{
    private MediaItem[] items;      // tabela objektov
    private int count;              // trenutno število predmetov
    
    public int Count { get { return count; } }
    
    // Indeksiranje
    public MediaItem this[int index]
    {
        get
        {
            if (index >= 0 && index < count)
                return items[index];
            return null;
        }
    }
}
```

**Opis**: `Playlist` upravljal z zbirko mediajev:
- **Tabela objektov** (`items[]`) - shranjuje vse dodane medije
- **Indeksiranje** (`this[index]`) - omogoča dostop s `playlist[0]`, `playlist[1]`, itd.
- **Dinamično povečevanje** - ko je tabela polna, se podvoji

### 3.4 Napredni Koncept: Delegati

Delegati so **tipi funkcij** - omogočajo nam, da funkcije podajamo kot parametre. V našem projektu uporabljamo delegate za **fleksibilno iskanje**.

#### FilterKriterij Delegate

```csharp
public delegate bool FilterKriterij(MediaItem item);
```

To je delegate, ki:
- Sprejme en parameter tipa `MediaItem`
- Vrne `bool` (true/false)

#### Metoda Isci - Iskanje z Delegatom

```csharp
public MediaItem[] Isci(FilterKriterij kriterij)
{
    List<MediaItem> rezultati = new List<MediaItem>();
    
    for (int i = 0; i < count; i++)
    {
        if (kriterij(items[i]))  // pokličemo delegate
        {
            rezultati.Add(items[i]);
        }
    }
    
    return rezultati.ToArray();
}
```

**Kako Deluje**:
1. Metoda `Isci` sprejme delegate `kriterij`
2. Za vsak predmet v playlisti pokliče delegate: `kriterij(items[i])`
3. Delegate vrne true/false
4. Če je true, se predmet doda v rezultate

#### Uporaba v Form1 - RadioButtoni in Lambda Izrazi

V glavnem oknu aplikacije (`Form1`) ima uporabnik **tri možnosti iskanja** preko RadioButtonov:

```csharp
private void buttonSearch_Click(object sender, EventArgs e)
{
    Playlist.FilterKriterij izbraniKriterij = null;

    if (rbTitle.Checked)
    {
        // Iskanje po naslovu
        string iskaniNiz = textSearch.Text.ToLower();
        izbraniKriterij = x => x.Title.ToLower().Contains(iskaniNiz);
    }
    else if (rbDuration.Checked)
    {
        // Iskanje po trajanju (več kot 5 minut)
        izbraniKriterij = x => x.Duration.TotalMinutes > 5;
    }
    else if (rbVideo.Checked)
    {
        // Iskanje samo videa
        izbraniKriterij = x => x.Type == MediaType.Video;
    }

    // Pokličemo metodo Isci s delegatom
    if (izbraniKriterij != null)
    {
        MediaItem[] rezultati = playlist.Isci(izbraniKriterij);
        OsveziPrikaz(rezultati);
    }
}
```

**Razlaga Lambda Izrazov**:

1. **`x => x.Title.ToLower().Contains(iskaniNiz)`**
   - `x` je parameter (MediaItem)
   - Vrne true, če naslov vsebuje iskani niz
   - Primer: iskanje "song" vrne vse pesmi z "song" v naslovu

2. **`x => x.Duration.TotalMinutes > 5`**
   - Vrne true, če je pesem daljša od 5 minut
   - Primer: filtrira samo dolge pesmi

3. **`x => x.Type == MediaType.Video`**
   - Vrne true, če je tip video
   - Primer: prikaže samo videoposnetke

**Prednosti Delegatov**:
- ✅ Ista metoda `Isci()` za različne tipe iskanja
- ✅ Ni potrebno pisati tri različne metode
- ✅ Fleksibilnost - lahko enostavno dodamo nove kriterije

---

## 4. Namestitvena Dokumentacija

### 4.1 Prenos iz GitHub-a

```bash
# Odprite Command Prompt ali PowerShell
git clone https://github.com/sixhover/SeminarskaOPR.git
cd SeminarskaOPR
```

Če nimate Git-a:
1. Pojdite na https://github.com/sixhover/SeminarskaOPR
2. Kliknite **Code → Download ZIP**
3. Razpakirajte datoteko

### 4.2 Priprava v Visual Studiu

1. **Odprite Visual Studio**
2. Izberite **File → Open → Project/Solution**
3. Poiščite `SeminarskaOPR.sln`
4. Kliknite **Open**

### 4.3 Obnova NuGet Paketov

Visual Studio bi moral avtomatski obnoviti pakete. Če ne:

1. Desni klik na Solution → **Manage NuGet Packages for Solution**
2. Kliknite **Restore**

### 4.4 Prevajanje in Zagon

**Prevajanje**:
- Izberi **Build → Build Solution**
- Ali pritisnite `Ctrl + Shift + B`

**Zagon**:
- Pritisnite **F5** ali **Debug → Start Debugging**
- Aplikacija se bo odprla

---

## 5. Navodila za Uporabo

### 5.1 Grafični Vmesnik

```
┌─────────────────────────────────────────────┐
│  Kontrole Predvajanja                       │
├─────────────────────────────────────────────┤
│  [Predvajaj] [Pauziraj] [Prejšnja]         │
│  [Naslednja] [Utišaj] [Fade Out]           │
│  [Polni Zaslon] [Skip] [Backward]          │
├─────────────────────────────────────────────┤
│  Glasnost: [========→]                      │
├─────────────────────────────────────────────┤
│  Iskanje: [Besedilo_____]  [Iskalnik]      │
│  ⊙ Po naslovu                              │
│  ○ Po trajanju                             │
│  ○ Samo video                              │
├─────────────────────────────────────────────┤
│  [Pesem 1 - 3:45]                          │
│  [Pesem 2 - 4:22]                          │
│  [Pesem 3 - 5:10]                          │
├─────────────────────────────────────────────┤
│  Status: Predvajanih pesmi: 5              │
└─────────────────────────────────────────────┘
```

### 5.2 Osnovni Koraki

#### Dodajanje Pesmi
1. Kliknite **"Dodaj"**
2. Izberite datoteko (MP3, WAV, MP4, AVI)
3. Pesem se doda v seznam

#### Predvajanje
1. Kliknite na pesem v seznamu
2. Kliknite **"Predvajaj"**

#### Iskanje
1. Vpišite besedilo v iskalno polje
2. Izberite kriterij (Po naslovu, Po trajanju, Samo video)
3. Kliknite **"Iskalnik"**

#### Kontrola Glasnosti
- **Drsnik**: Premikajte za spremembo glasnosti
- **Utišaj**: Toggling med tiho in prejšnjo glasnostjo
- **Fade Out**: Počasno zmanjšanje do tišine

---

## 6. Zaključek

### 6.1 Kaj Smo Se Naučili

Ta projekt demonstrira ključne koncepte objektnega programiranja:

1. **Polimorfizem**: `AudioItem` in `VideoItem` dedujeta od `MediaItem` in preglasita metodo `GetInfo()`
2. **Dedovanje**: Izpeljani razredi podedujejo lastnosti od osnovnega razreda
3. **Inkapsuacija**: Logika je skrieta v razredih, vmesnik je preprost
4. **Delegati in Eventi**: Fleksibilna komunikacija med objekti
5. **Indeksiranje**: Dostop do elementov prek `[]` operatorja

### 6.2 Možne Nadgradnje

Projekt ima velik potencial za nadgradnje:

- **Share na Social Media**: Gumb za deljenje pesmi/videov na Facebook, Twitter, itd.
- **Indekser s Časom**: Indekser, ki sprejme številko in preskoči na točen čas v pesmi
- **Playlistze Datoteke**: Shranjevanje in nalaganje playlist-ov (XML, JSON)
- **Grafični Ekvalizator**: Upravljanje z visokimi in nizkimi toni
- **Naslage**: Ustvarjanje in upravljanje z večimi playlistami
- **Prikaz Lirik**: Prikazovanje besedila pesmi med predvajanjem
- **Nalepke**: Uređevanje metapodatkov (naslov, izvajalec, album)
- **Dark Mode**: Temna tema za uporabnikov vmesnik

### 6.3 Zaključek

SeminarskaOPR je odličen primer **praktiške uporabe objektnega programiranja v realnem projektu**. Aplikacija spojuje teoretične koncepte (dedovanje, polimorfizem, delegati) s praktičnim, uporabno funkcionalnostjo, ki jo lahko uporabniki res uporabljajo za predvajanje svoje glasbe in videov.

Projekt služi kot **osnova za učenje** in **startna točka za nadaljnji razvoj** z bolj naprednimi funkcionalnostmi.

---

## Literatura in Reference

- **C# Dokumentacija**: https://docs.microsoft.com/en-us/dotnet/csharp/
- **.NET Framework 4.7.2**: https://dotnet.microsoft.com/download/dotnet-framework
- **Windows Forms**: https://docs.microsoft.com/en-us/dotnet/desktop/winforms/
- **Delegati v C#**: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/

---

**Avtor**: Žiga Korez
**Mentor**: Jaka Koren 
**Datum**: 2026
**Šola**: Srednja Šola Celje
