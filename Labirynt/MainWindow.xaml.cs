using Labirynt.Elements;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Labirynt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Player _player;

        private Level _currentLevel;

        public MainWindow()
        {
            InitializeComponent();

            InitializeLevel();

            KeyDown += MainWindow_KeyDown;
        }

        private void InitializeLevel()
        {
            _currentLevel = Level.GenerateLevel("SampleLevel.txt");
            InitializeObstacles();
            InitializeBoard();
            InitializePlayer();
        }

        private void InitializePlayer()
        {
            _player = new Player(_currentLevel);
            Grid.Children.Add(_player.PlayerRepresentation.Rectangle);
            Grid.SetColumn(_player.PlayerRepresentation.Rectangle, _player.PlayerRepresentation.Position.X);
            Grid.SetRow(_player.PlayerRepresentation.Rectangle, _player.PlayerRepresentation.Position.Y);
        }

        private void InitializeObstacles()
        {
            foreach (var obstaclePosition in _currentLevel.ObstaclePositions)
            {
                var obstacle = new Obstacle(obstaclePosition, Brushes.Black);
                Grid.Children.Add(obstacle.ObstacleGraphicRepresentation.Rectangle);
                Grid.SetColumn(obstacle.ObstacleGraphicRepresentation.Rectangle, obstacle.ObstacleGraphicRepresentation.Position.X);
                Grid.SetRow(obstacle.ObstacleGraphicRepresentation.Rectangle, obstacle.ObstacleGraphicRepresentation.Position.Y);
            }
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W)
            {
                _player.Move(new Coordinate(0, -1));
            }
            else if (e.Key == Key.A)
            {
                _player.Move(new Coordinate(-1, 0));
            }
            else if (e.Key == Key.S)
            {
                _player.Move(new Coordinate(0, 1));
            }
            else if (e.Key == Key.D)
            {
                _player.Move(new Coordinate(1, 0));
            }
        }

        private void InitializeBoard()
        {
            for (var i = 0; i < _currentLevel.LevelDimension.Width; i++)
                Grid.ColumnDefinitions.Add(new ColumnDefinition());
            for (var i = 0; i < _currentLevel.LevelDimension.Height; i++)
                Grid.RowDefinitions.Add(new RowDefinition());
        }
    }
}
