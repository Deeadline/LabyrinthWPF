using System.Windows.Media;
using Labirynt.Elements.Utils;

namespace Labirynt.Elements
{
    public class Room : MazeElement
    {
        public override MazeElement Make(Coordinate coordinate)
        {
            return new Room { GraphicRepresentation = new GraphicRepresentation(coordinate, Brushes.Tomato) };
        }
    }
}
