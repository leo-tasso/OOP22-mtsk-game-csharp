﻿using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;
using System.Drawing;

namespace OOP22_mtsk_game_csharp.LeonardoTassinari.game
{
    internal class CircleAspect : IAspectModel
    {
        private readonly double _radius;
        private readonly ColorRGB _color;

        public CircleAspect(double radius, ColorRGB color)
        {
            _radius = radius;
            _color = color;
        }
        public void Update(GameObject obj, IDrawings drawing)
        {
            drawing.DrawCircle(obj, _color, _radius);
        }
    }
}