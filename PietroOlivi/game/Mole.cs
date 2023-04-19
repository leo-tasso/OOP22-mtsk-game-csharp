
using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;

namespace OOP22_mtsk_game_csharp.PietroOlivi.game 
{
    /*
     * Class that models the mole character in the Whac-a-Mole minigame.
     */
    public class Mole : WamObject 
    {
        /*
         * Simple constructor aimed at initializing Mole fields.
         */
        public Mole(Point2D startCoor,
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

        /*
         * Method that checks if the mole caused 
         * the end of the game, i.e. if it managed 
         * to re-enter its hole without being hit.
         */
        override
        public bool IsGameOver() 
        {
            return this.GetStatus().Equals(Status.MISSED);
        }

        /*
         * Method that checks if the mole instance is 
         * still used in the game or can be deleted.
         */
        override
        public bool IsStillInUse() 
        {
            return !(this.GetStatus().Equals(Status.HIT) 
                    && this.Coor.Y > this.GetStartCoor().Y);
        }
    }
}
