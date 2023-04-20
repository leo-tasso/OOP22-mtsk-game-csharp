using OOP22_mtsk_game_csharp.LeonardoTassinari.Game;
using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;

namespace OOP22_mtsk_game_csharp.PietroOlivi.game
{
    /*
     * Class that models objects belonging to the Whac-a-Mole minigame.
     * If I hadn't created this class, extending the characters' classes 
     * directly from GameObject, I would have violated the DRY principle,
     * since many functions would have had the same implementation.
     */
    public abstract class WamObject : GameObject 
    {
        /*
         * Difference of the Y coordinate between the starting point 
         * of the object and the most distant point from the hole
         * it reaches (i.e. the one where it will stop for a while)
         */
        public static readonly int DELTA_Y = 110; 

        private Status _status;
        private readonly ILevel _level;
        private readonly int _holeNumber;
        private readonly Point2D _startCoor;
        private readonly long _appearanceTime;
        private long _motionRestartTime;

        /*
         * Basic initialization of the various fields.
         */
        public WamObject(Point2D startCoor,
            long appearanceTime, 
            ILevel currentLevel,
            int holeNumber,
            IPhysicsModel physicsModel,
            IAspectModel aspectModel,
            IInputModel inputModel) : base(
                startCoor, 
                Vector2D.NullVector(), 
                0, 
                inputModel, 
                physicsModel, 
                aspectModel
            )
        {
            _status = Status.WAITING;
            _level = currentLevel;
            _holeNumber = holeNumber;
            _appearanceTime = appearanceTime;
            _startCoor = startCoor;
            _motionRestartTime = 0L;
        }

        /*
         * Method that checks whether or not the object caused the 
         * GameOver, with a different check routine depending on 
         * the character type of the class implementing WamObject.
         */
        public abstract bool IsGameOver();

        /*
         * Check if the object has already performed its task 
         * in the game and has therefore become irrelevant 
         * (and that it is not the cause of GameOver).
         */
        public abstract bool IsStillInUse();

        /*
         * Getter method for the current 
         * logical state of the GameObject.
         */
        public Status GetStatus() => _status;

        /*
         * Setter method for the current
         * logical state of the GameObject.
         */
        public void SetStatus(Status status) => _status = status;

        /*
         * Getter method for the number of the 
         * hole the object will come out of.
         */
        public int GetHoleNumber() => _holeNumber;

        /*
         * Getter method for the coordinates from which the 
         * object starts its motion (just above the hole).
         */
        public Point2D GetStartCoor() => _startCoor;

        /*
         * Getter method for the time instant in which 
         * the object will be in its initial coordinates.
         */
        public long GetAppearanceTime() => _appearanceTime;
        
        /*
         * Getter method for the instant of time in which the 
         * object, after having stopped for a certain amount of time 
         * outside the hole, restarts its motion to return inside.
         */
        public long GetMotionRestartTime() => _motionRestartTime;

        /*
         * Method to set the motion restart time, 
         * calculated once the object reaches 
         * the highest point of its journey.
         */
        public void SetMotionRestartTime(long l) => _motionRestartTime = l;

        /*
         * Getter method for the level to 
         * which this object belongs.
         */
        public ILevel GetLevel() => _level;
    }
}
