using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace renamerIdee {
    class Matcher {
        static string VERSION = "V1.0";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldName">old pattern</param>
        /// <param name="newName">new pattern</param>
        /// <param name="files">List of filenames</param>
        /// <returns>List of changed filenames</returns>
        public static List<string> matcher(string oldName, string newName, List<string> files) {
            //ToDo: Do the magic here...
            return files;
        }

        static void runTests() {
            Console.WriteLine("Run All Matcher Tests");
            string oldP ="", newP= "", res="";
            string[] files1 = {"clipboard01.jpg", "clipboard02.jpg", "clipboard03.jpg",
                               "clipboard01.gif", "img01.jpg", "img-abc.jpg" };

            oldP = "clipboard01.jpg";
            newP = "clipboard01.jpg";
            res = "clipboard01.jpg clipboard02.jpg clipboard03.jpg clipboard01.gif img01.jpg img-abc.jpg";
            test(files1, oldP, newP, res);
            
            /*
            oldP = "clipboard01.jpg";
            newP = "aaa-clipboard01.jpg";
            res = "aaa-01.jpg aaa-02.jpg aaa-03.jpg aaa-clipboard01.gif aaa-img01.jpg aaa-img-abc.jpg";
            test(files1, oldP, newP, res);
            */

            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("All tests succeeded!");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ReadKey();

        }

        private static void test(string[] files, string oldName, string newName, string testRes = null) {
            Console.WriteLine($"oldName:{oldName} newName: {newName}");
            List<string> res = matcher(oldName, newName, new List<string>(files));
            string resS = string.Join(" ", res);
            Console.WriteLine("Old:" + string.Join(" ", new List<string>(files)));
            Console.WriteLine("New:" + resS);
            Console.WriteLine("--------------------------------------------------");
            if (testRes != null && resS != testRes) {
                throw new Exception("Test failed: expected:" + testRes + " received:" + resS);
            }
        }


        public static void Main(string[] args) {
            int RUN_DEBUG = 1;

            if (RUN_DEBUG == 1) {
                runTests();
                Console.ReadKey();
                return;
            }

            //
            // work on matcher...
            //

            Console.WriteLine("ToDo: current work on matcher...");
            Console.ReadKey();
        }

    }
}
