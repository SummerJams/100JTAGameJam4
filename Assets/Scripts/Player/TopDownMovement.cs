using UnityEngine;
using System.Collections;

public class TopDownMovement : MonoBehaviour
{
    public static Transform PlayerTransform;

    [SerializeField] private float _moveSpeed;
    [Header("Dash properties")]
    [SerializeField] private ParticleSystem _dust;
    [SerializeField] private TrailRenderer _trail;
    [SerializeField] private float _dashSpeed;
    [SerializeField] private float _dashCooldown;
    [SerializeField] private float _dashDuration;
    [SerializeField] private bool _turnOnTrail;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Vector2 _movement;
    private Health _health;
    private float _timer;
    private bool _isAlive;
    private bool _facingRight = true;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _health.Death.AddListener(Death);
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        
        PlayerTransform = transform;
        _timer = _dashCooldown;
    }

    private void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        _animator.SetFloat("Speed", _movement.sqrMagnitude);

        _timer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift) && _timer < 0 && _movement != Vector2.zero)
        {
            StartCoroutine(Dash());
            _timer = _dashCooldown;
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
        _moveSpeed = _dashSpeed;
        if (_turnOnTrail)_trail.emitting = true;
        yield return new WaitForSeconds(_dashDuration);
        if (_turnOnTrail) _trail.emitting = false;
        _moveSpeed = temp;
    }

    private void Death()
    {
        _isAlive = false;
        Debug.Log("YOU DIED");
    }
}
