using Labirynt.Player;
using System.Windows;
using System.Windows.Controls;

namespace Labirynt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int BoardWidth = 16;
        private int BoardHeight = 16;

        public MainWindow()
        {
            InitializeComponent();

            InitializeBoard();
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
