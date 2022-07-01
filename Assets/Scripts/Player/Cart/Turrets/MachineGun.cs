using UnityEngine;

public class MachineGun : ShootController
{
    [SerializeField] private MachineGunBullet _bulletPrefab;
    [SerializeField] private float _bulletSpeed;

    public override void Shoot(Transform shootPosition, int damage)
    {
        MachineGunBullet bullet = Instantiate(_bulletPrefab);
        bullet.transform.position = shootPosition.position;
        bullet.Damage = damage;
        bullet.GetComponent<Rigidbody2D>().AddForce(shootPosition.right * _bulletSpeed, ForceMode2D.Impulse);

        Destroy(bullet.gameObject, 2f);
    }
}
