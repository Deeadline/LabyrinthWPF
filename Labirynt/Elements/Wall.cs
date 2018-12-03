using System.Windows.Media;
using Labirynt.Elements.Utils;

namespace Labirynt.Elements
{
    public class Wall : MazeElement
    {
        public override MazeElement Make(Coordinate coordinate)
        {
            return new Wall {GraphicRepresentation = new GraphicRepresentation(coordinate, Brushes.Black)};
        }
    }
}
