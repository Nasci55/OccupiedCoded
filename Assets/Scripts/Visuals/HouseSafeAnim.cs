using UnityEngine;

public class HouseSafeAnim : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private bool playerInTrigger = false;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger");
            playerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("Player exited the trigger");
            playerInTrigger = false;
        }
    }

    private void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E key pressed");
            animator.SetBool("IsOpen", true);
        }
    }
}
