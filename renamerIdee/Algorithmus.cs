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
        public static void algorithmRenamePictureFiles()
        {
            Console.Write("Pfad: ");
            string pathInput = Console.ReadLine();
            string directoryPath = $@"{pathInput}"; // Bevor ihr den FileRenamer ausführt eure Bilder in einem Ordner tun und Pfad ändern.
            string[] fileExtensions = new string[] { "*.jpg", "*.png", "*.gif" };
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

                for (int i = 0; i < files.Count; i++)
                {
                    string currentFilePath = files[i];
                    string extension = Path.GetExtension(currentFilePath);
                    string newFileName = $"{(i + 1):D3}-{newFileNamePattern}{extension}";
                    string newFilePath = Path.Combine(directoryPath, newFileName);

                    File.Move(currentFilePath, newFilePath);
                    Console.WriteLine($"Datei umbenannt: {Path.GetFileName(currentFilePath)} -> {newFileName}");
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
