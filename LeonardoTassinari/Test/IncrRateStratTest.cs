using NUnit.Framework;
using OOP22_mtsk_game_csharp.LeonardoTassinari.game;
using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP22_mtsk_game_csharp.LeonardoTassinari.test
{
    [TestFixture]
    public class IncrRateStratTest
    {
        private static readonly double MAX_BOMB_RATE = 0.7;
        private static readonly double BOMB_SPAWN_DIFF = 1.05;
        private static readonly long START1 = 1000;
        private static readonly long START2 = 30_000;
        private static readonly long RANGE = 20_000;
        private static readonly long FLAT_START1 = 50_000;
        private static readonly long FLAT_START2 = 90_000;
        private readonly IncrRateStrat s = new IncrRateStrat(BOMB_SPAWN_DIFF, MAX_BOMB_RATE);

        [Test]
        public void IsIncreasing()
        {

            Assert.True(s.Invoke(START1 + RANGE) - s.Invoke(START1) < s.Invoke(START2 + RANGE) - s.Invoke(START2));
        }

        [Test]
        public void IsFlattening()
        {

            Assert.AreEqual(s.Invoke(FLAT_START1 + RANGE) - s.Invoke(FLAT_START1), s.Invoke(FLAT_START2 + RANGE)
                    - s.Invoke(FLAT_START2));
        }
    }
}
