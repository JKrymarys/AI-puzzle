using System;

namespace AI_puzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            FifteenPuzzle puzzle = new FifteenPuzzle(4);
            puzzle.printGrid();
        }
    }
}
