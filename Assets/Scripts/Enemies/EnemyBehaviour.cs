using UnityEngine;
using System.Collections;

public abstract class EnemyBehaviour : MonoBehaviour
{
    public abstract Rigidbody2D enemyRigidbody { get; }
    public abstract Animator animator { get; }
    public abstract Health health { get; }
    public abstract SpriteRenderer sprite { get; }
    public abstract Transform rightPlayerSide { get; }
    public abstract Transform leftPlayerSide { get; }
    public abstract int damage { get; }
    public abstract float speed { get; }
    public abstract float attackTime { get; }
    public abstract float deathTime { get; }
    public abstract float attackDistance { get; }
    public abstract float timeBetweenAttacks { get; }
    public abstract float distanceToPlayerFromSides { get; }

    private float _currentDistanceToPlayer;
    private float _rightSideDistance;
    private float _leftSideDistance;
    private bool _readyToAttack;
    private bool _isDied;
    private bool _isAttacking;
    private bool _isRightSideCloser;
    private bool _isEnemyCloseToPlayer;

    private void Start()
    {
        health.Death.AddListener(Death);
        health.Damaged.AddListener(WasDamagedHandler);
    }

    private IEnumerator Attack()
    {
        animator.SetBool("isRunning", false);
        animator.SetBool("isAttacking", true);
        _isAttacking = true;
        enemyRigidbody.isKinematic = true;
        yield return new WaitForSeconds(attackTime);
        animator.SetBool("isAttacking", false);
        yield return new WaitForSeconds(timeBetweenAttacks);
        _isAttacking = false;
        enemyRigidbody.isKinematic = false;
    }

    private void Death()
    {
        animator.SetBool("isRunning", false);
        animator.SetBool("isAttacking", false);
        _isDied = true;
        animator.SetBool("isDied", true);
        Destroy(gameObject, deathTime);
    }

    protected void ChasePlayer()
    {
        _rightSideDistance = Vector2.Distance(transform.position, rightPlayerSide.position);
        _leftSideDistance = Vector2.Distance(transform.position, leftPlayerSide.position);

        _isRightSideCloser = _rightSideDistance < _leftSideDistance;
        _isEnemyCloseToPlayer = _isRightSideCloser ? _rightSideDistance <= distanceToPlayerFromSides : _leftSideDistance <= distanceToPlayerFromSides;

        _currentDistanceToPlayer = Vector2.Distance(transform.position, TopDownMovement.PlayerCentralTransform.position);
        _readyToAttack = _currentDistanceToPlayer <= attackDistance;

        if (_isAttacking == false && _isDied == false)
        {
            if (_readyToAttack)
            {
                StartCoroutine(Attack());
            }
            else
            {
                Flip();
                animator.SetBool("isRunning", true);

                if (_isEnemyCloseToPlayer)
                {
                    enemyRigidbody.MovePosition(enemyRigidbody.position + PlayerDirection(transform.position, TopDownMovement.PlayerCentralTransform.position, speed) * Time.deltaTime);
                }
                else
                {
                    enemyRigidbody.MovePosition(enemyRigidbody.position + 
                        PlayerDirection(transform.position, _isRightSideCloser ? rightPlayerSide.position : leftPlayerSide.position, speed) * Time.deltaTime);
                }
            }
        }
    }

    private void WasDamagedHandler() => StartCoroutine(WasDamaged());

    private IEnumerator WasDamaged()
    {
        sprite.color = new Color(255, 0, 0);
        yield return new WaitForSeconds(.1f);
        sprite.color = Color.white;
    }

    private void Flip()
    {
        if (TopDownMovement.PlayerCentralTransform.position.x < transform.position.x)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<TopDownMovement>(out TopDownMovement player))
        {
            player.GetComponent<Health>().TakeDamage(damage);
        }
    }

    private Vector2 PlayerDirection(Vector2 objectPosition, Vector2 targetPosition, float speed)
    {
        float xDirection, yDirection;

        Vector2 distanceToTarget = new Vector2(targetPosition.x - objectPosition.x, targetPosition.y - objectPosition.y);

        if (Mathf.Abs(distanceToTarget.x) > Mathf.Abs(distanceToTarget.y))
        {
            xDirection = (distanceToTarget.x / Mathf.Abs(distanceToTarget.x)) * speed;
        }
        else
        {
            xDirection = Mathf.Abs(distanceToTarget.x) / Mathf.Abs(distanceToTarget.y) * ((distanceToTarget.x / Mathf.Abs(distanceToTarget.x)) * speed);
        }

        if (Mathf.Abs(distanceToTarget.y) > Mathf.Abs(distanceToTarget.x))
        {
            yDirection = (distanceToTarget.y / Mathf.Abs(distanceToTarget.y)) * speed;
        }
        else
        {
            yDirection = Mathf.Abs(distanceToTarget.y) / Mathf.Abs(distanceToTarget.x) * ((distanceToTarget.y / Mathf.Abs(distanceToTarget.y)) * speed);
        }

        return new Vector2(xDirection, yDirection);
    }
}