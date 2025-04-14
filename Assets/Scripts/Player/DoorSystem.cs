using UnityEngine;

public class DoorSystem : MonoBehaviour
{

    [SerializeField] private Transform Door;
    private bool isPlayerInside;
    private Player player;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        isPlayerInside = true;
        Debug.Log("Player entered the door area");
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        isPlayerInside = false;
        Debug.Log("Player left the door area");
    }

    private void Start()
    {
      player = FindFirstObjectByType<Player>();
    }
    private void Update()
    {
        
        if (isPlayerInside && Input.GetKeyDown(KeyCode.W))
        {
            player.transform.position = Door.position;
            Debug.Log("Player teleported to door position");
        }
    }
}
