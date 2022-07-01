using UnityEngine;

public class TurretsModule : CartModule
{
    [SerializeField] private float _damageFactor;
    [SerializeField] private float _rateOfFireFactor;

    private int _baseDamage = 10;
    private int _baseRateOfFire = 5;
    
    private int _damage;
    public int Damage => _damage;

    private int _rateOfFire;
    public int RateOfFire => _rateOfFire;
    
    public override void GenerateSpecifications()
    {
        _damage = Mathf.RoundToInt(GetRandomFactor() * _damageFactor * _baseDamage * GetWaveFactor());
        
        _rateOfFire = Mathf.RoundToInt(GetRandomFactor() * _rateOfFireFactor * _baseRateOfFire * GetWaveFactor());
    }
    
    public override float[] GetSpecifications()
    {
        return new float[] {Damage, RateOfFire};
    }
}
