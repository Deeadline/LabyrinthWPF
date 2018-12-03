using System;
using Labirynt.Elements;
using Labirynt.Elements.Utils;
using System.Collections.Generic;
using System.IO;

namespace Labirynt.Factory
{
    public class Level
    {
        private static MazeElementManager mazeElementManager = new MazeElementManager();

        public static Tuple<Maze,Player> CreateMaze(string levelName)
        {
            var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent?.FullName + "/Levels/" + levelName;
            var maze = new Maze
            {
                Elements = new List<MazeElement>()
            };
            Player player;
            using (var reader = new StreamReader(path))
            {
                var line = reader.ReadLine().Split(' ');
                maze.MazeSize = new Coordinate(int.Parse(line[0]), int.Parse(line[1]));
                line = reader.ReadLine().Split(' ');
                player =
                    mazeElementManager.CreateMazeElement(2, new Coordinate(int.Parse(line[0]), int.Parse(line[1]))) as Player;
                line = reader.ReadLine().Split(' ');
                maze.FinishCoordinate = new Coordinate(int.Parse(line[0]), int.Parse(line[1]));
                for (var i = 0; i < maze.MazeSize.X; i++)
                {
                    line = reader.ReadLine().Split(' ');
                    for (var j = 0; j < maze.MazeSize.Y; j++)
                    {
                        maze.Elements.Add(mazeElementManager.CreateMazeElement(int.Parse(line[j]), new Coordinate(i, j)));
                    }
                }
            }

            return Tuple.Create(maze, player);
        }
    }
}
