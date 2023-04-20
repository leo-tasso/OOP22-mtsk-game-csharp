using OOP22_mtsk_game_csharp.LeonardoTassinari.game;
using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;

namespace OOP22_mtsk_game_csharp.LorenzoDalmonte.game
{
    public class SlotAspect : IAspectModel
    {
        private readonly double _side;
        private readonly Point2D _center;
        private readonly int _numSlots;
        private readonly int _slotOffset;

        public SlotAspect(double side, Point2D center, int numSlots)
        {
            this._side = side;
            this._center = center;
            this._numSlots = numSlots;
            this._slotOffset = numSlots / 2;
        }

        public void Update(GameObject obj, IDrawings drawing)
        {
            for (int i = 0; i < _numSlots; i++)
            {
                drawing.DrawSquare(
                    new GameObject(_center.Sum(new Point2D(0, (i - _slotOffset) * _side)),
                    Vector2D.NullVector()),
                    ColorRGB.Black,
                    _side,
                    false);
            }
        }
    }
}