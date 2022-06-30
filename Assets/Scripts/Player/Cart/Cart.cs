using System;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Cart : MonoBehaviour
{
    [SerializeField] private Transform _ramSlot;
    [SerializeField] private Transform _cartBodySlot;
    [SerializeField] private Transform _turretsSlot;
    
    public void SwitchModule(GameObject newMoudle)
    {
        Transform slot;
            
        switch(newMoudle.GetComponentInChildren<CartModule>())
        {
            case Ram _:
            {
                slot = _ramSlot; 
                break;
            }
            case CartBody _:
            {
                slot = _cartBodySlot;
                break;
            }
            case Turrets _:
            {
                slot = _turretsSlot;
                break;
            }
            default:
            {
                Debug.LogException(new Exception("Invalid module"));
                return;
            }
        }
        
        Destroy(slot.GetComponentInChildren<CartModule>().gameObject);
        Instantiate(newMoudle, slot);
    }
    
    
    
    // private GameObject _ramMoudle;
    //
    // public GameObject RamMoudle
    // {
    //     get
    //     {
    //         return _ramMoudle;
    //     }
    //     set
    //     {
    //         if (value.TryGetComponent(out Ram ram))
    //         {
    //             _ramMoudle = value.gameObject;
    //         }
    //     }
    // }
    //
    // private GameObject _cartBodyMoudle;
    //
    // public GameObject CartBodyMoudle
    // {
    //     get
    //     {
    //         return _cartBodyMoudle;
    //     }
    //     set
    //     {
    //         if (value.TryGetComponent(out CartBody cartBody))
    //         {
    //             _cartBodyMoudle = value.gameObject;
    //         }
    //     }
    // }
    //
    // private GameObject _turretsModule;
    //
    // public GameObject TurretsModule
    // {
    //     get
    //     {
    //         return _turretsModule;
    //     }
    //     set
    //     {
    //         if (value.TryGetComponent(out Turrets turrets))
    //         {
    //             _turretsModule = value.gameObject;
    //         }
    //     }
    // }
    //
    // private void Awake()
    // {
    //     RamMoudle = GetComponentInChildren<>()
    // }
}
