using Unity.VisualScripting;
using UnityEngine;

public class ChandTrigger : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("The trap is deactivated");
        }
        else
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
