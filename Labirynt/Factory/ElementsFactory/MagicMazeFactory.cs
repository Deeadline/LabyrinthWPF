using Labirynt.Elements.Door;
using Labirynt.Elements.Ground;
using Labirynt.Elements.Interface;
using Labirynt.Elements.Utils;
using Labirynt.Elements.Wall;
using Labirynt.Factory.MainFactory;

using System.Collections.Generic;

namespace Labirynt.Factory.ElementsFactory
{
    public class MagicMazeFactory : MazeAbstractFactory
    {
        private readonly Dictionary<int, IMazeElement> magicDictionary = new Dictionary<int, IMazeElement>
        {
            {0, new MagicGround()},
            {1, new MagicWall()},
            {2, new MagicDoor()}
        };

        public override IMazeElement CreateMazeElement(int type, Coordinate coordinate)
        {
            return magicDictionary[type].Make(coordinate);
        }
    }
}
