using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;
using System;

namespace OOP22_mtsk_game_csharp.LeonardoTassinari.Game
{
    internal class CtsBombTimerPhysics : IPhysicsModel
    {
        public void Update(long dt, GameObject obj, IMinigame miniGame)
        {
            if (!(obj is CtsBomb))
            {
                throw new Exception("TimerPhysics can be used only on Bomb or his subclasses");
            }
            CtsBomb bObj = (CtsBomb)obj;
            bObj.Timer = (int)(bObj.Timer - dt);

        }
    }
}