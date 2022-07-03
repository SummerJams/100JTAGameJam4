using System;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class CartModule : MonoBehaviour
{
    protected int Wave;

    [SerializeField] private String _name;
    private float _minRandomFactor = 0.75f;
    private float _maxRandomFactor = 1.5f;

    public String Name => _name;

    private void Awake()
    {
        if (GetSpecifications()[0] == 0)
        {
            GenerateSpecifications();
        }

        ApplyScecifications();
    }

    protected float GetRandomFactor()
    {
        return Random.Range(_minRandomFactor, _maxRandomFactor);
    }

    public abstract void GenerateSpecifications();
    public abstract float[] GetSpecifications();
    public abstract void ApplyScecifications();

    protected float GetWaveFactor()
    {
        return 1 + (0.1f * Wave);
    }
}
