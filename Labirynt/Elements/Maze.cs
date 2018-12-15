using Labirynt.Elements.Interface;
using Labirynt.Elements.Utils;
using System.Collections.Generic;

namespace Labirynt.Elements
{
    public class Maze
    {
        public IList<IMazeElement> Elements { get; set; }
        public Coordinate FinishCoordinate { get; set; }
        public Coordinate MazeSize { get; set; }
        public string MazeType { get; set; }
    }
}
