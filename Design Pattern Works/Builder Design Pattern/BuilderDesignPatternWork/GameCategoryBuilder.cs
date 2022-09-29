using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDesignPatternWork
{//Builder class
    internal abstract class GameCategoryBuilder
    {
        public abstract void buildGameCategoryName();
        public abstract void buildGameCategoryDescription();
        public abstract void SubGameCategoryName();
        protected Game game;
        public Game Game { get { return game; } }   
    }
}
