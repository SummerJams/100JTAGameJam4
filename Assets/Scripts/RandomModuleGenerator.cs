using UnityEngine;
using Random = UnityEngine.Random;

public class RandomModuleGenerator
{
    private string _path = "Modules";
    
    private GameObject[] _cartMoudlePrefabs;

    public RandomModuleGenerator()
    {
        _cartMoudlePrefabs = Resources.LoadAll<GameObject>(_path);
    }

    public GameObject NewCartMoudle()
    {
        GameObject newCartMoudle = _cartMoudlePrefabs[Random.Range(0, _cartMoudlePrefabs.Length)];
        newCartMoudle.GetComponentInChildren<CartModule>().GenerateSpecifications();
        return newCartMoudle;
    }
}
