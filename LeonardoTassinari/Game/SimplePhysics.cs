using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;

namespace OOP22_mtsk_game_csharp.LeonardoTassinari.game
{
    internal class SimplePhysics : IPhysicsModel
    {
        private static readonly double SPEED_COEFF = 0.01;
        public void Update(long dt, GameObject obj, IMinigame miniGame)
        {
            Point2D pos = obj.Coor;
            Vector2D vel = obj.Vel;
            obj.Coor = (pos.Sum(vel.Mul(SimplePhysics.SPEED_COEFF * dt)));
        }
    }
}