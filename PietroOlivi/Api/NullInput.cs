using OOP22_mtsk_game_csharp.LorenzoDalmonte.Api;
using OOP22_mtsk_game_csharp.PietroOlivi.Api;

namespace OOP22_mtsk_game_csharp.PietroOlivi.Game
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
