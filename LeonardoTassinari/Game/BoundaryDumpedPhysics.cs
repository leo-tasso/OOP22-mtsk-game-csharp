using NUnit.Framework.Internal.Execution;
using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;
using System;

namespace OOP22_mtsk_game_csharp.LeonardoTassinari.game
{
    internal class BoundaryDumpedPhysics : SimplePhysics
    {
        public BoundaryDumpedPhysics(int rightBound, int bottomBound, int defuserRadius, double dumpCoefficient)
        {
            RightBound = rightBound;
            BottomBound = bottomBound;
            DefuserRadius = defuserRadius;
            DumpCoefficient = dumpCoefficient;
        }

        public int RightBound { get; }
        public int BottomBound { get; }
        public int DefuserRadius { get; }
        public double DumpCoefficient { get; }
        public override void Update(long dt, GameObject obj, IMinigame miniGame)
        {
            base.Update(dt, obj, miniGame);

            if (obj.Coor.Y > BottomBound - DefuserRadius)
            {
                obj.Coor = new Point2D(obj.Coor.X, BottomBound - DefuserRadius);
                obj.Vel = new Vector2D(obj.Vel.X, -Math.Abs(obj.Vel.Y / DumpCoefficient));
            }
            if (obj.Coor.X > RightBound - DefuserRadius)
            {
                obj.Coor = new Point2D(RightBound - DefuserRadius, obj.Coor.Y);
                obj.Vel = new Vector2D(-Math.Abs(obj.Vel.X / DumpCoefficient), obj.Vel.Y);
            }
            if (obj.Coor.X < 0 + DefuserRadius)
            {
                obj.Coor = new Point2D(DefuserRadius, obj.Coor.Y);
                obj.Vel = new Vector2D(Math.Abs(obj.Vel.X / DumpCoefficient), obj.Vel.Y);
            }
            if (obj.Coor.Y < 0 + DefuserRadius)
            {
                obj.Coor = new Point2D(obj.Coor.X, DefuserRadius);
                obj.Vel = new Vector2D(obj.Vel.X, Math.Abs(obj.Vel.Y / DumpCoefficient));

            }
        }
    }
}