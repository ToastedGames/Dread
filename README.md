# Dread Projekt

Hier ist unser Project Dread von den cooleren Teilnehmern der Games Talente Akademie:
* [ToastedGames](https://github.com/ToastedGames)
* [Schnitzelreaper](https://github.com/Schnitzelreaper)
* [Michael](https://github.com/hghjgfjgf)
* [Leon Henning](https://github.com/LeonHenning)

## Beschreibung

Wir entwickeln ein athmosphärisches top-down, horror Computerspiel mit Unity.
In diesem spielt der Spieler in einem Traum und muss kleine Aufgaben erledigen. Wenn man diese Aufgabe schafft, also das Level zuendespielt, dann schläft man wieder ein und geht eine Traumebene tiefer (das nächste Level). Jede Traumebene wird immer verrückter (graphisch und mechanisch). Das Ziel des Spiels ist alle Traumebenen zu durchschreiten und dem Traum zu entkommen.

## Regeln zum Mitwirken

* Linux nicht erwünscht ;)

### Coding

* Möglichst modular schreiben (Bsp: Player Controller auf (fast) jedes Objekt schieben und es funktioniert)
* Methoden möglichst klein halten
* IMMER aussagekräftige Namen verwenden
* Jede Methode mit Beschreibung versehen als Kommentar
* Goß und Kleinschreibung beachten:
    * Methoden in Pascal case (Bsp: MethodenName )
    * Variablen in camel case (Bsp: variablenName )
    * Klassen in Pascal case (Bsp: MethodenName )
* Wenn möglich, *public* Methoden mit einer Dokumentation versehen:
    ```
    /// <summary>
    ///     Beschreibung der Methode
    /// </summary>
    /// <param name=" isbnparameterName "> Beschreibung .</param>
    /// <returns> Beschreibung dessen, das zurückgegeben wird.</returns>
    ```

### Unity
* WICHTIG: Damit keine Dinge überschrieben werden darf jeder nur an einer Szene gleichzeitig arbeiten. Dafür gibt es ein Trello Board (siehe unten)
* Groß und Kleinschreibung beachten:
    * Objekte in der Herachie mit Großbuchstabe anfangend und mit Leerzeichen 
      (Bsp: Objekt Name)
    * ALLE Dateien in Pascal case (Bsp: DateiName)
* Ordnerstrukturen:
    * Alle Skripte in den Ordner *Skripte*
    * Alle Grafischen dateien in Ordner *Sprites*
    * **nur Scenes** in den Ordner *Scenes*
    * Alle Prefabs, Tilemap, etc. assets in *Prefabs* 
* Unterordner sind noch nicht näher definiert

### Art

* Jemand kompetentes soll hier mal was hinschreiben

### Projekt Management

* [Trelloboard](https://trello.com/invite/b/BIaJoIbF/da053866bf4f2ce9fb017f454b049d03/dread)
* [Trelloboard_Dateimanagement](https://trello.com/invite/b/a6mDkHjm/814a002cf57fb5b8932ac8dd1034aaec/dateien-version-control)