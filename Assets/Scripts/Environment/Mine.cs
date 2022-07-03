using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private float _animationTime;
    [SerializeField] private int _damage;

    private Animator _animator;
    private Health _health;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        _health = GetComponent<Health>(); 
        _health.Death.AddListener(Explosion);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out Health health))
        {
            health.TakeDamage(_damage);
        }
        else if (collision.GetComponentInParent<Health>())
        {
            collision.GetComponentInParent<Health>().TakeDamage(_damage);
        }
    }

    public void Explosion()
    {
        _animator.SetBool("DoExplosion", true);

        Destroy(gameObject, _animationTime);
    }
}
