using System;

namespace Code
{
    public interface IKillable
    {
        event Action OnDeath;
    }
}