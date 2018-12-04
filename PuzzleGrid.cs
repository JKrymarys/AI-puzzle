using System;
using System.Collections.Generic;

namespace AI_puzzle
{
    public class PuzzleGrid
    {
        public int gridSize;
        public int[,] grid; // <int, Field> ?
        static public int[,] goalGrid;
        private int _zeroRow;
        private int _zeroColumn;
        //first init 

        private int getInvCount(int[,] grid)
        {
            int inversCount = 0;
            for (int x = 0; x < gridSize; x++) 
            { 
                for (int y = 0; y < gridSize; y++) 
                {
                    for (int m = x + 1; m < gridSize - 1; m++)
                    {
                        for (int n = y + 1; n < gridSize - 1; n++)
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
            if (gridSize % 2 != 0)
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

        public PuzzleGrid(int[,] grid, int zeroRow)
        {
            this._zeroRow = zeroRow;
            if (isSolvable())
            {
                this.grid = grid;
                Console.WriteLine("xd");
            } else {
                Console.WriteLine("dupa");
            }
        }


        //copy contructor
        public PuzzleGrid(PuzzleGrid _previousGrid)
        {
            this.gridSize = _previousGrid.gridSize;

            for (int x = 0; x < gridSize; x++)
            {
                for (int y = 0; y < gridSize; y++)
                {
                    this.grid[x, y] = _previousGrid.grid[x, y];
                }
            }

        }

        public void printGrid()
        {
            for (int y = 0; y < gridSize; y++)
            {
                var temp = "";
                for (int x = 0; x < gridSize; x++)
                {
                    temp += grid[x, y].ToString() + " ";
                }
                Console.WriteLine(temp);
            }
        }

        public bool checkIfSolved()
        {
            for (int y = 0; y < gridSize; y++)
            {
                for (int x = 0; x < gridSize; x++)
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
                this._zeroColumn >= (this.gridSize - 1) ||
                this._zeroRow <= 0 ||
                this._zeroRow >= (this.gridSize - 1))
            {
                return false;
            }


            switch (direction)
            {
                case 'U':
                    moveUp();
                    return true;
                    break;
                case 'D':
                    moveDown();
                    return true;
                    break;
                case 'L':
                    moveLeft();
                    return true;
                    break;
                case 'R':
                    moveRigth();
                    return true;
                    break;
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
