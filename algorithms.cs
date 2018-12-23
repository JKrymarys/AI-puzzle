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

            while (frontier.Count != 0)
            {
                grid = frontier.Dequeue();

                foreach (char i in possible_moves)
                {
                    var newPuzzleState = grid.move(i);
                    
                    if(newPuzzleState == null)
                        continue;

                    
                    if (grid.checkIfSolved())
                    {
                        Console.WriteLine("SOLVED!");
                        grid.printGrid();
                        return true;
                    }
                    if(!doneMoves.Contains(newPuzzleState))
                    {
                        frontier.Enqueue(newPuzzleState);
                        doneMoves.Add(newPuzzleState);
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


            while (frontier.Count != 0)
            {
                grid = frontier.Pop();

                foreach (char i in possible_moves)
                {
                    var newPuzzleState = grid.move(i);
                    
                    if(newPuzzleState == null)
                        continue;

                    if (newPuzzleState.checkIfSolved())
                    {
                        Console.WriteLine("SOLVED!");
                        newPuzzleState.printGrid();
                        return true;
                    }

                    if(!doneMoves.Contains(newPuzzleState))
                    {
                        frontier.Push(newPuzzleState);
                        doneMoves.Add(newPuzzleState);
                    }
                       
                }
            }
            return false;
        }
      
        public void IDFS(PuzzleGrid grid)
        {
            var idfsSolver = new IDFS(possible_moves); 
            idfsSolver.iterativeDeepening(grid,MAX_DEPTH);
        }

        public bool BFTS(PuzzleGrid grid, int heuristic_id)
        {
            SimplePriorityQueue<PuzzleGrid> frontier = new SimplePriorityQueue<PuzzleGrid>();
            HashSet<PuzzleGrid> doneMoves = new HashSet<PuzzleGrid>();

            frontier.Enqueue(grid, 0);
            doneMoves.Add(grid);

            while (frontier.Count != 0)
            {
                grid = frontier.Dequeue();

                foreach (char i in possible_moves)
                {
                    var newPuzzleState = grid.move(i);
                    
                    if(newPuzzleState == null)
                        continue;

                    if (newPuzzleState.checkIfSolved())
                    {
                        Console.WriteLine("SOLVED!");
                        newPuzzleState.printGrid();
                        return true;
                    }

                    if(!doneMoves.Contains(newPuzzleState))
                    {
                        int priorityLevel = 0;
                        if(heuristic_id == 1) 
                            {
                                priorityLevel = newPuzzleState.manhatann_heuristic();
                            }
                        else if (heuristic_id == 2)
                            {
                                priorityLevel = newPuzzleState.diagonal_heuristic();

                            }
                        else if(heuristic_id == 3)
                            {
                                priorityLevel = (int)newPuzzleState.euclides_heuristic();
                            }
                        frontier.Enqueue(newPuzzleState, priorityLevel);
                        doneMoves.Add(newPuzzleState);
                    }
                }
            }
            return false;
        }

        public bool ASTAR(PuzzleGrid grid, int heuristic_id)
        {
            SimplePriorityQueue<PuzzleGrid> frontier = new SimplePriorityQueue<PuzzleGrid>();
            HashSet<PuzzleGrid> doneMoves = new HashSet<PuzzleGrid>();

            frontier.Enqueue(grid, 0); //according to assumtions
            doneMoves.Add(grid);
        
            while (frontier.Count != 0)
            {
                grid = frontier.Dequeue();

                foreach (char i in possible_moves)
                {
                    var newPuzzleState = grid.move(i);
                    
                    if(newPuzzleState == null)
                        continue;

                    if (newPuzzleState.checkIfSolved())
                    {
                        Console.WriteLine("SOLVED!");
                        newPuzzleState.printGrid();
                        return true;
                    }

                    if(!doneMoves.Contains(newPuzzleState))
                    {
                        grid._level_of_depth++;
                        int priorityLevel = 0;
                        if(heuristic_id == 1) 
                            {
                                priorityLevel = newPuzzleState.manhatann_heuristic() + grid._level_of_depth;
                            }
                        else if (heuristic_id == 2)
                            {
                                priorityLevel = newPuzzleState.diagonal_heuristic() + grid._level_of_depth;

                            }
                        else if(heuristic_id == 3)
                            {
                                priorityLevel = (int)newPuzzleState.euclides_heuristic() + grid._level_of_depth;
                            }
                        frontier.Enqueue(newPuzzleState, priorityLevel);
                        doneMoves.Add(newPuzzleState);
                    }
                }
            }
            return false;
        }

        public bool SMA(PuzzleGrid grid, int heuristic_id)
        {
            SimplePriorityQueue<PuzzleGrid> frontier = new SimplePriorityQueue<PuzzleGrid>();
            HashSet<PuzzleGrid> doneMoves = new HashSet<PuzzleGrid>();

            frontier.Enqueue(grid, 0);
            doneMoves.Add(grid);
            var previousCost = 0;

            while (frontier.Count != 0)
            {
                grid = frontier.Dequeue();

                foreach (char i in possible_moves)
                {
                    var newPuzzleState = grid.move(i);
                    
                    if(newPuzzleState == null)
                        continue;

                    if (newPuzzleState.checkIfSolved())
                    {
                        Console.WriteLine("SOLVED!");
                        newPuzzleState.printGrid();
                        return true;
                    }

                    if(!doneMoves.Contains(newPuzzleState))
                    {
                        grid._level_of_depth++;
                        int priorityLevel = 0;
                        if(heuristic_id == 1) 
                            {
                                priorityLevel = newPuzzleState.manhatann_heuristic() + grid._level_of_depth;
                            }
                        else if (heuristic_id == 2)
                            {
                                priorityLevel = newPuzzleState.diagonal_heuristic() + grid._level_of_depth;

                            }
                        else if(heuristic_id == 3)
                            {
                                priorityLevel = (int)newPuzzleState.euclides_heuristic() + grid._level_of_depth;
                            }
                        frontier.Enqueue(newPuzzleState, Math.Max(priorityLevel, previousCost));
                        previousCost = priorityLevel;
                        doneMoves.Add(newPuzzleState);
                    }
                }
            }
            return false;
        }
    }
}
