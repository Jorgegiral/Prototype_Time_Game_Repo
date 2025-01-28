using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float detectionRadius = 5.0f;
    public float speed = 2.0f;

    bool isFacingRight;
    private Rigidbody2D enemyRb;
    private Vector2 enemymovement;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < detectionRadius)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            enemymovement = new Vector2(direction.x, 0);
            Enemydirection(direction.x);
        }
        else
        {
            enemymovement = Vector2.zero;
        }
        enemyRb.MovePosition(enemyRb.position + enemymovement * speed * Time.deltaTime);
    }

    void Enemydirection(float directionX)
        {
            if  (directionX < 0)
            {
                if (isFacingRight)
                {
                    Flip();
                }
            }
            if (directionX > 0)
            {
                if (!isFacingRight)
                {
                    Flip();
                }
            }
    }
    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
        isFacingRight = !isFacingRight;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
