using UnityEngine;

public class Shotgun : ShootController
{
    [SerializeField] private ShotgunBullet _bulletPrefab;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] [Range(0.05f, 0.5f)] private float _accuracy;
    [Space(5f)]
    [SerializeField] private int _minBulletsCount;
    [SerializeField] private int _maxBulletsCount;
    [Space(5f)]
    [SerializeField] private float _bulletsWorstLifeTime;
    [SerializeField] private float _bulletsBestLifeTime;

    private int _bulletsCount;

    private void Start()
    {
        _bulletsCount = Random.Range(_minBulletsCount, _maxBulletsCount);
    }

    public override void Shoot(Transform shootPosition, int damage)
    {
        for (int i = 0; i < _bulletsCount; i++)
        {
            ShotgunBullet bullet = Instantiate(_bulletPrefab);
            bullet.transform.position = new Vector2(shootPosition.position.x, shootPosition.position.y + Random.Range(-_accuracy, _accuracy));
            bullet.Damage = damage;

            bullet.GetComponent<Rigidbody2D>().AddForce(
                new Vector2(shootPosition.right.x, shootPosition.right.y + Random.Range(-_accuracy, _accuracy)) *
                _bulletSpeed,
                ForceMode2D.Impulse
            );

            Destroy(bullet.gameObject, Random.Range(_bulletsWorstLifeTime, _bulletsBestLifeTime));
        }
    }
}
