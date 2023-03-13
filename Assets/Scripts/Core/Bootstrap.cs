using Core.Factory;
using Core.InputController;
using UnityEngine;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private ManagerInputController _managerInputController;
        [SerializeField] private DataSpawnUnits _dataSpawnUnits;
        [SerializeField] private SpawnerUnits _spawnerUnits;
        
        private GameController _gameController;

        private void Start()
        {
            _spawnerUnits.Init(new CreatorUnits(_dataSpawnUnits));
            _managerInputController.Init(TypeInputController.ButtonKeyboard);
            _gameController = new GameController();
            _gameController.FinishGame += _spawnerUnits.StopSpawn;
        }

        private void OnDestroy()
        {
            if (_gameController != null)
            {
                _gameController.OnDestroy();
            }
        }
    }
}