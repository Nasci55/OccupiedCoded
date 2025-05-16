using UnityEngine;

public class VaultKey : MonoBehaviour
{
    public bool isKeyCollected {get; private set;}

    private void Start()
    {
        isKeyCollected=false;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        isKeyCollected = true;
        Debug.Log("ooo");
        if (isKeyCollected == true)
        {
            foreach (Transform child in transform)
            {
                Debug.Log("Opa");
                child.gameObject.SetActive(false);
            }
        }
    }
}
