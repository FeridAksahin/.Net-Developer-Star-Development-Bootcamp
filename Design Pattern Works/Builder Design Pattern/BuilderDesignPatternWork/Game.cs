using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDesignPatternWork
{//Product class
    internal class Game
    {
        public string GameCategory { get; set; }
        public string GameCategoryDescription { get; set; }
        public string SubGameCategoryName { get; set; }

        public override string ToString()
        {
            return "Category Name : "+GameCategory+ "\n"+ "Description : "+ GameCategoryDescription+ "\n"+ "Alt kategorileri listeleniyor..." + "\n"+
                SubGameCategoryName;
        }
    }
}
