# Erstes Weekly 16.02.2026

## Projekt
- Projektfindung: Motoscout nachmachen
- Webprojekt
- Projekt soll simpel sein
- Fokus auf Modell-Methoden

## Rollen
- Luka – Entwickeln
- Jan – Scrum Master
- Artian – Dokumentation

## Erste Schritte
- Mit Kunde Produkt besprechen
- user stories erstellen
- Methode finden
- Login entwickeln
- Mit Kunde besprechen ob das Login passt
- Dokumentation am Ende vom Tag nachführen
- 

# Motoscout Webapplikation – User Stories

## Übersicht
Projekt: Webapplikation zur Verwaltung und Suche von Fahrzeuginseraten  
Ziel: Benutzer können Fahrzeuge inserieren, suchen und verwalten.

---

## 1. Registrierung & Login

### US1 – Registrierung (Must)
**Als** Besucher  
**möchte ich** mich registrieren können,  
**damit** ich eigene Fahrzeuge inserieren kann.

**Akzeptanzkriterien:**
- Eingabe von E-Mail und Passwort
- E-Mail darf noch nicht existieren
- Benutzer wird in der Datenbank gespeichert

---

### US2 – Login (Must)
**Als** registrierter Benutzer  
**möchte ich** mich einloggen können,  
**damit** ich auf meine Inserate zugreifen kann.

**Akzeptanzkriterien:**
- E-Mail und Passwort werden überprüft
- Bei falschen Daten erscheint eine Fehlermeldung
- Erfolgreicher Login leitet auf Dashboard weiter

---

## 2. Fahrzeugsuche

### US3 – Fahrzeuge suchen (Must)
**Als** Besucher  
**möchte ich** Fahrzeuge nach Marke und Modell filtern können,  
**damit** ich gezielt suchen kann.

**Akzeptanzkriterien:**
- Filter nach Marke möglich
- Filter nach Modell möglich
- Ergebnisse werden dynamisch angezeigt

---

### US4 – Preisfilter (Should)
**Als** Benutzer  
**möchte ich** Fahrzeuge nach Preisbereich filtern können,  
**damit** ich nur passende Angebote sehe.

**Akzeptanzkriterien:**
- Minimal- und Maximalpreis definierbar
- Nur Inserate im Preisbereich werden angezeigt

---

### US5 – Detailansicht (Must)
**Als** Besucher  
**möchte ich** eine Detailansicht eines Fahrzeugs öffnen können,  
**damit** ich alle Informationen sehe.

**Akzeptanzkriterien:**
- Anzeige von Bildern
- Anzeige von Preis, Kilometerstand, Beschreibung
- Verkäuferinformationen sichtbar

---

## 3. Inserate verwalten

### US6 – Inserat erstellen (Must)
**Als** registrierter Benutzer  
**möchte ich** ein Fahrzeug inserieren können,  
**damit** ich es verkaufen kann.

**Akzeptanzkriterien:**
- Pflichtfelder: Marke, Modell, Preis, Kilometerstand
- Preis darf nicht negativ sein
- Inserat wird in der Datenbank gespeichert

---

# Weekly 16.02.2026

## Ziele für heute

- Methode finden
- Login entwickeln

## Welche Methoden werden wir benutzen für unser Projekt?

- Design thinking
-

## Unsere Ziele 


## Gherkin

---

## Gherkin – Akzeptanztests

Gherkin wird verwendet, um Anforderungen in einem klaren Format zu definieren.

### Struktur

- **Given** – Ausgangszustand
- **When** – Aktion des Nutzers
- **Then** – Erwartetes Ergebnis

---

## Login

### Positiv-Szenario

**Given:** Ich bin auf der Login-Seite und habe ein gültiges Konto.  
**When:** Ich gebe meine E-Mail und mein Passwort korrekt ein und klicke auf "Login".  
**Then:** Ich werde auf das Dashboard weitergeleitet.

### Negativ-Szenario

**Given:** Ich bin auf der Login-Seite.  
**When:** Ich gebe ein falsches Passwort ein.  
**Then:** Ich sehe eine Fehlermeldung und bleibe auf der Seite.

---

## Registrierung

**Given:** Ich bin auf der Registrierungsseite.  
**When:** Ich gebe eine E-Mail und ein Passwort ein und klicke auf "Registrieren".  
**Then:** Ein Benutzer wird in der Datenbank erstellt.

---

## Fahrzeuge suchen

**Given:** Ich bin auf der Suchseite.  
**When:** Ich wähle eine Marke oder ein Modell aus.  
**Then:** Es werden passende Fahrzeuge angezeigt.

---

## Inserat erstellen

**Given:** Ich bin als Benutzer eingeloggt.  
**When:** Ich gebe Marke, Modell, Preis und Kilometerstand ein und speichere das Inserat.  
**Then:** Das Inserat wird in der Datenbank gespeichert und angezeigt.

---

## Release Ziel

- Einfaches **MVP der Webapplikation**
- Benutzer können sich **registrieren und einloggen**
- Benutzer können **Fahrzeuge suchen**
- Benutzer können **Inserate erstellen**

## 4. Definition of Done (DoD)

### Eine Story gilt als abgeschlossen wenn:

- Funktion implementiert ist
- Daten korrekt in der Datenbank gespeichert werden
- Akzeptanzkriterien erfüllt sind
- Code im Repository gespeichert ist
- README Dokumentation aktualisiert wurde

---

## Synergie mit M165 (CRUD & Datenbank)

Im Sprint 1 werden die ersten CRUD Operationen implementiert.

### Create
- Benutzer registrieren
- Fahrzeug inserieren

### Read
- Fahrzeuge anzeigen
- Benutzer laden

### Update
- Wird in späteren Sprints umgesetzt

### Delete
- Wird in späteren Sprints umgesetzt

### Zusätzlich:

- Verbindung zur Datenbank herstellen
- Validierung der Datenmodelle

# Sprint 1 Retrospektive

## Ziel der Retrospektive

Reflexion der Zusammenarbeit im Team und Identifikation von Verbesserungen für den nächsten Sprint.

---

## Was lief gut (Continue)

- Die Rollen im Team waren klar verteilt (Entwicklung, Scrum Master, Dokumentation).
- User Stories wurden früh definiert.
- Akzeptanzkriterien wurden für die wichtigsten Funktionen erstellt.
- Die Zusammenarbeit im Team war konstruktiv.
- Die technische Basis der Applikation konnte erfolgreich umgesetzt werden.

---

## Was lief nicht optimal (Stop)

- Einige Aufgaben waren am Anfang nicht klar genug definiert.
- Die Aufteilung der Tasks hätte früher gemacht werden können.
- Kommunikation über den Fortschritt hätte regelmässiger stattfinden können.

---

## Was wollen wir verbessern (Start)

- Tasks im Sprint genauer definieren.
- Regelmässig den Fortschritt im Team besprechen.
- Früher mit der Implementierung beginnen.
- Dokumentation parallel zur Entwicklung aktualisieren.

---

## Massnahmen für Sprint 2

- Klarere Task-Aufteilung zu Beginn des Sprints.
- Regelmässige kurze Abstimmungen im Team.
- Fortschritt im Repository oder Taskboard festhalten.
