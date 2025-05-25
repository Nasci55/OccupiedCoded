using UnityEngine;
using UnityEngineInternal;

public class PopUpSprite : MonoBehaviour
{
    private DoorSystem popUpAppearsForDoor;
    private BasementDoor popUpAppearsForBasementDoor;
    private PlayerHiding popUpAppearsForPlayerHiding;

    private SpriteRenderer popUpVisual;

    private void Start()
    {
        popUpVisual.enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider == (popUpAppearsForBasementDoor
                    || popUpAppearsForPlayerHiding
                    || popUpAppearsForDoor))
        {
            popUpVisual.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider == (popUpAppearsForBasementDoor
                   || popUpAppearsForPlayerHiding
                   || popUpAppearsForDoor))
        {
            popUpVisual.enabled = false;
        }
    }
}
