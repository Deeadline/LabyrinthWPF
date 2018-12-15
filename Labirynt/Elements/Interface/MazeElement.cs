using Labirynt.Elements.Utils;

namespace Labirynt.Elements.Interface
{
    public interface IMazeElement
    {
        GraphicRepresentation GraphicRepresentation { get; set; }
        IMazeElement Make(Coordinate coordinate);
    }
}
