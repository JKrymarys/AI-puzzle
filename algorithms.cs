using System;
using System.Collections;
using System.Collections.Generic;
using Priority_Queue;

namespace AI_puzzle
{
    public class Algorithms 
    {
        const int MAX_DEPTH = 30;
        char[] possible_moves;
        public Algorithms(char[] _moves)
        {
            this.possible_moves = _moves;
        }
        public Boolean BFS(PuzzleGrid grid)
        {
            Queue<PuzzleGrid> frontier = new Queue<PuzzleGrid>();
            HashSet<PuzzleGrid> doneMoves = new HashSet<PuzzleGrid>();

            frontier.Enqueue(grid);
            doneMoves.Add(grid);

           // possible_moves = { 'U', 'D', 'L', 'R' };

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

        public bool BFTS(PuzzleGrid grid)
        {
            SimplePriorityQueue<PuzzleGrid> frontier = new SimplePriorityQueue<PuzzleGrid>();
            HashSet<PuzzleGrid> doneMoves = new HashSet<PuzzleGrid>();
            frontier.Enqueue(grid, 0);
            doneMoves.Add(grid);
            char[] possible_moves = { 'U', 'D', 'L', 'R' };

            while (frontier.Count != 0)
            {
                grid = frontier.Dequeue();
                foreach (char i in possible_moves)
                {
                    if (grid.checkIfSolved())
                    {
                        Console.WriteLine("SOLVED!");
                        grid.printGrid();
                        return true;
                    }

                    var newPuzzleState = grid.move(i);
                    if(newPuzzleState == null)
                        continue;

                    if(!doneMoves.Contains(newPuzzleState))
                    {
                        var priorityLevel = grid.manhatann_heuristic();
                        frontier.Enqueue(newPuzzleState, priorityLevel);
                        doneMoves.Add(newPuzzleState);
                        grid = newPuzzleState;
                    }
                }
            }
            return false;
        }

        public bool ASTAR(PuzzleGrid grid)
        {
            SimplePriorityQueue<PuzzleGrid> frontier = new SimplePriorityQueue<PuzzleGrid>();
            HashSet<PuzzleGrid> doneMoves = new HashSet<PuzzleGrid>();
            frontier.Enqueue(grid, 0);
            doneMoves.Add(grid);
            char[] possible_moves = { 'U', 'D', 'L', 'R' };

            while (frontier.Count != 0)
            {
                grid = frontier.Dequeue();
                foreach (char i in possible_moves)
                {
                    if (grid.checkIfSolved())
                    {
                        Console.WriteLine("SOLVED!");
                        grid.printGrid();
                        return true;
                    }

                    var newPuzzleState = grid.move(i);
                    if(newPuzzleState == null)
                        continue;

                    if(!doneMoves.Contains(newPuzzleState))
                    {
                        grid._level_of_depth++;
                        var priorityLevel = grid.manhatann_heuristic() + grid._level_of_depth;
                        frontier.Enqueue(newPuzzleState, priorityLevel);
                        doneMoves.Add(newPuzzleState);
                        grid = newPuzzleState;
                    }
                }
            }
            return false;
        }

        public bool SMA(PuzzleGrid grid)
        {
            SimplePriorityQueue<PuzzleGrid> frontier = new SimplePriorityQueue<PuzzleGrid>();
            HashSet<PuzzleGrid> doneMoves = new HashSet<PuzzleGrid>();
            frontier.Enqueue(grid, 0);
            doneMoves.Add(grid);
            var previousCost = 0;
            char[] possible_moves = { 'U', 'D', 'L', 'R' };

            while (frontier.Count != 0)
            {
                grid = frontier.Dequeue();
                foreach (char i in possible_moves)
                {
                    if (grid.checkIfSolved())
                    {
                        Console.WriteLine("SOLVED!");
                        grid.printGrid();
                        return true;
                    }

                    var newPuzzleState = grid.move(i);
                    if(newPuzzleState == null)
                        continue;

                    if(!doneMoves.Contains(newPuzzleState))
                    {
                        grid._level_of_depth++;
                        var priorityLevel = grid.manhatann_heuristic() + grid._level_of_depth;
                        frontier.Enqueue(newPuzzleState, Math.Max(priorityLevel, previousCost));
                        previousCost = priorityLevel;
                        doneMoves.Add(newPuzzleState);
                        grid = newPuzzleState;
                    }
                }
            }
            return false;
        }
    }
}
