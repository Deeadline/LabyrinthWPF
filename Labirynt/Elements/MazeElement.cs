using Labirynt.Elements.Utils;

namespace Labirynt.Elements
{
    public abstract class MazeElement
    {
        public GraphicRepresentation GraphicRepresentation { get; set; }
        public abstract MazeElement Make(Coordinate coordinate);
    }
}
