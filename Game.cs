using System;
using System.Collections.Generic;

namespace Dojo_Beast_Brawl {
    class Game {
        public List<Player> players = new List<Player>(); // maybe an array...
        public int currentPlayer = 0;

        public bool continueGame = true;

        public Game() {
            Console.WriteLine("****************************");
            Console.WriteLine("Welcome to Dojo Beast Brawl!");
            Console.WriteLine("              n__n_    ");
            Console.WriteLine("             /  = =\   ");
            Console.WriteLine("            /   ._Y_)   ");
            Console.WriteLine("___________/      "\______");
            Console.WriteLine("          (_/  (_,  \       ");
            Console.WriteLine("            \      ( \_,--""""--. ");
            Console.WriteLine("      __..-,-`.___,-` )-.______.' ");
            Console.WriteLine("    <'     `-,'   `-, )-'    >      ");
            Console.WriteLine("     `----._/      ( /"`>.--"           ");
            Console.WriteLine("            "--..___,--"                 ");
            Console.WriteLine("****************************");

            // players.Add(new Player());
        }

        public bool update() {

            // FUNCTION CALL FOR EACH PHASE...
            // 1) update current player...
            nextPlayerTurn();
            // 2) persent player with action menu (atk, skip, quit?)
            string caseSwitch = renderPlayerMenu();
            // eval userinput from menu
            switch (caseSwitch) {
                case "1":
                    Console.WriteLine("Case 1");
                    return true;
                    // break;
                case "2":
                    Console.WriteLine("Case 2");
                    return true;
                    // break;
                case "3":
                    Console.WriteLine("Case 3");
                    return false;
                    // break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
            Console.WriteLine("I hit default case... not sure why...");
            return false;
            // 3) if atk ask other player who they wish to defend with (choose one or skip)
            // 4) eval combat...
            // 5) check for winning state...
            // 7) finish turn...
            
        }

        public void nextPlayerTurn() {
            Console.WriteLine("I want to switch to next player in list...");
        }

        public string renderPlayerMenu() {
            bool validInput = false;
            string InputLine = "3"; // set to quit by default just in case...
            while(!validInput){
                Console.WriteLine("Choose your action (1) attack your opponent. (2) skip your turn. (3) quit the game. :");
                InputLine = Console.ReadLine();
                if(InputLine == "1" || InputLine == "2" || InputLine == "3") {
                    validInput = true;
                    
                }
            }

            return InputLine;
            
        }

        public bool askContinue() {
            Console.WriteLine("Would you like to continue (y/n):");
            string InputLine = Console.ReadLine();

            if(InputLine == "n") {
                continueGame = false;
            }
            return continueGame;
        }

        // public Player createPlayer() {

        //     Console.WriteLine("Would you like to continue (y/n):");
        //     string InputLine = Console.ReadLine();
        // }

    }
}