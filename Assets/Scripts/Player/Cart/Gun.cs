using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform _gunPosition;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _shootPosition;

    private Camera _mainCamera;
    private float _shootRate = 0.2f;
    private float temp;
    private Vector2 _mousePosition;
    private bool _isLookRight = true;

    private bool _isReadyToShoot => temp > _shootRate;

    private void Start() => _mainCamera = Camera.main;

    private void Update()
    {
        FollowCoursor();

        temp += Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0) && _isReadyToShoot)
        {
            Shoot();
            temp = 0;
        }
    }

    private void FollowCoursor()
    {
        _mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mouseDirection = new Vector2(_mousePosition.x - transform.position.x, _mousePosition.y - transform.position.y);

        float angle = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (angle > 90 || angle < -90 && _isLookRight)
        {
            transform.localScale = new Vector3(1, -1, 1);
            _isLookRight = false;
        }
        else if (angle < 90 && angle > -90 && _isLookRight == false)
        {
            transform.localScale = new Vector3(1, 1, 1);
            _isLookRight = true;
        }

        transform.position = _gunPosition.position;
    }

    private void Shoot()
    {
        Bullet _bullet = Instantiate(_bulletPrefab);
        _bullet.transform.position = _shootPosition.position;
        _bullet.GetComponent<Rigidbody2D>().AddForce(_shootPosition.right * _bulletSpeed, ForceMode2D.Impulse);

        Destroy(_bullet.gameObject, 2f);
    }
}
