﻿using OOP22_mtsk_game_csharp.LorenzoDalmonte.api;
using OOP22_mtsk_game_csharp.PietroOlivi.game;

namespace OOP22_mtsk_game_csharp.LeonardoTassinari.game
{
    internal class Defuser : GameObject
    {
        private static readonly ColorRGB CIRCLE_COLOR = ColorRGB.Black;
        public Defuser(Point2D coor, int dEFUSER_RADIUS, IInputModel defuserInputModel, IPhysicsModel defuserPhysicsModel) : base(coor, Vector2D.NullVector(), 0, defuserInputModel, defuserPhysicsModel,
                new CircleAspect(dEFUSER_RADIUS, CIRCLE_COLOR), new CircleHitBoxModel(dEFUSER_RADIUS))
        {
        }
    }
}