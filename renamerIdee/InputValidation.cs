using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace renamerIdee
{
    public class InputValidation
    {

        bool validInputOneOrTwo, validInputOneToTen;

        public string GetValidInputNullOrEmpty(string message)
        {
            string input;

            do
            {
                Console.Write(message);
                input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Ungültige Eingabe!\n");
                }
            } while (string.IsNullOrEmpty(input));

            return input;
        }

        public int GetValidInputOneOrTwo(string message)
        {
            string input;
            int number;

            do
            {
                Console.Write(message);
                input = Console.ReadLine();

                if (int.TryParse(input, out number) && (number == 1 || number == 2))
                {
                    validInputOneOrTwo = true;
                }
                else
                {
                    Console.WriteLine("Ungültige Eingabe!\n");
                }
            } while (!validInputOneOrTwo);

            return number;
        }

        public int GetValidInputOneToTen(string message)
        {
            string input;
            int number;

            do
            {
                Console.Write(message);
                input = Console.ReadLine();

                if (int.TryParse(input, out number) && (number >= 1 || number <= 10))
                {
                    validInputOneToTen = true;
                }
                else
                {
                    Console.WriteLine("Ungültige Eingabe!\n");
                }
            } while (!validInputOneToTen);

            return number;
        }
    }
}
