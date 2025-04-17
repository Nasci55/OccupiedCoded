using Unity.VisualScripting;
using UnityEngine;

public class Trigger180 : MonoBehaviour
{
    private bool isActivated = false;
    Player player;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        player = collider.GetComponentInParent<Player>();
        if (player != null)
        {
            isActivated = true;
            Debug.Log($"This is {collider.name}");
        }
        else
        {
            Debug.Log($"This is not a player, this is a {collider.name}");
        }
    }

    public bool IsActivated() => isActivated;
}
