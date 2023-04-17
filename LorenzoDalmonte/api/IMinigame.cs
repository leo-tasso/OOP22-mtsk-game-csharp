using System.Collections.Generic;

namespace OOP22_mtsk_game_csharp.LorenzoDalmonte.api
{
    public interface IMinigame {

        bool IsGameOver();

        void Compute(long elapsed);

        List<GameObject> GetObjects();

        string GetTutorial();
    }
}