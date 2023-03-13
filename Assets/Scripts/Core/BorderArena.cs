using Core.InputController;
using Units;
using UnityEngine;

namespace Core
{
    public class BorderArena : MonoBehaviour
    {
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                var player = other.GetComponent<Player>();
                Teleport(player);
            }
        }

        private void Teleport(Player player)
        {
            var position = FindPosition();
            player.Teleport(position);
        }

        private Vector3 FindPosition()
        {
            if (ActiveUnitsSingleton.Instance.ListEnemy.Count == 0)
            {
                var pos = ActiveUnitsSingleton.Instance.ListSpawnPoints.Count;
                return ActiveUnitsSingleton.Instance.ListSpawnPoints[pos].position;
            }

            var maxDistance = 0f;
            var position = Vector3.zero;
            
            foreach (var point in ActiveUnitsSingleton.Instance.ListSpawnPoints)
            {
                var dist = MinDistance(point);
                if (dist > maxDistance)
                {
                    maxDistance = dist;
                    position = point.position;
                }
            }

            return position;
        }

        private float MinDistance(Transform point)
        {
            var maxDistance = 0f;
            
            foreach (var enemy in ActiveUnitsSingleton.Instance.ListEnemy)
            {
                var distance = Vector3.Distance(point.position, enemy.Position);
                if (distance > maxDistance) maxDistance = distance;
            }

            return maxDistance;
        }
    }
}