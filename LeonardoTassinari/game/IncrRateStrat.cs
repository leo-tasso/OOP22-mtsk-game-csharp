using System;

namespace OOP22_mtsk_game_csharp.LeonardoTassinari.game
{
    public class IncrRateStrat
    {
        private readonly double difficulty;
        private readonly double flattenSpawnRate; // the maximum steepness of the curve.

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
            this.difficulty = difficulty;
            this.flattenSpawnRate = flattenSpawnRate;
        }
        public long Invoke(long totalElapsed)
        {
            if (Math.Pow(difficulty, (double)totalElapsed / 1000) * Math.Log(difficulty) > flattenSpawnRate)
            {
                double x = Math.Log(flattenSpawnRate / Math.Log(difficulty)) / Math.Log(difficulty);
                return (long)(((double)totalElapsed / 1000 - x) * Math.Pow(difficulty, x) * Math.Log(difficulty)
                    + Math.Pow(difficulty, x));
            }
            return (long)Math.Pow(difficulty, (double)totalElapsed / 1000);
        }
    }
}
