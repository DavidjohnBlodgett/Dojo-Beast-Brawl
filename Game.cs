using System;
using System.Collections.Generic;

namespace Dojo_Beast_Brawl {
    class Game {
        public List<Player> players = new List<Player>(); // maybe an array...
        public int currentPlayer = 0;

        public Game() {
            Console.WriteLine("****************************");
            Console.WriteLine("Welcome to Dojo Beast Brawl!");
            Console.WriteLine("        (╯°□°）╯︵ ┻━┻");
            Console.WriteLine("****************************");

            // players.Add(new Player());
        }

        // public Player createPlayer() {

        //     Console.WriteLine("Would you like to continue (y/n):");
        //     string InputLine = Console.ReadLine();
        // }

    }
}