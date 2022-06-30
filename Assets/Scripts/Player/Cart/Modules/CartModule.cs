using System;
using UnityEngine;

public abstract class CartModule : MonoBehaviour
{
    protected int Wave;

    [SerializeField] private String _name;

    public String Name => _name;
    
    private void Awake()
    {
        GenerateSpecifications();
    }

    public abstract void GenerateSpecifications();
    public abstract float[] GetSpecifications();

    protected float GetWaveFactor()
    {
        return 1 + (0.1f * Wave);
    }
}
