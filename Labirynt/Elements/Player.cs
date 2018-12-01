using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Labirynt.Elements
{
    public class Player
    {
        public Rectangle PlayerRectangle;
        private int boardWidth;
        private int boardHeight;

        private Coordinate goal;
        private List<Coordinate> obstaclePositions;

        public Player(Level level)
        {
            PlayerRectangle = new Rectangle();
            PlayerRectangle.Fill = Brushes.Orange;

            this.obstaclePositions = level.ObstaclePositions;
            this.goal = level.EndPosition;

            this.boardWidth = level.SizeX;
            this.boardHeight = level.SizeY;
        }

        public void Move(int dirX,int dirY)
        {
            int rowToSet = Grid.GetRow(PlayerRectangle) + dirY;
            int colToSet = Grid.GetColumn(PlayerRectangle) + dirX;

            if (colToSet < 0 || colToSet >= boardWidth)
                return;

            if (rowToSet < 0 || rowToSet >= boardHeight)
                return;

            for(int i = 0;i < obstaclePositions.Count;i++)
            {
                if (obstaclePositions[i].X == colToSet && obstaclePositions[i].Y == rowToSet)
                    return;
            }

            Grid.SetColumn(PlayerRectangle, colToSet);
            Grid.SetRow(PlayerRectangle, rowToSet);


            if (colToSet == goal.X && rowToSet == goal.Y)
            {
                System.Diagnostics.Debug.WriteLine("Level finished");
            }
        }
    }
}
