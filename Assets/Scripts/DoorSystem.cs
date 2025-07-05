using UnityEngine;

public class DoorSystem : MonoBehaviour
{

    [SerializeField] private Transform Door;
    [SerializeField] private GameObject DoorUI;
    [SerializeField] private Animator DoorAnimator;
    private bool isPlayerInside;
    private Player player;
    private Camera camera;


    private void Start()
    {
        player = FindFirstObjectByType<Player>();
        camera = FindFirstObjectByType<Camera>();
        DoorAnimator = GetComponent<Animator>();
    }
    private void Update()
    {

        if (isPlayerInside && Input.GetKeyDown(KeyCode.W))
        {
            player.transform.position = new Vector3(Door.position.x, Door.position.y, player.transform.position.z);
            camera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 38, camera.transform.position.z);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Player findColl = collider.GetComponent<Player>();
        if (findColl != null)
        {
            isPlayerInside = true;
            //Debug.Log("Player entered the area");
        }
        else { }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        Player findColl = collider.GetComponent<Player>();
        if (findColl != null)
        {
            isPlayerInside = false;
            //Debug.Log("Player left the area");
        }
        else { }
    }

    private void OnDoorOpen()
    {
        //Debug.Log("Door opened");
        DoorUI.SetActive(true);
        DoorAnimator.SetTrigger("Open");
    }

    public void OnDoorClose()
    {
        //Debug.Log("Door closed");
        DoorUI.SetActive(false);
    }


}
