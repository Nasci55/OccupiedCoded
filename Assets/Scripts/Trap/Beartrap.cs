using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using UnityEditor.Experimental.GraphView;

public class Beartrap : MonoBehaviour 
{
    [SerializeField] private int damage = 1; 
    private void OnTriggerStay2D(Collider2D collider)
    {
        HealthSystem healthSystem = collider.GetComponentInParent<HealthSystem>();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log($"The {name} is deactivated");
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
