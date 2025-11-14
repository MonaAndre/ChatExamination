# Praktisk Examination – Chatklient med Socket.IO (Konsolapp)
Mona Elizaveta Andreeva

Chatklient med Socket.IO projekt är en modern konsolbaserad chattapplikation byggd med .NET.  
Syftet är att ge en enkel men robust realtidschatt med stöd för:

- användarregistrering  
- inloggning  
- realtidsskickade meddelanden  
- typing-indikatorer  
- meddelandehistorik  
- validering av input  
- server–klient kommunikation via Socket.IO  

## 📸 Programmet i användning
### Startmenyn
Så här ser huvudmenyn ut när applikationen startas:
![photo_2025-11-14_15-17-04](https://github.com/user-attachments/assets/b8437f52-7abe-4fb5-beff-7a56cc74c47c)

## 🚀 Funktioner
### 🔐 1. Logga in
Användaren kan logga in med ett befintligt konto och kommer in i chatten direkt
![photo_2025-11-14_15-17-32](https://github.com/user-attachments/assets/2ad270e1-dd2b-4330-b7b4-bafc02a5ce55)

### 🆕 2. Registrera ny användare
Nya användare kan skapas direkt via konsolen, därefter kan användaren logga in med den nya username och lösenord
![photo_2025-11-14_15-21-24](https://github.com/user-attachments/assets/188f5ecb-2f3a-425c-bf3d-25a7387e019f)

### 💬 3. Chatta i realtid
När man är inloggad ansluter man till chatten och kan skicka meddelanden i realtid.
Funktioner i chatten:
- Skicka och ta emot meddelanden
- Validering av tomma meddelanden
- "Typing…"-indikator
![photo_2025-11-14_15-24-50](https://github.com/user-attachments/assets/c370dd95-1d7a-4b37-ae8e-c5f29f31508e)

- Open chat instruktion med /help
![photo_2025-11-14_15-25-48](https://github.com/user-attachments/assets/532fb803-a953-4236-a281-abc676d10cad)

- Se meddelandehistorik med /history 2
![photo_2025-11-14_15-26-15](https://github.com/user-attachments/assets/e02a013f-08d3-470d-a7f1-ce6ed58b4e94)

- Avsluta chatten med /quit vilket skickar användaren till huvudmenyn
![photo_2025-11-14_15-26-51](https://github.com/user-attachments/assets/179197d9-cb84-47a5-9b7f-0f4b2d959d93)

### 4. Avsluta applikation
Användaren kan stänga av application genom att välja 3 i huvudmenyn
![photo_2025-11-14_15-22-28](https://github.com/user-attachments/assets/a1c2112f-d52a-41c4-a428-dec42afb2781)

## ⚙️ Teknisk struktur

### **Projektet består av:**

| Fil / Klass        | Beskrivning |
|--------------------|-------------|
| `Menu.cs`          | Hanterar huvudmenyn, val av funktioner och navigering |
| `Chat.cs`          | Huvudlogik för chattslingan, användarinput och validering |
| `SocketManager.cs` | Hanterar serveranslutning, event-sändning och mottagning (Socket.IO) |
| `Message.cs`       | Modell för meddelanden, inklusive formatering och presentation |
| `User.cs`          | Registrering, inloggning och användarhantering |

## 🔧 Installation & Körning
```bash
git clone https://github.com/MonaAndre/ChatExamination.git
```
```bash
cd ChatExamination
```
```bash
dotnet run
```


-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
**Kurs**: Introduktion till C#  
**Examinerar**: Läranderesultat 4, 5, 6  
**Betyg**: IG / G / VG  
**Arbetstid**: 2 veckor (start v45, inlämning senast söndag v46, 23:59)  
**Format**: Komplett C# konsolapplikationsprojekt

---

## Läranderesultat

Efter godkänd inlämning ska du kunna:

4. Skapa konsolapplikationer som använder objektorienterad programmering
5. Arbeta med komplexa objektstrukturer och arv
6. Använda objekt och OOP-koncept för att lösa problem

---

## Uppgiften och krav (G)

Bygg en konsolbaserad chatklient som ansluter till en färdig Socket.IO-server. Användaren ska kunna:

- [x] Ange användarnamn vid start (validera att det inte är tomt).
- [x] Ansluta till chatten och se status (ansluten/urkopplad).
- [x] Skicka och ta emot meddelanden i realtid.
- [x] Se tidsstämpel, avsändare och meddelandetext för varje meddelande.
- [x] Se händelser i chatten, t.ex. när någon joinar eller lämnar.
- [x] Avsluta programmet snyggt (koppla ner och städa resurser).

---

## Bonusdelar

- Persistens: Spara/ladda meddelandehistorik till/från appen mellan start.
- [x] En meny eller kommandon (ex `/help`, `/quit`, `/history 20`).
- Direktmeddelanden: `/dm <user> <text>`
- Kanaler/rum: Stöd för att gå med i/byta rum, t.ex. `/join general`.
- [x] Indikator när någon skriver, exempelvis "Ahmad skriver...".

---

## Verktyg (C#)

Installera Socket.IO-klienten genom terminalen i din projektmapp:

```bash
dotnet add package SocketIOClient
```

Server-URL: `wss://api.leetcode.se`

Path: `/sys25d`

Ladda ner exempelprojektet för att se exempel på hur ni kan ansluta och skicka/ta emot händelser.

---

## Inlämning

1. Källkod (GitHub-repo)
2. README med: hur man kör, vilka kommandon som finns.

---

## Bedömning (IG/G/VG)

För G ska följande vara uppfyllt:

- Samtliga funktionella krav fungerar.
- Fungerande användarupplevelse.
- Kompilerar och kör utan kritiska fel.
- Git har använts.

För VG ska följande vara uppfyllt:

- Samtliga G-krav ovan.
- Åtminstone tre punkter från bonusdelarna.
- Välgjord användarupplevelse.
- Meningsfulla namn, konsekvent namngivning, kod som inte upprepar sig själv. Städad kod. Koden går att förstå utan kommentarer.
- Välstrukturerad Git-historik med meningsfulla namn på commits.

---

## Regler

- Använd aldrig AI på examinationsuppgifter, upptäckt av AI-användning kan leda till avstängning.
- Ni får samarbeta i grupp om högst två.
- Ni får inte plagiera på andra gruppers kod. Er app får vara kompatibel med andra grupper genom ett överenskommet protokoll, men
  ni får inte samarbeta mellan grupper i själva byggandet; endast inom den egna gruppen.

## Gruppering

- Man får vara ensam om man vill, men jag rekommenderar alla att vara med i grupp. Varje grupp blir isåfall två personer.
- Fyll i hur ni önskar grupperas i länken neda.
- Jag kommer att slumpa fram grupper. Detta är för att kunna säkerställa en bra blandning av klassen.
