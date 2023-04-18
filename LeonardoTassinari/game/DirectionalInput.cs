using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;
using OOP22_mtsk_game_csharp.PietroOlivi.api;
using OOP22_mtsk_game_csharp.PietroOlivi.game;

namespace OOP22_mtsk_game_csharp.LeonardoTassinari.game
{
    internal class DirectionalInput : IInputModel
    {
        private static readonly double CHANGE_COEFFICENT = 0.1;

        public void Update(GameObject obj, IInput c, long elapsedTime)
        {
            if (c.MoveUp)
            {
                obj.Vel = new Vector2D(obj.Vel.X, obj.Vel.Y - CHANGE_COEFFICENT * elapsedTime);
            }
            if (c.MoveUp)
            {
                obj.Vel = new Vector2D(obj.Vel.X, obj.Vel.Y + CHANGE_COEFFICENT * elapsedTime);
            }
            if (c.MoveUp)
            {

                obj.Vel = new Vector2D(obj.Vel.X - CHANGE_COEFFICENT * elapsedTime, obj.Vel.Y);
            }
            if (c.MoveUp)
            {
                obj.Vel = new Vector2D(obj.Vel.X + CHANGE_COEFFICENT * elapsedTime, obj.Vel.Y);
            }
        }
    }
}