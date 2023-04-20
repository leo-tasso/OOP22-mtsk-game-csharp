using OOP22_mtsk_game_csharp.LeonardoTassinari.Game;
using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;

namespace OOP22_mtsk_game_csharp.PietroOlivi.game
{
    /*
     * Class that represents the lower part of the hole, 
     * i.e. the "tube" from which moles and bombs come out 
     * and re-enter, and which therefore must hide these.
     */
    public class HoleLowerPart : HolePart
    {
        /*
         * Simple constructor aimed at initializing the hole's lower part.
         */
        public HoleLowerPart(Point2D coor,
            long appearanceTime,
            ILevel currentLevel,
            int holeNumber,
            IPhysicsModel physicsModel,
            IAspectModel aspectModel,
            IInputModel inputModel) : base(
                coor, 
                appearanceTime, 
                currentLevel, 
                holeNumber, 
                physicsModel, 
                aspectModel, 
                inputModel
            )
        {
        }
    }
}
