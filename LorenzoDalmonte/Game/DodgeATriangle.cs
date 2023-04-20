using System;
using System.Collections.Generic;
using System.Linq;
using OOP22_mtsk_game_csharp.LeonardoTassinari.Game;
using OOP22_mtsk_game_csharp.LorenzoDalmonte.Api;
using OOP22_mtsk_game_csharp.PietroOlivi.Game;

namespace OOP22_mtsk_game_csharp.LorenzoDalmonte.Game
{
    public class DodgeATriangle : IMinigame
    {

        private static readonly double RATIO = 16 / 9d;
        private static readonly int DEFAULT_HEIGHT = 900;
        private static readonly int DIFFICULTY_OFFSET = 100;
        private static readonly int SLOT_RATIO = 9;
        private static readonly Vector2D DEFAULT_SPEED = new Vector2D(40, 0);
        private static readonly int NUM_SLOTS = 5;
        private static readonly int NUM_STEPS = 8;
        private static readonly long MS_TO_ADD_ENEMY = 10_000L;

        private readonly int _width;
        private readonly int _initialY;
        private readonly int _sideLength;
        private readonly int _spawnLeft;
        private readonly int _spawnRight;
        private readonly Vector2D _enemySpeed;
        private IList<GameObject> _l = new List<GameObject>();
        private readonly GameObject _slots;
        private readonly ICollider _c = new Collider();
        private readonly Random _rand = new Random();
        private long _totalElapsed;
        private readonly StepRateStrat _diff;
        private bool _gameOver;

        public DodgeATriangle(int height)
        {
            _width = (int) (height * RATIO);
            int initialX = (int) (_width / 2);
            _initialY = height / 2;
            _sideLength = (height - 2 * height / SLOT_RATIO) / NUM_SLOTS;
            _spawnLeft = -_sideLength;
            _spawnRight = (int) (_width + _sideLength);
            _enemySpeed = DEFAULT_SPEED.Mul(height / (double) DEFAULT_HEIGHT);
            _diff = new StepRateStrat(NUM_STEPS, height / DEFAULT_HEIGHT * DIFFICULTY_OFFSET, MS_TO_ADD_ENEMY);
            _l.Add(new Dodger(_initialY, _sideLength,
               new DodgerInputModel(_sideLength, _initialY)));
            _slots = new GameObject(new Point2D(initialX, _initialY), _enemySpeed);
            _slots.Aspect = new SlotAspect(_sideLength, new Point2D(initialX, _initialY), NUM_SLOTS);
            _slots.Input = new NullInput();
            _slots.Physics = new SimplePhysics();
            _slots.Vel = Vector2D.NullVector();
        }

        public DodgeATriangle() : this(DEFAULT_HEIGHT)
        {
        }

        public bool IsGameOver()
        {
            if (!_gameOver)
            {
                GameObject pl = _l.ElementAt(0);
                _gameOver = _l.Skip(1)
                        .Any(o => _c.IsColliding(pl, o));
            }
            return _gameOver;
        }

        public void Compute(long elapsed)
        {
            this._totalElapsed += elapsed;
            if (_l.Count == 1 || CanSpawnNewEnemy())
            {
                int enemyY = _initialY + (_rand.Next(NUM_SLOTS) - 2) * _sideLength;
                int enemyX = _rand.Next(2) == 0 ? _spawnLeft : _spawnRight;
                _l.Add(new DatTriangle(new Point2D(enemyX, enemyY),
                        enemyX < 0 ? _enemySpeed : _enemySpeed.Invert(),
                        _sideLength));
            }

            _l = _l.Where(o => o.Coor.X >= _spawnLeft
                    && o.Coor.X <= _spawnRight).ToList();
            foreach (var e in _l)
            {
                e.UpdatePhysics(elapsed, this);
            }
        }

        private bool CanSpawnNewEnemy()
        {
            return _l.ElementAt(_l.Count - 1).Vel.X < 0
                    && _l.ElementAt(_l.Count - 1).Vel.X < _diff.Invoke(_totalElapsed)
                    || _l.ElementAt(_l.Count - 1).Vel.X > 0
                            && _l.ElementAt(_l.Count - 1).Coor.X > _width - _diff.Invoke(_totalElapsed);
        }

        public IList<GameObject> GetObjects()
        {
            IList<GameObject> tmp = new List<GameObject>(_l);
            tmp.Insert(0, _slots);
            return tmp;
        }

        public string GetTutorial()
        {
            return "Use the arrows to move forward and backwards.\nAvoid the triangles.";
        }
    }
}