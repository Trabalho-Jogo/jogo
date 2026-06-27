using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyChase : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    private Rigidbody2D rb;
    private Animator animator;
    private EnemyKnockback knockback;

    [Header("Movement")]
    public float detectionRadius = 5f;
    public float moveSpeed = 3f;

    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        knockback = GetComponent<EnemyKnockback>();
    }

    void Update()
    {
        if (knockback != null && knockback.IsKnockedBack)
        {
            movement = Vector2.zero;
            return;
        }
        if (player == null)
            return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= detectionRadius)
        {
            movement = ((Vector2)player.position - rb.position).normalized;

            animator.SetBool("isWalking", true);

            animator.SetFloat("InputX", movement.x);
            animator.SetFloat("InputY", movement.y);

            animator.SetFloat("LastInputX", movement.x);
            animator.SetFloat("LastInputY", movement.y);
        }
        else
        {
            movement = Vector2.zero;

            animator.SetBool("isWalking", false);
        }
    }

    void FixedUpdate()
    {
        if (knockback != null && knockback.IsKnockedBack)
        {
            return;
        }

        rb.linearVelocity = movement * moveSpeed;
        //rb.linearVelocity = movement * moveSpeed;
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}