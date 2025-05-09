using System.Collections;
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
        //transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
        StartCoroutine(Wandering());
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

    private IEnumerator Wandering()
    {
        yield return new WaitForSeconds(Random.Range(3, 5));
        
        int randomPath = Random.Range(0, 2);


        switch (randomPath)
        {
            case 0:
                Debug.Log("Direita");
                new Vector3(transform.position.x + currentVelocity, transform.position.y, transform.position.z);
                break;
            case 1:
                Debug.Log("Esquerda");
                new Vector3(transform.position.x - currentVelocity, transform.position.y, transform.position.z);
                break;
            case 2:
                Debug.Log("Parado");
                new Vector3(0, transform.position.y, transform.position.z);
                break;
        }

        }
}
