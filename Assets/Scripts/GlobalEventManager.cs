using UnityEngine.Events;

public class GlobalEventManager 
{
    public static readonly UnityEvent<int> OnWaveEnd = new UnityEvent<int>();
    public static readonly UnityEvent<int> OnWaveStart = new UnityEvent<int>();
    public static readonly UnityEvent OnOpenInGameMenu = new UnityEvent();
    public static readonly UnityEvent OnCloseInGameMenu = new UnityEvent();

}
