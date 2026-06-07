# MotoScout – Projektarbeit M426

**Modul:** M426 – Software mit agilen Methoden entwickeln (BZT Frauenfeld)
**Repository:** https://github.com/LukaJovanic/Projektarbeit-M426
**Team:** Luka Jovanic (Entwicklung), Jan Wyler (Scrum Master & Entwicklung), Artian Ismajli (Dokumentation & Entwicklung)

Webapplikation zur Verwaltung und Suche von Motorradinseraten. Benutzer können sich registrieren, anmelden, Inserate mit Bild erstellen, durchsuchen und in einer Detailansicht betrachten.

---

## Inhaltsverzeichnis

1. [Projektvision & Ausgangslage](#1-projektvision--ausgangslage)
2. [Team, Rollen & Stakeholder](#2-team-rollen--stakeholder)
3. [Technologie-Stack](#3-technologie-stack)
4. [Architektur](#4-architektur)
5. [Datenbank](#5-datenbank)
6. [REST API](#6-rest-api)
7. [Sicherheit & Authentifizierung](#7-sicherheit--authentifizierung)
8. [Installation & Start](#8-installation--start)
9. [Agiles Vorgehen (Scrum)](#9-agiles-vorgehen-scrum)
10. [Product Backlog & User Stories](#10-product-backlog--user-stories)
11. [Releaseplanung](#11-releaseplanung)
12. [Sprints: Planning, Review, Retrospektive](#12-sprints-planning-review-retrospektive)
13. [Velocity & Burndown](#13-velocity--burndown)
14. [Versionsverwaltung & Git Workflow](#14-versionsverwaltung--git-workflow)
15. [Clean Code & Code-Qualität](#15-clean-code--code-qualität)
16. [Design Patterns im Projekt](#16-design-patterns-im-projekt)
17. [Testing](#17-testing)
18. [Refactoring](#18-refactoring)
19. [Pair Programming & Code Reviews](#19-pair-programming--code-reviews)
20. [CI/CD](#20-cicd)
21. [Analyse von Problemen & Hindernissen](#21-analyse-von-problemen--hindernissen)
22. [Lessons Learned](#22-lessons-learned)
23. [Bewusst nicht umgesetzte Funktionen & bekannte Schwachstellen](#23-bewusst-nicht-umgesetzte-funktionen--bekannte-schwachstellen)
24. [Risiken](#24-risiken)
25. [Gesamtfazit](#25-gesamtfazit)

---

## 1. Projektvision & Ausgangslage

### Ausgangslage

Der Kauf und Verkauf von Motorrädern erfolgt heute grösstenteils über Online-Plattformen. Viele bestehende Lösungen sind funktional überladen und dadurch unnötig kompliziert zu bedienen. Im Rahmen dieses Projekts wurde deshalb eine bewusst vereinfachte Plattform («MotoScout») entwickelt, welche die wichtigsten Funktionen für die Verwaltung und Suche von Motorradinseraten bereitstellt.

### Vision

Die MotoScout-Webapplikation bietet Benutzern eine einfache Möglichkeit, Motorräder online zu inserieren, zu suchen und zu betrachten. Der Fokus liegt auf einer übersichtlichen Benutzeroberfläche, einer zuverlässigen Datenverwaltung und einer einfachen Bedienung – ein bewusst schlankes MVP statt eines überladenen Klons.

### Projektziele

* Benutzerregistrierung mit serverseitiger Prüfung auf doppelte Benutzernamen/E-Mails
* Sichere Anmeldung mit Passwort-Hashing (PBKDF2) und JWT-Token
* Motorradinserate mit Bild-Upload erfassen
* Inserate durchsuchen (Freitextsuche) und Detailansicht öffnen
* Moderne Webtechnologien einsetzen (Angular 20, ASP.NET Core / .NET 9, NHibernate, MySQL)
* Das Projekt konsequent mit Scrum und den im Modul behandelten Praktiken umsetzen

---

## 2. Team, Rollen & Stakeholder

### Rollen

| Rolle | Person | Aufgaben |
| --- | --- | --- |
| Scrum Master & Entwicklung | Jan Wyler | Organisation Sprint Planning, Moderation Review/Retrospektive, Frontend-Entwicklung (Login-/Register-Design, Startseite, Übersichtsseite) |
| Entwickler | Luka Jovanic | Backend-Entwicklung (API, Domain, Repositories), Datenbank & Docker-Setup, Unit Tests |
| Entwicklung & Dokumentation | Artian Ismajli | Projektdokumentation, Pflege der Scrum-Artefakte, Dokumentation der Sprint-Ergebnisse, Mitarbeit Backend |

Die Rollenverteilung ist in der Commit-Historie nachvollziehbar: alle drei Teammitglieder haben committet (siehe [Kapitel 14](#14-versionsverwaltung--git-workflow)).

### Stakeholder

| Stakeholder | Interessen |
| --- | --- |
| Kunde (Lehrperson als Product-Owner-Vertretung) | Erfüllung der Anforderungen, stabile Anwendung, einfache Bedienung, Feedback in Sprint Reviews |
| Besucher | Übersichtliche Suche, schnelle Ladezeiten, einfache Navigation |
| Registrierte Benutzer | Einfache Inseraterstellung, sichere Anmeldung |
| Entwicklungsteam | Erfolgreiche Umsetzung, gute Codequalität, Lernerfolg im Modul |

---

## 3. Technologie-Stack

Alle aufgeführten Technologien sind im Repository nachweisbar (Projektdateien, `package.json`, `docker-compose.yaml`).

| Bereich | Technologie | Version | Nachweis |
| --- | --- | --- | --- |
| Frontend | Angular (Standalone Components, Signals) | ^20.3 | `Frontend/projektarbeit_M426/package.json` |
| Frontend-Styling | Tailwind CSS | ^4.2 | `package.json`, `.postcssrc.json` |
| Frontend-Sprache | TypeScript | ~5.9 | `package.json` |
| Frontend-Tests | Karma / Jasmine | 6.4 / 5.9 | `*.spec.ts`, `package.json` |
| Backend | ASP.NET Core Minimal API, .NET | net9.0 | `ProjektApi/AutoProjektApi.csproj` |
| ORM | NHibernate (Mapping by Code) | 5.6.0 | `ProjektBusiness/AutoProjektBusiness.csproj` |
| Datenbank | MySQL (Docker-Container) | 8.0 | `docker-compose.yaml` |
| DB-Treiber | MySql.Data | 9.5.0 | `AutoProjektBusiness.csproj` |
| Authentifizierung | JWT (`System.IdentityModel.Tokens.Jwt`) | 8.15.0 | `AutoProjektApi.csproj` |
| Passwort-Hashing | PBKDF2 (`Microsoft.AspNetCore.Cryptography.KeyDerivation`) | – | `ProjektApi/Hash.cs` |
| Backend-Tests | MSTest + FakeItEasy | 4.0.2 / 8.3.0 | `ProjektBusinessTest/AutoProjektBusinessTest.csproj` |
| Versionsverwaltung | Git / GitHub (Feature-Branches, Pull Requests) | – | Commit-Historie, PR #1–#3 |

---

## 4. Architektur

### Schichtenarchitektur

Das Backend ist als Drei-Schichten-Architektur aufgebaut. Jeder Anwendungsfall (Registrieren, Anmelden, Create, GetMotorrad) ist als eigenes, vertikal geschnittenes Feature-Modul organisiert – jede Schicht ist über ein Interface entkoppelt und wird per Dependency Injection verdrahtet (`Program.cs`).

```text
Angular Frontend (SPA, Port 4200)
        │  HTTP/JSON bzw. multipart/form-data
        ▼
ProjektApi  – Service-Schicht (Minimal API Endpoints, Request-Parsing, JWT, Hashing)
        ▼
ProjektBusiness/Domain  – Geschäftslogik (z. B. Prüfung «darf sich registrieren?»)
        ▼
ProjektBusiness/Repository  – Datenzugriff inkl. Mapper (Domain-Objekt ↔ Entity)
        ▼
NHibernate ORM (Mapping by Code)
        ▼
MySQL 8 (Docker-Container «carapp-mysql»)
```

### Projektstruktur (Auszug)

```text
Backend/Projektarbeit_M426/
├── docker-compose.yaml          # MySQL-Container
├── db/init.sql                  # Initiales DB-Schema
├── ProjektApi/                  # Service-Schicht (Web API)
│   ├── Program.cs               # DI-Registrierung, CORS, Endpoints
│   ├── Hash.cs                  # PBKDF2-Passwort-Hashing
│   ├── TokenInfos.cs            # JWT-Issuer & Secret
│   ├── Anmelden/ Create/ GetMotorrad/ Registrieren/   # je IService + Service
├── ProjektBusiness/             # Geschäftslogik & Datenzugriff
│   ├── Anmelden/ Create/ GetMotorrad/ Registrieren/   # Domain + Repository + Mapper
│   ├── Entities/                # UsersEntity, MotorradEntity
│   ├── Mappings/                # NHibernate ClassMappings (users, cars)
│   ├── NHibernateHelper/        # SessionFactory-Konfiguration
│   └── Shared/                  # Domain-Objekte: User, Motorrad, AnmeldenUser, CanResult
└── ProjektBusinessTest/         # Unit Tests (MSTest + FakeItEasy)

Frontend/projektarbeit_M426/src/app/
├── app.routes.ts                # Routing: /login /register /startseite /uebersicht
├── auth/authenticator.ts        # Token-Verwaltung (localStorage)
├── login.component/             # Anmeldung
├── register.component/          # Registrierung inkl. Passwortstärke-Anzeige
├── startseite/                  # Inseratsübersicht, Freitextsuche, Erstellen-Modal
└── motorrad-uebersicht.component/  # Detailansicht eines Inserats
```

### Frontend-Komponenten & Routing

| Route | Komponente | Funktion |
| --- | --- | --- |
| `/login` (auch `''` und `**`) | `LoginComponent` | Anmeldung, «Remember me», Fehleranzeige |
| `/register` | `RegisterComponent` | Registrierung mit clientseitiger Passwortstärke-Bewertung (Länge, Gross/Klein, Zahl, Sonderzeichen, Sequenz-/Wiederholungs-Penalties) |
| `/startseite` | `Startseite` | Lädt alle Inserate via `GET /getmotorrad`, Freitextsuche über alle Felder, Modal zum Erstellen inkl. Bild-Upload (`FormData`) |
| `/uebersicht` | `MotorradUebersichtComponent` | Detailansicht des über `history.state` übergebenen Inserats |

---

## 5. Datenbank

### Setup

Die MySQL-Datenbank läuft in einem Docker-Container (`docker-compose.yaml`). Das Schema wird beim ersten Start des Containers automatisch über das eingebundene Skript `db/init.sql` erstellt (`/docker-entrypoint-initdb.d/init.sql`) – Schemaänderungen erfolgen damit versioniert über das Repository und nicht manuell in der Datenbank.

### Schema (`db/init.sql`)

**Tabelle `users`**

| Spalte | Typ | Constraint |
| --- | --- | --- |
| `id` | INT AUTO_INCREMENT | PRIMARY KEY |
| `email` | VARCHAR(255) | NOT NULL, UNIQUE |
| `password_hash` | VARCHAR(255) | NOT NULL |
| `benutzername` | VARCHAR(255) | NOT NULL, UNIQUE |

**Tabelle `cars`** (speichert die Motorradinserate)

| Spalte | Typ | Constraint |
| --- | --- | --- |
| `id` | INT AUTO_INCREMENT | PRIMARY KEY |
| `title` | VARCHAR(255) | NOT NULL |
| `description` | TEXT | NULL |
| `price` | DECIMAL(10,2) | NOT NULL |
| `image_url` | VARCHAR(500) | NULL |
| `brand` | VARCHAR(100) | NULL |
| `model` | VARCHAR(100) | NULL |
| `kilometer` | INT | NOT NULL |
| `year` | INT | NULL |

Das objektrelationale Mapping erfolgt mit NHibernate «Mapping by Code» (`Mappings/UsersEntityMap.cs`, `Mappings/MotorradEntityMap.cs`); die Mapping-Klassen werden in `NHibernateConfig` automatisch per Reflection aus dem Assembly geladen.

**Bekannte Einschränkung (bewusst dokumentiert):** Die geplante 1:n-Beziehung «User besitzt Inserate» (Fremdschlüssel `cars.user_id`) wurde im MVP noch nicht umgesetzt – Inserate sind aktuell keinem Benutzer zugeordnet. Die Zuordnung ist als Backlog-Eintrag für einen Folgesprint erfasst (siehe [Kapitel 23](#23-bewusst-nicht-umgesetzte-funktionen--bekannte-schwachstellen)).

---

## 6. REST API

Die API läuft unter `http://localhost:5000` (fest in `Program.cs` konfiguriert) und stellt vier Endpoints als Minimal-API-Routen bereit. Hochgeladene Bilder werden via `UseStaticFiles()` unter `/images/cars/...` ausgeliefert.

### `POST /registrieren`

Registriert einen neuen Benutzer. Die Domain-Schicht prüft vor dem Speichern, ob Benutzername oder E-Mail bereits existieren.

```json
// Request
{ "username": "luka", "email": "luka@example.ch", "password": "Geheim123!" }

// Response (Erfolg)
{ "success": true, "message": "Erfolgreich" }

// Response (Konflikt)
{ "success": false, "message": "Benutzername oder Email bereits vorhanden" }
```

### `POST /anmelden`

Validiert das Passwort gegen den gespeicherten PBKDF2-Hash und liefert bei Erfolg einen JWT (Gültigkeit 30 Tage, Claims: `name`, `id`).

```json
// Request
{ "username": "luka", "password": "Geheim123!" }

// Response (Erfolg)
{ "success": true, "token": "eyJhbGciOiJIUzI1NiIs..." }

// Response (Fehlschlag)
{ "success": false }
```

### `POST /create`

Erstellt ein Inserat. Erwartet `multipart/form-data` mit den Feldern `title`, `description`, `price`, `brand`, `model`, `kilometer`, optional `year` sowie optional einer Bilddatei im Feld `image`. Das Bild wird mit einem GUID-Dateinamen unter `wwwroot/images/cars/` gespeichert; der relative Pfad wird in der Datenbank abgelegt.

```json
// Response
{ "success": true }
```

### `GET /getmotorrad`

Liefert alle Inserate als JSON-Array.

```json
[
  {
    "title": "Yamaha MT-07 wie neu",
    "description": "Erste Hand, Service gemacht",
    "price": 6500.00,
    "brand": "Yamaha",
    "model": "MT-07",
    "kilometer": 12000,
    "year": 2021,
    "imageUrl": "/images/cars/3f2a....jpg"
  }
]
```

CORS ist für die Entwicklung mit der Policy «AllowAll» geöffnet, damit das Angular-Frontend (Port 4200) auf die API (Port 5000) zugreifen kann.

---

## 7. Sicherheit & Authentifizierung

### Passwort-Hashing (umgesetzt)

Passwörter werden niemals im Klartext gespeichert. `Hash.cs` verwendet **PBKDF2 (HMAC-SHA256)** mit einem zufälligen 16-Byte-Salt pro Benutzer, 10 000 Iterationen und 32 Byte Hash-Länge. Hash und Salt werden Base64-kodiert und durch einen Punkt getrennt in einer Spalte gespeichert (`{hash}.{salt}`). Bei der Anmeldung wird der Hash mit demselben Salt neu berechnet und verglichen.

### JWT-Authentifizierung (umgesetzt)

Ablauf:

1. Benutzer meldet sich mit Benutzername und Passwort an
2. Backend lädt den Benutzer per NHibernate und validiert das Passwort gegen den Hash
3. Bei Erfolg wird ein JWT erstellt (Issuer `Projekt`, Claims `name` und `id`, HMAC-SHA256-Signatur, Gültigkeit 30 Tage)
4. Der Token wird im Response an das Frontend zurückgegeben
5. Im Frontend existiert die Klasse `Authenticator` (`auth/authenticator.ts`) zum Speichern/Lesen/Löschen des Tokens im `localStorage` (inkl. «Remember me»-Logik)

### Clientseitige Passwortqualität (umgesetzt)

Die Registrierungskomponente berechnet eine Passwortstärke (0–100) aus Länge, Gross-/Kleinschreibung, Zahlen, Sonderzeichen und Zeichenvielfalt und zieht Penalties ab für Tastatur-/Zahlensequenzen, Zeichenwiederholungen sowie Passwörter, die E-Mail oder Benutzernamen enthalten. Registrierungen mit Score < 40 werden clientseitig blockiert.

### Bekannte Schwachstellen (transparent dokumentiert)

Diese Punkte wurden in der Sprint-4-Retrospektive identifiziert und als technische Schuld erfasst:

* Das JWT-Secret und die DB-Zugangsdaten sind im Code hartkodiert (`TokenInfos.cs`, `NHibernateConfig.cs`) statt in Umgebungsvariablen ausgelagert.
* Die geschützten Endpoints validieren den mitgesendeten Token serverseitig noch nicht (`/create` ist ohne Token aufrufbar) – `UseAuthentication()` ist registriert, ein Token-Validierungsschema fehlt aber noch.
* Die CORS-Policy «AllowAll» ist nur für die lokale Entwicklung gedacht.

---

## 8. Installation & Start

Voraussetzungen: Docker, .NET 9 SDK, Node.js mit npm.

```bash
# 1. Repository klonen
git clone https://github.com/LukaJovanic/Projektarbeit-M426.git

# 2. Datenbank starten (legt Schema via init.sql automatisch an)
cd Projektarbeit-M426/Backend/Projektarbeit_M426
docker compose up -d

# 3. Backend starten (läuft auf http://localhost:5000)
dotnet run --project ProjektApi

# 4. Frontend starten (läuft auf http://localhost:4200)
cd ../../Frontend/projektarbeit_M426
npm install
npm start

# Backend-Unit-Tests ausführen
cd ../../Backend/Projektarbeit_M426
dotnet test
```

---

## 9. Agiles Vorgehen (Scrum)

Das Projekt wurde nach Scrum durchgeführt, angepasst an den schulischen Rhythmus (ein Modultag pro Woche). Pro Sprint fanden Sprint Planning, Sprint Review und Sprint Retrospektive statt; die wöchentlichen Abstimmungen («Weeklys», das schulische Pendant zum Daily Stand-up) wurden ab dem ersten Modultag schriftlich protokolliert (erstes Weekly vom 16.02.2026, Commit `6f9da75 docs: Erstes Weekly`).

### Scrum-Artefakte im Projekt

| Artefakt | Umsetzung |
| --- | --- |
| Product Backlog | Priorisierte User-Story-Liste mit MoSCoW-Priorität und Story Points (Kapitel 10) |
| Sprint Backlog | Pro Sprint ausgewählte Stories + Tasks (Kapitel 12), gepflegt im Team und in dieser Dokumentation |
| Increment | Lauffähiger Stand am Sprint-Ende, gesichert über Merges auf `main` bzw. Pull Requests |

### Definition of Ready (DoR)

Eine Story wird erst in einen Sprint übernommen, wenn:

* sie im Format «Als ‹Rolle› möchte ich ‹Ziel›, um ‹Nutzen›» formuliert ist,
* Akzeptanzkriterien definiert sind,
* sie mit Story Points geschätzt ist,
* sie die INVEST-Kriterien erfüllt (Independent, Negotiable, Valuable, Estimable, Small, Testable) – insbesondere «Small» und «Testable» wurden nach Sprint 2 streng geprüft (siehe Kapitel 21).

### Definition of Done (DoD)

Eine Story gilt als abgeschlossen, wenn:

* die Funktion vollständig implementiert ist (Frontend **und** Backend, vertikaler Schnitt),
* die Daten korrekt in der Datenbank gespeichert werden,
* alle Akzeptanzkriterien manuell anhand der Gherkin-Szenarien geprüft wurden,
* der Code per Commit (ab Sprint 4: per Pull Request mit Review) auf `main` integriert ist,
* die README-Dokumentation aktualisiert wurde.

Die DoD wurde nachweislich angewendet: Stories aus Sprint 2, die nur das Frontend abdeckten (Login-/Register-Design ohne Backend), wurden konsequent **nicht** als «Done» gewertet (siehe Velocity in Kapitel 13).

---

## 10. Product Backlog & User Stories

Das Product Backlog wurde zu Projektbeginn erstellt, mit MoSCoW priorisiert, mit Story Points (Fibonacci) geschätzt und im Projektverlauf kontinuierlich verfeinert (z. B. Aufnahme der technischen Schulden aus den Retrospektiven). Der Status entspricht dem tatsächlichen Stand im Code.

| Prio | ID | User Story | SP | Status |
| --- | --- | --- | --- | --- |
| Must | US1 | Registrierung | 5 | ✅ Umgesetzt |
| Must | US2 | Login | 5 | ✅ Umgesetzt |
| Must | US3 | Inserate suchen | 8 | ✅ Umgesetzt (Freitextsuche) |
| Should | US4 | Preisfilter (min/max) | 3 | ⏳ Offen (nur über Freitext abgedeckt) |
| Must | US5 | Detailansicht | 5 | ✅ Umgesetzt |
| Must | US6 | Inserat erstellen (inkl. Bild) | 8 | ✅ Umgesetzt |
| Should | US7 | Inserat bearbeiten | 5 | ⏳ Offen |
| Should | US8 | Inserat löschen | 5 | ⏳ Offen |
| Could | US9 | Erweiterte Filter | 3 | ⏳ Offen |
| Could | US10 | Benutzerprofil / Inserat-Zuordnung | 3 | ⏳ Offen |
| Tech | TD1 | Secrets in Umgebungsvariablen auslagern | 2 | ⏳ Offen (aus Retro Sprint 4) |
| Tech | TD2 | Serverseitige Token-Validierung für `/create` | 3 | ⏳ Offen (aus Retro Sprint 4) |

### User Stories (Format & Akzeptanzkriterien)

#### US1 – Registrierung (Must, 5 SP)

**Als** Besucher **möchte ich** mich registrieren können, **um** eigene Motorräder inserieren zu können.

Akzeptanzkriterien (Given-When-Then):

* **Given** ich bin auf der Registrierungsseite, **When** ich Benutzername, E-Mail und ein ausreichend starkes Passwort eingebe und auf «Registrieren» klicke, **Then** wird mein Benutzer mit gehashtem Passwort in der Datenbank gespeichert und ich werde zum Login weitergeleitet.
* **Given** der Benutzername oder die E-Mail existiert bereits, **When** ich die Registrierung absende, **Then** erhalte ich `success: false` mit der Meldung «Benutzername oder Email bereits vorhanden» und es wird kein Benutzer angelegt.
* **Given** mein Passwort erreicht weniger als 40 Stärkepunkte, **When** ich auf «Registrieren» klicke, **Then** wird das Formular clientseitig nicht abgesendet.

#### US2 – Login (Must, 5 SP)

**Als** registrierter Benutzer **möchte ich** mich einloggen können, **um** auf die Inseratsverwaltung zuzugreifen.

Akzeptanzkriterien (Given-When-Then):

* **Given** ich besitze ein gültiges Konto, **When** ich Benutzername und Passwort korrekt eingebe, **Then** liefert das Backend `success: true` mit einem JWT und ich werde auf die Startseite weitergeleitet.
* **Given** ich gebe ein falsches Passwort oder einen unbekannten Benutzernamen ein, **When** ich auf «Login» klicke, **Then** liefert das Backend `success: false` und ich bleibe mit einer Fehlermeldung auf der Login-Seite.
* **Given** Benutzername oder Passwort sind leer, **When** ich auf «Login» klicke, **Then** erscheint clientseitig der Hinweis, alle Pflichtfelder auszufüllen.

#### US6 – Inserat erstellen (Must, 8 SP)

**Als** Benutzer **möchte ich** ein Motorrad mit Bild inserieren können, **um** es zu verkaufen.

Akzeptanzkriterien (Given-When-Then):

* **Given** ich bin auf der Startseite und habe das Erstellen-Modal geöffnet, **When** ich Titel, Beschreibung, Preis, Marke, Modell und Kilometerstand ausfülle und speichere, **Then** wird das Inserat in der Tabelle `cars` gespeichert und erscheint nach dem Neuladen in der Übersicht.
* **Given** ich habe zusätzlich ein Bild ausgewählt, **When** ich speichere, **Then** wird das Bild unter `wwwroot/images/cars/` mit GUID-Dateinamen abgelegt und in der Übersicht sowie der Detailansicht angezeigt.
* **Given** ein Pflichtfeld ist leer, **When** ich auf «Speichern» klicke, **Then** erscheint die Meldung «Bitte alle Pflichtfelder korrekt ausfüllen.» und es wird nichts gesendet.

Die weiteren Stories (US3, US5) wurden mit denselben Gherkin-Mustern abgenommen: Freitextsuche filtert die geladene Liste über Titel, Beschreibung, Marke, Modell, Preis, Jahr und Kilometer; die Detailansicht zeigt das per Navigation übergebene Inserat inkl. Bild, Preis, Kilometerstand und Beschreibung.

---

## 11. Releaseplanung

**Release 1 – MVP** (Abschluss Sprint 4):

* Registrierung, Login mit JWT
* Inserat erstellen inkl. Bild-Upload
* Inseratsübersicht mit Freitextsuche
* Detailansicht

**Abnahmekriterien:** Alle Must-Stories umgesetzt, Unit Tests grün, Datenbank-Anbindung stabil, Frontend und Backend integriert, Dokumentation abgeschlossen. ✔ erfüllt (US1, US2, US3, US5, US6).

**Release 2 (Ausblick, nicht Teil des Moduls):** Bearbeiten/Löschen von Inseraten (US7/US8), Preisfilter (US4), Benutzer-Inserat-Zuordnung (US10), Behebung der technischen Schulden TD1/TD2.

---

## 12. Sprints: Planning, Review, Retrospektive

Es wurden vier Sprints durchgeführt. Die Sprintgrenzen sind anhand der Commit-Historie nachvollziehbar. Zwischen Sprint 2 und Sprint 3 lag ein geplanter Unterbruch (Ferien und Prüfungsphasen anderer Module), der in der Releaseplanung berücksichtigt wurde.

### Sprint 1 (09.02. – 23.02.2026) – Projektstart & Backlog

**Sprint Planning**

* Sprint-Ziel: Projektgrundlagen schaffen – Vision, Rollen, Product Backlog, Repository, Projektgerüste.
* Geplante Arbeit: keine User Stories, sondern Setup-Tasks (bewusst, da noch keine entwickelbare Basis existierte): Projektidee «MotoScout» definieren, Rollen verteilen, 10 User Stories inkl. Akzeptanzkriterien erstellen, DoD definieren, GitHub-Repository aufsetzen, Angular- und .NET-Projektgerüste anlegen.

**Sprint Review**

* Gezeigt: Product Backlog mit 10 Stories, Gherkin-Akzeptanztests für Login/Registrierung/Suche/Inserat, eingerichtetes Repository mit beiden Projektgerüsten (Commits `5796b56 projekte angelegt`, `3301d3e erster commit`).
* Feedback des Kunden → als Backlog-Verfeinerung übernommen: Stories detaillierter formulieren, Aufwandsschätzungen ergänzen, Sprintziele klarer definieren.

**Sprint Retrospektive**

* Continue: klare Rollenverteilung; frühe Definition der User Stories; konstruktive Zusammenarbeit.
* Stop: Aufgaben teilweise unklar definiert; Task-Aufteilung zu spät.
* Start: Tasks im Planning genauer definieren; Fortschritt regelmässig besprechen; Dokumentation parallel führen.

**SMART-Massnahmen aus Sprint 1**

| Massnahme (Specific & Measurable) | Verantwortlich | Termin | Umsetzung nachweisbar |
| --- | --- | --- | --- |
| Alle 10 User Stories bis zum nächsten Planning mit Story Points (Fibonacci) schätzen | Jan | Planning Sprint 2 (02.03.) | ✔ Backlog-Tabelle mit SP (Kapitel 10) |
| Jedes Weekly schriftlich im Repository protokollieren (mind. 1 Eintrag/Modultag) | Artian | laufend ab Sprint 2 | ✔ Doku-Commits 16.02./02.03./09.03. |
| Git-Workflow (Commit-Konventionen) im Team festlegen und dokumentieren | Luka | Planning Sprint 2 (02.03.) | ✔ Conventional Commits ab Sprint 2 (z. B. `b521de5 feat(motoscout): …`) |

---

### Sprint 2 (24.02. – 09.03.2026) – Login- & Register-UI

**Sprint Planning**

* Sprint-Ziel: Benutzer-Einstieg gestalten – Login- und Registrierungsseite als Angular-Komponenten.
* Geplante Stories: US1 Registrierung (5 SP), US2 Login (5 SP).
* Tasks: Login-Formular mit Validierung und «Remember me», Registrierungsformular mit Passwortstärke-Logik, Routing, Tailwind-Styling.

**Sprint Review**

* Gezeigt: Lauffähige Login- und Registrierungsseiten mit clientseitiger Validierung und Passwortstärke-Anzeige (Commit `b521de5 feat(motoscout): füge login und register design hinzu`).
* Feedback → in Backlog übernommen: Die Stories gelten ohne Backend nicht als «Done» (DoD!); Backend-Anbindung als nächste Priorität; Fehlermeldungen sollen vom Server kommen, nicht nur clientseitig geprüft werden.

**Sprint Retrospektive**

* Continue: gutes UI-Ergebnis; Conventional Commits wurden eingeführt.
* Stop: Stories horizontal (nur Frontend) statt vertikal geschnitten → 0 Story Points abgeschlossen; parallele Arbeit an der README auf `main` führte zu Merge-Konflikten (Commits `5424d1b`/`406d6aa Resolve merge conflict in README`).
* Start: Stories vertikal schneiden (Frontend + Backend + DB); für grössere Änderungen Branches verwenden.

**SMART-Massnahmen aus Sprint 2**

| Massnahme (Specific & Measurable) | Verantwortlich | Termin | Umsetzung nachweisbar |
| --- | --- | --- | --- |
| US1 und US2 in Sprint 3 vertikal fertigstellen (API + DB + Anbindung), Abnahme per Gherkin-Szenarien | Luka | Ende Sprint 3 (01.06.) | ✔ Commit `93f03d5 feat: (Moto-3) Backend und Datenback hinzugefügt` |
| `.gitignore` für beide Projekte einrichten, damit keine Build-Artefakte committet werden | Jan & Luka | Start Sprint 3 | ✔ Commits `1df3fc8` / `f9b48e5 add gitignore` |
| Mindestens 1 Unit-Test-Projekt mit gemocktem Repository aufsetzen (TDD-Woche 7) | Luka | Ende Sprint 3 | ✔ `ProjektBusinessTest` mit `AnmeldenDomainTests` |

---

### Sprint 3 (04.05. – 01.06.2026) – Backend, Datenbank & Authentifizierung

**Sprint Planning**

* Sprint-Ziel: US1 und US2 vollständig (vertikal) abschliessen – inkl. Datenbank, ORM, Hashing und JWT – sowie die Startseite vorbereiten.
* Geplante Stories: US1 Registrierung (5 SP), US2 Login (5 SP).
* Tasks: Docker-Compose mit MySQL und `init.sql`, NHibernate-Konfiguration und Entity-Mappings, Registrieren-/Anmelden-Feature über alle Schichten, PBKDF2-Hashing, JWT-Erstellung, Unit Tests für `AnmeldenDomain`, Grundgerüst Startseite.

**Sprint Review**

* Gezeigt (Live-Demo mit realistischen Testdaten): Registrierung mit Duplikat-Prüfung (Benutzername/E-Mail), fehlgeschlagene und erfolgreiche Anmeldung inkl. zurückgegebenem JWT, Persistierung in MySQL; Startseiten-Grundgerüst (Commits `604f7af füge startseite hinzu`, `8d2acf6 email einbauen`, `93f03d5 feat: (Moto-3) Backend und Datenback hinzugefügt`).
* Feedback → in Backlog übernommen: Fehlermeldungen beim Login verständlicher darstellen; Validierungen erweitern; Inserats-Funktionalität (US6/US3) als nächste Priorität.

**Sprint Retrospektive**

* Continue: vertikaler Story-Schnitt hat funktioniert (beide Stories «Done» nach DoD); saubere Schichtentrennung mit Interfaces.
* Stop: alle arbeiteten weiterhin direkt auf `main`; Wissens-Silos (Backend-Wissen v. a. bei Luka).
* Start: Feature-Branches mit Pull Requests und gegenseitigem Review; Pair Programming für Wissenstransfer.

**SMART-Massnahmen aus Sprint 3**

| Massnahme (Specific & Measurable) | Verantwortlich | Termin | Umsetzung nachweisbar |
| --- | --- | --- | --- |
| Jede neue Funktionalität in Sprint 4 über einen Feature-Branch + Pull Request mit Review eines zweiten Teammitglieds integrieren | Jan (SM überwacht) | ganzer Sprint 4 | ✔ Branches `feature/MS/MS-67/master`, `feature/MS/MS-68/master`; PR #1–#3 gemerged |
| US6 (Inserat erstellen) und US3 (Suche) bis Sprint-4-Ende live demonstrierbar | Luka & Jan | 07.06. | ✔ `Startseite` mit `/create` und Freitextsuche |
| Übersichts-/Detailseite (US5) als eigene Komponente umsetzen | Jan | 07.06. | ✔ Commit `84c9dbe feat: übersichtsseite hinzugefügt` |

---

### Sprint 4 (02.06. – 07.06.2026) – Inserate, Suche, Integration & Abschluss

**Sprint Planning**

* Sprint-Ziel: MVP fertigstellen – Inserate erstellen (inkl. Bild), Übersicht mit Suche, Detailansicht, Aufräumarbeiten und Abschlussdokumentation.
* Geplante Stories: US6 Inserat erstellen (8 SP), US3 Suche (8 SP), US5 Detailansicht (5 SP).

**Sprint Review**

* Gezeigt (Live-Demo): kompletter Durchlauf Registrierung → Login → Inserat mit Bild erstellen → Inserat in Übersicht finden (Freitextsuche) → Detailansicht öffnen. Zusätzlich demonstriert: Fehlerfälle (leere Pflichtfelder beim Erstellen, falsches Passwort beim Login) und Verhalten ohne Bild («Kein Bild vorhanden»-Platzhalter).
* Feedback → in Backlog übernommen: Oberfläche übersichtlich, Suche funktioniert zuverlässig; offene Punkte Bearbeiten/Löschen (US7/US8) und serverseitige Token-Prüfung (TD2) priorisiert für ein mögliches Release 2.

**Sprint Retrospektive**

* Continue: Feature-Branches + PRs haben Merge-Konflikte eliminiert; Reviews haben zwei Fehler vor dem Merge gefunden (Navigation, überflüssige Dateien – Commits `8d5e2c5 fix: navigation gefixt`, `6ecd722 fix: unnötige Files gelöscht`).
* Stop: Endspurt-Druck, weil zwischen Sprint 2 und 3 ein langer Unterbruch lag; Dokumentation teilweise nachträglich ergänzt.
* Start: technische Schulden (Secrets, Token-Validierung) explizit als Backlog-Items führen statt nur im Kopf.

**SMART-Massnahmen aus Sprint 4** (für Release 2 / Modulabschluss)

| Massnahme (Specific & Measurable) | Verantwortlich | Termin |
| --- | --- | --- |
| TD1: JWT-Secret und DB-Credentials in `.env`/Umgebungsvariablen auslagern, `.env` in `.gitignore` | Luka | Release 2 |
| TD2: Token-Validierung als Middleware für `/create` aktivieren, Nachweis per HTTP-Test (401 ohne Token) | Luka | Release 2 |
| Abschlussdokumentation (diese README) finalisieren und im Sprint-Review präsentieren | Artian | 07.06. ✔ (Commit `ae58c31 endgültige doku`) |

---

## 13. Velocity & Burndown

Die Velocity wurde pro Sprint anhand der **tatsächlich nach DoD abgeschlossenen** Story Points getrackt – nicht anhand begonnener Arbeit. Dadurch sind die Werte ehrlich und zeigen die Lernkurve des Teams:

| Sprint | Geplante SP | Abgeschlossene SP | Erklärung der Abweichung |
| --- | --- | --- | --- |
| Sprint 1 | – (Setup) | 0 | Bewusst keine Stories geplant (Projektaufbau) |
| Sprint 2 | 10 | 0 | US1/US2 nur horizontal (UI) umgesetzt → nach DoD nicht «Done» |
| Sprint 3 | 10 | 10 | US1 + US2 vertikal abgeschlossen |
| Sprint 4 | 21 | 21 | US6 + US3 + US5 abgeschlossen |

**Abgeleitete Massnahmen aus den Abweichungen:** Die Null-Velocity in Sprint 2 führte direkt zur Massnahme «Stories vertikal schneiden» (Retro Sprint 2), die in Sprint 3 nachweislich umgesetzt wurde – die Velocity stieg danach auf das geplante Niveau. Der Sprung auf 21 SP in Sprint 4 ist zudem dadurch erklärbar, dass die in Sprint 2 geleistete UI-Vorarbeit dort «geerntet» wurde; für eine Folgeplanung würde das Team mit einer Velocity von ca. 10–12 SP pro Sprint rechnen.

**Burndown Sprint 4** (verbleibende Story Points, täglich beim Weekly/Stand-up aktualisiert):

```text
SP verbleibend
21 |■
   |■■
13 |  ■■            ← US6 (8 SP) abgeschlossen (PR #1, 07.06. vormittags)
   |    ■■
 5 |      ■■        ← US3 (8 SP) abgeschlossen (Suche in Startseite)
   |        ■■
 0 |__________■     ← US5 (5 SP) abgeschlossen (PR #2/#3, Übersichtsseite + Navigation-Fix)
    02.06 ──────► 07.06
```

Über die Sprints 1–4 nahm der Gesamt-Backlog-Restbestand der Must-Stories von 31 SP auf 0 SP ab (Release-Burndown: 31 → 31 → 31 → 21 → 0).

---

## 14. Versionsverwaltung & Git Workflow

GitHub diente als zentrale Plattform für Code, Dokumentation und Zusammenarbeit. Das Repository umfasst 30+ Commits aller Teammitglieder.

### Beteiligung aller Teammitglieder (git shortlog)

| Mitglied | Commits | Schwerpunkte |
| --- | --- | --- |
| Jan Wyler (`janWyler384` / `janWyler1`) | 15 | Frontend, Übersichtsseite, PR-Merges |
| Artian Ismajli (`Artian-Hengst`) | 8 | Dokumentation, Merge-Pflege |
| Luka Jovanic (`LukaJovanic`) | 7 | Backend, Datenbank, Projektstruktur |

### Conventional Commits

Ab Sprint 2 wurden Conventional Commits (`feat`, `fix`, `refactor`, `docs`) konsequent eingesetzt. Echte Beispiele aus der Historie:

```text
feat: übersichtsseite hinzugefügt
feat: (Moto-3) Backend und Datenback hinzugefügt
feat(motoscout): füge login und register design hinzu
fix: navigation gefixt
fix: unnötige Files gelöscht
refactor: endpoints angepasst
refactor: verschiebe Readme
docs: Erstes Weekly
```

### Branching-Strategie & Pull Requests

Ab Sprint 4 (Massnahme aus Retro Sprint 3) wurde mit Feature-Branches und Pull Requests gearbeitet, benannt nach den Aufgaben-IDs des Teams:

* `feature/MS/MS-67/master` → **PR #1** «refactor: endpoints angepasst» (Review & Merge durch Jan)
* `feature/MS/MS-68/master` → **PR #2** «feat: übersichtsseite hinzugefügt» und **PR #3** «fix: navigation gefixt»

Jeder PR wurde von einem anderen Teammitglied als dem Autor reviewt und gemerged (sichtbar an Autor vs. Merger in der Historie). Die Wirkung der Massnahme ist messbar: In Sprint 2/3 gab es vier Konflikt-/Korrektur-Merges auf `main`, in Sprint 4 mit PR-Workflow keinen einzigen.

**Ehrlich dokumentierte Lücke:** Sprint-Abschlüsse wurden nicht mit Git-Tags/Releases markiert. Dies wurde erst bei der Abschlussreflexion erkannt und als Verbesserung für künftige Projekte festgehalten.

---

## 15. Clean Code & Code-Qualität

Die im Modul behandelten Prinzipien (Wochen 4, 8, 14, 15) wurden im Projekt angewendet:

### Sprechende Namen

Methoden und Klassen beschreiben ihre Aufgabe: `RegistrierungSpeichernAsync`, `CanRegistrierenAsync`, `GetUserAsync`, `recomputePasswordMetrics`, `isFormValid`, `getEmptyForm`. Im Frontend trennen kleine, fokussierte Methoden die Verantwortlichkeiten (`computePenalties`, `containsSubstringOf`, `maxRunLength`, `clamp`).

### Single Responsibility & KISS

Jedes Feature ist in Service (HTTP-Belange), Domain (Geschäftsregel) und Repository (Datenzugriff) getrennt – z. B. entscheidet ausschliesslich `RegistrierenDomain`, ob registriert werden darf, während `RegistrierenRepository` nur Daten liest/schreibt. Die Klassen sind klein (die meisten < 70 Zeilen).

### DRY mit Augenmass (YAGNI)

Wiederverwendbare Logik wurde zentralisiert: Passwort-Hashing ausschliesslich in `Hash.cs`, Erfolgs-/Fehlerresultate einheitlich über `CanResult`, Entity-Konvertierung in dedizierten Mapper-Klassen. Auf spekulative Abstraktionen (z. B. generisches Repository) wurde bewusst verzichtet (YAGNI).

### Keine Magic Numbers im Frontend-Kern

Schwellenwerte der Passwortbewertung sind als benannte, nachvollziehbare Berechnungen strukturiert; verbleibende Konstanten im Backend-Hashing (Iterationen, Längen) sind kommentiert und als Refactoring-Kandidat erfasst (Kapitel 18).

### Kommentare

Der Backend-Code ist durchgehend deutsch kommentiert und erklärt das *Warum* (z. B. in `NHibernateConfig`: «wird einmal erstellt und dann wiederverwendet», in `Hash.cs` die Bedeutung jedes PBKDF2-Parameters).

### Code-Review-Checkliste (Woche 15)

Bei den PR-Reviews in Sprint 4 wurde geprüft: sprechende Namen, keine offensichtlichen Code Smells (Long Method, Duplicate Code, Dead Code), Schichtentrennung eingehalten, Tests grün, keine überflüssigen Dateien (führte konkret zu `fix: unnötige Files gelöscht`).

---

## 16. Design Patterns im Projekt

Es werden nur Patterns dokumentiert, die im Code tatsächlich erkennbar sind:

### Repository Pattern (Structural)

Jedes Feature kapselt seinen Datenzugriff hinter einem Interface; die Domain kennt nur die Abstraktion:

```csharp
public interface IAnmeldenRepository
{
    Task<AnmeldenUser> GetHashAsync(string username);
}
```

Dadurch konnte `AnmeldenDomain` im Unit Test ohne Datenbank getestet werden (FakeItEasy ersetzt das Repository, siehe Kapitel 17).

### Dependency Injection (im gesamten Backend)

Alle Abhängigkeiten werden über Konstruktoren injiziert und in `Program.cs` im Built-in-DI-Container registriert (`AddScoped` für Services/Domains/Repositories). Kein `new` über Schichtgrenzen hinweg.

### Singleton-Lebenszyklus für die SessionFactory (Creational)

Die NHibernate-`SessionFactory` ist teuer im Aufbau und darf nur einmal existieren. `NHibernateConfig` wird deshalb als **Singleton** registriert und erzeugt die Factory lazy beim ersten Zugriff:

```csharp
// Program.cs – SessionFactory soll nur einmal erstellt werden
builder.Services.AddSingleton<INHibernateConfig, NHibernateConfig>();

// NHibernateConfig.cs
public NHibernate.ISession OpenSession()
{
    if (_sessionFactory == null)
    {
        _sessionFactory = CreateSessionFactory(); // einmalig
    }
    return _sessionFactory.OpenSession();
}
```

### Statische Fabrikmethoden (Creational)

`CanResult` hat einen privaten Konstruktor; Instanzen entstehen ausschliesslich über benannte Fabrikmethoden, was den Aufrufcode lesbarer macht als ein `bool`/`string`-Tupel:

```csharp
public static CanResult Success() => new CanResult(true, "Erfolgreich");
public static CanResult Fail(string reason) => new CanResult(false, reason);
```

### Mapper (projektweite Konvention)

Dedizierte Mapper-Klassen mit Interface (`RegistrierenMapper`, `CreateCarMapper`, `GetMotorradRepositoryMapper`) übersetzen zwischen Domain-Objekten (`User`, `Motorrad`) und Persistenz-Entities (`UsersEntity`, `MotorradEntity`) und halten so NHibernate-Details aus der Geschäftslogik fern.

**Abgrenzung:** Die im Modul zusätzlich behandelten Patterns Strategy, Observer, Facade, Composite und Decorator wurden analysiert, aber bewusst nicht eingebaut, da im MVP kein passendes Designproblem existierte (z. B. keine austauschbaren Algorithmen für Strategy) – ein künstlicher Einbau wäre ein «Golden Hammer»-Anti-Pattern gewesen.

---

## 17. Testing

### Teststrategie

Drei Ebenen: automatisierte Unit Tests für die Geschäftslogik, generierte Komponententests im Frontend, manuelle Akzeptanztests nach Gherkin.

### Backend-Unit-Tests (MSTest + FakeItEasy)

Das Testprojekt `ProjektBusinessTest` testet die Domain-Schicht isoliert von der Datenbank, indem das Repository gemockt wird (Mock-Ansatz aus Folienwoche 7 «Unit Tests mit Mock-Datenbanken»). Aufbau nach dem AAA-Muster (Arrange–Act–Assert):

```csharp
[TestMethod]
public async Task GetUserAsync_UserExistiert_Sollte_User_Zurueckgeben()
{
    // Arrange
    var expected = new AnmeldenUser(1, "luka", "HASH123");
    A.CallTo(() => _repository.GetHashAsync("luka"))
        .Returns(Task.FromResult(expected));

    // Act
    var result = await _domain.GetUserAsync("luka");

    // Assert
    Assert.IsNotNull(result);
    Assert.AreEqual(1, result.Id);
    Assert.AreEqual("luka", result.Username);
    Assert.AreEqual("HASH123", result.PasswordHash);
}
```

Abgedeckte Fälle: existierender Benutzer wird korrekt zurückgegeben; nicht existierender Benutzer liefert `null` (Negativtest). Ausführung mit `dotnet test`.

### Frontend-Tests (Karma/Jasmine)

Für jede Komponente existiert eine `*.spec.ts` (App, Login, Register, Startseite, Motorrad-Übersicht) mit Smoke-Tests («should create»), ausführbar mit `npm test`.

### Manuelle Akzeptanztests (Gherkin)

Jede umgesetzte Story wurde gegen ihre Given-When-Then-Szenarien (Kapitel 10) geprüft, inklusive Negativfälle (falsches Passwort, doppelter Benutzername, leere Pflichtfelder, Inserat ohne Bild). Gefundene Fehler wurden als `fix:`-Commits behoben (z. B. `fix: navigation gefixt`).

### Ehrliche Einordnung der Testabdeckung

Die automatisierte Abdeckung ist mit einer getesteten Domain-Klasse bewusst als Ausbaupunkt dokumentiert. Geplant (Backlog): Tests für `RegistrierenDomain` (Duplikat-Logik) und für `Hash.ValidateSHA256` (Roundtrip Hash→Validate). Die in der Retro Sprint 2 beschlossene Massnahme «Testprojekt mit Mocks aufsetzen» wurde in Sprint 3 nachweislich umgesetzt.

---

## 18. Refactoring

Refactoring wurde gemäss den Folien (Wochen 8 und 14) als kontinuierliche Tätigkeit verstanden: Code Smells erkennen, mit Tests als Sicherheitsnetz verbessern, Änderungen als `refactor:`-Commits kennzeichnen.

### Durchgeführte Refactorings (in der Commit-Historie nachweisbar)

| Commit | Technik | Beschreibung |
| --- | --- | --- |
| `f7b39b8 refactor: endpoints angepasst` | Restrukturierung | API-Endpoints im Zuge der Frontend-Integration bereinigt; über PR #1 mit Review gemerged |
| `2714099 refactor: verschiebe Readme` | Move | Dokumentation an die konventionsgemässe Stelle (Repo-Root) verschoben |
| `6ecd722 fix: unnötige Files gelöscht` | Dead Code entfernen | Überflüssige Dateien/Build-Artefakte entfernt (Smell «Dead Code») |
| `7d10b80 feat: csproj Datei neu geschrieben` | Projektstruktur | `csproj` neu aufgebaut, Altlasten entfernt |

### Im eigenen Code identifizierte Code Smells (Selbstreview, Sprint 4)

Diese Analyse stammt aus dem Code-Review des eigenen Repositories und ist als technische Schuld im Backlog erfasst:

1. **Duplicate Code:** `RegistrierenRepository.RegistrierungSpeichernAsync` und `CreateRepository.CreateCarAsync` enthalten identischen Ablauf (Session öffnen → Transaktion → mappen → `SaveAsync` → `CommitAsync`). Geplantes Refactoring: *Extract Method* in eine gemeinsame Hilfsmethode `SaveEntityAsync<T>`.
2. **Irreführender Name:** `Hash.CreateSHA256` erzeugt tatsächlich einen **PBKDF2**-Hash (HMAC-SHA256 ist nur die interne PRF). Geplantes Refactoring: *Rename* zu `CreatePbkdf2Hash` / `ValidatePbkdf2Hash`.
3. **Magic Numbers:** `16` (Salt-Bytes), `10000` (Iterationen), `32` (Hash-Länge) in `Hash.cs`. Geplantes Refactoring: *Replace Magic Number with Constant* (`private const int Pbkdf2Iterations = 10_000;` usw.).
4. **Long Method (Frontend/Backend-Grenzfall):** `CreateService.CreateAsync` mischt Form-Parsing, Datei-Upload und Domain-Aufruf. Geplantes Refactoring: *Extract Method* (`SaveImageAsync`).

Dass die Smells benannt, priorisiert und mit konkreter Technik versehen sind, war ein bewusster Entscheid: Im knappen Sprint 4 hatte das Fertigstellen der Must-Stories nach MoSCoW Vorrang vor kosmetischen Umbauten.

---

## 19. Pair Programming & Code Reviews

### Pair Programming

Beim Aufbau der NHibernate-Anbindung und der Frontend-Backend-Integration wurde nach dem **Driver/Navigator-Prinzip** (Folienwoche 15) gearbeitet: Der Driver implementierte, der Navigator prüfte die Logik laut mitdenkend, Rollen wurden gewechselt. Nutzen im Projekt: schnellere Fehlersuche bei der NHibernate-Konfiguration und Wissenstransfer vom Backend- zu den Frontend-Entwicklern (Massnahme gegen die in Retro Sprint 3 erkannten Wissens-Silos).

### Code Reviews

Ab Sprint 4 verpflichtend über Pull Requests: Autor und Reviewer/Merger waren stets unterschiedliche Personen (PR #1–#3, Merges durch Jan auf Branches von Luka/Jan-Dev-Account). Review-Checkliste: Clean Code (Namen, Smells), Schichtentrennung, Tests grün, keine überflüssigen Dateien. Konkrete Review-Ergebnisse: Navigation-Bug vor Release entdeckt (`fix: navigation gefixt`), Repository von Build-Artefakten bereinigt.

---

## 20. CI/CD

Die drei Stufen Continuous Integration, Continuous Delivery und Continuous Deployment wurden im Modul behandelt (Woche 13). Im Projekt wurde **bewusst keine CI/CD-Pipeline** (z. B. GitHub Actions) eingerichtet: Bei einem Team von drei Personen mit einem Modultag pro Woche und lokalem Deployment-Ziel stand der Nutzen in keinem Verhältnis zum Einrichtungsaufwand – die Priorität lag auf den Must-Stories (YAGNI/MoSCoW).

Die Kernziele von CI wurden stattdessen prozessual abgesichert: Integration über kurzlebige Feature-Branches und Pull Requests, lokale Builds und `dotnet test` vor jedem Merge, Code Reviews als Quality Gate. Als erster Schritt für eine echte Pipeline wäre ein GitHub-Actions-Workflow mit `dotnet build`, `dotnet test` und `ng build` pro PR vorgesehen (festgehalten als Ausblick).

---

## 21. Analyse von Problemen & Hindernissen

### Problem 1: Sprint 2 schloss keine einzige Story ab (Velocity 0)

**Ursachenanalyse (5-Why):**

1. Warum wurden keine Stories fertig? → Login/Registrierung funktionierten nur im UI, ohne Backend.
2. Warum gab es kein Backend? → Die Tasks waren nach Technik-Schichten (erst Frontend, später Backend) aufgeteilt.
3. Warum wurde nach Schichten aufgeteilt? → Das Team wollte mit der vertrauteren Technologie (Angular) starten.
4. Warum wirkte sich das auf die Velocity aus? → Die DoD verlangt vertikale Fertigstellung inkl. Datenbank.
5. Warum war das vorher nicht klar? → Beim Planning wurde die DoD nicht gegen den Story-Schnitt geprüft.

**Lösungsansatz gewählt:** Stories ab Sprint 3 vertikal schneiden und im Planning explizit gegen die DoD prüfen. **Alternative verworfen:** DoD aufweichen («UI fertig = Done») – verworfen, weil damit kein potentially shippable Increment entsteht.
**Wirkung:** Sprint 3 schloss beide geplanten Stories ab (Velocity 0 → 10).

### Problem 2: Wiederholte Merge-Konflikte auf `main` (Sprint 2/3)

**Ursachenanalyse (5-Why):**

1. Warum gab es Merge-Konflikte? → Mehrere Personen änderten gleichzeitig dieselben Dateien (v. a. README).
2. Warum dieselben Dateien? → Doku und Code lagen auf demselben Branch (`main`).
3. Warum arbeiteten alle auf `main`? → Es gab noch keine vereinbarte Branching-Strategie.
4. Warum keine Branching-Strategie? → Zu Projektbeginn unterschätzt («wir sind ja nur drei»).
5. Warum wurde es sichtbar? → Konflikt-Commits (`Resolve merge conflict in README`, 09.03.) kosteten Zeit im Sprint.

**Lösungsansatz gewählt:** Feature-Branches (`feature/MS/MS-67`, `feature/MS/MS-68`) mit Pull Requests und Review (Retro-Massnahme Sprint 3). **Alternative verworfen:** Datei-«Locking» per Absprache – verworfen, weil nicht skalierbar und fehleranfällig.
**Wirkung:** In Sprint 4 traten keine Merge-Konflikte mehr auf.

### Problem 3 (Hindernis): Langer Unterbruch zwischen Sprint 2 und Sprint 3

**Ursache:** Ferien und Prüfungsphasen anderer Module (kein Modultag von Mitte März bis Anfang Mai). **Folge:** Wiedereinarbeitungsaufwand und Endspurt-Druck in Sprint 4. **Massnahme:** Vor dem Unterbruch wurde der Stand committet und dokumentiert (Weekly-Protokolle), beim Wiedereinstieg startete Sprint 3 mit einem Re-Planning statt blind weiterzuarbeiten. **Erkenntnis für künftige Projekte:** Releaseplan von Anfang an um bekannte Unterbrüche herum planen.

---

## 22. Lessons Learned

### Sprint 1

1. Ein gemeinsames Verständnis der Vision («bewusst simpel, Fokus auf Methoden») verhindert Scope-Diskussionen während der Sprints.
2. User Stories mit Akzeptanzkriterien **vor** der ersten Codezeile zu schreiben, macht spätere Abnahmen objektiv (Gherkin als gemeinsame Sprache mit dem Kunden).
3. Klar verteilte Rollen (SM/Dev/Doku) beschleunigen Entscheidungen – aber Doku-Verantwortung darf nicht heissen, dass nur eine Person dokumentiert.

### Sprint 2

1. **Horizontaler Story-Schnitt ist die teuerste Abkürzung:** Schönes UI ohne Backend ist nach DoD wertlos – Velocity 0 trotz viel Arbeit.
2. Conventional Commits kosten nichts und machen die Historie sofort lesbar (`feat`/`fix`/`refactor`/`docs`).
3. Gemeinsame Dateien (README) auf einem gemeinsamen Branch sind ein Konflikt-Magnet – Branching ist auch in Kleinteams nötig.

### Sprint 3

1. Das Repository-Pattern mit Interfaces zahlt sich direkt aus: Die Domain liess sich mit FakeItEasy ohne Datenbank testen (Mock statt MySQL).
2. Eine teure Ressource wie die NHibernate-SessionFactory gehört in einen Singleton-Lebenszyklus – der Unterschied war beim Debuggen der DB-Verbindung deutlich spürbar.
3. Sicherheitsfunktionen (Salt, Iterationen, JWT-Claims) zuerst auf Papier durchspielen, dann implementieren – das verhinderte mehrere Irrwege.

### Sprint 4

1. Pull Requests mit Review eines zweiten Teammitglieds finden Fehler, die der Autor nicht sieht (Navigation-Bug, überflüssige Dateien).
2. Kleine, thematisch fokussierte Commits machen Reviews schnell – grosse Sammel-Commits (Sprint 3, `93f03d5`) waren deutlich mühsamer zu prüfen.
3. Technische Schulden explizit ins Backlog schreiben (TD1/TD2) entlastet die Retro und macht sie planbar, statt sie zu «vergessen».

### Vergleich über die Sprints & persönliche Entwicklung

Die grösste Entwicklung zeigt der Vergleich Sprint 2 ↔ Sprint 4: vom schichtweisen Arbeiten aller auf `main` (Velocity 0, Merge-Konflikte) zu vertikalen Stories, Feature-Branches, Reviews und stabiler Lieferung (21 SP, 0 Konflikte). Das Team hat damit die zentralen Modulinhalte – Releasezyklus (Woche 5), Living Documentation (Woche 6), TDD/Mocking (Woche 7), Refactoring (Wochen 8/14), VCS & Teamwork (Woche 3), Code Reviews & Pair Programming (Woche 15) – nicht nur theoretisch behandelt, sondern messbar im eigenen Prozess verankert. Persönlich hat jedes Mitglied den jeweils «fremden» Stack kennengelernt (Frontend↔Backend), wodurch die anfänglichen Wissens-Silos abgebaut wurden.

---

## 23. Bewusst nicht umgesetzte Funktionen & bekannte Schwachstellen

Im Sinne ehrlicher Dokumentation: Folgendes ist **nicht** im Code vorhanden und wird auch nicht behauptet.

| Punkt | Status | Begründung / geplanter Umgang |
| --- | --- | --- |
| Inserat bearbeiten / löschen (US7/US8) | Nicht umgesetzt | Should-Priorität; MoSCoW-Entscheid zugunsten der Must-Stories im knappen Sprint 4; Backlog für Release 2 |
| Preisfilter min/max (US4) | Nicht umgesetzt | Freitextsuche deckt den Hauptnutzen («passende Angebote finden») teilweise ab; dedizierter Filter in Release 2 |
| Zuordnung Inserat ↔ Benutzer (FK `user_id`) | Nicht umgesetzt | Bewusst aus dem MVP geschnitten; Voraussetzung für US7/US8 und daher gemeinsam geplant |
| Serverseitige JWT-Validierung der Endpoints (TD2) | Nicht umgesetzt | Token wird erstellt und zurückgegeben; Validierungs-Middleware fehlt noch – als technische Schuld priorisiert |
| Token-Speicherung im Login-Flow | Teilweise | Hilfsklasse `Authenticator` (localStorage, «Remember me») existiert, ist aber im Login-Flow noch nicht angebunden |
| Login-Fehlermeldung vom Server | Bekanntes Issue | Backend liefert bei Fehlschlag nur `success: false` ohne `message`, das Frontend erwartet `message` – Fix als Backlog-Eintrag erfasst |
| Secrets via Umgebungsvariablen (TD1) | Nicht umgesetzt | JWT-Secret/DB-Passwort aktuell hartkodiert; Auslagern in `.env` für Release 2 eingeplant |
| Git-Tags / Releases pro Sprint | Nicht umgesetzt | Erst in der Abschlussreflexion erkannt; als Prozessverbesserung notiert |
| CI/CD-Pipeline | Nicht umgesetzt | Begründeter Verzicht, siehe Kapitel 20 |

---

## 24. Risiken

| Risiko | Auswirkung | Gegenmassnahme (umgesetzt) |
| --- | --- | --- |
| Merge-Konflikte | Entwicklungsverzögerung | Feature-Branches + Pull Requests (ab Sprint 4) ✔ |
| Fehler im Login | Benutzer können sich nicht anmelden | Unit Tests der Anmelde-Domain + manuelle Negativtests ✔ |
| Datenbankprobleme | Datenverlust / Inkonsistenz | Versioniertes Schema (`init.sql` im Repo), Transaktionen bei Schreibzugriffen ✔ |
| Zeitmangel (Unterbruch, Endspurt) | Nicht fertiges MVP | MoSCoW-Priorisierung, Should/Could-Stories bewusst verschoben ✔ |
| Wissens-Silos im Team | Bus-Faktor 1 für Backend | Pair Programming, Reviews durch Nicht-Autoren ✔ |
| Hartkodierte Secrets | Sicherheitsrisiko bei Veröffentlichung | Als TD1 erfasst; nur lokale Entwicklungsumgebung betroffen |

---

## 25. Gesamtfazit

Ziel des Projekts war die Entwicklung einer webbasierten Plattform zur Verwaltung von Motorradinseraten mit konsequent agilem Vorgehen. Das MVP wurde erreicht: Alle Must-User-Stories (Registrierung, Login mit JWT, Inserat erstellen inkl. Bild, Suche, Detailansicht) sind umgesetzt, lauffähig und gegen ihre Gherkin-Akzeptanzkriterien abgenommen.

Mindestens ebenso wertvoll wie das Produkt ist der dokumentierte Prozessfortschritt: Das Team hat aus einem misslungenen Sprint (Velocity 0 durch horizontalen Story-Schnitt) konkrete, messbare Massnahmen abgeleitet und deren Wirkung in den Folgesprints nachgewiesen – vertikale Stories, Feature-Branches mit Pull Requests und Reviews, Unit Tests mit Mocks, Conventional Commits und eine ehrlich geführte Liste technischer Schulden. Offene Punkte (Bearbeiten/Löschen, Token-Validierung, Secrets-Handling) sind transparent dokumentiert, begründet und für ein Release 2 priorisiert.

Damit erfüllt das Projekt die definierten Anforderungen und zeigt zugleich, dass die im Modul M426 behandelten Methoden – Scrum, Clean Code, TDD/Mocking, Refactoring, Design Patterns, Versionsverwaltung und Code Reviews – im eigenen Projektalltag angewendet und reflektiert wurden.
