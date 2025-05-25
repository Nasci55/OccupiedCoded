using UnityEngine;
using UnityEngineInternal;

public class PopUpSprite : MonoBehaviour
{
    
    private Player player;
    private SpriteRenderer popUpVisual;

    private void Start()
    {
        popUpVisual = GetComponent<SpriteRenderer>();
        popUpVisual.enabled = false;
        player = FindFirstObjectByType<Player>();
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        player = collider.GetComponent<Player>();
        if (player != null)
        {
            popUpVisual.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        player = collider.GetComponent<Player>();
        if (player != null)
        {
            popUpVisual.enabled = false;
        }
    }
}
