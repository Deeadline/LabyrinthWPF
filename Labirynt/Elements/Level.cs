using System;
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

        public int SizeX;
        public int SizeY;

        public static Level FromTxt(string levelName)
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/Levels/" + levelName;
            var lines = File.ReadAllLines(path);

            Level level = new Level();
            level.ObstaclePositions = new List<Coordinate>();

            List<Coordinate> points = new List<Coordinate>();

            //First line is for spawning, last one is end point and the rest is reserved for obstacles
            for (int i = 0; i < lines.Length; i++)
            {
                int[] cords = lines[i].Split(';').Select(Int32.Parse).ToArray();

                points.Add(new Coordinate(cords[0], cords[1]));

                if (i == 0)
                {
                    level.StartPosition = new Coordinate(cords[0], cords[1]);
                }
                else if(i == lines.Length-1)
                {
                    level.EndPosition = new Coordinate(cords[0], cords[1]);
                }
                else
                  level.ObstaclePositions.Add(new Coordinate(cords[0], cords[1]));
            }

            level.SizeX = points.Max(x => x.X) + 1;
            level.SizeY = points.Max(x => x.Y) + 1;

            return level;
        }
    }
}
