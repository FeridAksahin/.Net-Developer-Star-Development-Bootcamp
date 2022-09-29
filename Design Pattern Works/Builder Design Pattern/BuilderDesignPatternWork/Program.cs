using BuilderDesignPatternWork;
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameCategoryBuilder gameCategoryPuzzleBuilder = new Puzzle();
            GameRouter g = new GameRouter();
            g.GameDirector(gameCategoryPuzzleBuilder);

            Console.WriteLine(gameCategoryPuzzleBuilder.Game.ToString());
        }
    }
}