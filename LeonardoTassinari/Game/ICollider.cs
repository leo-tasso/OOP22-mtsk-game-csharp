using OOP22_mtsk_game_csharp.LorenzoDalmonte.Api;

namespace OOP22_mtsk_game_csharp.LeonardoTassinari.Game
{
    public interface ICollider
    {
        bool IsColliding(GameObject g, GameObject h);

    }
}