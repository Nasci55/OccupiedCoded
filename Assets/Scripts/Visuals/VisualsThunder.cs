using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class VisualsThunder : MonoBehaviour
{
    [SerializeField]
    private float delayInTheSameThunder;
    [SerializeField]
    private float timerBetweenThunders;

    [SerializeField, Header("Sound Manager")] 
    private AudioClip audioSound;
    [SerializeField]
    private float Volume = 1.0f;

    private Light2D thunderLight;
    private float originalTimer;
    private float timer;

    void Start()
    {
        thunderLight = GetComponent<Light2D>();
        thunderLight.enabled = false;
        timer = 0;
        originalTimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < timerBetweenThunders*60)
        {

            timer += 1;

        }
        else
        {
            timer = originalTimer;
            StartCoroutine(ThunderDelay());
            int fiftySound = Random.Range(0, 1);
            if (fiftySound == 0)
            {
                if (audioSound != null)
                {
                    SoundManager.instance.playSound(audioSound, transform, Volume);
                }
            }

        }


    }

    private IEnumerator ThunderDelay()
    {
        thunderLight.enabled = !thunderLight.enabled;
        yield return new WaitForSeconds(delayInTheSameThunder);
        thunderLight.enabled = !thunderLight.enabled;
    }

  

}
