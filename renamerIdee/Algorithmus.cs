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
            Console.Write("Pfad: ");
            string pathInput = Console.ReadLine();
            string directoryPath = $@"{pathInput}";
            Console.WriteLine("\nAuswahlmöglichkeiten:");
            Console.WriteLine("(1) Präfixe ändern");
            Console.WriteLine("(2) Präfixe löschen");
            Console.WriteLine("(3) Suffixe ändern");
            Console.WriteLine("(4) Suffix löschen");
            Console.WriteLine("(5) Teilausdrücke ändern");
            Console.Write("Deine Wahl: ");
            int choiceOption = Convert.ToInt32(Console.ReadLine());
            string[] fileExtensions = new string[] { "*.*" };
            

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
                        Console.Write("\nNeuer File Name: ");
                        string newFileNamePattern = Console.ReadLine();
                        ChangePrefix(files, newFileNamePattern, directoryPath);
                        break;
                    case 2:
                        RemovePrefix(files, directoryPath);
                        break;
                    case 3:
                        Console.Write("\nGib das neue Suffix ein: ");
                        string newSuffix = Console.ReadLine();
                        ChangeSuffix(files, newSuffix, directoryPath);
                        break;
                    case 4:
                        RemoveSuffix(files, directoryPath);
                        break;
                    case 5:
                        Console.Write("\nGib den Teilausdruck ein, den du ändern möchtest: ");
                        string oldSubstring = Console.ReadLine();
                        Console.Write("Gib den neuen Teilausdruck ein: ");
                        string newSubstring = Console.ReadLine();
                        ChangePartialExpression(files, oldSubstring, newSubstring, directoryPath);
                        break;
                    default:
                        Console.WriteLine("\n!!!Ungültige Eingabe!!!");
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
            }
            
            Console.WriteLine("\nAlle Präfixe wurden erfolgreich geändert.");
        }

        public static void RemovePrefix(List<string> files, string directoryPath)
        {
            foreach (var file in files)
            {
                string currentFilePath = file;
                string currentFileName = Path.GetFileNameWithoutExtension(currentFilePath);
                string extension = Path.GetExtension(currentFilePath);

                int indexOfDash = currentFileName.IndexOf('-');
                string newFileName;

                if (indexOfDash != -1)
                {
                    newFileName = currentFileName.Substring(indexOfDash + 1) + extension;
                }
                else
                {
                    newFileName = currentFileName + extension;
                }

                string newFilePath = Path.Combine(directoryPath, newFileName);

                if (newFileName != Path.GetFileName(currentFilePath))
                {
                    System.IO.File.Move(currentFilePath, newFilePath);
                    Console.WriteLine($"Präfix entfernt: {Path.GetFileName(currentFilePath)} -> {newFileName}");
                }
            }

            Console.WriteLine("\nAlle Präfixe wurden erfolgreich entfernt.");
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

            Console.WriteLine("\nAlle Suffixe wurden erfolgreich geändert.");
        }

        public static void RemoveSuffix(List<string> files, string directoryPath)
        {
            foreach (var file in files)
            {
                string currentFilePath = file;
                string currentFileName = Path.GetFileNameWithoutExtension(currentFilePath);

                string newFilePath = Path.Combine(directoryPath, currentFileName);

                if (currentFileName + Path.GetExtension(currentFilePath) != currentFileName)
                {
                    System.IO.File.Move(currentFilePath, newFilePath);
                    Console.WriteLine($"Suffix entfernt: {Path.GetFileName(currentFilePath)} -> {Path.GetFileName(newFilePath)}");
                }
            }

            Console.WriteLine("\nAlle Suffixe wurden erfolgreich entfernt.");
        }

        public static void ChangePartialExpression(List<string> files, string oldSubstring, string newSubstring, string directoryPath)
        {
            foreach (var file in files)
            {
                string currentFilePath = file;
                string currentFileName = Path.GetFileNameWithoutExtension(currentFilePath);
                string extension = Path.GetExtension(currentFilePath);

                string newFileName = currentFileName.Replace(oldSubstring, newSubstring) + extension;
                string newFilePath = Path.Combine(directoryPath, newFileName);

                if (newFileName != Path.GetFileName(currentFilePath))
                {
                    System.IO.File.Move(currentFilePath, newFilePath);
                    Console.WriteLine($"Datei umbenannt: {Path.GetFileName(currentFilePath)} -> {newFileName}");
                }
            }

            Console.WriteLine("\nAlle Teilausdrücke wurden erfolgreich geändert.");
        }
    }
}
