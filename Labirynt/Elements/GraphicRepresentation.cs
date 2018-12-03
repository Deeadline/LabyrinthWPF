using System.Windows.Media;
using System.Windows.Shapes;

namespace Labirynt.Elements
{
    public class GraphicRepresentation
    {
        public Rectangle Rectangle { get; set; }
        public Coordinate Position { get; set; }

        public GraphicRepresentation(Coordinate graphicCoordinate, Brush color)
        {
            Rectangle = new Rectangle
            {
                Fill = color
            };
            Position = graphicCoordinate;
        }
    }
}
