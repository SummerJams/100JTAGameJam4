using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
 
public class WaveSpawner : MonoBehaviour
{
    public UnityEvent WaveEnd = new UnityEvent();
    
    [SerializeField] private List<Enemy> _enemies = new List<Enemy>();
    [SerializeField] private int _waveDuration;
    [SerializeField] private float _spawnInterval = 2;
    [SerializeField] private Transform _enemyParent;
    [SerializeField] private Transform _spawnLocation;
    
    private int _currWave = 1;
    private int _waveValue;
    private List<GameObject> _enemiesToSpawn = new List<GameObject>();
    
    
    private float _spawnTimer;
    
    private void Start()
    {
        StartNextWave();
    }
    
    void FixedUpdate()
    {
        if(_spawnTimer <=0)
        {
            if(_enemiesToSpawn.Count >0)
            {
                Debug.Log("Spawn enemy " + _enemiesToSpawn[0]);
                Instantiate(_enemiesToSpawn[0], _spawnLocation.position, Quaternion.identity,_enemyParent); 
                _enemiesToSpawn.RemoveAt(0);
                _spawnTimer = _spawnInterval;
            }
            else
            {
                WaveEnd.Invoke();
            }
        }
        else
        {
            _spawnTimer -= Time.fixedDeltaTime;
        }
    }
 
    public void StartNextWave()
    {
        _waveValue = _currWave * 10;
        GenerateEnemies();
    }
 
    public void GenerateEnemies()
    {
        List<GameObject> generatedEnemies = new List<GameObject>();
        while(_waveValue>0)
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
        _enemiesToSpawn = generatedEnemies;
    }
  
}

[System.Serializable]
public class Enemy
{
    public GameObject enemyPrefab;
    public int cost;
}
