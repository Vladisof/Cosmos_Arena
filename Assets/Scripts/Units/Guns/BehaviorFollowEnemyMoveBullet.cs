using UnityEngine;

namespace Units.Guns
{
    public class BehaviorFollowEnemyMoveBullet : BehaviorFollowMoveBullet
    {
        private readonly Unit _target;

        public BehaviorFollowEnemyMoveBullet(Transform transform, float speed, Unit target) : base(transform, speed, target)
        {
            _target = target;
            target.EventDead += PlayerTeleport;
        }
        
        public override void OnDestroy()
        {
            base.OnDestroy();
            _target.EventDead -= PlayerTeleport;
        }

        private void PlayerTeleport(Unit unit)
        {
            SetLastPosition();
        }
    }
}