using OOP22_mtsk_game_csharp.LorenzoDalmonte.Api;

namespace OOP22_mtsk_game_csharp.PietroOlivi.Game
{
    /*
     * The AspectModel for the Hole's lower section.
     */
    internal class HoleLowerPartAspectModel : IAspectModel
    {
        public void Update(GameObject obj, IDrawings drawing)
        {
            drawing.DrawHoleLowerPart(obj);
        }
    }
}
