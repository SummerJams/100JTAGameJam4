using UnityEngine;

public class Railgun : ShootController
{
    [SerializeField] private RailgunBullet _bulletPrefab;
    [SerializeField] private float _bulletLifetime;

    public override void Shoot(Transform shootPosition, int damage, float angle)
    {
        RailgunBullet bullet = Instantiate(_bulletPrefab);
        bullet.Damage = damage;
        bullet.transform.position = shootPosition.position;
        bullet.transform.rotation = Quaternion.Euler(0, 0, angle);

        Destroy(bullet.gameObject, _bulletLifetime);
    }
}
