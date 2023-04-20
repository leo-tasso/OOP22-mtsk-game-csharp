using System.Collections.Generic;
using System.Linq;
using OOP22_mtsk_game_csharp.LeonardoTassinari.Game;
using OOP22_mtsk_game_csharp.LorenzoDalmonte.Api;

namespace OOP22_mtsk_game_csharp.PietroOlivi.Game
{
    /*
     * Class that implements the Whac-a-mole minigame logic.
     */
    public class WhacAMole : IMinigame
    {
        /*
         *  Number of holes in the game.
         */
        public static readonly int NUM_HOLES = 9;
        private static readonly int DRAWS_TO_NEXT_LEVEL = 3;
        public long CurrentTime { get; set; }
        private List<WamObject> _objs;
        private readonly IList<ILevel> _levels; 
        private readonly IDrawStrategy _draw;
        private ILevel _currentLevel;
        private int _numDraws;

        /*
         * General initialization of the fields. The start time 
         * is requested in order to calculate when to advance 
         * in level, the WamObject list is initialized with the 
         * objects representing the holes in the playing field.
         */
        public WhacAMole(int fieldHeight) 
        {
            CurrentTime = 0L;
            _levels = new List<ILevel>{new LevelOne()};
            IHolesGeneratorStrategy holesGen = new SquareHolesGenerator(fieldHeight);
            _objs = new List<WamObject>(holesGen.Generate(NUM_HOLES));
            _draw = new DrawStrategy(new List<GameObject>(_objs.GetRange(NUM_HOLES, _objs.Count - NUM_HOLES)));
            _currentLevel = _levels[0];
            _numDraws = 0;
        }

        /*
         * Checks if one of the bombs in the game was hit by the user 
         * or if a mole managed to re-enter its hole without being 
         * crushed (both sufficient conditions for the game to end).
         */
        public bool IsGameOver() 
        { 
            return _objs
                .Any(o => o.IsGameOver());
        }

        /*
         * At this point each object that has been hit will have been notified 
         * by the InputModel, so now I need to update the logical state 
         * of all the others and manage the physics of the moving objects.
         * Finally I check if a new extraction is necessary.
         */
        public void Compute(long elapsed) 
        {
            CurrentTime += elapsed;
            this.DeleteOldObjs();
            this.CalculateLevel();
            this.DrawIfNecessary();

            foreach (var o in _objs) 
            {
                if (!o.GetStatus().Equals(Status.WAITING)) 
                {
                    o.UpdatePhysics(elapsed, this);
                }
            }

            foreach (var o in _objs) 
            {
                if (o.GetStatus().Equals(Status.WAITING) && o.GetAppearanceTime() <= CurrentTime) 
                {
                    o.SetStatus(Status.IN_MOTION);
                    o.Vel = o.GetLevel().GetObjSpeed();
                }
            }

            foreach (var o in _objs)
            {
                if (o.Coor.Y > o.GetStartCoor().Y) 
                {
                    o.Vel = Vector2D.NullVector();
                    if (!o.GetStatus().Equals(Status.HIT))
                    {
                        o.SetStatus(Status.MISSED);
                    }
                }
            }

            foreach (var o in _objs)
            {
                if (o.GetStatus().Equals(Status.HALFWAY) && o.GetMotionRestartTime() <= CurrentTime) 
                {
                    o.SetStatus(Status.IN_MOTION);
                    o.Vel = _currentLevel.GetObjSpeed().Invert();
                }
            }
        }

        /*
         * Method that checks whether it is time 
         * to perform a draw, and if so, does it.
         */
        private void DrawIfNecessary() 
        {
            if (_objs.Count == WhacAMole.NUM_HOLES * 2) 
            {
                foreach (var o in _draw.Draw(_currentLevel, CurrentTime))
                {
                    /* Since the visualization of the layers when they   */
                    /* overlap depends on the print order, I have to put */
                    /* all the objects after the upper part of the holes */
                    _objs.Insert(NUM_HOLES, (WamObject) o);
                }
                _numDraws = _numDraws + 1;
            }
        }

        /*
         * Returns all the GameObjects currently in use in the game.
         */
        public IList<GameObject> GetObjects() 
        {
            return new List<GameObject>(_objs);
        }

        /*
         * Method for calculating the difficulty level based on how 
         * many draws have been made. If there are no more levels 
         * available to advance, then the user will stay on the last one.
         */
        private void CalculateLevel() 
        {
            int levelIndex = (int) _numDraws / (int) DRAWS_TO_NEXT_LEVEL;
            if (levelIndex > _levels.Count - 1) 
            {
                _currentLevel = _levels[_levels.Count - 1];
            } 
            else 
            {
                _currentLevel = _levels[levelIndex];
            }
        }

        /*
         * Method to clean the lists from GameObjects no longer in use.
         */
        private void DeleteOldObjs() 
        {
            _objs.RemoveAll(o => !o.IsStillInUse());
        }

        public string GetTutorial() 
        {
            return "Smash the moles before they can get back to their hole by "
                + "clicking the number from 1 to 9 on your keyboard corresponding to "
                + "the hole the mole came out of, but be careful not to hit the bombs!";
        }

        /*
         * Method that allows you to update the list of objects (It is 
         * used to test that the bombs work correctly, eliminating the 
         * moles to ensure that they do not interfere with the test result).
         */
        public void SetObjects(IList<WamObject> objs) 
        {
            _objs = new List<WamObject>(objs);
        }
    }
}
