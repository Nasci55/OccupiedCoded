using UnityEngine;
using UnityEngine.SceneManagement;

public class BasementDoor : MonoBehaviour
{
    [SerializeField]
    private BasementLock isUnlocked;
    [SerializeField]
    private Transform doorExit;
    [SerializeField]
    private GameObject lockSprite;

    [SerializeField] private bool changeScene;
    [SerializeField] private string sceneName;

    [SerializeField] private GameObject DoorUI;
    [SerializeField] private Animator DoorAnimator;

    private bool isPlayerInside;
    private Player player;

    private void Start()
    {
        if (lockSprite == null)
        {
            Debug.LogWarning("No popUpVisual attached");
        }
        player = FindFirstObjectByType<Player>();
 
        
    }
    private void Update()
    {
        if (isUnlocked.IsLocked == true)
        {
            lockSprite.SetActive(false);
        }
        else
        {
            lockSprite.SetActive(true);
        }

        if (isPlayerInside == true
            && Input.GetKeyDown(KeyCode.W)
            && isUnlocked.IsLocked == true)
        {
            OnDoorOpen();
            if (!changeScene)
                player.transform.position = new Vector3(doorExit.position.x, doorExit.position.y, player.transform.position.z);
            else
            {
                player.transform.position = new Vector3(doorExit.position.x, doorExit.position.y, player.transform.position.z);
                SceneManager.LoadScene($"{sceneName}");
            }
        }
        else if (isPlayerInside == true
                 && Input.GetKeyDown(KeyCode.W)
                 && isUnlocked.IsLocked == false)
        {
            Debug.Log("Nope");
        }
        if (isDoorOpening)
        {
            AnimatorStateInfo stateInfo = DoorAnimator.GetCurrentAnimatorStateInfo(0);
            Debug.Log("Door animation state: " + stateInfo.normalizedTime);
            if (stateInfo.normalizedTime >= 1.0f)
            {
                Debug.Log("Door animation completed");
                DoorUI.SetActive(false);
                isDoorOpening = false;
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Player playerCollider = collider.GetComponent<Player>();
        if (playerCollider != null)
        {
            isPlayerInside = true;
            //Debug.Log("Player entered the area");
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        Player playerCollider = collider.GetComponent<Player>();
        if (playerCollider != null)
        {
            isPlayerInside = false;
            //Debug.Log("Player left the area");
        }
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
