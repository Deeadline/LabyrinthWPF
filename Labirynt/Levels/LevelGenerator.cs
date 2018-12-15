using Labirynt.Elements;
using Labirynt.Elements.Interface;
using Labirynt.Elements.Player;
using Labirynt.Elements.Utils;
using Labirynt.Factory.MainFactory;
using System;
using System.Collections.Generic;
using System.IO;

namespace Labirynt.Levels
{
    public class LevelGenerator
    {
        private static MazeAbstractFactory _factory;

        public static Tuple<Maze, IPlayer> CreateLevel(string levelName)
        {
            var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent?.FullName + "/Levels/" + levelName;
            var maze = new Maze
            {
                Elements = new List<IMazeElement>()
            };
            IPlayer player;
            using (var reader = new StreamReader(path))
            {
                //bierzemy pierwsza linijke z pliku i okreslamy wielkosc labiryntu
                var line = reader.ReadLine().Split(' ');
                maze.MazeSize = new Coordinate(int.Parse(line[0]), int.Parse(line[1]));
                //kolejna linijka ustawia nam gracza na startowej pozycji
                line = reader.ReadLine().Split(' ');
                player = new Player(new Coordinate(int.Parse(line[0]), int.Parse(line[1])));
                /*kolejna linijka okresla gdzie jest koniec labiryntu(meta albo przejscie na nastepny)
                + kolejna linijka rodzaj labiryntu
                */
                line = reader.ReadLine().Split(' ');
                maze.FinishCoordinate = new Coordinate(int.Parse(line[0]), int.Parse(line[1]));
                maze.MazeType = reader.ReadLine();
                _factory = MazeFactoryProducer.GetMazeAbstractFactory(maze.MazeType);

                for (var i = 0; i < maze.MazeSize.X; i++)
                {
                    line = reader.ReadLine().Split(' ');
                    for (var j = 0; j < maze.MazeSize.Y; j++)
                    {
                        maze.Elements.Add(_factory.CreateMazeElement(int.Parse(line[j]), new Coordinate(i, j)));
                    }
                }
            }
            
            return Tuple.Create(maze, player);
        }
    }
}