using UnityEngine;

public class Health : MonoBehaviour
{
    [Min(0)] [SerializeField] private int maxHealth = 5;
    [SerializeField] private bool killAtDeath = true;
    private int currentHealth;

    private void Awake() 
    {
        currentHealth = maxHealth;
    }

    public void DecreaseHealth()
    {
        DecreaseHealth(1);
    }

    public void DecreaseHealth(int healthPoint)
    {
        currentHealth -= healthPoint;

        if(isDead() && killAtDeath) {Kill();}

    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    public bool isDead()
    {
        return currentHealth <= 0;
    }
}
