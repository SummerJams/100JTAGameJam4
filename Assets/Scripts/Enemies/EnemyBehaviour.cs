using UnityEngine;

public abstract class EnemyBehaviour : MonoBehaviour
{
    public abstract float health { get; set; }
    public abstract Rigidbody2D enemyRigidbody { get; }
    public abstract float damage { get; }
    public abstract float speed { get; }

    public void TakeDamage(EnemyBehaviour enemy, float damage)
    {
        if (damage >= enemy.health)
            Die(enemy);
        else
        {
            enemy.health -= damage;
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<LivenessController>(out LivenessController playerLive))
        {
            playerLive.health -= damage;
            playerLive._healthBar.SetHealth(playerLive.health);
        }
    }*/

    public void Die(EnemyBehaviour enemy)
    {
        Destroy(enemy.gameObject);
    }

    public void Walk()
    {
        enemyRigidbody.MovePosition(enemyRigidbody.position + PlayerDirection(transform.position, TopDownMovement.PlayerTransform.position, speed) * Time.deltaTime);
    }

    public void Flip()
    {
        if (TopDownMovement.PlayerTransform.position.x < transform.position.x)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);
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