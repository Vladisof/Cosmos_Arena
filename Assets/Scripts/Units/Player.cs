using System;
using Core.Factory;
using DG.Tweening;
using Units.Guns;
using UnityEngine;

namespace Units
{
    public class Player : Unit
    {
        private const float MaxPower = 100;
        private const float SpeedRotation = 100;
        public event Action EventUseUltimate;
        public event Action EventTeleport;

        public float Power 
        {
            get
            {
                return _power;
            }
            set
            {
                _power = value;
                if (_power > MaxPower)
                    _power = MaxPower;
                Debug.Log($"Power {_power}");
            }
        }

        private float _power;
        private IGun _gun;

        public override void Init()
        {
            base.Init();

            TypeUnit = TypeUnit.Player;
            Team = TypeTeam.Player;
            Power = 50;
            MaxHp = 100;
            Health = MaxHp;
            SpeedMove = 1.4f;
            _gun = transform.GetComponentInChildren<IGun>();
            _gun.Init(1);
        }

        public void Teleport(Vector3 position)
        {
            EventTeleport?.Invoke();
            transform.DOMove(position, 2);
        }

        public void RotationHorizontal(float coefSpeed)
        {
            transform.Rotate(0, coefSpeed * SpeedRotation * Time.deltaTime, 0, Space.Self);
        }
        
        public void RotationVertical(float coefSpeed)
        {
            transform.Rotate(coefSpeed * SpeedRotation * Time.deltaTime, 0, 0, Space.Self);
        }

        public void Shoot()
        {
            _gun.Shoot();
        }

        public void UseUltimate()
        {
            if (_power >= MaxPower)
            {
                _power = 0;
                EventUseUltimate?.Invoke();
            }
        }
        
        private void Start()
        {
            Init();
        }
    }
}