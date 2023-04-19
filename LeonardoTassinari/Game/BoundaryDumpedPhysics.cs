using NUnit.Framework.Internal.Execution;
using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;
using System;

namespace OOP22_mtsk_game_csharp.LeonardoTassinari.game
{
    internal class BoundaryDumpedPhysics : SimplePhysics
    {
        public BoundaryDumpedPhysics(int rightBound, int bottomBound, int dEFUSER_RADIUS, double dUMP_COEFFICIENT)
        {
            RightBound = rightBound;
            BottomBound = bottomBound;
            DEFUSER_RADIUS = dEFUSER_RADIUS;
            DUMP_COEFFICIENT = dUMP_COEFFICIENT;
        }

        public int RightBound { get; }
        public int BottomBound { get; }
        public int DEFUSER_RADIUS { get; }
        public double DUMP_COEFFICIENT { get; }
        public override void Update(long dt, GameObject obj, IMinigame miniGame)
        {
            base.Update(dt, obj, miniGame);

            if (obj.Coor.Y > BottomBound - DEFUSER_RADIUS)
            {
                obj.Coor = new Point2D(obj.Coor.X, BottomBound - DEFUSER_RADIUS);
                obj.Vel = new Vector2D(obj.Vel.X, -Math.Abs(obj.Vel.Y / DUMP_COEFFICIENT));
            }
            if (obj.Coor.X > RightBound - DEFUSER_RADIUS)
            {
                obj.Coor = new Point2D(RightBound - DEFUSER_RADIUS, obj.Coor.Y);
                obj.Vel = new Vector2D(-Math.Abs(obj.Vel.X / DUMP_COEFFICIENT), obj.Vel.Y);
            }
            if (obj.Coor.X < 0 + DEFUSER_RADIUS)
            {
                obj.Coor = new Point2D(DEFUSER_RADIUS, obj.Coor.Y);
                obj.Vel = new Vector2D(Math.Abs(obj.Vel.X / DUMP_COEFFICIENT), obj.Vel.Y);
            }
            if (obj.Coor.Y < 0 + DEFUSER_RADIUS)
            {
                obj.Coor = new Point2D(obj.Coor.X, DEFUSER_RADIUS);
                obj.Vel = new Vector2D(obj.Vel.X, Math.Abs(obj.Vel.Y / DUMP_COEFFICIENT));

            }
        }
    }
}