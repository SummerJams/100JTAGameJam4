using UnityEngine;

public class CartBody : CartMoudle
{
    [SerializeField] private float _healthFactor;
    [SerializeField] private float _speedFactor;

    private int _baseHealth = 10;
    private int _baseSpeed = 5;
    
    private int _health;
    public int Health => _health;

    private int _speed;
    public int Speed => _speed;
    
    public override void GenerateSpecifications()
    {
        _health = Mathf.RoundToInt(Random.Range(0.5f, 1.5f) * _healthFactor * _baseHealth * GetWaveFactor());
        
        _speed = Mathf.RoundToInt(Random.Range(0.5f, 1.5f) * _speedFactor * _baseSpeed * GetWaveFactor());
    }
}
