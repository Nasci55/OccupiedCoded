using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public enum Type{ Teleport, Linear,  FeedbackLoop };
    public Type type;
    [SerializeField] private float cameraSpeed = 100.0f;
    private Transform playerTransform;
    [SerializeField] Vector3 offset;
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

      
        Vector3 toDestination = targetPos - transform.position;
        transform.position += toDestination * cameraSpeed;
    }
}
