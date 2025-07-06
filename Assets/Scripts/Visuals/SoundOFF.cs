using UnityEngine;

public class SoundOFF : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private GameObject Player;
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject == Player)
        {
            //Debug.Log("Player entered the trigger");
            audioSource.enabled = false;
        }
        
    } 
}
