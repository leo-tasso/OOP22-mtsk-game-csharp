using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;

namespace OOP22_mtsk_game_csharp.PietroOlivi.game 
{
    /*
     * The AspectModel for the Mole object.
     */
    public class MoleAspectModel : IAspectModel
    {
        /*
         * I order to draw the Mole only if it has actually 
         * entered the game, i.e. if it has already been 
         * spawned, in which case I distinguish the object's 
         * appearance based on whether it has been hit or not.
         */
        public void Update(GameObject obj, IDrawings drawing)
        {
            if (obj is WamObject) 
            {
                Status status = ((WamObject) obj).GetStatus();
                if (!status.Equals(Status.WAITING)) 
                {
                    if (status.Equals(Status.HIT)) 
                    {
                        drawing.DrawMole(obj, true);
                    } 
                    else 
                    {
                        drawing.DrawMole(obj, false);
                    }
                } 
            }
        }
    }
}
