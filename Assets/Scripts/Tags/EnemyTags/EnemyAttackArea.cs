using UnityEngine;

public class EnemyAttackArea : MonoBehaviour
{
    private int damage = 1;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        HealthSystem healthSystem = collider.GetComponentInParent<HealthSystem>();
        if (healthSystem != null)
        {
            Debug.Log($"{name} collided with {healthSystem.name}");
            healthSystem.DealDamage(damage);
            Debug.Log($"The player Health now is {healthSystem.getHealth}");
        }
    }
}
