using renamerIdee.Interfaces;
using System.IO;

namespace renamerIdee
{
    public class FileMover : IFileMover
    {
        public void Move(string sourcePath, string destinationPath)
        {
            File.Move(sourcePath, destinationPath);
        }
    }
}
