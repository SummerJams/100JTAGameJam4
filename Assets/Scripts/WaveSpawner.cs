using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
 
public class WaveSpawner : MonoBehaviour
{
    public UnityEvent WaveEnd = new UnityEvent();

    public delegate void WaveInfo(int waveIndex);
    public event WaveInfo WaveStart;
    
    [SerializeField] private List<Enemy> _enemies = new List<Enemy>();
    [SerializeField] private int _waveDuration;
    [SerializeField] private float _spawnInterval = 2;
    [SerializeField] private Transform _enemyParent;
    [SerializeField] private Transform _spawnLocation;
    
    //Переписать
    [SerializeField] private Health _playerHealth;
    [SerializeField] private GameObject _CardSelectionScreenPrefab;
    [SerializeField] private Transform _CardSelectionScreenParent;
    [SerializeField] private GameObject _CardSelectionScreen;
    [SerializeField] private bool _CardSelectionScreenCreate;
    private Card[] _cards;
    
    private int _currWave = 1;
    private int _waveValue;
    private List<GameObject> _enemiesToSpawn = new List<GameObject>();
    private int _livingEnemiesCounter;
    
    
    private float _spawnTimer;
    
    private void Start()
    {
        StartNextWave();
    }
    
    void FixedUpdate()
    {
        Debug.Log("else " + _livingEnemiesCounter);
        
        if(_spawnTimer <=0)
        {
            if(_enemiesToSpawn.Count >0)
            {
                Debug.Log("Spawn enemy " + _enemiesToSpawn[0]);
                GameObject newEnemy = Instantiate(_enemiesToSpawn[0], _spawnLocation.position, Quaternion.identity,_enemyParent);
                newEnemy.GetComponentInChildren<Health>().Death.AddListener(RemoveOneEnemie);
                _enemiesToSpawn.RemoveAt(0);
                _spawnTimer = _spawnInterval;
            }
            else
            {
               
                if (_livingEnemiesCounter <= 0)
                {
                    WaveEnd.Invoke();
                    if (!_CardSelectionScreenCreate)
                    {
                        _CardSelectionScreen = Instantiate(_CardSelectionScreenPrefab, _CardSelectionScreenParent);
                        _CardSelectionScreenCreate = true;
                    }
                    Debug.Log("Instantiate");
                    _cards = _CardSelectionScreen.GetComponentsInChildren<Card>();
                    foreach (var card in _cards)
                    {
                        card.CardSelectionScreenClose.AddListener(StartNextWave);
                    }
                }
                
                
            }
        }
        else
        {
            _spawnTimer -= Time.fixedDeltaTime;
        }
    }
 
    public void StartNextWave()
    {
        _playerHealth.SetMaxHealth();
        _CardSelectionScreenCreate = false;
        _waveValue = Mathf.RoundToInt(3 * (1 + (0.2f * _currWave))) ;
        GenerateEnemies();
        WaveStart.Invoke(_currWave);
    }

    private void RemoveOneEnemie()
    {
        _livingEnemiesCounter -= 1;
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
