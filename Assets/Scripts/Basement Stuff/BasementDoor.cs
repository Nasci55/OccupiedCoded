using UnityEngine;

public class BasementDoor : MonoBehaviour
{
    [SerializeField]
    private BasementLock isUnlocked;

    private bool isPlayerInside;
    private Player player;
    private SpriteRenderer lockSprite;

    private void Start()
    {
        player = FindFirstObjectByType<Player>();
 
        lockSprite = GetComponentInChildren<SpriteRenderer>();
        
    }
    private void Update()
    {
        if (isUnlocked.GetIsLocked() == true)
        {
            lockSprite.enabled = false;
        }
        else
        {
            lockSprite.enabled = true;
        }

        if (isPlayerInside == true
            && Input.GetKeyDown(KeyCode.W)
            && isUnlocked.GetIsLocked() == true)
        {
            player.transform.position = new Vector3(873.5f, -17.3999996f, -1.9902519f);

        }
        else if (isPlayerInside == true
                 && Input.GetKeyDown(KeyCode.W)
                 && isUnlocked.GetIsLocked() == false)
        {
            Debug.Log("Nope");
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Player playerCollider = collider.GetComponent<Player>();
        if (playerCollider != null)
        {
            isPlayerInside = true;
            Debug.Log("Player entered the area");
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        Player playerCollider = collider.GetComponent<Player>();
        if (playerCollider != null)
        {
            isPlayerInside = false;
            Debug.Log("Player left the area");
        }
    }


}
