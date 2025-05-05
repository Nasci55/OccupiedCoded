using UnityEngine;

public class ChandKill : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField]
    private AudioClip audioClip;
    [SerializeField] 
    private AudioClip audioClipHitting;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        HealthSystem healthSystem = collider.GetComponentInParent<HealthSystem>();
        if (healthSystem == null)
        {
            SoundManager.instance.playSound(audioClip, transform, 0.07f);
            Destroy(gameObject.GetComponent<BoxCollider2D>());
            Destroy(gameObject.GetComponent<SpriteRenderer>());
            Destroy(gameObject, audioClip.length);
        }
        else
        {
            SoundManager.instance.playSound(audioClipHitting, transform, 0.5f);
            healthSystem.DealDamage(damage);
            Destroy(gameObject.GetComponent<BoxCollider2D>());
            Destroy(gameObject.GetComponent<SpriteRenderer>());
            Destroy(gameObject, audioClipHitting.length);

        }

    }
}
