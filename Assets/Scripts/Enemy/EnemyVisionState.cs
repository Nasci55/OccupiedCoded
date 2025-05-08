using UnityEngine;

public class EnemyVisionState : MonoBehaviour
{
    private Flashlight flashlight;
    private TAG_BigVisionEnemy bigVisionEnemy;
    private TAG_SmallVisionEnemy smallVisionEnemy;
    private Collider2D cSmallVision;
    private Collider2D cBigVision;
    private Player player;
    private Collider2D playerCollider;
    public bool IsPlayerBeingSeen { get; private set; }


    private void Start()
    {
        flashlight = FindFirstObjectByType<Flashlight>();
        smallVisionEnemy = FindFirstObjectByType<TAG_SmallVisionEnemy>();
        cSmallVision = smallVisionEnemy.GetComponent<Collider2D>();
        bigVisionEnemy = FindFirstObjectByType <TAG_BigVisionEnemy>();
        cBigVision = bigVisionEnemy.GetComponent<Collider2D>();
        player = FindFirstObjectByType<Player>();
    }

    private void Update()
    {
        EnemyVisionRange();
        EnemyDetection();
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        playerCollider = player.GetComponent<Collider2D>();

        if (playerCollider != null)
        {
            if (collider == playerCollider)
            {
                IsPlayerBeingSeen = true;
            }
            else IsPlayerBeingSeen = false;
        }
    }

    private void EnemyDetection()
    {
        playerCollider = player.GetComponent<Collider2D>();

        if (playerCollider != null)
        {
            if ((cBigVision || cSmallVision) == playerCollider )
            {
                IsPlayerBeingSeen = true;
            }
            else IsPlayerBeingSeen = false;
        }
    }

    private void EnemyVisionRange()
    {
        if (flashlight != null)
        {
            if (flashlight.GetFlashlightState() == true)
            {

                cBigVision.enabled = true;
                cSmallVision.enabled = false;
            }
            else
            {
                cBigVision.enabled = false;
                cSmallVision.enabled = true;
            }
        }
    }
}
