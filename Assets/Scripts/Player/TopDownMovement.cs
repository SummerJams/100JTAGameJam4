﻿using UnityEngine;
using System.Collections;

public class TopDownMovement : MonoBehaviour
{
    public static Transform PlayerTransform;

    [SerializeField] private float _moveSpeed;
    [Header("Dash properties")]
    [SerializeField] private float _dashSpeed;
    [SerializeField] private float _dashCooldown;
    [SerializeField] private float _dashDuration;
    [SerializeField] private TrailRenderer _trail;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Vector2 _movement;
    private float _timer;
    private bool _facingRight = true;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        PlayerTransform = transform;
        _timer = _dashCooldown;
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

        _timer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift) && _timer < 0 && _movement != Vector2.zero)
        {
            StartCoroutine(Dash());
            _timer = _dashCooldown;
        }

        if (!_facingRight && _movement.x < 0)
        {
            Flip();
        }
        else if (_facingRight && _movement.x > 0)
        {
            Flip();
        }
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
        _trail.emitting = true;
        yield return new WaitForSeconds(_dashDuration);
        _trail.emitting = false;
        _moveSpeed = temp;
    }
}
