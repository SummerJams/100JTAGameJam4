
public class PlayerHealth : Health
{
    protected override void Awake()
    {
        base.Awake();
        GlobalEventManager.OnWaveStart.AddListener(ctx=> SetMaxHealth());
    }
}
