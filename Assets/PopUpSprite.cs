using UnityEngine;
using UnityEngineInternal;

public class PopUpSprite : MonoBehaviour
{
    
    private SpriteRenderer popUpVisual;

    private void Start()
    {
        popUpVisual = GetComponent<SpriteRenderer>();
       
        popUpVisual.enabled = false;
    }
    

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Player>())
        {
            popUpVisual.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.GetComponent<Player>())
        {
            popUpVisual.enabled = false;
        }
    }
}
