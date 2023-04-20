using OOP22_mtsk_game_csharp.LeonardoTassinari.Game;
using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;

namespace OOP22_mtsk_game_csharp.LorenzoDalmonte.game
{
    public class FlappyPhysics : SimplePhysics
    {

        private static readonly double Y_MIN = 0;
        private static readonly double Y_MAX = 900;
        private static readonly double ACCEL = 0.1;
        private readonly double _cursorOffset;

        public FlappyPhysics(double cursorSize)
        {
            this._cursorOffset = cursorSize / 2;
        }

        public override void Update(long dt, GameObject obj, IMinigame miniGame)
        {
            base.Update(dt, obj, miniGame);
            bool onGround = obj.Coor.Y >= Y_MAX - _cursorOffset;
            obj.Vel = new Vector2D(0, obj.Vel.Y + (onGround ? 0 : ACCEL * dt));
            if (obj.Coor.Y < Y_MIN + _cursorOffset)
            {
                obj.Coor = new Point2D(obj.Coor.X, Y_MIN + _cursorOffset);
                obj.Vel = Vector2D.NullVector();
            }
            if (obj.Coor.Y > Y_MAX - _cursorOffset)
            {
                obj.Coor = new Point2D(obj.Coor.X, Y_MAX - _cursorOffset);
                obj.Vel = Vector2D.NullVector();
            }
        }
    }
}