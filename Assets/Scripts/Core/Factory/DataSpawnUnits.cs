using UnityEngine;

namespace Core.Factory
{
    [CreateAssetMenu(fileName = "DataSpawnUnit", menuName = "ScriptableObjects/DataSpawnUnits", order = 1)]
    public class DataSpawnUnits : ScriptableObject
    {
        public GameObject Player;
        public GameObject Blue;
        public GameObject Red;
    }
}