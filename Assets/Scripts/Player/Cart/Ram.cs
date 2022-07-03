using UnityEngine;

public class Ram : MonoBehaviour
{
    [HideInInspector] public float DashCooldown;
    [HideInInspector] public int DashDamage;
    [HideInInspector] public bool IsDashing;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsDashing && collision.gameObject.TryGetComponent<Impactable>(out Impactable enemy))
        {
            enemy.GetComponent<Health>().TakeDamage(DashDamage);
        }
    }
}
