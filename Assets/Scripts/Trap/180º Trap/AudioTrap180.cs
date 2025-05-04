using System.Collections;
using UnityEngine;

public class Audio180Trap : MonoBehaviour
{
    private bool playOnce = true;
    
    [SerializeField]
    private Trigger180 trigger180;
    [SerializeField]
    private AudioClip audioClipComingDown;
    [SerializeField]
    private AudioClip audioClipGoingUp;




    void Update()
    {

        if (trigger180.isActivated() == true && playOnce == true)
        {
            SoundManager.instance.playSound(audioClipComingDown, transform, 1f);
            playOnce = false;
        }
        else if (trigger180.isActivated() == false && playOnce == false)
        {
            StartCoroutine(delay());
            playOnce = true;
           
        }

    }
    private IEnumerator delay()
    {
        yield return new WaitForSeconds(2f); 
        SoundManager.instance.playSound(audioClipGoingUp, transform, 1f);
    }
}
