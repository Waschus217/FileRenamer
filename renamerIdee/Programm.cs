namespace renamerIdee
{
    class Programm
    {
        public static void Main(string[] args)
        {
            var fileMover = new FileMover();
            Algorithmus algorithmus = new Algorithmus(fileMover);
            algorithmus.AlgorithmRenamePictureFiles();
        }
    }
}
