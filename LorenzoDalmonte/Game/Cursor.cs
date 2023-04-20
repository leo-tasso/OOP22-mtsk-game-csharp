using System;
using OOP22_mtsk_game_csharp.LeonardoTassinari.Game;
using OOP22_mtsk_game_csharp.LorenzoDalmonte.Api;
using OOP22_mtsk_game_csharp.PietroOlivi.Game;

namespace OOP22_mtsk_game_csharp.LorenzoDalmonte.Game
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