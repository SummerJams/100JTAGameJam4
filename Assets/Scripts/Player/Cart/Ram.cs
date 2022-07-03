using UnityEngine;

public class Ram : MonoBehaviour
{
    public float DashCooldown;
    public int DashDamage;

    public bool IsDashing;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsDashing && collision.TryGetComponent<Impactable>(out Impactable enemy))
        {
            enemy.GetComponent<Health>().TakeDamage(DashDamage);
        }
    }
}
