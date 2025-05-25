using UnityEngine;

public class SoundOFF : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collider)
    {
        audioSource.enabled = false;
    } 
}
