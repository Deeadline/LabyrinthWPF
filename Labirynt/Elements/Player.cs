using System;
using Labirynt.Elements.Utils;
using System.Windows.Controls;
using System.Windows.Media;

namespace Labirynt.Elements
{
    public class Player : MazeElement
    {
        public Collision Collider { get; set; }
        public override MazeElement Make(Coordinate coordinate)
        {
            return new Player
            {
                GraphicRepresentation = new GraphicRepresentation(coordinate, Brushes.DarkOrange),
                Collider = new Collision()
            };
        }

        public Coordinate GetMoveCoordinates(int x, int y)
        {
            var colToSet = Grid.GetColumn(GraphicRepresentation.Rectangle) + x;
            var rowToSet = Grid.GetRow(GraphicRepresentation.Rectangle) + y;
            Collider.Coordinate = new Coordinate(colToSet,rowToSet);
            return Collider.Coordinate;
        }

        public void Move(Coordinate moveCoordinate)
        {
            GraphicRepresentation.Position = moveCoordinate;
        }

        public void Redraw()
        {
            Grid.SetColumn(GraphicRepresentation.Rectangle, GraphicRepresentation.Position.X);
            Grid.SetRow(GraphicRepresentation.Rectangle, GraphicRepresentation.Position.Y);
        }

    }
}
