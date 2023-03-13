using Core.InputController;
using Units;
using UnityEngine;

namespace Core.Factory
{
    public class CreatorBlueUnit : ICreatorTypeUnit
    {
        private readonly GameObject _prefab;

        public CreatorBlueUnit(GameObject prefab)
        {
            _prefab = prefab;
        }

        public Unit CreateUnit()
        {
            var player = Object.Instantiate(_prefab);
            var component = player.GetComponent<BlueUnit>();
            component.Init(ActiveUnitsSingleton.Instance.Player);
            
            ActiveUnitsSingleton.Instance.AddEnemy(component);

            return component;
        }
    }
}
