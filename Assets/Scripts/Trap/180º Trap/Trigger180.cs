using Unity.VisualScripting;
using UnityEngine;

public class Trigger180 : MonoBehaviour
{
    private bool activated = false;
    Player player;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        player = collider.GetComponentInParent<Player>();
        if (player != null)
        {
            activated = true;
            Debug.Log($"This is {collider.name}");
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            Debug.Log($"This is not a player, this is a {collider.name}");
        }
    }

    public bool isActivated() => activated;

    public bool setActivate(bool condition)
    {
        return activated = condition;
    }

}
