using System;

namespace OOP22_mtsk_game_csharp.LeonardoTassinari.game
{
    public class IncrRateStrat
    {
        private readonly double _difficulty;
        private readonly double _flattenSpawnRate; // the maximum steepness of the curve.

        /**
         * Constructor allows to set the rate of increase of the spawn.
         * 
         * @param difficulty       the rate of increase of the spawning objects.
         *                         Suggested
         *                         values 1 &lt; x &lt; 1.3
         * @param flattenSpawnRate the maximum rate, once reached it will be kept
         */
        public IncrRateStrat(double difficulty, double flattenSpawnRate)
        {
            this._difficulty = difficulty;
            this._flattenSpawnRate = flattenSpawnRate;
        }
        public long Invoke(long totalElapsed)
        {
            if (Math.Pow(_difficulty, (double)totalElapsed / 1000) * Math.Log(_difficulty) > _flattenSpawnRate)
            {
                double x = Math.Log(_flattenSpawnRate / Math.Log(_difficulty)) / Math.Log(_difficulty);
                return (long)(((double)totalElapsed / 1000 - x) * Math.Pow(_difficulty, x) * Math.Log(_difficulty)
                    + Math.Pow(_difficulty, x));
            }
            return (long)Math.Pow(_difficulty, (double)totalElapsed / 1000);
        }
    }
}
