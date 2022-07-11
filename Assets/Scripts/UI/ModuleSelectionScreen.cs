using System;
using UnityEditor.Playables;
using UnityEngine;

public class ModuleSelectionScreen : MonoBehaviour
{
    private Transform[] _childTransforms;
    private Card[] _cards;
    
    
    private void Awake()
    {
        _childTransforms = UtilityExtensions.GetComponentsOnlyInChildren<Transform>(transform);
        _cards = GetComponentsInChildren<Card>(true);
        
        GlobalEventManager.OnWaveEnd.AddListener(ctx => Open());
    }

    private void Open()
    {
        foreach (var childTransform in _childTransforms)
        {
            childTransform.gameObject.SetActive(true);
        }
        
        GlobalEventManager.OnOpenInGameMenu.Invoke();

        Refresh();
    }
    
    public void Close()
    {
        foreach (var childTransform in _childTransforms)
        {
            childTransform.gameObject.SetActive(false);
        }
        
        GlobalEventManager.OnCloseInGameMenu.Invoke();
    }
    
    
    
    private void Refresh()
    {
        foreach (var card in _cards)
        {
            card.GenerateNewCard();
        }
    }
    
    
}
