using UnityEngine;

public class CartBodyModule : CartModule
{
    [SerializeField] private float _healthFactor;
    [SerializeField] private float _speedFactor;

    private int _baseHealth = 200;
    private int _baseSpeed = 5;
    
    private int _health;
    public int Health => _health;

    private int _speed;
    public int Speed => _speed;

    public override void GenerateSpecifications()
    {
        _health = Mathf.RoundToInt(GetRandomFactor() * _healthFactor * _baseHealth * GetWaveFactor());
        
        _speed = Mathf.RoundToInt(GetRandomFactor() * _speedFactor * _baseSpeed * GetWaveFactor());
    }

    public override float[] GetSpecifications()
    {
        return new float[] {Health,  Speed};
    }

    public override void ApplyScecifications()
    {
        GetComponentInParent<Health>().MaxHealth = _health;
        GetComponentInParent<TopDownMovement>().moveSpeed = _speed;
        GetComponentInParent<TopDownMovement>().dashSpeed = _speed * 3;
    }
}
