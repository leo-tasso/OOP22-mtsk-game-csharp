using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;

namespace OOP22_mtsk_game_csharp.PietroOlivi.game
{
    /*
     * The AspectModel for the Hole's upper section.
     */
    public class HoleUpperPartAspectModel : IAspectModel
    {
        public void Update(GameObject obj, IDrawings drawing)
        {
            drawing.DrawHoleUpperPart(obj);
        }
    }
}
