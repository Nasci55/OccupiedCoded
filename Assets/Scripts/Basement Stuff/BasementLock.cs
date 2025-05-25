using UnityEngine;

public class BasementLock : MonoBehaviour
{
    public bool IsLocked { get; private set; }
    private Player player;

    void Start()
    {
        player = FindFirstObjectByType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        player = collider.GetComponentInParent<Player>();
        if (player != null)
        {
            IsLocked = true;
            Destroy(gameObject.GetComponent<SpriteRenderer>());
            Destroy(gameObject.GetComponent<BoxCollider2D>());
        }
    }



}
