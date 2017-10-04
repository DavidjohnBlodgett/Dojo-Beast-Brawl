using System;

namespace Dojo_Beast_Brawl
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            bool continueGame = true;
            while(continueGame) {
                Console.WriteLine("Would you like to continue (y/n):");
                string InputLine = Console.ReadLine();

                if(InputLine == "n") {
                    continueGame = false;
                }
            }

        }
    }
}
