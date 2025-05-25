using UnityEngine;

public class SoundON : MonoBehaviour
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
    // Update is called once per frame
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
}
