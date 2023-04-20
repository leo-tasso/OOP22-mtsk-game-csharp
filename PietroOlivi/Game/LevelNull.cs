using OOP22_mtsk_game_csharp.LeonardoTassinari.Game;
using OOP22_mtsk_game_csharp.PietroOlivi.Api;

namespace OOP22_mtsk_game_csharp.PietroOlivi.Game
{
    /*
     * Class representing a level to be assigned 
     * to objects independent of levels.
     */
    internal class LevelNull : ILevel
    {
        public int GetMaxObjsSimultaneouslyOut() 
        {
            return 0;
        }

        public Vector2D GetObjSpeed() 
        {
            return Vector2D.NullVector();
        }

        public TimeInterval GetSpawnWaitingTime() 
        {
            return new TimeInterval(0L, 0L); 
        }

        public long GetHalfwayTime() 
        {
            return 0L;
        }
    }
}
