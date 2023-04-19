
using NUnit.Framework;
using System.Collections.Generic;

namespace OOP22_mtsk_game_csharp.LeonardoTassinari.game
{
    internal class NullHitBoxModel : IHitBoxModel
    {
        public IList<double> GetSizes()
        {
            return new List<double>();
        }
    }
}
