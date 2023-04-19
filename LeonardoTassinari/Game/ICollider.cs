using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;

namespace OOP22_mtsk_game_csharp.LeonardoTassinari.game
{
    public interface ICollider
    {
        bool IsColliding(GameObject g, GameObject h);

    }
}