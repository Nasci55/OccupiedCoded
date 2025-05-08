using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour
{
    private Player player;
    private Vector3 playerPos;
    private float currentVelocity;
    private bool beingSeen;
    private EnemyVisionState visionState;


    [SerializeField]
    private Vector2 velocity;
    
    [SerializeField]
    private float maxDistance;

    void Start()
    {
        player = FindFirstObjectByType<Player>();
        visionState = GetComponentInChildren<EnemyVisionState>();
    }

    

    private void Update()
    {
        playerPos = player.transform.position;
        //Chase();
        //Debug.Log($"Is the enemy seeing you? {visionState.IsPlayerBeingSeen}");
        transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
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
}
