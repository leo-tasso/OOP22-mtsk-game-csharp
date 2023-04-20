using OOP22_mtsk_game_csharp.LorenzoDalmonte.Api;

namespace OOP22_mtsk_game_csharp.LeonardoTassinari.Game
{
    internal class RectangleAspect : IAspectModel
    {
        private int Width { get; set; }
        private int Height { get; set; }
        private ColorRGB Color { get; set; }
        private readonly bool _filled;
        public RectangleAspect(int width, int height, ColorRGB color, bool filled)
        {
            this.Width = width;
            this.Height = height;
            this.Color = color;
            this._filled = filled;
        }

        public void Update(GameObject obj, IDrawings d)
        {
            d.DrawRectangle(obj, Color, Width, Height, _filled);
        }
    }
}