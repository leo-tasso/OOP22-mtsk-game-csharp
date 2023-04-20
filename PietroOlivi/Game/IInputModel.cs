using OOP22_mtsk_game_csharp.LorenzoDalmonte.Api;
using OOP22_mtsk_game_csharp.PietroOlivi.Api;

namespace OOP22_mtsk_game_csharp.PietroOlivi.Game 
{
    /*
     * Interface that allows to apply the changes
     * requested by the input on the object.
     */
    public interface IInputModel 
    {
        /*
         * Method to update the state of an object according the inputs.
         */
        void Update(GameObject obj, IInput c, long elapsedTime);
    }
}
