using UnityEngine;

public class PlayerHiding : MonoBehaviour
{
    private TAG_HidingPlace hidingPlace;
    private bool isHiding = false;
    private bool currentlyHiding = false;
    private Collider2D playerCollider;
    private Rigidbody2D playerRB;
    private float originalGravity; 

    void Start()
    {
        playerCollider = GetComponent<Collider2D>();
        playerRB = GetComponent<Rigidbody2D>();
        originalGravity = playerRB.gravityScale;
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
              currentlyHiding = true; 
            
        }
        else if (isHiding == true && Input.GetKeyDown(KeyCode.W) && currentlyHiding == true)
        {
            foreach (Transform child in transform)
            {
                Debug.Log(child.gameObject);
                child.gameObject.SetActive(true);
            }
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
