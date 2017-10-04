using System;
using System.Collections.Generic;


namespace Dojo_Beast_Brawl
{
    public class Deck
    {   
       
        public Deck(){
            reset();
        }
        
        public List<Card> cards = new List<Card>();
        public int size=52;
        
        public string[] adjective = {"Angry", "Sad", "Crazy", "Lustful", "Greedy", "Wrathful", "Flaming", "Tired", "Insightful", "Slow", "Random"};

        // public Dictionary[] example ={{name:"Angry",adjusters:[1,-1]}, {name:"Sad",adjusters:[-1,0]}, {name:"Crazy",adjusters:[2,-2]}, {name:"Lustful",adjusters:[-1,2]}, {name:"Greedy",adjusters[0,0]}, {name:"Wrathful",adjusters:[3,-1]}, {name:"Flaming",adjusters[1,-1]}, {name:"Tired",adjusters[-1,-1]}, {name:"Insightful"adjusters[1,1]}, {name:"Slow",adjusters:[-1,-2]}, {name:"Random",adjusters[7,7]}};
        public int[] adjusters1 = {1, -1, 2, -1, 0, 3, 1, -1, 1, -1, 7};
         public int[] adjusters2 = {-1, 0, -2, 2, 0, -1, -1, -1, 1, -2, 7};
        public string[] title = {"General", "Scout", "Grunt", "Blacksmith", "Farmer", "Bard", "Wizard", "Warrior", "Thief", "Samurai", "Student"};
        public string[] species = {"Bear", "Badger", "Koala", "Wolf", "Human", "Gorilla", "Python", "Chicken", "Lynx", "Coding Dojo", "Emu"};

        //rewrite generate.
        public void reset(){
            
            for(int x =0; x<size;x++){
                int def=rand.Next(5);
                
                int atk=5-def;
                int adj=rand.Next(adjective.Length);
                string title2=title[rand.Next(title.Length)];
                string species2=species[rand.Next(species.Length)];
                
                string name1=adjective[adj]+title2+species2;
                if(adjusters1[adj]==7){
                    int cardAttack = atk+rand.Next(-4,4);
                    int cardDef = def+rand.Next(-4,4);
                    if (cardAttack<0)
                    {
                        cardAttack = 0;
                    }
                    if (cardDef < 1)
                    {
                        cardDef = 1;
                    }
                    Card newCard= new Card(name1,cardAttack,cardDef);
                    cards.Add(newCard);
                }else{
                    int cardAttack = atk+adjusters1[adj];
                    int cardDef = def+adjusters2[adj];
                    if (cardAttack<0)
                    {
                        cardAttack = 0;
                    }
                    if (cardDef < 1)
                    {
                        cardDef = 1;
                    }
                    Card newCard= new Card(name1,cardAttack,cardDef);
                    cards.Add(newCard);
                }
                // Card newCard= new Card(name=name1,atk,def);
                // cards.Add(newCard);
                }
            }
        
        public Card draw(){
            Card dealtCard=cards[0];
            cards.RemoveAt(0);
            return dealtCard;
        }

        Random rand = new Random();
        
        public void shuffle(){
            int n = cards.Count;
            while (n > 1) 
            {
                int k = rand.Next(n--);
                Card temp = cards[n];
                cards[n] = cards[k];
                cards[k] = temp;
            }
            
        }
    }
}
