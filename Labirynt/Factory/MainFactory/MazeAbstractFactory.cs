using Labirynt.Elements.Interface;
using Labirynt.Elements.Utils;

namespace Labirynt.Factory.MainFactory
{
    public abstract class MazeAbstractFactory
    {
        public abstract IMazeElement CreateMazeElement(int type, Coordinate coordinate);
    }
}
