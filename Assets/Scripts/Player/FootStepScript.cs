using UnityEngine;
using System.Collections.Generic;

public class FootStepScript : MonoBehaviour
{

    private Animator mAnim;
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip[] footStepsClips;


    private Queue<AudioClip> audioClipInCooldown;

    private void Start()
    {
        mAnim = GetComponent<Animator>();
        audioClipInCooldown = new Queue<AudioClip>();
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Step()
    {   
        if (mAnim.GetBool("IsGrounded"))
        {
            AudioClip currentClip = footStepsClips[Random.Range(0, footStepsClips.Length)];

            while (audioClipInCooldown.Contains(currentClip))
            {
                currentClip = footStepsClips[Random.Range(0, footStepsClips.Length)];
            }
            
            audioClipInCooldown.Enqueue(currentClip);

            if (audioClipInCooldown.Count >= 2) //MagicNumber
                audioClipInCooldown.Dequeue();

            audioSource.clip = currentClip;

            audioSource.Play();
        }
    }
}