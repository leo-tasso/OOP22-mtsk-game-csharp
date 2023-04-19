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
        private const int DefuserRadius = 100;
        private const int BombSide = (int)(DefuserRadius * 1.5);
        private const int MaxObject = 6;
        private const double MaxBombRate = 0.7;
        private const double BombSpawnDiff = 1.05;
        private const double DumpCoefficient = 2;
        private const double Ratio = 16 / 9d;

        private readonly int _rightBound;
        private readonly int _bottomBound;
        private long _totalElapsed;
        private int _totalBombsSpawned;
        private readonly Defuser _defuser;
        private readonly IList<GameObject> _gObjects;
        private readonly Random _r;
        private readonly Func<long, long> _spawnFreqStrat;
        public CatchTheSquare(Func<long, long> spawnFreqStrat, IInputModel defuserInputModel,
             int bottomBound)
        {
            this._gObjects = new List<GameObject>();
            this._bottomBound = bottomBound;
            this._rightBound = (int)(bottomBound * Ratio);
            this._totalElapsed = 0;
            this._totalBombsSpawned = 0;
            this._r = new Random();
            this._spawnFreqStrat = spawnFreqStrat;
            _defuser = new Defuser(new Point2D(_rightBound / 2d, bottomBound / 2d), DefuserRadius, defuserInputModel, new BoundaryDumpedPhysics(_rightBound, bottomBound, DefuserRadius, DumpCoefficient));
            _gObjects.Add(_defuser);
        }
        public CatchTheSquare(int bottomBound) : this(new IncrRateStrat(BombSpawnDiff, MaxBombRate).Invoke, new DirectionalInput(), bottomBound)
        {
        }
        public bool IsGameOver()
        {
            return !_gObjects.Where(o => o.GetType() == typeof(CtsBomb))
                    .Cast<CtsBomb>()
                    .All(b => b.Timer >= 0);
        }
        public void Compute(long elapsed)
        {
            _totalElapsed += elapsed;
            GameObject? collider = CheckCollision(_defuser);
            if (collider != null)
            {
                _gObjects.Remove(collider);
            }
            if (_totalBombsSpawned < _spawnFreqStrat.Invoke(_totalElapsed) && _gObjects.Count < MaxObject)
            {
                _gObjects.Add(new CtsBomb(RandSpawnPoint(), BombSide, ColorRGB.Black)); // if changing bomb shape, also
                                                                                        // change
                                                                                        // checkCollision method
                _totalBombsSpawned++;
            }
            foreach (var b in _gObjects)
            {
                b.UpdatePhysics(elapsed, this);
            }
        }
        private GameObject? CheckCollision(Defuser defuser)
        {
            if (defuser.Aspect is CircleAspect)
            {
                IList<GameObject> bombs = _gObjects
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
            Point2D p = new(_r.Next(BombSide / 2, _rightBound - BombSide / 2),
                    _r.Next(BombSide / 2, _bottomBound - BombSide / 2));
            foreach (GameObject gameObject in _gObjects)
            {
                if (p.Distance(gameObject.Coor) < BombSide * 2)
                {
                    return RandSpawnPoint();
                }
            }
            return p;
        }
        public IList<GameObject> GetObjects()
        {
            return new List<GameObject>(_gObjects);
        }
        public String GetTutorial()
        {
            return "Use \"WASD\" to control the the circle and "
                    + "defuse all the squares by touching them before the time runs out";
        }
    }
}
