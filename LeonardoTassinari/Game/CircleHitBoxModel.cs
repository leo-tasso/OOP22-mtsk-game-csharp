using System.Collections.Generic;
using System;

namespace OOP22_mtsk_game_csharp.LeonardoTassinari.Game
{
    internal class CircleHitBoxModel : IHitBoxModel
    {
        private readonly double _size;

        /**
         * Constructor for the model.
         * 
         * @param size the radius of the circle.
         */
        public CircleHitBoxModel(double size)
        {
            this._size = size;
        }

        public IList<double> GetSizes()
        {
            var l = new List<double>
            {
                this._size
            };
            return l;
        }
    }
}