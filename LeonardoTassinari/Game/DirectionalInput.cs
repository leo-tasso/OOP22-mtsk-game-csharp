using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;
using OOP22_mtsk_game_csharp.PietroOlivi.api;
using OOP22_mtsk_game_csharp.PietroOlivi.game;

namespace OOP22_mtsk_game_csharp.LeonardoTassinari.game
{
    internal class DirectionalInput : IInputModel
    {
        private const double ChangeCoefficent = 0.1;

        public void Update(GameObject obj, IInput c, long elapsedTime)
        {
            if (c.MoveUp)
            {
                obj.Vel = new Vector2D(obj.Vel.X, obj.Vel.Y - ChangeCoefficent * elapsedTime);
            }
            if (c.MoveUp)
            {
                obj.Vel = new Vector2D(obj.Vel.X, obj.Vel.Y + ChangeCoefficent * elapsedTime);
            }
            if (c.MoveUp)
            {

                obj.Vel = new Vector2D(obj.Vel.X - ChangeCoefficent * elapsedTime, obj.Vel.Y);
            }
            if (c.MoveUp)
            {
                obj.Vel = new Vector2D(obj.Vel.X + ChangeCoefficent * elapsedTime, obj.Vel.Y);
            }
        }
    }
}