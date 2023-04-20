
using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;

namespace OOP22_mtsk_game_csharp.PietroOlivi.game
{
    /*
     * Class that models the bomb character in the Whac-a-Mole minigame.
     */
    public class WamBomb : WamObject
    {
        /*
         * Simple constructor aimed at initializing Bomb fields.
         */
        public WamBomb(Point2D startCoor,
            long appearanceTime,
            ILevel currentLevel,
            int holeNumber,
            IPhysicsModel physicsModel,
            IAspectModel aspectModel,
            IInputModel inputModel) : base(
                startCoor,
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
            return this.GetStatus().Equals(Status.HIT);
        }

        override
        public bool IsStillInUse()
        {
            return !this.GetStatus().Equals(Status.MISSED);
        }
    }
}
