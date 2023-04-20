using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;

namespace OOP22_mtsk_game_csharp.PietroOlivi.game
{
    /*
     * Class that models an hole's section in the Whac-a-Mole minigame.
     */
    internal class HolePart : WamObject
    {
        /*
         * Simple constructor aimed at initializing hole's section fields.
         */
        public HolePart(Point2D coor,
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

        override
        public bool IsGameOver() 
        {
            return false;
        }

        override
        public bool IsStillInUse() 
        {
            return true;
        }
    }
}
