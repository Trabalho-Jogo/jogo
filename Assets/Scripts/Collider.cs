using UnityEngine;

public class Collider : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entrou no trigger: " + other.name);

        if (other.CompareTag("Player"))
        {
            PlayerKnockback knockback = other.GetComponent<PlayerKnockback>();

            if (knockback != null)
                knockback.Knockback(transform.position);

            EnemyKnockback enemyKnockback = GetComponent<EnemyKnockback>();
            if (enemyKnockback != null)
            {
                enemyKnockback.ApplyKnockback(other.transform.position);
            }
        }
    }
}
