using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _TMPName;
    [SerializeField] private TextMeshProUGUI[] _TMPStats;
    [SerializeField] private Image _imageModulePreview;
    
    public CartModule ModuleComponent { get; private set; }
    
    private PlayerPreviewUI _playerPreviewUI;
    private StatsPreview _statsPreview;
    private GameObject _moduleGameObject;
    private Cart _cart;
    
    private void Awake()
    {
        _cart = GetComponentInParent<SceneInfo>().Player.GetComponentInChildren<Cart>();
        _playerPreviewUI = GetComponentInParent<PlayerPreviewUI>();
        _statsPreview = GetComponentInParent<StatsPreview>();
        _moduleGameObject = new RandomModuleGenerator().NewCartMoudle();
        ModuleComponent = _moduleGameObject.GetComponentInChildren<CartModule>();

        _TMPName.text = ModuleComponent.Name;
            
        switch(ModuleComponent)
        {
            case Ram _:
            {
                _TMPStats[0].text = "Damage: " + ModuleComponent.GetSpecifications()[0];
                _TMPStats[1].text = "Dash Cooldown: " + ModuleComponent.GetSpecifications()[1] + "s";
                break;
            }
            case CartBody _:
            {
                _TMPStats[0].text = "Health: " + ModuleComponent.GetSpecifications()[0];
                _TMPStats[1].text = "Speed: " + ModuleComponent.GetSpecifications()[1];
                break;
            }
            case Turrets _:
            {
                _TMPStats[0].text = "Damage: " + ModuleComponent.GetSpecifications()[0];
                _TMPStats[1].text = "Rate of Fire: " + ModuleComponent.GetSpecifications()[1];
                break;
            }
            default:
            {
                Debug.LogException(new Exception("Invalid module"));
                return;
            }
            
        }
        
        _imageModulePreview.sprite = ModuleComponent.GetComponent<SpriteRenderer>().sprite;
        _imageModulePreview.SetNativeSize();
    }
    
    public void PreviewModule()
    {
        _statsPreview.DisplayStatСompare(ModuleComponent);
        _playerPreviewUI.ReplacePreviewModule(ModuleComponent);
    }
    
    public void BackDefaultPreviewModule()
    {
        _playerPreviewUI.ReplaceToDefaultPreviewModule();
        _statsPreview.ClearStatsBar();
    }
    public void ApplyModule()
    {
        _cart.SwitchModule(_moduleGameObject);
        Destroy(_playerPreviewUI.gameObject);
    }
}
