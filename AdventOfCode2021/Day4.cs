using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021
{
    internal class Day4
    {
        public static int Run()
        {
            List<string> lines = File.ReadAllLines("Data/Day4Input.txt").ToList();

            List<int> numbers = lines[0].Split(",").Select(x => int.Parse(x)).ToList();

            List<BingoGrid> bingoGrids = new List<BingoGrid>();
            for (int i = 2; i < lines.Count; i += 6)
            {
                List<List<int>> currentGrid = new List<List<int>>();
                for (int j = 0; j < 5; ++j)
                {
                    currentGrid.Add(lines[i + j].Split(' ').Where(x => !string.IsNullOrEmpty(x)).Select(x =>int.Parse(x)).ToList());
                }
                bingoGrids.Add(new BingoGrid(currentGrid));
            }

            for (int i = 0; i < numbers.Count; ++i)
            {
                
                foreach (var grid in bingoGrids) 
                {
                    grid.MarkNumber(numbers[i]);
                }

                if (bingoGrids.Count == 1 && bingoGrids[0].IsComplete())
                {
                    var doneGrid = bingoGrids.First(x => x.IsComplete());
                    int sum = doneGrid.UnmarkedSum();

                    return sum * numbers[i];
                }
                if (bingoGrids.Count > 1)
                {
                    bingoGrids.RemoveAll(x => x.IsComplete());
                }
            }
            return 0;
        }
    }
}
