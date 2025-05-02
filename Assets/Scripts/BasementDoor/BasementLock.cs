using UnityEngine;

public class BasementLock : MonoBehaviour
{
    private bool IsLocked = false;
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
        }
    }

    public bool GeIsLocked()
    { return IsLocked; }


}
