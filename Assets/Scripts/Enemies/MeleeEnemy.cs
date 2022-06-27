using UnityEngine;

public class MeleeEnemy : EnemyBehaviour
{
    [SerializeField] private float _health = 20f;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _damage = 1f;

    private Rigidbody2D _rigidbody2D;

    public override float health { get => _health; set => _health = value; }
    public override Rigidbody2D enemyRigidbody => _rigidbody2D;
    public override float damage => _damage;
    public override float speed => _speed;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Walk();
    }
}
