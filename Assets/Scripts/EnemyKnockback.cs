using UnityEngine;

public class EnemyKnockback : MonoBehaviour
{
    [Header("Configurações")]
    public float knockbackForce = 2f; 
    public float knockbackTime = 0.2f; 

    private Rigidbody2D rb;
    private float timer;

    
    public bool IsKnockedBack => timer > 0f;

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                
                rb.linearVelocity = Vector2.zero;
            }
        }
    }

    public void ApplyKnockback(Vector2 attackSourcePosition)
    {
        timer = knockbackTime;

        Vector2 dir = ((Vector2)transform.position - attackSourcePosition).normalized;

        rb.linearVelocity = Vector2.zero;

        rb.linearVelocity = dir * knockbackForce;
    }
}