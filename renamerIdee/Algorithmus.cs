using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace renamerIdee
{
    class Algorithmus
    {
        public static void AlgorithmRenamePictureFiles()
        {
            Console.WriteLine("Auswahlmöglichkeiten:");
            Console.WriteLine("(1) Präfixe ändern");
            Console.WriteLine("(2) Suffixe ändern");
            Console.Write("Deine Wahl: ");
            int choiceOption = Convert.ToInt32(Console.ReadLine());
            Console.Write("Pfad: ");
            string pathInput = Console.ReadLine();
            string directoryPath = $@"{pathInput}"; // Bevor ihr den FileRenamer ausführt eure Bilder in einem Ordner tun und Pfad ändern.
            string[] fileExtensions = new string[] { "*.*" };
            string newFileNamePattern = "img";

            try
            {
                List<string> files = new List<string>();
                foreach (var fileExtension in fileExtensions)
                {
                    files.AddRange(Directory.GetFiles(directoryPath, fileExtension));
                }

                if (files.Count == 0)
                {
                    Console.WriteLine("Keine Dateien im angegebenen Ordner gefunden.");
                    return;
                }

                switch (choiceOption)
                {
                    case 1:
                        ChangePrefix(files, newFileNamePattern, directoryPath);
                        break;
                    case 2:
                        Console.Write("Gib das neue Suffix ein: ");
                        string newSuffix = Console.ReadLine();
                        ChangeSuffix(files, newSuffix, directoryPath);
                        break;
                    default:
                        Console.WriteLine("!!!Ungültige Eingabe!!!");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ein Fehler ist aufgetreten: {ex.Message}");
            }
        }

        public static void ChangePrefix(List<string> files, string newFileNamePattern, string directoryPath)
        {
            for (int i = 0; i < files.Count; i++)
            {
                string currentFilePath = files[i];
                string extension = Path.GetExtension(currentFilePath);
                string newFileName = $"{(i + 1):D3}-{newFileNamePattern}{extension}";
                string newFilePath = Path.Combine(directoryPath, newFileName);

                System.IO.File.Move(currentFilePath, newFilePath);
                Console.WriteLine($"Datei umbenannt: {Path.GetFileName(currentFilePath)} -> {newFileName}");

                Console.WriteLine("Alle Präfixe wurden erfolgreich geändert.");
            }
        }

        public static void ChangeSuffix(List<string> files, string newSuffix, string directoryPath)
        {
            foreach (var file in files)
            {
                string currentFilePath = file;
                string currentFileName = Path.GetFileNameWithoutExtension(currentFilePath);
                string newFilePath = Path.Combine(directoryPath, currentFileName + newSuffix);

                System.IO.File.Move(currentFilePath, newFilePath);
                Console.WriteLine($"Datei umbenannt: {Path.GetFileName(currentFilePath)} -> {Path.GetFileName(newFilePath)}");
            }

            Console.WriteLine("Alle Suffixe wurden erfolgreich geändert.");
        }
    }
}
