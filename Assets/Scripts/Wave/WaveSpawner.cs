using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private int _waveValueFactor;
    [SerializeField] private float _waveValueWaveCountFactor;
    [SerializeField] private float _spawnInterval = 2;
    [SerializeField] private Transform _enemyParent;
    [SerializeField] private Transform _spawnLocation;
    [SerializeField] private List<Enemy> _enemies = new List<Enemy>();
    

    private int _currentWave;
    private int _waveValue;
    private List<GameObject> _enemiesToSpawn = new List<GameObject>();
    private int _livingEnemiesCounter;
    private float _spawnTimer;
    private bool _waveStart = false;
    private int _cheapestEnemyPrice;

    private void Awake()
    {
        _cheapestEnemyPrice = _enemies[0].cost;
        foreach (var enemy in _enemies)
        {
            if (_cheapestEnemyPrice > enemy.cost)
            {
                _cheapestEnemyPrice = enemy.cost;
            }
        }
    }

    private void Start()
    {
        StartNextWave();
    }
    
    void FixedUpdate()
    {
        Debug.Log("else " + _livingEnemiesCounter);
        if (_waveStart)
        {
            if(_spawnTimer <=0)
            {
                if(_enemiesToSpawn.Count > 0)
                {
                    Debug.Log("Spawn enemy " + _enemiesToSpawn[0]);
                    GameObject newEnemy = Instantiate(_enemiesToSpawn[0], _spawnLocation.position, Quaternion.identity,_enemyParent);
                    newEnemy.GetComponentInChildren<Health>().Death.AddListener(RemoveOneEnemie);
                    _enemiesToSpawn.RemoveAt(0);
                    _spawnTimer = _spawnInterval;
                }
                else
                {
                    if (_livingEnemiesCounter <= 0 )
                    {
                        _waveStart = false;
                        GlobalEventManager.OnWaveEnd.Invoke(_currentWave);
                        StartNextWave();
                    }
                }
            }
            else
            {
                _spawnTimer -= Time.fixedDeltaTime;
            }
        }
        
    }
    
    public void StartNextWave()
    {
        if (_waveStart == false)
        {
            _waveStart = true;
            _currentWave += 1;
            Debug.Log("StartWave " + _currentWave);
        
            GlobalEventManager.OnWaveStart.Invoke(_currentWave);
           
            _waveValue = Mathf.RoundToInt(_waveValueFactor * (1 + (_waveValueWaveCountFactor * _currentWave)));
            GenerateEnemies();
        }
       
        
    }

    private void RemoveOneEnemie()
    {
        _livingEnemiesCounter -= 1;
    }
    
    public void GenerateEnemies()
    {
        List<GameObject> generatedEnemies = new List<GameObject>();
        
        
        while(_waveValue > _cheapestEnemyPrice)
        {
            int randEnemyId = Random.Range(0, _enemies.Count);
            int randEnemyCost = _enemies[randEnemyId].cost;
 
            if(_waveValue-randEnemyCost>=0)
            {
                generatedEnemies.Add(_enemies[randEnemyId].enemyPrefab);
                _waveValue -= randEnemyCost;
            }
            else if(_waveValue<=0)
            {
                break;
            }
        }
        _enemiesToSpawn.Clear();
        _livingEnemiesCounter = generatedEnemies.Count;
        _enemiesToSpawn = generatedEnemies;
    }
  
}

[System.Serializable]
public class Enemy
{
    public GameObject enemyPrefab;
    public int cost;
}
