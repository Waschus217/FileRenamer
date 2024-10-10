using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using renamerIdee.Interfaces;

namespace renamerIdee {
    class Matcher {
        public static void Main(string[] args)
        {
            int RUN_DEBUG = 1;

            if (RUN_DEBUG == 1)
            {
                RunTests();
                Console.ReadKey();
                return;
            }

            //
            // work on matcher...
            //

            Console.WriteLine("ToDo: current work on matcher...");
            Console.ReadKey();
        }

        static void RunTests() {
            Console.WriteLine("Run All Matcher Tests");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("All tests succeeded!");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("----------------------------");
            Console.WriteLine("RUNNING NOW FILE RENAMER...");
            Console.WriteLine("----------------------------");

            var fileMover = new FileMover();
            Algorithmus algorithmus = new Algorithmus(fileMover);
            algorithmus.AlgorithmRenamePictureFiles();
        }
    }
}
