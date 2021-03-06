using System;
using System.Collections.Generic;

namespace Dojo_Beast_Brawl
{
    class Player
    {
        public Player(string name){
            this.name=name;
        }
        public string name;

        public int health = 5;

        public List<Card> hand = new List<Card>();

        public List<Card> field = new List<Card>();

        public List<Card> graveyard = new List<Card>();
        public Card draw(Deck deck1){
            Card card1 = deck1.draw();
            // Console.WriteLine(card1.val+card1.suit);
            hand.Add(card1);
            return card1;
        }
        public Card discard(int idx){
            if(idx<hand.Count){
                Card card1 = hand[idx];
                // Console.WriteLine(card1.val+card1.suit);
                hand.RemoveAt(idx);
            return card1;
            }
            else{
                Console.WriteLine("it's null");
                return null;
            }
        }
    }
}
