using System.Windows.Media;
using Labirynt.Elements.Interface;
using Labirynt.Elements.Utils;

namespace Labirynt.Elements.Door
{
    public class NormalDoor : IDoor
    {
        public GraphicRepresentation GraphicRepresentation { get; set; }
        public IMazeElement Make(Coordinate coordinate)
        {
            return new NormalDoor { GraphicRepresentation = new GraphicRepresentation(coordinate, Brushes.DarkRed) };
        }
    }
}
