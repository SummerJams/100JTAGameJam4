using UnityEngine;
using System.Collections;

public class TopDownMovement : MonoBehaviour
{
    public static Transform PlayerTransform;

    [SerializeField] private float _moveSpeed;
    [Header("Dash properties")]
    [SerializeField] private float _dashSpeed;
    [SerializeField] private float _dashFrequency;
    [SerializeField] private float _dashDuration;
    private float temp;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Vector2 _movement;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        PlayerTransform = transform;
        temp = _dashFrequency;
    }

    private void Update()
    {
        #region Animation code
        /*_animator.SetFloat("Horizontal", _movement.x);
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
        }*/
        #endregion

        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        temp -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift) && temp < 0 && _movement != Vector2.zero)
        {
            StartCoroutine(Dash());
            temp = _dashFrequency;
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + _movement.normalized * _moveSpeed * Time.fixedDeltaTime);
    }

    private IEnumerator Dash()
    {
        float temp1 = _moveSpeed;
        _moveSpeed = _dashSpeed;
        yield return new WaitForSeconds(_dashDuration);
        _moveSpeed = temp1;
    }
}
