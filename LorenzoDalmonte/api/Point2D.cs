using OOP22_mtsk_game_csharp.LeonardoTassinari.game;
using System;

namespace OOP22_mtsk_game_csharp.LorenzoDalmonte.api
{
    public class Point2D
    {
        private readonly double _x;
        private readonly double _y;

        public double X
        {
            get => _x;
            set => new Point2D(value, this.Y);
        }

        public double Y
        {
            get => _y;
            set => new Point2D(this.X, value);
        }

        public Point2D(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public Point2D Sum(Point2D p2)
        {
            return new Point2D(this.X + p2.X, this.Y + p2.Y);
        }

        public Point2D Sum(Vector2D v2)
        {
            return new Point2D(this.X + v2.X, this.Y + v2.Y);
        }

        public Point2D Sub(Point2D p2)
        {
            return this.Sum(p2.Inverse);
        }

        public Point2D Inverse => new Point2D(-this.X, -this.Y);

        public double Distance(Point2D p)
        {
            double tmpX = this.X - p.X;
            double tmpY = this.Y - p.Y;
            return Math.Sqrt(tmpX * tmpX + tmpY * tmpY);
        }

        public override int GetHashCode()
        {
            return this.X.GetHashCode() ^ this.Y.GetHashCode();
        }

        public override bool Equals(object obj) {
            return obj is Point2D p &&
                   _x == p._x &&
                   _y == p._y &&
                   X == p.X &&
                   Y == p.Y;
        }

        public string StringRepresentation => "(" + this.X + ", " + this.Y + ")";

        public static Point2D Origin => new Point2D(0, 0);
    }
}