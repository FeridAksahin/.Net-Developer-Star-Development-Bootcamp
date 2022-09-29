using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDesignPatternWork
{//Director class
    internal class GameRouter
    {
        public void GameDirector(GameCategoryBuilder gameCategoryBuilder)
        {
            gameCategoryBuilder.buildGameCategoryName();
            gameCategoryBuilder.buildGameCategoryDescription();
            gameCategoryBuilder.SubGameCategoryName();
        }
    }
}
