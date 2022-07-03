using UnityEngine;

public abstract class ShootController : MonoBehaviour
{
    [SerializeField] private Transform _gunPosition;
    [SerializeField] private Transform _shootPosition;
    [SerializeField] private AudioSource _shootSound;
    [SerializeField] private int _damage;
    [SerializeField] private float _shootRate = 0.2f;

    private Camera _mainCamera;
    private float angle;
    private float shootTimer;
    private Vector2 _mousePosition;
    private bool _isLookRight = true;

    private bool _isReadyToShoot => shootTimer > _shootRate;

    public int damage { get => _damage; set { if (value > 0) _damage = value; } }
    public float shootRate { get => _shootRate; set { if (value > 0) _shootRate = value; } }

    private void Awake() => _mainCamera = Camera.main;

    private void Update()
    {
        FollowCoursor();

        shootTimer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0) && _isReadyToShoot)
        {
            if (gameObject.GetComponent<Railgun>())
            {
                Shoot(_shootPosition, _shootSound, _damage, angle); ;
            }
            else if (gameObject.GetComponent<MachineGun>())
            {
                Shoot(_shootSound, _damage);
            }
            else
            {
                Shoot(_shootPosition, _shootSound, _damage);
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

    public virtual void Shoot(Transform shootPosition, AudioSource shootSound, int damage) { }
    public virtual void Shoot(Transform shootPosition, AudioSource shootSound, int damage, float angle) { }
    public virtual void Shoot(AudioSource shootSound, int damage) { }
}
