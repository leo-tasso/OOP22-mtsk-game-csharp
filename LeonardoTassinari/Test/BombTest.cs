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
    public class BombTest
    {
        private static readonly int SIDE = 20;
        private static readonly int ITERATIONS = 100;
        private static readonly long DELTA = 15;

        [Test]
        public void TimeDec()
        {
            CtsBomb b = new CtsBomb(Point2D.Origin, SIDE, ColorRGB.Black);
            long start = b.Timer;
            for (int i = 0; i < ITERATIONS; i++)
            {
                b.UpdatePhysics(DELTA, null);
                Console.WriteLine(b.Timer.ToString());
            }
            Assert.True(start > b.Timer);
        }
    }
}
