using UnityEngine;

public class BoxSound : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    void Start()
    {
        audioSource.enabled = false;
    }

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        audioSource.enabled = true;
        if (collider.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger");
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
    
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("Player exited the trigger");
            audioSource.enabled = false;
            Collider2D triggerCollider = GetComponent<Collider2D>();
                if (triggerCollider != null)
                {
                    triggerCollider.enabled = false;
                }
        }
    }
}
