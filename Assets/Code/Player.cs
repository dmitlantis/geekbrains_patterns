using System;

namespace Code
{
    internal sealed class Player: IApplyDamage, IKillable
    {
        public event Action OnDeath;
        private int _hp;

        public Player(int hp)
        {
            _hp = hp;
        }
        
        public void ApplyDamage(int points)
        {
            if (_hp <= 0)
            {
                OnDeath?.Invoke();
            }
            else
            {
                _hp--;
            }
        }
    }
}