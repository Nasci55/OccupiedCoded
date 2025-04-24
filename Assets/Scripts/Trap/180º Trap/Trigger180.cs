using Unity.VisualScripting;
using UnityEngine;

public class Trigger180 : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    
    private bool activated = false;
    Player player;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        player = collider.GetComponentInParent<Player>();
        if (player != null)
        {
            activated = true;
            Debug.Log($"This is {collider.name}");
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            SoundManager.instance.playSound(audioClip, transform, 0.1f);
            Destroy(gameObject.GetComponent<BoxCollider2D>());
            Destroy(gameObject.GetComponent<SpriteRenderer>());
        }
        else
        {
            Debug.Log($"This is not a player, this is a {collider.name}");
        }
    }

    public bool isActivated() => activated;

    public bool setActivate(bool condition)
    {
        return activated = condition;
    }

}
