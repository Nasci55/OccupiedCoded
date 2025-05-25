using UnityEngine;

public class EnemyAttackArea : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject playerObject;

    [SerializeField]
    private string AttackParameter = "Attack";

    private PlayerHiding PlayerHiding;
    private bool isPlayerHiding;
    private int damage = 1;
    private void Start()
    {
        PlayerHiding = FindFirstObjectByType<PlayerHiding>();
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        isPlayerHiding = PlayerHiding.currentlyHiding;
        Debug.Log(isPlayerHiding);
        if (isPlayerHiding == false)
        {
            HealthSystem healthSystem = collider.GetComponentInParent<HealthSystem>();
            if (healthSystem != null)
            {
                Debug.Log($"{name} collided with {healthSystem.name}");
                healthSystem.DealDamage(damage);
                animator.SetTrigger(AttackParameter);
                
                Debug.Log($"The player Health now is {healthSystem.getHealth}");
            }
        }
    }




}
