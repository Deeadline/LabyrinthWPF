using Labirynt.Elements;
using Labirynt.Elements.Utils;
using System.Collections.Generic;

namespace Labirynt.Factory
{
    public class MazeElementManager
    {
        private readonly Dictionary<int, MazeElement> mazeElementDictionary = new Dictionary<int, MazeElement>
        {
            {0, new Room()},
            {1, new Wall()},
            {2, new Player() }
        };

        public MazeElement CreateMazeElement(int type, Coordinate coordinate)
        {
            return mazeElementDictionary[type].Make(coordinate);
        }

    }
}
