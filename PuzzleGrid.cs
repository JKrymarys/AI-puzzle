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

        //not sure if we need dictionary, can be changed to sth else
        private List<int[,]> doneMoves;

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
                            if (grid[x, y] > grid[m, n])
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
                if (inversionsCount % 2 == 0)
                    solvable = true;
            }
            else
            {
                if (_zeroRow % 2 != 0)
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
            foreach (int element in grid)
            {
                if (element == 0)
                {
                    _zeroRow = (index / _gridSize);
                    _zeroColumn = (index % _gridSize);
                }
                index++;
            }
            this.grid = grid;
            doneMoves = new List<int[,]>();
            doneMoves.Add(grid);
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
                    temp += grid[y, x].ToString() + " ";
                }
                Console.WriteLine(temp);
            }
        }

        public bool checkIfSolved()
        {
            bool solved = false;
            int i = 0;
            for (int y = 0; y < _gridSize; y++)
            {
                for (int x = 0; x < _gridSize; x++)
                {
                    if(this.grid[y, x] == i)
                    {
                        solved = true;
                    }
                    else
                    {
                        return false;
                    }
                    i++;
                }
            }
            return solved;
        }


        public bool move(char direction)
        {
            var copy_of_grid = this.grid;
            int i = 0;
            int j = 0;

            switch (direction)
            {
                case 'U':
                    {
                        if(this._zeroRow - 1 < 0)
                            return false;
                        var temp = copy_of_grid[this._zeroRow - 1, this._zeroColumn];
                        copy_of_grid[this._zeroRow - 1, this._zeroColumn] = 0;
                        copy_of_grid[this._zeroRow, this._zeroColumn] = temp;
                        i = -1;
                        break;
                    }
                case 'D':
                    {
                        if(this._zeroRow + 1 >= this._gridSize)
                            return false;
                        var temp = copy_of_grid[this._zeroRow + 1, this._zeroColumn];
                        copy_of_grid[this._zeroRow + 1, this._zeroColumn] = 0;
                        copy_of_grid[this._zeroRow, this._zeroColumn] = temp;
                        i = 1;
                       break;
                    }

                case 'L':
                    {
                        if (this._zeroColumn - 1 < 0)
                            return false;
                        int temp = copy_of_grid[this._zeroRow, this._zeroColumn - 1];
                        copy_of_grid[this._zeroRow, this._zeroColumn - 1] = 0;
                        copy_of_grid[this._zeroRow, this._zeroColumn] = temp;
                        j = -1;
                        break;
                    }

                case 'R':
                    {
                        if (this._zeroColumn + 1 >= this._gridSize)
                            return false;
                        int temp = copy_of_grid[this._zeroRow, this._zeroColumn + 1];
                        copy_of_grid[this._zeroRow, this._zeroColumn + 1] = 0;
                        copy_of_grid[this._zeroRow, this._zeroColumn] = temp;
                        j = 1;
                       break;
                    }

                default:
                    return false;
            }

            if (!doneMoves.Contains(copy_of_grid))
            {
                this.grid = copy_of_grid;
                this._zeroRow = this._zeroRow + i;
                this._zeroColumn = this._zeroColumn + j;
            } 

            doneMoves.Add(this.grid);

            this.printGrid();
            Console.WriteLine();
            return true;
        }
    }
}
