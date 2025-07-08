using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FInalScene : MonoBehaviour
{
    [SerializeField]
    private Light2D firstLight;
    [SerializeField]
    private Light2D secondLight;
    [SerializeField]
    private GameObject Enemy;
    [SerializeField, Header("Timers")]
    private float firstTimerToTurnOffLight;
    [SerializeField]
    private float secondTimerToTurnOffLight;
    [SerializeField]
    private float thirdTimerToTurnOffLight;
    [SerializeField]
    private SpriteRenderer enemyAracnoid;
    [SerializeField, Header("Audio")]
    private AudioClip firstAudio;
    [SerializeField]
    private float volume1;
    [SerializeField]
    private AudioClip secondAudio;
    [SerializeField]
    private float volume2;
    [SerializeField]
    private AudioClip thirdAudio;
    [SerializeField]
    private float volume3;

    private bool finalSceneCoroutineStarted = false;
    private bool finalSceneCoroutineMiddle = false;
    private bool Audio = false;

    private HouseSafeAnim start;
    private bool thirdTime = true;
    private bool secondTime = true;
    private bool firstTime = true;
    void Start()
    {
        enemyAracnoid.enabled = false;
        start = FindFirstObjectByType<HouseSafeAnim>();
    }

    // Update is called once per frame
    void Update()
    {
        if (firstTime == true && secondTime == true && thirdTime == true && start.activateFinalScene)
        {
            if (!finalSceneCoroutineStarted)
            {
                finalSceneCoroutineStarted = true;
                StartCoroutine(StartFinalScene());
            }
            if (firstAudio != null && Audio == false)
            {
                SoundManager.instance.playSound(firstAudio, transform, volume1);
                Audio = true;
            }
            TurnOffAndOnLights();
        }
        if (firstTime == false &&  secondTime == true && thirdTime == true)
        {
            
            SecondTurnOffAndOnLights();
            if (!finalSceneCoroutineMiddle)
            {
                StartCoroutine(LightFlicker());
                finalSceneCoroutineMiddle = true;
            }
 
        }
        if (firstTime == false && secondTime == false && thirdTime == true)
        {
            ThirdTurnOffAndOnLights();
        }
        if (firstTime == false && secondTime == false && firstTime == false)
        {

            enemyAracnoid.enabled = false;
            firstLight.enabled = true;
            secondLight.enabled = true; 
            RealEnemySpawn();
            StartCoroutine(ChangeScene());

        }
        
       
    
    }

    private void TurnOffAndOnLights()
    {
        firstTimerToTurnOffLight -= Time.deltaTime;

        Debug.Log(firstTimerToTurnOffLight);
        if (firstTimerToTurnOffLight < 0 && firstTime == true)
        {
            Debug.Log("CABOU");
            firstLight.enabled = !firstLight.enabled;
            secondLight.enabled = !secondLight.enabled;
            enemyAracnoid.enabled = true;
            firstTime = false;
        }
    }

    private void SecondTurnOffAndOnLights()
    {
        secondTimerToTurnOffLight -= Time.deltaTime;

        Debug.Log(secondTimerToTurnOffLight);
        if (secondTimerToTurnOffLight < 0 && secondTime == true)
        {
            Debug.Log("CABOU");
            firstLight.enabled = false;
            secondLight.enabled = false;
            if (secondAudio != null)
            {
                SoundManager.instance.playSound(secondAudio, transform, volume2);
            }
            
            secondTime = false;
        }
    }

    private void ThirdTurnOffAndOnLights()
    {
        thirdTimerToTurnOffLight -= Time.deltaTime;

        Debug.Log(thirdTimerToTurnOffLight);
        if (thirdTimerToTurnOffLight < 0 && thirdTime == true)
        {
            Debug.Log("CABOU");
            firstLight.enabled = !firstLight.enabled;
            secondLight.enabled = !secondLight.enabled;
            if (thirdAudio != null)
            {
                SoundManager.instance.playSound(thirdAudio, transform, volume3);
            }

            enemyAracnoid.enabled = !enemyAracnoid.enabled;
            thirdTime = false;
        }
    }


    private void RealEnemySpawn()
    {
        Enemy.SetActive(true);
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(1.5f);

        SceneTransition.TransitionToScene("FinalOfTheChapter");
    }

    IEnumerator StartFinalScene()
    {
        yield return new WaitForSeconds(1f);

        firstLight.enabled = !firstLight.enabled;
        secondLight.enabled = !secondLight.enabled;
    }

    IEnumerator LightFlicker()
    {
        yield return new WaitForSeconds(1f);

        firstLight.enabled = !firstLight.enabled;
        secondLight.enabled = !secondLight.enabled;
    }
}
