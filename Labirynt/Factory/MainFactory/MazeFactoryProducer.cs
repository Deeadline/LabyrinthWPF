using Labirynt.Factory.ElementsFactory;

namespace Labirynt.Factory.MainFactory
{
    public class MazeFactoryProducer
    {
        public static MazeAbstractFactory GetMazeAbstractFactory(string type)
        {
            if (type.Equals("MAGIC"))
                return new MagicMazeFactory();
            if (type.Equals("NORMAL"))
                return new NormalMazeFactory();

            return null;
        }
    }
}
