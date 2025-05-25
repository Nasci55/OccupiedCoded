using UnityEngine;

public class SoundON : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioSource OtherSound;

    [SerializeField]
    private GameObject Player;
    void Start()
    {
        audioSource.enabled = false;
    }
    
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject == Player)
        {
            Debug.Log("Player entered the trigger");
            if (OtherSound != null && OtherSound.enabled == false)
            {
                audioSource.enabled = true;
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
            }
            else if (OtherSound != null && OtherSound.enabled == true)
            {
                audioSource.enabled = false;
            }
        }
    } 
}
