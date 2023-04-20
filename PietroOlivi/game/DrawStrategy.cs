using System;
using System.Collections.Generic;
using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;

namespace OOP22_mtsk_game_csharp.PietroOlivi.game 
{
    /*
     * Class that implements a simple draw of GameObjects.
     */
    public class DrawStrategyImpl : IDrawStrategy 
    {
        private static readonly long SAFETY_TIME_MARGIN = 10L;
        private static readonly Random RANDOM = new Random();
        private readonly IList<GameObject> _holes;

        /*
         * Constructor that takes the list of holes 
         * in the game, from which to take the initial 
         * coordinates of the created objects. 
         */
        public DrawStrategyImpl(IList<GameObject> holes) 
        {
            _holes = new List<GameObject>();
            foreach(var hole in holes)
                _holes.Add(hole);
        }

        public ISet<GameObject> Draw(ILevel currentLevel, long currentTime) 
        {
            ISet<GameObject> newGameObjs = new HashSet<GameObject>();
            int maxObjs = currentLevel.GetMaxObjsSimultaneouslyOut();
            var holesOccupied = new Dictionary<int, bool>();
            for (int i = 1; i <= _holes.Count; i++) 
            {
                holesOccupied.Add(i, false);
            }
            int nMoles = RANDOM.Next(maxObjs + 1);
            int nBombs = RANDOM.Next(maxObjs - nMoles + 1); 
            /* To avoid assigning an appearance time so close that */
            /* the program is still executing the underlying loops */
            long lowerBound = currentTime + SAFETY_TIME_MARGIN;
            for (int i = 0; i < nMoles; i++) 
            {
                int holeAssigned = AssignHole(holesOccupied);
                long appearanceTime = lowerBound + currentLevel.GetSpawnWaitingTime().DrawInBetween();
                newGameObjs.Add(
                    new Mole(_holes[holeAssigned - 1].Coor,
                            appearanceTime, 
                            currentLevel, 
                            holeAssigned, 
                            new WamPhysicsModel(), 
                            new MoleAspectModel(), 
                            new WamInputModel())
                );
            }
            for (int i = 0; i < nBombs; i++) 
            {
                int holeAssigned = AssignHole(holesOccupied);
                long appearanceTime = lowerBound + currentLevel.GetSpawnWaitingTime().DrawInBetween();
                newGameObjs.Add(
                    new WamBomb(_holes[holeAssigned - 1].Coor,
                            appearanceTime,
                            currentLevel,
                            holeAssigned,
                            new WamPhysicsModel(),
                            new WamBombAspectModel(), 
                            new WamInputModel())
                );
            }
            return newGameObjs; 
        }

        /*
         * Method that randomly assigns a Hole from 
         * which to make the bomb or mole emerge.
         */
        private int AssignHole(IDictionary<int, bool> holesOccupied) 
        {
            bool holeFound = false;
            int holeAssigned = RANDOM.Next(holesOccupied.Count) + 1;
            while (!holeFound) 
            {
                if (!holesOccupied[holeAssigned]) 
                {
                    holesOccupied[holeAssigned] = true;
                    return holeAssigned;
                } 
                holeAssigned = RANDOM.Next(holesOccupied.Count) + 1;
            }
            return holeAssigned;
        }
    }
}
