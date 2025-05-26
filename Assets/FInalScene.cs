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
    private AudioSource firstAudio;
    [SerializeField]
    private AudioSource secondAudio;
    [SerializeField]
    private AudioSource thirdAudio;

    private HouseSafeAnim start;
    private bool thirdTime = true;
    private bool secondTime = true;
    private bool firstTime = true;
    private float initialTimer;
    void Start()
    {
        initialTimer = firstTimerToTurnOffLight;
        enemyAracnoid.enabled = false;
        start = FindFirstObjectByType<HouseSafeAnim>();
    }

    // Update is called once per frame
    void Update()
    {
        if (firstTime == true && secondTime == true && thirdTime == true && start.activateFinalScene)
        {
            TurnOffAndOnLights();
        }
        if (firstTime == false &&  secondTime == true && thirdTime == true)
        {
            enemyAracnoid.enabled = true;
            SecondTurnOffAndOnLights();
 
        }
        if (firstTime == false && secondTime == false && thirdTime == true)
        {
            enemyAracnoid.enabled = false;
            ThirdTurnOffAndOnLights();
        }
        if (firstTime == false && secondTime == false && firstTime == false)
        {

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
            if (firstAudio != null)
            {
                firstAudio.Play();
            }
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
            firstLight.enabled = !firstLight.enabled;
            secondLight.enabled = !secondLight.enabled;
            if (secondAudio != null)
            {
                secondAudio.Play();
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
                thirdAudio.Play();
            }


            enemyAracnoid.enabled = false;
            thirdTime = false;
        }
    }

    private void EnemySpawnAndDispawn()
    {
        enemyAracnoid.enabled = !enemyAracnoid.enabled;
    }

    private void RealEnemySpawn()
    {
        Enemy.SetActive(true);
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(1f);

        SceneTransition.TransitionToScene("FinalOfTheChapter");
    }
}
