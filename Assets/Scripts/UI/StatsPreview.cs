using System;
using TMPro;
using UnityEngine;

public class StatsPreview : MonoBehaviour
{
    [SerializeField] private Color _postiveColor = Color.green;
    [SerializeField] private Color _negativeColor = Color.red;
    [SerializeField] private TextMeshProUGUI[] _TMPs;

    private GameObject _player;

    private void Awake()
    {
        _player = GetComponentInParent<SceneInfo>().Player;
    }

    public void DisplayStatСompare(CartModule newModule)
    {
        float[] newModuleSpecifications = newModule.GetSpecifications();
      
        switch(newModule)
        {
        
            case RamModule _:
            {
                float[] defaultModuleSpecifications = _player.GetComponentInChildren<RamModule>().GetSpecifications();
            
                _TMPs[0].text = "Damage: " + "\t" + defaultModuleSpecifications[0] + "\t" + newModuleSpecifications[0];
                
                if (defaultModuleSpecifications[0] < newModuleSpecifications[0])
                {
                    _TMPs[0].color = _postiveColor;
                }
                else
                {
                    _TMPs[0].color = _negativeColor;
                }
                
                _TMPs[1].text = "Dash Cooldown: " + "\t" + defaultModuleSpecifications[1] + ".s" + "\t" + newModuleSpecifications[1] + ".s";
                
                if (defaultModuleSpecifications[1] > newModuleSpecifications[1])
                {
                    _TMPs[1].color = _postiveColor;
                }
                else
                {
                    _TMPs[1].color = _negativeColor;
                }
                break;
            }
            case CartBodyModule _:
            {
                float[] defaultModuleSpecifications = _player.GetComponentInChildren<CartBodyModule>().GetSpecifications();
            
                _TMPs[0].text = "Health: " + "\t" + defaultModuleSpecifications[0] + "\t" + newModuleSpecifications[0];
                
                if (defaultModuleSpecifications[0] < newModuleSpecifications[0])
                {
                    _TMPs[0].color = _postiveColor;
                }
                else
                {
                    _TMPs[0].color = _negativeColor;
                }
                
                _TMPs[1].text = "Speed: " + "\t" + defaultModuleSpecifications[1] + "\t" + newModuleSpecifications[1];
                
                if (defaultModuleSpecifications[1] < newModuleSpecifications[1])
                {
                    _TMPs[1].color = _postiveColor;
                }
                else
                {
                    _TMPs[1].color = _negativeColor;
                }
                break;
            }
            case TurretsModule _:
            {

                float[] defaultModuleSpecifications = _player.GetComponentInChildren<TurretsModule>().GetSpecifications();
            
                _TMPs[0].text = "Damage: " + "\t" + defaultModuleSpecifications[0] + "\t" + newModuleSpecifications[0];
                
                if (defaultModuleSpecifications[0] < newModuleSpecifications[0])
                {
                    _TMPs[0].color = _postiveColor;
                }
                else
                {
                    _TMPs[0].color = _negativeColor;
                }
                
                _TMPs[1].text = "Rate of Fire: " + "\t" + defaultModuleSpecifications[1] + "\t" + newModuleSpecifications[1];
                
                if (defaultModuleSpecifications[1] < newModuleSpecifications[1])
                {
                    _TMPs[1].color = _postiveColor;
                }
                else
                {
                    _TMPs[1].color = _negativeColor;
                }
                break;
            }
            default:
            {
                Debug.LogException(new Exception("Invalid module"));
                return;
            }
            
        }
    }

    public void ClearStatsBar()
    {
        foreach (var tmp in _TMPs)
        {
            tmp.text = "";
        }
    }
}