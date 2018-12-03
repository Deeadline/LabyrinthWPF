using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Labirynt.Elements
{
    public class Level
    {
        public Coordinate StartPosition;
        public List<Coordinate> ObstaclePositions;
        public Coordinate EndPosition;
        public Dimension LevelDimension;

        public static Level GenerateLevel(string levelName)
        {
            var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent?.FullName + "/Levels/" + levelName;
            var lines = File.ReadAllLines(path);

            var level = new Level
            {
                ObstaclePositions = new List<Coordinate>()
            };

            //First line is for spawning, last one is end point and the rest is reserved for obstacles
            for (var i = 0; i < lines.Length; i++)
            {
                var cords = lines[i].Split(';').Select(int.Parse).ToArray();

                if (i == 0)
                    level.LevelDimension = new Dimension(cords[0], cords[1]);
                else if (i == 1)
                    level.StartPosition = new Coordinate(cords[0], cords[1]);
                else if (i == lines.Length - 1)
                    level.EndPosition = new Coordinate(cords[1], cords[0]);
                else
                    level.ObstaclePositions.Add(new Coordinate(cords[0], cords[1]));
            }
            //level.LevelDimension = new Dimension(points.Max(x => x.X) + 1, points.Max(x => x.Y) + 1);
            return level;
        }
    }
}
