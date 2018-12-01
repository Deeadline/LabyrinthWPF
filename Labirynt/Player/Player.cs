using System.Windows.Controls;
using System.Windows.Media;

namespace Labirynt.Player
{
    public class MyPlayer
    {
        public PlayerRepresentation GraphicPlayerRepresentation { get; set; }

        public MyPlayer() => GraphicPlayerRepresentation = new PlayerRepresentation(20, 0)
        {
            GraphicRepresentation = { Width = 10, Height = 10, Fill = Brushes.Red }
        };

        public void RedrawPlayer()
        {
            Grid.SetColumn(GraphicPlayerRepresentation.GraphicRepresentation, GraphicPlayerRepresentation.X);
            Grid.SetRow(GraphicPlayerRepresentation.GraphicRepresentation, GraphicPlayerRepresentation.Y);
        }
    }
}
