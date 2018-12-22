using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
namespace AI_puzzle
{
    class Program
    {
        private static Random rand = new Random();
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
            string pattern = @"^([udlr]{4})|(x)$";
            Match result;
            char[] order = new char[4];
            var possibleMoves = new List<char>{'u','d','l','r'};
            Stopwatch watch = new Stopwatch();
            long elapsedMs; 
            int[,] grid;
            PuzzleGrid puzzle;
            Algorithms al;

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

             watch = new Stopwatch();
             grid = rowGrid;
             puzzle = new PuzzleGrid(grid);
            if (!puzzle.isSolvable())
            {
                throw new System.ArgumentException("Grid is no solvable", "original");
            }
            
            string[] input; // to gather input



            Console.WriteLine("Enter the algorith: ");  
            input = Console.ReadLine().Split(' ');
            string algorithm = input[0];
            al = new Algorithms(order);

            if(algorithm != "--astar" || algorithm != "--sma" || algorithm != "-a" || algorithm != "-s" ||
               algorithm != "--bf" || algorithm != "-h"  )
            {
                Console.WriteLine("Give the order of moves: ");
                do{
                    input = Console.ReadLine().Split(' ');
                    input[0].ToLower();
                    result = Regex.Match(input[0], pattern);
                }while(!result.Success);

                // check if order should be random or not
                if(input[0][0] == 'x')
                {
                    for(int i = 0; i < 4; i++)
                    {
                        int index = rand.Next(possibleMoves.Count);
                        order[i] = possibleMoves[index];
                        possibleMoves.RemoveAt(index);
                    }
                    
                } else
                {
                    for(int i = 0; i < 4; i++)
                    {
                        order[i] = input[0][i];
                    }
                }
            Console.WriteLine(new string(order));
            } 
            else {
                // tutaj wybór heurysyki
            }


            switch(algorithm)
            {
                case "-b":
                case "--bfs":
                {
                    Console.WriteLine("BFS started:");
                    watch = Stopwatch.StartNew();
                    Console.WriteLine(al.BFS(puzzle));
                    watch.Stop();
                    elapsedMs = watch.ElapsedMilliseconds;
                    Console.WriteLine("Elapsed time: {0} ms", elapsedMs);
                    break;
                }
                case "-d":
                case "--dfs":
                {
                    Console.WriteLine("DFS started:");
                    watch = Stopwatch.StartNew();
                    al.DFS(puzzle);
                    watch.Stop();
                    elapsedMs = watch.ElapsedMilliseconds;
                    Console.WriteLine("Elapsed time: {0} ms", elapsedMs);
                    break;
                }
                case "-i":
                case "--idfs":
                {
                    Console.WriteLine("IDFS started:");
                    watch = Stopwatch.StartNew();
                    al.IDFS(puzzle);
                    watch.Stop();
                    elapsedMs = watch.ElapsedMilliseconds;
                    Console.WriteLine("Elapsed time: {0} ms", elapsedMs);
                    break;
                }
                case "-h":
                case "--bf":
                {
                    Console.WriteLine("BF started:");
                    watch = Stopwatch.StartNew();
                    al.BFTS(puzzle);
                    watch.Stop();
                    elapsedMs = watch.ElapsedMilliseconds;
                    Console.WriteLine("Elapsed time: {0} ms", elapsedMs);
                    break;
                }
                case "-a":
                case "--astar":
                {
                    Console.WriteLine("A* started:");
                    watch = Stopwatch.StartNew();
                    al.ASTAR(puzzle);
                    watch.Stop();
                    elapsedMs = watch.ElapsedMilliseconds;
                    Console.WriteLine("Elapsed time: {0} ms", elapsedMs);
                    break;
                }
                case "-s":
                case "--sma":
                {
                    Console.WriteLine("SMA* started:");
                    watch = Stopwatch.StartNew();
                    al.SMA(puzzle);
                    watch.Stop();
                    elapsedMs = watch.ElapsedMilliseconds;
                    Console.WriteLine("Elapsed time: {0} ms", elapsedMs);
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
