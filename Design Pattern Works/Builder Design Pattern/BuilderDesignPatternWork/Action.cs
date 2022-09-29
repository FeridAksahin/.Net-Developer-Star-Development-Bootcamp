using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDesignPatternWork
{//Concrete Builder
    internal class Actionn : GameCategoryBuilder
    {
 
        public Actionn()
        {
            game = new Game();
        }
       
        public override void buildGameCategoryName()
        {
            game.GameCategory = "Category Name : Action";
           // Console.WriteLine(game.GameCategory);
        }
        public override void buildGameCategoryDescription()
        {
            game.GameCategoryDescription = "Aksiyon içerek oyunlar kategorisidir.";
            //Console.WriteLine(game.GameCategoryDescription);
        }
        public override void SubGameCategoryName()
        {
            game.SubGameCategoryName = "1- Action-Adventure\n2- Action-RYO\n3- Action-Roguelike";
            /* Console.WriteLine("Alt kategorileri listeleniyor...");
             string[] ar = { "Action-Adventure", "Action-RYO", "Action-Roguelike" };
             int count = 0;
             foreach (string s in ar)
             {
                 count++;
                 Console.WriteLine(s);
             }*/
        }
    }
}
