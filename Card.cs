using System;
using System.Collections.Generic;

namespace Dojo_Beast_Brawl
{
    public class Card
    {
       public string name;
       public int atk;
       public int def;
       public List<string> sprite;
       public Card(string name,int atk,int def, List<string> sprite){
           this.name=name;
           this.atk=atk;
           this.def=def;
           this.sprite =sprite;
       }
       public void GetInfo()
       {
           foreach (var line in sprite)
           {
               Console.WriteLine(line);
           }
           Console.WriteLine("Attack:"+atk+" "+"Defense:"+def);
       }
    }
}
