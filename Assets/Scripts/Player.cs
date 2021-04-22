using System;
using UnityEngine;

namespace Asteroids
{
    internal sealed class Player : MonoBehaviour, IDamageble
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _force;
        private Camera _camera;
        private Ship _ship;
        public event Action OnDamage;

        private void Start()
        {
            _camera = Camera.main;
            var moveTransform = new AccelerationMove(transform, _speed, _acceleration, GetComponent<Rigidbody2D>());
            var rotation = new RotationShip(transform);
            ShootShip shoot = new ShootShip(_bullet, _barrel, _force);
            _ship = new Ship(moveTransform, rotation, shoot);
        }

        private void Update()
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
            _ship.Rotation(direction);


            if (Input.GetKey(KeyCode.W))
            {
                _ship.MoveUp();
            }
            
            if (Input.GetKey(KeyCode.S))
            {
                _ship.MoveDown();
            }
            
            if (Input.GetKey(KeyCode.A))
            {
                _ship.MoveLeft();
            }
            
            if (Input.GetKey(KeyCode.D))
            {
                _ship.MoveRight();
            }
            
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _ship.AddAcceleration();
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _ship.RemoveAcceleration();
            }

            if (Input.GetButtonDown("Fire1"))
            {
                _ship.Shoot();
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            OnDamage?.Invoke();
        }
    }
}
