
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;
using OOP22_mtsk_game_csharp.PietroOlivi.api;
using OOP22_mtsk_game_csharp.PietroOlivi.game;

#nullable enable
namespace OOP22_mtsk_game_csharp.PietroOlivi.test
{

    /*
     * Tests for the minigame Whac-a-Mole.
     */
    class WhacAMoleTest 
    {
        private static readonly int ELAPSED_TIME = 10;
        private static readonly int FRAME_HEIGHT = 900;

        [Test]
        public void HitMoleTest() 
        {
            IMinigame wam = new WhacAMole(FRAME_HEIGHT);

            while (wam.GetObjects()
                    .Any(o => !(o is Mole))
                || wam.GetObjects()
                    .Where(o => o is Mole)
                    .Any(o => !(((WamObject) o).GetAppearanceTime() < ((WhacAMole) wam).CurrentTime)))
            {
                /* I iterate until at least one mole is drawn and actually */
                /* comes out of one of the holes becoming hittable         */ 
                wam.Compute(ELAPSED_TIME);
            }
            /* I pick the Mole with the closest appearance time and I hit it.      */
            /* If any bombs have been drawn in the meantime, this won't cause any  */
            /* problems, as if they aren't hit they won't alter the GameOver value */
            WamObject? moleToHit = wam.GetObjects()
                    .Where(o => o is Mole)
                    .Cast<WamObject>()
                    .OrderBy(o => o.GetAppearanceTime())
                    .First();

            IInput input = new KeyboardInput();
            input.NumberPressed = new int?(moleToHit.GetHoleNumber());
            moleToHit.Updateinput(input, ELAPSED_TIME);
            Assert.True(moleToHit.GetStatus().Equals(Status.HIT) && !wam.IsGameOver());
        }

        [Test]
        public void MissMoleTest() 
        {
            IMinigame wam = new WhacAMole(FRAME_HEIGHT);

            while (wam.GetObjects()
                    .Any(o => !(o is Mole))
                || wam.GetObjects()
                    .Where(o => o is Mole)
                    .Any(o => !(((WamObject) o).GetStatus().Equals(Status.IN_MOTION))))
            {
                wam.Compute(ELAPSED_TIME);
            }

            WamObject? moleToMiss = wam.GetObjects()
                .Where(o => o is Mole)
                .Cast<WamObject>()
                .OrderBy(o => o.GetAppearanceTime())
                .First();
            /* I iterate until the mole re-enters the den that */
            /* has been assigned to it, without hitting it     */
            while (moleToMiss.Coor.Y <= moleToMiss.GetStartCoor().Y) 
            {
                wam.Compute(ELAPSED_TIME);
            }
            Assert.True(moleToMiss.GetStatus().Equals(Status.MISSED) && wam.IsGameOver());
        }

        [Test]
        public void HitWamBombTest() 
        {
            IMinigame wam = new WhacAMole(FRAME_HEIGHT);

            while (wam.GetObjects()
                    .Any(o => !(o is WamBomb))
                || wam.GetObjects()
                    .Where(o => o is WamBomb)
                    .Any(o => !(((WamObject) o).GetStatus().Equals(Status.IN_MOTION)))) 
            {
                /* I iterate until at least one bomb is drawn and actually */
                /* comes out of one of the holes becoming hittable         */
                DeleteMoles(wam);
                wam.Compute(ELAPSED_TIME);
            }

            WamObject? bombToHit = wam.GetObjects()
                    .Where(o => o is WamBomb)
                    .Cast<WamObject>()
                    .OrderBy(o => o.GetAppearanceTime())
                    .First();

            IInput input = new KeyboardInput();
            input.NumberPressed = new int?(bombToHit.GetHoleNumber());
            bombToHit.Updateinput(input, ELAPSED_TIME);
            Assert.True(bombToHit.GetStatus().Equals(Status.HIT) && wam.IsGameOver());
        }

        [Test]
        public void MissWamBombTest() 
        {
            IMinigame wam = new WhacAMole(FRAME_HEIGHT);

            while (wam.GetObjects()
                    .Any(o => !(o is WamBomb))
                || wam.GetObjects()
                    .Where(o => o is WamBomb)
                    .Any(o => !(((WamObject) o).GetAppearanceTime() < ((WhacAMole) wam).CurrentTime))) 
            {
                DeleteMoles(wam);
                wam.Compute(ELAPSED_TIME);
            }

            WamObject? bombToMiss = wam.GetObjects()
                    .Where(o => o is WamBomb)
                    .Cast<WamObject>()
                    .OrderBy(o => o.GetAppearanceTime())
                    .First();
            /* After taking the reference to the closest bomb    */
            /* in terms of appearance, I make it exit and return */
            /* to the lair, then verifying that it is correctly  */
            /* marked as MISSED and that the game does not end   */
            while (bombToMiss.Coor.Y <= bombToMiss.GetStartCoor().Y) 
            {
                wam.Compute(ELAPSED_TIME);
            }
            Assert.True(bombToMiss.GetStatus().Equals(Status.MISSED) && !wam.IsGameOver());
        }

        /*
         * I need to eliminate all possible moles, since by not
         * handling their input (not hitting them) they could be the
         * cause of the gameOver and produce a "false positive" test.
         */
        private void DeleteMoles(IMinigame wam) 
        {
            List<WamObject> objs = new List<WamObject>();
            foreach(WamObject o in wam.GetObjects().Cast<WamObject>())
            {
                objs.Add(o);
            }
            objs.RemoveAll(o => o is Mole);
            ((WhacAMole) wam).SetObjects(objs);
        }
    }
}