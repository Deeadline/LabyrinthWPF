using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Labirynt.Elements
{
    public class Obstacle
    {
        public Rectangle obstacleRect;

        public int X { get; }
        public int Y { get; }

        public Obstacle(int x,int y)
        {
            obstacleRect = new Rectangle();
            obstacleRect.Fill = Brushes.Black;

            this.X = x;
            this.Y = y;
        }
    }
}
