using Labirynt.Elements.Door;
using Labirynt.Elements.Ground;
using Labirynt.Elements.Interface;
using Labirynt.Elements.Utils;
using Labirynt.Elements.Wall;
using Labirynt.Factory.MainFactory;

using System.Collections.Generic;

namespace Labirynt.Factory.ElementsFactory
{
    public class NormalMazeFactory : MazeAbstractFactory
    {
        private readonly Dictionary<int, IMazeElement> normalDictionary = new Dictionary<int, IMazeElement>
        {
            {0, new NormalGround()},
            {1, new NormalWall()},
            {2, new NormalDoor()}
        };

        public override IMazeElement CreateMazeElement(int type, Coordinate coordinate)
        {
            return normalDictionary[type].Make(coordinate);
        }
    }
}
