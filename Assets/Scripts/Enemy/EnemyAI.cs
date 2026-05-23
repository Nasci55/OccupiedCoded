using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour
{
    private Player player;
    private Vector3 playerPos;
    private Vector2 currentVelocity;
    private bool beingSeen;
    private EnemyVisionState visionState;
    private Rigidbody2D rb;
    private float changeInDirectionCooldown = 5;
    private float randomDirection;
    private bool soundEffect = true;
    private EnemyAttack enemyAttack;








    [SerializeField]
    private Vector2 velocity;

    [SerializeField]
    private Vector2 ChaseVelocityMulti;

    [SerializeField]
    private float maxDistance;
    [SerializeField]
    private float timerAfterSeeing = 2;
    private float timerCount;

    [SerializeField, Header("Wall Detector")]
    private Transform wallDetector;
    [SerializeField, Range(0, 5)]
    private float wallDetectorRadius;
    [SerializeField]
    private LayerMask layersToTurnEnemy;

    [SerializeField, Header("Audio")]
    private AudioClip EnemyAudio;

    [SerializeField]
    private float volume = 0.1f;

    [SerializeField, Header("Chase Scene")]
    private bool testChaseScene;

    [SerializeField]
    private DidThePlayerPassThrough playerPassThroughInFamilyRoom;
    [SerializeField]
    private DidThePlayerPassThrough playerPassThroughCorridor;
    [SerializeField]
    private Transform startPointForEnemyChase;


    [SerializeField]
    private Transform enemyHoldOffPoint;
    [SerializeField]
    private GameObject EnemySittingSprite;


    private bool activateEnemySeated;
    private bool activateChase = false;
    private bool tpToCorridor = true;
    private bool tpToHoldOff = true;





    void Start()
    {
        player = FindFirstObjectByType<Player>();
        visionState = GetComponentInChildren<EnemyVisionState>();
        enemyAttack = GetComponent<EnemyAttack>();
        rb = GetComponent<Rigidbody2D>();
        playerPassThroughCorridor.GetComponent<Collider2D>().enabled = false;
        
    }



    private void Update()
    {
        /*Debug.Log($"EnemySeated = {activateEnemySeated}     " +
                  $"EnemyChasing = {activateChase}");*/
        if (rb.linearVelocity.x < 0)
        {
            transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        }
        else if (rb.linearVelocity.x > 0)
        {
            transform.rotation = Quaternion.identity;
        }

        activateEnemySeated = playerPassThroughInFamilyRoom.didThePlayerPassThrough;

        playerPos = player.transform.position;
        if (!activateEnemySeated)
        {
            if (visionState.IsPlayerBeingSeen == true)
            {
                Chase();
                EnemySeeingPlayerAudio();
                timerCount = timerAfterSeeing;
            }
            else
            {
                timerCount -=Time.deltaTime;
                if (timerCount > 0 && transform.position.x != playerPos.x)
                {
                    Chase();
                    Debug.Log("Tou a chegar aqui");
                }
                else
                { 
                    Wandering();
                    soundEffect = true;
                }

            }
        }
        else
        {
            playerPassThroughCorridor.enabled = true;
            EnemySittingSprite.SetActive(true);
            ChaseScene();
        }
        //Debug.Log(timerCount);


    }



    private void Chase()
    {
        if (player != null)
        {
            if (playerPos.x - transform.position.x < maxDistance && playerPos.x - transform.position.x > -maxDistance)
            {
                Vector3 playerDirection = (playerPos - transform.position).normalized;
                currentVelocity = velocity * playerDirection.x * 0.001f;
                enemyAttack.Attack();
            }
            else
            {

                if (playerPos.x < transform.position.x)
                {

                    currentVelocity = -velocity * ChaseVelocityMulti;

                }
                else if (playerPos.x > transform.position.x)
                {

                    currentVelocity = velocity * ChaseVelocityMulti;
                }
            }
            rb.linearVelocity = currentVelocity;

        }
    }

    private void EnemySeeingPlayerAudio()
    {
        if (visionState.IsPlayerBeingSeen == true && soundEffect == true)
        {
            SoundManager.instance.playSound(EnemyAudio, transform, volume);
            soundEffect = false;
        }
        else if (visionState.IsPlayerBeingSeen == false && soundEffect == false)
        {
        }
    }


    private void Wandering()
    {
        changeInDirectionCooldown -= Time.deltaTime;
        bool touchingWall = Physics2D.OverlapCircle(wallDetector.position, wallDetectorRadius, layersToTurnEnemy);


        if (changeInDirectionCooldown <= 0)
        {
            randomDirection = Random.Range(-1f, 1f);
            changeInDirectionCooldown = Random.Range(2f, 4f);
            Debug.Log(changeInDirectionCooldown);
            //Debug.Log($"Cooldown : {changeInDirectionCooldown} \n velocity = {rb.linearVelocity}");
        }
        else
        {
            if (randomDirection < -0.33f)
            {
                rb.linearVelocity = velocity / 1.25f * -1;

            }
            else if (randomDirection > 0.33)
            {
                rb.linearVelocity = velocity / 1.25f * 1;
            }
            else if(-0.33f < randomDirection && randomDirection < 0.33f)
            {
                rb.linearVelocity = velocity / 1.25f * 0;
            }
            if (touchingWall)
            {
                changeInDirectionCooldown = -1;
            }

        }

    }

    public float GetCurrentVelocity() => rb.linearVelocity.x;


    private void ChaseScene()
    {
        playerPassThroughCorridor.GetComponent<Collider2D>().enabled = true;
        activateChase = playerPassThroughCorridor.didThePlayerPassThrough;

        if (activateChase == false)
        {
            if (tpToHoldOff)
            {
                rb.position = enemyHoldOffPoint.position;
                Debug.Log("Adeus vou me embora");
                tpToHoldOff = false;
            }
        }
        else if (activateChase)
        {
            EnemySittingSprite.SetActive(false);
            ChaseVelocityMulti = Vector2.right * 3;
            if (tpToCorridor)
            { 
                rb.position = startPointForEnemyChase.position;
                Debug.Log("Olá voltei");
                tpToCorridor = false;
            }
            Chase();
            if (visionState.IsPlayerBeingSeen == true)
            {
                EnemySeeingPlayerAudio();
            }

        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(wallDetector.position, wallDetectorRadius);
    }
}
