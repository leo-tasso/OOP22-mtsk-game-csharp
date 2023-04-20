using System;
using System.Collections.Generic;
using OOP22_mtsk_game_csharp.LeonardoTassinari.Game;
using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;

namespace OOP22_mtsk_game_csharp.PietroOlivi.game
{
    /*
     * Class that manages the creation and location of dens from 
     * which moles and bombs come and go in the game Whac-a-Mole,
     * ideal for a number of burrows whose root is an integer.
     */
    internal class SquareHolesGenerator : IHolesGeneratorStrategy
    {
        private static readonly double RATIO = 16.0 / 9.0;
        private readonly int _fieldHeight;
        private readonly int _fieldWidth;

        /*
         * Constructor that sets the value of the height 
         * of the playing field and calculate its width.
         */
        public SquareHolesGenerator(int fieldHeight) 
        {
            _fieldHeight = fieldHeight;
            _fieldWidth = (int) (fieldHeight * RATIO);
        }

        /*
         * Taking the dimensions (in coor) of the playing field and 
         * the number of holes in the game, places the holes in a 
         * "table" where the number of rows of columns is the same.
         */
        public IList<WamObject> Generate(int numHoles) 
        {
            IList<WamObject> holes = new List<WamObject>();
            int dx = (int) (_fieldWidth / (Math.Sqrt(numHoles) * 2));
            int dy = (int) (_fieldHeight / (Math.Sqrt(numHoles) * 2));
            int holesPerRow = (int) Math.Sqrt(numHoles);
            int holesCounter = 1;
            /* I fill the list so that in the end it has the first half */
            /* of HoleUpperPart and the second half of HoleLowerPart    */
            for (int y = dy; holesCounter <= numHoles; y += dy * 2) 
            {
                int holesInThisRow = 0;
                for (int x = dx;  holesInThisRow < holesPerRow; x += dx * 2) 
                {
                    holes.Add(new HoleUpperPart(
                        new Point2D(x, y),
                        0, 
                        new LevelNull(), 
                        holesCounter,
                        new SimplePhysics(), 
                        new HoleLowerPartAspectModel(),
                        new NullInput()));
                    holes.Insert(holesCounter - 1, new HoleLowerPart(
                        new Point2D(x, y),
                        0, 
                        new LevelNull(), 
                        holesCounter++, 
                        new SimplePhysics(), 
                        new HoleUpperPartAspectModel(), 
                        new NullInput()));
                    holesInThisRow += 1;
                }
            }
            return holes;
        }
    }
}
