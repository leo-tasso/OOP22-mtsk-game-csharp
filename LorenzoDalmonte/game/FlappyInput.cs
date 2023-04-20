using OOP22_mtsk_game_csharp.LeonardoTassinari.game;
using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;
using OOP22_mtsk_game_csharp.PietroOlivi.api;
using OOP22_mtsk_game_csharp.PietroOlivi.game;

namespace OOP22_mtsk_game_csharp.LorenzoDalmonte.game
{
    public class FlappyInput : IInputModel
    {
        private static readonly double SPEED_RATIO = -90d;
        private readonly double _upwardSpeed;
        private bool _hold;

        public FlappyInput(int height)
        {
            this._upwardSpeed = height / SPEED_RATIO;
        }

        public void Update(GameObject obj, IInput c, long elapsedTime)
        {
            if (c.Jump && !_hold)
            {
                this._hold = true;
                obj.Vel = new Vector2D(0, _upwardSpeed * elapsedTime);
            }

            if (!c.Jump && _hold)
            {
                this._hold = false;
            }
        }
    }
}