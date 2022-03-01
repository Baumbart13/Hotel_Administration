Hotelverwaltung
====

Erklärung zum Beispiel (Überblick)
----

Es soll für ein Hotel eine Verwaltungs-App programmiert werden. Das Programm soll in mehrere Teile aufgegliedert werden.
1. Datenbank-Modellierung: das zugehörige Datenbankmodell soll grafisch dargestellt werden
2. Web-API: alle Daten sollen über ein Web-API-Interface zur Verfügung gestellt werden (vorhergehendes Beispiel von uns) – es kann das Entity-Framework (ORM) oder die normalen DB-Klassen (4.Klasse) verwendet werden
3. App: dem Verwaltungspersonal (Rezeptionist/Rezeptionistin) soll über diese App die komplette Verwaltung des Hotels (freie Zimmer anzeigen, Zimmer reservieren, neuen Gast anlegen/ändern, Rechnungsverwaltung (Rechnung erzeugen, bezahlen, …), Zusatzleistungen (Tennis, Fitnessraum, usw.) verwalten)


1 Datenbank-Modellierung
====

Folgende Daten sollen in den DB-Tabellen gespeichert werden:
- [ ] Gästedaten:
    - [ ] alle notwendigen Daten zu den Gästen des Hotels
    - [ ] (zur eindeutigen Identifizierung: die Passnummer);
    - [ ] pro Gast sollen mehrere Adressdaten abgespeichert werden.
        - [ ] Adressdaten
- [ ] Alle Zimmerdaten:
    - [ ] Zimmernummer,
    - [ ] Anzahl Betten,
    - [ ] mit/ohne Küche,
    - [ ] mit/ohne Balkon,
    - [ ] mit/ohne Terrasse,
    - [ ] Preis pro Nacht,
    - usw.
- [ ] Zimmerreservierungen:
    - [ ] Start- und Enddatum der Reservierung,
    - [ ] wer hat das Zimmer reserviert,
    - [ ] welches Zimmer wurde reserviert,
    - usw.
- [ ] Rechnungen:
    - [ ] auf welchen Gast lautet die Rechnung,
    - [ ] welche Zimmer gehören zur Rechnung,
    - [ ] wurde die Rechnung bezahlt (ja/nein),
    - [ ] Zahlungsziel (wann muss die Rechnung beglichen sein),
    - [ ] Zahlmethode
        - [ ] PayPal,
        - [ ] Bar,
        - [ ] Visa,
        - usw.
    - [ ] Rabatt für ein Zimmer,
    - usw.
- [ ] Zusatzleistungen:
    - [ ] welcher Gast hat eine Zusatzleistung gebucht,
    - [ ] Datum,
    - [ ] Start- und Endzeitpunkt,
    - [ ] Normalpreis,
    - [ ] Rabatt,
    - [ ] bezahlt (ja/nein),
    - usw.


Hiermit sind die wichtigsten Daten bekannt. Wenn im Verlauf der DB-Modellierung weitere Felder benötigt werden, füge sie hinzu.


Aufgabe:
----

1. Erzeuge zu den obigen Daten das **konzeptionelle Modell** und das **interne Modell**. 
2. Lass dir aus den erstellten Tabellen das ``EER-Diagramm`` erzeugen


2 Web-API
====

1. Erzeuge ein Web-API-Projekt inkl. Datenbankanbindung (Anbindung z.B. an ``MySQL``)
2. Erzeuge nur einen ersten Teil (Interface + Klassen) für die Zimmerverwaltung: biete vorerst nur folgende Methoden an:
    - [ ] Alle Zimmer ermitteln
    - [ ] Alle freien Zimmer ermitteln
        - [ ] (innerhalb eines bestimmten Datumsbereichs (Start-, Enddatum))


3 App: erzeuge nun die zugehörige App
====

- [ ] Gestalte die erste Seite nach deinen Wünschen 
    - z.B.
    - [ ] Buttons
        - [ ] um zur Gästeregistrierung,
        - [ ] Zimmerverwaltung,
        - [ ] Rechnungsverwaltung,
        - usw. zu gelangen
- [ ] Zimmerverwaltung:
    - greife auf die Web-API von oben zu und
    - [ ] zeige alle Zimmer/alle freien Zimmer an


### Teste nun deinen gesamten Code so lange, bis alles funktioniert.


4 Erweitere nun dein Web-API-Projekt nur um einen weiteren kleinen Teil.
====

- [ ] z.B. Gästeregistrierung
    - [ ] erweitere dein Web-API-Projekt, damit Gäste in den DB-Tabellen abgespeichert werden können
    - [ ] erweitere deine App, damit sich ein neuer Gast registrieren kann
    - [ ] teste wieder so lange, bis alles funktioniert


5 Führe die gleichen Schritte (siehe [4](#4-Erweitere-nun-dein-Web-API-Projekt-nur-um-einen-weiteren-kleinen-Teil)) für alle weiteren Vorgaben aus.
====