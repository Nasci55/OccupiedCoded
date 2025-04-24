using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private AudioSource sound;  


    private void Awake()
    {
        instance = this;
    }

    public void playSound(AudioClip audioClip, Transform transform, float volume)
    {
        AudioSource audioSource = Instantiate(sound, transform);

        audioSource.clip = audioClip;

        audioSource.volume = volume;

        audioSource.Play();

        float clipLenght = audioSource.clip.length;

        Destroy(audioSource, clipLenght);
    }


}
