using UnityEngine;

public class RamModule : CartModule
{
    [SerializeField] private float _damageFactor;
    [SerializeField] private float _dashCooldownFactor;

    private int _baseDamage = 10;
    private int _baseCooldown = 5;
    
    private int _damage;
    public int Damage => _damage;
    
    private float _dashCooldown;
    public float DashCooldown => _dashCooldown;
    
    
    public override void GenerateSpecifications()
    {
        _damage = Mathf.RoundToInt(GetRandomFactor() * _damageFactor * _baseDamage * GetWaveFactor());
        _dashCooldown = Mathf.RoundToInt(GetRandomFactor() * _dashCooldownFactor * _baseCooldown * GetWaveFactor());
    }
    
    public override float[] GetSpecifications()
    {
        return new float[] {Damage, DashCooldown};
    }

    public override void ApplyScecifications()
    {
        throw new System.NotImplementedException();
    }
}
