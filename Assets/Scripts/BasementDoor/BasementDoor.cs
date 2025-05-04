using UnityEngine;

public class BasementDoor : MonoBehaviour
{
    private BasementLock isUnlocked;
    private bool isPlayerInside;
    private Player player;
    private Camera camera;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        isPlayerInside = true;
        Debug.Log("Player entered the area");
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        isPlayerInside = false;
        Debug.Log("Player left the area");
    }

    private void Start()
    {
        player = FindFirstObjectByType<Player>();
        camera = FindFirstObjectByType<Camera>();
        isUnlocked = FindFirstObjectByType<BasementLock>();
        
    }

    private void Update()
    {

        if (isPlayerInside == true
            && Input.GetKeyDown(KeyCode.W)
            && isUnlocked.GeIsLocked() == true)
        {
            player.transform.position = new Vector3(873.5f, -17.3999996f, -1.9902519f);
        }
        else if (isPlayerInside == true 
                 &&  Input.GetKeyDown(KeyCode.W) 
                 && isUnlocked.GeIsLocked() == false)
        {
            Debug.Log("Nope");
        }
        
    }
}
