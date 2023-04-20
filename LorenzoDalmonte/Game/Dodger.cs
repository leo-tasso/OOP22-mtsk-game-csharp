using OOP22_mtsk_game_csharp.PietroOlivi.Game;
using OOP22_mtsk_game_csharp.LorenzoDalmonte.Api;
using OOP22_mtsk_game_csharp.LeonardoTassinari.Game;

namespace OOP22_mtsk_game_csharp.LorenzoDalmonte.Game
{
    public class Dodger : GameObject
    {
        private static readonly double RATIO = 16 / 9.0;

        public Dodger(int initialY, int size, IInputModel inputModel) : base(new Point2D(initialY * RATIO, initialY), Vector2D.NullVector())
        {
            this.Input = inputModel;
            this.Physics = new SimplePhysics();
            this.Aspect = new RectangleAspect(size, size, ColorRGB.Red, true);
            this.HitBox = new SquareHitBoxModel(size);
        }
    }
}