using OOP22_mtsk_game_csharp.LorenzoDalmonte.Api;

namespace OOP22_mtsk_game_csharp.PietroOlivi.Game 
{
    /*
     * I order to draw the Bomb only if it has actually 
     * entered the game, i.e. if it has already been 
     * spawned, in which case I distinguish the object's 
     * appearance based on whether it has been hit or not.
     */
    public class WamBombAspectModel : IAspectModel
    {
        public void Update(GameObject obj, IDrawings drawing)
        {        
            if (obj is WamObject) 
            {
                Status status = ((WamObject) obj).GetStatus();
                if (!status.Equals(Status.WAITING)) 
                {
                    if (status.Equals(Status.HIT)) 
                    {
                        drawing.DrawWamBomb(obj, true);
                    } 
                    else 
                    {
                        drawing.DrawWamBomb(obj, false);
                    }
                }
            }
        }
    }
}
