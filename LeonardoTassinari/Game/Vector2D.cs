using System;

namespace OOP22_mtsk_game_csharp.LeonardoTassinari.game

{
    public class Vector2D
    {
        private readonly double _x;
        private readonly double _y;

        public double X
        {
            get => _x;
            set => new Vector2D(value, this.Y);
        }
        public double Y
        {
            get => _y;
            set => new Vector2D(this.X, value);
        }
        public Vector2D(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public Vector2D Sum(Vector2D v2)
        {
            return new Vector2D(this.X + v2.X, this.Y + v2.Y);
        }


        public Vector2D Mul(double alpha)
        {
            return new Vector2D(alpha * this.X, alpha * this.Y);
        }


        public double Module()
        {
            return Math.Sqrt(this.X * this.X + this.Y * this.Y);
        }

        public Vector2D Invert()
        {
            return new Vector2D(-this.X, -this.Y);
        }
        public static Vector2D NullVector()
        {
            return new Vector2D(0, 0);
        }

        public override bool Equals(object obj)
        {
            return obj is Vector2D d &&
                   _x == d._x &&
                   _y == d._y &&
                   X == d.X &&
                   Y == d.Y;
        }

        public override int GetHashCode()
        {
            int hashCode = 367829482;
            hashCode = hashCode * -1521134295 + _x.GetHashCode();
            hashCode = hashCode * -1521134295 + _y.GetHashCode();
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }
        public string StringRepresentation => "(" + this.X + "," + this.Y + ")";
    }
}