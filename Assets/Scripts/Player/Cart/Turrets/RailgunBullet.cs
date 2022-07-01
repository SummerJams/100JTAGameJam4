using UnityEngine;

public class RailgunBullet : MonoBehaviour
{
    [HideInInspector] public Vector2 MousePosition;

    [SerializeField] private LineRenderer _RailgunEffect;

    private int _damage;
    public int Damage
    {
        get { return _damage; }
        set
        {
            if (value <= 0) _damage = 1;
            else _damage = value;
        }
    }

    private void Start()
    {
        RaycastHit2D[] hitedObjects = Physics2D.RaycastAll(transform.position, transform.right, 20f);
        
        for (int i = 0; i < hitedObjects.Length; i++)
        {
            if (hitedObjects[i])
            {
                if (hitedObjects[i].transform.TryGetComponent<Impactable>(out Impactable enemy))
                {
                    enemy.GetComponent<Health>().TakeDamage(Damage);
                }
            }
        }
    }
}