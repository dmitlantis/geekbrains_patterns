using UnityEngine;

namespace Asteroids
{
    public class ShootShip: IShoot
    {
        private Rigidbody2D _bullet;
        private Transform _barrel;
        private float _force;
        public ShootShip(Rigidbody2D bullet, Transform barrel, float force)
        {
            _bullet = bullet;
            _barrel = barrel;
            _force = force;
        }
        
        public void Shoot()
        {
            var temAmmunition = Object.Instantiate(_bullet, _barrel.position, _barrel.rotation);
            temAmmunition.AddForce(_barrel.up * _force);
        }
    }
}