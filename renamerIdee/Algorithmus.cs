using renamerIdee.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace renamerIdee
{
    public class Algorithmus
    {
        private readonly IFileMover _fileMover;
        int foundNumbers;
        string newFileName, newFilePath;
        bool verfiy, loopChoice, endingLoopChoice;
        InputValidation validation = new InputValidation();

        public Algorithmus(IFileMover fileMover)
        {
            _fileMover = fileMover;
            this.validation = new InputValidation();
        }

        public void AlgorithmRenamePictureFiles()
        {
            do
            {
                Console.Write("Geben Sie den Ordnerpfad ein: ");
                string pathInput = Console.ReadLine();
                bool existingDirectory = Directory.Exists(pathInput);

                do
                {
                    if (existingDirectory == true)
                    {
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
                        Console.WriteLine("(10) Zahlenblock löschen\n");

                        int choiceOption = validation.GetValidInputOneToTen("Deine Wahl: ");
                        string[] fileExtensions = new string[] { "*.jpg", "*.jpeg", "*.png", "*.gif", "*.bmp", "*.tiff", "*.webp", "*.svg" };
                        bool loop = false;

                        try
                        {
                            List<string> files = new List<string>();
                            foreach (var fileExtension in fileExtensions)
                            {
                                files.AddRange(Directory.GetFiles(directoryPath, fileExtension));
                            }

                            switch (choiceOption)
                            {
                                case 1:
                                    string newFileNamePattern = validation.GetValidInputNullOrEmpty("\nNeuer Datei Name: ");
                                    ChangePrefix(files, newFileNamePattern, directoryPath);
                                    break;
                                case 2:
                                    RemovePrefix(files, directoryPath);
                                    break;
                                case 3:
                                    string newSuffix = validation.GetValidInputNullOrEmpty("\nGib das neue Suffix ein: ");
                                    ChangeSuffix(files, newSuffix, directoryPath);
                                    break;
                                case 4:
                                    RemoveSuffix(files, directoryPath);
                                    break;
                                case 5:
                                    string oldSubstring = validation.GetValidInputNullOrEmpty("\nGib den Teilausdruck ein, den du ändern möchtest: ");
                                    string newSubstring = validation.GetValidInputNullOrEmpty("Gib den neuen Teilausdruck ein: ");
                                    ChangePartialExpression(files, oldSubstring, newSubstring, directoryPath);
                                    break;
                                case 6:
                                    ShiftNumberBlock(files, directoryPath);
                                    break;
                                case 7:
                                    int totalLength;
                                    string totalLengthInput;

                                    do
                                    {
                                        totalLengthInput = validation.GetValidInputNullOrEmpty("\nGesamtzahl der Ziffern: ");
                                    } while (!int.TryParse(totalLengthInput, out totalLength));

                                    AddLeadingZeros(files, totalLength, directoryPath);
                                    break;
                                case 8:
                                    RemoveLeadingZeros(files, directoryPath);
                                    break;
                                case 9:
                                    int numberBlockToAdd;
                                    string numberBlockToAddInput;

                                    do
                                    {
                                        numberBlockToAddInput = validation.GetValidInputNullOrEmpty("\nGib den Zahlenblock ein, den du hinzufügen möchtest: ");
                                    } while (!int.TryParse(numberBlockToAddInput, out numberBlockToAdd));

                                    int numberBlockPosition = validation.GetValidInputOneOrTwo("\nMöchtest du den Zahlenblock vorne (1) oder hinten (2): ");

                                    AddNumberBlock(files, numberBlockToAdd, numberBlockPosition, directoryPath);
                                    break;
                                case 10:
                                    RemoveNumberBlock(files, directoryPath);
                                    break;
                                default:
                                    Console.WriteLine("\n!!!Ungültige Eingabe!!!");
                                    break;
                            }

                            loop = true;
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"\nEin Fehler ist aufgetreten: {ex.Message}");
                            Console.ForegroundColor= ConsoleColor.White;
                            Console.ReadKey();
                        }
                        if (loop == true)
                        {
                            int choice = validation.GetValidInputOneOrTwo("\nAndere Umbenennungs Option? Ja(1)/Nein(2): ");

                            if (choice == 1)
                            {
                                loopChoice = true;
                            }
                            else
                            {
                                loopChoice = false;
                            }
                        }
                        else
                        {
                            loopChoice = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nDer Ausgewählte Dateipfad existiert nicht!");
                        int endingChoice = validation.GetValidInputOneOrTwo("Klicke (1) um fortzufahren und es erneut zu versuchen oder (2) um die Anwendung zu beenden: ");

                        if (endingChoice == 1)
                        {
                            endingLoopChoice = true;
                        }
                        else
                        {
                            endingLoopChoice = false;
                        }
                    }
                } while (loopChoice == true);
            } while (endingLoopChoice == true);
        }

        public void ChangePrefix(List<string> files, string newFileNamePattern, string directoryPath)
        {
            for (int i = 0; i < files.Count; i++)
            {
                string currentFilePath = files[i];
                string extension = Path.GetExtension(currentFilePath);
                string newFileName = $"{newFileNamePattern}{i + 1}{extension}";
                string newFilePath = Path.Combine(directoryPath, newFileName);

                if (newFileName != Path.GetFileName(currentFilePath))
                {
                    _fileMover.Move(currentFilePath, newFilePath);
                    Console.WriteLine($"Datei umbenannt: {Path.GetFileName(currentFilePath)} -> {newFileName}");
                }
            }
            
            Console.WriteLine("\nAlle Präfixe wurden erfolgreich geändert.");
        }

        public void RemovePrefix(List<string> files, string directoryPath)
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
                    _fileMover.Move(currentFilePath, newFilePath);
                    Console.WriteLine($"Präfix entfernt: {Path.GetFileName(currentFilePath)} -> {newFileName}");
                }
            }

            Console.WriteLine("\nAlle Präfixe wurden erfolgreich entfernt.");
        }

        public void ChangeSuffix(List<string> files, string newSuffix, string directoryPath)
        {
            foreach (var file in files)
            {
                string currentFilePath = file;
                string currentFileName = Path.GetFileNameWithoutExtension(currentFilePath);
                string newFileName = $"{currentFileName}{newSuffix}";
                string newFilePath = Path.Combine(directoryPath, currentFileName + newSuffix);

                if (newFileName != Path.GetFileName(currentFilePath))
                {
                    _fileMover.Move(currentFilePath, newFilePath);
                    Console.WriteLine($"Datei umbenannt: {Path.GetFileName(currentFilePath)} -> {Path.GetFileName(newFilePath)}");
                }
            }

            Console.WriteLine("\nAlle Suffixe wurden erfolgreich geändert.");
        }

        public void RemoveSuffix(List<string> files, string directoryPath)
        {
            foreach (var file in files)
            {
                string currentFilePath = file;
                string currentFileName = Path.GetFileNameWithoutExtension(currentFilePath);

                string newFilePath = Path.Combine(directoryPath, currentFileName);

                if (currentFileName + Path.GetExtension(currentFilePath) != currentFileName)
                {
                    _fileMover.Move(currentFilePath, newFilePath);
                    Console.WriteLine($"Suffix entfernt: {Path.GetFileName(currentFilePath)} -> {Path.GetFileName(newFilePath)}");
                }
            }

            Console.WriteLine("\nAlle Suffixe wurden erfolgreich entfernt.");
        }

        public void ChangePartialExpression(List<string> files, string oldSubstring, string newSubstring, string directoryPath)
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
                    _fileMover.Move(currentFilePath, newFilePath);
                    Console.WriteLine($"Datei umbenannt: {Path.GetFileName(currentFilePath)} -> {newFileName}");
                }
            }

            Console.WriteLine("\nAlle Teilausdrücke wurden erfolgreich geändert.");
        }

        public void ShiftNumberBlock(List<string> files, string directoryPath)
        {
            foreach (var file in files)
            {
                string currentFilePath = file;
                string currentFileName = Path.GetFileNameWithoutExtension(currentFilePath);
                string extension = Path.GetExtension(currentFilePath);

                string[] parts = currentFileName.Split('-');

                if (parts.Length > 0 && int.TryParse(parts[^1], out int numberBlock))
                {
                    string newFileName = $"{numberBlock}-" + string.Join("-", parts, 0, parts.Length - 1) + extension;
                    string newFilePath = Path.Combine(directoryPath, newFileName);

                    if (newFileName != Path.GetFileName(currentFilePath))
                    {
                        _fileMover.Move(currentFilePath, newFilePath);
                        Console.WriteLine($"Zahlenblock verschoben: {Path.GetFileName(currentFilePath)} -> {newFileName}");
                    }
                }
                else if (parts.Length > 0 && int.TryParse(parts[0], out numberBlock))
                {
                    string newFileName = $"{string.Join("-", parts, 1, parts.Length - 1)}-{numberBlock}{extension}";
                    string newFilePath = Path.Combine(directoryPath, newFileName);

                    if (newFileName != Path.GetFileName(currentFilePath))
                    {
                        _fileMover.Move(currentFilePath, newFilePath);
                        Console.WriteLine($"Zahlenblock verschoben: {Path.GetFileName(currentFilePath)} -> {newFileName}");
                    }
                }
            }

            Console.WriteLine("\nAlle Zahlenblöcke wurden erfolgreich verschoben.");
        }

        public void AddLeadingZeros(List<string> files, int totalLength, string directoryPath)
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
                        _fileMover.Move(currentFilePath, newFilePath);
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
                        _fileMover.Move(currentFilePath, newFilePath);
                        Console.WriteLine($"Führende Nullen hinzugefügt: {Path.GetFileName(currentFilePath)} -> {newFileName}");
                    }
                }
            }

            Console.WriteLine("\nFührende Nullen wurden erfolgreich hinzugefügt.");
        }

        public void RemoveLeadingZeros(List<string> files, string directoryPath)
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
                        _fileMover.Move(currentFilePath, newFilePath);
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
                        _fileMover.Move(currentFilePath, newFilePath);
                        Console.WriteLine($"Führende Nullen entfernt: {Path.GetFileName(currentFilePath)} -> {newFileName}");
                    }
                }
            }

            Console.WriteLine("\nFührende Nullen wurden erfolgreich entfernt.");
        }

        public void AddNumberBlock(List<string> files, int numberBlock, int numberBlockPosition, string directoryPath)
        {
            foreach (var file in files)
            {
                string currentFilePath = file;
                string currentFileName = Path.GetFileNameWithoutExtension(currentFilePath);
                string extension = Path.GetExtension(currentFilePath);

                string pattern = @"\d+";
                Match match = Regex.Match(currentFileName, pattern);

                if (match.Success)
                {
                    foundNumbers = Convert.ToInt32(match.Value);
                    verfiy = Convert.ToInt32(foundNumbers) != numberBlock;
                }
                else
                {
                    verfiy = true;
                }

                if (numberBlockPosition == 1 && verfiy)
                {
                    newFileName = $"{numberBlock}-{currentFileName}{extension}";
                    newFilePath = Path.Combine(directoryPath, newFileName);
                }
                else if (numberBlockPosition == 2 && verfiy)
                {
                    newFileName = $"{currentFileName}-{numberBlock}{extension}";
                    newFilePath = Path.Combine(directoryPath, newFileName);
                }

                if (newFileName != Path.GetFileName(currentFilePath) && !String.IsNullOrEmpty(newFileName))
                {
                    _fileMover.Move(currentFilePath, newFilePath);
                    Console.WriteLine($"Zahlenblock hinzugefügt: {Path.GetFileName(currentFilePath)} -> {newFileName}");
                }
            }

            Console.WriteLine("\nZahlenblock wurde erfolgreich hinzugefügt.");
        }

        public void RemoveNumberBlock(List<string> files, string directoryPath)
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
                        _fileMover.Move(currentFilePath, newFilePath);
                        Console.WriteLine($"Zahlenblock entfernt: {Path.GetFileName(currentFilePath)} -> {newFileName}");
                    }
                }
                else if (parts.Length > 0 && int.TryParse(parts[0], out numberBlock))
                {
                    string newFileName = string.Join("-", parts, 1, parts.Length - 1) + extension;
                    string newFilePath = Path.Combine(directoryPath, newFileName);

                    if (newFileName != Path.GetFileName(currentFilePath))
                    {
                        _fileMover.Move(currentFilePath, newFilePath);
                        Console.WriteLine($"Zahlenblock entfernt: {Path.GetFileName(currentFilePath)} -> {newFileName}");
                    }
                }
            }

            Console.WriteLine("\nZahlenblöcke wurden erfolgreich entfernt.");
        }
    }
}
