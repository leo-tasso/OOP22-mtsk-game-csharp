using System;

namespace OOP22_mtsk_game_csharp.LeonardoTassinari.Game

{
    public class Vector2D
    {
        public double X { get; }

        public double Y { get; }

        public Vector2D(double x, double y)
        {
            X = x;
            Y = y;
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
                   X == d.X &&
                   Y == d.Y;
        }

        public override int GetHashCode()
        {
            int hashCode = 367829482;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }
        public string StringRepresentation => "(" + this.X + "," + this.Y + ")";
    }
}
