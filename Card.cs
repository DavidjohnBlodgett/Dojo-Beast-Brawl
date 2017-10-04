using System;

namespace Dojo_Beast_Brawl
{
    public class Card
    {
       public string stringVal;
       public string suit;
       public int val;

       public Card(string str,string suit,int val){
           stringVal=str;
           this.suit=suit;
           this.val=val;
       }
    }
}
