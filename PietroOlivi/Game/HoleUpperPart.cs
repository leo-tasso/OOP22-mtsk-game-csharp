using OOP22_mtsk_game_csharp.LorenzoDalmonte.Api;

namespace OOP22_mtsk_game_csharp.PietroOlivi.Game
{
    /*
     * Class that represents the upper part of the hole or rather 
     * the semicircle that gives a 3D effect, above which moles and 
     * bombs will have to be displayed. Having a different appearance 
     * than the bottom, and having to keep it in a different 
     * position on the GameObject list, it has a class of its own.
     */
    public class HoleUpperPart : HolePart
    {
        /*
         * Simple constructor aimed at initializing hole's upper part
         */
        public HoleUpperPart(Point2D coor,
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
