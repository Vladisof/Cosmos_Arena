using Core.InputController;
using Units;
using UnityEngine;

namespace Core.Factory
{
    public class ReactDeadEnemySingleton
    {
        public static ReactDeadEnemySingleton Instance => _activeUnitsSingleton ??= new ReactDeadEnemySingleton();
        public int SumDeadEnemy => DeadBlue + DeadRed;
        
        private static ReactDeadEnemySingleton _activeUnitsSingleton;
        private static Player Player => ActiveUnitsSingleton.Instance.Player;
        
        private int DeadBlue { get; set; }
        private int DeadRed { get; set; }
        
        public void DeadEnemy(TypeBulletKill typeBullet, TypeUnit typeUnit)
        {
            switch (typeUnit)
            {
                case TypeUnit.Blue:
                    Player.Power += 50;
                    DeadBlue++;
                    break;
                case TypeUnit.Red:
                    Player.Power += 15;
                    DeadRed++;
                    break;
            }

            if (typeBullet == TypeBulletKill.Ricochet)
            {
                KillRicochet();
            }
        }

        public void Reset()
        {
            DeadBlue = 0;
            DeadRed = 0;
        }
        
        private void KillRicochet()
        {
            var res = Random.Range(0, 2);
            
            if (res == 0)
            {
                Player.Power += Random.Range(1, 10);
            }
            else
            {
                Player.Health += Player.MaxHp / 2.0f;
            }
        }
    }

    public enum TypeBulletKill
    {
        None = 0,
        Ricochet = 1,
        Direct = 2,
    }
}