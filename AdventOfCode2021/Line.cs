using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    internal class Line
    {
        public  int StartX { get; set; }
        public int StartY { get; set; }
        public int EndX { get; set; }
        public int EndY { get; set; }

        public Line(string input)
        {
            var parts = input.Split(" -> ");

            var startCoords = parts[0].Split(',');
            var endCoords = parts[1].Split(',');
            StartX = int.Parse(startCoords[0]);
            StartY = int.Parse(startCoords[1]);
            EndX = int.Parse(endCoords[0]);
            EndY = int.Parse(endCoords[1]);
        }
    }
}
