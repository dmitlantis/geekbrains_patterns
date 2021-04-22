using UnityEngine;

namespace Asteroids
{
    internal class MoveTransform : IMove
    {
        private readonly Transform _transform;
        private readonly Rigidbody2D _rigidBody;

        public float Speed { get; protected set; }
        
        public MoveTransform(Transform transform, float speed, Rigidbody2D rigidBody)
        {
            _transform = transform;
            Speed = speed;
            _rigidBody = rigidBody;
        }
        
        public void MoveUp()
        {
            Move(_transform.up);
        }
        public void MoveDown()
        {
            Move(-_transform.up);
        }
        public void MoveLeft()
        {
            Move(-_transform.right);
        }
        public void MoveRight()
        {
            Move(_transform.right);
        }

        public void Move(Vector2 way)
        {
           _rigidBody.AddForce(way * Speed, ForceMode2D.Impulse);
        }
    }
}
