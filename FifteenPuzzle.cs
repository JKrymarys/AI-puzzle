using System;
using System.Collections.Generic;

namespace AI_puzzle
{
   public class FifteenPuzzle
    {
        private bool isSolvable;
        private PuzzleGrid _grid;
        public Algorithms _algorithms;
        public void solve(Algorithms _algorithm) 
        {}

        public FifteenPuzzle(int gridSize)
        {
            _grid = new PuzzleGrid(gridSize);
            _algorithms = new Algorithms();
        }

    }
}
