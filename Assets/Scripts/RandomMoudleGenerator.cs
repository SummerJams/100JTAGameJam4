using System;
using UnityEngine;

public class RandomMoudleGenerator : MonoBehaviour
{
    private string _path = "Resources/Modules";
    
    private GameObject[] _cartMoudlePrefabs; 

    private void Awake()
    {
        _cartMoudlePrefabs = Resources.LoadAll<GameObject>(_path);
    }

    private void Update()
    {
        Debug.Log(_cartMoudlePrefabs.Length);
    }

    // public CartModule NewCartMoudle()
    // {
    //     
    //     return x v 
    // }
}
