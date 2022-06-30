using UnityEngine;

public class Ram : CartModule
{
    [SerializeField] private float _damageFactor;
    [SerializeField] private float _dashCooldownFactor;

    private int _baseDamage = 10;
    private int _baseCooldown = 5;
    
    private int _damage;
    public int Damage => _damage;

    private int _dashCooldown;
    public int DashCooldown => _dashCooldown;
    
    public override void GenerateSpecifications()
    {
        _damage = Mathf.RoundToInt(Random.Range(0.5f, 1.5f) * _damageFactor * _baseDamage * GetWaveFactor());
        
        _dashCooldown = Mathf.RoundToInt(Random.Range(0.5f, 1.5f) * _dashCooldownFactor * _baseCooldown * GetWaveFactor());
    }
    
}
