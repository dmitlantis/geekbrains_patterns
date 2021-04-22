using UnityEngine;

namespace Asteroids
{
    public class PlayerController : MonoBehaviour
    {
        private const int DAMAGE_PER_HIT = 1;
        private const int INIT_HP = 1;
        private Code.Player _model;
        private Player _view;
        private void Start()
        {
            _model = new Code.Player(INIT_HP);
            _model.OnDeath += OnDeath;
            _view = FindObjectOfType<Player>();
            _view.OnDamage += OnDamage;
        }

        private void OnDamage()
        {
            _model.ApplyDamage(DAMAGE_PER_HIT);
        }

        private void OnDeath()
        {
            Destroy(_view);
        }
    }
}