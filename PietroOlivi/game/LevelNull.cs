using OOP22_mtsk_game_csharp.LeonardoTassinari.game;
using OOP22_mtsk_game_csharp.PietroOlivi.api;

namespace OOP22_mtsk_game_csharp.PietroOlivi.game
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
