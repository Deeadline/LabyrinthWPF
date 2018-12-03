using System.Windows.Media;

namespace Labirynt.Elements
{
    public class Obstacle
    {
        public GraphicRepresentation ObstacleGraphicRepresentation { get; set; }

        public Obstacle(Coordinate coordinate, Brush color) => ObstacleGraphicRepresentation =
            new GraphicRepresentation(coordinate, color);
    }
}
