using UnityEngine;

namespace Units.Guns
{
    public class Bullet : MonoBehaviour
    {
        private const float SecondsLifeBullet = 5;
        
        protected float Speed;
        
        private float _time = 0;

        public virtual void Init()
        {
            
        }

        protected void TimeLifeBullet()
        {
            _time += Time.deltaTime;
            if (_time > SecondsLifeBullet)
            {
                Destroy(this.gameObject);
            }
        }
    }
}