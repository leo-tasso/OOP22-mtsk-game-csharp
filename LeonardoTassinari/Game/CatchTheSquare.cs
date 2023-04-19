using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;
using OOP22_mtsk_game_csharp.PietroOlivi.game;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable

namespace OOP22_mtsk_game_csharp.LeonardoTassinari.game
{
    public class CatchTheSquare : IMinigame
    {
        private static readonly int DEFUSER_RADIUS = 100;
        private static readonly int BOMB_SIDE = (int)(DEFUSER_RADIUS * 1.5);
        private static readonly int MAX_OBJECT = 6;
        private static readonly double MAX_BOMB_RATE = 0.7;
        private static readonly double BOMB_SPAWN_DIFF = 1.05;
        private static readonly double DUMP_COEFFICIENT = 2;
        private static readonly double RATIO = 16 / 9d;

        private readonly int rightBound;
        private readonly int bottomBound;
        private long totalElapsed;
        private int totalBombsSpawned;
        private readonly Defuser defuser;
        private readonly IList<GameObject> gObjects;
        private readonly Random r;
        private readonly Func<long, long> spawnFreqStrat;
        public CatchTheSquare(Func<long, long> spawnFreqStrat, IInputModel defuserInputModel,
             int bottomBound)
        {
            this.gObjects = new List<GameObject>();
            this.bottomBound = bottomBound;
            this.rightBound = (int)(bottomBound * RATIO);
            this.totalElapsed = 0;
            this.totalBombsSpawned = 0;
            this.r = new Random();
            this.spawnFreqStrat = spawnFreqStrat;
            defuser = new Defuser(new Point2D(rightBound / 2d, bottomBound / 2d), DEFUSER_RADIUS, defuserInputModel, new BoundaryDumpedPhysics(rightBound, bottomBound, DEFUSER_RADIUS, DUMP_COEFFICIENT));
            gObjects.Add(defuser);
        }
        public CatchTheSquare(int bottomBound) : this(new IncrRateStrat(BOMB_SPAWN_DIFF, MAX_BOMB_RATE).Invoke, new DirectionalInput(), bottomBound)
        {
        }
        public bool IsGameOver()
        {
            return !gObjects.Where(o => o.GetType() == typeof(CtsBomb))
                    .Cast<CtsBomb>()
                    .All(b => b.Timer >= 0);
        }
        public void Compute(long elapsed)
        {
            totalElapsed += elapsed;
            GameObject? collider = CheckCollision(defuser);
            if (collider != null)
            {
                gObjects.Remove(collider);
            }
            if (totalBombsSpawned < spawnFreqStrat.Invoke(totalElapsed) && gObjects.Count() < MAX_OBJECT)
            {
                gObjects.Add(new CtsBomb(RandSpawnPoint(), BOMB_SIDE, ColorRGB.Black)); // if changing bomb shape, also
                                                                                        // change
                                                                                        // checkCollision method
                totalBombsSpawned++;
            }
            foreach (var b in gObjects)
            {
                b.UpdatePhysics(elapsed, this);
            }
        }
        private GameObject? CheckCollision(Defuser defuser)
        {
            if (defuser.Aspect is CircleAspect)
            {
                IList<GameObject> bombs = gObjects
                        .Where(o=>o is CtsBomb)
                        //.Where(b => b.Aspect is RectangleAspect)
                        .ToList();
                foreach (GameObject bomb in bombs)
                {
                    ICollider c = new Collider();
                    if (c.IsColliding(bomb, defuser))
                    {
                        return bomb;
                    }
                }
            }
            return null;
        }
        private Point2D RandSpawnPoint()
        {
            Point2D p = new(r.Next(BOMB_SIDE / 2, rightBound - BOMB_SIDE / 2),
                    r.Next(BOMB_SIDE / 2, bottomBound - BOMB_SIDE / 2));
            foreach (GameObject gameObject in gObjects)
            {
                if (p.Distance(gameObject.Coor) < BOMB_SIDE * 2)
                {
                    return RandSpawnPoint();
                }
            }
            return p;
        }
        public IList<GameObject> GetObjects()
        {
            return new List<GameObject>(gObjects);
        }
        public String GetTutorial()
        {
            return "Use \"WASD\" to control the the circle and "
                    + "defuse all the squares by touching them before the time runs out";
        }
    }
}
