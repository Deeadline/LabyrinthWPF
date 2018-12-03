using System.Linq;
using Labirynt.Elements;
using Labirynt.Elements.Utils;
using Labirynt.Factory;
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
        private Player player;

        private Maze maze;

        public MainWindow()
        {
            InitializeComponent();

            Initialize();

            KeyDown += MainWindow_KeyDown;
        }

        private void Initialize()
        {
            var values = Level.CreateMaze("SampleLevel.txt");
            maze = values.Item1;
            player = values.Item2;

            InitializeElements();
            InitializeBoard();
            InitializePlayer();
        }

        private void InitializePlayer()
        {
            Grid.Children.Add(player.GraphicRepresentation.Rectangle);
            Grid.SetColumn(player.GraphicRepresentation.Rectangle, player.GraphicRepresentation.Position.X);
            Grid.SetRow(player.GraphicRepresentation.Rectangle, player.GraphicRepresentation.Position.Y);
        }

        private void InitializeElements()
        {
            foreach (var element in maze.Elements)
            {
                Grid.Children.Add(element.GraphicRepresentation.Rectangle);
                Grid.SetColumn(element.GraphicRepresentation.Rectangle, element.GraphicRepresentation.Position.X);
                Grid.SetRow(element.GraphicRepresentation.Rectangle, element.GraphicRepresentation.Position.Y);
            }
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            Coordinate coordinate;
            if (e.Key == Key.W)
            {
                coordinate = player.GetMoveCoordinates(0, -1);
                if(!player.Collider.CheckCollision(maze.Elements.Where(w=>w is Wall).ToList(), maze.MazeSize))
                    player.Move(coordinate);
            }
            else if (e.Key == Key.A)
            {
                coordinate = player.GetMoveCoordinates(-1,0);
                if (!player.Collider.CheckCollision(maze.Elements.Where(w => w is Wall).ToList(), maze.MazeSize))
                    player.Move(coordinate);
            }
            else if (e.Key == Key.S)
            {
                coordinate = player.GetMoveCoordinates(0, 1);
                if (!player.Collider.CheckCollision(maze.Elements.Where(w => w is Wall).ToList(), maze.MazeSize))
                    player.Move(coordinate);
            }
            else if (e.Key == Key.D)
            {
                coordinate = player.GetMoveCoordinates(1,0);
                if (!player.Collider.CheckCollision(maze.Elements.Where(w => w is Wall).ToList(), maze.MazeSize))
                    player.Move(coordinate);
            }
            player.Redraw();
        }

        private void InitializeBoard()
        {
            for (var i = 0; i < maze.MazeSize.X; i++)
                Grid.RowDefinitions.Add(new RowDefinition());

            for (var i = 0; i < maze.MazeSize.Y; i++)
                Grid.ColumnDefinitions.Add(new ColumnDefinition());
        }
    }
}
