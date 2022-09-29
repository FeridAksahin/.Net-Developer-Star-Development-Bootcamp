using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDesignPatternWork
{//Concrete Builder
    internal class Moba : GameCategoryBuilder
    {
       
        public Moba()
        {
            game = new Game();
        }
     
        public override void buildGameCategoryName()
        {
            game.GameCategory = "Category Name : Moba";
          //  Console.WriteLine(game.GameCategory);
        }
        public override void buildGameCategoryDescription()
        {
            game.GameCategoryDescription = "Çevrimiçi çok oyunculu savaş arenası üzerinde oynanan oyunlar.";

           // Console.WriteLine(game.GameCategoryDescription);
        }
        public override void SubGameCategoryName()
        {
            game.SubGameCategoryName = "1- VR Moba\n2- Klasik Moba";
            // Console.WriteLine("Alt kategorileri listeleniyor...");
            /*  string[] ar = { "VR Moba", "Klasik Moba"};
              int count = 0;
              foreach (string s in ar)
              {
                  count++;
                  Console.WriteLine(s);
              }*/
        }
    }
}
