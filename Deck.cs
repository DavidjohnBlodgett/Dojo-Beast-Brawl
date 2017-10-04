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
        public string[] title = {"General", "Scout", "Grunt", "Blacksmith", "Farmer", "Bard", "Wizard", "Warrior", "Thief", "Samurai", "Student"};
        public string[] species = {"Bear", "Badger", "Koala", "Wolf", "Human", "Gorilla", "Python", "Chicken", "Lynx", "Coding Dojo", "Emu"};

        //rewrite generate.
        public void reset(){
            
            for(int x =0; x<size;x++){
                string name=null;
                int atk=0;
                int def=0;
                    Card newCard= new Card(name,atk,def);
                cards.Add(newCard);
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
