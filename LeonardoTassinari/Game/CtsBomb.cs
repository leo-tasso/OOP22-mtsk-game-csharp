using OOP22_mtsk_game_csharp.LorenzoDalmonte.Api;

namespace OOP22_mtsk_game_csharp.LeonardoTassinari.Game
{
    internal class CtsBomb : GameObject
    {
        public int Timer { get; set; }
        private const int StartingTimer = 10_000;

        public CtsBomb(Point2D coor, int side, ColorRGB color) : base(coor, Vector2D.NullVector(), 0, null, new CtsBombTimerPhysics(), null,
                    new RectangleHitBoxModel(side, side))
        {
            Timer = StartingTimer;
        }
    }
}