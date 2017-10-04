using System;

namespace Dojo_Beast_Brawl
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            bool continueGame = true;
            Game currentGame = new Game();

            while(continueGame) {
                continueGame = currentGame.update();
            }

        }
    }
}
