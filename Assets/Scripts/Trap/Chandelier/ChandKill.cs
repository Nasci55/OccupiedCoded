using UnityEngine;

public class ChandKill : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        HealthSystem healthSystem = collider.GetComponentInParent<HealthSystem>();
        if (healthSystem == null)
        {
            Destroy(gameObject);
        }
        else
        {
            Debug.Log($"{name} collided with {healthSystem.name}");
            healthSystem.DealDamage(damage);
            Destroy(gameObject);
            Debug.Log($"The player Health now is {healthSystem.Health}");
        }

    }
}
