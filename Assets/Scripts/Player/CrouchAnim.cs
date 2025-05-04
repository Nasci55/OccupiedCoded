using UnityEngine;

public class CrouchAnim : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    
    private string crouchParameter = "Standing"; 


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool(crouchParameter, false);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool(crouchParameter, true);
        }
    }
}