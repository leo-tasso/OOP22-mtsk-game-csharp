using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;
using OOP22_mtsk_game_csharp.PietroOlivi.api;

namespace OOP22_mtsk_game_csharp.PietroOlivi.game 
{
    public class WamInputModel : IInputModel
    {
        /*
         * I change the appearance of the hit object, then if it was a mole 
         * I make it go back to its hole, while if it was a bomb the game 
         * will end at the beginning of the next iteration of the mainLoop.
         */
        public void Update(GameObject obj, IInput c, long elapsedTime)
        {
            if (obj is WamObject) 
            {
                WamObject wamObj = (WamObject) obj;
                if (wamObj.GetHoleNumber() == c.NumberPressed.GetValueOrDefault(0)
                    && (wamObj.GetStatus().Equals(Status.IN_MOTION)
                    ||  wamObj.GetStatus().Equals(Status.HALFWAY))) 
                {
                    wamObj.SetStatus(Status.HIT);
                    if (wamObj.Vel.Y <= 0) 
                    {
                        wamObj.Vel = wamObj.GetLevel().GetObjSpeed().Invert();
                    }
                }
            }
        }
    }
}
