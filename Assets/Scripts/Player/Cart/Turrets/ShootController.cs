using UnityEngine;

public abstract class ShootController : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Transform _gunPosition;
    [SerializeField] private Transform _shootPosition;
    [SerializeField] private int _damage;
    [SerializeField] private float _shootRate = 0.2f;

    private float angle;
    private float shootTimer;
    private Vector2 _mousePosition;
    private bool _isLookRight = true;

    private bool _isReadyToShoot => shootTimer > _shootRate;

    private void Update()
    {
        FollowCoursor();

        shootTimer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0) && _isReadyToShoot)
        {
            if (gameObject.GetComponent<Railgun>())
            {
                Shoot(_shootPosition, _damage, angle);
            }
            else
            {
                Shoot(_shootPosition, _damage);
            }
            shootTimer = 0;
        }
    }

    private void FollowCoursor()
    {
        _mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mouseDirection = new Vector2(_mousePosition.x - transform.position.x, _mousePosition.y - transform.position.y);

        angle = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg;
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

    public virtual void Shoot(Transform shootPosition, int damage) { }

    public virtual void Shoot(Transform shootPosition, int damage, float angle) { }
}
