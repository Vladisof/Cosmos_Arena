using UnityEngine;

namespace Units.Guns
{
    public class BehaviorFollowPlayerMoveBullet : BehaviorFollowMoveBullet
    {
        private readonly Player _target;

        public BehaviorFollowPlayerMoveBullet(Transform transform, float speed, Player target) : base(transform, speed, target)
        {
            _target = target;
            target.EventTeleport += PlayerTeleport;
        }
        
        public override void OnDestroy()
        {
            base.OnDestroy();
            
            _target.EventTeleport -= PlayerTeleport;
        }

        private void PlayerTeleport()
        {
            SetLastPosition();
        }
    }
}