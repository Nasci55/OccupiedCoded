using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    [SerializeField] 
    private float cameraSpeed = 0.06f;
    [SerializeField] 
    Vector3 offset;
    
    private Transform playerTransform;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerTransform == null)
        {
            Player player = FindFirstObjectByType<Player>();
            if (player == null) return;
            playerTransform = player.GetCameraTarget();
        }
        
            Vector3 targetPos = playerTransform.position + offset;
            targetPos.z = transform.position.z;


        Debug.Log(Vector3.Distance(playerTransform.position, transform.position));

        if (Vector3.Distance(playerTransform.position, transform.position) <= 300)
        {
            Vector3 toDestination = targetPos - transform.position;
            transform.position += toDestination * cameraSpeed;
        }
        else
        {
            transform.position = targetPos;
        }
    }
}
