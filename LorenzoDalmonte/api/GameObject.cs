using Vecor2D;
using OOP22_mtsk_game_csharp.PietroOlivi.game;

namespace OOP22_mtsk_game_csharp.LorenzoDalmonte.api
{
    public class GameObject
    {
        public Point2D Coor { get; set;}
        public Vector2D Vel { get; set;}
        public int Rotation { get; set;}
        public IInputModel Input { get; set;}
        public IPhysicsModel Physics { get; set;}
        public IAspectModel Aspect { get; set;}
        public IHitBoxModel HitBox { get; set;}

        public GameObject(Point2D coor,
                Vector2D vel,
                int rotation,
                IInputModel inputModel,
                IPhysicsModel physicsModel,
                IAspectModel aspectModel,
                IHitBoxModel hitBoxModel)
        {
            Coor = coor;
            Vel = vel;
            Rotation = rotation;
            Input = inputModel;
            Physics = physicsModel;
            Aspect = aspectModel;
            HitBox = hitBoxModel;
        }

        public GameObject(Point2D coor,
                Vector2D vel,
                int rotation,
                IInputModel inputModel,
                IPhysicsModel physicsModel,
                IAspectModel aspectModel): this(coor,
                    vel,
                    rotation,
                    inputModel,
                    physicsModel,
                    aspectModel,
                    new NullHitBoxModel());

        public void Updateinput(IInput input, long elapsedTime) {
            Input.Update(this, input, elapsedTime);
        }

        public void UpdatePhysics(long deltaTime, IMinigame m) {
            Physics.Update(deltaTime, this, m);
        }

        public void UpdateAspect(IDrawings drawing) {
            Aspect.Update(this, drawing);
        }
    }
}