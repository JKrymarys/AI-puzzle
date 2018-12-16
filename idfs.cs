using System;
using System.Collections;
using System.Collections.Generic;

namespace AI_puzzle
{
    public class IDFS
    {
        HashSet<PuzzleGrid> doneMoves;
        PuzzleGrid goal;
        
        public IDFS() {
            doneMoves = new HashSet<PuzzleGrid>();
        }


        public void idfs(PuzzleGrid grid, int depth)
        {
            if (depth < 0)
                return; // end of recursion


            //check if reached solution, to stop the algorithm
            if (grid.checkIfSolved())
            {
                Console.WriteLine("SOLVED!");
                grid.printGrid();
                this.goal = grid;
                return;
            }

            PuzzleGrid newPuzzleState;

            char[] possible_moves = { 'U', 'D', 'L', 'R' };
            foreach (char i in possible_moves)
            {
                //Console.WriteLine(i);
                //Console.WriteLine(grid.move(i));
                newPuzzleState = grid.move(i);
                if (newPuzzleState != null && !doneMoves.Contains(newPuzzleState))
                {
                    CallIDFS(newPuzzleState, depth);
                  //  newPuzzleState.printGrid();
                }
            }


        }

        public void iterativeDeepening(PuzzleGrid puzzleState, int depthLimit)
        {
            doneMoves.Add(puzzleState); //starting grid

            for (int i = 1; i <= depthLimit; i++)
            {
                idfs(puzzleState, i);  // depth-first search at this level

                // Check if the goal grid has been reached
                if (goal != null)
                    return;
            }

        }
        public void CallIDFS(PuzzleGrid newPuzzleState, int depth)
        {
            doneMoves.Add(newPuzzleState);
            idfs(newPuzzleState, depth - 1);
            if (goal != null)
                return;

            doneMoves.Remove(newPuzzleState);
        }
    }
}