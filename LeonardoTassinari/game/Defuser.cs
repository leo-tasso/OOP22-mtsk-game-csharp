using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;
using OOP22_mtsk_game_csharp.PietroOlivi.game;

namespace OOP22_mtsk_game_csharp.LeonardoTassinari.game
{
    internal class Defuser : GameObject
    {
        public Defuser(Point2D coor, int dEFUSER_RADIUS, IInputModel defuserInputModel) : base(coor,Vector2D.NullVector(),0,defuserInputModel,null,null)
        {
        }
    }
}