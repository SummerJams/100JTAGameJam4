using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPreviewUI : MonoBehaviour
{
    
    [SerializeField] private Image _ramImage;

    public Image RamImage => _ramImage;

    [SerializeField] private Image _cartBodyImage;

    public Image CartBodyImag => _cartBodyImage;

    [SerializeField] private Image _turretsImage;

    public Image TurretsImage => _turretsImage;
    
    private GameObject _player;
    
    private void Awake()
    {
        _player = GetComponentInParent<SceneInfo>().Player;
    }
    

    public void ReplaceToDefaultPreviewModule()
    {
        CartModule[] DefaultCartModules = _player.GetComponentsInChildren<CartModule>();

        foreach (var DefaultCartModule in DefaultCartModules)
        {
            ReplacePreviewModule(DefaultCartModule);
        }
    }

    public void ReplacePreviewModule(CartModule module)
    {
        switch (module)
        {
            case RamModule _:
            {
                _ramImage.sprite = module.GetComponent<SpriteRenderer>().sprite;
                break;
            }
            case CartBodyModule _:
            {
                _cartBodyImage.sprite = module.GetComponent<SpriteRenderer>().sprite;
                break;
            }
            case TurretsModule _:
            {
                _turretsImage.sprite = module.GetComponent<SpriteRenderer>().sprite;
                break;
            }
            default:
            {
                Debug.LogException(new Exception("Invalid module"));
                return;
            }
        }
    }
}