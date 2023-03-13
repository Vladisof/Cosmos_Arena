using Core.Factory;
using UnityEngine;

namespace Units.Guns
{
    public class BehaviorForwardMoveBullet : IBehaviorMoveBullet
    {
        private readonly Transform _bullet;
        private readonly float _speed;

        public BehaviorForwardMoveBullet(Transform bullet, float speed)
        {
            _bullet = bullet;
            _speed = speed;
        }

        public TypeBulletKill TypeBullet => TypeBulletKill.Direct;

        public void Move()
        {
            _bullet.position += _speed * _bullet.forward * Time.deltaTime;
        }

        public void OnDestroy()
        {
            
        }
    }
}