using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.right, 0.1f);

        if (hitInfo)
        {
            if (hitInfo.transform.TryGetComponent<Health>(out Health enemy) && 
                hitInfo.transform.TryGetComponent<TopDownMovement>(out TopDownMovement player) == false)
            {
                enemy.TakeDamage(_damage);
                Destroy(gameObject);
            }
        }

    }
}
