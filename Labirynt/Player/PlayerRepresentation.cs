using System.Windows.Shapes;

namespace Labirynt.Player
{
    public class PlayerRepresentation
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Rectangle GraphicRepresentation { get; }
        public PlayerRepresentation(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
