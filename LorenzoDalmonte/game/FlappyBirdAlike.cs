using System.Collections.Generic;
using System.Linq;
using OOP22_mtsk_game_csharp.LeonardoTassinari.game;
using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;
using OOP22_mtsk_game_csharp.PietroOlivi.game;

namespace OOP22_mtsk_game_csharp.LorenzoDalmonte.game
{
    public class FlappyBirdAlike : IMinigame
    {

        private static readonly double RATIO = 16 / 9d;
        private static readonly int DEFAULT_HEIGHT = 900;
        private static readonly int DIFFICULTY_OFFSET = 100;
        private static readonly long INC_DIFF_TIME_WINDOW = 10_000L;
        private static readonly int NUM_STEPS = 8;
        private readonly int _height;
        private readonly int _maxHeight;
        private readonly int _enemySpeed;
        private readonly int _heightOffset;
        private readonly int _enemyWidth;
        private readonly int _enemySpawn;
        private IList<GameObject> _l = new List<GameObject>();
        private readonly System.Random _rand = new System.Random();
        private readonly StepRateStrat _freqStrat;
        private long _totalElapsed;
        private int _enemyHeight;
        private bool _gameOver;

        public FlappyBirdAlike(int height)
        {
            _height = height;
            _enemySpeed = (int) (-height * RATIO / 32);
            double cursorSize = height * RATIO / 8;
            _heightOffset = (int) (height * RATIO / 16);
            _enemyWidth = _heightOffset;
            _maxHeight = height - (int) cursorSize - 2 * _heightOffset;
            _enemySpawn = (int) (height * RATIO) + _enemyWidth;
            _freqStrat = new StepRateStrat(NUM_STEPS, height / DEFAULT_HEIGHT * DIFFICULTY_OFFSET, INC_DIFF_TIME_WINDOW);
            _l.Add(new Cursor(new Point2D(cursorSize / 2 + height * RATIO / 32, height - cursorSize / 2),
                    Vector2D.NullVector(),
                    cursorSize,
                    -_enemySpeed,
                    new FlappyInput(height)));
        }

        public FlappyBirdAlike() : this(DEFAULT_HEIGHT)
        {
        }

        public bool IsGameOver()
        {
            if (!_gameOver)
            {
                _gameOver = _l.Count > 1
                    && new Collider().IsColliding(_l.ElementAt(0), _l.ElementAt(1));
            }
            return _gameOver;
        }

        public void Compute(long elapsed)
        {
            _totalElapsed += elapsed;
            if (_l.Count == 1 || _l.ElementAt(_l.Count - 1).Coor.X < _freqStrat.Invoke(_totalElapsed))
            {
                _enemyHeight = _rand.Next(_maxHeight) + _heightOffset;
                double y = _rand.Next(2) == 1 ? _enemyHeight / 2.0 : _height - _enemyHeight / 2.0;
                _l.Add(new GameObject(new Point2D(_enemySpawn, y),
                        new Vector2D(_enemySpeed, 0),
                        0, new NullInput(),
                        new SimplePhysics(),
                        new RectangleAspect(_enemyWidth, _enemyHeight, ColorRGB.Black, false),
                        new RectangleHitBoxModel(_enemyWidth, _enemyHeight)));
            }

            _l = _l.Where(e => e.Coor.X < -_enemyWidth).ToList();
            foreach (var e in _l)
            {
                e.UpdatePhysics(elapsed, this);
            }
        }

        public IList<GameObject> GetObjects()
        {
            return new List<GameObject>(this._l);
        }

        public string GetTutorial()
        {
            return "Press the SPACEBAR to jump and evade obstacles.\n You can jump in midair too!";
        }
    }
}