using NUnit.Framework;
using OOP22_mtsk_game_csharp.LeonardoTassinari.Game;
using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;
using System;

namespace OOP22_mtsk_game_csharp.LeonardoTassinari.test
{
    [TestFixture]
    public class BombTest
    {
        private const int Side = 20;
        private const int Iterations = 100;
        private const long Delta = 15;

        [Test]
        public void TimeDec()
        {
            CtsBomb b = new CtsBomb(Point2D.Origin, Side, ColorRGB.Black);
            long start = b.Timer;
            for (int i = 0; i < Iterations; i++)
            {
                b.UpdatePhysics(Delta, null);
                Console.WriteLine(b.Timer.ToString());
            }
            Assert.True(start > b.Timer);
        }
    }
}
