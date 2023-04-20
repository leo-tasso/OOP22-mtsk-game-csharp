using System;
using System.Linq;
using NUnit.Framework;
using OOP22_mtsk_game_csharp.LorenzoDalmonte.Api;
using OOP22_mtsk_game_csharp.LorenzoDalmonte.Game;
using OOP22_mtsk_game_csharp.PietroOlivi.Api;

namespace OOP22_mtsk_game_csharp.LorenzoDalmonte.Test
{
    [TestFixture]
    public class DodgeATriangleTest
    {

        private static readonly long ELAPSED_TIME = 10L;
        private static readonly int CYCLES = 400;
        private static readonly int LIMIT_LOW = 170;
        private static readonly int LIMIT_HIGH = 730;
        private static readonly int MOVES = 7;

        [Test]
        public void HitboxCheck()
        {

            IMinigame m = new DodgeATriangle();
            Point2D center = m.GetObjects().ElementAt(0).Coor;

            while (m.GetObjects().Count <= 2 // The first elem is an istance of Slots
                   || center.Y != m.GetObjects().ElementAt(2).Coor.Y)
            {
                m.Compute(ELAPSED_TIME);
                m.IsGameOver();
            }

            for (int i = 0; i < CYCLES; i++)
            {
                m.Compute(ELAPSED_TIME);
                m.IsGameOver();
            }

            Assert.IsTrue(m.IsGameOver());
        }

        [Test]
        public void BoundaryTest()
        {
            IMinigame m = new DodgeATriangle();
            IInput input = new KeyboardInput();

            for (int j = 0; j < MOVES; j++)
            {
                SetInput(m, input, i => i.Forward = true);
                SetInput(m, input, i => i.Forward = false);
                Assert.IsTrue(m.GetObjects().ElementAt(0).Coor.Y >= LIMIT_LOW);
            }

            for (int j = 0; j < MOVES; j++)
            {
                SetInput(m, input, i => i.Backwards = true);
                SetInput(m, input, i => i.Backwards = false);
                Assert.IsTrue(m.GetObjects().ElementAt(0).Coor.Y <= LIMIT_HIGH);
            }
        }

        private void SetInput(IMinigame m, IInput input, Action<IInput> c)
        {
            c.Invoke(input);
            foreach (var o in m.GetObjects())
            {
                o.Updateinput(input, ELAPSED_TIME);
            }
            m.Compute(ELAPSED_TIME);
        }
    }
}