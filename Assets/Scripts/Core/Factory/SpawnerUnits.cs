using System.Collections.Generic;
using Core.InputController;
using DG.Tweening;
using UnityEngine;

namespace Core.Factory
{
    public class SpawnerUnits : MonoBehaviour
    {
        private const float DelayFirstSpawn = 1;
        private const float MinSecondsSpawn = 2;
        private const float CoefMinusTime = 0.95f;
        private const float RatioRadToBlue = 4;
        private const float SpawnMinDistanceToPlayer = 2;

        [SerializeField] private Transform _parentSpawnPoints;
        
        private readonly List<TypeUnit> _listSpawnEnemy = new List<TypeUnit>();
        private ICreatorUnits _creatorUnits;
        private float _timeToNextSpawn = 5;
        private Sequence _sequenceSpawn;

        public void Init(ICreatorUnits creatorUnits)
        {
            _creatorUnits = creatorUnits;
            SetSpawnPoints();
            StartScene();
        }
        
        public void StopSpawn()
        {
            _sequenceSpawn.Kill();
        }

        private void StartScene()
        {
            SpawnPlayer();
            
            DOTween.Sequence()
                .AppendInterval(DelayFirstSpawn)
                .AppendCallback(SpawnNextEnemy);
        }

        private void SetSpawnPoints()
        {
            var listSpawnPoints = new List<Transform>();
            
            for (int i = 0; i < _parentSpawnPoints.childCount; i++)
            {
                listSpawnPoints.Add(_parentSpawnPoints.GetChild(i));
            }
            
            ActiveUnitsSingleton.Instance.SetSpawnPoints(listSpawnPoints);
        }

        private void SpawnNextEnemy()
        {
            var typeUnit = NextTypeUnit();

            _sequenceSpawn = DOTween.Sequence()
                .AppendCallback(() => SpawnEnemy(typeUnit))
                .AppendInterval(_timeToNextSpawn)
                .AppendCallback(SpawnNextEnemy);
            
            _timeToNextSpawn *= CoefMinusTime;
            if (_timeToNextSpawn < MinSecondsSpawn) _timeToNextSpawn = MinSecondsSpawn;
        }

        private TypeUnit NextTypeUnit()
        {
            var amountLastRedSpawnUnit = 0;
            
            foreach (var t in _listSpawnEnemy)
            {
                if (t == TypeUnit.Red) amountLastRedSpawnUnit++;
                else amountLastRedSpawnUnit = 0;
            }
            
            var type = amountLastRedSpawnUnit >= RatioRadToBlue ? TypeUnit.Blue : TypeUnit.Red;
            
            _listSpawnEnemy.Add(type);
            if(_listSpawnEnemy.Count > 20)   _listSpawnEnemy.RemoveRange(0, 10);

            return type;
        }

        private void SpawnPlayer()
        {
            var player = _creatorUnits.CreateUnit(TypeUnit.Player);
            player.transform.position = GetPositionPlayer();
        }

        private void SpawnEnemy(TypeUnit type)
        {
            var unit = _creatorUnits.CreateUnit(type);
            unit.transform.position = GetPositionEnemy();
        }

        private Vector3 GetPositionPlayer()
        {
            var pos = Random.Range(0, ActiveUnitsSingleton.Instance.ListSpawnPoints.Count);
            return ActiveUnitsSingleton.Instance.ListSpawnPoints[pos].position;
        }

        private Vector3 GetPositionEnemy()
        {
            var distance = 0f;
            Vector3 position;
            
            do
            {
                var posInList = Random.Range(0, ActiveUnitsSingleton.Instance.ListSpawnPoints.Count);
                position = ActiveUnitsSingleton.Instance.ListSpawnPoints[posInList].position;
                distance = Vector3.Distance(ActiveUnitsSingleton.Instance.Player.Position, position);
            } while (distance < SpawnMinDistanceToPlayer);

            return position;
        }
    }
}