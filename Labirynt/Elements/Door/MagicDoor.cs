using Labirynt.Elements.Utils;
using System.Windows.Media;
using Labirynt.Elements.Interface;

namespace Labirynt.Elements.Door
{
    public class MagicDoor : IDoor
    {
        public GraphicRepresentation GraphicRepresentation { get; set; }

        public IMazeElement Make(Coordinate coordinate)
        {
            return new NormalDoor {GraphicRepresentation = new GraphicRepresentation(coordinate, Brushes.DarkOrange)};
        }
    }
}
