using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    public int MaxHealth => _maxHealth;

    public UnityEvent Death = new UnityEvent();
    public UnityEvent Damaged = new UnityEvent();
    
    private int _health;
    public int HealthProperty => _health;

    private void Awake() => _health = _maxHealth;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Death.Invoke();
        }
    }
}
