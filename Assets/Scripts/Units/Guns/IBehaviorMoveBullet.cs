using Core.Factory;

namespace Units.Guns
{
    public interface IBehaviorMoveBullet
    {
        TypeBulletKill TypeBullet { get; }
        void Move();
        void OnDestroy();
    }
}