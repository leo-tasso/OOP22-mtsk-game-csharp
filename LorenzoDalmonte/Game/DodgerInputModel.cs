using OOP22_mtsk_game_csharp.LeonardoTassinari.Game;
using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;
using OOP22_mtsk_game_csharp.PietroOlivi.api;
using OOP22_mtsk_game_csharp.PietroOlivi.game;

namespace OOP22_mtsk_game_csharp.LorenzoDalmonte.game
{
    public class DodgerInputModel : IInputModel {

        private readonly Point2D forward;
        private readonly Point2D backwards;
        private readonly int limitLow;
        private readonly int limitHigh;
        private bool hold;

        public DodgerInputModel(int step, int initialY)
        {
            this.forward = new Point2D(0, -step);
            this.backwards = new Point2D(0, step);
            this.limitLow = initialY - 2 * step;
            this.limitHigh = initialY + 2 * step;
        }

        public void Update(GameObject obj, IInput c, long elapsedTime)
        {
            if (!hold && c.Forward && obj.Coor.Y > limitLow)
            {
                obj.Coor = obj.Coor.Sum(forward);
                this.hold = true;
            }
            if (!hold && c.Backwards && obj.Coor.Y < limitHigh)
            {
                obj.Coor = obj.Coor.Sum(backwards);
                this.hold = true;
            }
            if (!(c.Forward || c.Backwards))
            {
                this.hold = false;
            }
            obj.Vel = Vector2D.NullVector();
        }
    }
}