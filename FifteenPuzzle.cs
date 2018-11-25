using System;
using System.Collections.Generic;

namespace AI_puzzle
{
   public class FifteenPuzzle
    {
        private int _gridSize;
        private int _gridLength;
        private int _randomPosition;
        private int[][] _grid; // <int, Field> ?
        private List<String> _movesHistory;

        private Dictionary<int, PuzzleGrid> _gridHistory;

        private Random random;


        public FifteenPuzzle(int gridSize)
        {
            this._gridSize = gridSize;
            this._gridLength = (_gridSize * _gridSize);
            this._history = new List<String>();
            
            random = new Random();

            _grid = new Dictionary<int, int>();
            for (int i = 0; i < _gridLength; i++)
            {
                _grid[i] = 0;
            }

            initRandomGrid();
        }

        public void makeMove(char direction)
        {

        }


        public void initRandomGrid()
        {
            for (int i = 0; i < _gridLength; i++)
            {
                do
                {
                    _randomPosition = random.Next(0, _gridLength);
                } while ((_grid[_randomPosition] != 0));
                _grid[_randomPosition] = i;
                Console.WriteLine("Set value: " + i + "to the field: " + _randomPosition);
            }
        }

        public void printGrid()
        {
            for(int y = 0; y < _gridSize; y++)
            {
                var temp = "";
                for(int x = 0; x <_gridSize; x++)
                {
                    temp += _grid[(y*4 + x)].ToString()+ " ";
                    
                }
                Console.WriteLine(temp);
            }
        }
    }
}
