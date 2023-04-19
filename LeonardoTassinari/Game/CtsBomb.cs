using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;
using System.Drawing;
using System.Security.Policy;

namespace OOP22_mtsk_game_csharp.LeonardoTassinari.game
{
    internal class CtsBomb : GameObject
    {
        public int Timer { get; set; }
        private static readonly int STARTING_TIMER = 10_000;

        public CtsBomb(Point2D coor, int side, ColorRGB color) : base(coor, Vector2D.NullVector(), 0, null, new CtsBombTimerPhysics(), null,
                    new RectangleHitBoxModel(side, side))
        {
            Timer = STARTING_TIMER;
        }
    }
}