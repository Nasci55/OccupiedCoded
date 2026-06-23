using UnityEngine;

public class FootStepScript : MonoBehaviour
{

    private Animator mAnim;
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip[] footStepsClips;

    private void Start()
    {
        mAnim = GetComponent<Animator>();
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Step()
    {   
        if (mAnim.GetBool("IsGrounded"))
        {
            audioSource.clip = footStepsClips[Random.Range(0, footStepsClips.Length)];
            audioSource.Play();
        }
    }
}