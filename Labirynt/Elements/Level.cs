using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Labirynt.Elements
{
    public class Level
    {
        public Coordinate StartPosition;
        public List<Coordinate> ObstaclePositions;
        public Coordinate EndPosition;

        public static Level FromTxt(string levelName)
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/Levels/" + levelName;
            var lines = File.ReadAllLines(path);

            Level level = new Level();
            level.ObstaclePositions = new List<Coordinate>();

            //First line is for spawning, last one is end point and the rest is reserved for obstacles
            for (int i = 0; i < lines.Length; i++)
            {
                int[] cords = lines[i].Split(';').Select(Int32.Parse).ToArray();

                if(i == 0)
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

            return level;
        }
    }
}
