using System;

namespace renamerIdee
{
    class Programm
    {
        public static void Main(string[] args)
        {
            var fileMover = new FileMover();
            Algorithmus algorithmus = new Algorithmus(fileMover);
            StartingPage startingPage = new StartingPage();

            startingPage.StartSign();
            int helpDecision = startingPage.StartInformation();

            bool endLoop = false;

            do
            {
                if (helpDecision == 1)
                {
                    startingPage.HelpScreen();
                    helpDecision = 2;
                    endLoop = true;
                    Console.Clear();
                }
                else if (helpDecision == 2)
                {
                    Console.Clear();
                    algorithmus.AlgorithmRenamePictureFiles();
                    endLoop = false;
                }
            } while (endLoop);

            startingPage.EndSign();
            Console.ReadKey();
        }
    }
}
