﻿using OOP22_mtsk_game_csharp.LorenzoDalmonte.Api;

namespace OOP22_mtsk_game_csharp.LeonardoTassinari.Game
{
    public class SimplePhysics : IPhysicsModel
    {
        private const double SpeedCoeff = 0.01;

        public virtual void Update(long dt, GameObject obj, IMinigame miniGame)
        {
            Point2D pos = obj.Coor;
            Vector2D vel = obj.Vel;
            obj.Coor = (pos.Sum(vel.Mul(SimplePhysics.SpeedCoeff * dt)));
        }
    }
}