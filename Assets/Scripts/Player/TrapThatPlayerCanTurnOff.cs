using Unity.VisualScripting;
using UnityEngine;

public class TrapThatPlayerCanTurnOff : MonoBehaviour 
{
    private bool trapAcitvate = false;
    private Player player;
    private Collider2D trapCollider;
    private Collider2D playerCollision;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<Player>();
        playerCollision = player.GetComponent<Collider2D>();
        trapCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.)
        {
            Debug.Log("OPA");
        }
    }
}
