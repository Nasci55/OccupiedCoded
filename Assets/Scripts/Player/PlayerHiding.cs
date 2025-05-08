using UnityEngine;

public class PlayerHiding : MonoBehaviour
{
    private TAG_HidingPlace hidingPlace;
    private bool isHiding = false;
    private bool currentlyHiding = false;
    private TAG_PlayerDetection player;
    private Collider2D playerCollider;


    void Start()
    {
        player = FindFirstObjectByType<TAG_PlayerDetection>();
        playerCollider = player.GetComponentInChildren<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isHiding == true && Input.GetKeyDown(KeyCode.W) && currentlyHiding == false)
        {
              foreach (Transform child in transform)
              {
                  child.gameObject.SetActive(false);
              }
              playerCollider.enabled = false;  
              currentlyHiding = true; 
            
        }
        else if (isHiding == true && Input.GetKeyDown(KeyCode.W) && currentlyHiding == true)
        {
            foreach (Transform child in transform)
            {
                Debug.Log(child.gameObject);
                child.gameObject.SetActive(true);
            }
            playerCollider.enabled = true;
            currentlyHiding = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        hidingPlace = collider.GetComponent<TAG_HidingPlace>();
        if (hidingPlace != null)
        {
            isHiding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        hidingPlace = collider.GetComponent<TAG_HidingPlace>();
        if (hidingPlace != null)
        {
            isHiding = false;
        }
    }
}
