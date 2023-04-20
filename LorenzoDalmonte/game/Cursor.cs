using System;
using OOP22_mtsk_game_csharp.LeonardoTassinari.game;
using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;
using OOP22_mtsk_game_csharp.PietroOlivi.game;

namespace OOP22_mtsk_game_csharp.LorenzoDalmonte.game
{
    public class Cursor : GameObject
    {
        public Cursor(Point2D coor, Vector2D vel, double size, double xSpeed, IInputModel inputModel) : base(coor, vel)
        {
            double radius = size / Math.Sqrt(3) * 3 / 4;
            this.Input = inputModel;
            this.Physics = new FlappyPhysics(size);
            this.Aspect = new CursorAspect(size, xSpeed);
            this.HitBox = new CircleHitBoxModel(radius);
        }
    }
}