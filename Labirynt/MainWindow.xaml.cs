using Labirynt.Player;
using System.Windows;

namespace Labirynt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MyPlayer player;
        private static readonly int TileSize = 10;

        public MainWindow() => InitializeComponent();//InitializeBoard();

        private void InitializeBoard()
        {
            //TODO
        }
    }
}
