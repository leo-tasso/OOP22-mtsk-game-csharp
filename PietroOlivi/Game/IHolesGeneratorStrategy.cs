using System.Collections.Generic;

namespace OOP22_mtsk_game_csharp.PietroOlivi.game
{
    /*
     * Interface for the burrow placement and creation algorithm.
     */
    internal interface IHolesGeneratorStrategy
    {
        /*
         * Method responsible for placing and making holes.
         */
        IList<WamObject> Generate(int numHoles);
    }
}
