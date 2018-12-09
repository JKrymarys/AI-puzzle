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
        frontier.Enqueue(grid);
        char[] possible_moves = {'U', 'D', 'L', 'R'};
        while(frontier.Count != 0)
        {
            grid = frontier.Dequeue();
            if(grid.checkIfSolved())
            {
                return true;
            }

            foreach(char i in possible_moves)
            {
                if(grid.move(i))
                {
                    frontier.Enqueue(grid);
                }
            }
        }
        return false;
    }
        
    }
}
