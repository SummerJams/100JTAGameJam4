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
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.right, 0.1f);

        if (hitInfo)
        {
            if (hitInfo.transform.TryGetComponent<Health>(out Health enemy) &&
                hitInfo.transform.TryGetComponent<TopDownMovement>(out TopDownMovement player) == false)
            {
                enemy.TakeDamage(Damage);
                Destroy(gameObject);
            }
        }
    }
}
