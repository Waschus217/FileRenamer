using System;

namespace renamerIdee
{
    public class StartingPage
    {
        InputValidation validation = new InputValidation();
        int helpDecision;

        public StartingPage()
        {
            validation = new InputValidation();
        }

        public void StartSign()
        {
            string sign = "File Renamer";
            int width = sign.Length + 4;

            Console.WriteLine(new string('*', width));
            Console.WriteLine($"* {sign} *");
            Console.WriteLine(new string('*', width));
        }

        public int StartInformation()
        {
            Console.WriteLine("\nVielen Dank dass Sie unseren File Renamer nutzen.");
            Console.WriteLine("Mittels diesem können Sie einen Dateipfad eingeben \nund in diesem dann zwischen verschiedenen Umbennenungsoprionen wählen.");
            Console.WriteLine("\nFür weiter Details tippen Sie bitte die (1). \nSofern keine Hilfe nötig klicken Sie die (2) und Sie können loslegen.");

            return helpDecision = validation.GetValidInputOneOrTwo("Bitte wählen: ");
        }

        public void HelpScreen()
        {
            Console.Clear();
            string sign = "Hilfe";
            int width = sign.Length + 4;

            Console.WriteLine(new string('*', width));
            Console.WriteLine($"* {sign} *");
            Console.WriteLine(new string('*', width));

            Console.WriteLine("\nPräfixe ändern: Diese Option ändert den Text am Anfang des Dateinamens.");
            Console.WriteLine("Präfixe löschen: Hiermit kann man den Anfangstext einer Datei löschen.");
            Console.WriteLine("Suffixe ändern: Diese Funktion ändert den Text am Ende des Dateinamens.");
            Console.WriteLine("Suffix löschen: Mit dieser Option wird der Endteil des Dateinamens entfernt.");
            Console.WriteLine("Teilausdrücke ändern: Ändern eines spezifischen Teils des Dateinamens.");
            Console.WriteLine("Zahlenblock verschieben: Verschiebt Zahlenblock an das andere Ende des Dateinamens.");
            Console.WriteLine("Führende Nullen einfügen: Fügt Nullen an den Anfang des Dateinamens ein.");
            Console.WriteLine("Führende Nullen löschen: Entfernt führende Nullen im Dateinamen.");
            Console.WriteLine("Zahlenblock einfügen: Fügt eine Zahl/Zahlenblock an eine bestimmte Position im Dateinamen ein.");
            Console.WriteLine("Zahlenblock löschen: Entfernt einen bestehenden Zahlenblock aus dem Dateinamen.");
            
            Console.ReadKey();
        }

        public void EndSign()
        {
            Console.Clear();
            string sign = "Vielen Dank";
            int width = sign.Length + 4;

            Console.WriteLine(new string('*', width));
            Console.WriteLine($"* {sign} *");
            Console.WriteLine(new string('*', width));
        }
    }
}
