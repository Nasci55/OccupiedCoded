using UnityEngine;

public class GroundCheckScript : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObject;
    [SerializeField]
    private string groundedParameter = "isGrounded";

    private Animator animator;
    private Player player;
    private bool isGrounded;

    private void Start()
    {
        if (playerObject != null)
        {
            animator = GetComponent<Animator>();
            player = playerObject.GetComponent<Player>();
        }
    }
    private void Update()
    {
        if (player != null)
        {
            isGrounded = player.GetIsGrounded();
            if (isGrounded==true)
            {
                //Debug.Log("Grounded: " + isGrounded);
            }
            else
            {
                //Debug.Log("Grounded: " + isGrounded);
            }
            animator.SetBool(groundedParameter, isGrounded);
        }
    }

}
