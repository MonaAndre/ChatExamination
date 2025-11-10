# Praktisk Examination – Chatklient med Socket.IO (Konsolapp)

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

- [x]Ange användarnamn vid start (validera att det inte är tomt).
- [x]Ansluta till chatten och se status (ansluten/urkopplad).
- [x]Skicka och ta emot meddelanden i realtid.
- Se tidsstämpel, avsändare och meddelandetext för varje meddelande.
- Se händelser i chatten, t.ex. när någon joinar eller lämnar.
- [x]Avsluta programmet snyggt (koppla ner och städa resurser).

---

## Bonusdelar

- Persistens: Spara/ladda meddelandehistorik till/från appen mellan start.
- En meny eller kommandon (ex `/help`, `/quit`, `/history 20`).
- Direktmeddelanden: `/dm <user> <text>`
- Kanaler/rum: Stöd för att gå med i/byta rum, t.ex. `/join general`.
- Indikator när någon skriver, exempelvis "Ahmad skriver...".

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

Branch:

– Add typing indicator
– Fixed timing issue
– Proper formatting
– Fix typing when mulitple indicators
– Clean up

====

Main:

– Add typing indicator
– Add help menu
– Display messages formatted
– Initial commit

Feat: Add typing indicator

Fix: Formatting issue

Squash Merge istället för vanlig merge

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

https://medieinstitutet-my.sharepoint.com/:x:/g/personal/ahmad_ardal_elevera_org/ESo2xMqnxIRIr88SXVQC-DcBsB9hBIPok6KkDqVZtHRcLw
