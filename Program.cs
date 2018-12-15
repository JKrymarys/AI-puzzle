using System;

namespace AI_puzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // Console.Write("Please use following commands:\n",
            //          "-b || --bfs order \t\t Breadth First Search \n",
            //          "-d || --dfs order \t\t for Depth First Search \n",
            //          "-i || --idfs order \t\t for Iterative Depth First Search \n",
            //          "-h || --bf id_of_heurisic \t Best-first strategy \n",
            //          "-a || --astar id_of_heurisic \t A* strategy \n",
            //          "-s || --sma id_of_heurisic \t SMA* strategy for Breadth First Search \n");


            // int [,] grid = new int[,] {
            //     {3, 9, 1, 15},
            //     {14, 11, 4, 6},
            //     {13, 0, 10, 12},
            //     {2, 7, 8, 5}
            // };
            // Console.Write("Enter the size of grid: ");
            // int a = Convert.ToInt32(Console.Read());
            // int [] grid = new int[a];
            // Console.Write("Enter the grid");
            // for (var i = 0; i < 4; i++)
            // {
            //     grid[i] = Convert.ToInt32(Console.ReadLine());
            //     Console.WriteLine( grid[i]);
            // }
            // Console.ReadKey();
            int [,] grid = new int[,] {
               {1, 8, 2},
               {0, 4, 3},
               {7, 6, 5}
            };

            PuzzleGrid puzzle = new PuzzleGrid(grid);
            puzzle.printGrid();

            Algorithms algorithm = new Algorithms();
            algorithm.BFTS(puzzle);
            //Console.WriteLine(xd);
        }
    }
}
