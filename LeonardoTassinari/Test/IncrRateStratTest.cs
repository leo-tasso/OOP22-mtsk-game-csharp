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
        private const double MaxBombRate = 0.7;
        private const double BombSpawnDiff = 1.05;
        private const long Start1 = 1000;
        private const long Start2 = 30_000;
        private const long Range = 20_000;
        private const long FlatStart1 = 50_000;
        private const long FlatStart2 = 90_000;
        private readonly IncrRateStrat _s = new IncrRateStrat(BombSpawnDiff, MaxBombRate);

        [Test]
        public void IsIncreasing()
        {

            Assert.True(_s.Invoke(Start1 + Range) - _s.Invoke(Start1) < _s.Invoke(Start2 + Range) - _s.Invoke(Start2));
        }

        [Test]
        public void IsFlattening()
        {

            Assert.AreEqual(_s.Invoke(FlatStart1 + Range) - _s.Invoke(FlatStart1), _s.Invoke(FlatStart2 + Range)
                    - _s.Invoke(FlatStart2));
        }
    }
}
