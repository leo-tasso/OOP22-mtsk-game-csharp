namespace OOP22_mtsk_game_csharp.LorenzoDalmonte.api
{
    public interface IDrawings {

        void DrawCircle(GameObject obj, ColorRGB color, double radius);

        void DrawSquare(GameObject obj, ColorRGB color, double side, bool filled);

        void DrawRectangle(GameObject obj, ColorRGB color, double width, double height, bool filled);

        void DrawTriangle(GameObject obj, ColorRGB color, double side, double rotAngle);

        void DrawMole(GameObject obj, bool beenHit);

        void DrawWamBomb(GameObject obj, bool beenHit);

        void DrawHoleUpperPart(GameObject obj);

        void DrawHoleLowerPart(GameObject obj);

        void DrawLabel(GameObject obj, ColorRGB color, int size, string str);
    }
}