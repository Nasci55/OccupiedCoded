using UnityEngine;

public class EnemyVisionState : MonoBehaviour
{
    private Flashlight flashlight;
    private TAG_BigVisionEnemy bigVisionEnemy;
    private TAG_SmallVisionEnemy smallVisionEnemy;
    private Collider2D cSmallVision;
    private Collider2D cBigVision;
    private bool flashlightState;


    private void Start()
    {
        flashlight = FindFirstObjectByType<Flashlight>();
        smallVisionEnemy = FindFirstObjectByType<TAG_SmallVisionEnemy>();
        cSmallVision = smallVisionEnemy.GetComponent<Collider2D>();
        bigVisionEnemy = FindFirstObjectByType <TAG_BigVisionEnemy>();
        cBigVision = bigVisionEnemy.GetComponent<Collider2D>();
    }

    private void Update()
    {    
        
        if (flashlight.GetFlashlightState() == true)
        {
            //Debug.Log("On" + flashlightState);
            cBigVision.enabled = true;
            cSmallVision.enabled = false;
        }
        else
        {
            //Debug.Log("Off" + flashlightState);
            cBigVision.enabled = false;
            cSmallVision.enabled = true;
        }
    }
}
