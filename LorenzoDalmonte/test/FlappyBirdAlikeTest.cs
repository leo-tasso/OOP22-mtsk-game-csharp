using System.Linq;
using NUnit.Framework;
using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;
using OOP22_mtsk_game_csharp.LorenzoDalmonte.game;
using OOP22_mtsk_game_csharp.PietroOlivi.api;

namespace OOP22_mtsk_game_csharp.LorenzoDalmonte.test
{
    [TestFixture]
    class FlappyBirdAlikeTest
    {
        private static readonly int CURSOR_INDEX = 0;
        private static readonly int LIMIT_BOTTOM = 800;
        private static readonly int LIMIT_HIGH = 100;
        private static readonly int NUM_JUMPS = 100;
        private static readonly int FIELD_MIDDLE = 450;
        private static readonly int CYCLES = 400;
        private static readonly long ELAPSED_TIME = 10L;

        [Test]
        public void BoundaryCheck()
        {
            IMinigame m = new FlappyBirdAlike();
            Assert.AreEqual(m.GetObjects().ElementAt(CURSOR_INDEX).Coor.Y, LIMIT_BOTTOM);
            IInput input = new KeyboardInput();
            for (int i = 0; i < NUM_JUMPS; i++)
            {
                JumpUpdate(true, m, input);
                Assert.IsTrue(m.GetObjects().ElementAt(CURSOR_INDEX).Coor.Y >= LIMIT_HIGH);
                JumpUpdate(false, m, input);
            }
        }

        private void JumpUpdate(bool jump, IMinigame m, IInput input)
        {
            input.Jump = jump;
            foreach (var o in m.GetObjects())
            {
                o.Updateinput(input, ELAPSED_TIME);
            }
            m.Compute(ELAPSED_TIME);
        }

        [Test]
        public void ClosestObstacleCheck()
        {
            IMinigame m = new FlappyBirdAlike();
            while (m.GetObjects().Count < 3)
            {
                m.Compute(ELAPSED_TIME);
            }

            Assert.IsTrue(m.GetObjects().ElementAt(1).Coor.X < m.GetObjects().ElementAt(2).Coor.X);
        }

        [Test]
        public void HitboxCheck()
        {
            IMinigame m = new FlappyBirdAlike();
            while (m.GetObjects().Count == 1
                    || m.GetObjects().ElementAt(1).Coor.Y < FIELD_MIDDLE)
            {
                m.Compute(ELAPSED_TIME);
            }

            for (int i = 0; i < CYCLES; i++)
            {
                m.Compute(ELAPSED_TIME);
                m.IsGameOver();
            }

            Assert.IsTrue(m.IsGameOver());
        }

        [Test]
        public void SpeedCheck()
        {
            IMinigame m = new FlappyBirdAlike();
            while (m.GetObjects().Count == 1)
            {
                m.Compute(ELAPSED_TIME);
            }

            Assert.AreEqual(m.GetObjects().ElementAt(CURSOR_INDEX).Vel.X, 0);
            Assert.AreEqual(m.GetObjects().ElementAt(1).Vel.Y, 0);
        }
    }
}