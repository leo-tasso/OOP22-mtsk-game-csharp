using System.Collections.Generic;

namespace OOP22_mtsk_game_csharp.LorenzoDalmonte.api
{
    public interface IMinigame
    {

        bool IsGameOver();

        void Compute(long elapsed);

        IList<GameObject> GetObjects();

        string GetTutorial();
    }
}