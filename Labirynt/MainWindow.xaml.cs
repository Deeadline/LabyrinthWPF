using Labirynt.Elements;
using Labirynt.Elements.Player;
using Labirynt.Elements.Utils;
using Labirynt.Elements.Wall;
using Labirynt.Levels;

using System.Linq;
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
        private IPlayer player;
        private Maze maze;

        public MainWindow()
        {

            InitializeComponent();

            Initialize("NormalMaze.txt");

            KeyDown += MainWindow_KeyDown;
        }

        public MainWindow(string lvlName)
        {
            InitializeComponent();

            Initialize(lvlName);

            KeyDown += MainWindow_KeyDown;
        }
        private void Initialize(string levelName)
        {
            var values = LevelGenerator.CreateLevel(levelName);
            maze = values.Item1;
            player = values.Item2;

            InitializeElements();
            InitializePlayer();
            InitializeBoard();
        }
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            Coordinate coordinate;
            if (e.Key == Key.W)
            {
                coordinate = player.GetMoveCoordinates(0, -1);
                if (!player.Collider.CheckCollision(maze.Elements.Where(w => w is IWall).ToList(), maze.MazeSize))
                    player.Move(coordinate);
            }
            else if (e.Key == Key.A)
            {
                coordinate = player.GetMoveCoordinates(-1, 0);
                if (!player.Collider.CheckCollision(maze.Elements.Where(w => w is IWall).ToList(), maze.MazeSize))
                    player.Move(coordinate);
            }
            else if (e.Key == Key.S)
            {
                coordinate = player.GetMoveCoordinates(0, 1);
                if (!player.Collider.CheckCollision(maze.Elements.Where(w => w is IWall).ToList(), maze.MazeSize))
                    player.Move(coordinate);
            }
            else if (e.Key == Key.D)
            {
                coordinate = player.GetMoveCoordinates(1, 0);
                if (!player.Collider.CheckCollision(maze.Elements.Where(w => w is IWall).ToList(), maze.MazeSize))
                    player.Move(coordinate);
            }

            //TODO: Jak zmienić okienko na plik MagicMaze.txt  stąd
            if (player.Collider.CheckWin(maze.FinishCoordinate))
            {
                if (maze.MazeType.Equals("MAGIC"))
                {
                    MessageBox.Show("Wygrałeś");
                    Close();
                }
            }
             
            player.Redraw();
        }

        private void InitializePlayer()
        {
            Grid.Children.Add(player.GraphicRepresentation.Rectangle);
            Grid.SetColumn(player.GraphicRepresentation.Rectangle, player.GraphicRepresentation.Position.Y);
            Grid.SetRow(player.GraphicRepresentation.Rectangle, player.GraphicRepresentation.Position.X);
        }

        private void InitializeElements()
        {
            foreach (var element in maze.Elements)
            {
                Grid.Children.Add(element.GraphicRepresentation.Rectangle);
                Grid.SetColumn(element.GraphicRepresentation.Rectangle, element.GraphicRepresentation.Position.Y);
                Grid.SetRow(element.GraphicRepresentation.Rectangle, element.GraphicRepresentation.Position.X);
            }
        }

        private void InitializeBoard()
        {
            Grid.RowDefinitions.Clear();
            Grid.ColumnDefinitions.Clear();
            for (var i = 0; i < maze.MazeSize.X; i++)
                Grid.RowDefinitions.Add(new RowDefinition());

            for (var i = 0; i < maze.MazeSize.Y; i++)
                Grid.ColumnDefinitions.Add(new ColumnDefinition());
        }
    }
}
