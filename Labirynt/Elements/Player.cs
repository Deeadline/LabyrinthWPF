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

        public Player(int boardWidthParam, int boardHeightParam)
        {
            PlayerRectangle = new Rectangle();
            PlayerRectangle.Fill = Brushes.Orange;

            this.boardWidth = boardWidthParam;
            this.boardHeight = boardHeightParam;
        }

        public void Move(int dirX,int dirY)
        {
            int rowToSet = Grid.GetRow(PlayerRectangle) + dirY;
            int colToSet = Grid.GetColumn(PlayerRectangle) + dirX;

            if (colToSet >= 0 && colToSet < boardWidth)
                Grid.SetColumn(PlayerRectangle, Grid.GetColumn(PlayerRectangle) + dirX);

            if (rowToSet >= 0 && rowToSet < boardHeight)
                    Grid.SetRow(PlayerRectangle, Grid.GetRow(PlayerRectangle) + dirY);
        }
    }
}
