using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _health;

    public int HealthProperty => _health;

    public int MaxHealth
    {
        get => _maxHealth;
        set { if (value > 0) _maxHealth = value; }
    }

    public UnityEvent Death = new UnityEvent();
    public UnityEvent Damaged = new UnityEvent();
    private bool isAlive = true;

    private void Awake() => _health = _maxHealth;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            if (isAlive)
            {
                Death.Invoke();
                isAlive = false;
            }
            
        }
        else
        {
            Damaged.Invoke();
        }
    }
}
