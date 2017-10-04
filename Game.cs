using System;
using System.Collections.Generic;

namespace Dojo_Beast_Brawl {
    class Game {
        public List<Player> players = new List<Player>(); // maybe an array...
        public int currentPlayer = 0;

        public Deck deck = new Deck();

        public bool continueGame = true;

        public Game() {
            
            // RENDER SPLASH SCREEN AT START...
            renderSplashScreen();

            // MAKE 2 PLAYERS...
            createPlayers();
        }

        // LOGIC FUNCTIONS...

        public bool update() {

            string caseSwitch = renderPlayerMenu();

            // eval userinput from menu
            switch (caseSwitch) {
                case "1":
                    Console.WriteLine("\n++++ {0}'s Attack Phase!!!! ++++\n", players[currentPlayer].name);
                    continueGame = resolveAttackPhase();
                    return continueGame;
                    // break;
                case "2":
                    Console.WriteLine("");
                    continueGame = true;
                    return continueGame;
                    // break;
                case "3":
                    Console.WriteLine("\n\nGoodbye!\n\n");
                    continueGame = false;
                    return continueGame;
                    // break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
            Console.WriteLine("I hit default case... not sure why...");
            return false;
            
        }

        public void nextPlayerTurn() {
            if(currentPlayer == 1) {
                currentPlayer = 0;
            } else {
                currentPlayer = 1;
            }
        }


        // RENDER FUNCTIONS...
        public string renderPlayerMenu() {

            Console.Clear();

            players[currentPlayer].draw(deck);

            bool validInput = false;
            string InputLine = "3"; // set to quit by default just in case...
            int count = 1;

            Console.WriteLine("\n*****************************");
            Console.WriteLine("     Player {0} current hand:", players[currentPlayer].name);
            Console.WriteLine("*****************************");

            foreach(var item in players[currentPlayer].hand) {
                Console.WriteLine("{0}) NAME: {1} ATK: {2} DEF: {3}", count, item.name, item.atk, item.def);
                count++;
            } 

             Console.WriteLine("*****************************");

            while(!validInput){
                Console.WriteLine("\nChoose your action (1) attack your opponent. (2) skip your turn. (3) quit the game. :");
                InputLine = Console.ReadLine();
                if(InputLine == "1" || InputLine == "2" || InputLine == "3") {
                    validInput = true;
                    
                }
            }

            return InputLine;
            
        }

        public bool resolveAttackPhase() {

            // ATTACKING PLAYER ACTIONS
            bool validInput = false;
            string InputLine = ""; // set to quit by default just in case...
            int input = 0;
            
            while(!validInput){
                Console.WriteLine("\nPlayer, {0}", players[currentPlayer].name);
                Console.WriteLine("Please choose beast you would like to attack with from the list above! (1-{0})", players[currentPlayer].hand.Count);
                InputLine = Console.ReadLine();
                input = Int32.Parse(InputLine);

                if(input <= players[currentPlayer].hand.Count) {
                    validInput = true;
                }
            }
            players[currentPlayer].field.Add(players[currentPlayer].hand[input-1]);
            players[currentPlayer].hand.RemoveAt(input-1);

            // DEFENDING PLAYER ACTIONS

            // find other player & reset values
            int otherPlayer;
            if(currentPlayer == 1) {
                otherPlayer = 0;
            } else {
                otherPlayer = 1;
            }

            Console.Clear();
            Console.WriteLine("\n++++ {0}'s Defence Phase!!!! ++++\n", players[otherPlayer].name);

            // added this just for balancing...
            players[otherPlayer].draw(deck);
            
            validInput = false;
            InputLine = "";
            input = 0;
            int count = 1;

            Console.WriteLine("\n*****************************");
            Console.WriteLine("     Player {0} current hand:", players[otherPlayer].name);
            Console.WriteLine("*****************************");

            foreach(var item in players[otherPlayer].hand) {
                Console.WriteLine("{0}) NAME: {1} ATK: {2} DEF: {3}", count, item.name, item.atk, item.def);
                count++;
            } 

             Console.WriteLine("*****************************");

            while(!validInput){
                Console.WriteLine("\nPlayer, {0}", players[otherPlayer].name);
                Console.WriteLine("Please choose beast you would like to defend with from the list above! (1-{0})", players[otherPlayer].hand.Count);
                InputLine = Console.ReadLine();
                input = Int32.Parse(InputLine);

                if(input <= players[otherPlayer].hand.Count) {
                    validInput = true;
                }
            }
            players[otherPlayer].field.Add(players[otherPlayer].hand[input-1]);
            players[otherPlayer].hand.RemoveAt(input-1);

            Console.Clear();
            Console.WriteLine("*****************************************************************************");
            Console.WriteLine("*************** PREPARE FOR A BATTLE OF THE AGES!!!!! ***********************");
            Console.WriteLine("*****************************************************************************");
            Console.WriteLine("press any key to continue");
            Console.ReadLine();
            Console.Clear();

            // Note: both fields have the attacking and defending creatures... 
            Console.WriteLine("\n{0}\n", players[currentPlayer].field[0].name);
            players[currentPlayer].field[0].GetInfo();

            Console.WriteLine("\n VS \n");

            Console.WriteLine("\n{0}\n", players[otherPlayer].field[0].name);
            players[otherPlayer].field[0].GetInfo();
            
            // Calc Combat

            if( players[currentPlayer].field[0].atk > players[otherPlayer].field[0].def ) {
                int leftover = players[currentPlayer].field[0].atk - players[otherPlayer].field[0].def;
                players[otherPlayer].health -= leftover;

                Console.WriteLine("\n****************************");
                Console.WriteLine("{0} DEALS {1}", players[currentPlayer].field[0].name, players[currentPlayer].field[0].atk);
                Console.WriteLine("{0} BLOCKS {1}", players[otherPlayer].field[0].name, players[otherPlayer].field[0].def);
                Console.WriteLine("{0} TAKES {1} DAMAGE!!!", players[otherPlayer].name, leftover);
                Console.WriteLine("****************************\n");
                Console.WriteLine("press any key to continue");
                Console.ReadLine();

            } else {
                // no action at the moment...
            }

            // now remove creatures from the field and check winning state...
            players[currentPlayer].field.RemoveAt(0);
            players[otherPlayer].field.RemoveAt(0);



            return checkWinState(otherPlayer);
        }


        public void renderSplashScreen() {
            Console.Clear();
            Console.WriteLine("****************************");
            Console.WriteLine("Welcome to Dojo Beast Brawl!");
            Console.WriteLine("              n__n_    ");
            Console.WriteLine("             /  = =\\   ");
            Console.WriteLine("            /   ._Y_)   ");
            Console.WriteLine("___________/      \"\\______");
            Console.WriteLine("          (_/  (_,  \\       ");
            Console.WriteLine("            \\      ( \\_,--\"\"\"\"--. ");
            Console.WriteLine("      __..-,-`.___,-` )-.______.' ");
            Console.WriteLine("    <'     `-,'   `-, )-'    >      ");
            Console.WriteLine("     `----._/      ( /\"`>.--\"           ");
            Console.WriteLine("            \"--..___,--\"                 ");
            Console.WriteLine("****************************");
        }

        public bool checkWinState(int otherPlayer ) {
            if( players[otherPlayer].health <= 0 ) {

                return false;
            } else {
                return true;
            }
        }

        public void renderWinScreen() {
            Console.WriteLine("\n\n******************");
            Console.WriteLine("**** {0} WON THE GAME! ", players[currentPlayer].name);
            Console.WriteLine("**********************");
        }

        public void createPlayers() {

            // CREATE AND ADD TO LIST OF PLAYERS...
            players.Add(new Player(renderNameInput("Player 1")));
            players.Add(new Player(renderNameInput("Player 2")));

            // DRAW FROM DECK FOR EACH PLAYER...
            for( int i = 3; i > 0; i-- ) {
                players[0].draw(deck);
                players[1].draw(deck);
            }
        }

        public string renderNameInput(string header) {
            Console.WriteLine("\nPlease enter a name for {0}", header);
            return Console.ReadLine();
        }

        

        public bool askContinue() {
            Console.WriteLine("Would you like to continue (y/n):");
            string InputLine = Console.ReadLine();

            if(InputLine == "n") {
                continueGame = false;
            }
            return continueGame;
        }
    }
}