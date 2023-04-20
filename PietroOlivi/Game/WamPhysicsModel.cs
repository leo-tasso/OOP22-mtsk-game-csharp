using OOP22_mtsk_game_csharp.LeonardoTassinari.Game;
using OOP22_mtsk_game_csharp.LorenzoDalmonte.Api;

namespace OOP22_mtsk_game_csharp.PietroOlivi.Game 
{
    /*
     * Class that deals with the physics of
     * objects in the Whac-A-Mole minigame.
     */
    public class WamPhysicsModel : SimplePhysics
    {
        /*
         * Method that manages the vertical translations of
         * the GameObjects, also checking if they have reached
         * their maximum position (and if so, it stops them).
         */
        override
        public void Update(long dt, GameObject obj, IMinigame miniGame)
        {
            base.Update(dt, obj, miniGame); 
            if (obj is WamObject && miniGame is WhacAMole) 
            {
                WamObject wamObj = (WamObject) obj;
                long currentTime = ((WhacAMole) miniGame).CurrentTime;
                if (wamObj.Coor.Y <= wamObj.GetStartCoor().Y - WamObject.DELTA_Y
                        && !wamObj.GetStatus().Equals(Status.HALFWAY)) 
                {
                    wamObj.SetStatus(Status.HALFWAY);
                    wamObj.Vel = Vector2D.NullVector();
                    wamObj.SetMotionRestartTime(currentTime + wamObj.GetLevel().GetHalfwayTime());
                }
            }
        }
    }
}
