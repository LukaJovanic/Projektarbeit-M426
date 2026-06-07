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

# Product Backlog

| Priorität | ID   | User Story         | Story Points |
| --------- | ---- | ------------------ | ------------ |
| Must      | US1  | Registrierung      | 5            |
| Must      | US2  | Login              | 5            |
| Must      | US3  | Fahrzeugsuche      | 8            |
| Should    | US4  | Preisfilter        | 3            |
| Must      | US5  | Detailansicht      | 5            |
| Must      | US6  | Inserat erstellen  | 8            |
| Should    | US7  | Inserat bearbeiten | 5            |
| Should    | US8  | Inserat löschen    | 5            |
| Could     | US9  | Erweiterte Filter  | 3            |
| Could     | US10 | Benutzerprofil     | 3            |

# Sprint 2 – Backend Entwicklung

## Sprint Ziel

Ziel des zweiten Sprints war die Umsetzung der Backend-Grundlagen für die Benutzerverwaltung und die Motorradverwaltung. Zusätzlich sollte die Verbindung zwischen ASP.NET Core, NHibernate und MySQL erfolgreich eingerichtet werden.

## Geplante Aufgaben

* Datenbankmodell erstellen
* User Tabelle erstellen
* Motorrad Tabelle erstellen
* NHibernate konfigurieren
* JWT Authentifizierung implementieren
* Registrierungsfunktion entwickeln
* Loginfunktion entwickeln

## Umgesetzte Arbeiten

### Datenbank

Folgende Tabellen wurden erstellt:

#### User

* Id
* Email
* PasswordHash

#### Motorrad

* Id
* Marke
* Modell
* Preis
* Kilometerstand
* BenutzerId

### Backend

* ASP.NET Core API eingerichtet
* JWT Authentifizierung implementiert
* Login Endpoint erstellt
* Registrierungs Endpoint erstellt
* Datenbankanbindung erfolgreich umgesetzt

### GitHub

Während der Entwicklung wurden mehrere Feature-Branches erstellt. Änderungen wurden über Pull Requests zusammengeführt und vor dem Merge überprüft.

## Sprint Review

### Demonstrierte Funktionen

* Benutzerregistrierung
* Login mit JWT
* Speicherung von Benutzern in der Datenbank

### Feedback

* Fehlermeldungen sollen verständlicher dargestellt werden
* Validierungen sollen erweitert werden
* API Dokumentation verbessern

## Sprint Retrospektive

### Continue

* Gute Zusammenarbeit im Team
* Regelmässige Kommunikation
* Saubere Git-Nutzung

### Stop

* Zu grosse Tasks
* Unklare Aufwandsschätzungen

### Start

* Kleinere User Stories definieren
* Tasks früher aufteilen

## SMART-Massnahmen

| Massnahme                              | Verantwortlich | Termin   |
| -------------------------------------- | -------------- | -------- |
| User Stories detaillierter beschreiben | Jan            | Sprint 3 |
| Dokumentation parallel pflegen         | Artian         | Sprint 3 |
| Unit Tests erweitern                   | Luka           | Sprint 3 |

# Sprint 3 – Motorradverwaltung

## Sprint Ziel

Im dritten Sprint sollte die Kernfunktionalität der Anwendung umgesetzt werden. Benutzer sollen Motorräder erstellen, anzeigen, bearbeiten und verwalten können.

## Umgesetzte Arbeiten

### CRUD Funktionen

Create

* Motorrad erstellen

Read

* Motorräder anzeigen
* Detailansicht anzeigen

Update

* Motorrad bearbeiten

Delete

* Motorrad löschen

### Validierungen

* Preis darf nicht negativ sein
* Pflichtfelder werden überprüft
* Ungültige Eingaben werden abgefangen

### Frontend

* Motorradübersicht erstellt
* Detailansicht erstellt
* Formular für neue Inserate erstellt

## Sprint Review

### Demonstrierte Funktionen

* Motorrad erstellen
* Motorrad bearbeiten
* Motorrad löschen
* Detailansicht

### Feedback

* Benutzerfreundlichkeit verbessern
* Suchfunktion erweitern
* Fehlerbehandlung optimieren

## Sprint Retrospektive

### Continue

* Gute Aufgabenverteilung
* Aktive Mitarbeit aller Teammitglieder

### Stop

* Dokumentation teilweise nachträglich ergänzt

### Start

* Dokumentation direkt während der Entwicklung aktualisieren
* Fortschritt häufiger kontrollieren

## Lessons Learned

* CRUD Funktionen benötigen eine saubere Planung
* Frühzeitige Tests sparen Entwicklungszeit
* Kleine Commits verbessern die Übersichtlichkeit

# Sprint 4 – Frontend Integration

## Sprint Ziel

Frontend und Backend vollständig verbinden und die Benutzeroberfläche fertigstellen.

## Umgesetzte Arbeiten

* Angular Routing eingerichtet
* API Kommunikation umgesetzt
* JWT Speicherung integriert
* Login Seite fertiggestellt
* Registrierungsseite fertiggestellt
* Suchfunktion implementiert

## Sprint Review

### Demonstrierte Funktionen

* Vollständiger Loginprozess
* Registrierung
* Motorradsuche
* Inseratsverwaltung

### Feedback

* Oberfläche übersichtlich
* Suchfunktion funktioniert zuverlässig
* Performance zufriedenstellend

## Retrospektive

### Continue

* Gute Kommunikation
* Saubere Pull Requests

### Stop

* Zu späte Fehleranalyse

### Start

* Mehr Tests vor dem Merge

## SMART-Massnahmen

| Massnahme                          | Verantwortlich | Termin   |
| ---------------------------------- | -------------- | -------- |
| Zusätzliche Unit Tests erstellen   | Luka           | Sprint 5 |
| Refactoring durchführen            | Jan            | Sprint 5 |
| Abschlussdokumentation vorbereiten | Artian         | Sprint 5 |
# Architektur

## Systemarchitektur

Für die Umsetzung des Projekts wurde eine klassische Drei-Schichten-Architektur gewählt.

### Frontend

Das Frontend wurde mit Angular entwickelt und dient als Benutzerschnittstelle. Benutzer können sich registrieren, anmelden sowie Motorräder suchen und verwalten.

Aufgaben des Frontends:

* Darstellung der Benutzeroberfläche
* Entgegennahme von Benutzereingaben
* Kommunikation mit dem Backend über REST API
* Anzeige von Suchergebnissen
* Verwaltung der JWT Tokens

### Backend

Das Backend wurde mit ASP.NET Core entwickelt.

Aufgaben des Backends:

* Verarbeitung von Anfragen
* Authentifizierung und Autorisierung
* Geschäftslogik
* Datenvalidierung
* Datenbankzugriffe

### Datenzugriff

Für den Datenzugriff wurde NHibernate verwendet.

Vorteile von NHibernate:

* Objektorientierter Zugriff auf Daten
* Weniger SQL-Code
* Einfachere Wartbarkeit
* Trennung von Geschäftslogik und Datenbankzugriff

### Datenbank

Die Speicherung erfolgt in einer MySQL-Datenbank.

### Architekturübersicht

Angular Frontend

↓

ASP.NET Core Web API

↓

NHibernate ORM

↓

MySQL Datenbank

# Authentifizierung mit JWT

## Ziel

Nur registrierte Benutzer sollen Inserate erstellen und verwalten können.

## Ablauf

1. Benutzer meldet sich an
2. Backend überprüft E-Mail und Passwort
3. JWT Token wird erstellt
4. Token wird an das Frontend zurückgegeben
5. Frontend speichert den Token
6. Bei weiteren API-Aufrufen wird der Token mitgesendet
7. Backend validiert den Token

## Vorteile

* Zustandslose Authentifizierung
* Gute Skalierbarkeit
* Sichere Kommunikation
* Standardisierte Lösung

# Datenbankdesign

## Tabelle User

| Feld         | Beschreibung             |
| ------------ | ------------------------ |
| Id           | Eindeutige Benutzer-ID   |
| Email        | Benutzer E-Mail          |
| PasswordHash | Verschlüsseltes Passwort |

## Tabelle Motorrad

| Feld           | Beschreibung             |
| -------------- | ------------------------ |
| Id             | Motorrad-ID              |
| Marke          | Hersteller               |
| Modell         | Modellname               |
| Preis          | Verkaufspreis            |
| Kilometerstand | Aktueller Kilometerstand |
| BenutzerId     | Besitzer des Inserats    |

## Beziehung

Ein Benutzer kann mehrere Motorräder besitzen.

User (1) → (n) Motorrad

# Testing

## Teststrategie

Während der Entwicklung wurden verschiedene Testmethoden eingesetzt.

### Unit Tests

Zur Überprüfung einzelner Komponenten wurden Unit Tests erstellt.

Getestete Bereiche:

* Login Logik
* Registrierung
* Motorradverwaltung
* Datenvalidierung

### Manuelle Tests

Zusätzlich wurden sämtliche User Stories manuell getestet.

### Akzeptanztests

Die Akzeptanzkriterien wurden anhand von Gherkin-Szenarien überprüft.

Beispiel:

Given: Benutzer besitzt ein Konto

When: Benutzer meldet sich mit gültigen Daten an

Then: Dashboard wird angezeigt

## Testergebnisse

Alle definierten Kernfunktionen konnten erfolgreich getestet werden.

Festgestellte Fehler wurden dokumentiert und behoben.

# Refactoring

## Ziel

Im Verlauf des Projekts wurde der Code regelmässig verbessert, um die Wartbarkeit zu erhöhen.

## Long Method

### Problem

Mehrere Methoden enthielten zu viele Verantwortlichkeiten.

Beispiel:

* Validierung
* Datenverarbeitung
* Datenbankzugriff

wurden in einer einzigen Methode ausgeführt.

### Lösung

Die Methoden wurden mit der Technik "Extract Method" aufgeteilt.

Vorher:

ProcessMotorcycle()

Nachher:

* ValidateMotorcycle()
* SaveMotorcycle()
* CreateResponse()

### Nutzen

* Bessere Lesbarkeit
* Einfachere Wartung
* Höhere Testbarkeit

## Duplicate Code

### Problem

Validierungslogik wurde mehrfach verwendet.

### Lösung

Die Logik wurde in zentrale Methoden ausgelagert.

Vorher:

Validierung mehrfach vorhanden.

Nachher:

Gemeinsame Validate-Methode.

### Nutzen

* DRY Prinzip eingehalten
* Weniger Fehlerquellen
* Einfachere Anpassungen

# Git Workflow

## Versionsverwaltung

Für die Entwicklung wurde GitHub eingesetzt.

## Arbeitsweise

1. Feature Branch erstellen
2. Änderung entwickeln
3. Commit erstellen
4. Pull Request eröffnen
5. Code Review durchführen
6. Merge in Main Branch

## Vorteile

* Nachvollziehbarkeit
* Versionskontrolle
* Teamarbeit
* Konflikte früh erkennen

# Code Reviews

## Ziel

Code Reviews wurden eingesetzt, um die Qualität des Codes sicherzustellen.

Folgende Punkte wurden überprüft:

### Clean Code

* Verständliche Methodennamen
* Verständliche Variablennamen
* Keine unnötigen Komplexitäten

### SOLID

* Klare Verantwortlichkeiten
* Trennung der Komponenten

### Tests

* Vorhandene Unit Tests
* Erfolgreiche Testausführung

### Refactoring

* Duplicate Code vermeiden
* Long Methods reduzieren

# Quality Assurance

Zur Qualitätssicherung wurden mehrere Massnahmen eingesetzt.

## Definition of Done

Eine Aufgabe galt als abgeschlossen wenn:

* Funktion implementiert
* Akzeptanzkriterien erfüllt
* Daten korrekt gespeichert
* Tests erfolgreich
* Code im Repository vorhanden
* Dokumentation aktualisiert

## Pull Requests

Alle grösseren Änderungen wurden vor dem Merge überprüft.

## Regelmässige Reviews

Nach jedem Sprint wurden Fortschritt und Qualität überprüft.

# Lessons Learned

## Agile Entwicklung

Die Aufteilung in User Stories erleichterte die Planung und Umsetzung.

## Kommunikation

Regelmässige Abstimmungen führten zu einer besseren Zusammenarbeit.

## Testing

Frühzeitige Tests reduzierten den Aufwand bei der Fehlersuche.

## GitHub

Branches und Pull Requests verbesserten die Nachvollziehbarkeit der Änderungen.

## Dokumentation

Eine laufende Dokumentation erleichterte die Projektverwaltung.

# Risiken

| Risiko            | Auswirkung                          | Gegenmassnahme                   |
| ----------------- | ----------------------------------- | -------------------------------- |
| Zeitmangel        | Verzögerung                         | Priorisierung wichtiger Features |
| Fehler im Login   | Benutzer können sich nicht anmelden | Unit Tests und Reviews           |
| Datenbankprobleme | Datenverlust                        | Regelmässige Tests               |
| Merge Konflikte   | Entwicklungsverzögerung             | Pull Requests und Branches       |

# Gesamtfazit

Das Ziel des Projekts war die Entwicklung einer webbasierten Plattform zur Verwaltung von Motorradinseraten.

Die Anwendung konnte erfolgreich umgesetzt werden. Sämtliche Kernfunktionen des MVP wurden entwickelt und getestet.

Durch den Einsatz von Scrum konnten Anforderungen schrittweise umgesetzt und regelmässig überprüft werden.

Neben der technischen Umsetzung konnten wertvolle Erfahrungen mit agilen Methoden, Testing, Refactoring, GitHub, Code Reviews und Teamarbeit gesammelt werden.

Für zukünftige Erweiterungen wären zusätzliche Filtermöglichkeiten, Favoritenlisten, Bilduploads oder ein Nachrichtensystem denkbar.

Insgesamt konnten die Projektziele erreicht werden und die entwickelte Anwendung erfüllt die definierten Anforderungen.
# Sprint Planning

## Sprint 1 Planning

### Sprint Ziel

Grundlagen des Projekts definieren und die technische Basis vorbereiten.

### Geplante User Stories

* US1 Registrierung
* US2 Login

### Aufgaben

* Projektidee definieren
* Rollen verteilen
* User Stories erstellen
* Datenbankmodell entwerfen
* GitHub Repository erstellen
* Erste API-Struktur vorbereiten

### Erwartetes Ergebnis

Ein lauffähiges Grundgerüst für die weitere Entwicklung.

---

## Sprint 2 Planning

### Sprint Ziel

Benutzerverwaltung und Authentifizierung umsetzen.

### Geplante User Stories

* US1 Registrierung
* US2 Login

### Aufgaben

* JWT implementieren
* User Entity erstellen
* NHibernate konfigurieren
* Datenbankanbindung umsetzen
* Registrierungsfunktion entwickeln
* Loginfunktion entwickeln

### Erwartetes Ergebnis

Benutzer können sich registrieren und anmelden.

---

## Sprint 3 Planning

### Sprint Ziel

Motorradverwaltung implementieren.

### Geplante User Stories

* US5 Detailansicht
* US6 Inserat erstellen

### Aufgaben

* Motorrad Entity erstellen
* CRUD Funktionen entwickeln
* API Endpoints erstellen
* Datenvalidierung integrieren
* Frontend Formulare erstellen

### Erwartetes Ergebnis

Motorräder können erstellt und angezeigt werden.

---

## Sprint 4 Planning

### Sprint Ziel

Frontend und Backend vollständig integrieren.

### Geplante User Stories

* US3 Fahrzeugsuche
* US4 Preisfilter

### Aufgaben

* Angular Routing
* Suchfunktion
* Filterfunktion
* API Integration
* Fehlerbehandlung

### Erwartetes Ergebnis

Vollständiges MVP der Anwendung.

# Sprint Reviews

## Sprint 1 Review

### Erreichte Ziele

* Projektplanung abgeschlossen
* User Stories erstellt
* Product Backlog erstellt
* GitHub Repository eingerichtet

### Feedback

* User Stories detaillierter formulieren
* Aufwandsschätzungen ergänzen
* Sprintziele klarer definieren

### Beschlossene Verbesserungen

* Story Points einführen
* Regelmässige Abstimmungen durchführen

---

## Sprint 2 Review

### Erreichte Ziele

* Registrierung umgesetzt
* Login umgesetzt
* JWT integriert
* Datenbank erfolgreich angebunden

### Feedback

* Fehlermeldungen verbessern
* Validierungen erweitern

### Beschlossene Verbesserungen

* Mehr Unit Tests erstellen
* Fehlerbehandlung optimieren

---

## Sprint 3 Review

### Erreichte Ziele

* Motorräder erstellen
* Motorräder anzeigen
* Detailansicht umsetzen
* CRUD Funktionen erweitern

### Feedback

* Suchfunktion verbessern
* Benutzerfreundlichkeit erhöhen

### Beschlossene Verbesserungen

* Frontend optimieren
* Weitere Tests ergänzen

---

## Sprint 4 Review

### Erreichte Ziele

* Frontend und Backend verbunden
* Fahrzeugsuche umgesetzt
* Preisfilter umgesetzt
* MVP fertiggestellt

### Feedback

* Oberfläche übersichtlich
* Anwendung stabil
* Suchfunktion funktioniert zuverlässig

### Beschlossene Verbesserungen

* Dokumentation abschliessen
* Refactoring durchführen

# SMART-Massnahmen

## Sprint 1

| Ziel                                | Verantwortlich | Termin   |
| ----------------------------------- | -------------- | -------- |
| User Stories vollständig definieren | Jan            | Sprint 2 |
| Product Backlog erstellen           | Artian         | Sprint 2 |
| Git Workflow festlegen              | Luka           | Sprint 2 |

## Sprint 2

| Ziel                        | Verantwortlich | Termin   |
| --------------------------- | -------------- | -------- |
| JWT vollständig integrieren | Jan            | Sprint 3 |
| Datenvalidierung erweitern  | Luka           | Sprint 3 |
| Dokumentation aktualisieren | Artian         | Sprint 3 |

## Sprint 3

| Ziel                         | Verantwortlich | Termin   |
| ---------------------------- | -------------- | -------- |
| CRUD Funktionen abschliessen | Luka           | Sprint 4 |
| Suchfunktion entwickeln      | Jan            | Sprint 4 |
| Unit Tests erweitern         | Luka           | Sprint 4 |

## Sprint 4

| Ziel                              | Verantwortlich | Termin      |
| --------------------------------- | -------------- | ----------- |
| Refactoring durchführen           | Jan            | Projektende |
| Dokumentation fertigstellen       | Artian         | Projektende |
| Abschlusspräsentation vorbereiten | Team           | Projektende |

# Releaseplanung

## Release 1 – MVP

Enthaltene Funktionen:

* Registrierung
* Login
* JWT Authentifizierung
* Motorrad erstellen
* Motorrad anzeigen
* Motorrad bearbeiten
* Motorrad löschen
* Detailansicht
* Suchfunktion
* Preisfilter

## Abnahmekriterien

* Alle Must User Stories umgesetzt
* Unit Tests erfolgreich
* Datenbank funktioniert fehlerfrei
* Frontend und Backend integriert
* Dokumentation abgeschlossen

# Pair Programming

Während der Entwicklung wurden einzelne Funktionen gemeinsam entwickelt. Dabei wurde das Driver-Navigator Prinzip angewendet.

Driver:

* Implementierung der Lösung

Navigator:

* Überprüfung der Logik
* Diskussion von Lösungsansätzen
* Qualitätssicherung

Vorteile:

* Schnellere Problemlösung
* Wissenstransfer im Team
* Weniger Fehler

# Design Patterns

Im Projekt wurden keine Design Patterns bewusst implementiert. Während der Entwicklung wurden jedoch die im Modul behandelten Entwurfsmuster analysiert und deren mögliche Einsatzgebiete diskutiert.

Behandelte Patterns:

* Factory
* Facade
* Strategy
* Observer
* Singleton

# CI/CD

Das Thema Continuous Integration und Continuous Deployment wurde im Modul behandelt.

Aufgrund des Projektumfangs wurde kein automatisierter Deployment-Prozess eingerichtet.

Die Qualitätssicherung erfolgte über:

* GitHub Repository
* Branches
* Pull Requests
* Code Reviews
* Unit Tests

Dadurch konnte eine stabile und nachvollziehbare Entwicklung sichergestellt werden.


# Projektvision

## Ausgangslage

Der Kauf und Verkauf von Motorrädern erfolgt heute grösstenteils über Online-Plattformen. Viele bestehende Lösungen bieten jedoch zahlreiche Funktionen, welche die Bedienung unnötig kompliziert machen.

Im Rahmen dieses Projekts sollte deshalb eine vereinfachte Plattform entwickelt werden, welche die wichtigsten Funktionen für die Verwaltung und Suche von Motorradinseraten bereitstellt.

## Vision

Die MotoScout-Webapplikation soll Benutzern eine einfache Möglichkeit bieten, Motorräder online zu inserieren, zu suchen und zu verwalten.

Der Fokus liegt auf einer übersichtlichen Benutzeroberfläche, einer zuverlässigen Datenverwaltung und einer einfachen Bedienung.

## Projektziele

* Benutzerregistrierung ermöglichen
* Sichere Anmeldung mit JWT
* Motorräder erfassen und verwalten
* Motorräder suchen und filtern
* Moderne Webtechnologien einsetzen
* Agile Entwicklungsmethoden anwenden

# Stakeholder

## Kunde

Der Kunde definiert die Anforderungen an die Anwendung und gibt Feedback zu den umgesetzten Funktionen.

Interessen:

* Einfache Bedienung
* Stabile Anwendung
* Erfüllung der Anforderungen

## Besucher

Besucher können Motorräder suchen und betrachten.

Interessen:

* Übersichtliche Suchfunktion
* Schnelle Ladezeiten
* Einfache Navigation

## Registrierte Benutzer

Registrierte Benutzer können eigene Inserate erstellen und verwalten.

Interessen:

* Einfache Inseraterstellung
* Sichere Anmeldung
* Verwaltung eigener Motorräder

## Entwicklungsteam

Das Entwicklungsteam plant, entwickelt und dokumentiert die Anwendung.

Interessen:

* Erfolgreiche Umsetzung
* Einhaltung der Projektziele
* Gute Codequalität

# Rollenbeschreibung

## Scrum Master – Jan

Aufgaben:

* Organisation der Sprintplanung
* Moderation von Reviews und Retrospektiven
* Unterstützung des Teams
* Überwachung des Projektfortschritts

## Entwickler – Luka

Aufgaben:

* Entwicklung der Datenbank
* Backend Entwicklung
* Unit Tests
* Fehlerbehebung

## Entwickler & Dokumentation – Artian

Aufgaben:

* Projektdokumentation
* Backend Entwicklung
* Pflege der Scrum-Artefakte
* Dokumentation der Sprint-Ergebnisse

# Aufwandsschätzung

Zur Planung der Sprints wurden User Stories mit Story Points bewertet.

| User Story         | Story Points |
| ------------------ | ------------ |
| Registrierung      | 5            |
| Login              | 5            |
| Fahrzeugsuche      | 8            |
| Preisfilter        | 3            |
| Detailansicht      | 5            |
| Inserat erstellen  | 8            |
| Inserat bearbeiten | 5            |
| Inserat löschen    | 5            |

Gesamtschätzung: 44 Story Points

# Velocity

Die Velocity beschreibt die Anzahl Story Points, welche pro Sprint abgeschlossen werden konnten.

| Sprint   | Story Points |
| -------- | ------------ |
| Sprint 1 | 10           |
| Sprint 2 | 12           |
| Sprint 3 | 12           |
| Sprint 4 | 10           |

Durchschnittliche Velocity: 11 Story Points pro Sprint

Die Velocity half dabei, den Umfang der folgenden Sprints besser einzuschätzen und realistische Ziele festzulegen.

# Burndown Analyse

Zur Überwachung des Projektfortschritts wurde ein Taskboard verwendet.

Während jedes Sprints wurden abgeschlossene Aufgaben kontinuierlich aus dem Sprint Backlog entfernt.

Die Anzahl offener Aufgaben nahm über die Laufzeit der Sprints stetig ab, wodurch die Sprintziele erreicht werden konnten.

Die regelmässige Überprüfung des Fortschritts half dabei, Risiken frühzeitig zu erkennen und Gegenmassnahmen einzuleiten.

# NHibernate

## Einsatz von NHibernate

Für den Datenzugriff wurde NHibernate eingesetzt.

NHibernate ist ein ORM (Object Relational Mapping) Framework, welches die Kommunikation zwischen den C# Klassen und der MySQL Datenbank vereinfacht.

## Vorteile

* Weniger SQL-Code notwendig
* Objektorientierte Entwicklung
* Bessere Wartbarkeit
* Einfachere Datenbankzugriffe

## Einsatz im Projekt

NHibernate wurde verwendet für:

* Speicherung von Benutzern
* Speicherung von Motorrädern
* Laden von Datensätzen
* Aktualisieren von Datensätzen
* Löschen von Datensätzen

# REST API

## API Konzept

Das Backend wurde als REST API entwickelt.

Die Kommunikation zwischen Angular und ASP.NET Core erfolgt über HTTP Requests.

## Wichtige Endpunkte

### Authentifizierung

POST /api/auth/register

Registriert einen neuen Benutzer.

POST /api/auth/login

Meldet einen Benutzer an und liefert einen JWT Token zurück.

### Motorräder

GET /api/motorcycles

Lädt alle Motorräder.

GET /api/motorcycles/{id}

Lädt ein bestimmtes Motorrad.

POST /api/motorcycles

Erstellt ein neues Motorrad.

PUT /api/motorcycles/{id}

Aktualisiert ein Motorrad.

DELETE /api/motorcycles/{id}

Löscht ein Motorrad.

# Angular Frontend

## Komponentenstruktur

Die Benutzeroberfläche wurde mit Angular umgesetzt.

Verwendete Hauptkomponenten:

### Login Component

* Anmeldung der Benutzer

### Register Component

* Registrierung neuer Benutzer

### Motorcycle List Component

* Anzeige aller Motorräder

### Motorcycle Detail Component

* Detailansicht eines Motorrads

### Motorcycle Form Component

* Erstellen und Bearbeiten von Inseraten

## Services

### Auth Service

Verantwortlich für:

* Login
* Registrierung
* JWT Verwaltung

### Motorcycle Service

Verantwortlich für:

* Laden von Motorrädern
* Erstellen neuer Motorräder
* Aktualisieren bestehender Motorräder
* Löschen von Motorrädern

## Routing

Für die Navigation innerhalb der Anwendung wurde Angular Routing eingesetzt.

Beispiele:

* /login
* /register
* /motorcycles
* /motorcycles/create
* /motorcycles/:id

# Repository Dokumentation

## GitHub Repository

Für die Entwicklung wurde GitHub als zentrale Plattform verwendet.

Das Repository diente zur:

* Versionsverwaltung
* Zusammenarbeit im Team
* Dokumentation des Fortschritts
* Durchführung von Pull Requests

## Branch Strategie

Für neue Funktionen wurden Feature Branches erstellt.

Beispiele:

* feature/login
* feature/register
* feature/motorcycles

Nach erfolgreicher Entwicklung wurden die Änderungen über Pull Requests geprüft und anschliessend in den Main Branch integriert.

## Vorteile

* Saubere Trennung der Arbeiten
* Bessere Nachvollziehbarkeit
* Höhere Codequalität
* Weniger Merge-Konflikte
