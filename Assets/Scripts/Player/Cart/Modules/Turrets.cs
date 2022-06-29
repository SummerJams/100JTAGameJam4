using UnityEngine;

public class Turrets : CartMoudle
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
        _damage = Mathf.RoundToInt(Random.Range(0.5f, 1.5f) * _damageFactor * _baseDamage * GetWaveFactor());
        
        _rateOfFire = Mathf.RoundToInt(Random.Range(0.5f, 1.5f) * _rateOfFireFactor * _baseRateOfFire * GetWaveFactor());
    }
}
