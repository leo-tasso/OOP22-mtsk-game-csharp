using System.Collections.Generic;
using System;

namespace OOP22_mtsk_game_csharp.LeonardoTassinari.Game
{
    public class RectangleHitBoxModel : IHitBoxModel
    {
        private readonly List<double> _sizes;
        public RectangleHitBoxModel(double side1, double side2)
        {
            _sizes = new List<double>
            {
                side1,
                side2
            };
        }

        public IList<double> GetSizes()
        {
            return new List<double>(_sizes);
        }
    }
}