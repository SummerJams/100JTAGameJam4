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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Explosion();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out Health health))
        {
            health.TakeDamage(_damage);
        }
    }

    private void Explosion()
    {
        _animator.SetBool("DoExplosion", true);

        Destroy(gameObject, _animationTime);
    }
}
