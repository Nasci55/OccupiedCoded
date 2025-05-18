using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private EnemyAttackArea TAG_AttackArea;
    private GameObject attackCollider;
    [SerializeField]
    private bool attacking = false;
    private float timer = 0;

    void Start()
    {
        TAG_AttackArea = FindFirstObjectByType<EnemyAttackArea>();
        attackCollider = TAG_AttackArea.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Attack()
    {
        Debug.Log(attackCollider);
        timer += Time.deltaTime;
        //Debug.Log($"{timer}-------{Time.deltaTime}");
        if (timer <= 0)
        {
            Attacking();
            Debug.Log("Enemy is attacking");
        }
        else if (timer <= 5 && timer >= 0.01)
        {
            StopAttacking();
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
        attackCollider.SetActive(attacking);
    }

    private void StopAttacking()
    {
        attacking = false;
        attackCollider.SetActive (attacking);
    }

}
