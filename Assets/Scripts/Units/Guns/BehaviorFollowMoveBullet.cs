using Core.Factory;
using UnityEngine;

namespace Units.Guns
{
    public abstract class BehaviorFollowMoveBullet : IBehaviorMoveBullet
    {
        public TypeBulletKill TypeBullet => TypeBulletKill.Ricochet;
        
        private readonly Transform _transform;
        private readonly float _speed;
        private readonly Unit _target;
        private bool _moveToLastPosition;
        private Vector3 _lastPosition;

        protected BehaviorFollowMoveBullet(Transform transform, float speed, Unit target)
        {
            _transform = transform;
            _speed = speed;
            _target = target;
        }

        public void Move()
        {
            _transform.position += _speed * _transform.forward * Time.deltaTime;
            LookAtPosition();
            DestroyToTeleportPosition();
        }
        
        private void LookAtPosition()
        {
            var position = !_moveToLastPosition ? _target.Position : _lastPosition;
            _transform.LookAt(position);
        }

        protected void SetLastPosition()
        {
            if(_moveToLastPosition) return;
            
            _moveToLastPosition = true;
            _lastPosition = _target.Position;
        }

        public virtual void OnDestroy()
        {
            
        }

        private void DestroyToTeleportPosition()
        {
            if (!_moveToLastPosition) return;
            
            var distance = Vector3.Distance(_transform.position, _lastPosition);
            if (distance < 0.1f)
            {
                Object.Destroy(_transform.gameObject);
            }
        }
    }
}