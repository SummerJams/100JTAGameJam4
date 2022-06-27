using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Vector2 _movement;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        _animator.SetFloat("Horizontal", _movement.x);
        _animator.SetFloat("Vertical", _movement.y);
        _animator.SetFloat("Speed", _movement.sqrMagnitude);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            _animator.SetFloat("LastHorizontal", Input.GetAxisRaw("Horizontal"));
            _animator.SetFloat("LastVertical", Input.GetAxisRaw("Vertical"));
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 90);
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, -90);
        }

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 180);
        }

        if (Input.GetAxisRaw("Vertical") < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + _movement * _moveSpeed * Time.fixedDeltaTime);
    }
}
