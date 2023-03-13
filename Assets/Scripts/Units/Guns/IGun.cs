
using System;

namespace Units.Guns
{
    public interface IGun
    {
        void Init(float secondsReload);
        event Action EventReadyShoot;
        float SecondsReload { get; }
        void Shoot();
    }
}