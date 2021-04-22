using System;

namespace Asteroids
{
    public interface IDamageble
    {
        event Action OnDamage;
    }
}