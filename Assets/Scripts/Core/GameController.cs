using System;
using Core.InputController;
using Units;
using UnityEngine.SceneManagement;

namespace Core
{
    public class GameController
    {
        public event Action FinishGame;
        
        private Player Player => ActiveUnitsSingleton.Instance.Player;

        public GameController()
        {
            Player.EventDead += DeadPlayer;
            Player.EventUseUltimate += UseUltimate;
        }
        
        private void DeadPlayer(Unit unit)
        {
            FinishGame?.Invoke();
            SceneManager.LoadScene("Menu");
        }

        private void UseUltimate()
        {
            var array = ActiveUnitsSingleton.Instance.ListEnemy.ToArray();
            
            for (int i = 0; i < array.Length; i++)
            {
                array[i].Dead();
            }
        }

        public void OnDestroy()
        {
            Player.EventDead -= DeadPlayer;
            Player.EventUseUltimate -= UseUltimate;
        }
    }
}