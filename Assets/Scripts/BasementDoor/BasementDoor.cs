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
        
    }

    private void Update()
    {

        if (isPlayerInside && Input.GetKeyDown(KeyCode.W))
        {
            
        }
    }
}
