using System.Collections.Generic;
using Units;
using UnityEngine;

namespace Core.InputController
{
    public class ActiveUnitsSingleton
    {
        public static ActiveUnitsSingleton Instance => _activeUnitsSingleton ??= new ActiveUnitsSingleton();
        
        public Player Player { get; private set; }
        public List<Unit> ListEnemy { get; private set; } = new List<Unit>();
        public List<Transform> ListSpawnPoints { get; private set; } = new List<Transform>();

        private static ActiveUnitsSingleton _activeUnitsSingleton;
        
        private ActiveUnitsSingleton()
        {
        }

        public void SetPlayer(Player player)
        {
            Player = player;
        }

        public void AddEnemy(Enemy enemy)
        {
            enemy.EventDead += RemoveEnemy;
            ListEnemy.Add(enemy);
        }

        private void RemoveEnemy(Unit enemy)
        {
            enemy.EventDead -= RemoveEnemy;
            ListEnemy.Remove(enemy);
        }

        public void Reset()
        {
            Player = null;
            ListEnemy = new List<Unit>();
        }

        public void SetSpawnPoints(List<Transform> listSpawnPoints)
        {
            ListSpawnPoints = listSpawnPoints;
        }
    }
}