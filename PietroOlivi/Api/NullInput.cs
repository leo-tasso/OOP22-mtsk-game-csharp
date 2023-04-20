using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;
using OOP22_mtsk_game_csharp.PietroOlivi.api;

namespace OOP22_mtsk_game_csharp.PietroOlivi.game
{
    /*
     * Class for GameObjects that reqires no inputs.
     */
    public class NullInput : IInputModel
    {
        public void Update(GameObject obj, IInput c, long elapsedTime)
        {
        }
    }
}
