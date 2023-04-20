using System;
using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;

namespace OOP22_mtsk_game_csharp.LorenzoDalmonte.game
{
    public class DatTriangleAspectModel : IAspectModel
    {

        private readonly int _side;
        private readonly bool _rightSpawn;

        public DatTriangleAspectModel(int side, bool rightSpawn)
        {
            this._side = side;
            this._rightSpawn = rightSpawn;
        }

        public void Update(GameObject obj, IDrawings drawing)
        {
            drawing.DrawTriangle(obj, ColorRGB.Orange, _side, _rightSpawn ? Math.PI : 0);
        }
    }
}