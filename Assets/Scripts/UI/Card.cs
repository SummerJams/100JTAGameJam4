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
    
    private PlayerPreviewView _playerPreviewView;
    private StatsPreview _statsPreview;
    private GameObject _moduleGameObject;
    private Cart _cart;
    
    private void Awake()
    {
        _cart = GameManager.Instance.Player.GetComponentInChildren<Cart>(); //rewrite player link 
        _playerPreviewView = GetComponentInParent<PlayerPreviewView>();
        _statsPreview = GetComponentInParent<StatsPreview>();
        
        GenerateNewCard();
    }

    public void GenerateNewCard()
    {
        _moduleGameObject = new RandomModuleGenerator().NewCartMoudle();
        ModuleComponent = _moduleGameObject.GetComponentInChildren<CartModule>();

        _TMPName.text = ModuleComponent.Name;
            
        switch(ModuleComponent)
        {
            case RamModule _:
            {
                _TMPStats[0].text = "Damage: " + ModuleComponent.GetSpecifications()[0];
                _TMPStats[1].text = "Dash Cooldown: " + ModuleComponent.GetSpecifications()[1] + ".s";
                break;
            }
            case CartBodyModule _:
            {
                _TMPStats[0].text = "Health: " + ModuleComponent.GetSpecifications()[0];
                _TMPStats[1].text = "Speed: " + ModuleComponent.GetSpecifications()[1];
                break;
            }
            case TurretsModule _:
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
        _playerPreviewView.ReplacePreviewModule(ModuleComponent);
    }
    
    public void BackDefaultPreviewModule()
    {
        _playerPreviewView.ReplaceToDefaultPreviewModule();
        _statsPreview.ClearStatsBar();
    }
    public void ApplyModule()
    {
        _cart.SwitchModule(_moduleGameObject);
        GetComponentInParent<ModuleSelectionScreen>().Close();
    }
}
