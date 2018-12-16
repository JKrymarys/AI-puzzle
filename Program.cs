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

            var grid = rowGrid;
            PuzzleGrid puzzle = new PuzzleGrid(grid);
            Console.WriteLine("Enter the algorith: ");
            string[] z = Console.ReadLine().Split(' ');
            string algorithm = z[0];

            switch(algorithm)
            {
                case "-b":
                case "--bfs":
                {
                    string order = z[1];
                    Algorithms al = new Algorithms();
                    al.BFS(puzzle);
                    break;
                }
                case "-d":
                case "--dfs":
                {
                    string order = z[1];
                    Algorithms al = new Algorithms();
                    al.DFS(puzzle);
                    break;
                }
                case "-i":
                case "--idfs":
                {
                    string order = z[1];
                    Algorithms al = new Algorithms();
                    al.IDFS(puzzle);
                    break;
                }
                case "-h":
                case "--bf":
                {
                    var order = Int32.Parse(z[1]);
                    Algorithms al = new Algorithms();
                    al.BFTS(puzzle);
                    break;
                }
                case "-a":
                case "--astar":
                {
                    var order = Int32.Parse(z[1]);
                    Algorithms al = new Algorithms();
                    al.ASTAR(puzzle);
                    break;
                }
                case "-s":
                case "--sma":
                {
                    var order = Int32.Parse(z[1]);
                    Algorithms al = new Algorithms();
                    al.SMA(puzzle);
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
