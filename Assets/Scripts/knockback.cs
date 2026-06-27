using UnityEngine;

public class PlayerKnockback : MonoBehaviour
{
    [Header("Configurações")]
    public float knockbackForce = 3f;
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
                rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            }
        }
    }

    public void Knockback(Vector2 source)
    {
        timer = knockbackTime;

        Vector2 dir = ((Vector2)transform.position - source).normalized;

        rb.linearVelocity = Vector2.zero;

        rb.linearVelocity = new Vector2(dir.x, dir.y + 0.2f).normalized * knockbackForce;
    }
}