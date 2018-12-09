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
        HashSet<PuzzleGrid> explored = new HashSet<PuzzleGrid>();
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
                grid.move(i);
                if(!frontier.Contains(grid) || explored.Contains(grid))
                {
                    frontier.Enqueue(grid);
                }
            }
        }
        return false;
    }
        
    }
}
