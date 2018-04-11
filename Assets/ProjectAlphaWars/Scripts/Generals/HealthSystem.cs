using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int initialHealth;
    private int currentHealth;

    // Use this for initialization
    void Start()
    {
        currentHealth = initialHealth;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        print("TakeDamage");
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Die");
        Destroy(gameObject);
    }
}
