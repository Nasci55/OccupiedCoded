using UnityEngine;

public class AnimatorVelocityLinker : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject playerObject;

    [SerializeField]
    private string velocityParameter = "xVelocity"; 

    private float playerVelocity;

    private Player player;


    private void Start()
    {
        if (playerObject != null)

        {
            player = playerObject.GetComponent<Player>();
        }

    }

    private void Update()
    {
        if (player != null)
        {   
            playerVelocity = player.GetCurrentVelocity();
            if (player.transform.rotation == Quaternion.identity)
            {
                animator.SetFloat(velocityParameter, playerVelocity);
            }
            else
            {
                animator.SetFloat(velocityParameter, -playerVelocity);
            }   
        }
    }
}