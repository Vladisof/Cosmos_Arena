using Core.Factory;
using DG.Tweening;
using UnityEngine;

namespace Units
{
    public class RedUnit : Enemy
    {
        private const float DamageValue = 15;
        private const float MinDistanceDamagePlayer = 0.1f;

        private bool isMove = false;

        public override void Init(Unit player)
        {
            base.Init(player);

            TypeUnit = TypeUnit.Red;
            Team = TypeTeam.Enemy;
            MaxHp = 50;
            SpeedMove = 1f;
            
            AnimationSpawn();
        }
        
        protected override void Update()
        {
            base.Update();
            
            if(!isMove) return;
            
            LookAtPlayer();
            MoveToPlayer();
        }

        protected override void AnimationSpawn()
        {
            base.AnimationSpawn();
            
            SequenceSpawn.OnComplete(Jump);
        }

        private void Jump()
        {
            transform.DOMoveY(0.5f, 2).OnComplete(() => isMove = true);
        }

        private void MoveToPlayer()
        {
            Move();

            if (Player == null) return; // Add null check here

            var distanceToPlayer = Vector3.Distance(Position, Player.Position);

            if (distanceToPlayer < MinDistanceDamagePlayer)
            {
                DamagePlayer();
            }
        }

        private void DamagePlayer()
        {
            Player.Damage(DamageValue);
            Dead();
        }
    }
}