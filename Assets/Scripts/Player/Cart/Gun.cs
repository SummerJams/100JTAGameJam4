using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform _gunPosition;

    private Rigidbody2D _rigidbody;
    private Camera _mainCamera;
    private float _shootRate = 0.2f;
    private float temp;

    private void Start()
    {
        _mainCamera = Camera.main;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        FollowCoursor();
    }

    private void FollowCoursor()
    {
        Vector2 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

        Vector2 mouseDirection = mousePosition - _rigidbody.position;

        float angle = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
        
        transform.position = _gunPosition.position;
    }
}
