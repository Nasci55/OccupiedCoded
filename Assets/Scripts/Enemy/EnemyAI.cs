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

    float randomPath;

    [SerializeField]
    private Vector2 velocity;
    
    [SerializeField]
    private float maxDistance;

    void Start()
    {
        player = FindFirstObjectByType<Player>();
        visionState = GetComponentInChildren<EnemyVisionState>();
        randomPath = Random.Range(-75, 75);
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
                
                currentVelocity = 0;
            }
            else
            {

                if (playerPos.x < transform.position.x)
                {
                    
                    currentVelocity = -velocity.x;
                    
                }
                else if (playerPos.x > transform.position.x)
                {
                   
                    currentVelocity = velocity.x;
                }
            }
            transform.position = new Vector3(transform.position.x + currentVelocity, transform.position.y, transform.position.z);

        }
    }

    
    
    
    private void Wandering()
    {
        float originalpos = transform.position.x;

        randomPath = Random.Range(-25, 25);

        float newPosition = originalpos + randomPath;
       
        if (originalpos > newPosition && randomPath < 0)
            {

                velocity = new Vector2(2f, 0f); 
                currentVelocity = -velocity.x;
            }
        else if (originalpos < newPosition && randomPath > 0)
           {
                velocity =new Vector2 (2f, 0f);
                currentVelocity = velocity.x;
            }


        currentVelocity = rb.linearVelocity;

        currentVelocity.x = moveDir * velocity.x;





        //transform.position = new Vector3(transform.position.x + currentVelocity, transform.position.y, transform.position.z);

    }
}
