using Labirynt.Elements.Utils;
using System.Collections.Generic;

namespace Labirynt.Elements
{
    public class Maze
    {
        public IList<MazeElement> Elements { get; set; }
        public Coordinate FinishCoordinate { get; set; }
        public Coordinate MazeSize { get; set; }
    }
}
