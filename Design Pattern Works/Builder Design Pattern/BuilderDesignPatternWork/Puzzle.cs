using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDesignPatternWork
{//Concrete Builder
    internal class Puzzle : GameCategoryBuilder
    {
       
        public Puzzle()
        {
            game = new Game();
        }
        public override void buildGameCategoryName()
        {
            game.GameCategory = "Puzzle";
           // Console.WriteLine("Category Name : "+ game.GameCategory);
        }
        public override void buildGameCategoryDescription()
        {
            game.GameCategoryDescription = "Analitik, görsel ve hafızaya yönelik düşünmeyi gerektiren bulmaca oyunları.";
           // Console.WriteLine(game.GameCategoryDescription);
        }
        public override void SubGameCategoryName()
        {
          
           // Console.WriteLine("Alt kategorileri listeleniyor...");
            game.SubGameCategoryName = "1- Puzzle-Platform\n2- Sıra Tabanlı\n3- Klasik (Sudoku-Kendoku)";
          //  Console.WriteLine(game.SubGameCategoryName);
            /*
            string[] ar = {"Puzzle-Platform","Sıra Tabanlı","Klasik (Sudoku-Kendoku)"};
            int count = 0;
            foreach(string s in ar)
            {
                count++;
                Console.WriteLine(count+". -"+s);
            }*/
        }
    }
}
