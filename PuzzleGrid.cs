using System;
using System.Collections.Generic;

namespace AI_puzzle
{
   public class PuzzleGrid
    {
        public int gridSize;
        public int[,] grid; // <int, Field> ?

        public PuzzleGrid(int _gridSize)
        {
            this.gridSize = _gridSize;       

            this.grid = new int[4,4];
            for (int x = 0; x < gridSize; x++)
            {
                for(int y = 0; y < gridSize; y++)
                {
                    // ??
                }
            }

        }

         public PuzzleGrid(PuzzleGrid _previousGrid)
        {
            this.gridSize = _previousGrid.gridSize;       
            for (int x = 0; x < gridSize; x++)
            {
                for(int y = 0; y < gridSize; y++)
                {
                    this.grid[x,y] = _previousGrid.grid[x,y];
                }
            }

        }

        public void printGrid()
        {
            for(int y = 0; y < gridSize; y++)
            {
                var temp = "";
                for(int x = 0; x < gridSize; x++)
                {
                    temp += grid[x,y].ToString()+ " ";  
                }
                Console.WriteLine(temp);
            }
        }

        public PuzzleGrid GetGrid()
        {
            return this;
        }
    }
}
