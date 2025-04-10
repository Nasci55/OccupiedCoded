using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float groundCheckRadius = 2.0f;
    [SerializeField]
    private Vector2 velocity;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask groundCheckLayers;
    [SerializeField]
    private float jumpMaxDuration;
    [SerializeField]
    private float gravityScaling = 2.0f;
    [SerializeField]
    private Transform cameraTarget;

    private float jumpTimer;
    private Rigidbody2D rb;
    private string horizontalAxisName = "Horizontal";
    private SpriteRenderer spriteRenderer;
    private Camera mainCamera;
    private bool isGrounded;
    private float originalGravity = 1;


    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }   

    // Update is called once per frame
    void Update()
    {
        ComputeGrounded();
        
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        float moveDir = Input.GetAxis(horizontalAxisName);


        Vector2 currentVelocity = rb.linearVelocity;

        currentVelocity.x = moveDir * velocity.x;


        if (mousePos.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        }
        else if(mousePos.x > transform.position.x)
        {
            transform.rotation = Quaternion.identity;
        }
        
        
        
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                currentVelocity.y = velocity.y;
                jumpTimer = 0;
                rb.gravityScale = originalGravity;
            }
        }
        else if (jumpTimer < jumpMaxDuration)
        {
            jumpTimer += Time.deltaTime;
            if (Input.GetButton("Jump"))
            {
                rb.gravityScale = Mathf.Lerp(gravityScaling, originalGravity, jumpTimer/jumpMaxDuration);
            }
            else
            {
                jumpTimer = jumpMaxDuration;
                rb.gravityScale = originalGravity;
            }
        }
        else
        {
            rb.gravityScale = originalGravity;
        }

        if (Input.GetKey(KeyCode.LeftShift) == true)
        {
            currentVelocity.x /= 3;
        }
        
        rb.linearVelocity = currentVelocity;
    }


    private void ComputeGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundCheckLayers);

        if (collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

    }

    public bool GetIsGrounded => isGrounded;

    public Transform GetCameraTarget()
    {
        return cameraTarget;
    }
}
