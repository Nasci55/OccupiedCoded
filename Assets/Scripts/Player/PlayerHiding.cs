using UnityEngine;

public class PlayerHiding : MonoBehaviour
{
    private TAG_HidingPlace hidingPlace;
    private bool isHiding = false;
    public bool currentlyHiding { get; private set; }
    private TAG_PlayerDetection playerDetection;
    private Collider2D mainPlayerCollider;
    private Collider2D playerCollider;


    void Start()
    {
        playerDetection = FindFirstObjectByType<TAG_PlayerDetection>();
        playerCollider = playerDetection.GetComponentInChildren<Collider2D>();
        mainPlayerCollider = GetComponent<Collider2D>();
        currentlyHiding = false;
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
            Debug.Log("Escondido");
            foreach (Transform child in transform)
            {
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
            Debug.Log("Está escondido");
            isHiding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        hidingPlace = collider.GetComponent<TAG_HidingPlace>();
        if (hidingPlace != null)
        {
            Debug.Log("Não está esocndido");
            isHiding = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        hidingPlace = collider.GetComponent<TAG_HidingPlace>();
        if (hidingPlace != null)
        {
            Debug.Log("Está esocndido");
            isHiding = true;
        }
        
    }
}
