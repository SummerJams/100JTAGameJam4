using UnityEngine;
using System.Collections;

public class Railgun : ShootController
{
    [SerializeField] private RailgunBullet _bulletPrefab;
    [SerializeField] private float _bulletLifetime;
    [SerializeField] private float _shootAnimationTime;

    private Animator _animator;
    private bool _isShooting;

    private void Start() => _animator = GetComponent<Animator>();

    public override void Shoot(Transform shootPosition, AudioSource shootSound, int damage, float angle)
    {
        RailgunBullet bullet = Instantiate(_bulletPrefab);
        bullet.Damage = damage;
        bullet.transform.position = shootPosition.position;
        bullet.transform.rotation = Quaternion.Euler(0, 0, angle);

        shootSound.Play();

        if (_isShooting == false)
            StartCoroutine(PlayShootAniamtion());

        Destroy(bullet.gameObject, _bulletLifetime);
    }

    private IEnumerator PlayShootAniamtion()
    {
        _animator.SetBool("isShooting", true);
        _isShooting = true;
        yield return new WaitForSeconds(_shootAnimationTime);
        _animator.SetBool("isShooting", false);
        _isShooting = false;
    }
}
