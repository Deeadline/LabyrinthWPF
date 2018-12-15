using Labirynt.Elements.Utils;

using System.Windows.Controls;
using System.Windows.Media;

namespace Labirynt.Elements.Player
{
    public class Player : IPlayer
    {
        public Collision Collider { get; set; }
        public GraphicRepresentation GraphicRepresentation { get; set; }

        public Player(Coordinate coordinate)
        {
            GraphicRepresentation = new GraphicRepresentation(coordinate, Brushes.LightSteelBlue);
            Collider = new Collision();
        }

        public Coordinate GetMoveCoordinates(int x, int y)
        {
            var colToSet = Grid.GetColumn(GraphicRepresentation.Rectangle) + x;
            var rowToSet = Grid.GetRow(GraphicRepresentation.Rectangle) + y;
            Collider.Coordinate = new Coordinate(colToSet, rowToSet);
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