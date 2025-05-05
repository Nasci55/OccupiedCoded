using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class Beartrap : MonoBehaviour 
{
    [SerializeField] private int damage = 1;
    [SerializeField] private AudioClip audioClip;
    private void OnTriggerStay2D(Collider2D collider)
    {
        HealthSystem healthSystem = collider.GetComponentInParent<HealthSystem>();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //Debug.Log($"The {name} is deactivated");
        }
        else
        {
            SoundManager.instance.playSound(audioClip, transform, 1f);
            //Debug.Log($"{name} collided with {healthSystem.name}");
            healthSystem.DealDamage(damage);
            Debug.Log($"The player Health now is {healthSystem.getHealth}");
            Destroy(gameObject.GetComponent<BoxCollider2D>());
            Destroy(gameObject, audioClip.length);
        }
    }

}
