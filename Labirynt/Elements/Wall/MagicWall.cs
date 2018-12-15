using System.Windows.Media;
using Labirynt.Elements.Interface;
using Labirynt.Elements.Utils;

namespace Labirynt.Elements.Wall
{
    public class MagicWall : IWall
    {
        public GraphicRepresentation GraphicRepresentation { get; set; }
        public IMazeElement Make(Coordinate coordinate)
        {
            return new MagicWall { GraphicRepresentation = new GraphicRepresentation(coordinate, Brushes.Transparent) };
        }
    }
}