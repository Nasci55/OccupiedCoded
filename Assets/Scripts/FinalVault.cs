using UnityEngine;

public class FinalVault : MonoBehaviour
{
    [SerializeField]
    private VaultKey Key;

    private bool didThePLayerGetTheKey;
    private bool isPlayerInside = false;
    [SerializeField]
    private Collider2D WallCollider;
    private Player player;
        
    private void Start()
    {
       player = FindFirstObjectByType<Player>();
    }

    private void Update()
    {
        didThePLayerGetTheKey = Key.isKeyCollected;
        Debug.Log($"Key: {didThePLayerGetTheKey}, Inside : {isPlayerInside}, W: {Input.GetKeyDown(KeyCode.W)}");
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
        if (collider != null)
        {
            isPlayerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider != null)
        {
            isPlayerInside = false;
        }
    }

}
