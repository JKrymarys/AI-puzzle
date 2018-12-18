using System;
using System.Diagnostics;
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


            Console.Write("Enter the size of grid: ");
            var gridSize = Convert.ToInt32(Console.ReadLine());
            int[,] rowGrid = new int[gridSize,gridSize];
           
            Console.WriteLine("Enter the grid, line by line with spaces(' '): ");
            try
            {
                for (var x = 0; x < gridSize; x++)
                {
                    string[] s = Console.ReadLine().Split(' ');
                    for (var y = 0; y < gridSize; y++)
                    {
                        rowGrid[x,y] = Int32.Parse(s[y]);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            Stopwatch watch = new Stopwatch();
            long elapsedMs;
            var grid = rowGrid;
            PuzzleGrid puzzle = new PuzzleGrid(grid);
            if (!puzzle.isSolvable())
            {
                throw new System.ArgumentException("Grid is no solvable", "original");
            }
            Console.WriteLine("Enter the algorith: ");
            string[] z = Console.ReadLine().Split(' ');
            string algorithm = z[0];

            Console.WriteLine("Give the order of moves: ");
            z = Console.ReadLine().Split(' ');
            char[] order = new char[4];
            for(int i = 0; i < 4; i++)
            {
                order[i] = z[0][i];
            }

            Algorithms al = new Algorithms(order);
            switch(algorithm)
            {
                case "-b":
                case "--bfs":
                {
                    watch = Stopwatch.StartNew();
                    al.BFS(puzzle);
                    watch.Stop();
                    elapsedMs = watch.ElapsedMilliseconds;
                    Console.WriteLine("Elapsed time: {0}", elapsedMs);
                    break;
                }
                case "-d":
                case "--dfs":
                {
                    watch = Stopwatch.StartNew();
                    al.DFS(puzzle);
                    watch.Stop();
                    elapsedMs = watch.ElapsedMilliseconds;
                    Console.WriteLine("Elapsed time: {0}", elapsedMs);
                    break;
                }
                case "-i":
                case "--idfs":
                {
                    watch = Stopwatch.StartNew();
                    al.IDFS(puzzle);
                    watch.Stop();
                    elapsedMs = watch.ElapsedMilliseconds;
                    Console.WriteLine("Elapsed time: {0}", elapsedMs);
                    break;
                }
                case "-h":
                case "--bf":
                {
                    watch = Stopwatch.StartNew();
                    al.BFTS(puzzle);
                    watch.Stop();
                    elapsedMs = watch.ElapsedMilliseconds;
                    Console.WriteLine("Elapsed time: {0}", elapsedMs);
                    break;
                }
                case "-a":
                case "--astar":
                {
                    watch = Stopwatch.StartNew();
                    al.ASTAR(puzzle);
                    watch.Stop();
                    elapsedMs = watch.ElapsedMilliseconds;
                    Console.WriteLine("Elapsed time: {0}", elapsedMs);
                    break;
                }
                case "-s":
                case "--sma":
                {
                    watch = Stopwatch.StartNew();
                    al.SMA(puzzle);
                    watch.Stop();
                    elapsedMs = watch.ElapsedMilliseconds;
                    Console.WriteLine("Elapsed time: {0}", elapsedMs);
                    break;
                }
                default:
                    Console.Write(
                     "Please use following commands:\n-b || --bfs order \t\t Breadth First Search \n-d || --dfs order \t\t for Depth First Search \n-i || --idfs order \t\t for Iterative Depth First Search \n-h || --bf id_of_heurisic \t Best-first strategy \n-a || --astar id_of_heurisic \t A* strategy \n-s || --sma id_of_heurisic \t SMA* strategy for Breadth First Search \n");
                     break;
            }
        }
    }
}
