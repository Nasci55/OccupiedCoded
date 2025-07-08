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
    }
    private void Update()
    {

        if (isPlayerInside && Input.GetKeyDown(KeyCode.W))
        {
            OnDoorOpen();
            player.transform.position = new Vector3(Door.position.x, Door.position.y, player.transform.position.z);
            camera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 38, camera.transform.position.z);
        }
        if (isDoorOpening)
        {
            AnimatorStateInfo stateInfo = DoorAnimator.GetCurrentAnimatorStateInfo(0);
            Debug.Log("Door animation state: " + stateInfo.normalizedTime);
            if (stateInfo.normalizedTime >= 1.0f )
            {
                Debug.Log("Door animation completed");
                DoorUI.SetActive(false);
                isDoorOpening = false;
            }
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

    private bool isDoorOpening = false;
    private void OnDoorOpen()
    {
        //Debug.Log("Door opened");
        DoorUI.SetActive(true);
        DoorAnimator.SetTrigger("OpenDoor");
        isDoorOpening = true;
        
    }

}
