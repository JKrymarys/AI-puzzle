using System;
using System.Collections.Generic;

namespace AI_puzzle
{
    public class PuzzleGrid
    {
        public int _gridSize;
        public int[,] grid; // <int, Field> ?
        static public int[,] goalGrid;
        private int _zeroRow;
        private int _zeroColumn;
        //first init 

        private int getInvCount(int[,] grid)
        {
            int inversCount = 0;
            for (var x = 0; x < _gridSize; x++) 
            { 
                for (var y = 0; y < _gridSize; y++) 
                {
                    for (var m = x; m < _gridSize; m++)
                    {
                        for (var n = y; n < _gridSize; n++)
                        {
                            if (grid[x,y] > grid[m,n]) 
                                inversCount++;
                        }
                    }
                } 
            } 
            return inversCount; 
        }

        public bool isSolvable()
        {
            bool solvable = false;
            int inversionsCount = getInvCount(grid);
            if (_gridSize % 2 != 0)
            {
                if(inversionsCount % 2 == 0)
                    solvable = true;
            } else {
                if (_zeroRow % 2 == 0)
                {
                    if (inversionsCount % 2 == 0)
                        solvable = true;
                }
                else
                {
                    if (inversionsCount % 2 != 0)
                        solvable = true;
                }
            }
            return solvable;
        }

        public PuzzleGrid(int[,] grid)
        {
            this._gridSize = grid.GetLength(0);
            var index = 0;
            foreach (int element in grid) {
                if (element == 0) {
                    _zeroRow = (index / _gridSize) + 1;
                }
                index++;
            }
            this.grid = grid;
            if (!isSolvable())
            {
                Console.WriteLine("Non solvable!");
            }
        }


        //copy contructor
        public PuzzleGrid(PuzzleGrid _previousGrid)
        {
            this._gridSize = _previousGrid._gridSize;

            for (var x = 0; x < _gridSize; x++)
            {
                for (var y = 0; y < _gridSize; y++)
                {
                    this.grid[x, y] = _previousGrid.grid[x, y];
                }
            }

        }

        public void printGrid()
        {
            for (int y = 0; y < _gridSize; y++)
            {
                var temp = "";
                for (int x = 0; x < _gridSize; x++)
                {
                    temp += grid[x, y].ToString() + " ";
                }
                Console.WriteLine(temp);
            }
        }

        public bool checkIfSolved()
        {
            for (int y = 0; y < _gridSize; y++)
            {
                for (int x = 0; x < _gridSize; x++)
                {
                    if (this.grid[x, y] != goalGrid[x, y])
                        return false;
                }
            }
            return true;
        }


        public bool move(char direction)
        {

            if (this._zeroColumn <= 0 ||
                this._zeroColumn >= (this._gridSize - 1) ||
                this._zeroRow <= 0 ||
                this._zeroRow >= (this._gridSize - 1))
            {
                return false;
            }


            switch (direction)
            {
                case 'U':
                    moveUp();
                    return true;
                case 'D':
                    moveDown();
                    return true;
                case 'L':
                    moveLeft();
                    return true;
                case 'R':
                    moveRigth();
                    return true;
                default:
                    return false;
            }
        }

        private void moveUp()
        {
            int temp = this.grid[this._zeroRow - 1, this._zeroColumn];
            this.grid[this._zeroRow - 1, this._zeroColumn] = 0;
            this.grid[this._zeroRow, this._zeroColumn] = temp;
            this._zeroRow = this._zeroRow - 1;
        }
        private void moveDown()
        {
            int temp = this.grid[this._zeroRow + 1, this._zeroColumn];
            this.grid[this._zeroRow + 1, this._zeroColumn] = 0;
            this.grid[this._zeroRow, this._zeroColumn] = temp;
            this._zeroRow = this._zeroRow + 1;
        }
        private void moveLeft()
        {
            int temp = this.grid[this._zeroRow, this._zeroColumn - 1];
            this.grid[this._zeroRow, this._zeroColumn - 1] = 0;
            this.grid[this._zeroRow, this._zeroColumn] = temp;
            this._zeroColumn = this._zeroColumn - 1;
        }
        private void moveRigth()
        {
            int temp = this.grid[this._zeroRow, this._zeroColumn + 1];
            this.grid[this._zeroRow, this._zeroColumn + 1] = 0;
            this.grid[this._zeroRow, this._zeroColumn] = temp;
            this._zeroColumn = this._zeroColumn + 1;
        }
    }
}
