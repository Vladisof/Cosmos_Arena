using Core.InputController;
using UnityEngine;

namespace Units.Guns
{
    public class BlueBullet : Bullet
    {
        private const float Damage = 25;
        
        private Vector3 _positionTeleport;
        private Player _player;
        private IBehaviorMoveBullet _behaviorMoveBullet;
        
        public override void Init()
        {
            _player = ActiveUnitsSingleton.Instance.Player;
            Speed = 5;
            _behaviorMoveBullet = new BehaviorFollowPlayerMoveBullet(transform, Speed, _player);
        }
        
        private void Update()
        {
            _behaviorMoveBullet.Move();
            TimeLifeBullet();
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.transform.tag == "Player")
            {
                var unit = collision.transform.GetComponent<Unit>();
                unit.Damage(Damage);
                Destroy(this.gameObject);
            }
        }
        
        private void OnDestroy()
        {
            _behaviorMoveBullet.OnDestroy();
        }
    }
}