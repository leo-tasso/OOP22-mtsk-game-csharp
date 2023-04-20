using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;

namespace OOP22_mtsk_game_csharp.LeonardoTassinari.Game
{
    public interface ICollider
    {
        bool IsColliding(GameObject g, GameObject h);

    }
}