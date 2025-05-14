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
    float changeInDirectionCooldown = 5;
    float randomDirection;




[SerializeField]
    private Vector2 velocity;
    
    [SerializeField]
    private float maxDistance;

    void Start()
    {
        player = FindFirstObjectByType<Player>();
        visionState = GetComponentInChildren<EnemyVisionState>();

        rb = GetComponent<Rigidbody2D>();
    }

    

    private void Update()
    {
        playerPos = player.transform.position;
        //Chase();
        if (visionState.IsPlayerBeingSeen == true)
        {
            Chase();
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
            if (playerPos.x - transform.position.x < maxDistance && playerPos.x - transform.position.x >-maxDistance)
            {
                
                currentVelocity = velocity *0;
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

    
    
    
    private void Wandering()
    {
         changeInDirectionCooldown -= Time.deltaTime;
       
        
        
        if(changeInDirectionCooldown <= 0)
        {
            randomDirection = Random.Range(-1f, 1f);
            changeInDirectionCooldown = Random.Range(2f, 3f);   
            Debug.Log($"Cooldown : {changeInDirectionCooldown} \n velocity = {rb.linearVelocity}");
        }
        else
        {
            if (randomDirection < 0)
            {
                rb.linearVelocity = velocity/1.25f * -1;
            }
            else
            {
                rb.linearVelocity = velocity/1.25f * 1;
            }        
        
        }

    }
}
