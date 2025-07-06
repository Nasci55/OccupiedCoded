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
        playerPassThroughCorridor.enabled = false;
        
    }



    private void Update()
    {
        Debug.Log($"EnemySeated = {activateEnemySeated}     " +
                  $"EnemyChasing = {activateChase}");
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

            }
            else
            {
                Wandering();
                soundEffect = true;

            }
        }
        else
        {
            playerPassThroughCorridor.enabled = true;
            EnemySittingSprite.SetActive(true);
            ChaseScene();
        }


    }



    private void Chase()
    {
        if (player != null)
        {
            if (playerPos.x - transform.position.x < maxDistance && playerPos.x - transform.position.x > -maxDistance)
            {

                currentVelocity = velocity * 0;
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



        if (changeInDirectionCooldown <= 0)
        {
            randomDirection = Random.Range(-1f, 1f);
            changeInDirectionCooldown = Random.Range(2f, 3f);
            //Debug.Log($"Cooldown : {changeInDirectionCooldown} \n velocity = {rb.linearVelocity}");
        }
        else
        {
            if (randomDirection < 0)
            {
                rb.linearVelocity = velocity / 1.25f * -1;
            }
            else
            {
                rb.linearVelocity = velocity / 1.25f * 1;
            }

        }

    }

    public float GetCurrentVelocity() => rb.linearVelocity.x;


    private void ChaseScene()
    {
        activateChase = playerPassThroughCorridor.didThePlayerPassThrough;

        if (activateChase == false)
        {
            if (!tpToHoldOff)
            {
                rb.position = enemyHoldOffPoint.position;
                Debug.Log("Adeus vou me embora");
                tpToHoldOff = false;
            }
        }
        else if (activateChase)
        {
            EnemySittingSprite.SetActive(false);
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

}
