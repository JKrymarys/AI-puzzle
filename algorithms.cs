using System;
using System.Collections;
using System.Collections.Generic;
namespace AI_puzzle
{
    public class Algorithms 
    {
        const int MAX_DEPTH = 30;
        public Algorithms()
        {

        }
        public Boolean BFS(PuzzleGrid grid)
        {
            Queue<PuzzleGrid> frontier = new Queue<PuzzleGrid>();
            HashSet<PuzzleGrid> doneMoves = new HashSet<PuzzleGrid>();

            frontier.Enqueue(grid);
            doneMoves.Add(grid);

            char[] possible_moves = { 'U', 'D', 'L', 'R' };

            while (frontier.Count != 0)
            {
                grid = frontier.Dequeue();
                foreach (char i in possible_moves)
                {
                    //Console.WriteLine(i);
                    if (grid.checkIfSolved())
                    {
                        Console.WriteLine("SOLVED!");
                        grid.printGrid();
                        return true;
                    }
                    //Console.WriteLine(grid.move(i));

                    var newPuzzleState = grid.move(i);
                    if(newPuzzleState == null)
                        continue;

                    //Console.WriteLine(!doneMoves.Contains(newPuzzleState));
                    if(!doneMoves.Contains(newPuzzleState))
                    {
                        frontier.Enqueue(newPuzzleState);
                        doneMoves.Add(newPuzzleState);
                        grid = newPuzzleState;
                        //newPuzzleState.printGrid();
                    }
                }
            }
            return false;
        }

        public Boolean DFS(PuzzleGrid grid)
        {
            Stack<PuzzleGrid> frontier = new Stack<PuzzleGrid>();
            HashSet<PuzzleGrid> doneMoves = new HashSet<PuzzleGrid>();

            frontier.Push(grid);
            doneMoves.Add(grid);

            char[] possible_moves = { 'U', 'D', 'L', 'R' };

            while (frontier.Count != 0)
            {
                grid = frontier.Pop();
                foreach (char i in possible_moves)
                {
                    //Console.WriteLine(i);
                    if (grid.checkIfSolved())
                    {
                        Console.WriteLine("SOLVED!");
                        grid.printGrid();
                        return true;
                    }
                    //Console.WriteLine(grid.move(i));

                    var newPuzzleState = grid.move(i);
                    if(newPuzzleState == null)
                        continue;

                    //Console.WriteLine(!doneMoves.Contains(newPuzzleState));
                    if(!doneMoves.Contains(newPuzzleState))
                    {
                        frontier.Push(newPuzzleState);
                        doneMoves.Add(newPuzzleState);
                        grid = newPuzzleState;
                        //newPuzzleState.printGrid();
                    }
                }
            }
            return false;
        }

      
      public void IDFS(PuzzleGrid grid)
      {
       var idfsSolver = new IDFS(); 
       idfsSolver.iterativeDeepening(grid,MAX_DEPTH);
      }
        public Boolean A_star(PuzzleGrid grid)
        {
            PriorityQueue<PuzzleGrid> frontier = new PriorityQueue<PuzzleGrid>();
            HashSet<PuzzleGrid> doneMoves = new HashSet<PuzzleGrid>();
            frontier.Add(0, grid);
            doneMoves.Add(grid);
            int priorityLevel = 2;
            char[] possible_moves = { 'U', 'D', 'L', 'R' };

            while (frontier.Count != 0)
            {
                grid = frontier.Peek();
                priorityLevel--;
                foreach (char i in possible_moves)
                {
                    //Console.WriteLine(i);
                    if (grid.checkIfSolved())
                    {
                        Console.WriteLine("SOLVED!");
                        grid.printGrid();
                        return true;
                    }
                    //Console.WriteLine(grid.move(i));

                    var newPuzzleState = grid.move(i);
                    if(newPuzzleState == null)
                        continue;

                    //Console.WriteLine(!doneMoves.Contains(newPuzzleState));
                    if(!doneMoves.Contains(newPuzzleState))
                    {
                        frontier.Add(++priorityLevel, newPuzzleState);
                        doneMoves.Add(newPuzzleState);
                        grid = newPuzzleState;
                        //newPuzzleState.printGrid();
                    }
                }
            }
            return false;
        }
    }
}
