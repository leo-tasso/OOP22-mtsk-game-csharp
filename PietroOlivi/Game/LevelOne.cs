using OOP22_mtsk_game_csharp.LeonardoTassinari.Game;
using OOP22_mtsk_game_csharp.PietroOlivi.Api;

namespace OOP22_mtsk_game_csharp.PietroOlivi.Game
{
    /*
     * Class that contains values related to 
     * the first level of the whac-a-mole game.
     */
    internal class LevelOne : ILevel
    {
        private static readonly int MAX_OBJS_OUT_AT_ONCE = 1;
        private static readonly double VECTOR_ORDINATE = -20;
        private static readonly long MIN_WAIT_TO_SPAWN = 5_000L;
        private static readonly long MAX_WAIT_TO_SPAWN = 15_000L;
        public static readonly long STATIONARY_TIME = 5000L;

        public int GetMaxObjsSimultaneouslyOut() 
        {
            return LevelOne.MAX_OBJS_OUT_AT_ONCE;
        }

        public Vector2D GetObjSpeed() 
        {
            return new Vector2D(0, LevelOne.VECTOR_ORDINATE);
        }

        public TimeInterval GetSpawnWaitingTime() 
        {
            return new TimeInterval(LevelOne.MIN_WAIT_TO_SPAWN, LevelOne.MAX_WAIT_TO_SPAWN);
        }

        public long GetHalfwayTime() 
        {
            return LevelOne.STATIONARY_TIME;
        }
    }
}
