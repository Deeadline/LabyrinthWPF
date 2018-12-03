namespace Labirynt.Elements.Utils
{
    public class Dimension
    {
        public int Width { get; protected set; }
        public int Height { get; protected set; }

        public Dimension(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
