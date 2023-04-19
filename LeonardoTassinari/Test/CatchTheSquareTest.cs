using NUnit.Framework;
using OOP22_mtsk_game_csharp.LeonardoTassinari.game;
using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;
using OOP22_mtsk_game_csharp.PietroOlivi.api;
using OOP22_mtsk_game_csharp.PietroOlivi.game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP22_mtsk_game_csharp.LeonardoTassinari.test
{
    [TestFixture]
    public class CatchTheSquareTest
    {
        private static readonly int SPEED_COEF = 5;
        private static readonly int FRAME_HEIGHT = 900;
        private static readonly int FRAME_LENGHT = 1600;
        private static readonly int START_SPEED = 200;
        private static readonly int TIME_TO_WAIT = 100_000;
        private static readonly int REPETITIONS = 10_000;
        private static readonly int ELAPSED_TIME = 10;
        private static readonly int BOUND_HEIGHT = 900;
        private static readonly int BOUND_LENGHT = 1600;
        private static readonly double BOMB_SPAWN_DIFF = 1.05;
        private static readonly double MAX_BOMB_RATE = 0.7;
        private static readonly IList<Func<long, long>> SPAWN_STRATS = new List<Func<long, long>> { new IncrRateStrat(BOMB_SPAWN_DIFF, MAX_BOMB_RATE).Invoke };
        private static readonly List<IInputModel> INPUT_MODEL_STRATS = new List<IInputModel> { new DirectionalInput() };


        [Test]
        public void TestExplosion()
        {
            foreach (IInputModel inputModel in INPUT_MODEL_STRATS)
            {
                foreach (Func<long, long> spawnStrat in SPAWN_STRATS)
                {
                    IMinigame cTS = new CatchTheSquare(spawnStrat,
                            inputModel, FRAME_HEIGHT);
                    for (int n = 0; n < REPETITIONS; n++)
                    {
                        cTS.Compute(TIME_TO_WAIT / REPETITIONS); // just waits
                    }
                    Assert.True(cTS.IsGameOver()); // bomb should be exploded
                }
            }
        }
        [Test]
        public void TestDefusion()
        {
            foreach (IInputModel inputModel in INPUT_MODEL_STRATS)
            {
                foreach (Func<long, long> spawnStrat in SPAWN_STRATS)
                {
                    IMinigame cTS = new CatchTheSquare(spawnStrat,
                            inputModel, FRAME_HEIGHT);
                    GameObject defuser = cTS.GetObjects()[0];
                    while (cTS.GetObjects().Count() < 2)
                    {
                        cTS.Compute(ELAPSED_TIME); // wait until some bomb is spawned
                    }
                    int objectsNold = cTS.GetObjects().Count;
                    while (objectsNold <= cTS.GetObjects().Count)
                    { // keep checking if any bomb has been defused
                        objectsNold = cTS.GetObjects().Count();
                        GameObject? b = cTS.GetObjects().Where(o => o is CtsBomb).First();
                        if (b != null)
                        {
                            defuser.Coor = b.Coor;
                        }
                        cTS.Compute(ELAPSED_TIME);
                        Assert.False(cTS.IsGameOver()); // game should be ok and running
                    }
                }
            }
        }
        /*
        [Test]
        public void TestControls()
        {
            foreach (IInputModel inputModel in INPUT_MODEL_STRATS)
            {
                foreach (Func<long, long> spawnStrat in SPAWN_STRATS)
                {
                    IMinigame cTS = new CatchTheSquare(spawnStrat,
                            inputModel, FRAME_HEIGHT);
                    IInput input = new KeyboardInput();
                    input.MoveDown = true;
                    foreach (GameObject o in cTS.GetObjects())
                    {
                        o.Updateinput(input, ELAPSED_TIME);
                    }
                    cTS.Compute(ELAPSED_TIME);
                    Assert.AreNotEqual(cTS.GetObjects()[0].Vel, Vector2D.NullVector());
                    Assert.AreNotEqual(cTS.GetObjects()[0].Coor, new Point2D(BOUND_LENGHT / 2, BOUND_HEIGHT / 2));
                }
            }
        }*/
        [Test]
        public void TestBoundary()
        {
            foreach (IInputModel inputModel in INPUT_MODEL_STRATS)
            {
                foreach (Func< long, long > spawnStrat in SPAWN_STRATS)
                {
                    IMinigame cTS = new CatchTheSquare(spawnStrat,
                            inputModel, FRAME_HEIGHT);
                    GameObject defuser = cTS.GetObjects()[0];
                    defuser.Vel = new Vector2D(START_SPEED, START_SPEED);
                    for (int n = 0; n < REPETITIONS; n++)
                    {
                        cTS.Compute(ELAPSED_TIME);
                        if (defuser.Vel.Module() < START_SPEED / 2)
                        {
                            defuser.Vel=(defuser.Vel.Mul(SPEED_COEF));
                        }
                        Assert.True(defuser.Coor.X >= 0);
                        Assert.True(defuser.Coor.X <= FRAME_LENGHT);
                        Assert.True(defuser.Coor.Y >= 0);
                        Assert.True(defuser.Coor.Y <= FRAME_HEIGHT);
                    }

                }
            }
        }
    }
}
