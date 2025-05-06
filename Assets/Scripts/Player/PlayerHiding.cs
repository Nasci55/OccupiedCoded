using UnityEngine;

public class PlayerHiding : MonoBehaviour
{
    private HidingPlaceTag hidingPlace;
    private bool isHiding = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        hidingPlace = collider.GetComponent<HidingPlaceTag>();
        if (hidingPlace != null)
        {
            isHiding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        hidingPlace = collider.GetComponent<HidingPlaceTag>();
        if (hidingPlace != null)
        {
            isHiding = false;
        }
    }
}
