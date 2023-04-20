namespace OOP22_mtsk_game_csharp.LorenzoDalmonte.Api
{
    public interface IPhysicsModel
    {
        void Update(long dt, GameObject obj, IMinigame miniGame);
    }
}