using UnityEngine;
using System.Collections;

public class MachineGun : ShootController
{
    [SerializeField] private Transform upperShootPositon;
    [SerializeField] private Transform downShootPositon;
    [SerializeField] private MachineGunBullet _bulletPrefab;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _shootAnimationTime;

    private Animator _animator;
    private bool _isShooting;
    private bool _isLastShotFromUpperMuzzle;

    private void Start() => _animator = GetComponent<Animator>();

    public override void Shoot(AudioSource shootSound, int damage)
    {
        MachineGunBullet bullet = Instantiate(_bulletPrefab);
        bullet.Damage = damage;
        
        if (_isLastShotFromUpperMuzzle)
        {
            bullet.transform.position = downShootPositon.position;
            bullet.GetComponent<Rigidbody2D>().AddForce(downShootPositon.right * _bulletSpeed, ForceMode2D.Impulse);
            shootSound.Play();
            _isLastShotFromUpperMuzzle = false;
        }
        else
        {
            bullet.transform.position = upperShootPositon.position;
            bullet.GetComponent<Rigidbody2D>().AddForce(upperShootPositon.right * _bulletSpeed, ForceMode2D.Impulse);
            shootSound.Play();
            _isLastShotFromUpperMuzzle = true;
        }

        if (_isShooting == false)
            StartCoroutine(PlayShootAniamtion());

        Destroy(bullet.gameObject, 2f);
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
