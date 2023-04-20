using System;
using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;

namespace OOP22_mtsk_game_csharp.LorenzoDalmonte.game
{
    public class CursorAspect : IAspectModel
    {
        private readonly double _size;
        private readonly double _xSpeed;

        public CursorAspect(double size, double xSpeed)
        {
            this._size = size;
            this._xSpeed = xSpeed;
        }

        public void Update(GameObject obj, IDrawings drawing)
        {
            drawing.DrawTriangle(obj, ColorRGB.Blue, _size, Math.Atan(obj.Vel.Y / _xSpeed));
        }
    }
}