﻿using System.Windows.Media;
using Labirynt.Elements.Interface;
using Labirynt.Elements.Utils;

namespace Labirynt.Elements.Ground
{
    public class NormalGround : IGround
    {
        public GraphicRepresentation GraphicRepresentation { get; set; }
        public IMazeElement Make(Coordinate coordinate)
        {
            return new NormalGround { GraphicRepresentation = new GraphicRepresentation(coordinate, Brushes.ForestGreen) };
        }
    }
}