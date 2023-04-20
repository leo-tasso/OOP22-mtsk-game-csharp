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
        private const int SpeedCoef = 5;
        private const int FrameHeight = 900;
        private const int FrameLenght = 1600;
        private const int StartSpeed = 200;
        private const int TimeToWait = 100_000;
        private const int Repetitions = 10_000;
        private const int ElapsedTime = 10;
        private const int BoundHeight = 900;
        private const int BoundLenght = 1600;
        private const double BombSpawnDiff = 1.05;
        private const double MaxBombRate = 0.7;
        private static readonly IList<Func<long, long>> SPAWN_STRATS = new List<Func<long, long>> { new IncrRateStrat(BombSpawnDiff, MaxBombRate).Invoke };
        private static readonly List<IInputModel> INPUT_MODEL_STRATS = new List<IInputModel> { new DirectionalInput() };


        [Test]
        public void TestExplosion()
        {
            foreach (IInputModel inputModel in INPUT_MODEL_STRATS)
            {
                foreach (Func<long, long> spawnStrat in SPAWN_STRATS)
                {
                    IMinigame cTS = new CatchTheSquare(spawnStrat,
                            inputModel, FrameHeight);
                    for (int n = 0; n < Repetitions; n++)
                    {
                        cTS.Compute(TimeToWait / Repetitions); // just waits
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
                            inputModel, FrameHeight);
                    GameObject defuser = cTS.GetObjects()[0];
                    while (cTS.GetObjects().Count() < 2)
                    {
                        cTS.Compute(ElapsedTime); // wait until some bomb is spawned
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
                        cTS.Compute(ElapsedTime);
                        Assert.False(cTS.IsGameOver()); // game should be ok and running
                    }
                }
            }
        }
        [Test]
        public void TestControls()
        {
            foreach (IInputModel inputModel in INPUT_MODEL_STRATS)
            {
                foreach (Func<long, long> spawnStrat in SPAWN_STRATS)
                {
                    IMinigame cTS = new CatchTheSquare(spawnStrat,
                            inputModel, FrameHeight);
                    IInput input = new KeyboardInput();
                    input.MoveDown = true;
                    foreach (GameObject o in cTS.GetObjects())
                    {
                        o.Updateinput(input, ElapsedTime);
                    }
                    cTS.Compute(ElapsedTime);
                    Assert.AreNotEqual(cTS.GetObjects()[0].Vel, Vector2D.NullVector());
                    Assert.AreNotEqual(cTS.GetObjects()[0].Coor, new Point2D(BoundLenght / 2, BoundHeight / 2));
                }
            }
        }
        [Test]
        public void TestBoundary()
        {
            foreach (IInputModel inputModel in INPUT_MODEL_STRATS)
            {
                foreach (Func<long, long> spawnStrat in SPAWN_STRATS)
                {
                    IMinigame cTS = new CatchTheSquare(spawnStrat,
                            inputModel, FrameHeight);
                    GameObject defuser = cTS.GetObjects()[0];
                    defuser.Vel = new Vector2D(StartSpeed, StartSpeed);
                    for (int n = 0; n < Repetitions; n++)
                    {
                        cTS.Compute(ElapsedTime);
                        if (defuser.Vel.Module() < StartSpeed / 2)
                        {
                            defuser.Vel = (defuser.Vel.Mul(SpeedCoef));
                        }
                        Assert.True(defuser.Coor.X >= 0);
                        Assert.True(defuser.Coor.X <= FrameLenght);
                        Assert.True(defuser.Coor.Y >= 0);
                        Assert.True(defuser.Coor.Y <= FrameHeight);
                    }

                }
            }
        }
    }
}
