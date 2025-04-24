using Unity.VisualScripting;
using UnityEngine;

public class ChandTrigger : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private AudioClip audioClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("The trap is deactivated");
        }
        else
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            SoundManager.instance.playSound(audioClip, transform, 0.1f);
            Destroy(gameObject.GetComponent<BoxCollider2D>());
            Destroy(gameObject.GetComponent<SpriteRenderer>());
        }
    }
}
