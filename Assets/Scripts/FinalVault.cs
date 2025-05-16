using UnityEngine;

public class FinalVault : MonoBehaviour
{
    [SerializeField]
    private VaultKey Key;

    private bool didThePLayerGetTheKey;
    private bool isPlayerInside = false;
    private Collider2D WallCollider;
    private Player player;
        
    private void Start()
    {
       didThePLayerGetTheKey = Key.isKeyCollected;
       WallCollider = GetComponentInChildren<Collider2D>();
       player = FindFirstObjectByType<Player>();
    }

    private void Update()
    {
        if (isPlayerInside == true
            && Input.GetKeyDown(KeyCode.W)
            && didThePLayerGetTheKey == true)
        {
            WallCollider.enabled = true;

        }
        else if (isPlayerInside == true
                 && Input.GetKeyDown(KeyCode.W)
                 && didThePLayerGetTheKey == false)
        {
            Debug.Log("Nope");
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider == player.GetComponent<Collider2D>())
        {
            isPlayerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider == player.GetComponent<Collider2D>())
        {
            isPlayerInside = false;
        }
    }

}
