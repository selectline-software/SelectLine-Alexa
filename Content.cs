using System;
using System.Collections.Generic;

namespace LambdaSLAPI
{
    static class Content
    {
        public static List<String> ListOfBye = new List<String>
        {
            "Tschüss",
            "Tschüssikowski",
            "Tschö mit ö"
        };

        public static List<String> ListOfTips = new List<String>
                                                {
                                                    "Stammdaten und Belege können mehrfach geöffnet werden. Sie können hierfür die Tastenkombination <Strg>+Maustaste im Hauptmenü verwenden. Das gilt auch für das Öffnen von Stammdialogen über die kontextbezogenen Programmfunktionen. Nutzen Sie die Funktion bspw. um zu einem geöffneten Kundenfenster ein zweites aufzurufen, indem Sie bei gedrückter <Strg>-Taste im Hauptmenü auf „Kunden“ klicken. Somit können Sie zwei oder mehr Kunden direkt miteinander vergleichen.",
                                                    "In den Mustermandanten finden Sie vorbereitete Beispieldaten. Die Mustermandanten stehen als Datensicherungen im Datenverzeichnis zur Verfügung. Das Einspielen der Mustermandanten erfolgt über den Menüpunkt Wartung/Datensicherung/Datensicherung laden im Applikationsmenü.",
                                                    "Mit einem Testmandanten können Sie alle Programmfunktionen ausprobieren, ohne Ihren Datenbestand zu gefährden.",
                                                    "Sie können in Auswahlfeldern mit der rechten Maustaste ein Menü aktivieren, mit dem Sie Stammdatensätze anlegen, bearbeiten und auflisten können.",
                                                    "Sie können bei der Erfassung der Belegpositionen für die Menge Ausdrücke eingeben, wie z.B. 2 * (6,3 + 3,9).",
                                                    "Beim Drucken können Sie eine Kopie an einen zweiten Drucker schicken, wenn Sie im Menüpunkt Drucken/Druckvorlagen im Applikationsmenü bei der Druckvorlage einen Folgedateinamen festlegen.",
                                                    "In Lieferscheinen können Sie das Gesamtgewicht ausdrucken, wenn Sie in den Artikelstammdaten das Gewicht für jeden einzelnen Artikel eintragen.",
                                                    "Die Bestätigung der Druckvorlage und des Druckziels kann im Menüpunkt Drucken/Druckvorlagen im Applikationsmenü abgestellt werden.",
                                                    "Auswertungen, die mit dem Makro-Assistenten erstellt wurden, können in die Schnellzugriffsleiste oder das Makro-Menü integriert werden.",
                                                    "Das Format der Adresse, die Sie über die Zwischenablage an andere Programme übergeben können, legen Sie über den Schalter Einstellungen im Applikationsmenü fest.",
                                                    "Für interne Bemerkungen innerhalb der Belegpositionen, die nicht gedruckt werden sollen, setzen Sie die Option Drucksperre.",
                                                    "Um einen bestimmten Datensatz aufzusuchen, können Sie eine markante Textpassage in das Eingabefeld am unteren rechten Rand der Stammdatenmasken eingeben und die Filterung mit dem Knopf des Eingabefeldes starten.",
                                                    "In Datumsfeldern können spezielle Datumsangaben über das Kontextmenü (rechte Maustaste) oder durch Eingabe von m, M, j, J oder eines Leerzeichens erfolgen.",
                                                    "Die Arbeitsweise der Positionseingabe in den Belegen können Sie mit der Funktion Maske anpassen nach Ihren Bedürfnissen weitestgehend konfigurieren.",
                                                    "Die Eingabemasken für die Struktur der Artikel-, Kunden- und Lieferantengruppen öffnen sich automatisch entsprechend der Einstellung (Autom. Öffnen) im Systemmenü der Strukturansicht (links oben).",
                                                    "In Langtextfelder können Sie Tabulatoren mit der Tastenkombination <Strg>+<I> einfügen.",
                                                    "Wenn Sie vielen Artikeln eine Mengenformel zugewiesen haben, ist es praktischer, in Ausgangsbelegen die Eingabereihenfolge auf »Artikel vor Menge« zu setzen.",
                                                    "Das Mandantenfeld in der Statuszeile des Hauptfensters können Sie zur Bearbeitung des Mandanten doppelklicken, bzw. zum Mandantenwechsel mit der rechten Maustaste anklicken.",
                                                    "Listen, die Sie im Programmteil Mandant/Überblick/Liste öffnen, werden beim nächsten Programmstart automatisch an derselben Position geöffnet.",
                                                    "Zur Überwachung der Termine und Bestände können Sie im Programmteil Mandant/Überblick/Aufgaben festlegen, welche Überprüfungen beim Programmstart erfolgen sollen.",
                                                    "In der Eingabemaske Mandant/Einstellungen/Vorgabewerte/Schlüssel können Sie einstellen, wie sich ein Auswahlfeld verhalten soll, wenn der eingetragene Schlüssel nicht existiert. (Daten auflisten oder neuen Datensatz anlegen)",
                                                    "Wenn Sie mit der rechten Maustaste in Felder für Dezimalzahlen (z. B. Preise) klicken, öffnet sich der Papierstreifenrechner, dessen Ergebnis automatisch in das Eingabefeld übernommen wird.",
                                                    "Zur schnelleren Auswahl von Artikeln, Kunden und Lieferanten kann im oberen Teil des Auswahlfensters die Gruppenhierarchie eingeblendet und zur Einschränkung der unteren Tabelle die gewünschte Gruppe markiert werden.",
                                                    "Wollen Sie beim Schreiben von Belegen für einen Kunden/Lieferanten an etwas erinnert werden, können Sie das im Memotext des Kunden/Lieferanten eintragen.",
                                                    "Um einzelne Platzhalter innerhalb eines Bildschirmausdrucks zu korrigieren, schalten Sie am einfachsten mit der Taste F8 in die Ansicht mit Lineal und führen einen Doppelklick auf die gewünschte Stelle aus. ",
                                                    "Wenn Sie eine Maus mit Rad verwenden, können Sie das Rad nicht nur dazu benutzen, sich in den Tabellen oder in der Druckvorschau zu bewegen, sondern Sie können damit auch die Werte in den Eingabefeldern erhöhen oder verringern. Im Datumsfeld wird gezählt: nur Rad = Tag; Umsch-Rad = Monat; Strg-Rad = Jahr.",
                                                    "Mit dem Spalteneditor für Tabellenfelder, den Sie über einen linken Mausklick auf die linke obere Ecke der Tabelle erreichen, können Sie festlegen welche Felder angezeigt werden sollen und in welcher Reihenfolge.",
                                                    "Eine einfache Möglichkeit, Werte aus Tabellen in Microsoft Word oder Microsoft Excel bzw. in die Open-Office-Programme zu exportieren, haben Sie mit den Programmfunktionen, die Sie mit einem linken Mausklick in die linke obere Ecke der Tabelle erreichen.",
                                                    "Um einen Mandanten komplett zu duplizieren, wechseln Sie in den Mandanten, sichern ihn über Applikationsmenü/Datensicherung/Mandantendaten sichern und spielen ihn mit dem Menüeintrag Applikationsmenü/Datensicherung/Datensicherung laden wieder ein, wobei Sie für den Zielmandanten eine neue Mandantennummer vergeben.",
                                                    "Mit der Option Auslagersperre in den Lagerstammdaten verhindern Sie dass Bestände aus diesen Lägern verkauft werden können.",
                                                    "Im Beleg wandelt ein Rechtsklick auf den Infoschalter über dem Einzelpreis der Belegposition den Wert des Feldes von Brutto auf Netto (in Belegen mit Preistyp Netto) bzw. von Netto auf Brutto (in Belegen mit Preistyp Brutto) um.",
                                                    "Beim Drucken als E-Mail legen Sie mit den Formelplatzhaltern EMail die Adresse und mit EMail-Betreff den Betreff fest.",
                                                    "Wenn Sie z.B. die Artikelnummern nicht im Kopf haben, können Sie unter Mandant/Einstellungen/Vorgabewerte/Schlüssel bei ungültigem Datensatz in einem Feld filtern (Bezeichnung) einstellen. Tragen Sie dann in einem Artikel-Auswahlfeld einen Teil der Bezeichnung ein, erhalten Sie eine Liste aller Artikel mit passender Bezeichnung zur Auswahl.",
                                                    "Um in der Artikelmaske schnell zu einem Unterartikel einer mehrfach verschachtelten Stückliste zu gelangen, können Sie diesen Artikel in der Baumansicht (links) anklicken und danach den Schalter Stammdaten betätigen.",
                                                    "Im Programmteil Applikationsmenü/Einstellungen/Darstellung auf der Seite Farben/Tabellenfarbe können Sie die Farbgebung des Hintergrundes der Tabellenzeilen regeln. Die Änderung der Schriftfarbe erfolgt über einen Rechtsklick auf die Legende unterhalb der Tabelle. ",
                                                    "Wenn eine Auswertung an mehrere E-Mail-Adressen gesplittet ausgegeben werden soll, kann dies durch eine Neuzuweisung des Sonderplatzhalters EMail erfolgen. Analoges gilt für das Splitten einer Dateiausgabe, wo die Sonderplatzhalter DateiTXT, DateiRTF bzw. DateiPDF neu zuzuweisen sind.",
                                                    "Mit <Strg>+<F> können Sie in den Belegpositionen suchen.",
                                                    "Wenn man in ein Langtextfeld den Schlüssel eines Textbausteins eingibt und <Strg>+<T> drückt, wird der Schlüssel gegen den eigentlichen Langtext ausgetauscht.",
                                                    "Mit der Tastenkombination <Alt>+<Links> kann in die Baumstruktur der Dialoge gewechselt werden.",
                                                    "Die Bearbeitungsseite der Belegpositionen lässt sich in den Belegen mit der Tastenkombination <Alt>+<P> erreichen.",
                                                    "Mit der erweiterten Anzeige in Tabellen, deren Inhalt im unteren Teil des Spalteneditors festgelegt wird, haben Sie die Möglichkeit, weitere Informationen zum ausgewählten Datensatz der Tabelle anzuzeigen.",
                                                    "Vor dem Abschluss einer Inventur können Sie mit dem Menüpunkt Testlauf - Inventurabschluss eine Prüfung der eingegeben Daten durchführen.",
                                                    "In Eingabemasken mit einem OK- und einem Abbruchschalter wirkt die Taste <F10> wie das Drücken des OK-Schalters, die Taste <ESC> bewirkt einen Abbruch.",
                                                    "Eingabefelder mit einem blauen Dreieck in der rechten oberen Ecke sind Pflichtfelder und müssen gefüllt werden.",
                                                    "Sie können für jede Druckvorlagenart und abweichend auch für jede Druckvorlage einstellen, ob zusätzlich zum Druck auch noch eine Archivierung mit einem installierten Archivsystem oder in einem gewählten Ordner als PDF erfolgen soll.",
                                                    "Wenn Sie mehrere Standorte haben und für jeden Standort einen Bearbeiter, dann können Sie im Datensatz des Bearbeiters (Mitarbeiterstammdaten) einen Standort eintragen und in den Mandanteneinstellungen auf der Seite Lager die Option Belegstandort vom angemeldeten Nutzer setzen.",
                                                    "Wird in einem Dialog oder einer Tabelle ein Datensatzschlüssel angezeigt, können Sie mit einem Linksklick bei gedrückter Alt-Taste den zugehörigen Dialog öffnen und im Kontextmenü werden Programmfunktionen für diesen Datensatz angeboten. Nutzen Sie <Alt>+<linke Maustaste> auch bei Abkürzungen, E-Mail- und Web-Adressen, Datei- und Pfadangaben, Zahlen, Datumsangaben, Orten oder Telefonnummern.",
                                                    "Stammdaten, wie Artikel, Kunden, Interessenten, Lieferanten und Mitarbeiter, die nicht mehr in Auswahllisten angeboten werden sollen, können im Funktionsmenü des jeweiligen Dialogs inaktiv gesetzt werden. Zusätzlich besteht die Möglichkeit, in den Einstellungen der jeweiligen Stammdialoge, inaktive Datensätze auszublenden.",
                                                    "Wird in Tabellen die Suchzeile nicht benötigt, kann sie im Spalteneditor mit der Option Suchzeile anzeigen ausgeblendet werden.",
                                                    "Ob für neu erstellte Zahlungsläufe erst eine Freigabe erfolgen muss, kann in den Mandanteneinstellungen auf der Seite Zahlungsverkehr mit der Option Zahlungsläufe automatisch freigeben eingestellt werden.",
                                                    "Sie können aus der Bildschirmansicht des Drucks in der Ansicht mit Lineal den Formulareditor mit bereits markiertem Platzhalter öffnen, indem Sie die Maus in der Bildschirmansicht über den Platzhalter halten und die Taste F12 drücken. ",
                                                    "In der Belegdefiniton können Sie mit der Option Bearbeitungsstatus verwenden festlegen, dass Ein- und Ausgangsbelege während der Bearbeitung den Status In Bearbeitung erhalten und damit von der Belegübergabe, vom Sammeldruck und vom Fibuexport ausgeschlossen sind.",
                                                    "Bei der Gestaltung von Druckvorlagen lassen sich mit einem Frei positionierbaren Block Ausgaben an beliebigen Bereichen des Formulars erzeugen, ohne die Positionierung und Schriftenverwaltung der normalen Ausgabe zu beeinflussen.",
                                                    "Im Statusbereich des Beleges können Sie die Zeile gedruckt markieren, und es erscheint der Schalter Protokoll mit dem eine Auflistung der erfolgten Ausdrucke bzw. Druckstatusänderungen geöffnet werden kann.",
                                                    "Solange für den Belegtyp Vorkasse noch keine Belege existieren, kann für den Vorkassebeleg festgelegt werden, ob er reservieren soll.",
                                                    "In Langtextfeldern lässt sich die Schriftgröße mit dem Mausrad bei gedrückter Strg-Taste ändern.",
                                                    "In Belegen können Sie Positionen mit der Taste <+> auf dem Ziffernblock speichern.",
                                                    "Wenn bei der Belegerfassung die Seite Positionen geöffnet ist, können Sie mithilfe der Tastenkombination <Strg>+<O> direkt in die Positionsübersicht springen. ",
                                                    "Wenn Sie in einem Textbaustein den Platzhalter @[|] eingeben, so steht nach dem Einfügen des Textbausteines die Schreibmarke an der Stelle des Platzhalters."
                                                };

        public static List<String> ListOfInfos = new List<String>
                                                 {
                                                     "SelectLine wurde 1992 gegründet.",
                                                     "SelectLine beschäftigt rund 120 Mitarbeiter.",
                                                     "SelectLine hat zwei Schwesterunternehmen. Eins in St. Gallen in der Schweiz und eins in Schwanenstadt in Österreich.",
                                                     "SelectLine stellt kaufmännische Software für kleine und mittlere Unternehmen her.",
                                                     "SelectLine hat seinen Firmensitz in der Innenstadt Magdeburgs."
                                                 };
    }
}