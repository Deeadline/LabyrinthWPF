using System.Windows.Media;
using Labirynt.Elements.Interface;
using Labirynt.Elements.Utils;

namespace Labirynt.Elements.Wall
{
    public class NormalWall : IWall
    {
        public GraphicRepresentation GraphicRepresentation { get; set; }
        public IMazeElement Make(Coordinate coordinate)
        {
            return new NormalWall { GraphicRepresentation = new GraphicRepresentation(coordinate, Brushes.Black) };
        }
    }
}