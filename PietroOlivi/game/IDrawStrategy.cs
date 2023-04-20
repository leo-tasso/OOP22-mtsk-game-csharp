using System.Collections.Generic;
using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;

namespace OOP22_mtsk_game_csharp.PietroOlivi.game 
{
    /*
     * Interface used as a strategy pattern, containing the 
     * interchangeable algorithm that creates moles/bombs in random 
     * number and positions (also assigning them an arbitrary appearance 
     * time) within the limits set by the current level of difficulty.
     */
    public interface IDrawStrategy 
    {
        /*
         * Method for randomly drawing moles and/or bombs.
         */
        ISet<GameObject> Draw(ILevel currentLevel, long currentTime);
    }
}
