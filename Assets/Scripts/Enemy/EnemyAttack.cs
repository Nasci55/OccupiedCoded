using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private TAG_EnemyAttackArea TAG_AttackArea;
    private Collider2D attackCollider;
    private bool attacking = false;
    private float timer = 0;

    void Start()
    {
        TAG_AttackArea = FindFirstObjectByType<TAG_EnemyAttackArea>();
        attackCollider = TAG_AttackArea.GetComponent<Collider2D>();
        attackCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Attack()
    {
        Debug.Log(attackCollider.enabled);
        timer += Time.deltaTime;
        Debug.Log(timer);
        if (timer <= 0)
        {
            Attacking();
            Debug.Log("Enemy is attacking");
        }
        else if (timer <= 5 || timer >= 0.01)
        {
            attacking = false;
            Debug.Log("Enemy attack is on cooldown");
        }
        else if (timer >= 5)
        {
            timer = -0.1f; 

        }

    }
    private void Attacking()
    {
        attacking = true;
        attackCollider.enabled = attacking;
    }

    private void OnDrawGizmos()
    {
        if (attacking)
        {
            Gizmos.color = Color.yellow;
        }
        else
        {
            Gizmos.color= Color.red;
        }
             Gizmos.DrawWireCube(transform.position, transform.forward);
    }
}
