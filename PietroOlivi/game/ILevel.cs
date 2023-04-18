using OOP22_mtsk_game_csharp.LeonardoTassinari.game;
using OOP22_mtsk_game_csharp.PietroOlivi.api;

namespace OOP22_mtsk_game_csharp.PietroOlivi.game 
{

    /*
     * Interface that models a whac-a-mole game level.
     */
    public interface ILevel 
    {

        /*
         * The higher the level goes, the more difficult the game 
         * will be, and therefore the maximum number of moles and
         * /or bombs displayed at the same time will increase.
         */
        int GetMaxObjsSimultaneouslyOut();

        /*
         * Another factor that determines the difficulty of a level
         * is the speed with which moles and bombs go up and down the 
         * holes: the faster they go, the more difficult it will be.
         */
        Vector2D GetObjSpeed();

        /*
         * Being that I extract GameObjects only when the list of them 
         * becomes "empty", the longer GameObjects wait to be spawned
         * ==> the slower the list will empty
         * ==> moles will come out less frequently
         * ==> the easier the level will be.
         */
        TimeInterval GetSpawnWaitingTime();

        /*
         * Method which, depending on the current level, returns the length 
         * of time in which an object remains stationary once it reaches the point 
         * of maximum distance from the ground (the higher the level, the shorter 
         * the time an object will remain stationary at the point of maximum 
         * elevation, therefore the shorter the total time spent outside the hole).
         */
        long GetHalfwayTime();
    }
}
