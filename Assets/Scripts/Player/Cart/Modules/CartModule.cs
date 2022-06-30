using UnityEngine;

public abstract class CartModule : MonoBehaviour
{
    protected int wave;

    private void Awake()
    {
        GenerateSpecifications();
    }

    public abstract void GenerateSpecifications();

    protected float GetWaveFactor()
    {
        return 1 + (0.1f * wave);
    }
}
