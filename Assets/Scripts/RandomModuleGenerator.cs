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
        
        Debug.Log("Massive lenght" + _cartMoudlePrefabs.Length);
        int Rint = Random.Range(0, _cartMoudlePrefabs.Length - 1);
        Debug.Log("Index " + Rint);
        return _cartMoudlePrefabs[Rint];
    }
}
