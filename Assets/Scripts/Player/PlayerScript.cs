using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{

    [SerializeField]
    private Vector2 velocity;
    private Rigidbody2D rb;
    [SerializeField]
    private string horizontalAxisName = "Horizontal";
    private SpriteRenderer spriteRenderer;
    private Camera mainCamera;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        float moveDir = Input.GetAxis(horizontalAxisName);

        rb.linearVelocity = new Vector2(moveDir * velocity.x, rb.linearVelocity.y);

        if (mousePos.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        }
        else if(mousePos.x > transform.position.x)
        {
            transform.rotation = Quaternion.identity;
        }
        
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * velocity.y, ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.LeftShift) == true)
        {
            rb.linearVelocity = new Vector2(moveDir * velocity.x/2, rb.linearVelocity.y);
        }
    }
}
