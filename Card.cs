using System;

namespace Dojo_Beast_Brawl
{
    public class Card
    {
       public string name;
       public int atk;
       public int def;

       public Card(string name,int atk,int def){
           this.name=name;
           this.atk=atk;
           this.def=def;
       }
    }
}
