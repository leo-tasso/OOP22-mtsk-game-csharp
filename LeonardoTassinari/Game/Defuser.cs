using OOP22_mtsk_game_csharp.LorenzoDalmonte.Api;
using OOP22_mtsk_game_csharp.PietroOlivi.Game;

namespace OOP22_mtsk_game_csharp.LeonardoTassinari.Game
{
    internal class Defuser : GameObject
    {
        private static readonly ColorRGB CIRCLE_COLOR = ColorRGB.Black;
        public Defuser(Point2D coor, int defuserRadius, IInputModel defuserInputModel, IPhysicsModel defuserPhysicsModel) : base(coor, Vector2D.NullVector(), 0, defuserInputModel, defuserPhysicsModel,
                new CircleAspect(defuserRadius, CIRCLE_COLOR), new CircleHitBoxModel(defuserRadius))
        {
        }
    }
}