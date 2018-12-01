using Labirynt.Elements;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Labirynt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int BoardWidth = 16;
        private int BoardHeight = 16;

        private Player player;

        public MainWindow()
        {
            InitializeComponent();
            InitializeBoard();
            InitializePlayer();

            this.KeyDown += MainWindow_KeyDown;
        }

        private void InitializePlayer()
        {        
            player = new Player(BoardWidth,BoardHeight);
            Grid.Children.Add(player.PlayerRectangle);
        }

        private void MainWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == Key.W)
            {
                player.Move(0, -1);
            }
            else if(e.Key == Key.A)
            {
                player.Move(-1, 0);
            }
            else if (e.Key == Key.S)
            {
                player.Move(0, 1);
            }
            else if (e.Key == Key.D)
            {
                player.Move(1, 0);
            }
        }

        private void InitializeBoard()
        {
            for(int i = 0;i < BoardWidth;i++)
            {
                Grid.RowDefinitions.Add(new RowDefinition()); 
            }

            for (int i = 0; i < BoardHeight; i++)
            {
                Grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        
    }
}
