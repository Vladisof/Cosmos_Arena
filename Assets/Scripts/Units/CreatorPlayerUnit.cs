using Core.InputController;
using Units;
using UnityEngine;

namespace Core.Factory
{
    public class CreatorPlayerUnit : ICreatorTypeUnit
    {
        private readonly GameObject _prefab;

        public CreatorPlayerUnit(GameObject prefab)
        {
            _prefab = prefab;
        }

        public Unit CreateUnit()
        {
            var player = Object.Instantiate(_prefab);
            var playerComponent = player.GetComponent<Player>();
            playerComponent.Init();

            ActiveUnitsSingleton.Instance.SetPlayer(playerComponent);
            
            return playerComponent;
        }
    }
}