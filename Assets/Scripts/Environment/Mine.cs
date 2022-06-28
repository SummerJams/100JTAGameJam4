using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private float _animationTime;

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
        Explosion();
    }

    private void Explosion()
    {
        _animator.SetBool("DoExplosion", true);

        Destroy(gameObject, _animationTime);
    }
}
