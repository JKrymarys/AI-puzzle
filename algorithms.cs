using System;
using System.Collections;
using System.Collections.Generic;
namespace AI_puzzle
{
    public class Algorithms
    {
        public Algorithms()
        {

        }

        public Boolean BFS(PuzzleGrid grid)
        {
            Queue<PuzzleGrid> frontier = new Queue<PuzzleGrid>();
            HashSet<PuzzleGrid> doneMoves = new HashSet<PuzzleGrid>();

            frontier.Enqueue(grid);

            char[] possible_moves = { 'U', 'D', 'L', 'R' };

            while (frontier.Count != 0)
            {
                grid = frontier.Dequeue();
                foreach (char i in possible_moves)
                {
                    if (grid.checkIfSolved())
                    {
                        return true;
                    }
                    Console.WriteLine(i);
                    //Console.WriteLine(grid.move(i));

                    var newPuzzleState = grid.move(i);
                    if(newPuzzleState == null)
                        break;

                    newPuzzleState.printGrid();

                    if (newPuzzleState != null && !doneMoves.Contains(newPuzzleState))
                    {
                        frontier.Enqueue(newPuzzleState);
                        doneMoves.Add(newPuzzleState);
                        
                    }
                }
            }
            return false;
        }

    }
}
