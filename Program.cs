using System;

namespace AI_puzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please use following commands:\n",
                     "-b || --bfs order \t\t Breadth First Search \n",
                     "-d || --dfs order \t\t for Depth First Search \n",
                     "-i || --idfs order \t\t for Iterative Depth First Search \n",
                     "-h || --bf id_of_heurisic \t Best-first strategy \n",
                     "-a || --astar id_of_heurisic \t A* strategy \n",
                     "-s || --sma id_of_heurisic \t SMA* strategy for Breadth First Search \n");



            PuzzleGrid puzzle = new PuzzleGrid(4);
            puzzle.printGrid();
        }
    }
}
