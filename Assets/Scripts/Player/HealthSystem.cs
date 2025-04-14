using Unity.VisualScripting;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int MaxHealth = 3; 

    int health;

    private void Start()
    {
        health = MaxHealth;
    }

    public void DealDamage(int damage)
    {
        if (health > 0)
        {
            health -= damage;
        }
        else if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
