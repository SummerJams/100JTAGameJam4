using UnityEngine;

public class TurretsModule : CartModule
{
    [SerializeField] private float _damageFactor;
    [SerializeField] private float _rateOfFireFactor;

    private int _baseDamage = 10;
    private int _baseRateOfFire = 1;
    
    private int _damage;
    public int Damage => _damage;

    private int _rateOfFire;
    public int RateOfFire => _rateOfFire;
    
    public override void GenerateSpecifications()
    {
        _damage = Mathf.RoundToInt(GetRandomFactor() * _damageFactor * _baseDamage * GetWaveFactor());
        
        _rateOfFire = Mathf.RoundToInt( _rateOfFireFactor / GetRandomFactor() * _baseRateOfFire * GetWaveFactor());
    }
    
    public override float[] GetSpecifications()
    {
        return new float[] {Damage, RateOfFire};
    }

    public override void ApplyScecifications()
    {
        GetComponentInChildren<ShootController>().damage = _damage;
        GetComponentInChildren<ShootController>().shootRate = _rateOfFire;
    }
}
