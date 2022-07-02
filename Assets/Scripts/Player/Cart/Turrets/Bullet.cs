using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    private int _damage;

    public int Damage
    {
        get { return _damage; }
        set { 
            if (value <= 0) 
                _damage = 1;
            else 
                _damage = value;
        }
    }

    private void Update()
    {
        RaycastHit2D hitedObject = Physics2D.Raycast(transform.position, Vector2.right, 0.1f);

        if (hitedObject)
        {
            if (hitedObject.transform.TryGetComponent<Impactable>(out Impactable enemy))
            {
                Health enemyHealth = enemy.GetComponent<Health>();
                enemyHealth.TakeDamage(Damage);
                enemyHealth.Damaged.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
