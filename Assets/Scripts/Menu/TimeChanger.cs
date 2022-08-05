using System;
using UnityEngine;

public class TimeChanger : MonoBehaviour
{
    private void Awake()
    {
        GlobalEventManager.OnOpenInGameMenu.AddListener(StopGameTime);
        GlobalEventManager.OnCloseInGameMenu.AddListener(ResumeGameTime);
    }

    private void StopGameTime()
    {
        Time.timeScale = 0;
    }
    
    private void ResumeGameTime()
    {
        Time.timeScale = 1;
    }

}
