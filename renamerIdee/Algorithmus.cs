using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace renamerIdee
{
    public class Algorithmus
    {
        public static void AlgorithmRenamePictureFiles()
        {
            bool loopChoice;

            do
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
                Console.WriteLine("(6) Zahlenblock verschieben");
                Console.WriteLine("(7) Führende Nullen einfügen");
                Console.WriteLine("(8) Führende Nullen löschen");
                Console.WriteLine("(9) Zahlenblock einfügen");
                Console.WriteLine("(10) Zahlenblock löschen");
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
                        Console.WriteLine("\nKeine Dateien im angegebenen Ordner gefunden.");
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
                        case 6:
                            ShiftNumberBlock(files, directoryPath);
                            break;
                        case 7:
                            Console.Write("\nGesamtzahl der Ziffern: ");
                            int totalLength = Convert.ToInt32(Console.ReadLine());
                            AddLeadingZeros(files, totalLength, directoryPath);
                            break;
                        case 8:
                            RemoveLeadingZeros(files, directoryPath);
                            break;
                        case 9:
                            Console.Write("\nGib den Zahlenblock ein, den du hinzufügen möchtest (z.B. 123): ");
                            int numberBlockToAdd = Convert.ToInt32(Console.ReadLine());
                            AddNumberBlock(files, numberBlockToAdd, directoryPath);
                            break;
                        case 10:
                            RemoveNumberBlock(files, directoryPath);
                            break;
                        default:
                            Console.WriteLine("\n!!!Ungültige Eingabe!!!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nEin Fehler ist aufgetreten: {ex.Message}");
                }

                Console.Write("\nAndere Rename Option? Ja(1)/Nein(2): ");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    loopChoice = true;
                }
                else if (choice == 2)
                {
                    loopChoice = false;
                }
                else
                {
                    Console.WriteLine("\nUngültige Auswahl. Programm wird beendet.");
                    loopChoice = false;
                }
            } while (loopChoice == true);
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

        public static void ShiftNumberBlock(List<string> files, string directoryPath)
        {
            foreach (var file in files)
            {
                string currentFilePath = file;
                string currentFileName = Path.GetFileNameWithoutExtension(currentFilePath);
                string extension = Path.GetExtension(currentFilePath);

                string[] parts = currentFileName.Split('-');

                if (parts.Length > 0 && int.TryParse(parts[^1], out int numberBlock))
                {
                    string newFileName = $"{numberBlock:D3}-" + string.Join("-", parts, 0, parts.Length - 1) + extension;
                    string newFilePath = Path.Combine(directoryPath, newFileName);

                    System.IO.File.Move(currentFilePath, newFilePath);
                    Console.WriteLine($"Zahlenblock verschoben: {Path.GetFileName(currentFilePath)} -> {newFileName}");
                }
                else if (parts.Length > 0 && int.TryParse(parts[0], out numberBlock))
                {
                    string newFileName = $"{string.Join("-", parts, 1, parts.Length - 1)}-{numberBlock:D3}{extension}";
                    string newFilePath = Path.Combine(directoryPath, newFileName);

                    System.IO.File.Move(currentFilePath, newFilePath);
                    Console.WriteLine($"Zahlenblock verschoben: {Path.GetFileName(currentFilePath)} -> {newFileName}");
                }
            }

            Console.WriteLine("\nAlle Zahlenblöcke wurden erfolgreich verschoben.");
        }

        public static void AddLeadingZeros(List<string> files, int totalLength, string directoryPath)
        {
            foreach (var file in files)
            {
                string currentFilePath = file;
                string currentFileName = Path.GetFileNameWithoutExtension(currentFilePath);
                string extension = Path.GetExtension(currentFilePath);

                string[] parts = currentFileName.Split('-');

                if (parts.Length > 0 && int.TryParse(parts[^1], out int numberBlock))
                {
                    string newNumberBlock = numberBlock.ToString().PadLeft(totalLength, '0');
                    string newFileName = $"{string.Join("-", parts, 0, parts.Length - 1)}-{newNumberBlock}{extension}";
                    string newFilePath = Path.Combine(directoryPath, newFileName);

                    if (newFileName != Path.GetFileName(currentFilePath))
                    {
                        System.IO.File.Move(currentFilePath, newFilePath);
                        Console.WriteLine($"Führende Nullen hinzugefügt: {Path.GetFileName(currentFilePath)} -> {newFileName}");
                    }
                }
                else if (parts.Length > 0 && int.TryParse(parts[0], out numberBlock))
                {
                    string newNumberBlock = numberBlock.ToString().PadLeft(totalLength, '0');
                    string newFileName = $"{newNumberBlock}-{string.Join("-", parts, 1, parts.Length - 1)}{extension}";
                    string newFilePath = Path.Combine(directoryPath, newFileName);

                    if (newFileName != Path.GetFileName(currentFilePath))
                    {
                        System.IO.File.Move(currentFilePath, newFilePath);
                        Console.WriteLine($"Führende Nullen hinzugefügt: {Path.GetFileName(currentFilePath)} -> {newFileName}");
                    }
                }
            }

            Console.WriteLine("\nFührende Nullen wurden erfolgreich hinzugefügt.");
        }

        public static void RemoveLeadingZeros(List<string> files, string directoryPath)
        {
            foreach (var file in files)
            {
                string currentFilePath = file;
                string currentFileName = Path.GetFileNameWithoutExtension(currentFilePath);
                string extension = Path.GetExtension(currentFilePath);

                string[] parts = currentFileName.Split('-');

                if (parts.Length > 0 && int.TryParse(parts[^1], out int numberBlock))
                {
                    string newNumberBlock = numberBlock.ToString();
                    string newFileName = $"{string.Join("-", parts, 0, parts.Length - 1)}-{newNumberBlock}{extension}";
                    string newFilePath = Path.Combine(directoryPath, newFileName);

                    if (newFileName != Path.GetFileName(currentFilePath))
                    {
                        System.IO.File.Move(currentFilePath, newFilePath);
                        Console.WriteLine($"Führende Nullen entfernt: {Path.GetFileName(currentFilePath)} -> {newFileName}");
                    }
                }
                else if (parts.Length > 0 && int.TryParse(parts[0], out numberBlock))
                {
                    string newNumberBlock = numberBlock.ToString();
                    string newFileName = $"{newNumberBlock}-{string.Join("-", parts, 1, parts.Length - 1)}{extension}";
                    string newFilePath = Path.Combine(directoryPath, newFileName);

                    if (newFileName != Path.GetFileName(currentFilePath))
                    {
                        System.IO.File.Move(currentFilePath, newFilePath);
                        Console.WriteLine($"Führende Nullen entfernt: {Path.GetFileName(currentFilePath)} -> {newFileName}");
                    }
                }
            }

            Console.WriteLine("\nFührende Nullen wurden erfolgreich entfernt.");
        }

        public static void AddNumberBlock(List<string> files, int numberBlock, string directoryPath)
        {
            foreach (var file in files)
            {
                string currentFilePath = file;
                string currentFileName = Path.GetFileNameWithoutExtension(currentFilePath);
                string extension = Path.GetExtension(currentFilePath);

                string newFileName = $"{currentFileName}-{numberBlock:D3}{extension}";
                string newFilePath = Path.Combine(directoryPath, newFileName);

                if (newFileName != Path.GetFileName(currentFilePath))
                {
                    System.IO.File.Move(currentFilePath, newFilePath);
                    Console.WriteLine($"Zahlenblock hinzugefügt: {Path.GetFileName(currentFilePath)} -> {newFileName}");
                }
            }

            Console.WriteLine("\nZahlenblock wurde erfolgreich hinzugefügt.");
        }

        public static void RemoveNumberBlock(List<string> files, string directoryPath)
        {
            foreach (var file in files)
            {
                string currentFilePath = file;
                string currentFileName = Path.GetFileNameWithoutExtension(currentFilePath);
                string extension = Path.GetExtension(currentFilePath);

                string[] parts = currentFileName.Split('-');

                if (parts.Length > 1 && int.TryParse(parts[^1], out int numberBlock))
                {
                    string newFileName = string.Join("-", parts, 0, parts.Length - 1) + extension;
                    string newFilePath = Path.Combine(directoryPath, newFileName);

                    if (newFileName != Path.GetFileName(currentFilePath))
                    {
                        System.IO.File.Move(currentFilePath, newFilePath);
                        Console.WriteLine($"Zahlenblock entfernt: {Path.GetFileName(currentFilePath)} -> {newFileName}");
                    }
                }
            }

            Console.WriteLine("\nZahlenblöcke wurden erfolgreich entfernt.");
        }
    }
}
