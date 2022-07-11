using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _enemyTemplates;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondsBetweenSpawn;

    private float _elapserTime = 0;

    private void Start()
    {
        Initialize(_enemyTemplates);
    }

    private void Update()
    {
        _elapserTime += Time.deltaTime;

        if(_elapserTime >= _secondsBetweenSpawn)
        {
            if(TryGetObject(out GameObject enemy))
            {
                _elapserTime = 0;

                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

                SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);
            }
        }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}
