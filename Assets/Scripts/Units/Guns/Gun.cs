using System;
using DG.Tweening;
using UnityEngine;

namespace Units.Guns
{
    public class Gun : MonoBehaviour, IGun
    {
        public event Action EventReadyShoot;
        public float SecondsReload { get; private set; }

        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _pointSpawnBullet;
        
        private bool _isReadyShoot;
        
        public void Init(float secondsReload)
        {
            SecondsReload = secondsReload;
            _isReadyShoot = true;
        }
        
        public void Shoot()
        {
            if(!_isReadyShoot)  return;
             
            var bullet = Instantiate(_bulletPrefab);
            var bulletComponent = bullet.GetComponent<Bullet>();
            bulletComponent.Init();
            
            bullet.transform.position = _pointSpawnBullet.position;
            bullet.transform.rotation = _pointSpawnBullet.rotation;
            
            Reload();
        }

        private void Reload()
        {
            _isReadyShoot = false;
            DOTween.Sequence()
                .AppendInterval(SecondsReload)
                .AppendCallback(FinishReload);
        }

        private void FinishReload()
        {
            _isReadyShoot = true;
            EventReadyShoot?.Invoke();
        }
    }
}