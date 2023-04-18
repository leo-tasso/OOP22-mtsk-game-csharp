namespace OOP22_mtsk_game_csharp.LorenzoDalmonte.api
{
    public class ColorRGB {
        public static readonly int COLOR_RANGE_TOP = 255;
        public static readonly int COLOR_RANGE_BOTTOM = 0;
        private readonly int _red;
        private readonly int _green;
        private readonly int _blue;
        public int RedAmount
        {
            get => _red % (COLOR_RANGE_TOP + 1);
        }
        public int GreenAmount
        {
            get => _green % (COLOR_RANGE_TOP + 1);
        }
        public int BlueAmount
        {
            get => _blue % (COLOR_RANGE_TOP + 1);
        }

        public ColorRGB(int red, int green, int blue) {
            _red = red;
            _green = green;
            _blue = blue;
        }

        public static ColorRGB Red
        {
            get => new ColorRGB(COLOR_RANGE_TOP, COLOR_RANGE_BOTTOM, COLOR_RANGE_BOTTOM);
        }

        public static ColorRGB Green
        {
            get => new ColorRGB(COLOR_RANGE_BOTTOM, COLOR_RANGE_TOP, COLOR_RANGE_BOTTOM);
        }

        public static ColorRGB Blue
        {
            get => new ColorRGB(COLOR_RANGE_BOTTOM, COLOR_RANGE_BOTTOM, COLOR_RANGE_TOP);
        }

        public static ColorRGB White
        {
            get => new ColorRGB(COLOR_RANGE_TOP, COLOR_RANGE_TOP, COLOR_RANGE_TOP);
        }

        public static ColorRGB Black
        {
            get => new ColorRGB(COLOR_RANGE_BOTTOM, COLOR_RANGE_BOTTOM, COLOR_RANGE_BOTTOM);
        }

        public static ColorRGB Orange
        {
            get => new ColorRGB(COLOR_RANGE_TOP, COLOR_RANGE_TOP / 2, COLOR_RANGE_BOTTOM);
        }

        public static ColorRGB Aqua
        {
            get => new ColorRGB(COLOR_RANGE_BOTTOM, COLOR_RANGE_TOP / 2, COLOR_RANGE_TOP / 2);
        }
    }
}