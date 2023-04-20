using System;
using OOP22_mtsk_game_csharp.LeonardoTassinari.Game;
using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;
using OOP22_mtsk_game_csharp.PietroOlivi.game;

namespace OOP22_mtsk_game_csharp.LorenzoDalmonte.game
{
    public class DatTriangle : GameObject
    {
        public DatTriangle(Point2D coor, Vector2D vel, int side) : base(coor, vel)
        {
            this.Input = new NullInput();
            this.Physics = new SimplePhysics();
            this.Aspect = new DatTriangleAspectModel(side, coor.X > 0);
            this.HitBox = new RectangleHitBoxModel(side * Math.Sqrt(3) / 2, side);
        }
    }
}