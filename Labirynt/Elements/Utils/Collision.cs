using System.Collections.Generic;
using System.Linq;

namespace Labirynt.Elements.Utils
{
    public class Collision
    {
        public Coordinate Coordinate { get; set; }

        public bool CheckCollision(List<MazeElement> walls, Coordinate mazeSize)
        {
            if (Coordinate.X < 0 || Coordinate.X >= mazeSize.X)
                return true;

            if (Coordinate.Y < 0 || Coordinate.Y >= mazeSize.Y)
                return true;
            var f = walls.Any(w =>
                w.GraphicRepresentation.Position.X == Coordinate.X && w.GraphicRepresentation.Position.Y == Coordinate.Y);

            return f;
        }

        public void CheckWin(Coordinate endCoordinate)
        {
            if (Coordinate.X == endCoordinate.X && Coordinate.Y== endCoordinate.Y)
            {
                System.Diagnostics.Debug.WriteLine("Level finished");
            }
        }
    }
}
