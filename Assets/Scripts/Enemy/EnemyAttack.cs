using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private TAG_EnemyAttackArea TAG_AttackArea;
    private Collider2D attackCollider;
    private bool attacking = false;

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
        attacking = true;
        attackCollider.enabled= attacking;
    }
}
