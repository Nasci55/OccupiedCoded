using UnityEngine;

public class FootStepScript : MonoBehaviour
{

    private Animator mAnim;
    private AudioSource audioSource;

    private void Start()
    {
        mAnim = GetComponent<Animator>();
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Step()
    {   
        if (mAnim.GetBool("IsGrounded"))
        {
            audioSource.Play();
        }
    }
}