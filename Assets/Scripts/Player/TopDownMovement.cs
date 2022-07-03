using UnityEngine;
using System.Collections;

public class TopDownMovement : MonoBehaviour
{
    public static Transform PlayerCentralTransform;
    public static Transform PlayerLeftSideTransform;
    public static Transform PlayerRightSideTransform;

    [SerializeField] private Transform _centerOfThePlayer;
    [SerializeField] private Transform _leftSideOfPlayer;
    [SerializeField] private Transform _rightSideOfPlayer;
    [SerializeField] private float _moveSpeed;
    [Header("Dash properties")]
    [SerializeField] private ParticleSystem _dust;
    [SerializeField] private float _dashDuration;
    [SerializeField] private Ram _ram;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Vector2 _movement;
    private Health _health;
    private float _dashTimer;
    private bool _isAlive = true;
    private bool _facingRight = true;
    private float _dashSpeed;

    public float moveSpeed
    {
        get => _moveSpeed;
        set { if (value > 0) _moveSpeed = value; }
    }

    private void Awake()
    {
        PlayerCentralTransform = _centerOfThePlayer;
        PlayerLeftSideTransform = _leftSideOfPlayer;
        PlayerRightSideTransform = _rightSideOfPlayer;

        _health = GetComponent<Health>();
        _health.Death.AddListener(Death);
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        _animator.SetFloat("Speed", _movement.sqrMagnitude);

        _dashTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift) && _dashTimer < 0 && _movement != Vector2.zero)
        {
            StartCoroutine(Dash());
            _dashTimer = _ram.DashCooldown;
            ParticleSystem dust = Instantiate(_dust, transform);
            Destroy(dust.gameObject, 1f);
        }

        if (!_facingRight && _movement.x < 0)
            Flip();
        else if (_facingRight && _movement.x > 0)
            Flip();
    }

    private void FixedUpdate() => _rigidbody.MovePosition(_rigidbody.position + _movement.normalized * _moveSpeed * Time.fixedDeltaTime);

    private void Flip()
    {
        _facingRight = !_facingRight;
        transform.rotation = Quaternion.Euler(0, _facingRight ? 180f : 0, 0);
    }

    private IEnumerator Dash()
    {
        float temp = _moveSpeed;
        _dashSpeed = _moveSpeed * 3;
        _moveSpeed = _dashSpeed;
        _ram.IsDashing = true;
        yield return new WaitForSeconds(_dashDuration);
        _ram.IsDashing = false;
        _moveSpeed = temp;
    }

    private void Death()
    {
        _isAlive = false;
        Debug.Log("YOU DIED");
    }
}
