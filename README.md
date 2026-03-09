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

### US7 - 