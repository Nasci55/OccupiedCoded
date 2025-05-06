using UnityEngine;

public class PlayerHiding : MonoBehaviour
{
    HidingPlaceTag hidingPlace;
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
            
        }
    }
}
