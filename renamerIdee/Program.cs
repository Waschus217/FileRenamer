using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace renamerIdee {
    class Program {
        static void Main1(string[] args) {
            int RUN_DEBUG = 1;

            if (RUN_DEBUG == 1) {
                Console.WriteLine("Run All Tests");
                Console.WriteLine("ToDo: Tests with real files in directories...");
                //runTests(); 
                Console.ReadKey();
                return;
            }

            if (RUN_DEBUG == 2) {
                Console.WriteLine("Run Matcher Main Method");
                //Matcher.Main1(null);
                Console.ReadKey();
                return;
            }


            //
            //run real renamer 
            //
            //...
            Console.WriteLine("ToDo: running renamer...");
            Console.ReadKey();
        }
    }
}
