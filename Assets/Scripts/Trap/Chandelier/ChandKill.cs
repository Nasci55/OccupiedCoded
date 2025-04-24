using UnityEngine;

public class ChandKill : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField]
    private AudioClip audioClip;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        HealthSystem healthSystem = collider.GetComponentInParent<HealthSystem>();
        if (healthSystem == null)
        {
            SoundManager.instance.playSound(audioClip, transform, 0.1f);
            Destroy(gameObject.GetComponent<BoxCollider2D>());
            Destroy(gameObject.GetComponent<SpriteRenderer>());
            Destroy(gameObject, audioClip.length);
        }
        else
        {
            Debug.Log($"{name} collided with {healthSystem.name}");
            healthSystem.DealDamage(damage);
            Destroy(gameObject);
            Debug.Log($"The player Health now is {healthSystem.getHealth}");
        }

    }
}
