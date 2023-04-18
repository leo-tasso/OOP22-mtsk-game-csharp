using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;
using System.Drawing;

namespace OOP22_mtsk_game_csharp.LeonardoTassinari.game
{
    internal class RectangleAspect : IAspectModel
    {
        private int Width { get; set; }
        private int Height { get; set; }
        private ColorRGB Color { get; set; }
        private readonly bool Filled;
        public RectangleAspect(int width, int height, ColorRGB color, bool filled)
        {
            this.Width = width;
            this.Height = height;
            this.Color = color;
            this.Filled = filled;
        }

        public void Update(GameObject obj, IDrawings d)
        {
            d.DrawRectangle(obj, Color, Width, Height, Filled);
        }
    }
}