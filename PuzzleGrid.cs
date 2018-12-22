using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace AI_puzzle
{
    //: IEqualityComparer<PuzzleGrid>
    public class PuzzleGrid 
    {
        public int _gridSize;
        public int[,] grid; // <int, Field> ?
        private int _zeroRow;
        private int _zeroColumn;
        //first init 
        public int _level_of_depth;
        string history;

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
                            if (grid[x, y] > grid[m, n] && grid[m, n]!=0)
                                inversCount++;
                        }
                    }
                }
            }
            // Console.WriteLine(inversCount);
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
                    if (inversionsCount % 2 != 0)
                        solvable = true;
                }
                else
                {
                    if (inversionsCount % 2 == 0)
                        solvable = true;
                }
            }
            return solvable;
        }

        public PuzzleGrid(int[,] grid)
        {
            if(this.history == null)
                this.history = "" ;
            
            this._gridSize = grid.GetLength(0);
            var index = 0;
            _level_of_depth = 0;
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

        }

        public PuzzleGrid(int[,] grid, string old_history)
        {
            this.history = old_history;
            
            this._gridSize = grid.GetLength(0);
            var index = 0;
            _level_of_depth = 0;
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

        }


        //copy contructor
        public PuzzleGrid(PuzzleGrid _previousGrid)
        {
            this._gridSize = _previousGrid._gridSize;
            this.history = _previousGrid.history;
            for (var x = 0; x < _gridSize; x++)
            {
                for (var y = 0; y < _gridSize; y++)
                {
                    this.grid[x, y] = _previousGrid.grid[x, y];
                }
            }
            this._level_of_depth = _previousGrid._level_of_depth;
            this._zeroColumn = _previousGrid._zeroColumn;
            this._zeroRow = _previousGrid._zeroRow;
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
          //  Console.WriteLine("History: " + history.ToString());
        }

        public bool checkIfSolved()
        {
            bool solved = false;
            int i = 0;
            for (int y = 0; y < _gridSize; y++)
            {
                for (int x = 0; x < _gridSize; x++)
                {
                    if (this.grid[y, x] == i)
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

        // public  bool Equals(PuzzleGrid a,PuzzleGrid b)
        // {
        //     if (a == null || b == null)
        //     {
        //         return false;
        //     }
        //     else
        //     {
        //         return (a.Equals(b));
        //     }
        // }

        public override bool Equals(Object other)
        {
            if ((other == null) || !this.GetType().Equals(other.GetType()))
            {
                return false;
            }

            else
            {
                // return (this.grid.Equals(((PuzzleGrid)other).grid));
                return this.GetHashCode().Equals(((PuzzleGrid)other).GetHashCode());
            }
        }


        public  bool Equals(PuzzleGrid other)
        {
            if (other == null)
            {
                return false;
            }
            else
            {
                return (this.Equals(other));
            }
        }



    public override int GetHashCode()
        {
            string hash = "";
            foreach (var el in this.grid )
            {
                    hash += el;
            }
            return hash.GetHashCode();
        }

        // public int GetHashCode(PuzzleGrid other)
        // {
        //     string hash = "";
        //     foreach (var el in other.grid )
        //     {
        //         hash += el;
        //     }
        //     return (Int32.Parse(hash)%(2147483646));
        // }

        public PuzzleGrid move(char direction)
        {
            var copy_of_grid = (int[,])grid.Clone();
            var copy_zeroRow = this._zeroRow;
            var copy_zeroColumn = this._zeroColumn;
            switch (direction)
            {
                case 'u':
                {
                    if (copy_zeroRow - 1 < 0)
                        return null;

                    var temp = copy_of_grid[copy_zeroRow - 1, copy_zeroColumn];
                    copy_of_grid[copy_zeroRow - 1, copy_zeroColumn] = 0;
                    copy_of_grid[copy_zeroRow, copy_zeroColumn] = temp;
                    copy_zeroRow--;
                    this.history += direction.ToString();
                    return new PuzzleGrid(copy_of_grid, this.history);
                }

                case 'd':
                {
                    if (copy_zeroRow + 1 >= this._gridSize)
                        return null;

                    var temp = copy_of_grid[copy_zeroRow + 1, copy_zeroColumn];
                    copy_of_grid[copy_zeroRow + 1, copy_zeroColumn] = 0;
                    copy_of_grid[copy_zeroRow, copy_zeroColumn] = temp;
                    copy_zeroRow++;
                    this.history += direction.ToString();
                    return new PuzzleGrid(copy_of_grid, this.history);
                }

                case 'l':
                {
                    if (copy_zeroColumn - 1 < 0)
                        return null;

                    int temp = copy_of_grid[copy_zeroRow, copy_zeroColumn - 1];
                    copy_of_grid[copy_zeroRow, copy_zeroColumn - 1] = 0;
                    copy_of_grid[copy_zeroRow, copy_zeroColumn] = temp;
                    copy_zeroColumn--;
                    this.history += direction.ToString();
                    return new PuzzleGrid(copy_of_grid, this.history);
                }

                case 'r':
                {
                    if (copy_zeroColumn + 1 >= this._gridSize)
                        return null;

                    int temp = copy_of_grid[copy_zeroRow, copy_zeroColumn + 1];
                    copy_of_grid[copy_zeroRow, copy_zeroColumn + 1] = 0;
                    copy_of_grid[copy_zeroRow, copy_zeroColumn] = temp;
                    copy_zeroColumn++;
                    this.history += direction.ToString();
                    return new PuzzleGrid(copy_of_grid, this.history);
                }

                default:
                    return null;
            }
        }

        public int manhatann_heuristic() 
        {
            int distance_sum = 0;
            int i = 0;
            foreach (int element in grid)
            {
                if(element != 0)
                {
                    var xDestCord = (element - 1) / _gridSize;
                    var yDestCord = (element - 1) % _gridSize;
                    var xDistanceFromActual = (i % _gridSize) - xDestCord;
                    var yDistanceFromActual = (i / _gridSize) - yDestCord;
                    distance_sum += Math.Abs(xDistanceFromActual) + Math.Abs(yDistanceFromActual);
                    i++;
                }
            }
            return distance_sum;
        }

        public int diagonal_heuristic()
        {
            int distance_sum = 0;
            int i = 0;
            foreach (int element in grid)
            {
                if(element != 0)
                {
                    var xDestCord = (element - 1) / _gridSize;
                    var yDestCord = (element - 1) % _gridSize;
                    var xDistanceFromActual = (i % _gridSize) - xDestCord;
                    var yDistanceFromActual = (i / _gridSize) - yDestCord;
                    distance_sum += Math.Max(Math.Abs(xDistanceFromActual), Math.Abs(yDistanceFromActual));
                    i++;
                }
            }
            return distance_sum;
        }

        public double euclides_heuristic()
        {
            double distance_sum = 0;
            int i = 0;
            foreach (int element in grid)
            {
                if(element != 0)
                {
                    var xDestCord = (element - 1) / _gridSize;
                    var yDestCord = (element - 1) % _gridSize;
                    var xDistanceFromActual = (i % _gridSize) - xDestCord;
                    var yDistanceFromActual = (i / _gridSize) - yDestCord;
                    distance_sum += Math.Sqrt(Math.Pow(xDistanceFromActual,2) + Math.Pow(yDistanceFromActual, 2));
                    i++;
                }
            }
            return distance_sum;
        }
    }
}
