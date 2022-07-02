using UnityEngine;

[RequireComponent(typeof(Impactable))]
public class MeleeEnemy : EnemyBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private float _attackTime;
    [SerializeField] private float _deathTime;
    [SerializeField] private float _attackDistance;
    [SerializeField] private float _distanceToPlayerFromSides;
    [SerializeField] private float _timeBetweenAttacks;

    private Transform _rightPlayerSide;
    private Transform _leftPlayerSide;
    private Rigidbody2D _rigidbody;
    private Health _health;
    private Animator _animator;
    private SpriteRenderer _sprite;

    public override Rigidbody2D enemyRigidbody => _rigidbody;
    public override Animator animator => _animator;
    public override SpriteRenderer sprite => _sprite;
    public override Health health => _health;
    public override Transform rightPlayerSide => _rightPlayerSide;
    public override Transform leftPlayerSide => _leftPlayerSide;
    public override float speed => _speed;
    public override int damage => _damage;
    public override float attackTime => _attackTime;
    public override float deathTime => _deathTime;
    public override float attackDistance => _attackDistance;
    public override float timeBetweenAttacks => _timeBetweenAttacks;
    public override float distanceToPlayerFromSides => _distanceToPlayerFromSides;

    private void Start()
    {
        _rightPlayerSide = TopDownMovement.PlayerRightSideTransform;
        _leftPlayerSide = TopDownMovement.PlayerRightSideTransform;

        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _health = GetComponent<Health>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void Update() => ChasePlayer();
}
