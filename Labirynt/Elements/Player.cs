using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;

namespace Labirynt.Elements
{
    public class Player
    {
        public GraphicRepresentation PlayerRepresentation { get; set; }
        public Dimension LevelDimension { get; set; }
        private readonly Coordinate _goal;
        private readonly List<Coordinate> _obstaclePositions;

        public Player(Level level)
        {
            PlayerRepresentation = new GraphicRepresentation(level.StartPosition, Brushes.DarkOrange);
            LevelDimension = level.LevelDimension;
            _obstaclePositions = level.ObstaclePositions;
            _goal = level.EndPosition;
        }

        public void Move(Coordinate moveCoordinate)
        {

            var rowToSet = Grid.GetRow(PlayerRepresentation.Rectangle) + moveCoordinate.Y;
            var colToSet = Grid.GetColumn(PlayerRepresentation.Rectangle) + moveCoordinate.X;

            //Collision
            if (CheckCollision(colToSet, rowToSet))
                return;
            PlayerRepresentation.Position.X = colToSet;
            PlayerRepresentation.Position.Y = rowToSet;
            //If not set new position
            Redraw();

            //Check if win
            CheckWin(colToSet, rowToSet);
        }

        private void Redraw()
        {
            Grid.SetColumn(PlayerRepresentation.Rectangle, PlayerRepresentation.Position.X);
            Grid.SetRow(PlayerRepresentation.Rectangle, PlayerRepresentation.Position.Y);
        }

        private bool CheckCollision(int x, int y)
        {
            if (x < 0 || x >= LevelDimension.Width)
                return true;

            if (y < 0 || y >= LevelDimension.Height)
                return true;
            var f = _obstaclePositions.Any(t => t.X == x && t.Y == y);
            return f;
        }

        private void CheckWin(int x, int y)
        {
            if (x == _goal.X && y == _goal.Y)
            {
                System.Diagnostics.Debug.WriteLine("Level finished");
            }
        }
    }
}
