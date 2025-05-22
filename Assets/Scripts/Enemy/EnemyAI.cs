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
    private float maxDistance;

    [SerializeField, Header("Audio")]
    private AudioClip EnemyAudio;

    [SerializeField]
    private float volume = 0.1f;

    void Start()
    {
        player = FindFirstObjectByType<Player>();
        visionState = GetComponentInChildren<EnemyVisionState>();
        enemyAttack = GetComponent<EnemyAttack>();
        rb = GetComponent<Rigidbody2D>();
    }



    private void Update()
    {
        playerPos = player.transform.position;
        if (visionState.IsPlayerBeingSeen == true)
        {
            Chase();
            EnemySeeingPlayerAudio();
        }
        else
        {
            Wandering();
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

                    currentVelocity = -velocity;

                }
                else if (playerPos.x > transform.position.x)
                {

                    currentVelocity = velocity;
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
            soundEffect = true;
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
    
    public float GetCurrentVelocity()
    {
        return rb.linearVelocity.x;
    }
}
