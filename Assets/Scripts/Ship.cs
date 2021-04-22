using UnityEngine;

namespace Asteroids
{
    internal sealed class Ship : IMove, IRotation
    {
        private readonly IMove _moveImplementation;
        private readonly IRotation _rotationImplementation;
        private readonly IShoot _shootImplementation;

        public float Speed => _moveImplementation.Speed;

        public Ship(IMove moveImplementation, IRotation rotationImplementation, IShoot shootImplementation)
        {
            _moveImplementation = moveImplementation;
            _rotationImplementation = rotationImplementation;
            _shootImplementation = shootImplementation;
        }

        public void Rotation(Vector3 direction)
        {
            _rotationImplementation.Rotation(direction);
        }

        public void Shoot()
        {
            _shootImplementation.Shoot();
        }

        public void AddAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.AddAcceleration();
            }
        }
        
        public void MoveUp()
        {
            _moveImplementation.MoveUp();
        }
        public void MoveDown()
        {
            _moveImplementation.MoveDown();
        }
        public void MoveLeft()
        {
            _moveImplementation.MoveLeft();
        }
        public void MoveRight()
        {
            _moveImplementation.MoveRight();
        }

        public void RemoveAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.RemoveAcceleration();
            }
        }
    }
}
