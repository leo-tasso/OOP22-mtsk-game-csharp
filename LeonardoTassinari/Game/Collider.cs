using System.Drawing;
using System;
using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;

namespace OOP22_mtsk_game_csharp.LeonardoTassinari.game
{
    internal class Collider : ICollider
    {
        public bool IsColliding(GameObject g, GameObject h)
        {
            if (g.HitBox is CircleHitBoxModel && h.HitBox is RectangleHitBoxModel) {
                return CircleRectangleCompare(g, h);
            }
            if (h.HitBox is CircleHitBoxModel && g.HitBox is RectangleHitBoxModel) {
                return CircleRectangleCompare(h, g);
            }
            if (h.HitBox is RectangleHitBoxModel && g.HitBox is RectangleHitBoxModel) {
                return rectangleRectangleCompare(h, g);
            }
            return false;
        }

        private bool rectangleRectangleCompare(GameObject h, GameObject g)
        {
            return h.Coor.X - h.HitBox.GetSizes()[0] / 2 < g.Coor.X
                    + g.HitBox.GetSizes()[0] / 2
                    && h.Coor.X + h.HitBox.GetSizes()[0] / 2 > g.Coor.X
                            - g.HitBox.GetSizes()[0] / 2
                    &&
                    h.Coor.Y - h.HitBox.GetSizes()[1] / 2 < g.Coor.Y
                            + g.HitBox.GetSizes()[1] / 2
                    &&
                    h.Coor.Y + h.HitBox.GetSizes()[1] / 2 > g.Coor.Y
                            - g.HitBox.GetSizes()[1] / 2;
        }
        private bool CircleRectangleCompare(GameObject circle, GameObject rectangle)
        {
            double circleDistancex = Math.Abs(circle.Coor.X - rectangle.Coor.X);
            double rectWidth = rectangle.HitBox.GetSizes()[0];
            double circleRad = rectangle.HitBox.GetSizes()[0];
            if (circleDistancex > (rectWidth / 2 + circleRad))
            {
                return false;
            }
            double circleDistancey = Math.Abs(circle.Coor.Y - rectangle.Coor.Y);
            double rectHeight = rectangle.HitBox.GetSizes()[1];
            if (circleDistancey > (rectHeight / 2 + circleRad))
            {
                return false;
            }

            if (circleDistancex <= (rectWidth / 2))
            {
                return true;
            }
            if (circleDistancey <= (rectHeight / 2))
            {
                return true;
            }

            double cornerDistanceSq = Math.Pow(circleDistancex - rectWidth / 2, 2)
                    + Math.Pow(circleDistancey - rectHeight / 2, 2);

            return cornerDistanceSq <= Math.Pow(circleRad, 2);
        }

    }
}