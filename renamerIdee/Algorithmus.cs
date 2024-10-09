using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace renamerIdee
{
    class Algorithmus
    {
        public static void AlgorithmRenamePictureFiles()
        {
            Console.WriteLine("Auswahlmöglichkeiten:");
            Console.WriteLine("(1) Präfix ändern");
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
                        for (int i = 0; i < files.Count; i++)
                        {
                            string currentFilePath = files[i];
                            string extension = Path.GetExtension(currentFilePath);
                            string newFileName = $"{(i + 1):D3}-{newFileNamePattern}{extension}";
                            string newFilePath = Path.Combine(directoryPath, newFileName);

                            File.Move(currentFilePath, newFilePath);
                            Console.WriteLine($"Datei umbenannt: {Path.GetFileName(currentFilePath)} -> {newFileName}");
                        }

                        break;

                    default: 
                        break;
                }

                Console.WriteLine("Alle Dateien wurden erfolgreich umbenannt.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ein Fehler ist aufgetreten: {ex.Message}");
            }
        }
    }
}
